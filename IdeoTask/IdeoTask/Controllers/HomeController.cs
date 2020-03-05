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
using IdeoTask.Services.Model;

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
        public IActionResult Index(string? sort)
        {
            var categories = _catalogRepository.GetAllCatalogs();
            var branches = _catalogRepository.GetBranches(SortType.NameAsc);
            if (sort == "NameAsc")
                branches = _catalogRepository.GetBranches(SortType.NameAsc);
            else if(sort == "NameDesc")
                branches = _catalogRepository.GetBranches(SortType.NameDesc);
            else if (sort == "DateAsc")
                branches = _catalogRepository.GetBranches(SortType.DateAsc);
            var result = new CatalogViewModel
            {
                BranchList = branches,
                Catalogs = categories
            };
            return View(result);
        }

        [HttpGet]
        public ActionResult Create(int Id)
        {
            var parentCatalog = _catalogRepository.GetCatalogById(Id);
            var result = new CatalogViewModel
            {
                SelectedCatalog = parentCatalog
            };
            return View("CreatePartialView", result);
        }

        [HttpPost]
        public ActionResult Create(CatalogViewModel catalog)
        {
            _catalogRepository.AddCatalog(catalog.NewCatalog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var selectedCatalog = _catalogRepository.GetCatalogById(Id);
            var result = new CatalogViewModel
            {
                SelectedCatalog = selectedCatalog
            };
            return View("EditPartialView", result);
        }
        
        [HttpPost]
        public ActionResult Edit(CatalogViewModel catalog)
        {
            _catalogRepository.UpdateCatalog(catalog.SelectedCatalog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var selectedCatalog = _catalogRepository.GetCatalogById(Id);
            var result = new CatalogViewModel
            {
                SelectedCatalog = selectedCatalog
            };
            return View("DeletePartialView", result);
        }

        [HttpPost]
        public ActionResult Delete(CatalogViewModel catalog)
        {
            _catalogRepository.DeleteCatalog(catalog.SelectedCatalog.Id);
            return RedirectToAction (nameof(Index));
        }
    }
}
