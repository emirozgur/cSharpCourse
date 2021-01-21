using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationED2013
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add4(1, 2, 3, 4, 5, 6));
            Console.ReadLine();
        }
        static int Add4(params int [] numbers)
        {
            return numbers.Sum();
            
        }
    }
}
