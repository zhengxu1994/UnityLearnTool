// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-5250-OUT;n:type:ShaderForge.SFN_Tex2d,id:6743,x:32622,y:32918,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_6743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4471-OUT;n:type:ShaderForge.SFN_Color,id:922,x:32790,y:32755,ptovrint:False,ptlb:color,ptin:_color,varname:node_922,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_VertexColor,id:6346,x:32813,y:33046,varname:node_6346,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5250,x:32987,y:32933,varname:node_5250,prsc:2|A-922-RGB,B-6743-RGB,C-6346-RGB,D-6855-RGB,E-3785-RGB;n:type:ShaderForge.SFN_Tex2d,id:6855,x:32806,y:32522,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_6855,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:9130,x:32198,y:32997,varname:node_9130,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:2505,x:31849,y:32790,varname:node_2505,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3898,x:31862,y:32681,ptovrint:False,ptlb:u_move,ptin:_u_move,varname:node_3898,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:982,x:31838,y:33004,ptovrint:False,ptlb:v_move,ptin:_v_move,varname:_u_move_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:470,x:32041,y:32734,varname:node_470,prsc:2|A-3898-OUT,B-2505-T;n:type:ShaderForge.SFN_Multiply,id:6378,x:32041,y:32913,varname:node_6378,prsc:2|A-2505-T,B-982-OUT;n:type:ShaderForge.SFN_Append,id:200,x:32218,y:32842,varname:node_200,prsc:2|A-470-OUT,B-6378-OUT;n:type:ShaderForge.SFN_Add,id:4471,x:32420,y:32893,varname:node_4471,prsc:2|A-200-OUT,B-9130-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3785,x:32528,y:32512,ptovrint:False,ptlb:mask1,ptin:_mask1,varname:node_3785,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;proporder:6743-922-6855-3898-982-3785;pass:END;sub:END;*/

Shader "Shader Forge/10211_liuguang_001" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _color ("color", Color) = (0.5,0.5,0.5,1)
        _mask ("mask", 2D) = "white" {}
        _u_move ("u_move", Float ) = 0
        _v_move ("v_move", Float ) = 0
        _mask1 ("mask1", 2D) = "white" {}
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
            Blend One One
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform sampler2D _mask1; uniform float4 _mask1_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _color)
                UNITY_DEFINE_INSTANCED_PROP( float, _u_move)
                UNITY_DEFINE_INSTANCED_PROP( float, _v_move)
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
                float4 _color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _color );
                float _u_move_var = UNITY_ACCESS_INSTANCED_PROP( Props, _u_move );
                float4 node_2505 = _Time;
                float _v_move_var = UNITY_ACCESS_INSTANCED_PROP( Props, _v_move );
                float2 node_4471 = (float2((_u_move_var*node_2505.g),(node_2505.g*_v_move_var))+i.uv0);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4471, _Texture));
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float4 _mask1_var = tex2D(_mask1,TRANSFORM_TEX(i.uv0, _mask1));
                float3 emissive = (_color_var.rgb*_Texture_var.rgb*i.vertexColor.rgb*_mask_var.rgb*_mask1_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
