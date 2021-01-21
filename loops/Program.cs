using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loops
{

    class Program
    {
        static void Main(string[] args)
        {
            //ForLoop();

            int number = 100;
            while (number>=0)
            {
                Console.WriteLine(number);
                number--;
            }
            Console.WriteLine("now number is: {0}",number);
            Console.ReadLine();

        }

        private static void ForLoop()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Finished");
        }
    }
}
