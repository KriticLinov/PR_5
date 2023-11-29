using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_5_task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите целое число:");
            int N = int.Parse(Console.ReadLine());

            double sum = 0;

            for (double i = 0; i <= N; i++)
            {
                sum += Math.Pow((N + i), 2);
            }
            Console.WriteLine($"Сумма: {sum}");

            Console.ReadKey();
        }
    }
}
