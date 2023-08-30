using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnMore
{
    internal class sortedList
    {
            class Product{
            public string Name{get; set; }
            public double Price { get; set; }
            public int ID { get; set; }
            public string Origin { get; set; }
        }
        static void sortedList1(string[] args){
            SortedList<string, Product> products = new SortedList<string, Product>();
            products["sanpham1"] = new Product() {Name = "san pham1", Price = 1000, Origin = "sanpham1"};
            products["sanpham2"] = new Product() {Name = "san pham2", Price = 1200, Origin = "sanpham2"};
            products.Add("sanpham3", new Product() {Name = "san pham3", Price = 1100, Origin = "sanpham3"});

            var p = products["sanpham2"];
            Console.WriteLine(p.Name);

            // var keys = products.Keys;
            // var values = products.Values;
            // foreach (var key in keys) {
            //     var product = products[key];
            //     Console.WriteLine(product.Name);
            // }

            foreach (KeyValuePair<string,Product> i in products) {
                var key = i.Key;
                var value = i.Value;
                Console.WriteLine($"{key} - {value.Name}");
            }
            // products.Remove("sanpham123");
            // products.RemoveAt(0);
        }
    }
}
