// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:1,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:0,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:1,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32740,y:33254,varname:node_2865,prsc:2|emission-116-OUT,alpha-2227-OUT,voffset-8539-OUT;n:type:ShaderForge.SFN_TexCoord,id:9674,x:32030,y:33792,varname:node_9674,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:8539,x:32228,y:33792,varname:node_8539,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9674-UVOUT;n:type:ShaderForge.SFN_Color,id:1289,x:32118,y:33009,ptovrint:False,ptlb:color,ptin:_color,varname:node_1289,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6390,x:32118,y:33169,varname:node_6390,prsc:2,ntxv:0,isnm:False|UVIN-5053-UVOUT,TEX-5735-TEX;n:type:ShaderForge.SFN_Multiply,id:116,x:32387,y:33208,varname:node_116,prsc:2|A-1289-RGB,B-6390-RGB,C-7694-RGB;n:type:ShaderForge.SFN_TexCoord,id:7703,x:30769,y:33231,varname:node_7703,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:6286,x:30927,y:33231,varname:node_6286,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7703-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:1861,x:31109,y:33231,varname:node_1861,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6286-OUT;n:type:ShaderForge.SFN_ArcTan2,id:3125,x:31282,y:33246,varname:node_3125,prsc:2,attp:3|A-1861-G,B-1861-R;n:type:ShaderForge.SFN_Append,id:3991,x:31453,y:33246,varname:node_3991,prsc:2|A-3125-OUT,B-3125-OUT;n:type:ShaderForge.SFN_Rotator,id:5053,x:31703,y:33001,varname:node_5053,prsc:2|UVIN-3991-OUT;n:type:ShaderForge.SFN_TexCoord,id:4805,x:30870,y:33498,varname:node_4805,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector2,id:2177,x:30870,y:33691,varname:node_2177,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Distance,id:1531,x:31099,y:33546,varname:node_1531,prsc:2|A-4805-UVOUT,B-2177-OUT;n:type:ShaderForge.SFN_Power,id:2333,x:31507,y:33563,varname:node_2333,prsc:2|VAL-4307-OUT,EXP-4177-OUT;n:type:ShaderForge.SFN_Exp,id:4177,x:31275,y:33756,varname:node_4177,prsc:2,et:0|IN-4993-OUT;n:type:ShaderForge.SFN_Slider,id:4993,x:30890,y:33878,ptovrint:False,ptlb:node_4993,ptin:_node_4993,varname:node_4993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:8;n:type:ShaderForge.SFN_RemapRange,id:4307,x:31321,y:33546,varname:node_4307,prsc:2,frmn:0,frmx:0.5,tomn:0,tomx:0.6|IN-1531-OUT;n:type:ShaderForge.SFN_Clamp01,id:3042,x:31696,y:33563,varname:node_3042,prsc:2|IN-2333-OUT;n:type:ShaderForge.SFN_Slider,id:7479,x:31559,y:33754,ptovrint:False,ptlb:Ins,ptin:_Ins,varname:node_7479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:2227,x:31989,y:33611,varname:node_2227,prsc:2|A-3042-OUT,B-7479-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:5735,x:31710,y:33357,ptovrint:False,ptlb:node_5735,ptin:_node_5735,varname:node_5735,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7694,x:32118,y:33321,varname:node_7694,prsc:2,ntxv:0,isnm:False|UVIN-7127-UVOUT,TEX-5735-TEX;n:type:ShaderForge.SFN_Rotator,id:7127,x:31710,y:33171,varname:node_7127,prsc:2|UVIN-3991-OUT,SPD-3276-OUT;n:type:ShaderForge.SFN_Vector1,id:3276,x:31478,y:33393,varname:node_3276,prsc:2,v1:0.3;proporder:1289-4993-7479-5735;pass:END;sub:END;*/

Shader "yl/Shader Forge_Post" {
    Properties {
        _color ("color", Color) = (0.5,0.5,0.5,1)
        _node_4993 ("node_4993", Range(0, 8)) = 1
        _Ins ("Ins", Range(0, 5)) = 1
        _node_5735 ("node_5735", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha One
            Cull Off
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _node_5735; uniform float4 _node_5735_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _color)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4993)
                UNITY_DEFINE_INSTANCED_PROP( float, _Ins)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                v.vertex.xyz = float3((o.uv0*2.0+-1.0),0.0);
                o.pos = v.vertex;
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _color );
                float4 node_8841 = _Time;
                float node_5053_ang = node_8841.g;
                float node_5053_spd = 1.0;
                float node_5053_cos = cos(node_5053_spd*node_5053_ang);
                float node_5053_sin = sin(node_5053_spd*node_5053_ang);
                float2 node_5053_piv = float2(0.5,0.5);
                float2 node_1861 = (i.uv0*2.0+-1.0).rg;
                float node_3125 = (1-abs(atan2(node_1861.g,node_1861.r)/3.14159265359));
                float2 node_3991 = float2(node_3125,node_3125);
                float2 node_5053 = (mul(node_3991-node_5053_piv,float2x2( node_5053_cos, -node_5053_sin, node_5053_sin, node_5053_cos))+node_5053_piv);
                float4 node_6390 = tex2D(_node_5735,TRANSFORM_TEX(node_5053, _node_5735));
                float node_7127_ang = node_8841.g;
                float node_7127_spd = 0.3;
                float node_7127_cos = cos(node_7127_spd*node_7127_ang);
                float node_7127_sin = sin(node_7127_spd*node_7127_ang);
                float2 node_7127_piv = float2(0.5,0.5);
                float2 node_7127 = (mul(node_3991-node_7127_piv,float2x2( node_7127_cos, -node_7127_sin, node_7127_sin, node_7127_cos))+node_7127_piv);
                float4 node_7694 = tex2D(_node_5735,TRANSFORM_TEX(node_7127, _node_5735));
                float3 emissive = (_color_var.rgb*node_6390.rgb*node_7694.rgb);
                float3 finalColor = emissive;
                float _node_4993_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4993 );
                float _Ins_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Ins );
                return fixed4(finalColor,(saturate(pow((distance(i.uv0,float2(0.5,0.5))*1.2+0.0),exp(_node_4993_var)))*_Ins_var));
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                v.vertex.xyz = float3((o.uv0*2.0+-1.0),0.0);
                o.pos = v.vertex;
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
