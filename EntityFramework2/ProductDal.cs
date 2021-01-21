using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace EntityFramework2
{
    public class ProductDal
    {
        /// <summary>
        /// //(101)/////////////////////////   LİSTELEME   ///////////////////////////////////////
        /// </summary>
        public List<Product> GetAll()//(101)
        {

            using (ETradeContext context = new ETradeContext())//(101)Using metodu parametre içinde yapılan implementasyonun, hafızada yer kaplaması istenmediği için, metot biter bitmez garbage collector beklenmeden hafızadan atmaya yarar.
            {
                return context.Products.ToList();//(101)Burada gridin veri kaynağı olarak,context içindeki products nesnesi çağırılıyor.products context içinde list olarak tanımlandığı ve product sınıfının propertylerinden veri setleri oluşturmada faydalandığı için listeye çevirilmelidir.Buradan nesne çağırılıdıktan sonra context içinde ve sonra App config içinde tanımlı sql bağlantı cümleleri vasıtasıyla sorgu yapılıp tekrar buraya çekilir.
            }
        }

        /// <summary>
        /// //(102)/////////////////////////   LİNQ  VERİTABANINDA SORGULAMA  ///////////////////////////////////////
        /// </summary>
        ///

        public List<Product> GetByName(string key)//(102)
        {

            using (ETradeContext context = new ETradeContext())//(102)Using metodu parametre içinde yapılan implementasyonun, hafızada yer kaplaması istenmediği için, metot biter bitmez garbage collector beklenmeden hafızadan atmaya yarar.
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();//(102)Burada gridin veri kaynağı olarak,context içindeki products nesnesi çağırılıyor.products context içinde list olarak tanımlandığı ve product sınıfının propertylerinden veri setleri oluşturmada faydalandığı için listeye çevirilmelidir.Buradan nesne çağırılıdıktan sonra context içinde ve sonra App config içinde tanımlı sql bağlantı cümleleri vasıtasıyla sorgu yapılıp tekrar buraya çekilir.
            }
        }

        /// <summary>
        /// //(103)///////////////////////// LİNQ  İLE FİLTRELEME ///////////////////////////////////////
        /// </summary>
        public List<Product> GetByUnitPrice(decimal price)//(103)
        {

            using (ETradeContext context = new ETradeContext())//(103)Using metodu parametre içinde yapılan implementasyonun, hafızada yer kaplaması istenmediği için, metot biter bitmez garbage collector beklenmeden hafızadan atmaya yarar.
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();//(103)Burada gridin veri kaynağı olarak,context içindeki products nesnesi çağırılıyor.Çağırılırken GetByUnitPrice ın parametresi olarak gelen değerin büyük eşiti olacak şekilde sorgu yapılıyor. Farklı sorgular= Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList(); iki fiyat arasını sorgular. 
            }
        }
        public Product GetById(int id)//(103)
        {

            using (ETradeContext context = new ETradeContext())//(103)Using metodu parametre içinde yapılan implementasyonun, hafızada yer kaplaması istenmediği için, metot biter bitmez garbage collector beklenmeden hafızadan atmaya yarar.
            {
                var result= context.Products.FirstOrDefault(p=>p.Id==id);//(103)Burada gridin veri kaynağı olarak,context içindeki products nesnesi çağırılıyor.Products,GetById metoduna gelen id parametresi tek olduğunda FirstOfDefault fonksiyonuyla ilk Id yi getirir. veri bulamassa null döndürür.
                return result;
            }
        }

        /// <summary>
        /// //(101)/////////////////////////   EKLEME   ///////////////////////////////////////
        /// </summary>
        public void Add(Product product)//(101)
        {
            using (ETradeContext context = new ETradeContext())//(101)
            {
                context.Products.Add(product);//(101)context teki products a pproduct ekle.
                //var entity = context.Entry(product);//(101)Buraya add  metodunun farkli bir yazim seklini uyguladik.
                //entity.State = System.Data.Entity.EntityState.Added;//(101)
                context.SaveChanges();//(101)yapılan işlemleri veritabanına yaz.
            }
        }


        /// <summary>
        /// //(101)/////////////////////////   GÜNCELLEME   ///////////////////////////////////////
        /// </summary>
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//(101)contexte bu ürün için abone ol:gönderilen productu veritabanındaki productla eşitler

                entity.State = System.Data.Entity.EntityState.Modified;//(101)Eşitlenmiş ürnün durumunun güncellenmesi.
                context.SaveChanges();//(101)yapılan işlemleri veritabanına yaz.
            }

        }

        /// <summary>
        /// //(101)/////////////////////////   SİLME   ///////////////////////////////////////
        /// </summary>
        public void Delete(Product product)//(101)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//(101)contexte bu ürün için abone ol:gönderilen productu veritabanındaki productla eşitler
                entity.State = System.Data.Entity.EntityState.Deleted;//(101)Eşitlenmiş ürnün durumunun silinnmesi.
                context.SaveChanges();//(101)yapılan işlemleri veritabanına yaz.
            }
        }


    }
}
