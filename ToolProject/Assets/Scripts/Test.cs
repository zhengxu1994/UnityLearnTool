using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 0;
        a |= 1 >> 4;
        Debug.Log(a);
        Debug.Log(1 >> 4);
        Debug.Log(Test11(5, 5));
        Test2 t2 = new Test2();
        TT(t2.A);
        Debug.Log(t2.A);
        Debug.Log(Time.deltaTime);
    }


    public void TT(int a)
    {
        a = 10;
    }
    

    public double Test11(int  i ,int j)
    {
        if (j <= 1)
        {
            return 1;
        }
        return i * Test11(i, j - 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Test2
{
    private int a =1;

    public int A
    {
        get {
            return a;
        }
        set
        {
            a = value;
        }
    }

}