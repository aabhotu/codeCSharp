using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

interface IClassB
{
    public void ActionB();
}

interface IClassC
{
    public void ActionC();
}
class classC: IClassC {
    public classC() => Console.WriteLine("Class C");
    public void ActionC() => Console.WriteLine("Action in classC");
}
class classB: IClassB
{
    IClassC c_dependency;
    public classB(IClassC classc) => c_dependency = classc;
    public void ActionB()
    { 
        Console.WriteLine("Action in class B");
        c_dependency.ActionC();
    }
}

class ClassB2 : IClassB
{
    IClassC c_dependency;
    string message;
    public ClassB2(IClassC classc, string mgs)
    {
        c_dependency = classc;
        message = mgs;
        Console.WriteLine("ClassB2 is created");
    }
    public void ActionB()
    {
        Console.WriteLine(message);
        c_dependency.ActionC();
    }
}

class classA
{
    IClassB b_dependency;
    public classA(IClassB classb) => b_dependency = classb;
    public void ActionA()
    {
        Console.WriteLine("Action in classA");
        b_dependency.ActionB();
    }
}



class Program
{
    //Dung Factory
    public static IClassB CreateB2(IServiceProvider provider)
    {
        var b2 = new ClassB2(
                provider.GetService<IClassC>(),
                "Trong B2"
            );
        return b2;
    }

    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }

    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

        // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
        public MyService(IOptions<MyServiceOptions> options)
        {
            // Đọc được MyServiceOptions từ IOptions
            MyServiceOptions opts = options.Value;
            data1 = opts.data1;
            data2 = opts.data2;
        }
        public void PrintData() => Console.WriteLine($"{data1} - {data2}");
    }
    static void Main(string[] args)
    {
        //IClassC objectC = new classC();
        //IClassB objectB = new classB(objectC);
        //classA objectA = new classA(objectB);
        //objectA.ActionA();

        //Dki kieu AddSingleton
        //Cac kieu khac dki tuong tu
        var services = new ServiceCollection();

        //services.AddSingleton<IClassC, classC>();

        //var provider = services.BuildServiceProvider();

        //IClassC c = provider.GetService<IClassC>();

        //Console.WriteLine(c.GetHashCode());

        

        services.AddSingleton<classA>();
        //services.AddSingleton<IClassB, classB>();

        //Dung Delegate
        //services.AddSingleton<IClassB, ClassB2>(
        //    (provider) =>
        //    {
        //        var b2 = new ClassB2(
        //                provider.GetService<IClassC>(),
        //                "Trong ClassB2"
        //            );
        //        return b2;
        //    }
        //);

        //Dung Factory
        services.AddSingleton<IClassB>(CreateB2);
        services.AddSingleton<IClassC, classC>();

        services.Configure<MyServiceOptions>(
             options => {
                 options.data1 = "Thuy ne";
                 options.data2 = 2023;
             }
         );

        services.AddSingleton<MyService>();
        var provider = services.BuildServiceProvider();

        classA a = provider.GetService<classA>();
        a.ActionA();

        

        MyService myService = provider.GetService<MyService>();
        myService.PrintData();
    }
}
