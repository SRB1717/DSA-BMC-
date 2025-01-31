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


        private static  void Main(string[] args)
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
                    

                    foreach (string task in list)
                    {
                        {
                            Console.WriteLine($" {task}");

                        }
                    }
                }
                else if (Task.Equals("remove task", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("which task do you want to remove you have following task ");
                    foreach (string task in list)
                    {
                        Console.WriteLine(task);

                    }
                    string itemdel = Console.ReadLine();
                    for (int j = 0; j < count; j++)
                    {
                        if (list[j].Equals(itemdel, StringComparison.CurrentCultureIgnoreCase))
                        {
                            list.RemoveAt(j);
                            Console.WriteLine($"the elemet {itemdel} is deleted successfully ");
                            break;

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



