using Amdocs.Ginger.Plugin.Core;
using System;

namespace PluginExample3
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Starting Plugin Exmaple 3");            
            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                if (args.Length > 0)
                {
                    gingerNodeStarter.StartFromConfigFile(args[0]);  // file name 
                }
                else
                {                    
                    gingerNodeStarter.StartNode("Text File Service 1", new TextFileService());
                }
                gingerNodeStarter.Listen();
            }


            Console.ReadKey();
        }
    }
}
