using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumApp.Models;
using ForumApp.Data;
using ForumApp.ViewModels.Home;
using ForumApp.Services;

namespace ForumApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            this.categoryService = categoryService;
           
        }

        public IActionResult Index()
        {
            var model = new List<IndexCategoriesViewModel>();

            var categories = categoryService.GetAll();

            foreach (var item in categories)
            {
                var category = new IndexCategoriesViewModel
                {
                    Description=item.Description,
                    ImageUrl= item.ImageUrl,
                    Name=item.Name,
                    Title=item.Title,
                    PostSCount=item.Posts.Count()
                };

                model.Add(category);
            }
            

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
