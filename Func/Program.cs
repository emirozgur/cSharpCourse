using System;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = Topla;// func 1. kullanım
            Console.WriteLine(add(4, 5));

            Func<int> getRandomNumber = delegate () //func 2. kullanım
            {
                Random random = new Random();
                return random.Next(1, 100);
            };
            Console.WriteLine(getRandomNumber());

            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);// func 3. kullanım.
            Console.WriteLine(getRandomNumber2());



            Console.WriteLine(Topla(2, 3));
            Console.ReadLine();
        }
        static int Topla(int x, int y)
        {
            return x + y;
        }
    }
}
