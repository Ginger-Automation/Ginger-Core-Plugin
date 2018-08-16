using Amdocs.Ginger.Plugin.Core;
using PluginExample;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginExample
{
    public class MyTextEditor : ITextEditor
    {
        // to test the tool 'Save' worked - check Execute
        public bool IsSaved = false;

        string ITextEditor.Name { get { return "My Text Editor"; } }

        List<string> ITextEditor.Extensions { get { return new List<string>() { "txt", "csv", "json" }; } }
        
        public byte[] HighlightingDefinition
        {
            get
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PluginExample.MyTextEditorHighlighting.xshd");
                byte[] data = ReadFully(stream);                                
                return data;
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public List<ITextEditorToolBarItem> Tools { get {
                List<ITextEditorToolBarItem> tools = new List<ITextEditorToolBarItem>();
                tools.Add(new SaveTool() { myTextEditor = this});
                return tools;
            } }

        public IFoldingStrategy FoldingStrategy { get { return new MyFoldingStrategy();  } }
    }    
}

class MyFoldingStrategy : IFoldingStrategy
{
   
}


class SaveTool : ITextEditorToolBarItem
{
    public MyTextEditor myTextEditor { get; set; }

    public string Text { get { return "Save"; }  }

    public string toolTip { get { return "Save to file system"; }  }    

    public void Execute()
    {
        myTextEditor.IsSaved = true;
    }    
}