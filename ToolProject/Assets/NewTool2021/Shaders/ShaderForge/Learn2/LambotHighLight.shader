// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33414,y:33105,varname:node_3138,prsc:2|emission-4971-OUT,olwid-6813-OUT,olcol-7225-OUT;n:type:ShaderForge.SFN_NormalVector,id:7758,x:32153,y:32665,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:5277,x:32153,y:32844,varname:node_5277,prsc:2;n:type:ShaderForge.SFN_Dot,id:7092,x:32339,y:32751,varname:node_7092,prsc:2,dt:0|A-7758-OUT,B-5277-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5104,x:32293,y:32953,ptovrint:False,ptlb:node_5104,ptin:_node_5104,varname:node_5104,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9057,x:32466,y:32919,varname:node_9057,prsc:2|A-7092-OUT,B-5104-OUT;n:type:ShaderForge.SFN_Add,id:5187,x:32595,y:32628,varname:node_5187,prsc:2|A-9057-OUT,B-5104-OUT;n:type:ShaderForge.SFN_Tex2d,id:9079,x:32950,y:32895,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_9079,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ea8a1a6962677e54e89e8039b0c7cfa0,ntxv:0,isnm:False|UVIN-720-OUT;n:type:ShaderForge.SFN_Append,id:720,x:32754,y:32767,varname:node_720,prsc:2|A-5187-OUT,B-2088-OUT;n:type:ShaderForge.SFN_Vector1,id:2088,x:32608,y:32938,varname:node_2088,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Vector1,id:6813,x:32877,y:33740,varname:node_6813,prsc:2,v1:0.015;n:type:ShaderForge.SFN_Vector3,id:7225,x:32877,y:33619,varname:node_7225,prsc:2,v1:1,v2:0.9447157,v3:0;n:type:ShaderForge.SFN_LightVector,id:5006,x:32103,y:33640,varname:node_5006,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2293,x:31770,y:33474,prsc:2,pt:False;n:type:ShaderForge.SFN_Add,id:9782,x:32028,y:33427,varname:node_9782,prsc:2|A-8410-XYZ,B-2293-OUT;n:type:ShaderForge.SFN_Add,id:8203,x:32028,y:33225,varname:node_8203,prsc:2|A-583-XYZ,B-2293-OUT;n:type:ShaderForge.SFN_Normalize,id:4926,x:32162,y:33225,varname:node_4926,prsc:2|IN-8203-OUT;n:type:ShaderForge.SFN_Normalize,id:370,x:32174,y:33427,varname:node_370,prsc:2|IN-9782-OUT;n:type:ShaderForge.SFN_Dot,id:2456,x:32431,y:33233,varname:node_2456,prsc:2,dt:0|A-4926-OUT,B-5006-OUT;n:type:ShaderForge.SFN_Vector4Property,id:8410,x:31770,y:33159,ptovrint:False,ptlb:highLightoffset1,ptin:_highLightoffset1,cmnt:高光偏移1,varname:node_8410,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:583,x:31770,y:33334,ptovrint:False,ptlb:highLightoffset2,ptin:_highLightoffset2,varname:_highLightoffset2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Dot,id:5725,x:32431,y:33427,varname:node_5725,prsc:2,dt:0|A-370-OUT,B-5006-OUT;n:type:ShaderForge.SFN_If,id:5966,x:32584,y:33264,cmnt:if如果大于阈值则输出1为白色否则为黑色,varname:node_5966,prsc:2|A-2456-OUT,B-7238-OUT,GT-6176-OUT,EQ-6176-OUT,LT-5931-OUT;n:type:ShaderForge.SFN_Vector1,id:6176,x:32293,y:33138,varname:node_6176,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:5931,x:32293,y:33065,varname:node_5931,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:7238,x:32447,y:33112,ptovrint:False,ptlb:node_7238,ptin:_node_7238,varname:node_7238,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_Vector1,id:5663,x:32314,y:33700,varname:node_5663,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4112,x:32314,y:33627,varname:node_4112,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:7539,x:32468,y:33674,ptovrint:False,ptlb:interval,ptin:_interval,varname:_node_7238_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_If,id:6228,x:32602,y:33430,varname:node_6228,prsc:2|A-5725-OUT,B-7539-OUT,GT-5663-OUT,EQ-5663-OUT,LT-4112-OUT;n:type:ShaderForge.SFN_Max,id:2508,x:32739,y:33430,varname:node_2508,prsc:2|A-5966-OUT,B-6228-OUT;n:type:ShaderForge.SFN_Clamp01,id:5383,x:32867,y:33322,varname:node_5383,prsc:2|IN-2508-OUT;n:type:ShaderForge.SFN_Color,id:7319,x:32867,y:33131,ptovrint:False,ptlb:maskColor,ptin:_maskColor,varname:node_7319,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:9264,x:33083,y:33193,varname:node_9264,prsc:2|A-9079-RGB,B-7319-RGB,T-5383-OUT;n:type:ShaderForge.SFN_Fresnel,id:8340,x:32674,y:33812,cmnt:菲尼尔效果,varname:node_8340,prsc:2|EXP-2959-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2959,x:32468,y:33835,ptovrint:False,ptlb:ferValue,ptin:_ferValue,varname:node_2959,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Color,id:3274,x:32674,y:34010,ptovrint:False,ptlb:ferColor,ptin:_ferColor,varname:node_3274,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:8158,x:32916,y:33903,varname:node_8158,prsc:2|A-8340-OUT,B-3274-RGB;n:type:ShaderForge.SFN_Blend,id:4971,x:33178,y:33482,varname:node_4971,prsc:2,blmd:6,clmp:True|SRC-9264-OUT,DST-8158-OUT;proporder:5104-9079-583-7238-8410-7539-7319-2959-3274;pass:END;sub:END;*/

Shader "Shader Forge/LamHighLight" {
    Properties {
        _node_5104 ("node_5104", Float ) = 0.5
        _Texture ("Texture", 2D) = "white" {}
        _highLightoffset2 ("highLightoffset2", Vector) = (0,0,0,0)
        _node_7238 ("node_7238", Float ) = 0.8
        _highLightoffset1 ("highLightoffset1", Vector) = (0,0,0,0)
        _interval ("interval", Float ) = 0.8
        _maskColor ("maskColor", Color) = (0.5,0.5,0.5,1)
        _ferValue ("ferValue", Float ) = 3
        _ferColor ("ferColor", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*0.015,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(float3(1,0.9447157,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5104)
                UNITY_DEFINE_INSTANCED_PROP( float4, _highLightoffset1)
                UNITY_DEFINE_INSTANCED_PROP( float4, _highLightoffset2)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_7238)
                UNITY_DEFINE_INSTANCED_PROP( float, _interval)
                UNITY_DEFINE_INSTANCED_PROP( float4, _maskColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _ferValue)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ferColor)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float _node_5104_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5104 );
                float2 node_720 = float2(((dot(i.normalDir,lightDirection)*_node_5104_var)+_node_5104_var),0.3);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_720, _Texture));
                float4 _maskColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _maskColor );
                float4 _highLightoffset2_var = UNITY_ACCESS_INSTANCED_PROP( Props, _highLightoffset2 );
                float _node_7238_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_7238 );
                float node_5966_if_leA = step(dot(normalize((_highLightoffset2_var.rgb+i.normalDir)),lightDirection),_node_7238_var);
                float node_5966_if_leB = step(_node_7238_var,dot(normalize((_highLightoffset2_var.rgb+i.normalDir)),lightDirection));
                float node_6176 = 1.0;
                float4 _highLightoffset1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _highLightoffset1 ); // 高光偏移1
                float _interval_var = UNITY_ACCESS_INSTANCED_PROP( Props, _interval );
                float node_6228_if_leA = step(dot(normalize((_highLightoffset1_var.rgb+i.normalDir)),lightDirection),_interval_var);
                float node_6228_if_leB = step(_interval_var,dot(normalize((_highLightoffset1_var.rgb+i.normalDir)),lightDirection));
                float node_5663 = 1.0;
                float _ferValue_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ferValue );
                float4 _ferColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ferColor );
                float3 emissive = saturate((1.0-(1.0-lerp(_Texture_var.rgb,_maskColor_var.rgb,saturate(max(lerp((node_5966_if_leA*0.0)+(node_5966_if_leB*node_6176),node_6176,node_5966_if_leA*node_5966_if_leB),lerp((node_6228_if_leA*0.0)+(node_6228_if_leB*node_5663),node_5663,node_6228_if_leA*node_6228_if_leB)))))*(1.0-(pow(1.0-max(0,dot(normalDirection, viewDirection)),_ferValue_var)*_ferColor_var.rgb))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5104)
                UNITY_DEFINE_INSTANCED_PROP( float4, _highLightoffset1)
                UNITY_DEFINE_INSTANCED_PROP( float4, _highLightoffset2)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_7238)
                UNITY_DEFINE_INSTANCED_PROP( float, _interval)
                UNITY_DEFINE_INSTANCED_PROP( float4, _maskColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _ferValue)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ferColor)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
