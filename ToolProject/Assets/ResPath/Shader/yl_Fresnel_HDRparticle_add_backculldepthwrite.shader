// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-9972-OUT;n:type:ShaderForge.SFN_Tex2d,id:9921,x:32524,y:32704,ptovrint:False,ptlb:Main_Tex,ptin:_Main_Tex,varname:_Main_Tex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2382,x:32750,y:32905,varname:node_2382,prsc:2|A-9921-RGB,B-7630-RGB,C-9921-A,D-9984-RGB,E-9413-OUT;n:type:ShaderForge.SFN_Color,id:7630,x:32524,y:33116,ptovrint:False,ptlb:Main_Color,ptin:_Main_Color,varname:_Main_Color,prsc:0,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_VertexColor,id:9984,x:32524,y:32905,varname:node_9984,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9972,x:32910,y:33064,varname:node_9972,prsc:2|A-2382-OUT,B-7630-A,C-9984-A,D-4891-OUT;n:type:ShaderForge.SFN_Vector1,id:9413,x:32524,y:33033,varname:node_9413,prsc:2,v1:2;n:type:ShaderForge.SFN_Fresnel,id:991,x:32687,y:33295,varname:node_991,prsc:2|EXP-3526-OUT;n:type:ShaderForge.SFN_Slider,id:3526,x:32379,y:33424,ptovrint:False,ptlb:Fresnel,ptin:_Fresnel,varname:_Fresnel,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:50;n:type:ShaderForge.SFN_Multiply,id:4891,x:32837,y:33398,varname:node_4891,prsc:2|A-991-OUT,B-722-OUT;n:type:ShaderForge.SFN_Slider,id:722,x:32406,y:33584,ptovrint:False,ptlb:Fresnel_Indensity,ptin:_Fresnel_Indensity,varname:_Fresnel_Indensity,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;proporder:9921-7630-3526-722;pass:END;sub:END;*/

Shader "yl/yi_Fresnel_HDRparticle_add_backculldepthwrite" {
    Properties {
        _Main_Tex ("Main_Tex", 2D) = "white" {}
        [HDR]_Main_Color ("Main_Color", Color) = (0.5,0.5,0.5,1)
        _Fresnel ("Fresnel", Range(0, 50)) = 0
        _Fresnel_Indensity ("Fresnel_Indensity", Range(0, 10)) = 0
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _Main_Tex; uniform float4 _Main_Tex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( fixed4, _Main_Color)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _Fresnel)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _Fresnel_Indensity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = float3(0,0,-1);
                float3 normalDirection = i.normalDir;
////// Lighting:
                fixed4 _Main_Tex_var = tex2D(_Main_Tex,TRANSFORM_TEX(i.uv0, _Main_Tex));
                fixed4 _Main_Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Main_Color );
                fixed _Fresnel_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Fresnel );
                fixed _Fresnel_Indensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Fresnel_Indensity );
                float3 finalColor = ((_Main_Tex_var.rgb*_Main_Color_var.rgb*_Main_Tex_var.a*i.vertexColor.rgb*2.0)*_Main_Color_var.a*i.vertexColor.a*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_var)*_Fresnel_Indensity_var));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
