using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public delegate void StockControl();
    public class Product
    {
        private int _stock;

        public Product(int stock)//Ctor program cs içinden implementasyon anında stok miktarı bu ctor vasıtasıyla alınıyor.
        {
            _stock = stock;//alınan miktar değeri _stock değişkenine atanıyor.
        }

        public event StockControl StockControlEvent;//event oluşturuldu
        public string ProductName { get; set; }//prop
        public int Stock {  //(prop)
            get 
            {
                return _stock;
            }
            set //setter propertysinde stock değişkenine gelen ve _stock değişkenine atanan  değeri value ile eşitledikten sonra eğer sayı 15 ten aşağıya düşmüşse stockcontrol eventi çalıştırılıyor.
            {
                _stock = value;
                if ( value<=15 && StockControlEvent!=null)
                {
                    StockControlEvent();
                }
            }
        }

        public void Sell(int amount)// program iinde inherit edilen harddisk veya gsm  değişkenlerinin sayıları sell fonksiyonuyla kullanılarak azaltılıyor.
        {
            Stock -= amount;
            Console.WriteLine("{1}Stock Amount:{0}", Stock,ProductName);
        }
    }
}
