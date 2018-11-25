using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;
        public int length;

        public LinkedList()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public void AddInTail(Node _item)
        {
            _item.next = null;
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
            length++;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value) //Метод поиска всех узлов по конкретному значению 
        {
            List<Node> nodes = new List<Node>();
            var node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value) //Метод удаления одного узла по его значению
        {
            if (head.value == _value)
            {
                if (head.next == null) tail = null;
                head = head.next;
                return true;
            }
            var node = head;
            while (node != null)
            {
                if (node.next.value == _value)
                {
                    if (node.next.Equals(tail)) tail = node;
                    node.next = node.next.next;
                    length--;
                    return true;
                }
                if (node.next.Equals(tail)) return false;
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value) //Метод удаления всех узлов по конкретному значению
        {
            while (head.value == _value)
            {
                if (head.next == null) tail = null;
                head = head.next;
                length--;
            }
            var node = head;
            while (node != null)
            {
                if (node.next.value == _value)
                {
                    if (node.next.Equals(tail))
                    {
                        node.next = null;
                        tail = node;
                        node = null;
                    }
                    else node.next = node.next.next;
                    length--;
                }
                else if (node.next.Equals(tail)) node = null;
                else node = node.next;
            }
        }

        public void Clear() //Метод очистки всего содержимого (создание пустого списка)
        {
            head = null;
            tail = null;
            length = 0;
        }

        public int Count()
        {
            return length;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert) //Метод вставки узла после заданного узла
        {
            if (_nodeAfter is null && head is null)
            {
                _nodeToInsert.next = null;
                head = _nodeToInsert;
                tail = head;
                length++;
            }
            else if (IsNodeInList(_nodeAfter))
            {
                if (_nodeAfter.Equals(tail)) tail = _nodeToInsert;
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                length++;
            }
        }

        public static LinkedList SumTwoListsElements(LinkedList firstList, LinkedList secondList) //Метод сложения значений двух списков
        {
            if (firstList.length != secondList.length) return new LinkedList();
            var node1 = firstList.head;
            var node2 = secondList.head;
            var resultList = new LinkedList();

            while (node1 != null)
            {
                resultList.AddInTail(new Node(node1.value + node2.value));
                node1 = node1.next;
                node2 = node2.next;
            }
            return resultList;
        }

        public bool IsNodeInList(Node checkNode)
        {
            var node = head;
            while (node != null)
            {
                if (checkNode.Equals(node)) return true;
                node = node.next;
            }
            return false;
        }
    }

}
