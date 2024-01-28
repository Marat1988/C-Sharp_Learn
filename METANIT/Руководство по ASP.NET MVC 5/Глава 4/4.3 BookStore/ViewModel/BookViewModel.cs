using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModel
{
    public class BookViewModel
    {
    

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        private DateTime? create;

        public DateTime? Create
        {
            get
            {
                return create;
            }
            set
            {
                create = value;
            }
        }

        public DateTime? DateCreate
        {
            get
            {
                //Price += 80000;
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Create.Value.Hour, Create.Value.Minute, Create.Value.Second);
            }
            set
            {
                DateCreate = value;
            }
        }
    }
}