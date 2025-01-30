using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace todoapp
{
    internal class Program
    {


        private static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int count = 0;
            while (true)
            {
                Console.WriteLine("we are creating a todo app ");
                Console.WriteLine("add task");
                Console.WriteLine("view task");
                Console.WriteLine("remove task");

                String Task = Console.ReadLine();


                if (Task.Equals("add task", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("write the task that you want to add ");
                    string mytask = Console.ReadLine();
                    list.Add(mytask);
                    count++;
                    Console.WriteLine(count);

                }
                else if (Task.Equals("view task", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("inside view");

                    foreach (string task in list)
                    {
                        {
                            Console.WriteLine($"the item in the list is {task}");

                        }
                    }
                }
                else
                {
                    Console.WriteLine("invalid command ");
                }
            }



        }
    }
}



