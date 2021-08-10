using System;
namespace DataStructure
{
    public class Node<T>
    {
        public T data;
        public Node<T> child;
        public Node<T> rSibling;

        public Node(T data)
        {
            this.data = data;
        }
    }
    public class Tree<T>
    {

        private Node<T> root = null;

        public Node<T> CreateRoot(T data)
        {
            if (root == null)
                root = new Node<T>(data);
            return root;
        }

        public Node<T> AddChild(Node<T> current,T data)
        {
            if (current == null) return null;
            Node<T> child = new Node<T>(data);
            current.child = child;
            return child;
        }

        public Node<T> AddSibling(Node<T> current,T data)
        {
            if (current == null) return null;
            Node<T> sibling = new Node<T>(data);
            current.rSibling = sibling;
            return sibling;
        }

        private void _TraverseByLevel(Node<T> current)
        {
            if (current == null) return;
            Console.WriteLine(current.data);
            _TraverseByLevel(current.rSibling);
            _TraverseByLevel(current.child);
        }

        /// <summary>
        /// 广度遍历
        /// </summary>
        public void TraverseByLevel()
        {
            _TraverseByLevel(root);
        }

        private void _TraverseByDepth(Node<T> current)
        {
            if (current == null) return;
            Console.WriteLine(current.data);
            _TraverseByDepth(current.child);
            _TraverseByDepth(current.rSibling);
        }

        /// <summary>
        /// 广度遍历
        /// </summary>
        public void TraverseByDepth()
        {
            _TraverseByDepth(root);
        }
    }
}
