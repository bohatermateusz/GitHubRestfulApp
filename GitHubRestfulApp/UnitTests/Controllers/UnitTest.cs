using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectInterfaces;

namespace AllegroGitHub.Controllers.Tests
{
    [TestFixture]
    public class UnitTest 
    {
        internal string user;
        [SetUp]
        public void Setup()
        {
            user = "John";
        }
        [Test]
        public async Task WellWellWellTest()
        {
            var service = new Mock<IMyService>();
            service.Setup(x => x.GetAsync()).Returns(() => Task.FromResult(5));
            var system = new GitHubController();
            var result = await system.GetDataFromGitHub(user);
            var testresult = result.Count == 0 ? false : true;
            Assert.IsTrue(testresult);
        }
    }
}