using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            ////////////////////////////////////(109) REFLECTİON GİRİŞ  /////////////////////////////////////////
            ///

            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine( dortIslem.Topla2());
            //Console.WriteLine( dortIslem.Topla(3,4));

            ////////////////////////////////////(110) METHOD İNFO VE İNVOKE/////////////////////////////////////////
            ///

            var type = typeof(DortIslem);//(110)//(109)Çalıştırma anında gelen tip bilinmeyeceği için bilinen kısım olan dortişlem tipi değişkene atanıyor


            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,6,7);//(109)Bu işlem new lemenin aynısıdır. parantez içindeki dortislem sınıfına cast(döküm,rol dağıtma) deniyor.
            //Console.WriteLine( dortIslem.Topla(4,5));//(109)Topla metodu çalıştırılacaksa burada parametre gönderebilmek için Dortislem içinde boş constructor olmalı
            //Console.WriteLine(dortIslem.Topla2());//(109)Topla 2 metodu çalıştırılacaksa parametreler activator içinden gönderilmeli

            var instance = Activator.CreateInstance(type, 6, 7);//(110)Bu işlem new lemenin aynısıdır. ancak daha sonra kullanabilmek için değişkene atanmıştır.

            Console.WriteLine( instance.GetType().GetMethod("Topla2").Invoke(instance,null));//(110)Burada info ve invoke bir arada.

            MethodInfo methodInfo= instance.GetType().GetMethod("Topla2");//(110)Burada info ve invoke ayrıldı. Burası info kısmı. methodInfo nesnesi oluşturuldu.
            methodInfo.Invoke(instance, null);//(110)Burada info nesnesi invoke edildi(çalıştırıldı).

            ////////////////////////////////////(111) REFLECTİON İLE DETAYLAR/////////////////////////////////////////
            ///

            Console.WriteLine("-------------------------------------");//(111)

            var metotlar = type.GetMethods();//(111)reflection ile classın sahip olduğu metotlara ulaşma.

            foreach (var info in metotlar)//(111)reflection ile classın sahip olduğu metotları yazdırma

            {
                Console.WriteLine("Metot adı: {0}", info.Name);
                foreach (var parameterInfo in info.GetParameters())//(111)reflection ile metotların sahip olduğu parametrelere ulaşma.
                {
                    Console.WriteLine("parametre: {0}", parameterInfo.Name);//(111)reflection ile metotların sahip olduğu parametreleri yazdırma
                }
                foreach (var attribute in info.GetCustomAttributes())//(111)reflection ile metotların sahip olduğu attribute lara ulaşma.
                {
                    Console.WriteLine("Attribute Name: {0}", attribute.GetType().Name);// (111)reflection ile metotların sahip olduğu attribute leri yazdırma.
                }
            }

            Console.ReadLine();
        }
    }
    public class DortIslem//(109)//(110)
    {
        int _sayi1;
        int _sayi2;
        public DortIslem(int sayi1, int sayi2)//(109)dortislem'in dolu coonstructoru buraya parametreler activator içinden gelir
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()//(109)DortIslem'in boş connstructoru buraya parametreler çağırıldığı yerden gelir
        {

        }
        public int Topla(int sayi1, int sayi2)//(109)buraya parametreler boş constructor vasıtasıyla gelir
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)//(109)buraya parametreler boş constructor vasıtasıyla gelir
        {
            return sayi1 * sayi2;
        }
        public int Topla2()//(110)//(109)buraya parametreler dolu constructor vasıtasıyla gelir
        {
            return _sayi1 + _sayi2;
        }

        [MethodName("Çarpma")]//(111)reflection için custom attribute yazma
        public int Carp2()//(109)buraya parametreler dolu constructor vasıtasıyla gelir
        {
            return _sayi1 * _sayi2;
        }

        public class MethodNameAttribute: Attribute//(111)reflection için custom attribute yazma
        {
            public MethodNameAttribute(string name)//(111)reflection için yazılan custom name attribute'une ulaşmak için constructor gerekir
            {
                    
            }
        }

    }
}
