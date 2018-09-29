using Amdocs.Ginger.Plugin.Core;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginExample
{
    // Sample implemntation of ITextEditor for unit tests
    public class MyTextEditor : ITextEditor
    {
        // to test the tool 'Save' worked - check Execute
        public bool IsSaved = false;

        string ITextEditor.Name { get { return "My Text Editor"; } }

        List<string> ITextEditor.Extensions { get { return new List<string>() { "txt", "csv", "json" }; } }

        

        //public MessageType MessageType;
        //public string MessageText;

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



        // public void ShowMessage(MessageType messageType, string text)
        //{
        //    MessageType = messageType;
        //    MessageText = text;
        //}

        
        
            // Add the tools 
        public List<ITextEditorToolBarItem> Tools { get {
                List<ITextEditorToolBarItem> tools = new List<ITextEditorToolBarItem>();
                tools.Add(new SaveTool());
                tools.Add(new LowerCaseTool());
                
                return tools;
            } }

        public IFoldingStrategy FoldingStrategy { get { return new MyFoldingStrategy();  } }

        ITextHandler mTextHandler;
        public ITextHandler TextHandler { get { return mTextHandler; } set { mTextHandler = value; } }

        //string mText;
        //public string Text { get { return mText; } set { mText = value; } }

        //public int CaretLocation { get { return mText.Length ;  } }
    }    
}

class MyFoldingStrategy : IFoldingStrategy
{
   
}


