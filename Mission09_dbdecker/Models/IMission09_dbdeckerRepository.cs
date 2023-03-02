using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbdecker.Models
{
    public interface IMission09_dbdeckerRepository
    {
        IQueryable<Book> Books { get; }
    }
}
