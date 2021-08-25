using UnityEngine;

namespace FishMan {
    public class ShaderDefine {
        static ShaderDefine(){
            _MainTex = Shader.PropertyToID("_MainTex");
            _Detail = Shader.PropertyToID("_DetailTex");
        }
        public static int _MainTex;
        public static int _Detail;
    }
}