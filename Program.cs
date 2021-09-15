using System;
using System.Threading;

namespace Analysis_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к текстовому файлу:");
            string adressFile = Console.ReadLine();

            //Передаем во второй поток параметр и запускаем его.
            Thread threadAnalisisText = new Thread(new ParameterizedThreadStart(Analysis.AnalysisText));
            threadAnalisisText.Start(adressFile);

            Console.ReadKey();
        }

        
    }
}
