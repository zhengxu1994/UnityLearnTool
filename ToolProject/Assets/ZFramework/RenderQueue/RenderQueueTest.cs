using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderQueueTest : MonoBehaviour
{

    //我的思路是 不考虑camera depth，sortinglayer（都设置为under 特殊的需要与人物有穿插的除外），(根据层级设置orderinlayer)
    //，不考虑设置距离相机的远近来排序，因为项目里使用的透视相机。
    //最终遇到的问题是 当sortinglayer 一样的图贴的很近时就需要下面的看上去在上，所以需要有什么条件去设置前后，所以我考虑使用shader
    //中的renderqueue来设置前后，
    //renderqueue的知识点：
    // queue <= 2500 和 renderqueue>2500是两个区域，也就说 大于2500的对象 必然显示在<=2500的对象前面，此时它们的order等因素是
    //不起作用的，<=2500的对象 unity默认为需要开启透明度检测的物体
    //解决方案： 当sortingOrder orderinlayer 设置完毕后  通过设置shader tag renderqueue来控制渲染顺序
    // Start is called before the first frame update
    public SpriteRenderer[] sprite;
    public int[] renderQueue;
    public const int startIndex = 3000;
    void Start()
    {
        
    }

    public void SetSpriteRenderQueue(int index)
    {
        var sp = sprite[index];
        var quq = renderQueue[index];
        //sp.material.set = startIndex + quq;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < renderQueue.Length; i++)
            {
                SetSpriteRenderQueue(i);
            }
        }
    }
}


