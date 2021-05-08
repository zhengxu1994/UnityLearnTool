using System;
using System.Collections.Generic;
using UnityEngine;
public class DrawMesh : MonoBehaviour
{
    public List<Transform> points;
    public Material mat;
    Mesh mesh;
    private void Start()
    {
        GameObject obj = new GameObject();
        var render = obj.AddComponent<MeshRenderer>();
        var filter = obj.AddComponent<MeshFilter>();

        mesh = new Mesh();
        var list = new List<Vector3>();
        var list2D = new List<Vector2>();
        for (int i = 0; i < points.Count; i++)
        {
            list.Add(points[i].position);
            list2D.Add(points[i].position);
        }
        //Polygon pl = new Polygon(list);
        //var triangles = pl.Triangulation();
        var triangles = CutPolygon.Triangulate(list2D);
        var newTrianlges = new int[triangles.Length];
        int count = 0;
        for (int i = triangles.Length -1; i >= 0 ; i--)
        {
            newTrianlges[count] = triangles[i];
            count++;
        }
        mesh.vertices = list.ToArray();
        mesh.triangles = triangles;

        filter.mesh = mesh;
        render.material = mat;

    }

    private void Update()
    {
        var list = new List<Vector3>();
        for (int i = 0; i < points.Count; i++)
        {
            list.Add(points[i].position);
        }
        Polygon pl = new Polygon(list);
        var triangles = pl.Triangulation();
        mesh.vertices = list.ToArray();
        mesh.triangles = triangles;
    }
}
