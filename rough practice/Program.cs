using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_pracitce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" this is me suman coding stuff today ");
            Console.WriteLine("please write your name ");

            String name = Console.ReadLine();
            Console.WriteLine("enter your age please ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("your name is    " + name + "  your age is   " + age);
            Console.WriteLine(" do you want to play the fibonacci game YES OR NO  ");


            string USERINPUT = Console.ReadLine();
            USERINPUT = USERINPUT.Trim();
            Console.WriteLine(USERINPUT);
            if (USERINPUT.Equals("YES", StringComparison.OrdinalIgnoreCase));
            {
                Console.WriteLine(" enter the number ");
                int number = Convert.ToInt32(Console.ReadLine());
                int Factorial = Fact(number);
                Console.WriteLine("the factorial of the number is   " + Factorial);


            }
            int Fact(int x)
            {
                if (x == 1|| x==0)
                {
                    return 1;
                }
                else return x * Fact(x - 1);
            }
        }
    }
}
