using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_dbdecker.Models;
using Mission09_dbdecker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbdecker.Controllers
{
    public class HomeController : Controller
    {
        private IMission09_dbdeckerRepository repo;
        public HomeController(IMission09_dbdeckerRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null 
                    ? repo.Books.Count() 
                    : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

    }
}
