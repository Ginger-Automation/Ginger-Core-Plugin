using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample3
{
    [GingerService("TextFileService", "Text File service")]
    public class TextFileService 
    {
        [GingerAction(Id : "WordsCount", description: "Count number of words in text file")]
        public void WordsCount(IGingerAction GA, string fileName)
        {            
            //In
            if (!System.IO.File.Exists(fileName))
            {
                GA.AddError("File not found: " + fileName);
            }

            //Act
            string[] lines = System.IO.File.ReadAllLines(fileName);
            int count = 0;
            foreach (string l in lines)
            {
                count += l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            }

            //Out
            GA.AddOutput("count", count);
            
            GA.AddExInfo("Count=" + count);
        }


        //[GingerAction("Search", "Search text in file, out put line contain the text")]
        //public void Search(IGingerAction GA, string fileName, string text, FindAll, FindFirst)
        //{
        //    //In
        //    if (!System.IO.File.Exists(fileName))
        //    {
        //        GA.AddError("File not found: " + fileName);
        //    }

        //    // check empty text

        //    //Act
        //    string[] lines = System.IO.File.ReadAllLines(fileName);
        //    int count = 0;
        //    foreach (string l in lines)
        //    {
        //        if (l.IndexOf(text) > 0)
        //        {

        //        }
        //    }

        //    //Out
        //    GA.AddOutput("count", count);

        //    GA.AddExInfo("Count=" + count);
        //}



    }
}
