

using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PluginExample1
{
    [GingerService("StringService", "String service")]
    public class StringService 
    {
       
        [GingerAction("Concat", "Concat two string")]
        public void Concat(IGingerAction GA, string s1, string s2)
        {
            Console.WriteLine(DateTime.Now + "> Concat: " + s1 + "+" + s2);
            //In

            //Act
            string txt = string.Concat(s1, s2);         

            //Out
            GA.AddOutput("s1", s1);
            GA.AddOutput("s2", s2);
            GA.AddOutput("txt", txt);

            GA.AddExInfo(s1 + "+" + s2 + "=" + txt);
        }

        [GingerAction("Split", "SplitString")]
        public void Divide(IGingerAction GA, string txt, string seperator)
        {
            //In


            //Act
            string[] a = txt.Split(new string[] { seperator }, StringSplitOptions.None);

            //Out
            int i = 1;
            foreach (string s in a)
            {
                GA.AddOutput("#" + i, s, i + "");
            }
        }


        [GingerAction("ConcatList", "Concat List of strings")]
        public void ConcatList(IGingerAction GA, string delimiter, List<string> list)
        {
            Console.WriteLine(DateTime.Now + "> ConcatList: contains" + list.Count + " strings");
            //In

            //Act
            string txt = "";
            foreach (string s in list)
            {
                if (txt.Length > 0) txt += delimiter;
                txt += s;
            }

            //Out
            GA.AddOutput("txt", txt);                        
        }

        [GingerAction("ConcatListItems", "Concat List of items")]
        public void ConcatListItems(IGingerAction GA, string delimiter, List<ListItem> list)
        {
            Console.WriteLine(DateTime.Now + "> ConcatList: contains" + list.Count + " strings");
            //In

            //Act
            string txt = "";
            foreach (ListItem item in list)
            {
                if (txt.Length > 0) txt += Environment.NewLine;
                txt += item.Key + delimiter + item.Value;
            }

            //Out
            GA.AddOutput("txt", txt);
        }

    }
}
