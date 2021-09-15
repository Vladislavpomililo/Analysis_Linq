using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Analysis_Linq
{
    class Analysis
    {
        public static void AnalysisText(object adressObj )
        {
            //Таймер времени обработки текста
            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();

            string adressFile = adressObj.ToString();

            string text = File.ReadAllText(adressFile, Encoding.GetEncoding(65001));
            //запросом LINQ и методом Parts сортируем обьекты 
            var groups = Parts(text, 3)
               .Where(str => str.All(ch => char.IsLetter(ch)))
               .GroupBy(str => str);
            // запросом LINQ фильтруем обьекты
            Console.WriteLine(string.Join(Environment.NewLine, groups.OrderByDescending(gr => gr.Count()).Take(10).Select(gr => $"\"{gr.Key}\" встретилось {gr.Count()} раз")));

            //останавливаем таймер и переводим полученый результат в миллисекунды.
            stopWatch1.Stop();
            TimeSpan ts1 = stopWatch1.Elapsed;
            var time = ts1.Minutes * 60000 + ts1.Seconds * 1000 + ts1.Milliseconds;
            Console.WriteLine($"\nВремя работы программы: " + time + " миллисекунд.");
        }

        private static IEnumerable<string> Parts(string source, int length)
        {
            for (int i = length; i <= source.Length; i++)
                yield return source.Substring(i - length, length);
        }
    }
}
