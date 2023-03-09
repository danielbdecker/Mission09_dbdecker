using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Mission09_dbdecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbdecker.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IMission09_dbdeckerRepository repo { get; set; }
        public CategoriesViewComponent(IMission09_dbdeckerRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
