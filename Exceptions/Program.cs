using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //(87)////////////////////////////EXCEPTİON İNTRO///////////////////////////////

            //ExceptionIntro();//(87)

            //(88)/////////////////////KENDİ HATA SINIFIMIZI YAZALIM///////////////////////////////


            try//(88)//Bu kod front-end kodudur.
            {
                Find();//(88)//Bu metot Back-endde hatanın yakalanıp, kontrol altına alınması için yazıldı.
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);////(88)Recordnotfound constructorundan base sınıfın (Exception) message özelliğine tanımlanan string bu teknikle gösteriliyor.
            }


            //(89)/////////////////////ACTİON DELEGASYONU İLE PROFESYONEL HATA YAKALAMA///////////////////////////////


            HandleException(() => //(89)Delegate Kullanımı:Metoda parametre olarak süslü parantez içini veriyoruz
            {
                Find();//(89)HandleException metodunun içindeki Invoke fonksiyonu ile find metodu çalıştırılır
            });
            
 
            Console.ReadLine();
        }

        private static void HandleException(Action action)//(89)Bu metot Action delegate ini kullanıyor. ve Find metodunu parametre olarak alıyor.
        {
            try
            {
                action.Invoke();//(89)Find metodunu çalıştır 
            }
            catch (Exception exception)//(89)Hataya özel mesajı Exception sınıfında alarak çalıştırır. (Örn RecordNotFoundException)
            {
                Console.WriteLine(exception.Message);//(89)Hata neyse ona ait hata mesajını gösterir. Bunun için o hatalara ait sınıflar tanımlanıp,hata mesajları belirlenmiş olmalıdır.
                
            }
        }

        private static void Find()//(89)//Bu metot Back-endde hatanın yakalanıp, kontrol altına alınması için (Handling) yazıldı Burada bu hatanın kontrol edilmesinin amacı kullanıcıya doğru mesajı verip yönlendirmektir. RecordNotFoundException sınıfıyla beraber çalışır.
        {
            List<string> students = new List<string> { "Engin", "Derin", "Salih" };//(88)

            if (!students.Contains("Ahmet"))//(89)Öğrenciler içinde ahmet yoksa
            {
                throw new RecordNotFoundException("Record not found");//(89)Hata yakalamak için oluşturulmuş sınıfın constructoruna mesaj stringini gönderiyoruz.
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        private static void ExceptionIntro()//(87)
        {
            try
            {
                string[] students = new string[3] { "Engin", "Derin", "Salih" };//(87)
                students[3] = "Ahmet";
            }
            catch (IndexOutOfRangeException exception)//(87)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DivideByZeroException exception)//(87)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)//(87)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
