// Merge  by JiepengTan@gmail.com
// https://github.com/JiepengTan/FishManShaderTutorial
// 2018-03-27
#ifndef FMST_NOISE
#define FMST_NOISE

#include "Hash.cginc"
// -------------------------------------------------
// PNoise  Perlin Noise
// VNoise  Value Noise
// SNoise  Simplex Noise
// TNoise  Triangle Noise
// WNoise  Voronoi Noise
// XxNoised means Noise with its derivatives
// all of these noise return [-1,1]
// -------------------------------------------------
sampler2D _NoiseTex;
#if defined(USING_PERLIN_NOISE) 
	#define Noise PNoise
#elif defined(USING_VALUE_NOISE) 
	#define Noise VNoise
    #if defined (USING_TEXLOD_NOISE)
    #undef USING_TEXLOD_NOISE
    #endif
#elif defined(USING_SIMPLEX_NOISE) 
	#define Noise SNoise
#else 
    #define Noise PNoise
#endif 

#if !defined(_USING_RAW_HASH) //  these hash return [-1,1] //  
    // https://www.shadertoy.com/view/XdXGW8
    float2 __hash22( float2 x )  // replace this by something better
    {
        const float2 k = float2( 0.3183099, 0.3678794 );
        x = x*k + k.yx;
        return -1.0 + 2.0*frac( 16.0 * k*frac( x.x*x.y*(x.x+x.y)) );
    }
    float __hash12(float2 p)  // replace this by something better
    {
        p  = 50.0*frac( p*0.3183099 + float2(0.71,0.113));
        return -1.0+2.0*frac( p.x*p.y*(p.x+p.y) );
    }
    float3 __hash33( float3 p ) // replace this by something better. really. do
    {
        p = float3( dot(p,float3(127.1,311.7, 74.7)),
                  dot(p,float3(269.5,183.3,246.1)),
                  dot(p,float3(113.5,271.9,124.6)));

        return -1.0 + 2.0*frac(sin(p)*43758.5453123);
    }
    float __hash13(float3 p)  // replace this by something better
    {
        p  = frac( p*0.3183099+.1 );
        p *= 17.0;
        return frac( p.x*p.y*p.z*(p.x+p.y+p.z) );
    }

    #define __Hash22 __hash22
    #define __Hash12 __hash12
    #define __Hash13 __hash13
    #define __Hash33 __hash33

#else
    #define __Hash22 Hash22 
    #define __Hash12 Hash12 
    #define __Hash13 Hash13 
    #define __Hash33 Hash33 
#endif

float __tri(in float x){return abs(frac(x)-.5);}
float2 __tri2(in float2 p){return float2(__tri(p.x+__tri(p.y*2.)), __tri(p.y+__tri(p.x*2.)));}
float3 __tri3(in float3 p){return float3(__tri(p.z+__tri(p.y*1.)), __tri(p.z+__tri(p.x*1.)), __tri(p.y+__tri(p.x*1.)));}



float PNoise( in float2 p )
{
    float2 i = floor( p );
    float2 f = frac( p );
	
	float2 u = f*f*(3.0-2.0*f);

    return lerp( lerp( dot( __Hash22( i + float2(0.0,0.0) ), f - float2(0.0,0.0) ), 
                     dot( __Hash22( i + float2(1.0,0.0) ), f - float2(1.0,0.0) ), u.x),
                lerp( dot( __Hash22( i + float2(0.0,1.0) ), f - float2(0.0,1.0) ), 
                     dot( __Hash22( i + float2(1.0,1.0) ), f - float2(1.0,1.0) ), u.x), u.y);
}

float PNoise( in float3 p )
{
    float3 i = floor( p );
    float3 f = frac( p );
	
	float3 u = f*f*(3.0-2.0*f);

    return lerp( lerp( lerp( dot( __Hash33( i + float3(0.0,0.0,0.0) ), f - float3(0.0,0.0,0.0) ), 
                          dot( __Hash33( i + float3(1.0,0.0,0.0) ), f - float3(1.0,0.0,0.0) ), u.x),
                     lerp( dot( __Hash33( i + float3(0.0,1.0,0.0) ), f - float3(0.0,1.0,0.0) ), 
                          dot( __Hash33( i + float3(1.0,1.0,0.0) ), f - float3(1.0,1.0,0.0) ), u.x), u.y),
                lerp( lerp( dot( __Hash33( i + float3(0.0,0.0,1.0) ), f - float3(0.0,0.0,1.0) ), 
                          dot( __Hash33( i + float3(1.0,0.0,1.0) ), f - float3(1.0,0.0,1.0) ), u.x),
                     lerp( dot( __Hash33( i + float3(0.0,1.0,1.0) ), f - float3(0.0,1.0,1.0) ), 
                          dot( __Hash33( i + float3(1.0,1.0,1.0) ), f - float3(1.0,1.0,1.0) ), u.x), u.y), u.z );
}


// https://www.shadertoy.com/view/XdXBRH
// https://stackoverflow.com/questions/4297024/3d-perlin-Noise-analytical-derivative
float3 Noised( in float2 p )
{
    float2 i = floor( p );
    float2 f = frac( p );

#if 1
    // quintic interpolation
    float2 u = f*f*f*(f*(f*6.0-15.0)+10.0);
    float2 du = 30.0*f*f*(f*(f-2.0)+1.0);
#else
    // cubic interpolation
    float2 u = f*f*(3.0-2.0*f);
    float2 du = 6.0*f*(1.0-f);
#endif    
    
    float2 ga = __Hash22( i + float2(0.0,0.0) );
    float2 gb = __Hash22( i + float2(1.0,0.0) );
    float2 gc = __Hash22( i + float2(0.0,1.0) );
    float2 gd = __Hash22( i + float2(1.0,1.0) );
    
    float va = dot( ga, f - float2(0.0,0.0) );
    float vb = dot( gb, f - float2(1.0,0.0) );
    float vc = dot( gc, f - float2(0.0,1.0) );
    float vd = dot( gd, f - float2(1.0,1.0) );

    return float3( va + u.x*(vb-va) + u.y*(vc-va) + u.x*u.y*(va-vb-vc+vd),   // value
                 ga + u.x*(gb-ga) + u.y*(gc-ga) + u.x*u.y*(ga-gb-gc+gd) +  // derivatives
                 du * (u.yx*(va-vb-vc+vd) + float2(vb,vc) - va));
}

// return value Noise (in x) and its derivatives (in yzw)
float4 Noised( in float3 x )
{
    // grid
    float3 p = floor(x);
    float3 w = frac(x);
    
    #if 1
    // quintic interpolant
    float3 u = w*w*w*(w*(w*6.0-15.0)+10.0);
    float3 du = 30.0*w*w*(w*(w-2.0)+1.0);
    #else
    // cubic interpolant
    float3 u = w*w*(3.0-2.0*w);
    float3 du = 6.0*w*(1.0-w);
    #endif    
    
    // gradients
    float3 ga = __Hash33( p+float3(0.0,0.0,0.0) );
    float3 gb = __Hash33( p+float3(1.0,0.0,0.0) );
    float3 gc = __Hash33( p+float3(0.0,1.0,0.0) );
    float3 gd = __Hash33( p+float3(1.0,1.0,0.0) );
    float3 ge = __Hash33( p+float3(0.0,0.0,1.0) );
    float3 gf = __Hash33( p+float3(1.0,0.0,1.0) );
    float3 gg = __Hash33( p+float3(0.0,1.0,1.0) );
    float3 gh = __Hash33( p+float3(1.0,1.0,1.0) );
    
    // projections
    float va = dot( ga, w-float3(0.0,0.0,0.0) );
    float vb = dot( gb, w-float3(1.0,0.0,0.0) );
    float vc = dot( gc, w-float3(0.0,1.0,0.0) );
    float vd = dot( gd, w-float3(1.0,1.0,0.0) );
    float ve = dot( ge, w-float3(0.0,0.0,1.0) );
    float vf = dot( gf, w-float3(1.0,0.0,1.0) );
    float vg = dot( gg, w-float3(0.0,1.0,1.0) );
    float vh = dot( gh, w-float3(1.0,1.0,1.0) );
    
    // interpolations
    return float4( va + u.x*(vb-va) + u.y*(vc-va) + u.z*(ve-va) + u.x*u.y*(va-vb-vc+vd) + u.y*u.z*(va-vc-ve+vg) + u.z*u.x*(va-vb-ve+vf) + (-va+vb+vc-vd+ve-vf-vg+vh)*u.x*u.y*u.z,    // value
                 ga + u.x*(gb-ga) + u.y*(gc-ga) + u.z*(ge-ga) + u.x*u.y*(ga-gb-gc+gd) + u.y*u.z*(ga-gc-ge+gg) + u.z*u.x*(ga-gb-ge+gf) + (-ga+gb+gc-gd+ge-gf-gg+gh)*u.x*u.y*u.z +   // derivatives
                 du * (float3(vb,vc,ve) - va + u.yzx*float3(va-vb-vc+vd,va-vc-ve+vg,va-vb-ve+vf) + u.zxy*float3(va-vb-ve+vf,va-vb-vc+vd,va-vc-ve+vg) + u.yzx*u.zxy*(-va+vb+vc-vd+ve-vf-vg+vh) ));
}




#ifdef USING_TEXLOD_NOISE
//IQ fast Noise3D https://www.shadertoy.com/view/ldScDh
float VNoise( in float3 x )
{
    float3 p = floor(x);
    float3 f = frac(x);
	f = f*f*(3.0-2.0*f);
	float2 uv = (p.xy+float2(37.0,17.0)*p.z) + f.xy;
	float2 rg = tex2Dlod( _NoiseTex, float4((uv+0.5)/256.0, 0.0,0.)).yx;
	return lerp( rg.x, rg.y, f.z );
}

//IQ fast Noise2D https://www.shadertoy.com/view/XsX3RB
float VNoise( in float2 x )
{
    float2 p = floor(x);
    float2 f = frac(x);
	f = f*f*(3.0-2.0*f);
	float2 uv = p.xy+ + f.xy;
	return tex2Dlod( _NoiseTex, float4((uv+0.5)/256.0, 0.,0.) ).x;
} 
#else
float VNoise(float2 p)
{
    float2 pi = floor(p);
    float2 pf = p - pi;
    
    float2 w = pf * pf * (3.0 - 2.0 * pf);
    
    return lerp(lerp(__Hash12(pi + float2(0.0, 0.0)), __Hash12(pi + float2(1.0, 0.0)), w.x),
               lerp(__Hash12(pi + float2(0.0, 1.0)), __Hash12(pi + float2(1.0, 1.0)), w.x),
               w.y);
}


float VNoise(float3 p)
{
    float3 pi = floor(p);
    float3 pf = p - pi;
    
    float3 w = pf * pf * (3.0 - 2.0 * pf);
    
    return  lerp(
                lerp(
                    lerp(__Hash13(pi + float3(0, 0, 0)), __Hash13(pi + float3(1, 0, 0)), w.x),
                    lerp(__Hash13(pi + float3(0, 0, 1)), __Hash13(pi + float3(1, 0, 1)), w.x), 
                    w.z),
                lerp(
                    lerp(__Hash13(pi + float3(0, 1, 0)), __Hash13(pi + float3(1, 1, 0)), w.x),
                    lerp(__Hash13(pi + float3(0, 1, 1)), __Hash13(pi + float3(1, 1, 1)), w.x), 
                    w.z),
                w.y);
}
#endif


float SNoise(float2 p)
{
    const float K1 = 0.366025404; // (sqrt(3)-1)/2;
    const float K2 = 0.211324865; // (3-sqrt(3))/6;
    
    float2 i = floor(p + (p.x + p.y) * K1);
    
    float2 a = p - (i - (i.x + i.y) * K2);
    float2 o = (a.x < a.y) ? float2(0.0, 1.0) : float2(1.0, 0.0);
    float2 b = a - (o - K2);
    float2 c = a - (1.0 - 2.0 * K2);
    
    float3 h = max(0.5 - float3(dot(a, a), dot(b, b), dot(c, c)), 0.0);
    float3 n = h * h * h * h * float3(dot(a, __Hash22(i)), dot(b, __Hash22(i + o)), dot(c, __Hash22(i + 1.0)));
    
    return dot(float3(70.0, 70.0, 70.0), n);
}

float SNoise(float3 p)
{
    const float K1 = 0.333333333;
    const float K2 = 0.166666667;
    
    float3 i = floor(p + (p.x + p.y + p.z) * K1);
    float3 d0 = p - (i - (i.x + i.y + i.z) * K2);
    
    // thx nikita: https://www.shadertoy.com/view/XsX3zB
    float3 e = step(float3(0.0,0.0,0.0), d0 - d0.yzx);
    float3 i1 = e * (1.0 - e.zxy);
    float3 i2 = 1.0 - e.zxy * (1.0 - e);
    
    float3 d1 = d0 - (i1 - 1.0 * K2);
    float3 d2 = d0 - (i2 - 2.0 * K2);
    float3 d3 = d0 - (1.0 - 3.0 * K2);
    
    float4 h = max(0.6 - float4(dot(d0, d0), dot(d1, d1), dot(d2, d2), dot(d3, d3)), 0.0);
    float4 n = h * h * h * h * float4(dot(d0, __Hash33(i)), dot(d1, __Hash33(i + i1)), dot(d2, __Hash33(i + i2)), dot(d3, __Hash33(i + 1.0)));
    
    return dot(float4(31.316,31.316,31.316,31.316), n);
}

float TNoise(float2 p,float time,float spd)
{
	const float2x2 m2 = float2x2( 0.970,  0.242, -0.242,  0.970 );
    float z=1.5;
	float rz = 0.;
    float2 bp = p;
	for (float i=0.; i<=4.; i++ )
	{
        float2 dg = __tri2(bp*2.)*.8;
        p += (dg+time)*spd;

        bp *= 1.6;
		z *= 1.8;
		p *= 1.2;
        p = mul(_m2,p);
        
        rz+= (__tri(p.x+__tri(p.y)))/z;
	}
	return rz;
}

//https://www.shadertoy.com/view/4ts3z2 
float TNoise(in float3 p, float time,float spd)
{
    float z=1.4;
	float rz = 0.;
    float3 bp = p;
	for (float i=0.; i<=3.; i++ )
	{
        float3 dg = __tri3(bp*2.);
        p += dg+time*spd;

        bp *= 1.8;
		z *= 1.5;
		p *= 1.2;
        
        rz+= (__tri(p.z+__tri(p.x+__tri(p.y))))/z;
        bp += 0.14;
	}
	return rz;
}

//voronoi worleyNoise
float WNoise(float2 p,float time) {
	float2 n = floor(p);
	float2 f = frac(p);
	float md = 5.0;
	float2 m = float2(0.,0.);
	for (int i = -1;i<=1;i++) {
		for (int j = -1;j<=1;j++) {
			float2 g = float2(i, j);
			float2 o = __Hash22(n+g);
			o = 0.5+0.5*sin(time+6.28*o);
			float2 r = g + o - f;
			float d = dot(r, r);
			if (d<md) {
				md = d;
				m = n+g+o;
			} 
		}
	}
	return md;
}
//3D version please ref to https://www.shadertoy.com/view/ldl3Dl
float3 WNoise( in float3 x ,float time)
{
    float3 p = floor( x );
    float3 f = frac( x );

    float id = 0.0;
    float2 res = float2( 100.0,100.0 );
    for( int k=-1; k<=1; k++ )
    for( int j=-1; j<=1; j++ )
    for( int i=-1; i<=1; i++ )
    {
        float3 b = float3( float(i), float(j), float(k) );
		float3 o = __Hash33( p + b );
		o = 0.5+0.5*sin(time+6.28*o);
        float3 r = float3( b ) - f + o;
        float d = dot( r, r );

        if( d < res.x )
        {
            id = dot( p+b, float3(1.0,57.0,113.0 ) );
            res = float2( d, res.x );         
        }
        else if( d < res.y )
        {
            res.y = d;
        }
    }

    return float3( sqrt( res ), abs(id) );
}

#endif // FMST_NOISE