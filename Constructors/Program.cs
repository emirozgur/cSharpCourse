using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            //(75)//////////////////////YAPICI BLOKLARA GİRİŞ(CONSTRUCTOR)/////////////////////////////////

            //(75)constructor lar bir sınıf new lendiğinde çalışacak kod bloğudur.
            CustomerManager customerManager = new CustomerManager(10);//(75)İnstance içinden değer gönderilirse içi dolu olan constructor, değer gönderilmezse içi boş olan constructor çalışır.
            customerManager.Add();

            //(76)///////////////////////NESNE ÖRNEKLERİ İÇİN CONSTRUCTOR////////////////////////////////////

            Product product = new Product(1,"bv");//(76)buradan değerler constructor içine gönderiliyor
            Product product2 = new Product { Id = 1, Name = "laptop" };// (76)burada değerler doğrudan propertylere set ediliyor.

            //(77)//////////////////////////////////CONSTRUCTOR İNJECTİON////////////////////////////////////

            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());//(77)Hülle nesnei kullanımında artık Log metodunun hangi sınıf içinde çalıştırılacağını  instance ın constructor bölümünden parametre olarak gönderiyoruz.
            //employeeManager.Logger = new FileLogger();//(77) EmployeeManager içinde property den interface e erişim sağlarken burada çalışacak log metodunun databaselogger dan mı yoksa filelogger sınıfından mı çalışacağını bu heap atamasıyla yapıyorduk.
            employeeManager.Add();

            //(78)///////////////////////TEMEL SINIFIN YAPICI BLOĞUNA PARAMETRE GÖNDERME/////////////////////////

            PersonManager personManager = new PersonManager("product");//(78)
            personManager.Add();//(78)

            //(79)//////////////////////////////STATİC CLASS VE METOTLAR/////////////////////////////////////////

            Teacher.Number = 10;//(79)Static nesneler çağırılırken instance üretmeye gerek yoktur.

            Utilities.Validate();//(79) Sınıf static ise metot static olmak zoundadır.

            Manager.DoSomething();//(79)Sınıf static değilse de altında metot static tanımlanabilir bu durumda instance a gerek yoktur.

            Manager manager = new Manager();//(79)static olamayan sınıfın altındaki static olmayan metot için yine instance gerekir.
            manager.DoSomething2();//(79)

                
            

            Console.ReadLine();
        }
    }
    class CustomerManager//(75)//////////////////////YAPICI BLOKLARA GİRİŞ(CONSTRUCTOR)/////////////////////////////////
    {
        private int _count=15;//(75)Constructor içine gönderilen değeri sınıf içindeki diğer metotlarda kullanmaya yarayan nesne(private field) burada default değer atanmıştır.
        public CustomerManager(int count)//(75)bu constructor instance içinden değer gönderildiği zaman çalışacaktır ve gelen değeri count'a yükleyip metot içinde _count private field'ına yükler
        {
            _count = count;
             
        }
        //(75)constructor overload edilebilir aşağıdaki constructor boş olduğundan instance içinden değer gönderilmezse çalışır.
        public CustomerManager()//(75)
        {

        }
        public void List()
        {
            Console.WriteLine("Listed!");//(75)
        }
        public void Add()
        {
            Console.WriteLine("Added {0} items", _count);//(75)
        }
    }
    class Product//(76)///////////////////////////////NESNE ÖRNEKLERİ İÇİN CONSTRUCTOR///////////////////////////////
        //(76) Busınıfta constructorun iki farklı parametreli kullanım örneği var
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)//(76)bu constructora değerler product instance ıyla parametre olarak gönderiliyor
        {
            _id = id;//(76)Burada constructor metoda gelen parametreler sınıf içinde kullanım için private fieldlara atanıyor.
            _name = name;
        }
        public int Id { get; set; }//(76)Bu property lere değerler product2 instance ıyla {} içinden hazır gönderiliyor
        public string Name { get; set; }
    }
    interface ILogger//(77)////////////////////////CONSTRUCTOR İNJECTİON//////////////////////////////
    {
        void Log();
    }
    class DatabaseLogger : ILogger//(77)
    {
        public void Log()
        {
            Console.WriteLine("Logged to Database");
        }
    }
    class FileLogger : ILogger//(77)
    {
        public void Log()
        {
            Console.WriteLine("Logged to File");
        }
    }
    class EmployeeManager//(77)
    {
        //public ILogger Logger { get; set; }//(77) önceden property içerisinde interface erişimi için nesne tanımlayıp, add metodu içinde property den log metodunu çekiyorduk. main içinde de instance a ilgili sınıfın heap adresini gösteriyorduk.
        private ILogger _logger;//(77) bu private nesne arayüz tipi değişken olarak 
        public EmployeeManager(ILogger logger)//(77) Artık bu constructor metot sayesinde Hangi sınıf içinden çalışacağı main içindeki instance'tan parametre olarak alınan değer arayüz cinsinden belirlenmiş bu logger nesnesine atanıyor.
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added");
        }
    }
    class BaseClass//(78)//////////////TEMEL SINIFIN YAPICI BLOĞUNA PARAMETRE GÖNDERME///////////////////
    {
        private string _entity;//(78)dahili nesne
        public BaseClass(string entity)//(78)alt sınıfın ctorundan parametre aldı
        {
            _entity = entity;   
        }
        public void Message()//(78) Message metodu burada yazılı _enity nesnesinden gelen değeri işliyor
        {
            Console.WriteLine("{0} message", _entity);//(78)
        }
    }

    class PersonManager : BaseClass//(78)Bu sınıf mainden gelen parametreyi ctoru vasıtasıyla base e gönderiyor basede işlenn parametre Add içinde Message metoduyla birlikte maine dönüyor. 
    {
        public PersonManager(string entity):base(entity)//(78)main içindeki instance da gelen parametre Base sınıfın ctoruna gönderildi. Bu constructor bu işe yarıyor. 
        {

        }
        public void Add()//(78)main içindeki instance da çağırılan metot base içindeki message metoduyla birlikte çalıştı.
        {

            Console.WriteLine("Added!");
            Message();//(78)Base den geldi.
        }
    }
    static class Teacher//(79)Static nesneler ortak nesnelerdir. herhangi bir yerde doğrudan kullanılabilirler
    {
        public static int Number { get; set; } //(79)Static classların alt nesneleri static olmak zorundadır.
    }
    static class Utilities
    {
        public static void Validate()//(79)
        {
            Console.WriteLine("validation is done.");
        }
    }
    class Manager
    {
        public static void DoSomething() 
        {
            Console.WriteLine("done");
        }
        public void DoSomething2()
        {
            Console.WriteLine("Done 2");

        }
    }

}
