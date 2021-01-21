using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReferanceAndValueType
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;

            number2 = number1;//Her ikiside değer tiptir bu durumda number2 değeri10 olmuştur.
            number1 = 30;//değer tiplerde değerin kendi değişir number1 değişse bile

            Console.WriteLine(number2);//number210 olarak kalmıştır.

            //Refrans tiplerde durum farklıdır
            string[] cities = new string[] { "Ankara", "Adana", "Afyon" };//101 Heap adresi olarak tanmıştır
            string[] cities2 = new string[] { "Bursa", "Bolu", "Balıkesir" };//102 Heap adresi olarak atanmıştır.
            //101
            cities2 = cities;//Burada cities2 ye cities in heap aresi atanmıştır.
            cities[0] = "İstanbul";//cities refrans adresinde olan değişiklikler o refrans adresini taşıyan değişkenleri etkiler

            Console.WriteLine(cities2[0]);//cities2 nin 0. elemanı istanbuldur.

            DataTable dataTable;// =new DataTable() burada bellek performansını etkilememk için new lemeye gerek yoktur.
            DataTable dataTable2 = new DataTable();//2 nesnesi oluşturulup,
            dataTable = dataTable2;//doğrudan eşitlenebilir.

            Console.ReadLine();
        }
    }
}
