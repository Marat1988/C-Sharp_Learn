using System;
using System.Linq;

namespace DBFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(helloappContext db = new helloappContext())
            {
                //Получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов: ");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}
