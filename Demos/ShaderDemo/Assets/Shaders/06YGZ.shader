// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "06YGZ"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_Progress("Progress", Range( 0 , 1)) = 0.5952927
		_Color0("Color 0", Color) = (0.509078,0.69878,0.754717,1)
		_Color1("Color 1", Color) = (1,1,1,1)

	}


	Category 
	{
		SubShader
		{
		LOD 0

			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			Blend SrcAlpha OneMinusSrcAlpha
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
				uniform float _Progress;
				uniform float4 _Color0;
				uniform float4 _Color1;


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
				float DrawCircle(float2 uv,float2 offset,float2 size,float2 ssMinMax){
					uv -= 0.5;
					uv -= offset;
					uv /= size;
					float circle = 1- length(uv) * 2;
					return smoothstep(ssMinMax.x,ssMinMax.y,circle);
				}
				
				float Remap(float oldMin,float oldMax,float newMin,float newMax,float val){
					float percent = (val - oldMin)/ (oldMax - oldMin);
					return (newMax - newMin) * percent + newMin;
				}

				fixed4 frag ( v2f i  ) : SV_Target
				{
					//return DrawCircle(i.texcoord.xy,float2(0,0),float2(1,1),float2(0,0.3));
					UNITY_SETUP_INSTANCE_ID( i );
					UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( i );

					#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
						float partZ = i.projPos.z;
						float fade = saturate (_InvFade * (sceneZ-partZ));
						i.color.a *= fade;
					#endif

					float3 uv = i.texcoord.xyz;
					float customDataVal = uv.z;
					float2 blur = float2(0,0.05);

					// 绘制外部圆
					float circle1 = DrawCircle(uv.xy,0,1,blur);

					// 绘制 内部圆
					float offsetX = Remap (0, 1, -1, 0 ,customDataVal + _Progress);
					float2 offset = float2(offsetX, 0);
					float circle2 = DrawCircle(uv.xy,offset,1,blur);//

					float moonMask = saturate( circle1 - circle2 );

					// 计算颜色
					float colorCircle = DrawCircle(uv.xy,0,1,float2( 0,0.3 ));
					float4 moonColor = lerp( _Color0 , _Color1 , colorCircle);
					
					moonColor = moonMask * moonColor;
					// 颜色调和
					fixed4 col =  i.color * _TintColor * 2.0 *  moonColor ;
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
2545;75;1155;693;-203.7731;-1503.268;1.253933;True;False
Node;AmplifyShaderEditor.CommentaryNode;59;243.483,1297.957;Inherit;False;893.546;326.0234;Offset;5;24;31;26;25;30;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;30;322.6923,1374.352;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;24;305.2241,1530.395;Inherit;False;Property;_Progress;Progress;0;0;Create;True;0;0;False;0;0.5952927;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;31;565.2563,1432.563;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;26;738.7449,1347.957;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;-1;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;25;976.0291,1420.034;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;12;861.3181,1003.946;Inherit;False;Constant;_Offset;Offset;0;0;Create;True;0;0;False;0;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;57;1113.938,1380.557;Inherit;False;DrawCircle;-1;;5;2f115a3d18e184f228c4670f6dcec381;0;4;1;FLOAT2;0,0;False;13;FLOAT2;0,0;False;14;FLOAT2;1,1;False;15;FLOAT2;0,0.05;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;60;595.8987,1767.1;Inherit;False;707.7145;639.937;Color;4;44;58;43;42;;1,1,1,1;0;0
Node;AmplifyShaderEditor.FunctionNode;56;1081.229,1000.352;Inherit;False;DrawCircle;-1;;4;2f115a3d18e184f228c4670f6dcec381;0;4;1;FLOAT2;0,0;False;13;FLOAT2;0,0;False;14;FLOAT2;1,1;False;15;FLOAT2;0,0.05;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;58;717.7847,2167.415;Inherit;True;DrawCircle;-1;;6;2f115a3d18e184f228c4670f6dcec381;0;4;1;FLOAT2;0,0;False;13;FLOAT2;0,0;False;14;FLOAT2;1,1;False;15;FLOAT2;0,0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;23;1390.305,1286.392;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;42;755.0213,1817.1;Inherit;False;Property;_Color0;Color 0;1;0;Create;True;0;0;False;0;0.509078,0.69878,0.754717,1;0.509078,0.69878,0.754717,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;43;697.8307,1979.39;Inherit;False;Property;_Color1;Color 1;2;0;Create;True;0;0;False;0;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;44;1038.613,2100.138;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;29;1625.188,1304.769;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;1802.436,1291.105;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;1;1780.872,631.8815;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;2;1759.523,810.1462;Inherit;False;0;0;_TintColor;Shader;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;4;1783.432,987.1288;Inherit;False;Constant;_Float0;Float 0;0;0;Create;True;0;0;False;0;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;2058.219,903.5753;Inherit;False;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;2236.851,922.9189;Float;False;True;-1;2;ASEMaterialInspector;0;7;06YGZ;0b6a9f8b4f707c74ca64c0be8e590de0;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;False;False;True;2;False;-1;True;True;True;True;False;0;False;-1;False;True;2;False;-1;True;3;False;-1;False;True;4;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;False;0;False;False;False;False;False;False;False;False;False;False;True;0;0;;0;0;Standard;0;0;1;True;False;;0
WireConnection;31;0;30;3
WireConnection;31;1;24;0
WireConnection;26;0;31;0
WireConnection;25;0;26;0
WireConnection;57;13;25;0
WireConnection;56;13;12;0
WireConnection;23;0;56;0
WireConnection;23;1;57;0
WireConnection;44;0;42;0
WireConnection;44;1;43;0
WireConnection;44;2;58;0
WireConnection;29;0;23;0
WireConnection;46;0;29;0
WireConnection;46;1;44;0
WireConnection;3;0;1;0
WireConnection;3;1;2;0
WireConnection;3;2;4;0
WireConnection;3;3;46;0
WireConnection;0;0;3;0
ASEEND*/
//CHKSM=FB3291BE5C78209995B21A99C194D03E3E432563

	
