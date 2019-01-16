using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample
{
    [GingerService("DictionaryService", "Memeory" , "Dictionary Service ")]
    public class DictionaryService :  IServiceSession
    {
        bool IsRunning = false;

        readonly Dictionary<string, string> mDictionary = new Dictionary<string, string>();
        public List<string> Platforms { get { return new List<string>() { "Web", "Mobile" }; } }

        #region IServiceSession
        public void StartSession()
        {
            IsRunning = true;
            Console.WriteLine("*** DictionaryService started ***");
        }

        public void StopSession()
        {
            IsRunning = false;
            Console.WriteLine("*** DictionaryService is closing ***");
        }
        #endregion


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
            mDictionary.Add(key, value);
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
            bool b = mDictionary.TryGetValue(key, out value);

            //Out
            if (b)
            {
                Console.WriteLine("Found it, " + key + "=" + value);
                GA.AddOutput(key, value);
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
            mDictionary.Clear();

            //Out
            
            Console.WriteLine("Memeory cleared");
            
        }

        [GingerAction("LoadDataFromFile", "Load Data From File")]
        public void LoadDataFromFile(IGingerAction GA, string fileName)
        {
            //In
            //check file name exist
            //Act
            // mMemory.load...
            GA.AddError("No impl yet");
            //Out

            Console.WriteLine("Loaded...");

        }

        [GingerAction("List", "List all items in dictionary")]
        public void List(IGingerAction GA)
        {
            //In

            //Act
            Console.WriteLine("dictionary list:");
            List<string> list = new List<string>(mDictionary.Keys);
            int i = 0;
            foreach (string key in list)
            {
                i++;
                Console.WriteLine("{0} = {1}", key, mDictionary[key]);
                GA.AddOutput(key, mDictionary[key], i + "");
            }
            
            //Out

            Console.WriteLine("Loaded...");

        }


        //#region IWebBrowser

        //// or void IWebBrowser.Navigate(IGingerAction gingerAction, string URL)

        //public void Navigate(IGingerAction gingerAction, string URL)
        //{
        //    gingerAction.AddExInfo("OK");            
        //}

        //public void Submit(IGingerAction gingerAction)
        //{
        //    gingerAction.AddExInfo("OK");
        //}

        //#endregion

        //#region  ITakeScreenShot

        //public void TakeScreenShot(IGingerAction gingerAction, eScreens screens)
        //{
        //    gingerAction.AddExInfo("Screen Shot");
        //}

        // #endregion
    }
}
