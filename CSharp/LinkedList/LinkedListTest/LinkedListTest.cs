using LinkedListDll;
using NUnit.Framework;
using System;

namespace LinkedListTest
{
    [TestFixture]
    public class LinkedListTest
    {
        LinkedList<int> m_list0;
        LinkedList<int> m_list1;
        LinkedList<int> m_list2;
        LinkedList<int> m_list3;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
        }

        [SetUp]
        public void SetUp()
        {
            m_list0 = new LinkedList<int>();
            m_list1 = new LinkedList<int>();
            m_list2 = new LinkedList<int>();
            m_list3 = new LinkedList<int>();

            m_list1.Add(42);

            m_list2.Add(1);
            m_list2.Add(2);

            m_list3.Add(1);
            m_list3.Add(2);
            m_list3.Add(3);
        }

        [Test]
        public void TestNewList()
        {
            Assert.AreEqual(0, m_list0.Count);
            Assert.AreEqual(null, m_list0.First);
            Assert.AreEqual(null, m_list0.Last);
        }

        [Test]
        public void TestClearList0()
        {
            m_list0.Clear();
            Assert.AreEqual(0, m_list0.Count);
            Assert.AreEqual(null, m_list0.First);
            Assert.AreEqual(null, m_list0.Last);
        }

        [Test]
        public void TestClearList3()
        {
            m_list3.Clear();
            Assert.AreEqual(0, m_list0.Count);
            Assert.AreEqual(null, m_list0.First);
            Assert.AreEqual(null, m_list0.Last);
        }

        [Test]
        public void TestAddList1()
        {
            Assert.AreEqual(1, m_list1.Count);
            Assert.AreEqual(42, m_list1.First.Value);
            Assert.AreEqual(42, m_list1.Last.Value);
        }

        [Test]
        public void TestAddList2()
        {
            Assert.AreEqual(2, m_list2.Count);
            Assert.AreEqual(1, m_list2.First.Value);
            Assert.AreEqual(2, m_list2.Last.Value);
        }

        [Test]
        public void TestAddList3()
        {
            Assert.AreEqual(3, m_list3.Count);
            Assert.AreEqual(1, m_list3.First.Value);
            Assert.AreEqual(3, m_list3.Last.Value);
        }

        [Test]
        public void TestGetList1()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(42);

            Assert.AreEqual(42, m_list1[0].Value);
        }

        [Test]
        public void TestGetList2()
        {
            Assert.AreEqual(1, m_list2[0].Value);
            Assert.AreEqual(2, m_list2[1].Value);
        }

        [Test]
        public void TestGetList3()
        {
            Assert.AreEqual(1, m_list3[0].Value);
            Assert.AreEqual(2, m_list3[1].Value);
            Assert.AreEqual(3, m_list3[2].Value);
        }

        [Test]
        public void TestGetListException0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list0[-1]; });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list0[0]; });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list0[1]; });
        }

        [Test]
        public void TestGetListException1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list0[-1]; });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list0[1]; });
        }

        [Test]
        public void TestGetListException2()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list2[-1]; });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list2[2]; });
        }

        [Test]
        public void TestGetListException3()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list2[-1]; });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { LinkedListNode<int> item = m_list2[3]; });
        }

        [Test]
        public void TestInsertList0()
        {
            m_list0.Insert(0, 42);
            Assert.AreEqual(1, m_list1.Count);
            Assert.AreEqual(42, m_list1.First.Value);
            Assert.AreEqual(42, m_list1.Last.Value);
        }

        [Test]
        public void TestInsertBeginList1()
        {
            m_list1.Insert(0, 24);
            Assert.AreEqual(2, m_list1.Count);
            Assert.AreEqual(24, m_list1.First.Value);
            Assert.AreEqual(24, m_list1[0].Value);
            Assert.AreEqual(42, m_list1.Last.Value);
            Assert.AreEqual(42, m_list1[1].Value);
        }

        [Test]
        public void TestInsertEndList1()
        {
            m_list1.Insert(1, 24);
            Assert.AreEqual(2, m_list1.Count);
            Assert.AreEqual(42, m_list1.First.Value);
            Assert.AreEqual(42, m_list1[0].Value);
            Assert.AreEqual(24, m_list1.Last.Value);
            Assert.AreEqual(24, m_list1[1].Value);
        }

        [Test]
        public void TestInsertList2()
        {
            m_list2.Insert(1, 42);
            Assert.AreEqual(3, m_list2.Count);
            Assert.AreEqual(1, m_list2.First.Value);
            Assert.AreEqual(2, m_list2.Last.Value);
            Assert.AreEqual(1, m_list2[0].Value);
            Assert.AreEqual(42, m_list2[1].Value);
            Assert.AreEqual(2, m_list2[2].Value);
        }

        [Test]
        public void TestInsertException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { m_list3.Insert(10, 42); });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { m_list3.Insert(-1, 42); });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { m_list3.Insert(4, 42); });
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            
        }
    }
}
