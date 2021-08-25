
#ifndef FMST01_UTIL2D
#define FMST01_UTIL2D

#include "ColorBlend.cginc"
#include "ColorUtil.cginc"
#include "PostProcess.cginc"
#include "UVOperator.cginc"

float DrawCircle(float2 uv,float2 offset,float2 size,float2 ssMinMax){
	uv -= 0.5;
	uv -= offset;
	uv /= size;
	float circle = 1- length(uv) * 2;
	return smoothstep(ssMinMax.x,ssMinMax.y,circle);
}

inline float _FireHash2D(float2 x){	return frac(sin(dot(x, float2(13.454, 7.405)))*12.3043);}
float _FireVoronoi2D(float2 uv, float precision)
{
	float2 fl = floor(uv);
	float2 fr = frac(uv);
	float res = 1.0;
	for (int j = -1; j <= 1; j++){
		for (int i = -1; i <= 1; i++){
			float2 p = float2(i, j);
			float h = _FireHash2D(fl + p);
			float2 vp = p - fr + h;
			float d = dot(vp, vp);
			res += 1.0 / pow(d, 8.0);
		}
	}
	return pow(1.0 / res, precision);
}

float4 DrawFire(float2 uv, float posX, float posY, float precision, float smooth, float speed, float black)
{
	uv += float2(posX, posY);
	float t = _fTime *60 *speed;
	float vor1 = _FireVoronoi2D(uv * float2(6.0, 4.0) + float2(0, -t), precision);
	float vor2 = 0.5 + _FireVoronoi2D(uv * float2(6.0, 4.0) + float2(42, -t ) + 30.0, precision);
	float finalMask = vor1 * vor2  + (1.0 - uv.y);// belnd vor1 vor2
	finalMask += (1.0 - uv.y)* 0.5;	
	finalMask *= 0.7 - abs(uv.x - 0.5); // shape the fires 
	float4 result = smoothstep(smooth, 0.95, finalMask);
	result.a = saturate(result.a + black);
	return result;
}

#endif