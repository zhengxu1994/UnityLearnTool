using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> aa = new List<int>();
        Debug.Log(aa.Capacity);
   
        Debug.Log(aa.Count);
        for (int i = 0; i < 6; i++)
        {
            aa.Add(i);
        }
        aa.Capacity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
