using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();//customerManager sınıfı instance ı yazıldı ve metot çağırıldı.
            customerManager.logger = new DatabaseLogger();//customeManager sınıfı içinden logger nesnesi vasıtasıyla instance hazırlanarak Databaselogger sınıfının heap bölümü adres gösterildi. Böylece customerManager sınıfı içerisinden Add metodu çalışırken logger.log=>Ilogger.logger=>Ilogger.log çalışırken,heap vasıtasıyla ilgili sınıfın içindeki değerleri döndürecek.
            customerManager.Add();

            customerManager.logger = new SmsLogger();//tek komutla ve ardışık olarak databaselogger çalışırken smslogger da çalışıyor.
            customerManager.Add();
            Console.ReadLine();
        }
    }
    
    class CustomerManager
    {
        public ILogger logger { get; set; }//
        public void Add()//ekleme metodunun içinde eklemeden önce loglama yapacağız bu yüzden logger interface ine ait property nesnesi tanımlanarak nesne üzerinden interface içindeki Log metodu çağırıldı.
        {
            logger.Log();//Log metodu bu sınıf üzerinden çağırılarak, işaret edidiği heap adresi vsıtasıyla tanımlandığı sınıflardaki değerleriyle çalıştırılacak.
            Console.WriteLine("Customer added!");
        }
    }
    interface ILogger
    {
        void Log();//Log metodu içi boş bir metod olup,interface üzerinden çağırıldığı yerde aynı zamanda bir heap adresi gösterilerek hangi çalışma alanında  içi doldurulduysa oradaki değerleri çalıştırmak üzere çağırılır.
    }
    class DatabaseLogger:ILogger//ILogger interface i implemente edilerek interface içindeki Log metodu sınıf içinde tanımlanıp içi sınıfa göre dolduruldu
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }
    class FileLogger : ILogger//ILogger interface i implemente edilerek interface içindeki Log metodu sınıf içinde tanımlanıp içi sınıfa göre dolduruldu
    {

        public void Log()
        {
            Console.WriteLine("Logged to File");
        }
    }
    class SmsLogger : ILogger//ILogger interface i implemente edilerek interface içindeki Log metodu sınıf içinde tanımlanıp içi sınıfa göre dolduruldu
    {

        public void Log()
        {
            Console.WriteLine("Logged to Sms");
        }
    }
    
}
