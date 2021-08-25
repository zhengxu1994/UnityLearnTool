using System.Collections.Generic;
using UnityEngine;

public class TweenMaterialProperty : MonoBehaviour {
    public Renderer Renderer;
    private Material mat;
    private float timer;

    [System.Serializable]
    public class ColorInfo {
        public string name;
        public Color start;
        public Color end;
        public float peroid;
    }

    [System.Serializable]
    public class FloatInfo {
        public string name;
        public float start;
        public float end; 
        public float peroid;
    }

    public List<ColorInfo> colors = new List<ColorInfo>();
    public List<FloatInfo> floats = new List<FloatInfo>();

    private void Start(){
      if(Renderer!= null)  Renderer.material = mat = new Material(Renderer.material);
    }

    public void Update(){
        timer += Time.deltaTime;
        foreach (var info in colors) {
            UpdateInfo(info);
        }

        foreach (var info in floats) {
            UpdateInfo(info);
        }
    }

    public MonoBehaviour mono;
    void UpdateInfo(ColorInfo info){
        float percent = (timer % info.peroid) / info.peroid;
        percent = ((int) (timer / info.peroid) % 2 == 0) ? percent : 1 - percent;
        var val = Color.Lerp(info.start, info.end, percent);
        mat?.SetColor(info.name,val );
        if (mono != null) {
            mono.GetType().GetField(info.name).SetValue(mono,val);
        }
    }

    void UpdateInfo(FloatInfo info){
        float percent = (timer % info.peroid) / info.peroid;
        percent = ((int) (timer / info.peroid) % 2 == 0) ? percent : 1 - percent;
        var val = Mathf.Lerp(info.start, info.end, percent);
        mat?.SetFloat(info.name,val);
        if (mono != null) {
            mono.GetType().GetField(info.name).SetValue(mono,val);
        }
    }
}