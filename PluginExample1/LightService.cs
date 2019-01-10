using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PluginExample1
{
    [GingerService("LightService", "Light service")]
    public class LightService
    {
        public enum ONOFF
        {
            [Description("Turn Light on")]
            On,
            [Description("Turn Light off")]
            Off
        }

        public enum COLOR
        {
            Red,
            Green,
            Blue,
            Yellow,
            Cyan,
            Brown,
            White,
            Black
        }

        [GingerAction("TurnLight", "Turn Light on/off")]
        public void TurnLight(IGingerAction GA, ONOFF oNOFF)
        {
            Console.WriteLine(DateTime.Now + "> TurnLight: " + oNOFF);
            //In

            //Act
            

            //Out
            GA.AddOutput("Light is ", oNOFF);            
        }

        [GingerAction("LightColor", "Change light color")]
        public void LightColor(IGingerAction GA, COLOR color)
        {
            Console.WriteLine(DateTime.Now + "> LightColor: " + color);
            //In

            //Act


            //Out
            GA.AddOutput("Light color ", color);
        }
    }
}
