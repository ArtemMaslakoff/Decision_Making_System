using DecisionMakingLibrary;
using System.Security.Cryptography.X509Certificates;

namespace DecisionMakingLibraryUnitTests
{
    [TestClass]
    public class NotionTests
    {
        [TestMethod]
        public void Test_NotionConstructor_WithoutName()
        {
            Notion notion = new Notion();
            Assert.AreEqual("", notion.Name);
            // arrange // expected
            // act  // actual
            // assert  // Assert.AreEqual(expected, actual)
        }
        [TestMethod]
        public void Test_NotionConstructor_WithName()
        {
            string name = "Test Name";
            Notion notion = new Notion(name);
            Assert.AreEqual(name, notion.Name);
        }
    }
}