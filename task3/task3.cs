using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace task3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            float[,] queues = Queues(args);
            Console.WriteLine(MaxQueue(queues));
            Console.ReadLine();
        }

        static List<float> LinesFromFile(string path)
        {
            List<float> list = new List<float>();
            List<string> lines = File.ReadAllLines(path).ToList();
            foreach (var elem in lines)
                list.Add(float.Parse(elem));
            return list;
        }

        static float[,] Queues(string[] args)
        {
            string[] files = { "Cash1.txt", "Cash2.txt", "Cash3.txt", "Cash4.txt", "Cash5.txt" };
            float[,] queues = new float[5, 16];
            for (int i = 0; i < 5; i++)
            {
                string finalPath = null;
                finalPath += args[0] + "\\" + files[i];
                List<float> queue = LinesFromFile(finalPath);
                for (int j = 0; j < 16; j++)
                {
                    queues[i, j] = queue[j];
                }
            }
            return queues;
        }

        static int MaxQueue(float[,] queues)
        {
            float max = 0;
            int maxAvgId = 0;
            for (int i = 0; i < 16; i++)
            {
                float sum = 0;
                for (int j = 0; j < 5; j++)
                    sum += queues[j, i];
                if (sum > max)
                {
                    max = sum;
                    maxAvgId = i + 1;
                }
            }
            return maxAvgId;
        }
    }
}
    

