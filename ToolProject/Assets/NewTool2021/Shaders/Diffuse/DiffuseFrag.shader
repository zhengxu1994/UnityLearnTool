//漫反射 逐片元
Shader "ZXShader/DiffuseFrag"
{
    Properties
    {
        _Diffuse("Diffuse",Color) = (1,1,1,1)
    }

    SubShader
    {
        Pass{

            Tags{"LightMode" = "ForwardBase"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //头文件
            #include "Lighting.cginc"
            fixed4 _Diffuse;

            struct a2v
            {
                //模型空间下的顶点坐标
                float4 vertex : POSITION;
                //模型空间下的法线向量
                float3 normal: NORMAL;
            };

            struct v2f
            {
                //裁切空间下的顶点坐标
                float4 pos :SV_POSITION;
                //用于存储顶点颜色的变量
                fixed3 worldNormal : COLOR;   
            };
            //逐顶点
            v2f vert(a2v i)
            {
                v2f o;
                //将模型空间下的顶点坐标转换为裁切空间下的坐标
                o.pos = UnityObjectToClipPos(i.vertex);
                //环境光
                //将模型空间下的法线向量转换为世界空间下的向量
                o.worldNormal =normalize(mul(i.normal,(float3x3)unity_WorldToObject)); 
                return o;
            }
            //逐片元
            fixed4 frag(v2f i) : SV_Target
            {
                
                fixed3 ambient  = UNITY_LIGHTMODEL_AMBIENT.xyz;
                //世界空间下环境光照方向
                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
                //漫反射计算 环境光rgb * 设置的颜色 * （（世界空间下的法线与光照方向）的点乘（0-1））
                //dot(i.worldNormal,worldLight) 为蓝伯特光照模型  
                // fixed3 diff = ambient + _LightColor0.rgb * _Diffuse.rgb * saturate(dot(i.worldNormal,worldLight));
                //0.5* dot(i.worldNormal,worldLight) + 0.5 半兰伯特光照模型 这样看上去更真实一点 就是背光的地方不全是黑色的
                fixed3 diff =ambient + _LightColor0.rgb * _Diffuse.rgb * saturate(0.5* dot(i.worldNormal,worldLight) + 0.5);
                fixed4 color = fixed4(diff,1.0);
                return color;
            }

            ENDCG
        }
    }
}