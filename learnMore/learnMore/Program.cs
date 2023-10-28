using System;
using System.Collections.Generic;


class Program
{
    static void DoSomeThing(int seconds, string message, ConsoleColor color)
    {
        //Thread.Sleep(seconds);
        Console.ForegroundColor = color;
        Console.WriteLine($"{message} ...... Start");
        Console.ResetColor();

        for(int i = 1; i <= seconds; i++)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message} {i}");
            Console.ResetColor();

            Thread.Sleep( 1000 );
        }
        Console.ForegroundColor = color;
        Console.WriteLine($"{message} ..... End");
        Console.ResetColor();
    }

    static async Task Task2()
    {
        Task t2 = new Task(
            () => {
                DoSomeThing(4, "Thao", ConsoleColor.Blue);
            }
         );
        t2.Start();
        await t2;
        Console.WriteLine("Done t2");
    }

    static async Task Task3()
    {
        Task t3 = new Task(
           (object ob) => {
               string tentacvu = (string)ob;
               DoSomeThing(5, tentacvu, ConsoleColor.Yellow);
           }
        , "Thuy");
        t3.Start();
        await t3;
        Console.WriteLine("Done t3");
    }

    static void Main(string[] args)
    {
        Task t2 = Task2();
        Task t3 = Task3();
       

        //DoSomeThing(3, "tt", ConsoleColor.Yellow);
        //DoSomeThing(4, "hh", ConsoleColor.Blue);
        DoSomeThing(6, "Abu", ConsoleColor.Magenta);
    }
}
