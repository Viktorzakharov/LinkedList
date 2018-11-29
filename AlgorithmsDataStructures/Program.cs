using System;

namespace AlgorithmsDataStructures
{
    public class Program
    {
        public static void Main()
        {
            var list = GenerateLinkedListElements(new LinkedList(), 7);

            var node = list.head;
            while (node != null)
            {
                Console.Write("{0} ", node.value);
                node = node.next;
            }
            Console.WriteLine();
        }

        public static LinkedList GenerateLinkedListElements(LinkedList list, int count)
        {
            var n = new Random();
            while (count > 0)
            {
                list.AddInTail(new Node(n.Next(255)));
                count--;
            }
            return list;
        }
    }
}
