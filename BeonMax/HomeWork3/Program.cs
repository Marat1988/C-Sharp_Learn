using System;

/*Запросить у пользователя: фамилию, имя, возраст, вес, рост.
 * Рассчитать ИМТ (индекс массы тела) по формуле ИМТ = вес (кг) / (рост (м) * рост (м))
 * Сформировать единую строку, в следующем формате:
 * Your profile:
 * Full Name: фамилия, имя
 * Age: рост
 * Weight: вес
 * Height: рост
 * Body Mass Index: ИМТ
Вывести сформированную строку на консоль.*/

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your last name?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What's first name?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What's age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("What's your weight in kg?");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("What's your height in meters?");
            double height = double.Parse(Console.ReadLine());

            double bodyMassIndex = weight / (height * height);

            string profile =
                $"Your profile: {Environment.NewLine}"
                + $"Full Name: {lastName} {firstName}{Environment.NewLine}"
                + $"Age: {age}{Environment.NewLine}"
                + $"Weight: {weight}{Environment.NewLine}"
                + $"Height: {height}{Environment.NewLine}"
                + $"Body Mass Index: {bodyMassIndex}";
            Console.WriteLine(profile);

        }
    }
}
