using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220, Create = new DateTime(2023, 12, 31, 14, 15, 25) });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180, Create = new DateTime(2023, 2, 22, 14, 16, 17) });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150, Create = new DateTime(2024, 1, 26, 15, 13, 22) });
            base.Seed(db);
        }
    }
}