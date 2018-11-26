using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        static readonly int ElementsCount = 7;
        static readonly int ElementsCount2 = 7;
        static readonly int TestValue = 9;

        [TestMethod]
        public void TestRemove()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount);
            list.AddInTail(new Node(TestValue));
            list.AddInTail(new Node(TestValue));
            Program.GenerateLinkedListElements(list, ElementsCount);

            var node = list.Find(TestValue);
            Assert.IsTrue(list.Remove(TestValue));
            Assert.AreNotEqual(node, list.Find(TestValue));

            var list1 = new LinkedList();
            Assert.IsFalse(list1.Remove(TestValue));
        }

        [TestMethod]
        public void TestRemoveAll()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount);
            list.AddInTail(new Node(TestValue));
            Program.GenerateLinkedListElements(list, ElementsCount);
            list.AddInTail(new Node(TestValue));

            Assert.IsNotNull(list.Find(TestValue));
            list.RemoveAll(TestValue);
            Assert.IsNull(list.Find(TestValue));
        }

        [TestMethod]
        public void TestClear()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount);
            list.Clear();
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
            Assert.AreEqual(0, list.length);
        }

        [TestMethod]
        public void TestFindAll()
        {
            var testBigValue = 1000;
            var list = new LinkedList();
            list.AddInTail(new Node(testBigValue));
            Program.GenerateLinkedListElements(list, ElementsCount);
            list.AddInTail(new Node(testBigValue));
            Program.GenerateLinkedListElements(list, ElementsCount);
            list.AddInTail(new Node(testBigValue));

            var resultList = list.FindAll(testBigValue);
            Assert.AreEqual(3, resultList.Count);
            foreach (var e in resultList)
                Assert.AreEqual(testBigValue, e.value);
        }

        [TestMethod]
        public void TestCount()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount);

            var count = 0;
            var node = list.head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            Assert.AreEqual(list.length, count);
        }

        [TestMethod]
        public void TestInsertAfter()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount);
            var node = new Node(TestValue);
            list.AddInTail(node);
            Program.GenerateLinkedListElements(list, ElementsCount);
            var insertNode = new Node(TestValue + 1);

            var startLength = list.length;
            list.InsertAfter(node, insertNode);
            Assert.AreEqual(startLength + 1, list.length);
            Assert.IsTrue(list.IsNodeInList(insertNode));
            Assert.IsTrue(node.next.Equals(insertNode));
        }

        [TestMethod]
        public void TestSumTwoListsElements()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount);
            var list2 = Program.GenerateLinkedListElements(new LinkedList(), ElementsCount2);

            var resultList = LinkedList.SumTwoListsElements(list, list2);
            if (list.length == list2.length)
            {
                Assert.AreEqual(list.length, resultList.length);
                Assert.AreEqual(ElementsSumm(list) + ElementsSumm(list2), ElementsSumm(resultList));
            }
            else Assert.IsNull(resultList);
        }

        public static int ElementsSumm(LinkedList list)
        {
            var result = 0;
            var node = list.head;
            while (node != null)
            {
                result += node.value;
                node = node.next;
            }
            return result;
        }
    }
}
