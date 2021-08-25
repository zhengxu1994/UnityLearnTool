Shader "FishMan/18FireParticles"
{
    Properties
    {
        _Color(" Tint color",Color) = (0.9,0.8,0.1,1)
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
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float DrawParticles(float2 rawUV,int layerId){
                float layerHash = Hash11(layerId);
                float2 uv = rawUV;
                float gridSize = 10;
                float time = _Time.y*(3.5+ (layerId * 0.5)) + layerHash ;
                float4 ret = float4(0,0,0,1);
                uv *=gridSize;
                float yOffset = time;
                uv.y -=  yOffset ;
                uv.x += sin(Hash21(floor(uv.y) + layerId) * _PI2 + _Time.y *3) *0.5;// move by row id
                float2 gridId = floor(uv);
                float2 hash2 = Hash22(gridId + layerHash);
                uv = frac(uv);
                float2 offset = 0 ;
                float deg = (time *0.7 * (step(hash2.y,0.5)*2 -1)) + hash2.x * _PI2;
                offset = float2(cos(deg),sin(deg)) * 0.35;

                float mask = saturate((gridId.y + yOffset) / gridSize);
                mask = saturate(1 - pow(mask,0.5) * lerp(1,2,hash2.x));
                mask = pow(mask,1);
                mask *= saturate (lerp(0,gridSize,rawUV.y));
                float sizeHash = Hash21(gridId + float2(11.11,54.12) * (layerId+ 1));
                float sizeScale = (sin(_Time.y * 10 + sizeHash * _PI2) * 0.5 +0.5);
                float2 size = 0.2* lerp(0.3,1.2,sizeScale)  * mask;
                float circle = DrawCircle(uv,offset,size,float2(0,1));   
                return circle;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float mask  = 0;
                for (int i = 0; i < 3; ++i)
                {
                    mask += DrawParticles(uv,i);
                }
                return mask * _Color ;
            }
            ENDCG
        }
    }
}
