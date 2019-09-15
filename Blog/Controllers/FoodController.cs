using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    public class FoodController : Controller
    {
        private ReadFile loadedEntries = new ReadFile();

        public FoodController()
        {
            loadedEntries = new ReadFile();
        }

        public IActionResult Food()
        {
            var content = loadedEntries.LoadEntries("/Users/hongle/Projects/Blog/Blog/Data");

            return View(content);
        }
    }
}
