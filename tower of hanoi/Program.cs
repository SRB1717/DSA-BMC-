using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace tower_of_hanoi
{
    internal class Program
    {

        static void tower_of_hanoi(int N, String source, String helper, String destination)
        {
            if (N == 1)
            {
                Console.WriteLine(" moved   " + source + "to destination  " + destination);
                return;

            }
            tower_of_hanoi(N - 1, source, destination, helper);

            Console.WriteLine(" moved   " + source + "to destination  " + destination);

            tower_of_hanoi(N - 1, helper, source, destination);


        }


        static void Main(string[] args)
        {
            tower_of_hanoi(4, "A", "B", "C");

        }
    }
}
