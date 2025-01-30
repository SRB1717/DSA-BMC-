using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    internal class Program
    {
        static int  factorial(int x)
        {






            if (x == 1 || x == 0) return 1;
            int factorialIS = x * factorial(x - 1);

            return factorialIS;
        }

        static void Main(string[] args)
        {
           
            Console.WriteLine("what factorail do you realy nead");
            int p = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(factorial(p));
            
                

            
        }
    }

}
