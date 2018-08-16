using System;
using System.Collections.Generic;
using System.Text;

namespace Amdocs.Ginger.Plugin.Core
{
    public interface IGingerAction
    {
        string Id { get; set; }
        void AddOutput(string param, object value, string path = null);
        void AddError(string error);
        void AddExInfo(string info);
    }
}
