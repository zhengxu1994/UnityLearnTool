// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33532,y:32920,varname:node_3138,prsc:2|emission-1949-OUT;n:type:ShaderForge.SFN_ScreenPos,id:4733,x:32429,y:32746,cmnt:将纹理平铺,varname:node_4733,prsc:2,sctp:1;n:type:ShaderForge.SFN_Depth,id:7164,x:32429,y:32938,varname:node_7164,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5825,x:32617,y:32847,varname:node_5825,prsc:2|A-4733-UVOUT,B-7164-OUT;n:type:ShaderForge.SFN_Tex2d,id:8308,x:32805,y:32847,ptovrint:False,ptlb:node_8308,ptin:_node_8308,varname:node_8308,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:81e672ecd28fa472cb41b0ba3ea4d3bb,ntxv:0,isnm:False|UVIN-5825-OUT;n:type:ShaderForge.SFN_NormalVector,id:2816,x:32429,y:33101,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:2542,x:32429,y:33262,varname:node_2542,prsc:2;n:type:ShaderForge.SFN_Dot,id:855,x:32629,y:33183,varname:node_855,prsc:2,dt:0|A-2816-OUT,B-2542-OUT;n:type:ShaderForge.SFN_Step,id:1717,x:32828,y:33084,varname:node_1717,prsc:2|A-8308-R,B-855-OUT;n:type:ShaderForge.SFN_Color,id:6613,x:32629,y:33374,ptovrint:False,ptlb:node_6613,ptin:_node_6613,varname:node_6613,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1636,x:32851,y:33286,varname:node_1636,prsc:2|A-855-OUT,B-6613-RGB;n:type:ShaderForge.SFN_Add,id:1949,x:33134,y:33169,varname:node_1949,prsc:2|A-8283-OUT,B-1636-OUT;n:type:ShaderForge.SFN_Color,id:3398,x:33032,y:32910,ptovrint:False,ptlb:node_3398,ptin:_node_3398,varname:node_3398,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:5572,x:33012,y:32720,ptovrint:False,ptlb:node_3398_copy,ptin:_node_3398_copy,varname:_node_3398_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:8283,x:33268,y:32910,varname:node_8283,prsc:2|A-5572-RGB,B-3398-RGB,T-1717-OUT;proporder:8308-6613-3398-5572;pass:END;sub:END;*/

Shader "Shader Forge/LambotT2" {
    Properties {
        _node_8308 ("node_8308", 2D) = "white" {}
        _node_6613 ("node_6613", Color) = (0.5,0.5,0.5,1)
        _node_3398 ("node_3398", Color) = (0.5,0.5,0.5,1)
        _node_3398_copy ("node_3398_copy", Color) = (0.5,0.5,0.5,1)
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _node_8308; uniform float4 _node_8308_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_6613)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_3398)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_3398_copy)
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
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _node_3398_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_3398_copy );
                float4 _node_3398_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_3398 );
                float2 node_5825 = (float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg*partZ);
                float4 _node_8308_var = tex2D(_node_8308,TRANSFORM_TEX(node_5825, _node_8308));
                float node_855 = dot(i.normalDir,lightDirection);
                float4 _node_6613_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_6613 );
                float3 emissive = (lerp(_node_3398_copy_var.rgb,_node_3398_var.rgb,step(_node_8308_var.r,node_855))+(node_855*_node_6613_var.rgb));
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
            uniform sampler2D _node_8308; uniform float4 _node_8308_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_6613)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_3398)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_3398_copy)
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
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
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
