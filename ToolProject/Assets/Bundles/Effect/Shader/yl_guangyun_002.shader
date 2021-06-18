// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-9043-OUT,alpha-9328-OUT;n:type:ShaderForge.SFN_Tex2d,id:8683,x:32702,y:32810,ptovrint:False,ptlb:TEX,ptin:_TEX,varname:node_8683,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2716-OUT;n:type:ShaderForge.SFN_Color,id:8178,x:32702,y:32632,ptovrint:False,ptlb:COLOR,ptin:_COLOR,varname:node_8178,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_VertexColor,id:1433,x:32599,y:32992,varname:node_1433,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6077,x:32587,y:33180,ptovrint:False,ptlb:MASK,ptin:_MASK,varname:node_6077,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9043,x:32978,y:32792,varname:node_9043,prsc:2|A-8178-RGB,B-8683-RGB,C-1433-RGB,D-6077-RGB,E-6201-RGB;n:type:ShaderForge.SFN_Multiply,id:9328,x:32996,y:33001,varname:node_9328,prsc:2|A-8178-A,B-8683-A,C-1433-A,D-6077-A,E-6201-A;n:type:ShaderForge.SFN_TexCoord,id:5956,x:32313,y:32857,varname:node_5956,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3853,x:31886,y:32784,varname:node_3853,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7078,x:32101,y:32692,varname:node_7078,prsc:2|A-2886-OUT,B-3853-T;n:type:ShaderForge.SFN_Multiply,id:6084,x:32114,y:32888,varname:node_6084,prsc:2|A-3853-T,B-7598-OUT;n:type:ShaderForge.SFN_Append,id:6225,x:32313,y:32721,varname:node_6225,prsc:2|A-7078-OUT,B-6084-OUT;n:type:ShaderForge.SFN_Add,id:2716,x:32455,y:32783,varname:node_2716,prsc:2|A-6225-OUT,B-5956-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:2886,x:31886,y:32692,ptovrint:False,ptlb:u,ptin:_u,varname:node_2886,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:7598,x:31868,y:32984,ptovrint:False,ptlb:v,ptin:_v,varname:node_7598,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:6201,x:32616,y:33371,ptovrint:False,ptlb:node_6201,ptin:_node_6201,varname:node_6201,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9648,x:33011,y:33220,varname:node_9648,prsc:2;proporder:8683-8178-6077-7598-2886-6201;pass:END;sub:END;*/

Shader "yl/yl_guangyun_002" {
    Properties {
        _TEX ("TEX", 2D) = "white" {}
        [HDR]_COLOR ("COLOR", Color) = (0.5,0.5,0.5,1)
        _MASK ("MASK", 2D) = "white" {}
        _v ("v", Float ) = 0
        _u ("u", Float ) = 0
        _node_6201 ("node_6201", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _TEX; uniform float4 _TEX_ST;
            uniform sampler2D _MASK; uniform float4 _MASK_ST;
            uniform sampler2D _node_6201; uniform float4 _node_6201_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _COLOR)
                UNITY_DEFINE_INSTANCED_PROP( float, _u)
                UNITY_DEFINE_INSTANCED_PROP( float, _v)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _COLOR_var = UNITY_ACCESS_INSTANCED_PROP( Props, _COLOR );
                float _u_var = UNITY_ACCESS_INSTANCED_PROP( Props, _u );
                float4 node_3853 = _Time;
                float _v_var = UNITY_ACCESS_INSTANCED_PROP( Props, _v );
                float2 node_2716 = (float2((_u_var*node_3853.g),(node_3853.g*_v_var))+i.uv0);
                float4 _TEX_var = tex2D(_TEX,TRANSFORM_TEX(node_2716, _TEX));
                float4 _MASK_var = tex2D(_MASK,TRANSFORM_TEX(i.uv0, _MASK));
                float4 _node_6201_var = tex2D(_node_6201,TRANSFORM_TEX(i.uv0, _node_6201));
                float3 emissive = (_COLOR_var.rgb*_TEX_var.rgb*i.vertexColor.rgb*_MASK_var.rgb*_node_6201_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_COLOR_var.a*_TEX_var.a*i.vertexColor.a*_MASK_var.a*_node_6201_var.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
