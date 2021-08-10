using System;
namespace CSDemo
{
    public class Node<T> where T : IComparable<T>
    {
        public T t;
        public Node<T> left, right;

        public Node(T t)
        {
            this.t = t;
            left = right = null;
        }
    }

    public class SimpleBinaryTree<T> where T :IComparable<T>
    {
        private Node<T> root;

        private int N;

        public SimpleBinaryTree()
        {
            root = null;
            N = 0;
        }

        public int Count { get { return N; } }

        public bool IsEmpty
        {
            get {
                return N == 0;
            }
        }

        public void Add(T t)
        {
            root = Add(root, t);
        }

        private Node<T> Add(Node<T> node, T t)
        {
            if(node == null)
            {
                N++;
                return new Node<T>(t);
            }
            if (t.CompareTo(node.t) < 0)
                //左子树
                node.left = Add(node.left, t);
            else if (t.CompareTo(node.t) > 0)
                //右子树
                node.right = Add(node.right, t);
            return node;
        }

        public bool Contain(T t)
        {
            return Contain(root, t);
        }

        private bool Contain(Node<T> node,T t)
        {
            if (node == null)
                return false;
            if (t.CompareTo(node.t) < 0)
                return Contain(node.left, t);
            else if (t.CompareTo(node.t) > 0)
                return Contain(node.right, t);
            else
                return true;
        }

        /// <summary>
        /// 前序排列  根左右
        /// </summary>
        public void PreOrder()
        {

        }
    }
}
