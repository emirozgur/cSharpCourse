using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new SqlServer();//Abstract classların instance ı yazılırken kendi adına yazılır fakat implemente edildiği sınıfın heap bölgesini kullanırlar.Böylece tamamlanmış metotları kalıtımla olduğu gibi bırakırken abstract metotları override edilerek kullanılır.

            database.Add();
            database.Delete();

            Database databse2 = new Oracle();

            databse2.Add();
            databse2.Delete();

            Console.ReadLine();
        }
    }
    abstract class Database//Absatract class lar interfaceler ile virtual metotların birleşimi gibi çalışırlar. Başka sınıflarca implemente  edilebilirler,abstract metotları vardır, instance ederken hangi sınıflarca implemente edilmişseler o sınıf heap bölgesini kullanırlar.
    {
        public void Add()
        {
            Console.WriteLine("Added by default.");
        }
        public abstract void Delete();//Abstract metot içi dolu olmayan virtual metottur. abstract keywordüyle yazılıp,override keywordüyle altsınıfta override edilirler.
    }
    class SqlServer : Database
    {
        public override void Delete()//Burada abstract metot olan delete override edilmiştir
        {
            Console.WriteLine("Deleted by Sql");
        }
    }
    class Oracle : Database
    {

        public override void Delete()//Burada abstract metot olan delete override edilmiştir.
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }
}
