//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using FairyGUI;
//using DG.Tweening;
//public class TestCls : MonoBehaviour
//{

//    public Transform pos1;
//    public Transform pos2;
//    public Transform obj;
//    public Transform effect;
//    public Camera camera;

//    private float cameraShake = 2;//震动系数
//    // Start is called before the first frame update
//    void Start()
//    {
//        this.camera = Camera.main;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //Vector2 v1 = pos1.transform.position;
//        //Vector2 v2 = pos2.transform.position;
//        //Vector2 t = v2 - v1;
//        //float tt = Mathf.Atan2(t.y, t.x) * 180 / Mathf.PI;

//        //if (tt >= 0 && tt <= 180)
//        //{ }
//        //else
//        //    tt = 360 + tt;
//        //effect.transform.eulerAngles = new Vector3(0, 0, tt);
//        ////Debug.Log(tt);
//        //float x =  GetScale(tt,45);
//        //effect.transform.localScale = new Vector3(x, 1, 1);
//        //Debug.Log(x);
//        if(Input.GetMouseButton(0))
//        {
//            shake = true;
//            cameraShake = 2;
//        }

//        if(shake)
//        {
//            //X,Y轴震动
//            transform.position = new Vector3((Random.Range(0f, cameraShake)) - cameraShake * 0.5f, transform.position.y, transform.position.z);
//            //Z轴震动
//            //transform.position = new Vector3(transform.position.x, transform.position.y, (Random.Range(0f, cameraShake)) - cameraShake * 0.5f);
//            cameraShake = cameraShake / 1.05f;
//            if (cameraShake < 0.05f)
//            {
//                cameraShake = 0;
//                shake = false;
//            }
//        }
//    }

//    private bool shake = false;
//    public float GetScale(float angle, float xangle)
//    {
//        float cos = Mathf.Cos(xangle * Mathf.Deg2Rad);
//        float minusCos = 1 - cos;
//        if (angle >= 0 && angle <= 90)
//        {
//            return 1 - angle / 90.0f * minusCos;
//        }
//        else if (angle > 90 && angle <= 180)
//        {
//            return cos + (angle - 90) / 90.0f * minusCos;
//        }
//        else if (angle > 180 && angle <= 270)
//        {
//            return 1 - (angle - 180) / 90.0f * minusCos;
//        }
//        else
//        {
//            return cos + (angle - 270) / 90.0f * minusCos;
//        }
//    }


//    public void Get2DAngleByVector()
//    {
//        Vector2 v1 = pos1.transform.position;
//        Vector2 v2 = pos2.transform.position;
//        Vector2 t = v2 - v1;
//        float tt = Mathf.Atan2(t.y, t.x) * 180 / Mathf.PI;

//        if (tt >= 0 && tt <= 180)
//        { }
//        else
//            tt = 360 + tt;
//        obj.transform.eulerAngles = new Vector3(0, 0, tt);
//        Debug.Log(tt);
//    }
//}
using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour
{

    // 震动标志位
    private bool isshakeCamera = false;

    // 震动幅度
    public float shakeLevel = 3f;
    // 震动时间
    public float setShakeTime = 0.2f;
    // 震动的FPS
    public float shakeFps = 45f;

    private float fps;
    private float shakeTime = 0.0f;
    private float frameTime = 0.0f;
    private float shakeDelta = 0.005f;
    private Camera selfCamera;

    private Rect changeRect;

    void Awake()
    {
        selfCamera = GetComponent<Camera>();
        changeRect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
    }

    // Use this for initialization
    void Start()
    {
        shakeTime = setShakeTime;
        fps = shakeFps;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isshakeCamera = true;
        }
        if (isshakeCamera)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if (shakeTime <= 0)
                {
                    changeRect.xMin = 0.0f;
                    changeRect.yMin = 0.0f;
                    selfCamera.rect = changeRect;
                    isshakeCamera = false;
                    shakeTime = setShakeTime;
                    fps = shakeFps;
                    frameTime = 0.03f;
                    shakeDelta = 0.005f;
                }
                else
                {
                    frameTime += Time.deltaTime;

                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        changeRect.xMin = shakeDelta * (-1.0f + shakeLevel * Random.value);
                        changeRect.yMin = shakeDelta * (-1.0f + shakeLevel * Random.value);
                        selfCamera.rect = changeRect;
                    }
                }
            }
        }
    }

    public void shake()
    {
        isshakeCamera = true;
    }
}