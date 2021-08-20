using System;
using UnityEngine;

/// <summary>
/// 序列化图集数据
/// </summary>
[System.Serializable]
public class MySpriteData 
{
    public string name = "Sprite";

    public int x = 0;
    public int y = 0;
    public int width = 0;
    public int height = 0;
    //左边
    public int borderLeft = 0;
    //右边
    public int borderRight = 0;
    //上边
    public int borderTop = 0;
    //下边
    public int borderBottom = 0;

    //上下左右间隔像素
    public int paddingLeft = 0;
    public int paddingRight = 0;
    public int paddingTop = 0;
    public int paddingBottom = 0;
    /// <summary>
    /// 是否支持旋转
    /// </summary>
    public bool rotated = false;

    //转UV坐标
    static public Rect ConvertToTexCoords(Rect rect, int width, int height)
    {
        Rect final = rect;

        if (width != 0f && height != 0f)
        {
            final.xMin = rect.xMin / width;
            final.xMax = rect.xMax / width;
            final.yMin = 1f - rect.yMax / height;
            final.yMax = 1f - rect.yMin / height;
        }
        return final;
    }
}
