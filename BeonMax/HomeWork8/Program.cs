using System;

/*Предположим, что логин\пароль для входа в систему: johnsilver\qwerty.

Запросить у пользователя логин и пароль. Дать пользователю только три попытки для ввода корректной пары логин\пароль.
Если пользователь произвёл корректный ввод, вывести на консоль: "Enter the System" и прекратить запрос логина\пароля.
Если пользователь ошибся трижды - вывести "The number of available tries have been exceeded" и прекратить запрос пары логин\пароль. */

namespace HomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "qwerty";
            string login = "johnsilver";
            int tries = 1;
            while (tries <= 3)
            {
                Console.WriteLine("Enter login");
                string userLogin = Console.ReadLine();

                Console.WriteLine("Enter pass");
                string userPass = Console.ReadLine();

                if (userLogin==login && userPass == password)
                {
                    Console.WriteLine("Enter the system.");
                    break;
                }
                tries++;
            }
            if (tries == 4)
            {
                Console.WriteLine("You exceeded the number of available tries.");
            }
        }
    }
}
