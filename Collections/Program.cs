using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //(81)////////////////////// NEDEN COLLECTİON İHTİYACI VAR //////////////////////

            //string[] cities = new string[] { "Ankara", "İstanbul" };//(81)
            //cities = new string[3];//(81) Burada cities değişkenine yeni bir heap bölgesi atandı ve orası boş.
            //Console.WriteLine(cities[0]);//bu yüzden bu boş gelir.
            //Console.ReadLine();

            //(82)///////////////////////// ARRAYLİST İLE ÇALIŞMAK ///////////////////////////

            //ArrayList();

            //(83)///////////////////////// TİP GÜVENLİ KOLEKSİYONLARLA ÇALIŞMAK ///////////////////////////

            //List();

            //(86)///////////////////////// DİCTİONARY İLE ÇALIŞMAK ///////////////////////////

            Dictionary<string, string> dictionary = new Dictionary<string, string>();//(86)tanımlandı
            dictionary.Add("book", "kitap");//(86)elemaan eklendi
            dictionary.Add("table", "tablo");
            dictionary.Add("computer", "bilgisayar");

            foreach (var item in dictionary)//(86)okundu
            {
                Console.WriteLine(item.Value);//(86)fonksiyonlu okundu
            }

            Console.WriteLine(dictionary.ContainsKey("glass"));//(86)arama fonksiyonudur bool döndürür
            Console.WriteLine(dictionary.ContainsKey("table"));//(86)

            Console.ReadLine();
        }
        private static void List()
        {

            //(83)///////////////////////// TİP GÜVENLİ KOLEKSİYONLARLA ÇALIŞMAK ///////////////////////////

            List<string> cities = new List<string>();//(83)Liste oluşturuldu
            cities.Add("Ankara");//(83)elemanları eklendi
            cities.Add("İstanbul");
            foreach (var city in cities)//(83)okundu
            {
                Console.WriteLine(city);
            }

            //(83)Birinci yazım şekli
            List<Customer> customers = new List<Customer>//(83)Liste  Oluşturuldu ve içerisine Customer sınıfından propertyler instance edildi.
            {
            new Customer { Id = 1, FirstNAme = "Engin" },//(83)propertylere değerleri atandı
            new Customer { Id = 2, FirstNAme = "Derin" }
            };

            //(83)İkinci yazım şekli
            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id = 1, FirstNAme = "Engin" });
            //customers.Add(new Customer { Id = 2, FirstNAme = "Derin" });

            foreach (var customer in customers)//(83)ve okundu
            {
                Console.WriteLine(customer.FirstNAme);//(83)
            }


            //(84)///////////////////////// COLLECTİON ÖZELLİK VE METOTLARIYLA ÇALIŞMAK ///////////////////////////

            customers.AddRange(new Customer[2]//(84)Listeye dizi olarak eleman ekleme
                 {
                     new Customer{Id=4,FirstNAme="Ali"},//(84)Bu ekleme işlemini de yine Customer sınıfının propertylerine instance yoluyla yapıyoruz.
                     new Customer{Id=5,FirstNAme="Ayşe"}//(84)veritabanından grup halinde veri ekleme bu şekilde yapılır. 
                 });


            var count = customers.Count;//(84) Eleman sayısını verir
            var customer2 = new Customer { Id = 3, FirstNAme = "Salih" };//(84)Add için instance yapıldı
            customers.Add(customer2);

            Console.WriteLine("Count: {0}", count);//(84)


            //customers.Clear();//(84)elemanları temizler


            Console.WriteLine(cities.Contains("Ankara"));//(84) verilen listede verilen değer bulunursa true verir.

            Console.WriteLine(customers.Contains(new Customer { Id = 1, FirstNAme = "Engin" }));//Burada eleman listede olmasına rağmen false döner çünkü tanımlanan heap adresidir.(referans)


            //(85)///////////////////////// COLLECTİON ÖZELLİK VE METOTLARIYLA ÇALIŞMAK 2 ///////////////////////////

            var index = customers.IndexOf(customer2);//(85)verilen elemanın dizi içindeki indeksini verir.
            Console.WriteLine("Index: {0}", index);

            customers.Add(customer2);
            var index2 = customers.LastIndexOf(customer2);//(85)verilen elemanı dizide aramaya sondan başlar
            Console.WriteLine("Index2: {0}", index2);

            customers.Insert(0, customer2);//Listenin istenen indexine eleman yerleştirir.

            customers.Remove(customer2);//Listede aynı elemandan birden fazla varsa baştan itibaren ilk bulduğunu kaldırır.
            customers.RemoveAll(c => c.FirstNAme == "Salih");//verilen parametredeki elemanların hepsini kaldırır.
        }

        private static void ArrayList()//(82)
        {
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Adana");
            cities.Add(1);
            cities.Add('A');
            //(82) ArrayListler farklı tiplerle çalışmak için kullanılır. Acak genelde tek tiple(type safe) çalışılır.
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

        }
    }
    class Customer//(83)  Bu sınıf veritabanından customer tablosundan çekilen verilerin dolduurlmasına yadımcı olmak için oluşturuldu. Veritabanındaki veriler listeye alındıktan sonra buraya gönderilerek ayrıldı ve tekrar liste içine çekilerek okundu(hülle sınıfı)
    {
        public int Id { get; set; }
        public string FirstNAme { get; set; }
    }
}
