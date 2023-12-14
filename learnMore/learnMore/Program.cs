using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string[] Colors { get; set; }
    public int Brand { get; set; }
    public Product(int id, string name, double price, string[] colors, int brand)
    {
        ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
    }
    override public string ToString()
       => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
}

public class Brand
{
    public string Name { set; get; }
    public int ID { set; get; }
}
class Program
{
    static void Main(string[] args)
    {
        var brands = new List<Brand>() {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
        };

        var products = new List<Product>()
        {
            new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
            new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
            new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
            new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
            new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
            new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
            new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
        };
        //var query = from p in products
        //            where p.Price == 400
        //            select p;
        //foreach (var item in query) Console.WriteLine(item);

        //var kq = products.Select(
        //     (p) => p.Name
        //    );


        //var kq = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
        //{
        //    return new
        //    {
        //        Ten = p.Name,
        //        ThuongHieu = b.Name
        //    };
        //});
        //foreach(var product in kq) Console.WriteLine(product);

        //var kq = brands.GroupJoin(products, b => b.ID, p => p.Brand,
        //    (brand, pros) =>
        //    {
        //        return new
        //        {
        //            ThuongHieu = brand.Name,
        //            sanPham = pros
        //        };
        //    });
        //foreach(var p in kq)
        //{
        //    Console.WriteLine(p.ThuongHieu);
        //    foreach (var sp in p.sanPham) Console.WriteLine(sp);
        //}
        //products.Take(4).ToList().ForEach(p => Console.WriteLine(p));

        //products.SelectMany(p=>p.Colors).Distinct().ToList()
        //.ForEach(mau=>Console.WriteLine(mau));

        //products.Where(p => p.Price >= 300 && p.Price <= 400)
        //   .OrderByDescending(p => p.Price)
        //   .Join(brands, p => p.Brand, b => b.ID, (sp, th) =>
        //   {
        //       return new
        //       {
        //           tensp = sp.Name,
        //           tenTH = th.Name,
        //           gia = sp.Price
        //       };
        //   }
        //   )
        //   .ToList()
        //   .ForEach(i => Console.WriteLine($"{i.tensp,15}{i.tenTH,15} {i.gia,5}"));

        //var kq = from p in products
        //         join brand in brands on p.Brand equals brand.ID into t
         //         from b in t.DefaultIfEmpty()
        //         where (p.Price >= 300 && p.Price <= 400)
        //         orderby p.Price
        //         select new
        //         {
        //             tenSP = p.Name,
        //             thuongHieu = (b !=null) ? b.Name : "No brand"
        //         };
        //foreach(var item in kq)Console.WriteLine(item);


    }
}
