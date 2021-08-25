
#ifndef FMST01_UTIL2D
#define FMST01_UTIL2D
#include "Const.cginc"
//---------------------------   uv operators   -------------------------------- //

float2 DistortionUV(float2 p, float waveX, float waveY, float distanceX, float distanceY, float speed)
{
	speed *=_Time*100;
	p.x= p.x+sin(p.y*waveX + speed)*distanceX*0.05;
	p.y= p.y+cos(p.x*waveY + speed)*distanceY*0.05;
	return p;
}

float Remap(float oldMin,float oldMax,float newMin,float newMax,float val){
	float percent = (val - oldMin)/ (oldMax - oldMin);
	return (newMax - newMin) * percent + newMin;
}

float2 Remap2Rect(float2 uv,float4 rect)
{
	uv.x = lerp(rect.x,rect.x+rect.z, uv.x);
	uv.y = lerp(rect.y,rect.y+rect.w, uv.y);
	return uv;
}

float2 RotateAround2D(float2 center,float2 uv,float rad)
{
	float2 fuv = uv - center;
	float2x2 ma = float2x2(cos(rad),sin(rad),-sin(rad),cos(rad));
	fuv = mul(ma,fuv)+center;
	return fuv;
}

float2 FishEye( float2 uv , float size )
{
	float2 m = float2(0.5, 0.5);
	float2 d = uv - m;
	float r = sqrt(dot(d, d));
	float amount = (2.0 * 3.141592653 / (2.0 * sqrt(dot(m, m)))) * (size*0.5+0.0001);
	float bind = sqrt(dot(m, m));
	uv = m + normalize(d) * tan(r * amount) * bind/ tan(bind * amount);
	return uv;
}

float2 Pinch( float2 uv , float size )
{
	float2 m = float2(0.5, 0.5);
	float2 d = uv - m;
	float r = sqrt(dot(d, d));
	float amount = (2.0 * 3.141592653 / (2.0 * sqrt(dot(m, m)))) * (-size+0.001);
	float bind = 0.5;
	uv = m + normalize(d) * atan(r * -amount * 16.0) * bind / atan(-amount * bind * 16.0);
	return uv;
}

float2 Twirl( float2 uv , float value , float posx , float posy , float radius )
{
	value = value * _Deg2Rad;
	uv -= float2(posx,posy);
	float2 distortedOffset = RotateAround2D(float2(0,0),uv,value);
	float2 tmp = uv / radius;
	float t = min (1, length(tmp));
	uv = lerp (distortedOffset, uv, t);
	uv += float2(posx,posy);
	return uv;
}
float2 Vortex( float2 uv , float value , float posx , float posy , float radius )
{
	value = value * _Deg2Rad;
	uv -= float2(posx,posy);
	float angle = 1.0 - length(uv / radius);
	angle = max (0, angle);
	angle = angle * angle * value;
	float cosLength, sinLength;
	sincos (angle, sinLength, cosLength);
	
	float2 _uv;
	_uv.x = cosLength * uv[0] - sinLength * uv[1];
	_uv.y = sinLength * uv[0] + cosLength * uv[1];
	_uv += float2(posx,posy);
	return _uv;
}





#endif