
#ifndef FMST01_POST_PROCESS
#define FMST01_POST_PROCESS

#include "Const.cginc"

//---------------------------    post effects  -------------------------------- //
// 模糊
float4 Blur(sampler2D sam,float2 rawUV,float offset)
{
    const int num =12;
	const float2 divi[12] = {float2(-0.326212f, -0.40581f),
	float2(-0.840144f, -0.07358f),
	float2(-0.695914f, 0.457137f),
	float2(-0.203345f, 0.620716f),
	float2(0.96234f, -0.194983f),
	float2(0.473434f, -0.480026f),
	float2(0.519456f, 0.767022f),
	float2(0.185461f, -0.893124f),
	float2(0.507431f, 0.064425f),
	float2(0.89642f, 0.412458f),
	float2(-0.32194f, -0.932615f),
	float2(-0.791559f, -0.59771f)};
	float4 col = float4(0,0,0,0);
	for(int i=0;i<num;i++)
	{
		float2 uv = rawUV + offset * divi[i];
		uv = saturate(uv);
		float4 c = tex2D(sam,uv);
		col += c;
	}
	col /= num;
	return col;
}
//fixed4 Blur(sampler2D sam, fixed2 rawUV, fixed offset)
//{
//	// 1 2 1
//	// 2 4 2
//	// 1 2 1
//	fixed step = 0.00390625f * offset;
//	fixed4 result = fixed4 (0, 0, 0, 0);
//	fixed2 texCoord = fixed2(0, 0);
//	texCoord = rawUV + fixed2(-step, -step);
//	result += tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(-step, 0);
//	result += 2.0 * tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(-step, step);
//	result += tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(0, -step);
//	result += 2.0 * tex2D(sam, texCoord);
//	texCoord = rawUV;
//	result += 4.0 * tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(0, step);
//	result += 2.0 * tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(step, -step);
//	result += tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(step, 0);
//	result += 2.0* tex2D(sam, texCoord);
//	texCoord = rawUV + fixed2(step, -step);
//	result += tex2D(sam, texCoord);
//	result = result * 0.0625;
//	return result;
//}


// 像素化
float2 Pixelate(float2 uv,float _PixelateSize)
{
	return floor(uv * _PixelateSize) / _PixelateSize;
}

// 取色
float4 Desaturate(float4 rawCol, float rate )
{
	fixed gray = dot(half3(0.22, 0.707, 0.071),rawCol.rgb);
	return lerp(rawCol, float4(gray,gray,gray,rawCol.a),rate);
}
// 色差
float4 ChromaticAberration(float4 rawCol,sampler2D tex,float2 uv, float4 tintColor, float factor ,float alpha )
{
	fixed4 r = tex2D(tex, uv + fixed2(factor, 0)) * tintColor;
	fixed4 b = tex2D(tex, uv + fixed2(-factor, 0)) * tintColor;
	return fixed4(r.r * r.a, rawCol.g, b.b * b.a, max(max(r.a, b.a) * alpha, rawCol.a)); 
}
// 2D 阴影
float4 Shadow2D(float4 rawCol, sampler2D tex, float2 uv, float2 shadowOffset, float4 shadowColor )
{
	fixed shadowA = tex2D(tex, uv + shadowOffset).a;
    rawCol.rgb = lerp((shadowColor.rgb * shadowA), rawCol.rgb, rawCol.a);
    rawCol.a = max(shadowA * shadowColor.a, rawCol.a); 
    return rawCol;
}

// 获取边界值
float _GetBorderAlpha(sampler2D tex,float2 uv,float offset){
	fixed spriteLeft = tex2D(tex, uv + fixed2(offset, 0)).a;
	fixed spriteRight = tex2D(tex, uv - fixed2(offset, 0)).a;
	fixed spriteBottom = tex2D(tex, uv + fixed2(0, offset)).a;
	fixed spriteTop = tex2D(tex, uv - fixed2(0, offset)).a;
	fixed result = spriteLeft + spriteRight + spriteBottom + spriteTop;

	fixed spriteTopLeft = tex2D(tex, uv + fixed2(offset, offset)).a;
	fixed spriteTopRight = tex2D(tex, uv + fixed2(-offset, offset)).a;
	fixed spriteBotLeft = tex2D(tex, uv + fixed2(offset, -offset)).a;
	fixed spriteBotRight = tex2D(tex, uv + fixed2(-offset, -offset)).a;
	result = result + spriteTopLeft + spriteTopRight + spriteBotLeft + spriteBotRight;
	return result;
}
inline fixed3 _GetPixel(float offsetX, float offsetY, fixed2 uv, sampler2D tex){
	return tex2D(tex, (uv + fixed2(offsetX ,offsetY))).rgb;
}
// 内部描边
float4 DrawInnerOutline(float4 rawCol,sampler2D tex,float2 uv,float4 outlineColor,float width,float alpha,float glow){
	fixed3 col = abs(_GetPixel(0, width, uv, tex) - _GetPixel(0, -width, uv, tex));
	col += abs(_GetPixel(width, 0, uv, tex) - _GetPixel(-width, 0, uv, tex));
	col *= rawCol.a * alpha;
	float outlineVal =  length(col) * glow;
	rawCol.rgb = lerp(rawCol.rgb,outlineColor.rgb,outlineVal);
	return rawCol;
}
// 外部描边
float4 DrawOutline(float4 rawCol,sampler2D tex,float2 uv,float4 outlineColor,float width,float alpha,float glow){
	float result = _GetBorderAlpha(tex,uv,width);
	result = step(0.01, result);
	result *= (1 - rawCol.a) *alpha;
	fixed4 outline = result * outlineColor;
	outline.rgb *= glow * 2;
	return lerp(outline,rawCol,rawCol.a);
}


float4 Contrast( float4 color , float4 blurred , float intensity , float threshold )
{
	half4 difference = color - blurred;
	half4 signs = sign (difference);
	
	half4 enhancement = saturate (abs(difference) - threshold) * signs * 1.0/(1.0-threshold);
	color += enhancement * intensity;
	
	return color;
}

float4 OldPhoto( float4 color , float rate )
{
	// get intensity value (Y part of YIQ color space)
	fixed Y = dot (fixed3(0.299, 0.587, 0.114), color.rgb);
	
	// Convert to Sepia Tone by adding constant
	fixed4 sepiaConvert = float4 (0.191, -0.054, -0.221, 0.0);
	fixed4 output = sepiaConvert + Y;
	output.a = color.a;
	return lerp(color,output,rate);
}


#endif