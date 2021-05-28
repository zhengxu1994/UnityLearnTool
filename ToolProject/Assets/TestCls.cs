using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCls : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    public Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    public void Get2DAngleByVector()
    {
        Vector2 v1 = pos1.transform.position;
        Vector2 v2 = pos2.transform.position;
        Vector2 t = v2 - v1;
        float tt = Mathf.Atan2(t.y, t.x) * 180 / Mathf.PI;

        if (tt >= 0 && tt <= 180)
        { }
        else
            tt = 360 + tt;
        obj.transform.eulerAngles = new Vector3(0, 0, tt);
        Debug.Log(tt);
    }
}
