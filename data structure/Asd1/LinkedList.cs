using System;

namespace Asd1
{
    public class LinkedList
    {
        public Node head;
        public Node current;
        public int count;

        public LinkedList()
        {
            head = new Node();
            current = head;
        }
        public void AddLast(int val)
        {
            Node newNode = new Node();
            newNode.value = val;
            current.next = newNode;
            current = newNode;
            count++;
        }
        public static Node RemoveLast(Node head)
        {
            if (head == null)
                return null;

            if (head.next == null)
            {
                return null;
            }

            Node second_last = head;
            while (second_last.next.next != null)
                second_last = second_last.next;

            second_last.next = null;

            return head;
        }
        public void OutputList()
        {
            Console.Write("list:    ");
            Node curr = head;
            while (curr.next != null)
            {
                curr = curr.next;
                Console.Write(curr.value + "\t");
            }
            Console.WriteLine();
        }
        public static LinkedList Sort(int[] array)
        {
            int[] arrSorted = array;
            Array.Sort(arrSorted);
            LinkedList listSorted = new LinkedList();
            listSorted.GetList(listSorted, arrSorted);
            return listSorted;
        }
        public void GetList(LinkedList list, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                list.AddLast(array[i]);
            }
        }
        public int ListLength(LinkedList list)
        {
            int size = 0;
            var iterator = list.head;
            while (iterator.next != null)
            { 
                size++;
                iterator = iterator.next;
            }
            return size;
        }
    }
    public class Node
    {
        public Node next;
        public int value;
    }
}
