using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayEffect : MonoBehaviour
{
	public AnimationClip anim;
	public GameObject Effect;
    public void _PlayEffect(){
    	Debug.Log(anim.length);
    	PlayEffect(0);
    }
    public void PlayEffect(float anim){
    	Effect.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
