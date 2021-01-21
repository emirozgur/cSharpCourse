using System;

namespace Delegates
{
    class Program
    {

        /// <summary>
        /// /////////////////////////////(112)  DELEGELERE DETAYLI GİRİŞ   /////////////////////////////////////
        /// </summary>
        public delegate void MyDelegate();//(112)Parametresiz delege

        public delegate void MyDelegate2(string text);//(112)Parametreli delege oluşturuldu.

        public delegate int MyDelegate3(int number1, int number2);//(112)İnt cinsinde parametreli delegate
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();//(112)Customer manager instance

            Matematik matematik = new Matematik();//(112) Matematik sınıfı için instance yazıldı MyDelegate3 bu sınıfı kullanıyor.

            //customerManager.SendMessage();
            //customerManager.ShowAllert();

            MyDelegate myDelegate = customerManager.SendMessage;//(112)delege oluşturuldu ve send message yüklendi
            

            myDelegate += customerManager.ShowAllert;//(112)Delegeye show alert eklendi

            myDelegate -= customerManager.SendMessage;//(112)delegeden sendmessage çıkarıldı


            MyDelegate2 myDelegate2 = customerManager.SendMessage2;//(112)2. delege instance edildi ve send message yüklendi

            myDelegate2 += customerManager.ShowAllert2;//(112)2. delegeye showalert eklendi


            MyDelegate3 myDelegate3 = matematik.Topla;//(112)MyDelegate3 için instance.Matematik nesnesiyle Matematik sınıfından Topla metodunu çalıştırmak üzere atandı.

            myDelegate3 += matematik.Carp;//(112)myDelegate 3 e  çarp metodu eklendi ancak burada yine parametre kısıtından dolayı son yazılan çalışacak.

            int sonuc= myDelegate3(2, 3);//(112) matematik.Topla parametreli olduğundan burada çağırılırken parametreleri gönderiliyor. Dönen değeri ekrana yazdırabilmek için sonuc değişkeni üretildi. 

            Console.WriteLine(sonuc);//(112)

            myDelegate2("Hello2");//(112)Burada delegede 2 metot olmasına rağmen gönderilebilecek tek string olduğundan, her iki metoda da parametre olarak aynoı string gönderilir ve ekrana 2 defa yazar bu kısıttır.

            myDelegate();//(112)Delege çağırıldı


            Console.ReadLine();
        }
    }
    public class CustomerManager//(112)
    {
        public void SendMessage()//(112)Parametresiz 
        {
            Console.WriteLine("Hello");
        }
        public void ShowAllert()//(112)Parametresiz
        {
            Console.WriteLine("Be Careful!");
        }
        public void SendMessage2(string message)//(112)Parametreli
        {
            Console.WriteLine(message);
        }
        public void ShowAllert2(string alert)//(112)Parametreli
        {
            Console.WriteLine(alert);
        }
    }
    public class Matematik//(112) int delegate için matematik sınıfı yazıldı
    {
         public int Topla(int sayi1, int sayi2)//(112)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)//(112)
        {
            return sayi1 * sayi2;
        }
    }
}
