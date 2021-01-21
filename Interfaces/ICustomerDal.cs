using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface ICustomerDal//Dal:Data Access Layer
    // Bu interface iki ayrı veritabanına veri işlemleri yapmak için oluşturuldu.
    {
        void Add();
        void Update();
        void Delete();

    }
    class SqlServerCustomerDal : ICustomerDal//sql servere veri işlemek için bu sınıf olşturuldu ve Icustomerdal arayüzüne  bağlandı.
    {

        public void Add()
        {
            Console.WriteLine("Sql Added");
        }

        public void Update()
        {
            Console.WriteLine("Sql Updated");
        }

        public void Delete()
        {
            Console.WriteLine("Sql Deleted");
        }
    }
    class OracleCustomerDal : ICustomerDal// bu sınıf oracle veritabanına veri işlemek için oluşturldu ve arayüze bağlandı.
    {

        public void Add()
        {
            Console.WriteLine("Oracle Added");
        }

        public void Update()
        {
            Console.WriteLine("Oracle Updated");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle Deleted");
        }
    }

    class MySqlCustomerDal : ICustomerDal // bu sınıf yeni bir veritabanı ekleme örneği için 65. derste yazıldı. diğer veritabanı sınıflarının aynısıdır. Projeye yeni bir veritabanı eklenmek istendiğinde doğrudan buraya yeni veritabanına işlem yapacak ve ICustomerDal arayüzünden implemente edilmiş bu sınıf eklenerek,Program.cs içinden dizi nesnesi aracılığıyla çağırıldı. ve tüm veritabanlarına aynı anda tek komutla aynı işlemi yapacak yetenek kazanıldı.Böylece projeye esneklik ve modüler yapı kazandırıldı.
    {

        public void Add()
        {
            Console.WriteLine("MySql Added");
        }

        public void Update()
        {
            Console.WriteLine("MySql Updated");
        }

        public void Delete()
        {
            Console.WriteLine("MySql Deleted");
        }
    }
    class CustomerMAnager// bu sınıf her iki veritabanını da arayüz aracılığıyla kullanabilmek için yazıldı. İnterface ler diğer sınıflar içerisinden doğrudan çağırılamadığı için bu hülle sınıfı oluşturuldu.
    {
        public void Add(ICustomerDal customerDal) // bu add metodu her iki veritabanına arayüzden referans alarak veri ekleme yapar. Programcs içerisinden bu metot çağırılacak.
        {
            customerDal.Add();
        }
    }
}
