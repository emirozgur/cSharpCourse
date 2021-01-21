using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();//(93) İşlemler Data Access Layer katmanı üzerinden yapılacağından,form içinde kullanılmak üzere bu ortak nesne yazılarak ProductDa sınıfına instance edildi.
        private void Form1_Load(object sender, EventArgs e)
        {

            //(93)//////////////////////// LİSTELERLE ÇALIŞMAK //////////////////////////////

            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }


        //(95)//////////////////////// ÜRÜN EKLEME İŞLEMİNİN YAZILMASI //////////////////////////////

        private void btnAdd_Click(object sender, EventArgs e)//(95)Ekleme butonu eventi
        {
            _productDal.Add(new Product //(95) Ekleme metodu parametre göndereceğinden Product sınıfına propertyleri kullanmak üzere instance edildi.
            {
                Name = tbxName.Text,//(95)Textboxlardan veriler çekildi ,convert edilerek property nesnelerine atandı
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),//(95)
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)//(95)
            });

            LoadProducts();

            MessageBox.Show("Product Added!");
        }


        //(97)//////////////////////// GÜNCELLEME İŞLEMİNİN YAPILMASI //////////////////////////////

        //(97) 96. Derste ProducDal içerisinde Update metodunu yazdık şimdi form olaylarını yazıyoruz.
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)//(97)Datagridview in içerisindeki verileri textboxlar yoluyla değiştirmek için öncelikle griddeki verileri textboxa geçmemiz lazım. bunun için grid eventlerindeki bu metodu kullanıyoruz. evente çift tıklayınca metot oluşuyor. bu metot sayesinde grid içinde seçtiğimiz satır ilgili textlere yükleniyor. 
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();//(97)
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();//(97)gridin seçilen satırının ilgili hücresindeki değeri ilgili textboxa yükler.
        }

        private void btnUpdate_Click(object sender, EventArgs e)//(97)update butonu textbox içinde yapılan değişiklikleri gride yüklemeye yarar.
        {
            Product product = new Product //(97)Product sınıfının property nesnelerine erişebilmek için product nesnesini implemente ettik.
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),//(97)Bu değer güncellenmeyeceği için doğrudan gridden çekiyoruz.
                Name=tbxNameUpdate.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)//(97) Diğer değerler textboxlarda değiştirilmiş hallariyle geri yüklenecekleri için textboxlardan çekiyoruz.
            };

            _productDal.Update(product);//(97)product nesnesine yüklenen veriler _productDal nesnesiyle ProductDal sınıfı içindeki update metoduna gönderildi. 

            LoadProducts();//(97)Grid yeniden yüklendi.
            MessageBox.Show("Updated");
        }

        //(98)//////////////////////// SİLME İŞEMİNİN YAPILMASI //////////////////////////////

        private void btnRemove_Click(object sender, EventArgs e)//(98)Silme butonu yapıldı
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);//(98)oluşturulan id değişkenine gridin seçili satırının 0 dizinli hücresinin değeri atandı.
            _productDal.Delete(id);//(98)İşlemler Data Access Layer katmanı üzerinden yapılacağından,form içinde kullanılmak üzere implemente edilen bu _productDal nesnesi üzerinden Delete metodu çağrılarak parametre olarak id değişkeni gönderildi.
            LoadProducts();//(98)Grid yeniden yüklendi.
            MessageBox.Show("Deleted!");
        }
    }
}
