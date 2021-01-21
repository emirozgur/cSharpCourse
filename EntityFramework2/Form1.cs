using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _producDal = new ProductDal();//(101)form içinde kullanmak için ProductDaldan implementasyon
        private void Form1_Load(object sender, EventArgs e)
        {
            //using (ETradeContext context=new ETradeContext())//(100)Using metodu parametre içinde yapılan implementasyonu, hafızada yer kaplaması istenmediği için metot biter bitmez garbage collector beklenmeden hafızadan atmaya yarar.
            //{
            //    dgwProducts.DataSource = context.Products.ToList();//(100)Burada gridin veri kaynağı olarak,context içindeki products nesnesi çağırılıyor.products context içinde list olarak tanımlandığı ve product sınıfının propertylerinden veri setleri oluşturmada faydalandığı için listeye çevirilmelidir.Buradan nesne çağırılıdıktan sonra context içinde ve sonra App config içinde tanımlı sql bağlantı cümleleri vasıtasıyla sorgu yapılıp tekrar buraya çekilir.
            //}

            LoadProducts();//(101)gridi doldur

        }


        /// <summary>
        /// //(101)/////////////////////////   LİSTELEME   ///////////////////////////////////////
        /// </summary>
        private void LoadProducts()//(101)Refactor
        {
            dgwProducts.DataSource = _producDal.GetAll();//(101) ProducDal içindeki Getall da context var App.config içindeki cümlelerle sorgu yapıyor. dgwproducts'un veri kaynağı bu contexttir.
        }

        /// <summary>
        /// //(102)///////////////////////// LİNQ  LİSTEDE / VERİTABANINDA SORGULAMA ///////////////////////////////////////
        /// </summary>
        private void SearchProducts(string key)//(102)
        {
            //var result= _producDal.GetAll().Where(p=>p.Name.ToLower().Contains(key.ToLower())).ToList();//(102) ProducDal içindeki Getall da context var App.config içindeki cümlelerle sorgu yapıyor. dgwproducts'un veri kaynağı bu contexttir.
            //(102)ProductDal içindeki GetAll vasıtasıyla sorguyu yapıp tüm ürünleri getirdikten sonre liste içinde sorgula: p için p nin adının key içerenlerini alıp, Gridin veri kaynağına ata. Burada veritabanı sorgulanıp veriler geldikten sonra veri seti içinde arama yapıyoruz.
            //(102) ToLower ifadeleri büyük küçük harf duyarlılığını aşmak için kullanılmıştır.

            var result = _producDal.GetByName(key);//(102) Veritabanından sorgulama

            dgwProducts.DataSource = result;


        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)//(102)
        {
            //MessageBox.Show(tbxSearch.Text);
            SearchProducts(tbxSearch.Text);
        }

        /// <summary>
        /// //(103)///////////////////////// LİNQ  İLE FİLTRELEME ///////////////////////////////////////
        /// </summary>

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _producDal.GetById(10);
        }


        /// <summary>
        /// //(101)/////////////////////////   EKLEME   ///////////////////////////////////////
        /// </summary>
        /// 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _producDal.Add(new Product //(101)ProductDal içindeki Add'de context var Product içindeki nesneleri kullanarak, ETradecontex/App.Config içindeki sorgu cümleleri vasıtasıyla veritabanına ekleme yapar
            {
                Name = tbxName.Text,//(101)Ekleme textboxlardan yapılır.
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });

            LoadProducts();//(101)gridi doldur

            MessageBox.Show("Added!");
        }


        /// <summary>
        /// //(101)/////////////////////////   GÜNCELLEME   ///////////////////////////////////////
        /// </summary>
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)//(101)Güncelleme işlemi gridde seçilen satırdaki vrilerin textboxlara doldurulmasıyla yapılır.
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _producDal.Update(new Product //(101)ProductDal içindeki update'te context var. Product içindeki nesneleri kullanarak, ETradecontex/App.Config içindeki sorgu cümleleri vasıtasıyla veritabanına güncelleme yapar.
            {
                Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),//(101)CellClick ile doldurulan ve kullanıcı tarafından değiştirilen veriler, güncelleme için contexte gönderilir.
                Name =tbxNameUpdate.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount=Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            LoadProducts();//(101)gridi doldur
            MessageBox.Show("Updated!");
        }



        /// <summary>
        /// //(101)/////////////////////////   SİLME   ///////////////////////////////////////
        /// </summary>

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _producDal.Delete(new Product//(101)ProductDal içindeki Delete'te context var. Product içindeki nesneleri kullanarak, ETradecontex/App.Config içindeki sorgu cümleleri vasıtasıyla veritabanında silme yapar
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)//(101)Silmeye gridin seçilen satırının Id sini göndermek yeterli.
            });
            LoadProducts();//(101)gridi doldur.
            MessageBox.Show("Deleted!");
            
        }

        
    }
}
