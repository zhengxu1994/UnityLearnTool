using System.Collections.Generic;
using UnityEngine;

public class Polygon
{
    NodeList m_NodeList;
    List<int> m_Triangles = new List<int>();

    public Polygon(List<Vector3> vertices)
    {
        if (vertices.Count <= 2)
        {
            throw new System.InvalidOperationException("非多边形");
        }
        m_NodeList = new NodeList(vertices);
    }

    public int[] SimpleTriangulation()
    {
        SimpleCutPolygon();
        return m_Triangles.ToArray();
    }

    public int[] Triangulation()
    {
        while (m_NodeList.GetCount >= 3)
        {
            if (!CutPolygon())
            {
                throw new System.InvalidOperationException("点位非逆时针排布或围成图形非简单多边形");
            }
        }
        return m_Triangles.ToArray();
    }

    private void SimpleCutPolygon()
    {
        int nodeListCount = m_NodeList.GetCount;
        for (int i = 0; i < nodeListCount - 1; i++)
        {
            Node currentNode = m_NodeList.GetNodeByIdx(i);
            Node nextNode = currentNode.NextNode;
            Node oppositeNode = m_NodeList.GetNodeByIdx(nodeListCount - 1 - i);
            if (i < nodeListCount / 2 - 1 || i > nodeListCount / 2 - 1)
            {
                m_Triangles.Add(oppositeNode.Index);
                m_Triangles.Add(nextNode.Index);
                m_Triangles.Add(currentNode.Index);
            }
        }
    }

    private bool CutPolygon()
    {
        //凸顶点
        List<Node> raisedVertices = new List<Node>();
        //凹顶点
        List<Node> concaveVertices = new List<Node>();
        //耳尖
        List<Node> earTips = new List<Node>();

        for (int i = 0; i < m_NodeList.GetCount; i++)
        {
            Node currentNode = m_NodeList.GetNodeByIdx(i);
            Node previousNode = currentNode.PreviousNode;
            Node nextNode = currentNode.NextNode;

            if (IsRaisedVertex(previousNode, currentNode, nextNode))
            {
                raisedVertices.Add(currentNode);
                if (IsEarTip(previousNode, currentNode, nextNode))
                {
                    earTips.Add(currentNode);
                }
            }
            else
            {
                concaveVertices.Add(currentNode);
            }
        }

        //至少要有一个耳尖
        if (earTips.Count == 0)
        {
            return false;
        }

        m_Triangles.Add(earTips[0].PreviousNode.Index);

        m_Triangles.Add(earTips[0].NextNode.Index);
        m_Triangles.Add(earTips[0].Index);
        m_NodeList.RemoveNode(earTips[0]);

        return true;
    }

    private bool IsRaisedVertex(Node previousNode, Node currentNode, Node nextNode)
    {
        Vector3 side1 = currentNode.Position - previousNode.Position;
        Vector3 side2 = nextNode.Position - currentNode.Position;
        Vector3 crossRes = Vector3.Cross(side1, side2);

        if (crossRes.y > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool IsEarTip(Node previousNode, Node currentNode, Node nextNode)
    {
        bool flag = true;
        for (int i = 0; i < m_NodeList.GetCount; i++)
        {
            Node node = m_NodeList.GetNodeByIdx(i);
            if (node != currentNode && node != previousNode && node != nextNode)
            {
                if (InTrigon(node.Position, previousNode.Position, currentNode.Position, nextNode.Position))
                {
                    flag = false;
                    break;
                }
            }
        }
        return flag;
    }

    private bool InTrigon(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 pa = a - p;
        Vector3 pb = b - p;
        Vector3 pc = c - p;

        Vector3 pab = Vector3.Cross(pa, pb);
        Vector3 pbc = Vector3.Cross(pb, pc);
        Vector3 pca = Vector3.Cross(pc, pa);

        float d1 = Vector3.Dot(pab, pbc);
        float d2 = Vector3.Dot(pab, pca);
        float d3 = Vector3.Dot(pbc, pca);

        bool result = Mathf.Sign(d1) == Mathf.Sign(d2) && Mathf.Sign(d2) == Mathf.Sign(d3) && Mathf.Sign(d1) == Mathf.Sign(d3);

        return result;
    }

    private class Node
    {

        public int Index { get; set; }
        public Vector3 Position { get; set; }
        public Node PreviousNode { get; set; }
        public Node NextNode { get; set; }

        public Node(int idx, Vector3 position)
        {
            Index = idx;
            Position = position;
        }
    }

    private class NodeList
    {

        List<Node> list = new List<Node>();

        public NodeList(List<Vector3> vertices)
        {
            int verticesCount = vertices.Count;

            for (int i = 0; i < verticesCount; i++)
            {
                Node node = new Node(i, vertices[i]);
                list.Add(node);
            }

            for (int i = 0; i < verticesCount; i++)
            {
                int previousIdx;
                int nextIdx;
                if (i == 0)
                {
                    previousIdx = verticesCount - 1;
                    nextIdx = i + 1;
                }
                else if (i == verticesCount - 1)
                {
                    previousIdx = i - 1;
                    nextIdx = 0;
                }
                else
                {
                    previousIdx = i - 1;
                    nextIdx = i + 1;
                }
                list[i].PreviousNode = list[previousIdx];
                list[i].NextNode = list[nextIdx];
            }
        }

        public int GetCount
        {
            get { return list.Count; }
        }

        public Node GetNodeByIdx(int idx)
        {
            return list[idx];
        }

        public void RemoveNode(Node node)
        {
            node.NextNode.PreviousNode = node.PreviousNode;
            node.PreviousNode.NextNode = node.NextNode;
            list.Remove(node);
        }
    }
}