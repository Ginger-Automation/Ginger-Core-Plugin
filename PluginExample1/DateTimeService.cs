using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginExample1
{
    [GingerService("DateTimeService", "System",  "Date Time service")]
    public class DateTimeService 
    {
        [GingerAction("GetCurrentTime", "Get current system time")]
        public void GetCurrentTime(IGingerAction GA)
        {

            //In

            //Act
            string txt = DateTime.Now.ToString();

            //Out
            GA.AddOutput("DateTime", txt);
            
        }

        [GingerAction("GetCurrentTimeUTC", "Get current UTC time")]
        public void GetCurrentTimeUTC(IGingerAction GA)
        {

            //In

            //Act
            string txt = DateTime.UtcNow.ToString();

            //Out
            GA.AddOutput("DateTime", txt);

        }
    }
}
