using DecisionMakingLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibraryUnitTests
{
    [TestClass]
    public class DiscreteRangeTests
    {
        string name = "Discrete Range";
        Notion notion = new Notion("Notion");
        int minimum = -10;
        int maximum = 13;
        public DiscreteRange testRange = new DiscreteRange("", new Notion());

        [TestInitialize]
        public void TestInitialize()
        {
            testRange = new DiscreteRange(name, notion, minimum, maximum);
        }
        [TestMethod]
        public void Test_DiscreteRangeConstructor_WithData_WithoutError()
        {
            string name = "Discrete Range";
            Notion notion = new Notion("Notion");
            int minimum = -10;
            int maximum = 13;
            DiscreteRange range = new DiscreteRange(name, notion, minimum, maximum);

            Assert.AreEqual(name, range.GetName());
            Assert.AreEqual(notion, range.GetNotion());
            Assert.AreEqual(minimum, range.MinimumValue.GetMeaning());
            Assert.AreEqual(maximum, range.MaximumValue.GetMeaning());
        }
        [TestMethod]
        public void Test_DiscreteRangeConstructor_WithData_WithError_MinMax()
        {
            string name = "Discrete Range";
            Notion notion = new Notion("Notion");
            int minimum = 10;
            int maximum = -13;
            DiscreteRange range = new DiscreteRange(name, notion, minimum, maximum);

            Assert.AreEqual(name, range.GetName());
            Assert.AreEqual(notion, range.GetNotion());
            Assert.AreEqual(minimum, range.MinimumValue.GetMeaning());
            Assert.AreEqual(minimum, range.MaximumValue.GetMeaning());
        }
        [TestMethod]
        public void Test_DiscreteRange_GetMinimum()
        {
            Assert.AreEqual(notion, testRange.GetMinimum().GetNotion());
            Assert.AreEqual(minimum, testRange.GetMinimum().GetMeaning());
        }
        [TestMethod]
        public void Test_DiscreteRange_GetMaximum()
        {
            Assert.AreEqual(notion, testRange.GetMaximum().GetNotion());
            Assert.AreEqual(maximum, testRange.GetMaximum().GetMeaning());
        }
        [TestMethod]
        public void Test_DiscreteRange_IsInRange()
        {
            testRange = new DiscreteRange(name, notion, minimum, maximum);

            int testInt = 5;
            Assert.IsTrue(testRange.IsInRange(testInt));

            testInt = 15;
            Assert.IsFalse(testRange.IsInRange(testInt));

            testInt = -15;
            Assert.IsFalse(testRange.IsInRange(testInt));

            int testDouble = 5;
            try
            {
                bool res = testRange.IsInRange(testDouble);
                Assert.IsFalse(true);
            }
            catch
            {
                Assert.IsFalse(false);
            }
        }
    }
}
