// Create by JiepengTan@gmail.com
// https://github.com/JiepengTan
// 2020-04-03

Shader "FishMan/Optimize/SeaWave"
{
    Properties
    {
        _WaveCount("_WaveCount",Float) = 15
        [Space]
        _SeaHigh("_SeaHigh",Float )= 0.3
        _LayerGapPower("_LayerGapPower",Float) = 0.5 
        
        [Header(Colors)]
        _TSeaColor("_SeaColor",Color )= (1,1,1,1)
        _BSeaColor("_SeaColor",Color )= (1,1,1,1)

        [Header(Amptitude)]
        [Space]
        _AmptPower("_AmptPower",Float) = 1 
        _AmptFactor("_AmptFactor",Float) = 0.05 

        [Space]
        [Header(SubWave Attribute)] 
        _SubWaveAmptFactor("_SubWaveAmptFactor",Float) = 0.35 
        _SubWaveFrequenceFactor("_SubWaveFrequenceFactor",Float) = 1.7 
        _SubeWaveOffsetBaseSpd("_SubeWaveOffsetBaseSpd",Float) = 1 
        _SubeWaveOffsetHashFactor("_SubeWaveOffsetHashFactor",Float) = 1 


        [Space]
        [Header(RunTimeInfo)] 
        _LayerId("_LayerId",Float) = 1
        _WaveBaseHigh("_WaveBaseHigh",Float) = 1
        _WavePercent("_WavePercent",Float) = 1
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
            float4 _TSeaColor;
            float4 _BSeaColor;

            float _SeaHigh;
            float _LayerGapPower;

            float _AmptPower;
            float _AmptFactor;

            float _SubWaveAmptFactor;
            float _SubWaveFrequenceFactor;
            float _SubeWaveOffsetBaseSpd;
            float _SubeWaveOffsetHashFactor;

            float _WaveCount;
            float _LayerId;
            float _WaveBaseHigh;
            float _WavePercent;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            float Wave(float x,float layer){
                float percent = 1 - layer / _WaveCount;
                float frequence = _PI2 * (layer + 3);
                float amptitude = pow(percent,_AmptPower) * _AmptFactor;
                float offset = _PI2 * Hash11(layer);
                float result = 0;
                float spd = _SubeWaveOffsetBaseSpd;
                for (int i = 0; i < 3; ++i)
                {
                    result += sin(x * frequence + offset +
                     Hash11(i + offset) * _PI2 + _Time.y * _PI2 * spd
                     ) * amptitude;
                    frequence *= _SubWaveFrequenceFactor;
                    amptitude*= _SubWaveAmptFactor;
                    spd *= _SubeWaveOffsetHashFactor;
                }
                return result;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv; 
                float curLayerHigh = _WaveBaseHigh +  Wave(uv.x,_LayerId)*_WavePercent;// Wave  -2~2
                float4 col =  lerp(_BSeaColor,_TSeaColor,_LayerId / _WaveCount);
                clip(curLayerHigh -uv.y); 
                return col;
            }
            ENDCG
        }
    }
}
