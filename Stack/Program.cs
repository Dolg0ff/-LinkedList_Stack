using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinckedList<T> : IEnumerable<T>
    {
        public Node<T> head;
        public int count;

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);
            if(head != null)
            {
                node.Next = head;
                head = node;
                count++;
            }
            else
            {
                head = node;
                count++;
            }
        }

        public bool Pop()
        {
            if(head != null)
            {
                if(head.Next != null)
                {
                    head = head.Next;
                    count--;
                }
                else
                {
                    head = null;
                    count--;
                }
                return true;
            }
            return false;
        }

        public T Peek()
        {
            if(head != null)
            {
                return head.Data;
            }
            else
            {
                throw new InvalidOperationException(); 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinckedList<string> linckedList = new LinckedList<string>();
            linckedList.Push("Apple");
            linckedList.Push("Samsung");
            linckedList.Push("Nokia");
            linckedList.Push("LG");
            linckedList.Pop();
            linckedList.Pop();
            var peek = linckedList.Peek();

            foreach (string node in linckedList)
            {
                Console.WriteLine(node); 
            }

            Console.WriteLine($"Вершина стека: {peek}");
            Console.ReadLine();
        }
    }
}
