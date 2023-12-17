//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class User
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public string PhoneNumber { get; set; }
//    public string Email { get; set; }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        User user = new User()
//        {
//            Name = "ThaoNguyen",
//            Age = 21,
//            PhoneNumber = "0918775755",
//            Email = "nguyenthithuy@gmail.com"
//        };

//        var properties = user.GetType().GetProperties();
//        foreach (var property in properties)
//        {
//            var name = property.Name;
//            var value = property.GetValue(user);
//            Console.WriteLine($"{name} : {value}");
//        }
//    }
//}
