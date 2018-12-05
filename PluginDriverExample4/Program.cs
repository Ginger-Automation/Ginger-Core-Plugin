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

            // Not working on Linux
            // Console.BufferHeight = 100;

            Console.WriteLine("Starting Plugin Driver Exmaple 4");
            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                gingerNodeStarter.StartNode("Dictionary Service 1", new DictionaryService());
                gingerNodeStarter.StartNode("Speech Service 1", new SpeechService());

                gingerNodeStarter.Listen();                
            }
                
            
        }
    }
}
