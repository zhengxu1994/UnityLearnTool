using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 显示一张图集的部分或者全部信息
/// </summary>
public class Demo1 : MonoBehaviour
{
    public int width = 512;
    public int height = 512;
    public Color color = Color.black;

    public Vector2 uv1 = new Vector2(0, 0);
    public Vector2 uv2 = new Vector2(0, 1);
    public Vector2 uv3 = new Vector2(1, 0);
    public Vector2 uv4 = new Vector2(1, 1);
    private MeshRenderer renderer;
    private MeshFilter filter;
    // Start is called before the first frame update
    void Start()
    {
        Shader s = Shader.Find("Unlit/ShaderDemo1");
        Material spMat = new Material(s);

        GameObject go = new GameObject("Demo1");
        renderer = go.AddComponent<MeshRenderer>();
        filter = go.AddComponent<MeshFilter>();

        renderer.sharedMaterial = spMat;
        Fill();
    }

    public void Fill()
    {
        Mesh mesh = new Mesh();
        filter.mesh = mesh;
        //设置顶点
        Vector3[] vertices = new Vector3[4];
        //设置点顺序
        int[] triangles = new int[6];
        //设置颜色
        Color[] colors = new Color[4];
        //设置uv坐标
        Vector2[] uvs = new Vector2[4];

        float glWidth = (float)width / 2;
        float glHeight = (float)height / 2;

        //以当前对象中心点为标准 四个顶点 构成2个三角面
        vertices[0] = new Vector3(-glWidth, -glHeight, 0);
        vertices[1] = new Vector3(-glWidth, glHeight, 0);
        vertices[2] = new Vector3(glWidth, -glHeight, 0);
        vertices[3] = new Vector3(glWidth, glHeight, 0);

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 1;

        //设置顶点颜色
        colors[0] = color;
        colors[1] = color;
        colors[2] = color;
        colors[3] = color;

        //绑定uv坐标
        uvs[0] = uv1;
        uvs[1] = uv2;
        uvs[2] = uv3;
        uvs[3] = uv4;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.uv = uvs;
    }

    /// <summary>
    /// 监视面板值发现改变时调用
    /// </summary>
    private void OnValidate()
    {
        if (filter && Application.isPlaying)
        {
            Fill();
        }
    }
}
