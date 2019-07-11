using Amdocs.Ginger.Plugin.Core;
using PluginExample;
using System;

namespace PluginDriverExample4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PluginDriverExample4";

            Console.WriteLine("Starting Plugin Driver Example 4");

            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                if (args.Length > 0)
                {
                    gingerNodeStarter.StartFromConfigFile(args[0]);  // file name 
                }
                else
                {
                    gingerNodeStarter.StartNode("Dictionary Service 1", new DictionaryService());
                    gingerNodeStarter.StartNode("Speech Service 1", new SpeechService());
                }
                gingerNodeStarter.Listen();
            }
        }
    }
}
