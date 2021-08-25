
Shader "FishMan/11UberShader"
{
	Properties
	{
		[Header(Main)]
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Main Texture", 2D) = "white" {}

		[Header(UV Flow)]
		[Toggle(USE_UV_FLOW)] _UseUVFlow("Use UV Flow", Int) = 0
		_FlowSpeed("FlowSpeed", Vector) = (1,1,0,0)

		[Header(Mask)]
		_MaskTex ("Mask Texture", 2D) = "white" {}

		// distort
		[Header(Distort)]
		_DistortTex("_DistortTex", 2D) = "bump" {}
		_DistrotStrength("DistrotStrength", Range( 0 , 0.5)) = 0
		_DistortRotateSpeed("DistortRotateSpeed", Float) = 0

		// dissolve
		[Header(Dissolve)]
		_DissolveTex("DissolveTex", 2D) = "white" {}
		_DissolveProgress("DissolveProgress", Range( 0 , 1)) = 0
		_DissolveColor ("_DissolveColor", Color) = (0.5,0.5,0.5,0.5)
		_DissolveRange("_DissolveRange", Range( 0 , 1)) = 0.5


		[Header(Solf Particle)]
		[Toggle(USE_SOFT_PARTICLES)] _UseSoftParticle("Use Soft Particle", Int) = 0
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0

		[Space]
        [Header(Rendering)]
        // Fade,   // Old school alpha-blending mode, fresnel does not affect amount of transparency
        // Transparent, // Physically plausible transparency mode, implemented as alpha pre-multiply
        [Enum(Cull Off,0, Cull Front,1, Cull Back,2)] 
        _CullMode("Culling", Float) = 0 //0 = off, 2=back
        [KeywordEnum(Additive,Blend,Opaque,Cutout,Transparent,Subtractive,Modulate)] 
        _BlendMode("Blend Mode", Float) = 1
        _SrcBlend("SrcBlend", Int) = 5
        _DstBlend("DstBlend", Int) = 10
        [HideInInspector] _BlendOp ("__blendop", Float) = 0.0
        _ZWrite("ZWrite On", Int) = 1
	}

	Category 
	{
		SubShader
		{
			LOD 0

			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			BlendOp [_BlendOp]
        	Blend[_SrcBlend][_DstBlend]
        	Cull[_CullMode]
        	ZWrite[_ZWrite]

			Lighting Off 
			ColorMask RGB
			
			Pass {
			
				CGPROGRAM
				
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0
				

				#include "UnityCG.cginc"
				#include "Util.cginc"

            	#pragma shader_feature USE_SOFT_PARTICLES
            	#pragma shader_feature USE_UV_FLOW
            	#pragma shader_feature USE_MASK
            	#pragma shader_feature USE_DISTORT
            	#pragma shader_feature USE_DISSOLVE

				//#define USE_SOFT_PARTICLES
#if defined(USE_SOFT_PARTICLES) || defined(SOFTPARTICLES_ON)
	#define USING_SOFT_PARTICLES
#endif
				
#if defined(USE_UV_FLOW) 
	#define USING_UV_FLOW
#endif

#if defined(USE_MASK) 
	#define USING_MASK
#endif

#if defined(USE_DISTORT) 
	#define USING_DISTORT
#endif

#if defined(USE_DISSOLVE) 
	#define USING_DISSOLVE
#endif

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float4 uv : TEXCOORD0;
					
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float4 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					#ifdef USING_SOFT_PARTICLES
					float4 projPos : TEXCOORD2;
					#endif
					
				};
				
				uniform fixed4 _TintColor;

				uniform sampler2D _MainTex;
				uniform float4 _MainTex_ST;
				
			#ifdef USING_SOFT_PARTICLES
				// soft particle 
				uniform float _InvFade;
				#if UNITY_VERSION >= 560
				UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
				#else
				uniform sampler2D_float _CameraDepthTexture;
				#endif
			#endif //USING_SOFT_PARTICLES


				// uv flow
			#ifdef USING_UV_FLOW
				uniform fixed4 _FlowSpeed;
			#endif //USING_UV_FLOW
				// mask
			#ifdef USING_MASK
				uniform sampler2D _MaskTex;
			#endif //USING_MASK

				// distort
			#ifdef USING_DISTORT
				uniform sampler2D _DistortTex;
				uniform float4 _DistortTex_ST;
				uniform float _DistrotStrength;
				uniform float _DistortRotateSpeed;
			#endif //USING_DISTORT

				//dissolve 
			#ifdef USING_DISSOLVE
				uniform sampler2D _DissolveTex;
				uniform float _DissolveProgress;
				uniform float4 _DissolveTex_ST;
				uniform fixed4 _DissolveColor;
				uniform float _DissolveRange;
			#endif //USING_DISSOLVE


				v2f vert ( appdata_t v  )
				{
					v2f o;
					v.vertex.xyz +=  float3( 0, 0, 0 ) ;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef USING_SOFT_PARTICLES
						o.projPos = ComputeScreenPos (o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.uv = v.uv;
					return o;
				}

				fixed4 frag ( v2f i  ) : SV_Target
				{
					//soft particle
				#ifdef USING_SOFT_PARTICLES
					float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
					float partZ = i.projPos.z;
					float fade = saturate (_InvFade * (sceneZ-partZ));
					i.color.a *= fade;
				#endif //USING_SOFT_PARTICLES

					float2 uv = i.uv.xy;
					uv = uv *_MainTex_ST.xy + _MainTex_ST.zw;// 主uv

				#ifdef USING_UV_FLOW
					// uv flow
					uv -= _FlowSpeed.xy * _Time.y;
				#endif //USING_UV_FLOW

					float mask = 1;
					// mask
				#ifdef USING_MASK
					mask = tex2D(_MaskTex, i.uv.xy ).r;
				#endif //USE_MASK
					//distort 
				#ifdef USING_DISTORT
					float2 distortUV = uv * _DistortTex_ST.xy + _DistortTex_ST.zw;
					float2 distortVal = UnpackNormal( tex2D( _DistortTex, distortUV ) ) .rg;
					uv = uv + ( distortVal * _DistrotStrength );
					uv = Rotate2D(uv, _Time.y *  _DistortRotateSpeed);//旋转
				#endif //USE_MASK

					float4 mainCol = tex2D(_MainTex, uv );

					//dissolve 
				#ifdef USING_DISSOLVE
					float customData = i.uv.z;
					float2 dissolveUV = uv * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
					float progress =  _DissolveProgress + customData + 0.1;
					float dissolveVal = tex2D( _DissolveTex, dissolveUV ).r * mainCol.r;
					clip( dissolveVal - progress );

					float dissolveBorderVal = saturate((dissolveVal -progress) * 4);
					dissolveBorderVal = smoothstep(0,_DissolveRange,dissolveBorderVal);
					mainCol = lerp(_DissolveColor ,mainCol,dissolveBorderVal);
				#endif//USE_MASK


					fixed4 col = 2.0f * mask* _TintColor * i.color * mainCol;
					
					return col;
				}
				ENDCG 
			} // pass
		}//SubShader
	}//Category
	CustomEditor "_11UberShaderGUI"
}
