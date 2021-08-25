// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "10DistortPortal_1"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_Distort("Distort", 2D) = "bump" {}
		_CircleTex("Circle01", 2D) = "white" {}
		_DistrotStrength("DistrotStrength", Range( 0 , 0.5)) = 0
		_DistortRotateSpeed("DistortRotateSpeed", Float) = 0
		_MaskSize1_Blur1("MaskSize1_Blur1", Vector) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}


	Category 
	{
		SubShader
		{
		LOD 0

			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			Blend One One
			ColorMask RGB
			Cull Off
			Lighting Off 
			ZWrite Off
			ZTest LEqual
			
			Pass {
			
				CGPROGRAM
				
				#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
				#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
				#endif
				
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0
				#pragma multi_compile_instancing
				#pragma multi_compile_particles
				#pragma multi_compile_fog
				#include "UnityShaderVariables.cginc"


				#include "UnityCG.cginc"
				#include "Util.cginc"

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_VERTEX_INPUT_INSTANCE_ID
					
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					#ifdef SOFTPARTICLES_ON
					float4 projPos : TEXCOORD2;
					#endif
					UNITY_VERTEX_INPUT_INSTANCE_ID
					UNITY_VERTEX_OUTPUT_STEREO
					
				};
				
				
				#if UNITY_VERSION >= 560
				UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
				#else
				uniform sampler2D_float _CameraDepthTexture;
				#endif

				//Don't delete this comment
				// uniform sampler2D_float _CameraDepthTexture;

				uniform sampler2D _MainTex;
				uniform fixed4 _TintColor;
				uniform float4 _MainTex_ST;
				uniform float _InvFade;
				uniform float2 _MaskSize1_Blur1;
				uniform sampler2D _CircleTex;
				uniform sampler2D _Distort;
				uniform float4 _Distort_ST;
				uniform float _DistrotStrength;
				uniform float _DistortRotateSpeed;


				v2f vert ( appdata_t v  )
				{
					v2f o;
					UNITY_SETUP_INSTANCE_ID(v);
					UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
					UNITY_TRANSFER_INSTANCE_ID(v, o);
					

					v.vertex.xyz +=  float3( 0, 0, 0 ) ;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef SOFTPARTICLES_ON
						o.projPos = ComputeScreenPos (o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.texcoord = v.texcoord;
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}
		
				fixed4 frag ( v2f i  ) : SV_Target
				{
					UNITY_SETUP_INSTANCE_ID( i );
					UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( i );

					#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
						float partZ = i.projPos.z;
						float fade = saturate (_InvFade * (sceneZ-partZ));
						i.color.a *= fade;
					#endif
					float2 uv = i.texcoord.xy ;
					
					// DrawCircle 
					float circleMask = DrawCircle(uv.xy,0,_MaskSize1_Blur1.x,float2(0,_MaskSize1_Blur1.y));
					
					// 采样 扭曲贴图
					float2 distortUV = i.texcoord.xy * _Distort_ST.xy + _Distort_ST.zw;
					float2 distortVal = UnpackNormal( tex2D( _Distort, distortUV ) ) .rg;
					uv = uv + ( distortVal * _DistrotStrength );

					uv = Rotate2D(uv, _Time.y *  _DistortRotateSpeed);//旋转
					//float4 ret =0;ret.xy =  uv.xy; return ret;

					fixed4 col = i.color * circleMask* tex2D( _CircleTex, uv ) ;
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
				ENDCG 
			}
		}	
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=17500
2629;75;820;693;2479.612;1285.48;4.288129;True;False
Node;AmplifyShaderEditor.SamplerNode;2;-938.1235,293.8426;Inherit;True;Property;_Distort;Distort;0;0;Create;True;0;0;False;0;-1;6433ad4692b7d114f95eaccf8dfb9627;6433ad4692b7d114f95eaccf8dfb9627;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;5;-609.516,431.1719;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-969.1184,544.8391;Inherit;False;Property;_DistrotStrength;DistrotStrength;2;0;Create;True;0;0;False;0;0;0.06;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-208.3529,916.9604;Inherit;False;Property;_DistortRotateSpeed;DistortRotateSpeed;3;0;Create;True;0;0;False;0;0;-3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;11;-205.327,672.8864;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;17;-573.6056,-77.9671;Inherit;False;Property;_MaskSize1_Blur1;MaskSize1_Blur1;4;0;Create;True;0;0;False;0;0,0;0.85,0.3;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-437.2061,564.1965;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-379.7993,259.7609;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;87.68954,812.1881;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;18;-349.6056,61.0329;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-63.99457,413.2824;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;14;-347.5599,-104.2466;Inherit;False;DrawCircle;-1;;1;2f115a3d18e184f228c4670f6dcec381;0;4;1;FLOAT2;0,0;False;13;FLOAT2;0,0;False;14;FLOAT2;1,1;False;15;FLOAT2;0,0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;10;207.4198,543.9638;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-39.8363,-113.5716;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;3;-74.23444,159.022;Inherit;True;Property;_CircleTex;Circle01;1;0;Create;True;0;0;False;0;-1;a7ba4ab3dacca1f41b92de92749d7342;a7ba4ab3dacca1f41b92de92749d7342;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;1;489.5616,-31.03697;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;273.3158,109.1693;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;650.6703,195.7609;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;833.2362,95.34201;Float;False;True;-1;2;ASEMaterialInspector;0;7;10DistortPortal_1;0b6a9f8b4f707c74ca64c0be8e590de0;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;True;4;1;False;-1;1;False;-1;0;1;False;-1;0;False;-1;False;False;True;2;False;-1;True;True;True;True;False;0;False;-1;False;True;2;False;-1;True;3;False;-1;False;True;4;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;False;0;False;False;False;False;False;False;False;False;False;False;True;0;0;;0;0;Standard;0;0;1;True;False;;0
WireConnection;5;0;2;1
WireConnection;5;1;2;2
WireConnection;6;0;5;0
WireConnection;6;1;7;0
WireConnection;12;0;11;2
WireConnection;12;1;13;0
WireConnection;18;1;17;2
WireConnection;9;0;8;0
WireConnection;9;1;6;0
WireConnection;14;14;17;1
WireConnection;14;15;18;0
WireConnection;10;0;9;0
WireConnection;10;2;12;0
WireConnection;15;0;14;0
WireConnection;3;1;10;0
WireConnection;16;0;15;0
WireConnection;16;1;3;0
WireConnection;4;0;1;0
WireConnection;4;1;16;0
WireConnection;0;0;4;0
ASEEND*/
//CHKSM=5EC47395576BDA0E2E50F4A0C26DDED8E99FE392