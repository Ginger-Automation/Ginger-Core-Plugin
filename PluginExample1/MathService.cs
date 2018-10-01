

using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PluginExample1
{
    [GingerService("MathService", "Math service")]
    public class MathService : IGingerService
    {
       
        [GingerAction("Sum", "Sum two numbers")]
        public void Sum(IGingerAction GA, int a, int b)
        {
            Console.WriteLine(DateTime.Now + "> Sum: " + a + "+" + b);
            //In

            //Act
            int total = a + b;            

            //Out
            GA.AddOutput("a", a);
            GA.AddOutput("b", b);
            GA.AddOutput("Total", total);

            GA.AddExInfo(a + "+" + b + "=" + total);
        }

        [GingerAction("Divide", "Divide two numbers")]
        public void Divide(IGingerAction GA, int a, int b)   // convert to decimal
        {
            //In
            if (b == 0)
            {
                GA.AddError("Cannot divide by zero");
                return;
            }

            //Act
            int result = a / b;

            //Out
            GA.AddOutput("a", a);
            GA.AddOutput("b", b);
            GA.AddOutput("Result", result);
        }


    }
}
