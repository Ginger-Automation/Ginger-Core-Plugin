using GingerPlugInsNET.ActionsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GingerPluginCoreTest
{
    [TestClass]
    public class MyPluginTest
    {
        [TestMethod]
        public void CheckName()
        {
            //Arrange
            MyPlugin myPlugin = new MyPlugin();

            //Act
            string name = myPlugin.Name;

            //assert
            Assert.AreEqual("My Plugin", name, "name = 'My Plugin'");
        }

        [TestMethod]
        public void StartDriver()
        {
            //Arrange
            MyPlugin myPlugin = new MyPlugin();

            //Act
            myPlugin.StartDriver();

            //assert
            Assert.AreEqual(true, myPlugin.IsRunning , "IsRunning = true");
        }

        [TestMethod]
        public void CloseDriver()
        {
            //Arrange
            MyPlugin myPlugin = new MyPlugin();
            myPlugin.StartDriver();

            //Act
            myPlugin.CloseDriver();

            //assert
            Assert.AreEqual(false, myPlugin.IsRunning, "IsRunning = false");
        }

        [TestMethod]
        public void RunAction()
        {
            //Arrange
            MyPlugin myPlugin = new MyPlugin();            

            GingerAction sumAction = new GingerAction("sum");
            sumAction.InputParams["a"].Value = "3";
            sumAction.InputParams["b"].Value = "5";

            myPlugin.StartDriver();
            // myPlugin.ini

            //Act

            myPlugin.RunAction(sumAction);

            //assert
            Assert.AreEqual(null, sumAction.Errors, "Errors=null");
            Assert.AreEqual(sumAction.Output["Total"] , "8" , "output 'total' = 8");
        }
    }
}
