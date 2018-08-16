using System;
using System.Collections.Generic;
using System.Text;

namespace Amdocs.Ginger.Plugin.Core
{
    public interface ITextEditorToolBarItem
    {        
        string Text { get; }
        string toolTip { get;  }

        void Execute();
    }
}
