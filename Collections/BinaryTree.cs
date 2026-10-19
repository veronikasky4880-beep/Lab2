using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2.Collections
{
    // Вузол дерева
    public class Node<T>
    {
        public T Data;
        public Node<T> Left;
        public Node<T> Right;
        public Node(T data) { Data = data; }
    }

    // Узагальнене бінарне дерево
    public class BinaryTree<T> : IEnumerable<T> where T : class, IComparable<T>
    {
        public Node<T> Root;

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                return;
            }

            Node<T> curr = Root;
            while (true)
            {
                if (data.CompareTo(curr.Data) < 0)
                {
                    if (curr.Left == null) { curr.Left = new Node<T>(data); break; }
                    curr = curr.Left;
                }
                else
                {
                    if (curr.Right == null) { curr.Right = new Node<T>(data); break; }
                    curr = curr.Right;
                }
            }
        }

        public IEnumerator<T> GetEnumerator() => new PreorderEnumerator(Root);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Ітератор (Preorder)
        class PreorderEnumerator : IEnumerator<T>
        {
            private Node<T> _root;
            private Stack<Node<T>> _stack;
            public T Current { get; private set; }
            object IEnumerator.Current => Current;

            public PreorderEnumerator(Node<T> root)
            {
                _root = root;
                _stack = new Stack<Node<T>>();
                Reset();
            }

            public bool MoveNext()
            {
                if (_stack.Count == 0) return false;

                Node<T> node = _stack.Pop();
                Current = node.Data;

                if (node.Right != null) _stack.Push(node.Right);
                if (node.Left != null) _stack.Push(node.Left);

                return true;
            }

            public void Reset()
            {
                _stack.Clear();
                if (_root != null) _stack.Push(_root);
                Current = null;
            }
            public void Dispose() { }
        }
    }
}
