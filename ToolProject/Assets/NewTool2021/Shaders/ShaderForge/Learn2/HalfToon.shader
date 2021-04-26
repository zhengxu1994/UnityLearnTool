// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33594,y:32686,varname:node_3138,prsc:2|emission-3096-OUT;n:type:ShaderForge.SFN_ScreenPos,id:1616,x:32404,y:32692,varname:node_1616,prsc:2,sctp:0;n:type:ShaderForge.SFN_Slider,id:9837,x:32326,y:32902,ptovrint:False,ptlb:DotSize,ptin:_DotSize,varname:node_9837,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:10,cur:28.56174,max:100;n:type:ShaderForge.SFN_Multiply,id:7428,x:32618,y:32743,varname:node_7428,prsc:2|A-1616-UVOUT,B-9837-OUT;n:type:ShaderForge.SFN_Frac,id:8097,x:32790,y:32743,varname:node_8097,prsc:2|IN-7428-OUT;n:type:ShaderForge.SFN_RemapRange,id:7650,x:32963,y:32743,varname:node_7650,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8097-OUT;n:type:ShaderForge.SFN_Length,id:7931,x:33131,y:32743,varname:node_7931,prsc:2|IN-7650-OUT;n:type:ShaderForge.SFN_LightVector,id:4292,x:32351,y:32996,varname:node_4292,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9767,x:32340,y:33150,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:7696,x:32588,y:33041,varname:node_7696,prsc:2,dt:0|A-4292-OUT,B-9767-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:2771,x:32499,y:33300,cmnt:投影,varname:node_2771,prsc:2;n:type:ShaderForge.SFN_Multiply,id:34,x:32745,y:33180,varname:node_34,prsc:2|A-7696-OUT,B-2771-OUT;n:type:ShaderForge.SFN_RemapRange,id:18,x:32928,y:33180,varname:node_18,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-34-OUT;n:type:ShaderForge.SFN_Power,id:2729,x:33108,y:32974,varname:node_2729,prsc:2|VAL-7931-OUT,EXP-18-OUT;n:type:ShaderForge.SFN_Round,id:3096,x:33333,y:32910,cmnt:四舍五入非白即黑,varname:node_3096,prsc:2|IN-2729-OUT;proporder:9837;pass:END;sub:END;*/

Shader "Shader Forge/HalfToon" {
    Properties {
        _DotSize ("DotSize", Range(10, 100)) = 28.56174
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _DotSize)
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
                float4 projPos : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float _DotSize_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DotSize );
                float node_3096 = round(pow(length((frac(((sceneUVs * 2 - 1).rg*_DotSize_var))*2.0+-1.0)),((dot(lightDirection,i.normalDir)*attenuation)*2.0+-1.0))); // 四舍五入非白即黑
                float3 emissive = float3(node_3096,node_3096,node_3096);
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _DotSize)
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
                float4 projPos : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
