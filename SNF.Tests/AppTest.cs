using SNF;

namespace ECS.Tests
{
    public class AppTest
    {
        private Scene _scene;

        [SetUp]
        public void Setup()
        {
            _scene = new Scene();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}