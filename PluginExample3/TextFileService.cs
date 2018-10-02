using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample3
{
    [GingerService("TextFileService", "Text File service")]
    public class TextFileService : IGingerService
    {
        [GingerAction("WordsCount", "Count number of words in text file")]
        public void Sum(IGingerAction GA, string fileName)
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
    }
}
