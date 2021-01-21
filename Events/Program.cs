using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Product harddisk = new Product(50);// harddisk Product sınıfından implemente edilirken product'ın ctoruna miktar parametre olarka gönderiliyor.
            harddisk.ProductName = "Hard disk";

            Product gsm = new Product(50);// gsm Product sınıfından implemente edilirken product'ın ctoruna miktar parametre olarka gönderiliyor.
            gsm.ProductName = "GSM";

            gsm.StockControlEvent += Gsm_StockControlEvent;// gsm stockControl eventine abone yapıldı(tab ile)

            for (int i = 0; i <=10; i++)//program çalışırken ilk defa buraya geldiğinde 10 tane satar.ardından 10 defa daha  döner.
            {
                harddisk.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()//gsm stockcontrolevent yazılırken tab a basıldığında event metodu tanımlanıyor.
        {
            Console.WriteLine ("GSM about to finish!");
        }
    }
}
