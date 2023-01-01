using System;

/*Запросить у пользователя не более 10 целых положительных чисел.
 * Пользователь может прекратить приём чисел, введя 0.

После прекращения приёма целых чисел (это происходит в случае если было введено 10 чисел, либо пользователь ввёл 0,
чтобы не вводить все 10) подсчитать среднее значение целых положительных чисел кратных трём и вывести на консоль. */

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            int inputCout = 0;
            while (inputCout < 10)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[inputCout] = number;
                inputCout++;

                if (number == 0)
                    break;
            }

            int sum = 0;
            int count = 0;

            foreach (int n in numbers)
            {
                if (n > 0 && n % 3 == 0)
                {
                    sum += n;
                    count++;
                }
            }

            double average = (double)sum / count;

            Console.WriteLine(average);
        }

    }
}
