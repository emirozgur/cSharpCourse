using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3] //Array yoluyla tüm sınıflara erişilebilir.
            {
                new Customer{FirstName="engin"},
                new Student{FirstName="Derin"},
                new Person{FirstName="Salih"}

            };
            foreach (var person in persons)//person arrayinde elemanlara ulaşmak için döngü yazıldı.
            {
                Console.WriteLine(person.FirstName);
            }
            Console.ReadLine();
        }
    }
    class Person// Ana sınıf özelliklerini kalıtım yoluyla bırakabilir.
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Customer:Person// kalıtım alan sınıf kalıtım yoluyla özellik aldığı gibi kendi özellikleri de bulunabilir.
    {
        public string City { get; set; }
    }
    class Student : Person// kalıtım alan sınıf kalıtım yoluyla özellik aldığı gibi kendi özellikleri de bulunabilir.
    {
        public string Department { get; set; }
    }
}
