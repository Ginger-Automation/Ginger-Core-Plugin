using Amdocs.Ginger.Plugin.Core;
using System;

namespace PluginExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TODO: connect to grid

            MyService myService = new MyService();
            GingerAction GA = new GingerAction();
            myService.Sum(GA, 5, 4);
        }

        
    }
}
