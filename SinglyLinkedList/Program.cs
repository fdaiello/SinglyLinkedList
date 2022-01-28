using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode? next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode? head;
        public SinglyLinkedListNode? tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode? node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }


    /*
        * Complete the 'reverse' function below.
        *
        * The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
        * The function accepts INTEGER_SINGLY_LINKED_LIST llist as parameter.
        */

    /*
        * For your reference:
        *
        * SinglyLinkedListNode
        * {
        *     int data;
        *     SinglyLinkedListNode next;
        * }
        *
        */

    static SinglyLinkedListNode reverse0(SinglyLinkedListNode llist)
    {
        List<int> list = new List<int>();

        SinglyLinkedListNode? node = llist;
        while (node != null)
        {
            list.Add(node.data);
            node = node.next;
        }

        list.Reverse();

        node = llist;
        int i = 0;
        while (node != null)
        {
            node.data = list[i];
            node = node.next;
            i++;
        }

        return llist;
    }

    static SinglyLinkedListNode reverse(SinglyLinkedListNode llist)
    {

        // New Head node
        SinglyLinkedListNode? nHead = null;

        // Run the Linked List
        SinglyLinkedListNode? node = llist;
        while (node != null)
        {
            // Create new node
            SinglyLinkedListNode nNode = new SinglyLinkedListNode(node.data);
            nNode.next = nHead;

            // new Head points to just created node
            nHead = nNode;

            // next node
            node = node.next;
        }

        // Return new Head
        return nHead;
    }


    static void Main(string[] args)
    {
        string fileName = Directory.GetCurrentDirectory() + "output.txt";
        TextWriter textWriter = new StreamWriter(fileName, true);

        int tests = Convert.ToInt32(Console.ReadLine());

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            SinglyLinkedListNode llist1 = reverse(llist.head);

            PrintSinglyLinkedList(llist1, " ", textWriter);
            textWriter.WriteLine();
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
