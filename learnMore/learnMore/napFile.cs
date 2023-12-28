//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using Microsoft.Extensions.Configuration.Json;

//class Program
//{

//    public class MyServiceOptions
//    {
//        public string data1 { get; set; }
//        public int data2 { get; set; }
//    }
//    public class MyService
//    {
//        public string data1 { get; set; }
//        public int data2 { get; set; }
//        public MyService(IOptions<MyServiceOptions> options)
//        {
//            var opts = options.Value;
//            data1 = opts.data1;
//            data2 = opts.data2;
//        }
//        public void PrintData()
//        {
//            Console.WriteLine($"{data1} - {data2}");
//        }
//    }
//    static void Main(string[] args)
//    {

//        IConfigurationRoot configRoot;
//        ConfigurationBuilder configBulder = new ConfigurationBuilder();
//        configBulder.SetBasePath(Directory.GetCurrentDirectory());
//        configBulder.AddJsonFile("cauhinh.json");

//        configRoot = configBulder.Build();

//        var service = new ServiceCollection();
//        service.AddSingleton<MyService>();
//        service.Configure<MyServiceOptions>(
//            configRoot.GetSection("MyServiceOption")
//       );
//        var provider = service.BuildServiceProvider();

//        var myservice = provider.GetService<MyService>();
//        myservice.PrintData();
//    }
//}
