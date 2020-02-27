using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null)
            {
                string path = args[0];
                List<int> list = LinesFromFile(path);
                if (list != null)
                {
                    int[] mass = list.ToArray();
                    Array.Sort(mass);
                    Counter counter = new Counter { Mass = mass };
                    Console.WriteLine(string.Format("{0:N2}", counter.Percentile_90()));
                    Console.WriteLine(string.Format("{0:N2}", counter.Median()));
                    Console.WriteLine(string.Format("{0:N2}", counter.Max()));
                    Console.WriteLine(string.Format("{0:N2}", counter.Min()));
                    Console.WriteLine(string.Format("{0:N2}", counter.Mean()));
                }
                Console.ReadLine();
            }
        }

        static  List<int> LinesFromFile(string path)
        {
            List<int> list = new List<int>();
             string line = null;
             using (StreamReader sr = new StreamReader(path))
             {
                while (true)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    if (line == null) break;
                    list.Add(Int32.Parse(line));
                }
             }
            return list;
        }
        class Counter
        {
            public int[] Mass { get; set; }
            
            public double Percentile_90()
            {
                double n = (double)90 / 100 * (Mass.Length - 1) + 1;
                double percentile = Mass[Convert.ToInt32(n)-1] + (Convert.ToDouble(Mass[Convert.ToInt32(n)]- Mass[Convert.ToInt32(n) - 1])) * (n - Convert.ToInt32(n));
                return  percentile;
            }
            public double Median()
            {
                if (Mass.Length%2==0)
                    return (Convert.ToDouble(Mass[(Mass.Length-1)/ 2]) + Convert.ToDouble(Mass[(Mass.Length-1) /2 ])) / 2;
                return Convert.ToDouble(Mass[Mass.Length / 2]);
            }

            public double Min()
            {
                return Convert.ToDouble(Mass[0]);
            }

            public double Max()
            {
                return Convert.ToDouble(Mass[Mass.Length-1]);
            }

            public double Mean()
            {
                double sum = 0;

                foreach (var e in Mass)
                    sum += e;
                return sum / Mass.Length;
            }
             
        }
    }
}
