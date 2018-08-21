using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample
{
    [GingerService("MyDriver", "My driver who can speak")]
    public class MyDriver : IGingerService, IGingerDriver
    {
        bool IsRunning = false;

        public List<string> Platforms { get { return new List<string>() { "Web", "Mobile" }; } }

        public void Start()
        {
            IsRunning = true;
            Console.WriteLine("I started talking");
        }

        public void Stop()
        {
            IsRunning = false;
            Console.WriteLine("Going to sleep");
        }

        [GingerAction("Say", "Say text")]
        public void Say(IGingerAction GA, string text)
        {
            //In
            if (string.IsNullOrEmpty(text))
            {
                GA.AddError("Text cannot be empty");
                return;
            }

            //Act
            Console.WriteLine("I Say: " + text);
            
            //Out
            GA.AddOutput("I said", text);            
        }
    }
}
