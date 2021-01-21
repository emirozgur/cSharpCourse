using System;
using System.Collections.Generic;
using System.Data.Entity;//(100)Burada NuGet kütüphanesinden .net FrameworkcoreSqlServer alındığı zaman ona gereken relational ve core kütüphaneleri de gelecektir. Bu tamamlanınca projede references altında kütüphaneler görünür.
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2
{
    public class ETradeContext: DbContext//(100)contextimizin dbcontext sınıfından kalıtım alması için nugetler yüklenmelidir.
    {
        public DbSet<Product> Products { get; set; }//(100)(generic)Bu property form içinden çekilen sorguyu, product sınıfından implemente edilen Products nesnesi vasıtasıyla veri seti(liste) olarak veritabanından almaya/işlemeye yarar. Sorgu cümlesi ve diğer bilgiler App.config içindedir. <connectionStrings> <add name = "ETradeContext"connectionString = "server = (localdb)\mssqllocaldb; initial catalog = ETrade; integrated security = true" providerName = "System.Data.SqlClient"/> </connectionStrings>
    }
}
