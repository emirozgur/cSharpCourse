using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro(); //63. ve 64 ders metodu

            //InterfaceDemo();  // 65. ders metodu.

            ICustomerDal[] customerDals = new ICustomerDal[3] //3 veritabanı 
            {
                new SqlServerCustomerDal(),
                new OracleCustomerDal(), 
                new MySqlCustomerDal()
            };
            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }

            Console.ReadLine();
        }

        private static void InterfaceDemo()
        {
            CustomerMAnager customerManager = new CustomerMAnager(); // ICustomerDal arayüzü vasıtasıyla iki ayrı veritabanına kayıt yapabilmek için CustomerMAnager sınıfına instance hazırlandı.
            customerManager.Add(new OracleCustomerDal()); //Customermanager sınıfının içerisinden çağırılan bu add metodu içindeki nesneyle arayüze ve kalıtım yoluyla veritabanı işleme sınıflarına bağlı.  
        }

        private static void InterfacesIntro()//63. ve 64. derslerde işlenen konuların nesne ve metotlarını tek metot altında topladık. metodu yukarıda pasif yaptık.
        {
            PersonManager manager = new PersonManager();
            //manager.Add(new Customer{Id=1,FirtstName="Engin",LastName="Demir", Address="Ankara"});
            //Bu şekilde person manager içinden Add metodunu çağırırken metodun içinden parametre gönderirken tanımlayabileceğimiz gibi, 
            Customer customer = new Customer// Bu şekilde customer sınıfına erişim nesnesi tanımlayarak parametreleri nesne içerisinden doğrudan customer sınıfındaki property kısmınada gönderbiliriz.
            {
                Id = 1,
                FirtstName = "Engin",
                LastName = "Demi"
            };
            Student student = new Student
            {
                Id = 1,
                FirtstName = "Derin",
                LastName = "Demir",
                Department = "Computer"
            };
            manager.Add(customer);
            manager.Add(student);
        }
    }
    interface IPerson//Interface + TAb + Tab ile  oluşturduk. İçinde alt sınıflar tarafından ortak kullanılacak 3 özellek (property) tanımladık
    {
        int Id { get; set; }
        string FirtstName { get; set; }
        string LastName { get; set; }
    }
    class Customer : IPerson//müşteri sınıfı persondan kalıtım(inherit) aldı. içinde fazladan müşteriye ait adres özelliği eklendi.
    {
        public int Id { get; set; }
        public String FirtstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
    }
    class Student : IPerson//öğrenci sınıfı müşteriden kalıtım aldı. içinde öğrenciye ait bölüm özelliği tanımlandı(definition)
    {
        public int Id { get; set; }
        public String FirtstName { get; set; }
        public String LastName { get; set; }
        public String Department { get; set; }
    }
    class PersonManager
    {
        public void Add(IPerson person)//Bu metotta Iperson interface i üzerinden oluşturulan nesne,Iperson un kalıtım bıraktığı sınıflara erişmek için kullanılıyor.
        {
            Console.WriteLine(person.Id);
            Console.WriteLine(person.FirtstName);
            Console.WriteLine(person.LastName);
        }
    }
}
   