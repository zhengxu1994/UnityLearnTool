Shader "Unlit/12Shader2D Tips"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            //fixed4 frag (v2f i) : SV_Target{ return 1;}
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 rawUV = uv;
                uv = (uv -0.5) *3;
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
                for (int i = 0; i < 12; ++i)
                {
                    if(length(uv - divi[i]) < 0.05){
                        return float4(1,0,0,1);
                    }
                }
                return 1;
            }
            ENDCG
        }
    }
}
