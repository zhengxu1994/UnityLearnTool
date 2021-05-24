using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DrawMesh : MonoBehaviour
{
    public Transform[] pos;

    private void Start()
    {
        GameObject obj = new GameObject();
        var render = obj.AddComponent<MeshRenderer>();
        var filter = obj.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] postion = new Vector3[pos.Length];
        List<Vector2> position2d = new List<Vector2>();
        for (int i = 0; i < pos.Length; i++)
        {
            postion[i] = pos[i].position;
            position2d.Add(pos[i].position);
        }
        var list = CutPolygon.Triangulate(position2d);
        mesh.vertices = postion;
        mesh.triangles = list;
        filter.mesh = mesh;
        AssetDatabase.CreateAsset(mesh, "Assets/" + name + ".asset");
    }

}
