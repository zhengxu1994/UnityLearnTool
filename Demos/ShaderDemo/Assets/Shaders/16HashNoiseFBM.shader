Shader "FishMan/16HashNoiseFBM"
{
    Properties
    {
        [KeywordEnum(Value,Perlin,Simplex,Triangle,Voronoi,Hash)] _Type("_NoiseType", Int) = 0 //0 = off, 2=back
        _TileSize("_TileSize",Int) = 15
        [Toggle()] _UseFBM("_UseFBM", Int) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            //#define USING_PERLIN_NOISE
            //#define USING_VALUE_NOISE
            //#define USING_SIMPLEX_NOISE
            #include "./ShaderLibs/FBM.cginc"
            #pragma shader_feature _TYPE_VALUE _TYPE_PERLIN _TYPE_SIMPLEX _TYPE_TRIANGLE _TYPE_VORONOI _TYPE_HASH 
           


            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            int _NoiseType;
            int _TileSize;
            int _UseFBM;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            #define FBMR(ret, p, Noise)\
            {\
                float f = 0.0;\
                f += 0.50000*Noise( p ); p = mul(_m2,p)*2.02;\
                f += 0.25000*Noise( p ); p = mul(_m2,p)*2.03;\
                f += 0.12500*Noise( p ); p = mul(_m2,p)*2.01;\
                f += 0.06250*Noise( p ); p = mul(_m2,p)*2.04;\
                f += 0.03125*Noise( p );\
                ret = f/0.984375;\
            }

            float _TNoise(float2 uv){ return TNoise(uv,0,0) *2 ; }
            float _WNoise(float2 uv){ return WNoise(uv,_Time.y)   *2 - 1; }
            float _Hash12(float2 uv){ return Hash12(uv)     *2 - 1; }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * _TileSize;
                float val = 0;
            #ifdef _TYPE_VALUE 
                val = VNoise(uv); if(_UseFBM) FBMR(val,uv,VNoise);
            #endif 
            #ifdef _TYPE_PERLIN 
                val = PNoise(uv); if(_UseFBM) FBMR(val,uv,PNoise);
            #endif 
            #ifdef _TYPE_SIMPLEX 
                val = SNoise(uv); if(_UseFBM) FBMR(val,uv,SNoise);
            #endif 
            #ifdef _TYPE_TRIANGLE 
                val = TNoise(uv,0,0); if(_UseFBM) FBMR(val,uv,_TNoise);
            #endif 
            #ifdef _TYPE_VORONOI 
                val = WNoise(uv,_Time.y); if(_UseFBM) FBMR(val,uv,_WNoise);
            #endif 
            #ifdef _TYPE_HASH
                {val = Hash12(uv); if(_UseFBM) FBMR(val,uv,_Hash12); return val;}
            #endif 
                return val*0.5+0.5;
            }
            ENDCG
        }
    }
}
