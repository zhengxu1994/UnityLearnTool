
#ifndef FMST01_COLOR_BELND
#define FMST01_COLOR_BELND

// from shader weaver
float BlendAddf(float base,float act){	return min(base+act, 1.0);}
float BlendSubstractf(float base,float act){return max(base + act - 1.0, 0.0);}
float BlendLightenf(float base,float act){return max(base, act);}
float BlendDarkenf(float base,float act){return min(base,act);}
float BlendLinearLightf(float base,float act){return (act < 0.5 ? BlendSubstractf(base, (2.0 * act)) : BlendAddf(base, (2.0 * (act - 0.5))));}
float BlendScreenf(float base,float act){return (1.0 - ((1.0 - base) * (1.0 - act)));}
float BlendOverlayf(float base,float act){return (base < 0.5 ? (2.0 * base * act) : (1.0 - 2.0 * (1.0 - base) * (1.0 - act)));}
float BlendSoftLightf(float base,float act){return ((act < 0.5) ? (2.0 * base * act + base * base * (1.0 - 2.0 * act)) : (sqrt(base) * (2.0 * act - 1.0) + 2.0 * base * (1.0 - act)));}
float BlendColorDodgef(float base,float act){return 	((act == 1.0) ? base : min(base / (1.0 - act), 1.0));}
float BlendColorBurnf(float base,float act){return ((act == 0.0) ? base : max((1.0 - ((1.0 - base) / act)), 0.0));}
float BlendVividLightf(float base,float act){return ((act < 0.5) ? BlendColorBurnf(base, (2.0 * act)) : BlendColorDodgef(base, (2.0 * (act - 0.5))));}
float BlendPinLightf(float base,float act){return ((act < 0.5) ? BlendDarkenf(base, (2.0 * act)) : BlendLightenf(base, (2.0 *(act - 0.5))));}
float BlendHardMixf(float base,float act){return ((BlendVividLightf(base, act) < 0.5) ? 0.0 : 1.0);}
float BlendReflectf(float base,float act){return ((act == 1.0) ? act : min(base * base / (1.0 - act), 1.0));}
float BlendDarkerColorf(float base,float act){return clamp(base-(1-base)*(1-act)/act,0,1);}

float3 BlendDarken(float3 base,float3 act){return min(base,act);}
float3 BlendColorBurn(float3 base, float3 act) {return float3(BlendColorBurnf(base.r,act.r),BlendColorBurnf(base.g,act.g),BlendColorBurnf(base.b,act.b));}
float3 BlendLinearBurn(float3 base,float3 act){return max(base + act - 1,0);}
float3 BlendDarkerColor(float3 base,float3 act){return (base.r+base.g+base.b)>(act.r+act.g+act.b)?act:base;}
float3 BlendLighten(float3 base,float3 act){return max(base, act);}
float3 BlendScreen(float3 base,float3 act){return float3(BlendScreenf(base.r,act.r),BlendScreenf(base.g,act.g),BlendScreenf(base.b,act.b));}
float3 BlendColorDodge(float3 base,float3 act){return float3(BlendColorDodgef(base.r,act.r),BlendColorDodgef(base.g,act.g),BlendColorDodgef(base.b,act.b));}
float3 BlendLinearDodge(float3 base,float3 act){return min(base+act, 1.0);}
float3 BlendLighterColor(float3 base,float3 act){return (base.r+base.g+base.b)>(act.r+act.g+act.b)?base:act;}
float3 BlendOverlay(float3 base,float3 act){return  float3(BlendOverlayf(base.r,act.r),BlendOverlayf(base.g,act.g),BlendOverlayf(base.b,act.b));}
float3 BlendSoftLight(float3 base,float3 act){return float3(BlendSoftLightf(base.r,act.r),BlendSoftLightf(base.g,act.g),BlendSoftLightf(base.b,act.b));}
float3 BlendHardLight(float3 base,float3 act){return BlendOverlay(act, base);}
float3 BlendVividLight(float3 base,float3 act){return float3(BlendVividLightf(base.r,act.r),BlendVividLightf(base.g,act.g),BlendVividLightf(base.b,act.b));}
float3 BlendLinearLight(float3 base,float3 act){return float3(BlendLinearLightf(base.r,act.r),BlendLinearLightf(base.g,act.g),BlendLinearLightf(base.b,act.b));}
float3 BlendPinLight(float3 base,float3 act){return float3(BlendPinLightf(base.r,act.r),BlendPinLightf(base.g,act.g),BlendPinLightf(base.b,act.b));}
float3 BlendHardMix(float3 base,float3 act){return float3(BlendHardMixf(base.r,act.r),BlendHardMixf(base.g,act.g),BlendHardMixf(base.b,act.b));}
float3 BlendDifference(float3 base,float3 act){return abs(base - act);}
float3 BlendExclusion(float3 base,float3 act){return (base + act - 2.0 * base * act);}
float3 BlendSubtract(float3 base,float3 act){return max(base - act, 0.0);}

#endif