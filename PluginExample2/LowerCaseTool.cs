using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample
{
    class LowerCaseTool : ITextEditorToolBarItem
    {
        public string ToolText { get { return "Lower Case"; } }

        public string ToolTip { get { return "Change text to lower case"; } }

        public void Execute(ITextEditor TextEditor)
        {
            TextEditor.Text = TextEditor.Text.ToLower();
        }
    }
}
