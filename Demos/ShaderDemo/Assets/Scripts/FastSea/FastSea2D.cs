// Create by JiepengTan@gmail.com
// https://github.com/JiepengTan
// 2020-04-03
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 计算量 = 指令提交时间（DC） +  单一像素耗时  *  面积
// 19：			1 *n	 		15 *x		 15		
// 20:			15*n 			1  *x		 2.5 *15
//
//// 当然这只是一个 大概的估计，具体要真机测试  ，但这是一种额外的思路 

[ExecuteInEditMode]
public class FastSea2D : MonoBehaviour {
    public float _SkyOffset = 0.05f;
    public bool IsAutoUpdate = true;
    public int WaveCount = 20;

    [Header("Material Attribute")] 
    public float _SeaHigh = 0.3f;
    public float _LayerGapPower = 0.5f;
    [Header("Colors ")] 
    public Color _TSkyColor = Color.white;
    public Color _BSkyColor = Color.white;
    public Color _TSeaColor = Color.white;
    public Color _BSeaColor = Color.white;
    [Header("SkyLine ")] 
    public Color _SkyLineColor = Color.white;
    public float _SkyLinePower = 10f;
    public float _SkyLineFactor = 1f;

    [Header("Waves ")] 
    public float _AmptPower = 1.66f;
    public float _AmptFactor = 0.013f;

    [Header("SubWave ")] 
    public float _SubWaveAmptFactor= 50f;
    public float _SubWaveFrequenceFactor= 0.73f;
    public float _SubeWaveOffsetBaseSpd= 1.25f;
    public float _SubeWaveOffsetHashFactor;
    [Header("Prefabs ")] 
    public GameObject SkyPrefab;
    public GameObject WavePrefab;

    [Header("Runtime don't modify it")] public GameObject _Sky;

    public Material _SkyMat;
    public List<GameObject> _Waves = new List<GameObject>();
    public List<Material> _WaveMats = new List<Material>();

    public void Clear(){
        if (_Sky != null) {
            GameObject.DestroyImmediate(_Sky);
        }

        foreach (var mat in _WaveMats) {
            if (mat != null) GameObject.DestroyImmediate(mat);
        }

        _WaveMats.Clear();
        foreach (var wave in _Waves) {
            if (wave != null) GameObject.DestroyImmediate(wave);
        }

        _Waves.Clear();
    }

    void CreateItems(){
        // create sky
        SkyPrefab.gameObject.SetActive(true);
        _Sky = GameObject.Instantiate(SkyPrefab, transform);
        _Sky.name = "Sky";
        SkyPrefab.gameObject.SetActive(false);
        _SkyMat = new Material(SkyPrefab.GetComponent<Renderer>().sharedMaterial);
        _Sky.GetComponent<Renderer>().sharedMaterial = _SkyMat;

        //create waves
        WavePrefab.gameObject.SetActive(true);
        var waveMat = WavePrefab.GetComponent<Renderer>().sharedMaterial;
        for (int i = 0; i <= WaveCount; i++) {
            var wave = GameObject.Instantiate(WavePrefab, transform);
            wave.name = "Wave_" + i;
            var mat = new Material(waveMat);
            _WaveMats.Add(mat);
            wave.GetComponent<Renderer>().sharedMaterial = mat;
            _Waves.Add(wave);
        }

        WavePrefab.gameObject.SetActive(false);
    }

    void UpdateInfos(bool isForce){
        if (_Waves.Count != WaveCount || isForce) {
           Clear();
           CreateItems();
        }

        UpdateMaterialInfos();
    }

    public void ForceRefresh(){
        UpdateInfos(true);
    }

    public void Refresh(){
        UpdateInfos(false);
    }

    private void Update(){
        if (IsAutoUpdate) {
            Refresh();
        }
    }

    void UpdateOffsetSize(Transform trans, float minHigh, float maxHigh){
        minHigh = Mathf.Max(0, minHigh);
        trans.localScale = new Vector3(1, maxHigh - minHigh, 1);
        trans.localPosition = new Vector3(0, minHigh + (maxHigh - minHigh) * 0.5f - 0.5f, 0)
            ;
    }

    private int startQueueIdx = 3000;

    void UpdateMaterialInfos(){
        var startIdx = startQueueIdx;
        _SkyMat.SetFloat("_SeaHigh", 0);
        _SkyMat.SetFloat("_LayerGapPower", _LayerGapPower);


        _SkyMat.SetColor("_TSkyColor", _TSkyColor);
        _SkyMat.SetColor("_BSkyColor", _BSkyColor);

        _SkyMat.SetColor("_SkyLineColor", _SkyLineColor);
        _SkyMat.SetFloat("_SkyLinePower", _SkyLinePower);
        _SkyMat.SetFloat("_SkyLineFactor", _SkyLineFactor);

        _SkyMat.renderQueue = startIdx++;
        UpdateOffsetSize(_Sky.transform, _SeaHigh - _SkyOffset, 1); //update pos

        float preMinHigh = 0;
        for (int layerId = 0; layerId <= WaveCount; layerId++) {
            var mat = _WaveMats[layerId];
            mat.renderQueue = startIdx + WaveCount - layerId;

            mat.SetFloat("_SeaHigh", _SeaHigh);
            mat.SetFloat("_LayerGapPower", _LayerGapPower);


            mat.SetColor("_TSeaColor", _TSeaColor);
            mat.SetColor("_BSeaColor", _BSeaColor);

            mat.SetFloat("_AmptPower", _AmptPower);
            mat.SetFloat("_AmptFactor", _AmptFactor);
            
            mat.SetFloat("_WaveCount", WaveCount);

            mat.SetFloat("_SubeWaveOffsetHashFactor", _SubeWaveOffsetHashFactor);
            mat.SetFloat("_SubWaveAmptFactor", _SubWaveAmptFactor);
            mat.SetFloat("_SubWaveFrequenceFactor", _SubWaveFrequenceFactor);
            mat.SetFloat("_SubeWaveOffsetHashFactor", _SubeWaveOffsetHashFactor);
            

            mat.SetFloat("_LayerId", layerId);


            float percent = layerId * 1.0f / WaveCount;
            float oneMinusPercent = 1-percent;
            percent = Mathf.Pow(percent, _LayerGapPower);
            float curLayerHigh = percent * _SeaHigh;
            
            float subWaveAmptitude = _AmptFactor * Mathf.Pow(oneMinusPercent, _AmptPower);
            float minMaxGap = subWaveAmptitude * 4; //FBM return [-2,2]
            
            float minHigh = curLayerHigh - minMaxGap * 0.5f;
            float maxHigh = curLayerHigh + minMaxGap * 0.5f;
            UpdateOffsetSize(_Waves[layerId].transform, preMinHigh, maxHigh); //update pos
            mat.SetFloat("_WaveBaseHigh", (curLayerHigh - preMinHigh) / (maxHigh - preMinHigh));
            mat.SetFloat("_WavePercent", 1 / (maxHigh - preMinHigh));//(minMaxGap) / (maxHigh - preMinHigh));
            preMinHigh = minHigh;
        }
        //
    }
}