using DecisionMakingLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DecisionMakingLibraryUnitTests
{
    [TestClass]
    public class SetTests
    {
        Notion notion1 = new Notion("notion1");
        Notion notion2 = new Notion("notion2");
        [TestMethod]
        public void Test_Constructor_WithoutItems()
        {
            Set<int> testSet = new Set<int>(notion1);
            Assert.AreEqual(notion1, testSet.GetNotion());
            Assert.AreEqual(0, testSet.GetCount());
        }
        [TestMethod]
        public void Test_Constructor_WithItems()
        {
            List<int> list = new List<int> { 1, 2, 3, 1233};
            Set<int> testSet = new Set<int>(notion1, list);

            Assert.AreEqual(notion1, testSet.GetNotion());
            Assert.AreEqual(list.Count, testSet.GetCount());

            list = new List<int> { 1, 2, 3, 1233, 2, 3};
            testSet = new Set<int>(notion1, list);

            Assert.AreEqual(notion1, testSet.GetNotion());
            Assert.AreEqual(list.Count - 2, testSet.GetCount());
        }
        [TestMethod]
        public void Test_GetNotion()
        {
            Set<int> testSet = new Set<int>(notion1);
            Assert.AreEqual(notion1, testSet.GetNotion());

            Set<int> testSet2 = new Set<int>(notion2);
            Assert.AreEqual(notion2, testSet2.GetNotion());
        }
        [TestMethod]
        public void Test_GetCount()
        {
            List<int> list = new List<int> { 1, 2, 3, 1233 };
            Set<int> testSet = new Set<int>(notion1, list);
            Assert.AreEqual(list.Count, testSet.GetCount());

            list = new List<int> { 12, 432, 2, 1233, 23453, 23 };
            testSet = new Set<int>(notion1, list);
            Assert.AreEqual(list.Count, testSet.GetCount());

            testSet = new Set<int>(notion1);
            Assert.AreEqual(0, testSet.GetCount());
        }
        [TestMethod]
        public void Test_GetItem()
        {
            List<int> list = new List<int> { 1, 2, 3, 1233 };
            Set<int> testSet = new Set<int>(notion1, list);
            Assert.AreEqual(list[0], testSet.GetItem(0));
            Assert.AreEqual(list[1], testSet.GetItem(1));
            Assert.AreEqual(list[2], testSet.GetItem(2));
            Assert.AreEqual(list[3], testSet.GetItem(3));

            testSet = new Set<int>(notion1);
            try
            {
                testSet.GetItem(0);
                Assert.IsTrue(false, "Should have thrown the exception");
            }
            catch
            {

            }
        }
        [TestMethod]
        public void Test_GetItemAsValue()
        {
            List<int> list = new List<int> { 1, 2, 3, 1233 };
            Set<int> testSet = new Set<int>(notion1, list);

            Value<int> value1 = new Value<int>(notion1, 3);
            Value<int> value2 = new Value<int>(notion2, 3);

            Assert.AreEqual(value1, testSet.GetItemAsValue(2));
            Assert.AreNotEqual(value2, testSet.GetItemAsValue(2));
        }
        [TestMethod]
        public void Test_AddItem()
        {
            int number = 1231;

            Set<int> testSet = new Set<int>(notion1);
            testSet.AddItem(number);

            Assert.AreEqual(1, testSet.GetCount());
            Assert.AreEqual(number, testSet.GetItem(0));
        }
        [TestMethod]
        public void Test_RemoveItem()
        {
            List<int> list = new List<int> { 1233 };
            Set<int> testSet = new Set<int>(notion1, list);

            testSet.RemoveItem(0);

            Assert.AreEqual(1, testSet.GetCount());

            testSet.RemoveItem(1233);

            Assert.AreEqual(0, testSet.GetCount());

            testSet.RemoveItem(2);

            Assert.AreEqual(0, testSet.GetCount());
        }
        [TestMethod]
        public void Test_Clear()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet = new Set<int>(notion1, list);

            testSet.Clear();

            Assert.AreEqual(0, testSet.GetCount());
        }
        [TestMethod]
        public void Test_Contains()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet = new Set<int>(notion1, list);

            Assert.IsTrue(testSet.Contains(12));
            Assert.IsFalse(testSet.Contains(13));
        }
        [TestMethod]
        public void Test_IsSubSet()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 423 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Assert.IsTrue(testSet1.IsSubSet(testSet2));

            testSet2 = new Set<int>(notion1);

            Assert.IsTrue(testSet1.IsSubSet(testSet2));

            list = new List<int> { 1233, 12, 423, 1 };
            testSet2 = new Set<int>(notion1, list);

            Assert.IsFalse(testSet1.IsSubSet(testSet2));

            list = new List<int> { 1233, 12, 4231 };
            testSet2 = new Set<int>(notion1, list);

            Assert.IsFalse(testSet1.IsSubSet(testSet2));

            list = new List<int> { 1233, 12, 4231 };
            testSet1 = new Set<int>(notion1, list);
            list = new List<int> { 1233, 12 };
            testSet2 = new Set<int>(notion2, list);

            Assert.IsFalse(testSet1.IsSubSet(testSet2));
        }
        [TestMethod]
        public void Test_Union()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 31, 1, 2, 3 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Set<int> result = Set<int>.Union(testSet1, testSet2);

            list = new List<int> { 1233, 12, 31, 423, 54, 1, 2, 3};

            Assert.AreEqual(list.Count, result.GetCount());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(result.Contains(list[i]));
            }
        }
        [TestMethod]
        public void Test_Intersection()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 31, 1, 2, 3 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Set<int> result = Set<int>.Intersection(testSet1, testSet2);

            list = new List<int> { 1233, 12, 31 };

            Assert.AreEqual(list.Count, result.GetCount());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(result.Contains(list[i]));
            }
        }
        [TestMethod]
        public void Test_Difference()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 31, 1, 2, 3 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Set<int> result = Set<int>.Difference(testSet1, testSet2);

            list = new List<int> { 423, 54 };

            Assert.AreEqual(list.Count, result.GetCount());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(result.Contains(list[i]));
            }
        }
        [TestMethod]
        public void Test_SymmetricDifference()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 31, 1, 2, 3 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Set<int> result = Set<int>.SymmetricDifference(testSet1, testSet2);

            list = new List<int> { 423, 54, 1, 2, 3 };

            Assert.AreEqual(list.Count, result.GetCount());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(result.Contains(list[i]));
            }
        }
        [TestMethod]
        public void Test_operator_summ()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 31, 1, 2, 3 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Set<int> result = testSet1 + testSet2;

            list = new List<int> { 1233, 12, 31, 423, 54, 1, 2, 3 };

            Assert.AreEqual(list.Count, result.GetCount());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(result.Contains(list[i]));
            }
        }
        [TestMethod]
        public void Test_operator_diff()
        {
            List<int> list = new List<int> { 1233, 12, 31, 12, 423, 54 };
            Set<int> testSet1 = new Set<int>(notion1, list);

            list = new List<int> { 1233, 12, 31, 1, 2, 3 };
            Set<int> testSet2 = new Set<int>(notion1, list);

            Set<int> result = testSet1 - testSet2;

            list = new List<int> { 423, 54 };

            Assert.AreEqual(list.Count, result.GetCount());
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(result.Contains(list[i]));
            }
        }
    }
}
