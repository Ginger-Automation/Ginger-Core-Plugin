using Amdocs.Ginger.Plugin.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginExample1;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample1Test
{
    [TestClass]
    public class StringServiceTest
    {
        [TestMethod]
        public void RunAction()
        {
            //Arrange
            StringService myService = new StringService();
            GingerAction GA = new GingerAction();
            List<string> list = new List<string>() { "How", "Are", "You" };

            //Act
            myService.ConcatList (GA, "#", list);

            //assert
            Assert.AreEqual(null, GA.Errors, "Errors=null");
            Assert.AreEqual("How#Are#You", GA.Output["txt"], "txt");            
        }
    }
}
