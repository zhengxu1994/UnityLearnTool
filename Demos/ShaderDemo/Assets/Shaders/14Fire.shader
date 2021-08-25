Shader "FishMan/14Fire"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _UVScale ("_UVScale", Vector) = (5,5,1,1)
        _FlowSpeed ("_FlowSpeed", Float) = 10
        _FireVertMaskFactor ("_FireVertMaskFactor", Float) = 2
        _FireHoriMaskBaseVal ("_FireHoriMaskBaseVal", Float) = 0.7
        _FireSmoothMin1_Max1 ("_FireSmoothMin1_Max1", Vector) = (0.3,0.9,1,1)

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

            float Voronoi(float2 uv){
                float2 gridId = floor(uv);
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
            float2 _UVScale;
            float _FlowSpeed;//10
            float _FireVertMaskFactor;//2
            float _FireHoriMaskBaseVal;//0.7
            float2 _FireSmoothMin1_Max1;// 0.3 0.9
            float DrawFire(float2 rawUV,float2 uv,float time,
                float vertMaskFactor,float horiMaskBaseVal,
                float2 smothMinMax
                ){
                uv.y -= time;
                float vn = Voronoi(uv);
                float vn2 =0.5+ Voronoi(uv * float2(0.9,0.7) + float2(0.5,0.8));
                vn *= vn2;
                vn += (1- rawUV.y) * vertMaskFactor;
                vn *= horiMaskBaseVal- abs(rawUV.x - 0.5);
                vn = smoothstep(smothMinMax.x,smothMinMax.y,vn);
                return vn;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 ret = 0;
                float2 uv = i.uv;
                uv *= _UVScale;
                return DrawFire(i.uv, uv,_Time.y * _FlowSpeed
                    ,_FireVertMaskFactor
                    ,_FireHoriMaskBaseVal
                    ,_FireSmoothMin1_Max1
                    );
            }
            ENDCG
        }
    }
}
