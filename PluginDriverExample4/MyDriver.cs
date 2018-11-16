using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample
{
    [GingerService("MyDriver", "My driver who can speak")]
    public class MyDriver :  IServiceSession
    {
        bool IsRunning = false;

        Dictionary<string, string> mMemory = new Dictionary<string, string>();
        public List<string> Platforms { get { return new List<string>() { "Web", "Mobile" }; } }

        public void StartSession()
        {
            IsRunning = true;
            Console.WriteLine("*** I started talking ***");
        }

        public void StopSession()
        {
            IsRunning = false;
            Console.WriteLine("*** Going to sleep ***");
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

        [GingerAction("Memorize", "Memorize text")]
        public void Memorize(IGingerAction GA, string key, string value)
        {
            //In
            if (string.IsNullOrEmpty(key))
            {
                GA.AddError("Key cannot be empty");
                return;
            }

            //Act
            mMemory.Add(key, value);
            Console.WriteLine("I Remeber: " + key + "=" + value);

            //Out
            GA.AddOutput("I Remeber: ",  key + "=" + value);
        }

        [GingerAction("GetMemo", "Get item from memory")]
        public void GetMemo(IGingerAction GA, string key)
        {
            //In
            if (string.IsNullOrEmpty(key))
            {
                GA.AddError("Key cannot be empty");
                return;
            }

            //Act
            string value;
            bool b = mMemory.TryGetValue(key, out value);

            //Out
            if (b)
            {
                Console.WriteLine("Found it, " + key + "=" + value);
            }
            else
            {
                Console.WriteLine("Key not found it: " + key);
                GA.AddError("Key not found it: " + key);
            }
            
        }


        [GingerAction("ClearMemo", "Clear memory")]
        public void ClearMemo(IGingerAction GA)
        {
            //In

            //Act
            mMemory.Clear();

            //Out
            
            Console.WriteLine("Memeory cleared");
            
        }

    }
}
