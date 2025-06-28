
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmment1.Question3
{

    public class SinglyLinkedList<E>
    {
        private class Node<T>
        {
            public T Element { get; set; }
            public Node<T> Next { get; set; }

            public Node(T element, Node<T> next = null)
            {
                Element = element;
                Next = next;
            }
        }

        private Node<E> head;
        private Node<E> tail;
        private int size;

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void AddFirst(E element)
        {
            head = new Node<E>(element, head);
            if (size == 0)
            {
                tail = head;
            }
            size++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty");
            E removedElement = head.Element;
            head = head.Next;
            size--;
            if (size == 0)
            {
                tail = null;
            }
            return removedElement;
        }

        public void AddLast(E element)
        {
            Node<E> newest = new Node<E>(element);
            if (IsEmpty())
            {
                head = newest;
            }
            else
            {
                tail.Next = newest;
            }
            tail = newest;
            size++;
        }

        public E First()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty");
            return head.Element;
        }

        public E Last()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty");
            return tail.Element;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty() => size == 0;

        public override string ToString()
        {
            var sb = new StringBuilder();
            Node<E> current = head;
            while (current != null)
            {
                sb.AppendLine(current.Element.ToString());
                current = current.Next;
            }
            return sb.ToString();
        }
    }
}

