
float2 Rotate2D(float2 uv,float radial){
	float cos10 = cos( radial );
	float sin10 = sin( radial );
	float2x2 rotate2D =  float2x2( cos10 , -sin10 , sin10 , cos10 );
	float2 rotator10 = mul( ( uv ) - float2( 0.5,0.5 ) ,rotate2D) + float2( 0.5,0.5 );
	return rotator10;
}

float DrawCircle(float2 uv,float2 offset,float2 size,float2 ssMinMax){
	uv -= 0.5;
	uv -= offset;
	uv /= size;
	float circle = 1- length(uv) * 2;
	return smoothstep(ssMinMax.x,ssMinMax.y,circle);
}

float Remap(float oldMin,float oldMax,float newMin,float newMax,float val){
	float percent = (val - oldMin)/ (oldMax - oldMin);
	return (newMax - newMin) * percent + newMin;
}


inline float2 SAMPLE_DISTORT_TEX(sampler2D tex, float2 uv){
    float4 packednormal = tex2D( tex, uv);
    #if !defined(UNITY_NO_DXT5nm)
        packednormal.x *= packednormal.w;
    #endif
    return packednormal.xy * 2 - 1;
}