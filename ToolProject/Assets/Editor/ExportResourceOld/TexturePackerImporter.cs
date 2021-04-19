using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class V4
{
    public int x;
    public int y;
    public int w;
    public int h;

    public V4()
    {

    }
}

[System.Serializable]
public class V2
{
    public int w;
    public int h;
    public V2()
    {

    }
}

[System.Serializable]
public class Frame
{
    public string filename;
    public V4 frame;
    public bool rotated;
    public bool trimmed;
    public V4 spriteSourceSize;
    public V2 sourceSize;
    public Frame() { }
}

[System.Serializable]
public class Meta
{
    public string image;
    public V2 size;
}

[System.Serializable]
public class Frames
{
    public List<Frame> frames = new List<Frame>();
    public Meta meta;
    public Frames() { }
}

public class TexturePackerImporter
{
    public Frames frames = null;
    public Texture2D texFile = null;

    [MenuItem("Tool/分割选中图集透明通道")]
    static void SplitSelectPngAlpha()
    {
        if (Selection.activeObject == null)
            return;
        Texture2D t = Selection.activeObject as Texture2D;
        if (t == null)
        {
            EditorUtility.DisplayDialog("错误", "只能分割png文件", "ok");
            return;
        }
        var colors = t.GetPixels(0, 0, t.width, t.height);
        var tex = new Texture2D(t.width, t.height);
        Color[] rgbs = new Color[colors.Length];
        Color[] alphas = new Color[colors.Length];
        Color temp ;
        for (int i = 0; i < colors.Length; i++)
        {
            temp = colors[i];
            rgbs[i] = new Color(temp.r, temp.g, temp.b);
            alphas[i] = new Color(0, 0, 0, temp.a);
        }
        tex.SetPixels(0, 0, t.width, t.height, rgbs);
        tex.Apply();
        byte[] btr = tex.EncodeToPNG();
        string name = t.name.Split('.')[0];
        File.WriteAllBytes(Application.dataPath + "/SpriteSheet/" + name + ".png", btr);
        var texa = new Texture2D(t.width, t.height);
        texa.SetPixels(0, 0, t.width, t.height, alphas);
        texa.Apply();
        byte[] btra = texa.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/SpriteSheet/" + name + "!a.png", btra);
    }

    [MenuItem("Tool/拆分选中图集")]
    static void SplitSelectPng()
    {
        if (Selection.activeObject == null)
            return;
        Texture2D t = Selection.activeObject as Texture2D;
        if(t== null)
        {
            EditorUtility.DisplayDialog("错误", "只能转换png文件！", "ok");
            return;
        }
        TexturePackerImporter tpie = new TexturePackerImporter();
        tpie.texFile = t;

        string path = AssetDatabase.GetAssetPath(tpie.texFile);
        var jsonFile = AssetDatabase.LoadAssetAtPath(Path.ChangeExtension(path, "json"), typeof(TextAsset)) as TextAsset;
        if(jsonFile == null)
        {
            EditorUtility.DisplayDialog("提示", "josn 文件必须放在png文件同目录下", "ok");
            return;
        }

        tpie.frames = JsonUtility.FromJson<Frames>(jsonFile.text);
        tpie.ImportTexture();
    }

    public void ImportTexture()
    {
        string _texPath = AssetDatabase.GetAssetPath(texFile);
        TextureImporter ti = TextureImporter.GetAtPath(_texPath) as TextureImporter;

        List<SpriteMetaData> sps = new List<SpriteMetaData>();
        foreach (var f in frames.frames)
        {
            SpriteMetaData md = new SpriteMetaData();
            int fx = f.frame.x;
            int fy = frames.meta.size.h - f.frame.h - f.frame.y;

            md.alignment = 9;
            md.rect = new Rect(fx, fy, f.frame.w, f.frame.h);
            //因为每帧的图片大小是不一样的 ，所以要计算每张对应frame大小的中心点 进行一一对应
            md.pivot = new Vector2((f.sourceSize.w / 2.0f - f.spriteSourceSize.x) / f.frame.w, 1 - (f.sourceSize.h / 2.0f - f.spriteSourceSize.y) / f.frame.h);
            md.name = Path.ChangeExtension(f.filename, null);

            sps.Add(md);
        }

        ti.textureType = TextureImporterType.Sprite;
        ti.spriteImportMode = SpriteImportMode.Multiple;
        ti.spritePixelsPerUnit = 1.0f;
        ti.spritesheet = sps.ToArray();

        AssetDatabase.ImportAsset(_texPath, ImportAssetOptions.ForceUncompressedImport);
    }

    public class TexturePackerAssetModifica :UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreatAsset(string path)
        {
            path = path.Replace(".meta", "");
            if (path.EndsWith(".json",System.StringComparison.Ordinal))
            {
                if (path.IndexOf("Assets/SpriteSheet") >= 0)
                {

                }
            }
        }
    }
}

