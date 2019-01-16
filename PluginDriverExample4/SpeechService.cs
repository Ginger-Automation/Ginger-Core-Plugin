using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginDriverExample4
{
    // Simple service with stand alone actions


    [GingerService("SpeechService", "Speach" ,"Speech Service ")]
    public class SpeechService
    {
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
            Console.WriteLine("Output with path");
            //Out
            GA.AddOutput("I said", text, "myPath");
        }

        [GingerAction("SayHello", "Say Hello {Name}")]
        public void SayHello(IGingerAction GA, string name, bool greeting)
        {
            //In
            if (string.IsNullOrEmpty(name))
            {
                GA.AddError("Name cannot be empty");
                return;
            }

            //Act
            Console.WriteLine("I Say Hello to: " + name);
            if (greeting)
            {
                Console.WriteLine("Have a wonderful day");
            }

            //Out
            GA.AddOutput("I said", name);
        }

    }
}
