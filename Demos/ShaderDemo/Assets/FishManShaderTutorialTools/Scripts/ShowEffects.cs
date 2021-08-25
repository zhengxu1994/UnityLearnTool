using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class ShowEffects : MonoBehaviour
{
   	public int curIdx = -1;
	public List<GameObject> allEffect = new List<GameObject>();
	void Start(){
		allEffect.Clear();
		foreach(Transform tran in transform){
			allEffect.Add(tran.gameObject);
		}
	}
	[Button]
	void ShowNext(){
    	curIdx++;
		allEffect[(curIdx - 1 + allEffect.Count)%allEffect.Count].SetActive(false);
    	allEffect[curIdx%allEffect.Count].SetActive(true);
    	Debug.Log("hesf");
	}
    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKey(KeyCode.Space)){
    		
    	}
    }
}
