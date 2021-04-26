// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34142,y:32457,varname:node_3138,prsc:2|emission-3436-OUT;n:type:ShaderForge.SFN_LightVector,id:6847,x:32411,y:33005,varname:node_6847,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2812,x:32411,y:32815,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:8880,x:32588,y:32895,varname:node_8880,prsc:2,dt:0|A-2812-OUT,B-6847-OUT;n:type:ShaderForge.SFN_Slider,id:4088,x:32327,y:32561,ptovrint:False,ptlb:node_4088,ptin:_node_4088,varname:node_4088,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:2584,x:32388,y:32659,ptovrint:False,ptlb:node_2584,ptin:_node_2584,varname:node_2584,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:425,x:32588,y:32659,cmnt:输出rgb3个通道作为遮罩进行混合,varname:node_425,prsc:2|A-4088-OUT,B-2584-RGB;n:type:ShaderForge.SFN_ComponentMask,id:1978,x:32757,y:32512,varname:node_1978,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-425-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8216,x:32757,y:32659,varname:node_8216,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-425-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5857,x:32757,y:32814,varname:node_5857,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-425-OUT;n:type:ShaderForge.SFN_Step,id:3851,x:32933,y:32512,cmnt:红色光的范围,varname:node_3851,prsc:2|A-1978-OUT,B-8880-OUT;n:type:ShaderForge.SFN_Step,id:2715,x:32933,y:32659,cmnt:绿色光的范围,varname:node_2715,prsc:2|A-8216-OUT,B-8880-OUT;n:type:ShaderForge.SFN_Step,id:1915,x:32933,y:32797,cmnt:蓝色光的范围,varname:node_1915,prsc:2|A-5857-OUT,B-8880-OUT;n:type:ShaderForge.SFN_Append,id:4733,x:33152,y:32574,varname:node_4733,prsc:2|A-3851-OUT,B-2715-OUT;n:type:ShaderForge.SFN_Append,id:805,x:33167,y:32738,varname:node_805,prsc:2|A-4733-OUT,B-1915-OUT;n:type:ShaderForge.SFN_Color,id:6672,x:33225,y:33187,ptovrint:False,ptlb:node_6672,ptin:_node_6672,varname:node_6672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9208,x:33467,y:33128,cmnt:暗部色,varname:node_9208,prsc:2|A-8055-OUT,B-6672-RGB;n:type:ShaderForge.SFN_Add,id:3436,x:33989,y:32558,varname:node_3436,prsc:2|A-5227-OUT,B-9208-OUT;n:type:ShaderForge.SFN_ScreenPos,id:4507,x:32929,y:32040,varname:node_4507,prsc:2,sctp:0;n:type:ShaderForge.SFN_Depth,id:2047,x:32929,y:32244,varname:node_2047,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3318,x:33168,y:32158,varname:node_3318,prsc:2|A-4507-UVOUT,B-2047-OUT;n:type:ShaderForge.SFN_Tex2d,id:1776,x:33403,y:32039,ptovrint:False,ptlb:texture,ptin:_texture,varname:node_1776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3318-OUT;n:type:ShaderForge.SFN_Multiply,id:5227,x:33739,y:32216,cmnt:亮部色与贴图uv颜色混合,varname:node_5227,prsc:2|A-1776-RGB,B-2514-OUT;n:type:ShaderForge.SFN_OneMinus,id:8055,x:33245,y:33022,varname:node_8055,prsc:2|IN-805-OUT;n:type:ShaderForge.SFN_Color,id:3052,x:33300,y:32429,ptovrint:False,ptlb:node_3052,ptin:_node_3052,varname:node_3052,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2514,x:33519,y:32588,cmnt:得到亮部色,varname:node_2514,prsc:2|A-3052-RGB,B-805-OUT;proporder:4088-2584-6672-1776-3052;pass:END;sub:END;*/

Shader "Shader Forge/l04" {
    Properties {
        _node_4088 ("node_4088", Range(0, 1)) = 0
        _node_2584 ("node_2584", Color) = (0.5,0.5,0.5,1)
        _node_6672 ("node_6672", Color) = (0.5,0.5,0.5,1)
        _texture ("texture", 2D) = "white" {}
        _node_3052 ("node_3052", Color) = (0.5,0.5,0.5,1)
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
            uniform sampler2D _texture; uniform float4 _texture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4088)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_2584)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_6672)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_3052)
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
                float2 node_3318 = ((sceneUVs * 2 - 1).rg*partZ);
                float4 _texture_var = tex2D(_texture,TRANSFORM_TEX(node_3318, _texture));
                float4 _node_3052_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_3052 );
                float _node_4088_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4088 );
                float4 _node_2584_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2584 );
                float3 node_425 = (_node_4088_var*_node_2584_var.rgb); // 输出rgb3个通道作为遮罩进行混合
                float node_8880 = dot(i.normalDir,lightDirection);
                float3 node_805 = float3(float2(step(node_425.r,node_8880),step(node_425.g,node_8880)),step(node_425.b,node_8880));
                float4 _node_6672_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_6672 );
                float3 emissive = ((_texture_var.rgb*(_node_3052_var.rgb*node_805))+((1.0 - node_805)*_node_6672_var.rgb));
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
            uniform sampler2D _texture; uniform float4 _texture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4088)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_2584)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_6672)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_3052)
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
