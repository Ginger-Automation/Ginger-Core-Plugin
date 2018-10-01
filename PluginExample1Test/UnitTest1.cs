using Amdocs.Ginger.Plugin.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginExample1;

namespace PluginExample1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RunAction()
        {
            //Arrange
            MathService myService = new MathService();
            GingerAction GA = new GingerAction();

            //Act
            myService.Sum(GA, 2, 3);

            //assert
            Assert.AreEqual(null, GA.Errors, "Errors=null");
            //Assert.AreEqual(GA.Output["a"], "2", "a");
            //Assert.AreEqual(GA.Output["b"], "3", "b");
            //Assert.AreEqual(GA.Output["Total"], "5", "output Total");
            // Assert.AreEqual(GA.ExInfo .Output["a"], "2", "a");
        }
    }
}
