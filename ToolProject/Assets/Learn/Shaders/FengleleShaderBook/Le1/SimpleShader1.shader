// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ZFramework/Learn/SimpleShader1"
{
    Properties
    {
        //定义一个属性  定义属性后不要加;分号 
        _Color("Color Tint",Color) = (1.0,1.0,1.0,1.0)
    }

    SubShader {
        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            fixed4 _Color;//引用上面定义的属性
            //添加一个结构体，里面存这模型的顶点信息 和 法线信息
            struct a2v
            {
                float4 vertex : POSITION;//顶点
                float3 normal : NORMAL;//法线
                float4 texcoord : TEXCOORD0; //第一套纹理数据
            };

            //定义结构体，将顶点着色器中处理的数据传递给片元着色器
            struct v2f
            {
                float4 pos : SV_POSITION;//裁剪空间下顶点坐标
                fixed3 color : COLOR0;//COLOR0 语义可以用于存储颜色信息
            };
            
            //a2f 里面定义了pos 类型是SV_POSITION 所以不用写vert(a2v v) : SV_POSITION
            v2f vert(a2v v)
            {
                v2f o ;
                o.pos =  UnityObjectToClipPos(v.vertex);// 模型转换到裁剪空间
                o.color = v.normal * 0.5 + fixed3(0.5,0.5,0.5);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 c = i.color;
                c *= _Color.rgb;//乘以定义的颜色
                return fixed4(c,1.0);
            }

            ENDCG
        }
        
    }
}
