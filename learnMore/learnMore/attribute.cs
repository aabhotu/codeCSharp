//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;


//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
//public class MotaAttribute : Attribute
//{
//    public string Thongtinchitiet { get; set; }
//    public MotaAttribute(string _Thongtinchitiet)
//    {
//        Thongtinchitiet = _Thongtinchitiet;
//    }
//}

//[Mota("Lop chua thong tin nguoi dung")]
//public class User
//{
//    [Mota("ten nguoi dung")]
//    public string Name { get; set; }
//    [Mota("TUoi nguoi dung")]
//    [Range(18, 80, ErrorMessage = "Tuoi khong hop le")]
//    public int Age { get; set; }
//    [Phone]
//    public string PhoneNumber { get; set; }
//    [EmailAddress]
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

//        ValidationContext context = new ValidationContext(user);
//        var result = new List<ValidationResult>();

//        bool kq = Validator.TryValidateObject(user, context, result, true);
//        if (kq == false)
//        {
//            result.ToList().ForEach((er) =>
//            {
//                Console.WriteLine(er.ErrorMessage);
//            });
//        }

//        //var properties = user.GetType().GetProperties();
//        //foreach(var property in properties)
//        //{
//        //    foreach(var attr in property.GetCustomAttributes(false)){
//        //        MotaAttribute mota = attr as MotaAttribute;
//        //        if(mota != null)
//        //        {
//        //            Console.WriteLine(mota.Thongtinchitiet);
//        //        }
//        //    };
//        //}
//    }
//}
