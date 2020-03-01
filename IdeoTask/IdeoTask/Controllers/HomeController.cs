using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdeoTask.Models;
using IdeoTask.Services.CatalogService;
using IdeoTask.Services.Models;

namespace IdeoTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;

        public HomeController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var catalogs = _catalogRepository.GetBranches();
            var result = new CatalogViewModel
            {
                BranchList = catalogs
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Create()
        {

            return View("CreatePartialView");
        }
    }
}
