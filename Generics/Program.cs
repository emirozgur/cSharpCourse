using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            //////////////////////////////////// (105) GENERİC METOTLAR   ///////////////////////////////////////
            ///
            //Console.WriteLine("Hello World!");
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "İzmir", "Adana");//(105)utilities içinde string tipinde bir liste oluşturularak elemanları verildi ve result adlı aynı özellikli listeye eşitlendi.

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "Engin" }, new Customer { FirstName = "Derin" });//(105)customer sınıfnın içerisindekis firstname özelliğini(property) kullanarak utilities içindeki BuildList'e veriler gönderilip, result2 içine döndürülüyor. Burada Utilities içindeki BuildList Generic metottur.

            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.ReadLine();
        }
    }
    class Utilities//(105)
    {
        public List<T > BuildList<T>(params T[] items)//(105)generic metot main içindeki result listesini string işlerken, result2 den gelen parametreleri customer cinsinden (referans tip) işler. Paraametreler birden çok olduğu için params dizisiyle alınır.
        {
            return new List<T>(items);
        }
    }

    //////////////////////////////////// (104) GENERİC SINIFLAR   ///////////////////////////////////////
    ///
    class Product//(104) 2 Adet sınıfımız var. Yapılacak birbirinin aynısı olan veritabanı işlemleri için,bir adet Irepository generic sınıfı belirledik(burada  interface olmasına rağmen sınıf veya abstract sınıf da kullanılabilir.) 
        : IEntity//(105) generic kısıtları
    {

    }
    interface IProductDal : IRepository<Product>//(104)Ortak işlemlerde sorunsuz çalışmakla birlikte,DAL sınıflarında ürüne özel bir fazla işlem yapılmak istendiğinde, doğrudan IReposiity e bağlı dal sınıflarının o işlem iin tekrar implementasyonu gerekir. Bu yüzden DAL sınıfları ile generic sınıf(interface) arasına birer interface yazılmıştır.
    {

    }
    class Customer//(104) 2 adet sınıfın 2. si
        : IEntity//(105) generic kısıtları 
    {
        public string FirstName { get; set; }
    }
    interface ICustomerDal : IRepository<Customer>//(104) Customer grubunda ICustomerdal ile IRepository i bağlayan interface
    {

    }

    interface IStudentDal:IRepository<Student>//(105)Bu interface,Irepository generic sınıfından implemente edilmiştir. student sınıfı generic içindeki T nesnesine referans olarak gönderildiğinden ve Generic sınıfa kısıt uygulandığından IEntityden  implemente edilmeli ve new lenebilir olmalı.
    {

    }
    class Student: IEntity//(105)student sınıfı generic kısıtlarında IEntity den implemente edilmeli.
    {

    }
    interface IEntity//(105)kısıtlar buradan implementasyonu öngördü
    {

    }
    interface IRepository<T>//(104) IRepository interface i dal işlemlerinin ortak olanlarının yapılırken tekrardan kaçınmak için yazılmış bir generic sınıftır. işlemler buradan inherit edilerek yapılır.
        where T: class,IEntity, new()//(105)Burada generic sınıfa kısıtlar koymak için tanımlar yaptık class:referans tip olmalı, IENtity:buradan implemente edilmeli, new(): new lenebilir olmalı
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class ProductDal : IProductDal//(104)
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    class CustomerDal : ICustomerDal//(104)
    {
        void IRepository<Customer>.Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Customer>.Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        Customer IRepository<Customer>.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Customer> IRepository<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<Customer>.Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
