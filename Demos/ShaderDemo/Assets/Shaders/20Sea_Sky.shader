// Create by JiepengTan@gmail.com
// https://github.com/JiepengTan
// 2020-04-03
Shader "FishMan/Optimize/Sea2DSky"
{
    Properties
    {
        [Space]
        _SeaHigh("_SeaHigh",Float )= 0.3
        
        [Header(Colors)]
        _TSkyColor("_TSkyColor",Color )= (1,1,1,1)
        _BSkyColor("_BSkyColor",Color )= (1,1,1,1)

        [Header(SkyLine)]
        [Space]
        _SkyLineColor("_SkyLineColor",Color )= (1,1,1,1)
        _SkyLinePower("_SkyLinePower",Float )= 10
        _SkyLineFactor("_SkyLineFactor",Float)= 1


    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        LOD 100
        Blend One Zero
        ColorMask RGB
        Cull Off Lighting Off ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "./ShaderLibs/Util2D.cginc"
            #include "./ShaderLibs/Hash.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            float4 _TSkyColor;
            float4 _BSkyColor;

            float4 _SkyLineColor;
            float _SkyLinePower;
            float _SkyLineFactor;

            float _SeaHigh;


            #define LAYER_COUNT 20
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            float4 DrawSky(float2 uv){
                float val = Remap(_SeaHigh,1.0,0,1,uv.y);
                float4 col = lerp(_BSkyColor,_TSkyColor, val);
                return col + _SkyLineColor * pow(1-val,_SkyLinePower) * _SkyLineFactor;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float4 res = 0;
                return DrawSky(uv);
            }
            ENDCG
        }
    }
}
