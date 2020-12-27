using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stos
{
    public class StosWLiscie<T> : IStos<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;

            public Node (T value, Node next)
            {
                Data = value;
                Next = next;
            }
        }
        
        Node top;

        public StosWLiscie()
        {
            this.top = null;
        }

        public void Push(T value)
        {
            top = new Node(value, top);
        }
        public void Pop()
        {
            if(IsEmpty)
            {
                throw new StosEmptyException();
            }

            top = (top).Next;
        }

        public bool IsEmpty => top == null;

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new StosEmptyException();
            }
            return top.Data;
        }

        public void Show()
        {
            if (IsEmpty)
            {
                throw new StosEmptyException();
            }
            else
            {
                Node temp = top;
                while(temp!= null)
                {
                    Console.WriteLine(temp.Data);
                    temp = temp.Next;
                }
            }
        }

        public int Count => throw new NotImplementedException();

        public void Clear()
        {
            top = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node temp = top;
            while(temp!= null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public T[] ToArray()
        {
            Node temp = top;
            T[] arr = null;

            int i = 0;
            while (!IsEmpty)
            {
                arr[i] = temp.Data;
            }

            return arr;
        }

        T IStos<T>.Pop()
        {
            throw new NotImplementedException();
        }
        T IStos<T>.Peek => throw new NotImplementedException();

        T IStos<T>.this[int index] => throw new NotImplementedException();
    }
}
