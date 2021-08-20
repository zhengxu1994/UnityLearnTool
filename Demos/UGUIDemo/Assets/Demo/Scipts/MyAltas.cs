using System;
using System.Collections.Generic;
using UnityEngine;

public class MyAltas : MonoBehaviour
{
    [SerializeField]
    public Material spriteMaterial;
    [SerializeField]
    private List<MySpriteData> m_sprites = new List<MySpriteData>();
    [System.NonSerialized]
    private Dictionary<string, MySpriteData> m_spritesDict = new Dictionary<string, MySpriteData>();
    [System.NonSerialized]
    private bool m_inited = false;

    public List<MySpriteData> spriteList
    {
        get
        {
            return m_sprites;
        }
        set
        {
            m_sprites = value;
        }
    }

    public MySpriteData GetSpriteDataByName(string name)
    {
        MySpriteData result = null;

        if (!m_inited)
        {
            SlotDictData();
        }
        m_spritesDict.TryGetValue(name, out result);
        return result;
    }

    public void SlotDictData()
    {
        if (m_inited) return;

        for (int i = 0, imax = m_sprites.Count; i < imax; i++)
        {
            MySpriteData data = m_sprites[i];
            m_spritesDict[data.name] = data;
        }

        m_inited = true;
    }
}
