using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorker[] workers = new IWorker[3] //Her bir arayüz için dizi oluşturularak içerisine erişimi istenen çalışan gruplarının her biri için  nesne örneği (instance) oluşturuldu.
            {
                new Manager(),
                new Worker(),
                new Robot()
            };

            foreach (var work in workers) // IWorker arayüzü için oluşturulan workers instance dizisinin elemanlarını gezebilmek için foreach döngüsü yazıldı.
            {
                work.Work();
            }

            IEat[] eaters = new IEat[2] //Her bir arayüz için dizi oluşturularak içerisine erişimi istenen çalışan gruplarının her biri için  nesne örneği (instance) oluşturuldu.
            { 
                new Manager(),
                new Worker()
            };

            foreach (var eat in eaters) // IEat arayüzü için oluşturulan eaters instance dizisinin elemanlarını gezebilmek için foreach döngüsü yazıldı.
            {
                eat.Eat();
            }
            
        }

    }
    interface IWorker//farklı çalışan gruplarına farklı işleri yaptırmak için 3 adet arayüz tanımlandı
    {
        void Work();

    }
    interface IEat 
    {
        void Eat();
    }
    interface ISalary
    {
        void GetSalary();
    }
    class Manager : IWorker, IEat, ISalary //Yönetici sınıfı çalışanlar için 3 fonksiyon çalıştırabilmek amacıyla 3 arayüz aynı anda implemente edildi.
    {

        public void Work()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void GetSalary()
        {
            throw new NotImplementedException();
        }
    }
    class Worker : IWorker, IEat, ISalary //İşçi sınıfı çalışanlar için 3 fonksiyon çalıştırabilmek amacıyla 3 arayüz aynı anda implemente edildi.
    {

        public void Work()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void GetSalary()
        {
            throw new NotImplementedException();
        }
    }
    class Robot : IWorker //Robot sınıfı çalışanlar için  diğer çalışan sınıflarında farklı olmak üzere 1 fonksiyon çalıştırabilmek amacıyla 1 arayüz implemente edildi.
    {

        public void Work()
        {
            throw new NotImplementedException();
        }
    }
}
