using DecisionMakingLibrary.Core;

namespace DecisionMakingLibraryUnitTests
{
    [TestClass]
    public class ValueTests
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Notion Notion { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

        [TestInitialize]
        public void TestInitialize()
        {
            Notion = new Notion("Notion");
        }
        [TestMethod]
        public void Test_ValueConstructor_notion()
        {
            Value<int> value = new(Notion, 1);
            Assert.AreEqual(Notion.Name, value.GetNotion().Name);
        }
        [TestMethod]
        public void Test_ValueConstructor_meaning_int()
        {
            int excepted = 1273;
            Value<int> value = new(Notion, excepted);
            Assert.AreEqual(excepted, value.GetMeaning());
        }
        [TestMethod]
        public void Test_ValueConstructor_meaning_double()
        {
            double excepted = 1273.28732;
            Value<double> value = new(Notion, excepted);
            Assert.AreEqual(excepted, value.GetMeaning());
        }
        [TestMethod]
        public void Test_ValueConstructor_meaning_string()
        {
            string excepted = "fegre efe";
            Value<string> value = new(Notion, excepted);
            Assert.AreEqual(excepted, value.GetMeaning());
        }
    }
}
