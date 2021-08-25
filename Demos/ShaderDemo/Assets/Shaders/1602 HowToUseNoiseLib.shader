Shader "FishMan/1602HowToUseNoiseLib"
{
    Properties
    {
        [KeywordEnum(PERLIN_NOISE,VALUE_NOISE,SIMPLEX_NOISE)] Using("_NoiseType", Int) = 0 //0 = off, 2=back
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
            #pragma shader_feature USING_PERLIN_NOISE USING_VALUE_NOISE USING_SIMPLEX_NOISE
            #include "./ShaderLibs/FBM.cginc"
            
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

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * _TileSize;
                float val = 0;
                val = Noise(uv); if(_UseFBM) val = FBMR(uv);
                return val*0.5+0.5;
            }
            ENDCG
        }
    }
}
