using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonaccci
{
    internal class Program
    {
         static int  fibonaccci(int x)
        {
            if (x == 0 || x == 1)
            {
                return 1;

            }
            else
            {
                int first = fibonaccci(x-1);
                int second = fibonaccci(x-2);
               
                return first + second;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("PLESE WRITE THE NUMBER THAT YOU HAVE TO CALCULATE THE FIBONACCI OF ");
            int p =Convert.ToInt32(Console.ReadLine());
            for (int x  = 0; x < p; x++)
            {
                int y = fibonaccci(x);
                Console.Write("    "+y);
               
            }


        }
    }
}
