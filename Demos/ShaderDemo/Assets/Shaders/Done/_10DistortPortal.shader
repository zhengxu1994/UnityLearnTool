// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "_10DistortPortal"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_Distort("Distort", 2D) = "bump" {}
		_DistortStrength("DistortStrength", Range( 0 , 0.3)) = 0
		_BaseSize1SizeDiff1("BaseSize1SizeDiff1", Vector) = (0.7,0.2,0,0)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_DistortRotateSpeed("DistortRotateSpeed", Range( -2 , 2)) = 0.5
		_TimeScale("TimeScale", Range( 0 , 5)) = 0
		_StrengthFloat("StrengthFloat", Range( 0 , 0.7)) = 0
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
				uniform float2 _BaseSize1SizeDiff1;
				uniform sampler2D _TextureSample0;
				uniform sampler2D _Distort;
				uniform float4 _Distort_ST;
				uniform float _DistortStrength;
				uniform float _DistortRotateSpeed;
				uniform float _TimeScale;
				uniform float _StrengthFloat;


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

					float2 break16_g1 = float2( 0,0.1 );
					float2 uv011_g1 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float2 temp_cast_0 = (_BaseSize1SizeDiff1.x).xx;
					float smoothstepResult10_g1 = smoothstep( break16_g1.x , break16_g1.y , ( 1.0 - ( length( ( ( ( uv011_g1 - float2( 0.5,0.5 ) ) - float2( 0,0 ) ) / temp_cast_0 ) ) * 2.0 ) ));
					float2 break16_g2 = float2( 0,0.3 );
					float2 uv011_g2 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float2 temp_cast_1 = (( _BaseSize1SizeDiff1.x + _BaseSize1SizeDiff1.y )).xx;
					float smoothstepResult10_g2 = smoothstep( break16_g2.x , break16_g2.y , ( 1.0 - ( length( ( ( ( uv011_g2 - float2( 0.5,0.5 ) ) - float2( 0,0 ) ) / temp_cast_1 ) ) * 2.0 ) ));
					float2 uv021 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float2 uv_Distort = i.texcoord.xy * _Distort_ST.xy + _Distort_ST.zw;
					float3 tex2DNode1 = UnpackNormal( tex2D( _Distort, uv_Distort ) );
					float2 appendResult18 = (float2(tex2DNode1.r , tex2DNode1.g));
					float cos27 = cos( ( _DistortRotateSpeed * _Time.y ) );
					float sin27 = sin( ( _DistortRotateSpeed * _Time.y ) );
					float2 rotator27 = mul( ( uv021 + ( appendResult18 * _DistortStrength ) ) - float2( 0.5,0.5 ) , float2x2( cos27 , -sin27 , sin27 , cos27 )) + float2( 0.5,0.5 );
					

					fixed4 col = ( i.color * ( saturate( ( smoothstepResult10_g1 + smoothstepResult10_g2 ) ) * tex2D( _TextureSample0, rotator27 ) ) * (( 1.0 - _StrengthFloat ) + (sin( ( _Time.y * _TimeScale * 6.28 ) ) - -1.0) * (( _StrengthFloat + 1.0 ) - ( 1.0 - _StrengthFloat )) / (1.0 - -1.0)) );
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
420;119;1415;841;1066.286;-646.2217;1.05606;False;False
Node;AmplifyShaderEditor.CommentaryNode;43;-1056.119,677.8015;Inherit;False;1268.144;887.7071;DistortTex;11;1;20;18;19;21;29;28;30;16;27;22;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;13;-1105.652,-91.58681;Inherit;False;1542.563;655.9402;Mask;6;9;10;12;2;6;11;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;1;-1006.119,868.6536;Inherit;True;Property;_Distort;Distort;0;0;Create;True;0;0;False;0;-1;6433ad4692b7d114f95eaccf8dfb9627;6433ad4692b7d114f95eaccf8dfb9627;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;20;-820.6268,1124.575;Inherit;False;Property;_DistortStrength;DistortStrength;1;0;Create;True;0;0;False;0;0;0.051;0;0.3;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;11;-866.5863,45.40413;Inherit;False;Property;_BaseSize1SizeDiff1;BaseSize1SizeDiff1;2;0;Create;True;0;0;False;0;0.7,0.2;0.66,0.2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.DynamicAppendNode;18;-656.6266,959.5745;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;21;-661.8838,727.8015;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;29;-566.8755,1382.509;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;28;-644.3004,1266.388;Inherit;False;Property;_DistortRotateSpeed;DistortRotateSpeed;4;0;Create;True;0;0;False;0;0.5;-1.65;-2;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-540.6267,1070.575;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;12;-562.3702,182.6573;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;42;-653.9148,1679.082;Inherit;False;868.4628;659.4625;ColorFactor;9;33;35;36;39;34;41;40;37;32;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TimeNode;33;-603.9148,1973.229;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;6;-396.8413,219.9425;Inherit;True;DrawCircle;-1;;2;2f115a3d18e184f228c4670f6dcec381;0;4;1;FLOAT2;0,0;False;13;FLOAT2;0,0;False;14;FLOAT2;1,1;False;15;FLOAT2;0,0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-250.5963,1397.105;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;2;-375.0077,-41.58681;Inherit;True;DrawCircle;-1;;1;2f115a3d18e184f228c4670f6dcec381;0;4;1;FLOAT2;0,0;False;13;FLOAT2;0,0;False;14;FLOAT2;1,1;False;15;FLOAT2;0,0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;35;-599.2549,2142.725;Inherit;False;Property;_TimeScale;TimeScale;5;0;Create;True;0;0;False;0;0;0.83;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;16;-400.9722,846.2281;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;36;-305.735,2222.544;Inherit;False;Constant;_Float0;Float 0;5;0;Create;True;0;0;False;0;6.28;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;39;-545.4069,1865.175;Inherit;False;Property;_StrengthFloat;StrengthFloat;6;0;Create;True;0;0;False;0;0;0.267;0;0.7;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;-261.4019,2066.642;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-4.156372,153.5271;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;27;-181.3646,1122.966;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;3;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;41;-233.1509,1956.945;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;22;-107.9749,927.5148;Inherit;True;Property;_TextureSample0;Texture Sample 0;3;0;Create;True;0;0;False;0;-1;None;a7ba4ab3dacca1f41b92de92749d7342;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SinOpNode;37;-116.4201,2047.181;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;40;-279.6315,1875.901;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;10;252.5318,243.952;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;873.0946,646.0651;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCRemapNode;32;-75.45197,1729.082;Inherit;True;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;0.7;False;4;FLOAT;1.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;25;873.0045,348.9014;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;1149.941,726.327;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;1302.602,684.7198;Float;False;True;-1;2;ASEMaterialInspector;0;7;_10DistortPortal;0b6a9f8b4f707c74ca64c0be8e590de0;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;True;4;1;False;-1;1;False;-1;0;1;False;-1;0;False;-1;False;False;True;2;False;-1;True;True;True;True;False;0;False;-1;False;True;2;False;-1;True;3;False;-1;False;True;4;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;False;0;False;False;False;False;False;False;False;False;False;False;True;0;0;;0;0;Standard;0;0;1;True;False;;0
WireConnection;18;0;1;1
WireConnection;18;1;1;2
WireConnection;19;0;18;0
WireConnection;19;1;20;0
WireConnection;12;0;11;1
WireConnection;12;1;11;2
WireConnection;6;14;12;0
WireConnection;30;0;28;0
WireConnection;30;1;29;2
WireConnection;2;14;11;1
WireConnection;16;0;21;0
WireConnection;16;1;19;0
WireConnection;34;0;33;2
WireConnection;34;1;35;0
WireConnection;34;2;36;0
WireConnection;9;0;2;0
WireConnection;9;1;6;0
WireConnection;27;0;16;0
WireConnection;27;2;30;0
WireConnection;41;0;39;0
WireConnection;22;1;27;0
WireConnection;37;0;34;0
WireConnection;40;0;39;0
WireConnection;10;0;9;0
WireConnection;24;0;10;0
WireConnection;24;1;22;0
WireConnection;32;0;37;0
WireConnection;32;3;40;0
WireConnection;32;4;41;0
WireConnection;26;0;25;0
WireConnection;26;1;24;0
WireConnection;26;2;32;0
WireConnection;0;0;26;0
ASEEND*/
//CHKSM=9E606C6801AF843492BDDBA80DA1A865418FEE45