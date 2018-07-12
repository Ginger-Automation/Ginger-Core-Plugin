using GingerPlugInsNET.ActionsLib;
using GingerPlugInsNET.DriversLib;
using GingerPlugInsNET.PlugInsLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GingerPluginCoreTest
{
    public class MyPlugin : PluginDriverBase
    {
        private bool mIsrunning = false;

        public override string Name { get { return "My Plugin"; } }

        public object IsRunning { get { return mIsrunning; } }

        public override void CloseDriver()
        {
            mIsrunning = false;
        }

        public override void StartDriver()
        {
            mIsrunning = true;            
        }

        [GingerAction("sum", "sum two numbers")]
        public void Sum(ref GingerAction GA, int a, int b)
        {
            string total = (a + b).ToString();
            GA.Output.Add("Total", total);

        }

    }
}
