// Create by JiepengTan@gmail.com
// https://github.com/JiepengTan
// 2020-04-03
Shader "FishMan/Sea2D"
{
    Properties
    {
        [Space]
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
        _SubeWaveOffsetHashFactor("_SubeWaveOffsetHashFactor",Float) = 50 
        _SubWaveAmptFactor("_SubWaveAmptFactor",Float) = 0.61 
        _SubWaveFrequenceFactor("_SubWaveFrequenceFactor",Float) = 1.5 

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

            float4 _SkyLineColor;
            float _SkyLinePower;
            float _SkyLineFactor;

            float _SeaHigh;
            float _LayerGapPower;

            float _AmptPower;
            float _AmptFactor;


            float _SubeWaveOffsetHashFactor;
            float _SubWaveAmptFactor;
            float _SubWaveFrequenceFactor;


            #define LAYER_COUNT 20
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            float Hash11(float val){
                return frac(sin(val * 3714.57) * 174.11);
            }
            float Wave(float x,float layer){
                float percent = (1-layer/ LAYER_COUNT);
                float amptitude = _AmptFactor * pow(percent,_AmptPower);
                //sin(x)+ sin(2*x)*0.5 + sin(4*x)*0.25
                float amp = 1;
                float frequence = 1;
                float res = 0;
                for (int i = 0; i < 3; ++i)
                {
                    float frq = frequence * x * UNITY_TWO_PI * (3 + layer);
                    float offset = _Time.x * (UNITY_TWO_PI* 10+ Hash11(layer)* _SubeWaveOffsetHashFactor);
                    float val = sin(frq + offset) * amptitude * amp;
                    res+= val;
                    amp *= _SubWaveAmptFactor;
                    frequence *= _SubWaveFrequenceFactor;
                }

                return res;
            }
            float Remap(float srcStart,float srcEnd,float dstStart,float dstEnd,float val){
                return (val - srcStart)/ (srcEnd - srcStart) * (dstEnd - dstStart) + dstStart;
            }
            float4 DrawSky(float2 uv){
                float val = Remap(_SeaHigh,1.0,0,1,uv.y);
                float4 col = lerp(_BSkyColor,_TSkyColor, val);
                return col + _SkyLineColor * pow(1-val,_SkyLinePower) * _SkyLineFactor;
            }
            float4 DrawSea(float2 uv){
                float val = Remap(0,_SeaHigh,0,1,uv.y);
                float layerId = LAYER_COUNT;
                for (float layer = 0; layer < LAYER_COUNT; ++layer)
                {
                    float percent = layer / LAYER_COUNT;//layer ==0
                    percent = pow(percent,_LayerGapPower);
                    float curLayerHigh = percent * _SeaHigh;
                    curLayerHigh += Wave(uv.x,layer);
                    if(uv.y < curLayerHigh){
                        layerId = layer;
                        break;
                    }
                    /* code */
                }
                float4 col = lerp(_BSeaColor,_TSeaColor,layerId / LAYER_COUNT);
                return col;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float4 res = 0;
                if(uv.y > _SeaHigh) {
                    return DrawSky(uv);
                }
                else{
                    return DrawSea(uv);
                }
                res.xy = uv;
                return res;
            }
            ENDCG
        }
    }
}
