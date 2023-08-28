// class Product{
//         public string Name{get; set; }
//         public double Price { get; set; }
//         public int ID { get; set; }
//         public string Origin { get; set; }
//     }
//     static void Main(string[] args)
//     {
//         // List<int> dsach1 = new List<int>() { 1, 2, 3, 4, 5, 6};
//         // dsach1.Add(1);
//         // dsach1.AddRange(new int[] {3,4,5});
//         // Console.WriteLine(dsach1.Count);
//         // foreach(var i in dsach1) { 
//         //     Console.WriteLine(i);
//         // }
//         // var n = dsach1.Find(
//         //     e => {
//         //         return e % 2 == 0;
//         //         }
//         // );
//         // Console.WriteLine(n);
//         List<Product> products = new List<Product>() {
//             new Product() {
//                 Name = "IpX", Price = 1000, ID = 1, Origin = "China"
//             },
//             new Product() {
//                 Name = "IP14", Price = 2000, ID = 2, Origin = "China"
//             },
//             new Product() {
//                 Name = "SamSung", Price = 1200, ID = 3, Origin = "Korea"
//             },
//         };

//         // var sps = products.FindAll(
//         //     e => {
//         //         return e.Price < 2000;
//         //     }
//         // );
//         // foreach (var sp in sps){
//         //     Console.WriteLine($"{sp.Name} - {sp.Price} - {sp.Origin}");
//         // }

//         products.Sort(
//             (p1, p2) => {
//                 // 0 p1 == p2
//                 // 1 p1 > p2
//                 // -1 p1 < p2
//                 if (p1.Price == p2.Price) return 0;
//                 if (p1.Price > p2.Price) return 1;
//                 return -1;
//             }
//         );
//         foreach (var sp in products){
//             Console.WriteLine($"{sp.Name} - {sp.Price} - {sp.Origin}");
//         }
//     }