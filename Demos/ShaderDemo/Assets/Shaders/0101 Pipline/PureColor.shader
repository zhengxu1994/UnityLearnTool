Shader "FishMan/Pipline/PureColor"
{
    Properties
    {
        //_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            //float4 _TintColor;
            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //return _TintColor;
                return float4(1,0,0,1);
            }
            ENDCG
        }
    }
}
