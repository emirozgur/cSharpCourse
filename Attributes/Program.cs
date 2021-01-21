using System;
using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////(107)    ATTRİBUTE LERE GİRİŞ     ////////////////////////////////////
            ///
            Customer customer = new Customer { Id = 1, LastName = "Demiroğ", Age = 32 };//(107) customer içindeki propertylere parametre gönderiliyor
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);//(107) customerdal içinde add metodu, customer sınıfından implemente edilip, propertylerde işlenerek yüklenmiş cuustomer nesnesiyle dal işlemleri yapmak üzere çağırılıyor.
            Console.ReadLine();
        }
    }
    //////////////////////////////////(108)    ATTRİBUTE TARGETS VE ALLOW MULTİPLE    ////////////////////////////////////
    ///
    [ToTable("Customers")]//(107) parametreli attribute burada ToTable attribute u içindeki constructor a tabloya yerleştirmesi için tablo adı gönderiyor.
    [ToTable("TblCustomers")]//(108) AllowMultiple =true
    class Customer//(107) customer sınıfı içindeki propertylere parametresiz attribute ler yerleştirildi.
    {
        public int Id { get; set; }
        [RequiredProperty]//(107)required attribute u reflectionlarda işlenecek
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }


    class CustomerDal//(107) Dal işlemleri yapmak üzere yazıldı.
    {
        [Obsolete("Don't use Add, instead use AddNew Method")]//(107)Hazır Attribute ile programcı Add metodunun eski olduğu,yerine addnew metodunun kullanılması konusunda bilgilendirildi.
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} Added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} Added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

    }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]//(108)  Çoklu usage kullanımı pipe ile istenen kriterler eklenebilir. ya da AttributeTargets.All fonksiyonuyla kullanılabilir.
    class RequiredPropertyAttribute: Attribute//(107) parametresiz attribute gereklilik için kullanılıyor, reflectionlarda tamamlanacak.
    {

    }


    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]//(108)  Çoklu kullanım aktif edildiği zaman, aynı attribute birden fazla görevde kullanılabilir.
    class ToTableAttribute : Attribute//(107)Parametreli attribute totable ile constructoruna gönderilen "customers" tablo adı stringini işliyor 
    {
        private string _tableName;

        public ToTableAttribute(string tableName)//(107)Bu constructor ToTable attribute unun çağırıldığı yerden gönderilen tablo adı stringini("customers") işliyor.
        {
            _tableName = tableName;
        }
    }
}
