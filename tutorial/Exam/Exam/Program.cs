using System;

namespace Exam
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();

            LogDel logSrceenDel, logFileDel;

            logSrceenDel = new LogDel(log.LogText);
            logFileDel = new LogDel(log.LogTextToFile);

            //LogDel logDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = logSrceenDel + logFileDel;
            var name = Console.ReadLine();
            //logDel(name);
            //multiLogDel(name);
            LogText(logSrceenDel, name);

            Console.ReadKey();
        }  
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }
    public class Log {
        public void LogText (string text)
        {
            Console.WriteLine($"{DateTime.Now} : {text}");
        }
        public void LogTextToFile(string text){
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log.txt"), true)){
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }
    }
}