

using Amdocs.Ginger.Plugin.Core;
using System.Collections.Generic;

namespace PluginExample
{
    [GingerService("MyService", "My Sum and Device service")]
    public class MyService : IGingerService
    {
        //private bool mIsrunning = false;

        //public override string Name { get { return "My Plugin"; } }

        //public object IsRunning { get { return mIsrunning; } }

        //public override void CloseDriver()
        //{
        //    mIsrunning = false;
        //}

        //public override void StartDriver()
        //{
        //    mIsrunning = true;            
        //}

        //[GingerAction("sum", "sum two numbers")]
        //public void Sum(ref GingerAction GA, int a, int b)
        //{
        //    string total = (a + b).ToString();
        //    GA.Output.Add("Total", total);

        //}
        // public string Name { get { return "My Service"; } }



        [GingerAction("Sum", "Sum two numbers")]
        public void Sum(IGingerAction GA, int a, int b)
        {
            //In

            //Act
            int total = a + b;

            //Out
            GA.AddOutput("a", a);
            GA.AddOutput("b", b);
            GA.AddOutput("Total", total);
        }

        [GingerAction("Divide", "Divide two numbers")]
        public void Divide(IGingerAction GA, int a, int b)
        {
            //In
            if (b == 0)
            {
                GA.AddError("Cannot divide by zero");
                return;
            }

            //Act
            int total = a + b;

            //Out
            GA.AddOutput("a", a);
            GA.AddOutput("b", b);
            GA.AddOutput("Sum", total);
        }

    }
}
