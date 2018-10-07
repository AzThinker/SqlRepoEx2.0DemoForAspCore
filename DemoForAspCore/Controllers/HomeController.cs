using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DemoTools.BLL.DemoNorthwind;
using Microsoft.AspNetCore.Mvc;
using SqlRepoEx.Abstractions;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryFactory repositoryFactory;
        IRepository<AzCustomers> repository;

        public HomeController(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.repository = repositoryFactory.Create<AzCustomers>();

           
            

        }
        public IActionResult Index()
        {

            var results = repository.Query().SelectAll().Page(20,1).Go();

           
            return View(results);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
