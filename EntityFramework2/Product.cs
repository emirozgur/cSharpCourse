using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2

{
    public class Product
    {
        //(100) Product sınıfı propertylerinden, implemente edildiği sınıflara, veritabanından sütun karşılığı olacak şekilde yararlandırır.
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
