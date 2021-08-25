// Create by JiepengTan@gmail.com
// https://github.com/JiepengTan

Shader "FishMan/UberParticleEffect"
{
    Properties
    {
        [Header(ColorTint)]
        _TintColor(" _TintColor ",Color) = (0.5,0.5,0.5,0.5)
        _ColorFactor("_ColorFactor ",Float) = 1

        [Header(MainTex)]
        _MainTex ("Main Texture", 2D) = "white" {}
        _MainSpeed2_MaskSpeed2 ("_MainSpeed2_MaskSpeed2", Vector) = (0,0,0,0)

        [Header(Mask)]
        _MaskTex ("_MaskTex", 2D) = "white" {}

        [Header(Distortion)]
        _DistortTex ("_DistortTex", 2D) = "white" {}
        _DistortSpeed2_Factor2 ("_DistortSpeed2_Factor2", Vector) = (1,1,1,1)
        _DistortUVFactor2_RotateSpeed1(" _DistortUVFactor2_RotateSpeed1 ",Vector) = (1,1,0,0)

        [Header(Dissolve)]
        _DissolveTex("_DissolveTex", 2D) = "white" {}
        _DissolveProgress("DissolveProgress", Range( 0 , 1)) = 0
        [HDR] _DissolveColor ("_DissolveColor", Color) = (0.9,0.9,0.2,1)
        _DissolveRange("_DissolveRange", Range( 0 , 1)) = 0.5


        [Header(Soft particle)]
        [Toggle(USE_SOFTPARTICLES)] _UseSoftParticle("Use Soft Particle", Int) = 0
        _InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0  // soft particles


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
    SubShader
    {
    	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        LOD 100
        
        Lighting Off
        BlendOp [_BlendOp]
        Blend[_SrcBlend][_DstBlend]
        Cull[_CullMode]
        ZWrite[_ZWrite]

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Util.cginc"

            #pragma shader_feature USE_MASK
            #pragma shader_feature USE_DISTORT
            #pragma shader_feature USE_DISSOLVE
            #pragma shader_feature USE_SOFTPARTICLES
            #pragma shader_feature USE_FLOW_DISTORT
            
            //#define 
#if defined(USE_MASK)
    #define USING_MASK
#endif

#if defined(USE_DISTORT)
    #define USING_DISTORT
    #if defined(USE_FLOW_DISTORT)
        #define USING_FLOW_DISTORT
    #endif
#endif

#if defined(SOFTPARTICLES_ON) || defined(USE_SOFTPARTICLES)
    #define USING_SOFTPARTICLES
#endif

#if defined(USE_DISSOLVE)
    #define USING_DISSOLVE
#endif
            float4 _TintColor;
            float _ColorFactor;

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainSpeed2_MaskSpeed2;

#ifdef  USING_MASK
            sampler2D _MaskTex;
            float4 _MaskTex_ST;
#endif //USE_MASK

#ifdef  USING_DISTORT
            sampler2D _DistortTex;
            float4 _DistortTex_ST;
            float4 _DistortSpeed2_Factor2;
            float4 _DistortUVFactor2_RotateSpeed1;
#endif //USING_DISTORT

#ifdef  USING_DISSOLVE
            sampler2D _DissolveTex;
            float4 _DissolveTex_ST;
            float _DissolveProgress;
            fixed4 _DissolveColor;
            float _DissolveRange;
#endif //USING_DISSOLVE

#ifdef  USING_SOFTPARTICLES
            UNITY_DECLARE_DEPTH_TEXTURE(_CameraDepthTexture);
            float _InvFade;
#endif //USING_SOFTPARTICLES

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 customData : TEXCOORD0;
                float4 MainUV2_MaskUV2 : TEXCOORD1;
            #if defined(USING_DISSOLVE) || defined(USING_DISTORT)
                float4 DistortUV2_DissolveUV2 : TEXCOORD2;
            #endif

            #ifdef USING_SOFTPARTICLES
                float4 projPos : TEXCOORD3;
            #endif
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color;
                o.customData.xy = v.uv.zw;

                float2 uv = v.uv.xy;
                o.MainUV2_MaskUV2.xy = uv * _MainTex_ST.xy + _MainTex_ST.zw;

            #ifdef USING_MASK
                o.MainUV2_MaskUV2.zw = uv * _MaskTex_ST.xy + _MaskTex_ST.zw ;
            #endif

            #ifdef USING_DISTORT
                o.DistortUV2_DissolveUV2.xy = uv * _DistortTex_ST.xy + _DistortTex_ST.zw ; 
            #endif

            #ifdef USING_DISSOLVE
                o.DistortUV2_DissolveUV2.zw = uv * _DissolveTex_ST.xy + _DissolveTex_ST.zw ;
            #endif

            #ifdef USING_SOFTPARTICLES
                o.projPos = ComputeScreenPos (o.vertex);
                COMPUTE_EYEDEPTH(o.projPos.z);
            #endif
                return o;
            }


            fixed4 frag (v2f i) : SV_Target
            {

            #ifdef USING_SOFTPARTICLES
                float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
                float partZ = i.projPos.z;
                float fade = saturate (_InvFade * (sceneZ-partZ));
                i.color.a *= fade;
            #endif

                float time = _Time.y;
                fixed maskVal = 1;

            #ifdef USING_MASK
                fixed2 maskUV = i.MainUV2_MaskUV2.zw + _MainSpeed2_MaskSpeed2.zw * time;
                maskVal *= tex2D(_MaskTex, maskUV).r;
            #endif //Mask

                fixed2 mainUV = i.MainUV2_MaskUV2.xy + _MainSpeed2_MaskSpeed2.xy * time;
                // calc distort uv
        #ifdef USING_DISTORT//旋转
                float2 distortUV = 0;
            #ifdef USING_FLOW_DISTORT
                half2 distort1 = SAMPLE_DISTORT_TEX(_DistortTex, i.DistortUV2_DissolveUV2.xy + _DistortSpeed2_Factor2.xy * time);
                half2 distort2 = SAMPLE_DISTORT_TEX(_DistortTex, i.DistortUV2_DissolveUV2.xy + float2(0.37,0.71) + _DistortSpeed2_Factor2.xy * time * 1.3) * 0.7;
                distortUV += (distort1 + distort2);
            #else
                distortUV += SAMPLE_DISTORT_TEX(_DistortTex,i.DistortUV2_DissolveUV2.xy);
            #endif //FLOW_DISTORT
                distortUV *= maskVal;
                mainUV += distortUV * _DistortUVFactor2_RotateSpeed1.xy;    //add distort
                mainUV = Rotate2D(mainUV, _Time.y *  _DistortUVFactor2_RotateSpeed1.z);
                //return float4(mainUV,0,1);
        #endif//distort
                

                fixed4 mainCol = tex2D(_MainTex, mainUV);

            #ifdef USING_DISSOLVE
                float customData = i.customData.x;
                float progress = customData + _DissolveProgress + 0.1;
                float dissolveVal = tex2D( _DissolveTex, i.DistortUV2_DissolveUV2.zw ).r * mainCol.a;
                clip( dissolveVal - progress );
                
                float dissolveBorderVal = saturate((dissolveVal -progress));
                dissolveBorderVal = saturate(1- smoothstep(0,_DissolveRange ,dissolveBorderVal)) * step(dissolveBorderVal,_DissolveRange);
                
                mainCol = lerp(mainCol,_DissolveColor,dissolveBorderVal) ;
            #endif//dissolve


                fixed4 finalCol = mainCol * i.color * _TintColor * (maskVal * _ColorFactor * 2 );
                return finalCol;
            }
            ENDCG
        }//endOf pass
    }//endOf SubShader 
    CustomEditor "FishMan.UberParticleGUI"
}
