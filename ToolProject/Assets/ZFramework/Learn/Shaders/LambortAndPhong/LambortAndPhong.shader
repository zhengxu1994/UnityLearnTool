Shader "Unlit/LambortAndPhong"
{
    Properties
    {
        _MainColor("颜色",Color)= (1,1,1,1)
        _PowRange("次幂",Range(1,30))= 30
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
            float3 _MainColor;
            float _PowRange;
            struct appdata
            {
                float4 vertex : POSITION;
                float4 normal:NORMAL;
            };

            struct v2f
            {
                float4 posCS : SV_POSITION;
                float4 posWS :TEXCOORD0;
                float3 nDirWS : TEXCOORD1;
            };

            
            v2f vert (appdata v)
            {
                v2f o;
                o.posCS = UnityObjectToClipPos(v.vertex);//其次坐标
                o.posWS = mul(unity_ObjectToWorld,v.vertex);//世界坐标
                o.nDirWS = UnityObjectToWorldNormal(v.normal);//世界空间下法线坐标
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 nDir = i.nDirWS;//法线坐标
                float3 lDir = _WorldSpaceLightPos0.xyz;//光照方向
                float3 vDir = normalize(_WorldSpaceCameraPos.xyz-i.posWS);//观察方向
                float3 hDir = normalize(vDir + lDir);//半角方向  两个方向相加

                //dot
                float nDotl = dot(nDir,lDir);//lambert
                float nDoth = dot(nDir,hDir);//phong

                //光照模型
                float lambert = max(0.0,nDotl);
                float blinnPhong = pow(max(0.0,nDoth),_PowRange);
                float3 finalRGB  = _MainColor * lambert + blinnPhong;
                return float4(finalRGB,1);
            }
            ENDCG
        }
    }
}
