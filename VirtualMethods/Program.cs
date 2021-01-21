using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();// Database sınıfından kalıtım alan SqlServer sınıfı için instance yazılmıştır.

            sqlServer.Add();//bu nesne sayesinde sql server sınıfındaki add metodu çağırılmış olup, sınıf içinde override edildiği için base metottan farklı çalışmıştır.

            MySql mySql = new MySql();//Database sınıfından kalıtım alan MySql sınıfı için instance yazılmıştır.

            mySql.Add();//Bu nesne sayesinde MySql sınıfındaki add metodu çağırılmış olup, sınıf içinde override edilmediği için base metodu çalışmıştır.

            Console.ReadLine();
        }
    }
    class Database
    {
        public virtual void Add()// Bazen ortak metotlar kullanılırken proje içinde metodun farklı çalıştırılmak(ezmek)gerekebilir.Virtual metotların temel özelliği üzerine yazılabilmesidir.(override)
        {
            Console.WriteLine("Added");
        }
        public virtual void Delete()
        {
            Console.WriteLine("Deleted");
        }
    }
    class SqlServer:Database
    {
        public override void Add()// Burada Add metodu override edilmiştir.(ezilmiş)
        {
            Console.WriteLine("Added by Sql code");
            //base.Add();
        }
    }
    class MySql:Database
    {
        public override void Add()//Virtual metot tanımlandığında fonksiyon çağırılırken temel metodun çalışacağı anlamında base deyimiyle kullanılır.
        {
            base.Add();
        }
    }
}
