Shader "YileShader/Blend_00"{
    Properties {
        [HDR]_Color("Color" , Color) = ( 0.5, 0.5 , 0.5 , 1.0 )
        _MainTex("MainTex" , 2D) = "white"{}
        _Indensity("Indensity" , float) = 1.0
        _Opacity ("Opacity" , float) = 1.0
        
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Transparent"     //AB渲染 去掉 CUTOFF
            "ForceNoShadowCasting"="True"         //关闭阴影投射
            "TgnoreProjector"="True"             //不响应投射器
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off 
            Cull off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            //输入参数
            uniform float4 _Color ;
            uniform sampler2D _MainTex ;  uniform float4 _MainTex_ST;
            uniform float _Indensity ;
            uniform float  _Opacity ;
            
            //结构体 struct开头就是声明我们在创建一个新的结构
            //输入结构
            struct VertexInput {
                float4 vertex : POSITION;    //将模型的顶点信息传入
                float2 uv : TEXCOORD0;      //get UV    (输入的标识名是固定的  输出的标识名是可以自己定义的  即  float4 vertex : POSITION;   此为固定写法 uv0>TEX0   uv1>TEX1)
                float4 color : color ;
            };
            //输出结构
            struct VertexOutput {
                float4 pos : SV_POSITION;      //由模型顶点信息转换而来的顶点屏幕位置    posCS
                float2 uv0 : TEXCOORD0;        //uv信息    
                float4 color : color ;
            };
            //输入结构>>>顶点shader>>>输出结构
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;                                 //新建一个输出结构
                o.pos = UnityObjectToClipPos( v.vertex );                            //变换顶点信息 并将其塞给输出结构   OS>CS
                o.uv0 = TRANSFORM_TEX(v.uv  , _MainTex );   
                o.color = v.color ;                                                 //传递UV数据
                return o;                                                           //将输出结构输出
            }
            //输出结构>>像素
            float4 frag(VertexOutput i) : COLOR {                    //输出像素的时候 此处命名的i的信息就是上面o输出的信息 命名可改
                //采样MainTex
                half4 var_MainTex = tex2D(_MainTex , i.uv0) ;
                half op = var_MainTex.a * _Opacity * i.color.a  ;
                
                half3 FinalRGB = var_MainTex.rgb *  _Color * i.color * _Indensity ;
                return half4 (FinalRGB.rgb,op);                                  //返回值
            }
            ENDCG
        }
    }
    
}
