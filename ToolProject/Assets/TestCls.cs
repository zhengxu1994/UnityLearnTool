using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCls : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    public Transform obj;
    public Transform effect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v1 = pos1.transform.position;
        Vector2 v2 = pos2.transform.position;
        Vector2 t = v2 - v1;
        float tt = Mathf.Atan2(t.y, t.x) * 180 / Mathf.PI;

        if (tt >= 0 && tt <= 180)
        { }
        else
            tt = 360 + tt;
        effect.transform.eulerAngles = new Vector3(0, 0, tt);
        //Debug.Log(tt);
        float x =  GetScale(tt,45);
        effect.transform.localScale = new Vector3(x, 1, 1);
        Debug.Log(x);
    }

    public float GetScale(float angle, float xangle)
    {
        float cos = Mathf.Cos(xangle * Mathf.Deg2Rad);
        float minusCos = 1 - cos;
        if (angle >= 0 && angle <= 90)
        {
            return 1 - angle / 90.0f * minusCos;
        }
        else if (angle > 90 && angle <= 180)
        {
            return cos + (angle - 90) / 90.0f * minusCos;
        }
        else if (angle > 180 && angle <= 270)
        {
            return 1 - (angle - 180) / 90.0f * minusCos;
        }
        else
        {
            return cos + (angle - 270) / 90.0f * minusCos;
        }
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
