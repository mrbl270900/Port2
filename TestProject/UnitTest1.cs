using DataLayer;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestContext()
        {
            var service = new DataService();
            Assert.Pass();
        }
    }
}