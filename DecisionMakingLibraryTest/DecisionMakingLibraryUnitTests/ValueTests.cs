using DecisionMakingLibrary.Core;

namespace DecisionMakingLibraryUnitTests
{
    [TestClass]
    public class ValueTests
    {
        public Notion Notion { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Notion = new Notion("Notion");
        }
        [TestMethod]
        public void Test_ValueConstructor_notion()
        {
            Value<int> value = new(Notion, 1);
            Assert.AreEqual(Notion.Name, value.Notion.Name);
        }
        [TestMethod]
        public void Test_ValueConstructor_meaning_int()
        {
            int excepted = 1273;
            Value<int> value = new(Notion, excepted);
            Assert.AreEqual(excepted, value.Meaning);
        }
        [TestMethod]
        public void Test_ValueConstructor_meaning_double()
        {
            double excepted = 1273.28732;
            Value<double> value = new(Notion, excepted);
            Assert.AreEqual(excepted, value.Meaning);
        }
        [TestMethod]
        public void Test_ValueConstructor_meaning_string()
        {
            string excepted = "fegre efe";
            Value<string> value = new(Notion, excepted);
            Assert.AreEqual(excepted, value.Meaning);
        }
    }
}
