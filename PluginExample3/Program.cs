using Amdocs.Ginger.Plugin.Core;
using System;

namespace PluginExample3
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Starting Plugin Exmaple 3");
            GingerNodeStarter.StartNode(new TextFileService(), "Text File Service 1");            
            Console.ReadKey();
        }
    }
}
