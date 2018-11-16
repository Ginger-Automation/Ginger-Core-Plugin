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
            // GingerNodeStarter.StartNode(new MyDriver(), "MyDriver Service 1", "10.122.112.124",15001);
            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                gingerNodeStarter.StartNode(new MyDriver(), "MyDriver Service 1");
            }
                

            Console.ReadKey();
        }
    }
}
