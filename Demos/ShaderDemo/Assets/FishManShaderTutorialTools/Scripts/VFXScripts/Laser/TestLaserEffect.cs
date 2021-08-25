using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace FishMan {
    public class TestLaserEffect : MonoBehaviour {
        public Transform StartPoint;
        public Transform EndPoint;
        public bool HasHited = true;
        public LaserEffect LaserEffect;


        // Update is called once per frame
        void Update(){
            if(LaserEffect == null) return;
            LaserEffect.transform.position = StartPoint.position;
            LaserEffect.transform.LookAt(EndPoint.position);
            LaserEffect.HitPos = EndPoint.position;
        }
    }
}