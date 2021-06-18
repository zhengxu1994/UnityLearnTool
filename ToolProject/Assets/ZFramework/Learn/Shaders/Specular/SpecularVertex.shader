// 高光
Shader "ZXShader/SpecularVertex"
{
    Properties{
        _Diffuse("Diffuse",Color) = (1,1,1,1)
        _Specular("Specular",Color) = (1,1,1,1)
        _GLoss("GLoss",Range(0,10)) = 1
    }

    SubShader
    {
        pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"

            fixed4 _Specular;
            fixed4 _Diffuse;
            float _GLoss ;
            struct a2v
            {
                float4 vertex : POSITION;
                float3 normal: NORMAL;
            };

            struct v2f
            {
                float4  pos:SV_POSITION;
                fixed4 color : COLOR;
            };
            
            v2f vert(a2v i)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(i.vertex);
                fixed3 abiment = UNITY_LIGHTMODEL_AMBIENT.xyz;

                fixed3 worldNormal = normalize(mul(i.normal,(float3x3)unity_ObjectToWorld));

                fixed3 worldlightDir = normalize(_WorldSpaceLightPos0.xyz);

                fixed3 diff = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldlightDir,worldNormal));

                float3 worldPos = normalize(mul(i.vertex,unity_ObjectToWorld)).xyz;

                float3 worldCameraPos = _WorldSpaceCameraPos.xyz;

                fixed3 reflectDir = normalize(reflect(-worldlightDir,worldNormal));

                float3 viewDir = normalize(worldCameraPos - worldPos);

                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(reflectDir,viewDir)),_GLoss);

                o.color =  (abiment + diff + specular,1.0);

                return o;
            }

            fixed4 frag(v2f o) :SV_TARGET
            {
                return _Diffuse;
            }
            ENDCG
        }
    }
}