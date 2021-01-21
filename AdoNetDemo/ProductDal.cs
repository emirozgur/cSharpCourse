using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdoNetDemo
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\projects;initial catalog=ETrade;integrated security=true");//(95)Connection string oluşturuldu


        //(93)//////////////////////// LİSTELERLE ÇALIŞMAK //////////////////////////////

        public List<Product> GetAll()//(93)
        {

            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from products", _connection);//(93)sorgu nesnesi oluşturuldu.

            SqlDataReader reader = command.ExecuteReader();//(93)Datareader oluşturulup,sorgu nesnesiyle başlatıldı.

            List<Product> products = new List<Product>();//(93)Product sınıfına ait liste tanımlandı

            while (reader.Read())//(93)Okuma döngüsü oluşturuldu.
            {
                Product product = new Product//(93)Product sınıfına ait property metotlarını kullanmak için instance oluşturuldu.
                {
                    Id = Convert.ToInt32(reader["Id"]),//(93)Buradaki her bir nesne product sınıfında oluşturulmuş property nesneleridir.reader ile veritabanından çekerken veri object olarak geldiği için uygun formata dönüştürülmelidir.
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);//(93)product nesnesine yüklenen veriler products listesine gönderildi.
            }

            reader.Close();//(93)reader kapatıldı.
            _connection.Close();//(93)bağlantı kapatıldı
            return products;//(93)liste nesnesi çağırıldığı yere döndürüldü.


        }

        private void ConnectionControl()//(95) Refactor/extract method
        {
            if (_connection.State == ConnectionState.Closed)//(93)Connection kapalıysa açıldı.
            {
                _connection.Open();
            }
        }


        //(92)//////////////////////// VERİ LİSTELEMEYE GİRİŞ //////////////////////////////

        public DataTable GetAll2()
        {
            //SqlConnection connection = new SqlConnection(@"server=(localdb)\projects;initial catalog=ETrade;integrated security=true");//(92)Connection string oluşturuldu
            //if (_connection.State == ConnectionState.Closed)//(92)Connection kapalıysa açıldı.
            //{
            //    _connection.Open();
            //}
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from products", _connection);//(92)sorgu nesnesi oluşturuldu.

            SqlDataReader reader = command.ExecuteReader();//(92)Datareader oluşturulup,sorgu nesnesiyle başlatıldı.
            DataTable dataTable = new DataTable();//(92)Datatable oluşturuldu.
            dataTable.Load(reader);//(92)Datareader nesnesi içindeki veriler datatable nesnesine yüklendi.
            reader.Close();//(92)reader kapatıldı.
            _connection.Close();//(92)bağlantı kapatıldı
            return dataTable;//(92)datatable tablo nesnesi çağırıldığı yere döndürüldü.


        }


        //(95)//////////////////////// ÜRÜN EKLEME İŞLEMİNİN YAZILMASI //////////////////////////////

        public void Add(Product product)//(95) Burada metot tanımlanırken parametre alabilmesi için Product sınıfından instance yapılmış. Bu sayede Product sınıfının propertyleri kullanılabiliyor.
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Insert into Products values(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);//(95)sql cümlesinde Parametre kullanımında bu teknik kullanılır.Parantez içindeki kısımda parametreler sql cümlesinin içine atanır. Burada form içinden Product sınıfının property metotlarına gönderilen veriler çekiliyor. 
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);//(95)String birleştirme değil de bu şekilde parametreyle alınmasının sebebi sql injectiondan kurtulmak.
            command.ExecuteNonQuery();
            _connection.Close();
        }


        //(96)//////////////////////// GÜNCELLEME OPERASYONUNUN YAZILMASI //////////////////////////////


        public void Update(Product product)//(96) Burada metot tanımlanırken parametre alabilmesi için Product sınıfından instance yapılmış. Bu sayede Product sınıfının propertyleri kullanılabiliyor.
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            command.Parameters.AddWithValue("@name", product.Name);//(96)sql cümlesinde Parametre kullanımında bu teknik kullanılır.Parantez içindeki kısımda parametreler sql cümlesinin içine atanır. Burada form içinden Product sınıfının property metotlarına gönderilen veriler çekiliyor. 
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);//(96)String birleştirme değil de bu şekilde parametreyle alınmasının sebebi sql injectiondan kurtulmak.
            command.Parameters.AddWithValue("@id", product.Id);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        //(98)//////////////////////// SİLME İŞEMİNİN YAPILMASI //////////////////////////////
        public void Delete(int id)//(98) Burada metot doşarıdan parametre alacak şekilde tanımlandı.
        {
            ConnectionControl();//(98) Bağlantı açıldı.
            SqlCommand command = new SqlCommand(
                "Delete Products where Id=@id", _connection);//(98)Sql cümlesi gönderildi.

            command.Parameters.AddWithValue("@id", id);//(98) metot aparmetresi ile gelen değer sql cümlesine aktarıldı.

            command.ExecuteNonQuery();//(98)sorgu yapıldı
            _connection.Close();//(98)Bağlantı kapatıldı.
        }
    }
}
