using Amdocs.Ginger.Plugin.Core;
using System;

namespace PluginExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Plugin Exmaple 1");
            GingerNodeStarter.StartNode(new MathService(), "Math Service 1");

            GingerNodeStarter.StartNode(new StringService(), "String Service 1");

            // GingerNodeStarter.StartNode(new StringService(), "String Service 1");

            //GingerNodeStarter.StartNode(typeof(MathService),"localhost", 15001);
            // GingerNodeStarter.StartNode(args);
            Console.ReadKey();
        }
    }
}
