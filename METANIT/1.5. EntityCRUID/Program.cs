using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _1._5._EntityCRUID
{
    class Program
    {
        static void Main(string[] args)
        {
            async_example();
        }

        static void non_async_example()
        {
            //Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };

                //Добавление
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.SaveChanges();
            }

            //Получение
            using (ApplicationContext db = new ApplicationContext())
            {
                //получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            //Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                //Получаем первый объект
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //Обновляем объект
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                //выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            //Удаление
            using (ApplicationContext db = new ApplicationContext())
            {
                //Получаем первый объект
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //Удаляем объект
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                //выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }

        static async void async_example()
        {
            //Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };

                //Добавление
                await db.Users.AddRangeAsync(tom, alice);
                await db.SaveChangesAsync();
            }

            //Получение
            using (ApplicationContext db = new ApplicationContext())
            {
                //Получаем объекты из бд и выводим на консоль
                var users = await db.Users.ToListAsync();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            //Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                //Получаем первый объект
                User? user = await db.Users.FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //Обновляем объект
                    await db.SaveChangesAsync();
                }
                //Выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = await db.Users.ToListAsync();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            //Удаление
            using(ApplicationContext db = new ApplicationContext())
            {
                //Получаем первый объект
                User? user = await db.Users.FirstOrDefaultAsync();
                if (user != null)
                {
                    //удаляем объект
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                }
                //выводим данные после обновления
                Console.WriteLine("\nДанные после обновления");
                var users = await db.Users.ToListAsync();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}
