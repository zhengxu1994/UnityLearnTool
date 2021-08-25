Shader "FishMan/17Snow"
{
    Properties
    {
        _LayerCount("Layer Count",Int) = 10
        _SpeedY("_SpeedY",Int) = 1

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
            #include "UnityCG.cginc"
            #include "./ShaderLibs/Util2D.cginc"
            #include "./ShaderLibs/Hash.cginc"

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
            float _LayerCount;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv =v.uv;
                return o;
            }
            float _SpeedY;
            float DrawSnowLayer(float2 uv,int layerId){
                float layerHash = Hash11(layerId);
                uv *= (2 + layerId);
                uv.x += uv.y * 0.3;
                uv.y += _Time.y  * _SpeedY + layerHash * 3;
                float2 gridId = floor(uv);
                uv = frac(uv);
                float2 hash2 = Hash22(gridId);
                float hash1 = Hash12(gridId);
                float2 offset = (hash2 - 0.5) * 0.5;
                float size = lerp(0.6,1,hash1) * 0.3;
                float lightPeroidVal = (sin(_Time.y + hash1 * _PI2) * 0.5 + 0.5);
                float light = lerp(0.4,0.6,lightPeroidVal) * pow((1-layerId /_LayerCount),1.5);
                float circle = DrawCircle(uv,offset,size,float2(0,1)) * light ;
                return circle;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 ret = float4(0,0,0,1);
                float2 uv = i.uv;
                for (int i = 0; i < 7; ++i)
                {
                    ret = max(ret,DrawSnowLayer(uv,i));
                }
               
                return ret;
            }
            ENDCG
        }
    }
}
