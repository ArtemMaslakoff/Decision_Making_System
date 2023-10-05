using DecisionMakingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibraryUnitTests
{
    [TestClass]
    public class ContinuousRangeTests
    {
        string name = "Discrete Range";
        Notion notion = new Notion("Notion");
        double minimum = -10.353;
        double maximum = 13.42524;
        public ContinuousRange testRange = new ContinuousRange("", new Notion());

        [TestInitialize]
        public void TestInitialize()
        {
            testRange = new ContinuousRange(name, notion, minimum, maximum);
        }
        [TestMethod]
        public void Test_ContinuousRangeConstructor_WithData_WithoutError()
        {
            ContinuousRange range = new ContinuousRange(name, notion, minimum, maximum);

            Assert.AreEqual(name, range.GetName());
            Assert.AreEqual(notion, range.GetNotion());
            Assert.AreEqual(minimum, range.MinimumValue.Meaning);
            Assert.AreEqual(maximum, range.MaximumValue.Meaning);
        }
        [TestMethod]
        public void Test_ContinuousRangeConstructor_WithData_WithError_MinMax()
        {
            string name = "Discrete Range";
            Notion notion = new Notion("Notion");
            double minimum = 10.2321;
            double maximum = -13.3223;
            ContinuousRange range = new ContinuousRange(name, notion, minimum, maximum);

            Assert.AreEqual(name, range.GetName());
            Assert.AreEqual(notion, range.GetNotion());
            Assert.AreEqual(minimum, range.MinimumValue.Meaning);
            Assert.AreEqual(minimum, range.MaximumValue.Meaning);
        }
        [TestMethod]
        public void Test_ContinuousRange_GetMinimum()
        {
            Assert.AreEqual(notion, testRange.GetMinimum().Notion);
            Assert.AreEqual(minimum, testRange.GetMinimum().Meaning);
        }
        [TestMethod]
        public void Test_ContinuousRange_GetMaximum()
        {
            Assert.AreEqual(notion, testRange.GetMaximum().Notion);
            Assert.AreEqual(maximum, testRange.GetMaximum().Meaning);
        }
        [TestMethod]
        public void Test_ContinuousRange_IsInRange()
        {
            testRange = new ContinuousRange(name, notion, minimum, maximum);

            double testDouble = 5.12;
            Assert.IsTrue(testRange.IsInRange(testDouble));

            testDouble = 15.12;
            Assert.IsFalse(testRange.IsInRange(testDouble));

            testDouble = -15.12;
            Assert.IsFalse(testRange.IsInRange(testDouble));

            int testInt = 5;
            try
            {
                bool res = testRange.IsInRange(testInt);
                Assert.IsFalse(true);
            }
            catch
            {
                Assert.IsFalse(false);
            }
        }
    }
}
