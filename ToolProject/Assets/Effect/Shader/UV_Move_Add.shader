// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-4840-OUT;n:type:ShaderForge.SFN_Tex2d,id:869,x:32651,y:32516,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_869,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4929-OUT;n:type:ShaderForge.SFN_Color,id:4600,x:32446,y:32711,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_4600,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3343,x:32674,y:32902,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_3343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7667-OUT;n:type:ShaderForge.SFN_VertexColor,id:3327,x:32640,y:33075,varname:node_3327,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6844,x:32955,y:32643,varname:node_6844,prsc:2|A-4600-RGB,B-3343-RGB,C-3327-RGB,D-869-RGB,E-7451-RGB;n:type:ShaderForge.SFN_TexCoord,id:2363,x:32366,y:33029,varname:node_2363,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:7667,x:32511,y:32938,varname:node_7667,prsc:2|A-4082-OUT,B-2363-UVOUT;n:type:ShaderForge.SFN_Time,id:5793,x:31948,y:32918,varname:node_5793,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4812,x:31948,y:32833,ptovrint:False,ptlb:U_Move,ptin:_U_Move,varname:node_4812,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:1547,x:31948,y:33108,ptovrint:False,ptlb:V_Move,ptin:_V_Move,varname:node_1547,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5545,x:32173,y:32864,varname:node_5545,prsc:2|A-4812-OUT,B-5793-T;n:type:ShaderForge.SFN_Multiply,id:1890,x:32173,y:33019,varname:node_1890,prsc:2|A-5793-T,B-1547-OUT;n:type:ShaderForge.SFN_Append,id:4082,x:32366,y:32904,varname:node_4082,prsc:2|A-5545-OUT,B-1890-OUT;n:type:ShaderForge.SFN_Multiply,id:6480,x:32920,y:32982,varname:node_6480,prsc:2|A-4600-A,B-3343-A,C-3327-A,D-869-A;n:type:ShaderForge.SFN_Multiply,id:4840,x:33023,y:32851,varname:node_4840,prsc:2|A-6844-OUT,B-6480-OUT;n:type:ShaderForge.SFN_Time,id:2902,x:31835,y:32501,varname:node_2902,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4395,x:31835,y:32691,ptovrint:False,ptlb:Mask_V,ptin:_Mask_V,varname:_V_Move_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:683,x:31835,y:32416,ptovrint:False,ptlb:Mask_U,ptin:_Mask_U,varname:_U_Move_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:3600,x:32060,y:32447,varname:node_3600,prsc:2|A-683-OUT,B-2902-T;n:type:ShaderForge.SFN_Multiply,id:6632,x:32060,y:32602,varname:node_6632,prsc:2|A-2902-T,B-4395-OUT;n:type:ShaderForge.SFN_TexCoord,id:5904,x:32253,y:32612,varname:node_5904,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:7893,x:32253,y:32487,varname:node_7893,prsc:2|A-3600-OUT,B-6632-OUT;n:type:ShaderForge.SFN_Add,id:4929,x:32420,y:32505,varname:node_4929,prsc:2|A-7893-OUT,B-5904-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7451,x:32651,y:32304,ptovrint:False,ptlb:Mask_01,ptin:_Mask_01,varname:node_7451,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4875-OUT;n:type:ShaderForge.SFN_Add,id:4875,x:32420,y:32149,varname:node_4875,prsc:2|A-7066-OUT,B-3454-UVOUT;n:type:ShaderForge.SFN_Append,id:7066,x:32253,y:32131,varname:node_7066,prsc:2|A-9032-OUT,B-3644-OUT;n:type:ShaderForge.SFN_TexCoord,id:3454,x:32253,y:32256,varname:node_3454,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3644,x:32060,y:32246,varname:node_3644,prsc:2|A-4781-T,B-3834-OUT;n:type:ShaderForge.SFN_Multiply,id:9032,x:32060,y:32091,varname:node_9032,prsc:2|A-1543-OUT,B-4781-T;n:type:ShaderForge.SFN_ValueProperty,id:1543,x:31835,y:32060,ptovrint:False,ptlb:Mask_U_1,ptin:_Mask_U_1,varname:_Mask_U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Time,id:4781,x:31835,y:32145,varname:node_4781,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3834,x:31835,y:32335,ptovrint:False,ptlb:Mask_V_1,ptin:_Mask_V_1,varname:_Mask_V_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:3343-4812-1547-869-683-4395-4600-7451-1543-3834;pass:END;sub:END;*/

Shader "yl/UV_Move_Add" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _U_Move ("U_Move", Float ) = 0
        _V_Move ("V_Move", Float ) = 0
        _Mask ("Mask", 2D) = "white" {}
        _Mask_U ("Mask_U", Float ) = 0
        _Mask_V ("Mask_V", Float ) = 0
        [HDR]_Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Mask_01 ("Mask_01", 2D) = "white" {}
        _Mask_U_1 ("Mask_U_1", Float ) = 0
        _Mask_V_1 ("Mask_V_1", Float ) = 0
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
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _Mask_01; uniform float4 _Mask_01_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _U_Move)
                UNITY_DEFINE_INSTANCED_PROP( float, _V_Move)
                UNITY_DEFINE_INSTANCED_PROP( float, _Mask_V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Mask_U)
                UNITY_DEFINE_INSTANCED_PROP( float, _Mask_U_1)
                UNITY_DEFINE_INSTANCED_PROP( float, _Mask_V_1)
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
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _U_Move_var = UNITY_ACCESS_INSTANCED_PROP( Props, _U_Move );
                float4 node_5793 = _Time;
                float _V_Move_var = UNITY_ACCESS_INSTANCED_PROP( Props, _V_Move );
                float2 node_7667 = (float2((_U_Move_var*node_5793.g),(node_5793.g*_V_Move_var))+i.uv0);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_7667, _Texture));
                float _Mask_U_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Mask_U );
                float4 node_2902 = _Time;
                float _Mask_V_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Mask_V );
                float2 node_4929 = (float2((_Mask_U_var*node_2902.g),(node_2902.g*_Mask_V_var))+i.uv0);
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_4929, _Mask));
                float _Mask_U_1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Mask_U_1 );
                float4 node_4781 = _Time;
                float _Mask_V_1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Mask_V_1 );
                float2 node_4875 = (float2((_Mask_U_1_var*node_4781.g),(node_4781.g*_Mask_V_1_var))+i.uv0);
                float4 _Mask_01_var = tex2D(_Mask_01,TRANSFORM_TEX(node_4875, _Mask_01));
                float3 emissive = ((_Color_var.rgb*_Texture_var.rgb*i.vertexColor.rgb*_Mask_var.rgb*_Mask_01_var.rgb)*(_Color_var.a*_Texture_var.a*i.vertexColor.a*_Mask_var.a));
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
