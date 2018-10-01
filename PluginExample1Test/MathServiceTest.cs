using Amdocs.Ginger.Plugin.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginExample1;

namespace PluginExample1Test
{
    [TestClass]
    public class MathServiceTest
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
            Assert.AreEqual(2, GA.Output["a"],  "a");
            Assert.AreEqual(3, GA.Output["b"],  "b");
            Assert.AreEqual(5, GA.Output["Total"],  "output Total");
            Assert.AreEqual("2+3=5", GA.ExInfo , "ExInfo");
        }
    }
}
