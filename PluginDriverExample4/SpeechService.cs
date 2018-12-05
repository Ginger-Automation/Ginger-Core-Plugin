using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginDriverExample4
{
    // Simple service with stand alone actions


    [GingerService("SpeechService", "Speech Service ")]
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
    }
}
