using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample
{
    class SaveTool : ITextEditorToolBarItem
    {        

        public string ToolText { get { return "Save"; } }

        public string ToolTip { get { return "Save to file system"; } }
                

        public void Execute(ITextEditor textEditor)
        {
            MyTextEditor myTextEditor = (MyTextEditor)textEditor;
            myTextEditor.IsSaved = true;
            myTextEditor.ShowMessage(MessageType.Info, "Saved");
        }
    }
}
