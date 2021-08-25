Shader "FishMan/19Sea"
{
    Properties
    {
        _SeaHigh("_SeaHigh",Float )= 0.3
        _LayerGapPower("_LayerGapPower",Float) = 0.5 
        [Header(Colors)]
        _TSkyColor("_TSkyColor",Color )= (1,1,1,1)
        _BSkyColor("_BSkyColor",Color )= (1,1,1,1)
        _TSeaColor("_SeaColor",Color )= (1,1,1,1)
        _BSeaColor("_SeaColor",Color )= (1,1,1,1)

        [Header(SkyLine)]
        [Space]
        _SkyLineColor("_SkyLineColor",Color )= (1,1,1,1)
        _SkyLinePower("_SkyLinePower",Float )= 10
        _SkyLineFactor("_SkyLineFactor",Float)= 1

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
            #include "../ShaderLibs/Util2D.cginc"
            #include "../ShaderLibs/Hash.cginc"

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
            float4 _TSeaColor;
            float4 _BSeaColor;

            float _SeaHigh;
            float _LayerGapPower;

            float4 _SkyLineColor;
            float _SkyLinePower;
            float _SkyLineFactor;

            float _AmptPower;
            float _AmptFactor;

            float _SubWaveAmptFactor;
            float _SubWaveFrequenceFactor;
            float _SubeWaveOffsetBaseSpd;
            float _SubeWaveOffsetHashFactor;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            #define LAYER_COUNT  15
            //
            float Wave(float x,float layer){
                float percent = 1 - layer / LAYER_COUNT;
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
            float4 DrawSea(float2 uv){
                float val = Remap(0,_SeaHigh,0,1,uv.y);
                float layerId = LAYER_COUNT;
                for (float layer = 0; layer < LAYER_COUNT; ++layer)
                {
                    float percent = layer / LAYER_COUNT;//layer ==0 
                    percent = pow(percent,_LayerGapPower);
                    float curLayerHigh = percent * _SeaHigh;
                    curLayerHigh+= Wave(uv.x,layer);
                    if(uv.y < curLayerHigh){
                        layerId = layer;
                        break;
                    }
                }

                return lerp(_BSeaColor,_TSeaColor,layerId/ LAYER_COUNT);
            }
            float4 DrawSky(float2 uv){ 
                float val = Remap(_SeaHigh,1.0,0,1,uv.y);
                float4 col = lerp(_BSkyColor,_TSkyColor, val);

                return col + _SkyLineColor * pow(1-val,_SkyLinePower) * _SkyLineFactor;
            }
            fixed4 frag (v2f i) : SV_Target
            {
               float4 ret = float4(0,0,0,1);
                float2 uv = i.uv;
                if(uv.y < _SeaHigh){
                    return DrawSea(uv);
                }else{
                    return DrawSky(uv);
                }
            }
            ENDCG
        }
    }
}
