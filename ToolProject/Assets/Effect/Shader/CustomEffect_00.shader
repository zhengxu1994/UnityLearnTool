Shader "YileShader/CustomEffect_00" {
    Properties {
        _MainTex("MainTex" , 2D) = "white"{}
        _MainU("MainU" , float) = 0
        _MainV("MainV" , float) = 0
        [HDR]_Color("Color" , Color) = ( 1.0, 1.0 , 1.0 , 1.0 )
        _ColorPow("ColorPow" , float ) = 1
        _Indensity("Indensity", float) = 1
        _Opacity("Opacity", float) = 1
        _DistortionTex("DistortionTex" , 2D) = "white"{}
        _DistortionU("DistortionU" , float) = 0
        _DistortionV("DistortionV" , float) = 0
        _DistortionIndensity("DistortionIndensity" , float) = 0
        [Toggle]_DistortionToSoftDissolve("_DistortionToSoftDissolve", Float) = 0
        _AlphaTex("AlphaTex", 2D) = "white" {}
        _AlphaU("AlphaU", Float) = 0
		_AlphaV("AlphaV", Float) = 0
        _AlphaTex1("AlphaTex1", 2D) = "white" {}
        _AlphaU1("AlphaU1", Float) = 0
		_AlphaV1("AlphaV1", Float) = 0
        [Toggle]_SoftDissolveSwitch("SoftDissolveSwitch", Float) = 0
        _SoftDissolveTex("SoftDissolveTex", 2D) = "white" {} 
		_SoftDissolveTexU("SoftDissolveTexU", Float) = 0
		_SoftDissolveTexV("SoftDissolveTexV", Float) = 0
		_SoftDissolveIndensity("SoftDissolveIndensity", Range( 0 , 1.05)) = 0
        _SoftDissolveSoft("_SoftDissolveSoft " , Range(0.0 , 1.0)) = 0.5
        _LineRange("LineRange", Float) = 0.5
        _LineWidth("LineWidth", Float) = 0.1
        [HDR]_LineColor("LineColor", Color) = (1,1,1,1)
		_LineIndensity("LineIndensity", Float) = 1
		
      
        
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
            #pragma shader_feature _SOFTDISSOLVESWITCH_ON 
            #pragma shader_feature _DISTORTIONTOSOFTDISSOLVE_ON
            
            //输入参数
            uniform sampler2D _MainTex ;  uniform float4 _MainTex_ST;
            uniform half _MainU ;
            uniform half _MainV ;
            uniform half3 _Color ;
            uniform half _ColorPow ;
            uniform half _Indensity ;
            uniform half _Opacity ;
            uniform sampler2D _DistortionTex;   uniform float4 _DistortionTex_ST;
            uniform half _DistortionU ;
            uniform half _DistortionV ;
            uniform half _DistortionIndensity ;
            uniform half _DistortionToSoftDissolve ;
            uniform sampler2D _AlphaTex;   uniform float4 _AlphaTex_ST;
            uniform half _AlphaU ;
            uniform half _AlphaV ;
            uniform sampler2D _AlphaTex1;   uniform float4 _AlphaTex1_ST;
            uniform half _AlphaU1 ;
            uniform half _AlphaV1 ;
            uniform half _SoftDissolveSwitch ;
            uniform sampler2D _SoftDissolveTex;   uniform float4 _SoftDissolveTex_ST;
            uniform half _SoftDissolveTexU ;
            uniform half _SoftDissolveTexV ;
            uniform half _SoftDissolveIndensity ;
            uniform half _SoftDissolveSoft ;
            uniform half _LineRange;
            uniform half _LineWidth;
            uniform half3 _LineColor ;
            uniform half _LineIndensity ;

            
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
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float2 uv3 : TEXCOORD3;
                float2 uv4 : TEXCOORD4;
                float4 color : color ;
                
            };
            //输入结构>>>顶点shader>>>输出结构
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;                                 //新建一个输出结构
                o.pos = UnityObjectToClipPos( v.vertex );                            //变换顶点信息 并将其塞给输出结构   OS>CS
                o.uv0 = TRANSFORM_TEX(v.uv  , _MainTex );                                                    //传递UV数据
                o.uv1 = TRANSFORM_TEX(v.uv  , _DistortionTex );
                o.uv2 = TRANSFORM_TEX(v.uv  , _AlphaTex );
                o.uv3 = TRANSFORM_TEX(v.uv  , _SoftDissolveTex );
                o.uv4 = TRANSFORM_TEX(v.uv  , _AlphaTex1 );
                o.color = v.color ;

                return o;                                                           //将输出结构输出
            }
            //输出结构>>像素
            float4 frag(VertexOutput i) : COLOR {                    //输出像素的时候 此处命名的i的信息就是上面o输出的信息 命名可改
                float2 var_MainTexUV = i.uv0 + frac(half2(_Time.y * _MainU , _Time.y * _MainV));
                half2 var_DistortionTexUV = i.uv1 + half2( frac(_Time.y * _DistortionU) ,frac( _Time.y * _DistortionV));
                half2 _AlphaTexUV = i.uv2 + half2( frac(_Time.y * _AlphaU) ,frac( _Time.y * _AlphaV));
                float2 _SoftDissolveTexUV = i.uv3 +frac( half2( _Time.y * _SoftDissolveTexU , _Time.y * _SoftDissolveTexV));
                half2 _AlphaTexUV1 = i.uv4 + half2( frac(_Time.y * _AlphaU1) ,frac( _Time.y * _AlphaV1));
                
                
                
                half4 var_DistortionTex = tex2D(_DistortionTex , var_DistortionTexUV) ;
                  
                float2 lerpResult = lerp( var_MainTexUV  , var_MainTexUV + var_DistortionTex.xy , _DistortionIndensity);
                #if _DISTORTIONTOSOFTDISSOLVE_ON

                float2 lerpResult2 = lerp( _SoftDissolveTexUV  , _SoftDissolveTexUV + var_DistortionTex.xy , _DistortionIndensity);
                #else 
                float2 lerpResult2 = _SoftDissolveTexUV ;
                #endif
                
                half4 var_MainTex = tex2D(_MainTex , lerpResult ) ;
                half4 var_AlphaTex = tex2D(_AlphaTex ,_AlphaTexUV ) ;
                half4 var_AlphaTex1 = tex2D(_AlphaTex1 ,_AlphaTexUV1 ) ;

                half4 var_SoftDissolveTex = tex2D(_SoftDissolveTex ,lerpResult2 ) ;


                half var_SoftDissolveTexClamp = var_SoftDissolveTex.r + 1 + _SoftDissolveIndensity * - 2.0 ;
                #if _SOFTDISSOLVESWITCH_ON
                half var_SoftDissolveTexClampFinal = clamp(var_SoftDissolveTexClamp , 0.0 , 1.0 ) ;
                
                half var_SoftDissolveTexStep = smoothstep(var_SoftDissolveTexClampFinal , _SoftDissolveSoft , 1.0 - _SoftDissolveSoft ) ; 
                half var_SoftDissolveTexStepLine = step(var_SoftDissolveTexStep +  _LineWidth , _LineRange ) - step(var_SoftDissolveTexStep , _LineRange )   ;

               
                half3 var_SoftDissolveTexStepLineColor =  var_SoftDissolveTexStepLine  * _LineIndensity * _LineColor  ;
                #else 
                half var_SoftDissolveTexStep = 1.0 ;
                half3 var_SoftDissolveTexStepLineColor = (0.0 , 0.0 , 0.0) ;
                half var_SoftDissolveTexClampFinal = 1.0 ;
                #endif

               

                half3 var_ColorIndensity = _Color * _Indensity  ;
                half3 var_ColorPow = pow ( var_MainTex.rgb , _ColorPow ) ;
                half3 var_ColorPowLine = var_ColorPow + var_SoftDissolveTexStepLineColor ;

                half3 finalRGB =  var_ColorIndensity *  var_ColorPowLine * var_AlphaTex1.r * var_AlphaTex.r * i.color ;
                half finalOp = var_MainTex.r * _Opacity  * var_AlphaTex.a * var_AlphaTex.r * var_AlphaTex1.a * var_AlphaTex1.r * var_SoftDissolveTexStep * var_SoftDissolveTexClampFinal * i.color.a * var_MainTex.a ;
             
               return     half4 ( finalRGB.rgb , finalOp);                                  //返回值


            }
            ENDCG
        }
    }
  
}


