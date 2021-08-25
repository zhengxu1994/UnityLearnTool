using UnityEngine;

namespace FishMan {
    public class LaserEffect : MonoBehaviour {
        public enum EUpdateType {
            Disable,
            EnableNotHit,
            EnableAll
        }

        private LineRenderer LaserLine;
        public GameObject HitEffect;
        public float HitOffset = 0;

        public float MainTextureLength = 1f;
        public float DetailTextureLength = 1f;


        public EUpdateType UpdateType = EUpdateType.EnableAll;
        public Vector3 HitPos;


        private Vector2 _TexScaleMain = new Vector2(1, 1);
        private Vector2 _TexScaleDetail = new Vector2(1, 1);

        private bool _NeedUpdate = true;

        private ParticleSystem[] LaserPSs;
        private ParticleSystem[] HitPSs;

        private Material _LaserMat;

        void Start(){
            LaserLine = GetComponent<LineRenderer>();
            _LaserMat = LaserLine.material;
            LaserPSs = GetComponentsInChildren<ParticleSystem>();
            HitPSs = HitEffect.GetComponentsInChildren<ParticleSystem>();
        }


        void Update(){
            if (LaserLine != null) {
                if (UpdateType == EUpdateType.Disable) {
                    DisablePrepare();
                    return;
                }

                transform.LookAt(HitPos);
                if (UpdateType == EUpdateType.EnableNotHit) {
                    UpdateEffect(HitPos, Vector3.zero, false);
                }
                else {
                    UpdateEffect(HitPos, Vector3.zero, true);
                }

                _LaserMat.SetTextureScale(ShaderDefine._MainTex, new Vector2(_TexScaleMain[0], _TexScaleMain[1]));
                //_LaserMat.SetTextureScale(ShaderDefine._Detail, new Vector2(_TexScaleDetail[0], _TexScaleDetail[1]));
                if (!LaserLine.enabled) {
                    LaserLine.enabled = true;
                }
            }
        }

        private void UpdateEffect(Vector3 hitPos, Vector3 offset, bool isOpen){
            LaserLine.SetPosition(0, transform.position);
            LaserLine.SetPosition(1, hitPos);
            HitEffect.transform.position = hitPos + offset;
            if (isOpen) {
                foreach (var ps in LaserPSs) {
                    if (!ps.isPlaying) ps.Play();
                }
            }
            else {
                foreach (var ps in HitPSs) {
                    if (ps.isPlaying) ps.Stop();
                }
            }

            _TexScaleMain[0] = MainTextureLength * (Vector3.Distance(transform.position, hitPos));
            _TexScaleDetail[0] = DetailTextureLength * (Vector3.Distance(transform.position, hitPos));
        }

        public void DisablePrepare(){
            if (LaserLine != null) {
                LaserLine.enabled = false;
            }

            _NeedUpdate = false;
            if (LaserPSs != null) {
                foreach (var allPSs in LaserPSs) {
                    if (allPSs.isPlaying) allPSs.Stop();
                }
            }
        }
    }
}