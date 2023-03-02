using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbdecker.Models
{
    public class EFMission09_dbdeckerRepository : IMission09_dbdeckerRepository
    {
        private BookstoreContext context { get; set; }

        public EFMission09_dbdeckerRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
