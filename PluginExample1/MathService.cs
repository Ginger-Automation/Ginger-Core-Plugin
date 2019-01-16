

using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PluginExample1
{
    [GingerService("MathService", "Math", "Math service")]
    public class MathService 
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

        [GingerAction("PrimeFactorization", "find the prime factorization of a number")]
        public void PrimeFactorization(IGingerAction GA, int number)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //In            

            //Act
            var primes = new List<int>();

            // Option 1
            //for (int div = 2; div <= Math.Sqrt(number); div++)
            //{
            //    while (number % div == 0)
            //    {
            //        primes.Add(div);
            //        number = number / div;
            //    }
            //}

            // Option 2
            int div = number;
            for (int b = 2; div > 1; b++)
            {
                while (div % b == 0)
                {
                    div /= b;
                    primes.Add(b);
                }
            }


            

            //Verify
            int total = 1;
            foreach (int num in primes)
            {
                total = total * num;
            }
            if (total != number)
            {
                GA.AddOutput("Validation Failed, total=", total);
                GA.AddError("Validation Failed, total=" + total);
            }

            //Out                        
            int i = 0;
            foreach (int prime in primes)
            {
                i++;
                GA.AddOutput(i + "", prime);
            }

            string result = string.Join(",", primes.Select(n => n.ToString()).ToArray());
            GA.AddOutput("Result", result);
            GA.AddOutput("Count", i);

            GA.AddExInfo("Found: " + i + " primes");

            stopwatch.Stop();
            GA.AddOutput("Elapsed", stopwatch.ElapsedMilliseconds);
        }

        [GingerAction("Factors", "find the factors of a number")]
        public void Factors(IGingerAction GA, int number)
        {
            //In            
            GA.Log("Factors for - " + number);
            //Act
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  
            for (int factor = 1; factor <= max; ++factor)
            { 
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)   // see if can remove do test for it
                    { 
                        factors.Add(number / factor);
                    }
                }
            }

            //Out
            
            string result = string.Join(",", factors.Select(n => n.ToString()).ToArray());
            GA.AddOutput("Result", result);
            GA.AddOutput("Count", factors.Count);

            GA.AddExInfo("Found: " + factors.Count + " primes");
        }


    }
}
