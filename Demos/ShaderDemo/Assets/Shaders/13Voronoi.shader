Shader "Unlit/13Voronoi"
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
            float2 Hash22(float2 val){
                float x = frac(sin(dot(val * 62.1, fixed2(127.1, 311.7))) * 43758.5453123);
                float y = frac(sin(dot(val , fixed2(12.9898, 78.233))) * 3758.547);
                return float2(x,y);
            }
            #define GRID_SIZE 5

            fixed4 frag (v2f i) : SV_Target
            {
                float4 ret = 0;
                float2 uv = i.uv;
                uv *= GRID_SIZE;
                float2 gridId = floor(uv);
                float2 hash = Hash22(gridId);
                hash = (sin(_Time.y + hash * 6.28)) * 0.5 +0.5;
                if(length(uv - (gridId + hash)) < 0.05) return float4(1,0,0,1);
                float2 fuv = frac(uv);
                //return float4(fuv,0,1);
                float minDist = 1000;
                for (int i = -1; i <= 1; ++i)
                {
                    for (int j = -1; j <= 1; ++j)
                    {
                       float2 id = gridId + float2(i,j);
                       float2 h = Hash22(id);
                       h = (sin(_Time.y + h * 6.28)) * 0.5 +0.5;
                       float2 pos = id + h;
                       float2 diff = uv - pos;
                       float dist = dot(diff,diff);
                       if(dist < minDist){
                            minDist = dist;
                       }
                    }
                }
                return sqrt(minDist);
            }
            ENDCG
        }
    }
}
