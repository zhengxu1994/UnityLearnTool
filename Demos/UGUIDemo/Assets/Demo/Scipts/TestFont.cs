using UnityEngine;
using System.Collections.Generic;
using System;

public class TestFont : MonoBehaviour
{
    public Font font;
    public string str = "Hello World";
    public int fontSize = 40;
    public float outWidth = 5;
    public Color fontColor = Color.white;
    public Color outColor = Color.black;
    Mesh mesh;
    public MyAltas atlas;
    void OnFontTextureRebuilt(Font changedFont)
    {
        if (changedFont != font)
            return;

        RebuildMesh();
    }

    void OnValidate()
    {
        if (!Application.isPlaying) return;
        RebuildMesh();
    }

    void RebuildMesh()
    {
        if (mesh == null) return;

        font.RequestCharactersInTexture(str, fontSize);
        mesh.Clear();
        // Generate a mesh for the characters we want to print.
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        List<Color> color = new List<Color>();
        List<Vector3> picVertices = new List<Vector3>();
        List<Vector2> picUv = new List<Vector2>();
        List<int> picTriangles = new List<int>();
        //这里是描边
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(outWidth, 0, 0), 0);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(-outWidth, 0, 0), 1);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(0, outWidth, 0), 2);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(0, -outWidth, 0), 3);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(outWidth, outWidth, 0), 4);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(outWidth, -outWidth, 0), 5);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(-outWidth, outWidth, 0), 6);
        //DrawText(vertices, triangles, uv, color, outColor, new Vector3(-outWidth, -outWidth, 0), 7);

        //这里是真正的字
        //DrawText(vertices, triangles, uv, color, fontColor, Vector3.zero, 8);
        DrawText(vertices, triangles, uv, color, fontColor, picVertices, picUv, picTriangles); ;
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        mesh.colors = color.ToArray();
    }

    void DrawText(List<Vector3> vertices, List<int> triangles, List<Vector2> uv, List<Color> colorList, Color color, Vector3 offset, int index)
    {

        Vector3 pos = Vector3.zero - offset;
        font.RequestCharactersInTexture(str, fontSize);
        for (int i = 0; i < str.Length; i++)
        {
            // Get character rendering information from the font
            CharacterInfo ch;
            font.GetCharacterInfo(str[i], out ch, fontSize);

            vertices.Add(pos + new Vector3(ch.minX, ch.maxY, 0));
            vertices.Add(pos + new Vector3(ch.maxX, ch.maxY, 0));
            vertices.Add(pos + new Vector3(ch.maxX, ch.minY, 0));
            vertices.Add(pos + new Vector3(ch.minX, ch.minY, 0));

            colorList.Add(color);
            colorList.Add(color);
            colorList.Add(color);
            colorList.Add(color);

            uv.Add(ch.uvTopLeft);
            uv.Add(ch.uvTopRight);
            uv.Add(ch.uvBottomRight);
            uv.Add(ch.uvBottomLeft);

            triangles.Add(4 * (i + index * str.Length) + 0);
            triangles.Add(4 * (i + index * str.Length) + 1);
            triangles.Add(4 * (i + index * str.Length) + 2);

            triangles.Add(4 * (i + index * str.Length) + 0);
            triangles.Add(4 * (i + index * str.Length) + 2);
            triangles.Add(4 * (i + index * str.Length) + 3);

            // Advance character position
            pos += new Vector3(ch.advance, 0, 0);
        }
    }

    void Start()
    {
        //font = Font.CreateDynamicFontFromOSFont("Helvetica", 16);
        // Set the rebuild callback so that the mesh is regenerated on font changes.
        Font.textureRebuilt += OnFontTextureRebuilt;

        // Set up mesh.
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = font.material;

        // Generate font mesh.
        RebuildMesh();
    }

    void DrawText(List<Vector3> fontVertices, List<int> fontTriangles, List<Vector2> fontUV, List<Color> fontColorList, Color fontColor,
    List<Vector3> picVertices, List<Vector2> picUV, List<int> picTriangles)
    {

        Vector3 pos = Vector3.zero;
        int index = 0;
        int picIndex = 0;
        for (int i = 0; i < str.Length;)
        {
            char c = str[i];
            if (c == '#'
                && Char.IsNumber(str[i + 1])
                && Char.IsNumber(str[i + 2])
                && Char.IsNumber(str[i + 3])
                )
            {
                string name = str.Substring(i + 1, 3);
                if (atlas != null)
                {
                    MySpriteData spriteInfo = atlas.GetSpriteDataByName(name);
                    Rect outer = new Rect(spriteInfo.x, spriteInfo.y, spriteInfo.width, spriteInfo.height);
                    Texture tex = atlas.spriteMaterial.mainTexture;
                    Rect outerUV = MySpriteData.ConvertToTexCoords(outer, tex.width, tex.height);

                    picVertices.Add(pos + new Vector3(0, spriteInfo.height, 0));
                    picVertices.Add(pos + new Vector3(spriteInfo.width, spriteInfo.height, 0));
                    picVertices.Add(pos + new Vector3(spriteInfo.width, 0, 0));
                    picVertices.Add(pos + new Vector3(0, 0, 0));

                    picUV.Add(new Vector2(outerUV.xMin, outerUV.yMax));
                    picUV.Add(new Vector2(outerUV.xMax, outerUV.yMax));
                    picUV.Add(new Vector2(outerUV.xMax, outerUV.yMin));// ch.uvBottomRight);
                    picUV.Add(new Vector2(outerUV.xMin, outerUV.yMin));//ch.uvBottomLeft);

                    picTriangles.Add(4 * picIndex + 0);
                    picTriangles.Add(4 * picIndex + 1);
                    picTriangles.Add(4 * picIndex + 2);
                    picTriangles.Add(4 * picIndex + 0);
                    picTriangles.Add(4 * picIndex + 2);
                    picTriangles.Add(4 * picIndex + 3);

                    // Advance character position
                    pos += new Vector3(spriteInfo.width, 0, 0);
                }

                i = i + 4;
                picIndex++;
            }
            else
            {
                // Get character rendering information from the font
                CharacterInfo ch;
                font.GetCharacterInfo(c, out ch, fontSize);

                fontVertices.Add(pos + new Vector3(ch.minX, ch.maxY, 0));
                fontVertices.Add(pos + new Vector3(ch.maxX, ch.maxY, 0));
                fontVertices.Add(pos + new Vector3(ch.maxX, ch.minY, 0));
                fontVertices.Add(pos + new Vector3(ch.minX, ch.minY, 0));

                fontUV.Add(ch.uvTopLeft);
                fontUV.Add(ch.uvTopRight);
                fontUV.Add(ch.uvBottomRight);
                fontUV.Add(ch.uvBottomLeft);

                fontColorList.Add(fontColor);
                fontColorList.Add(fontColor);
                fontColorList.Add(fontColor);
                fontColorList.Add(fontColor);

                fontTriangles.Add(4 * index + 0);
                fontTriangles.Add(4 * index + 1);
                fontTriangles.Add(4 * index + 2);
                fontTriangles.Add(4 * index + 0);
                fontTriangles.Add(4 * index + 2);
                fontTriangles.Add(4 * index + 3);

                // Advance character position
                pos += new Vector3(ch.advance, 0, 0);
                index++;
                i++;
            }

        }
    }


    void OnDestroy()
    {
        Font.textureRebuilt -= OnFontTextureRebuilt;
    }
}