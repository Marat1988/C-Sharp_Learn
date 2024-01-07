using System;
using System.Linq;

namespace DBFirstApp
{
    class Program
    {
        static  void Main(string[] args)
        {
            /*using(helloappContext db = new helloappContext())
            {
                bool isCreated = db.Database.EnsureCreated();
                //bool isCreated2 = await db.Database.EnsureCreatedAsync()
                if (isCreated) Console.WriteLine("База данных была создана");
                else Console.WriteLine("База данных существует");
            }*/

            /*using (helloappContext db = new helloappContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                //асинхронная версия
                //await db.Database.EnsureCreatedAsync();
                //await db.Database.EnsureDeletedAsync();
            }*/
            using (helloappContext db = new helloappContext())
            {
                bool isAvalaible = db.Database.CanConnect();
                //bool isAvalaible2 = await db.Database.CanConnectAsync()
                if (isAvalaible) Console.WriteLine("База данных доступна");
                else Console.WriteLine("База данных не доступна");
            }
        }
    }
}
