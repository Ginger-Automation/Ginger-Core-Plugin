using Amdocs.Ginger.Plugin.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginExample;
using System.Collections.Generic;

namespace GingerPluginCoreTest
{
    [TestClass]
    public class TextEditorTest
    {
        [TestMethod]
        public void CheckName()
        {
            //Arrange
            ITextEditor myTextEditor = new MyTextEditor();

            //Act
            string name = myTextEditor.Name;

            //assert
            Assert.AreEqual("My Text Editor", name, "My text editor name");
        }

        [TestMethod]
        public void Extensions()
        {
            //Arrange
            ITextEditor myTextEditor = new MyTextEditor();

            //Act
            List<string> extensions = myTextEditor.Extensions;

            //assert
            Assert.AreEqual("txt", extensions[0], "Extension txt");
            Assert.AreEqual(3, extensions.Count, "Extensions count");
        }

        [TestMethod]
        public void Buttons()
        {
            //Arrange
            ITextEditor myTextEditor = new MyTextEditor();

            //Act
            List <ITextEditorToolBarItem> tools = myTextEditor.Tools;
            ITextEditorToolBarItem savetool = tools[0];

            //assert
            Assert.AreEqual("Save",savetool.Text, "tool text");            
        }

        [TestMethod]
        public void ExecuteTool()
        {
            //Arrange
            ITextEditor myTextEditor = new MyTextEditor();
            List<ITextEditorToolBarItem> tools = myTextEditor.Tools;
            ITextEditorToolBarItem savetool = tools[0];

            //Act
            savetool.Execute();
            bool isSaved = ((MyTextEditor)myTextEditor).IsSaved;

            //assert
            Assert.AreEqual(true, isSaved, "Tool activated");
        }


        [TestMethod]
        public void Highlighting()
        {
            //Arrange
            ITextEditor myTextEditor = new MyTextEditor();

            //Act
            byte[] b = myTextEditor.HighlightingDefinition;
            string txt = System.Text.Encoding.UTF8.GetString(b);

            //assert
            Assert.IsTrue(txt.StartsWith("<?xml version=") , "Highlighting from resource");
        }

    }
}
