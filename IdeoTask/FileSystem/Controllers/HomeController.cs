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
        public IActionResult Index(string sort)
        {
            try
            {
                var categories = _catalogRepository.GetAllCatalogs();
                List<Branch> branches;
                if (sort == "NameAsc")
                    branches = _catalogRepository.GetBranches(SortType.NameAsc);
                else if (sort == "NameDesc")
                    branches = _catalogRepository.GetBranches(SortType.NameDesc);
                else if (sort == "DateAsc")
                    branches = _catalogRepository.GetBranches(SortType.DateAsc);
                else branches = _catalogRepository.GetBranches(SortType.NameAsc);
                var result = new CatalogViewModel
                {
                    BranchList = branches,
                    Catalogs = categories
                };
                return View(result);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Replace(int idTarget, int idMoved)
        {
            try
            {
             var movedbranche =_catalogRepository.GetCatalogById(idMoved);
            _catalogRepository.ChangeBranchLocation(movedbranche, idTarget);
            return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Create(int Id)
        {
            try
            {
                var parentCatalog = _catalogRepository.GetCatalogById(Id);
                var result = new CatalogViewModel
                {
                    SelectedCatalog = parentCatalog
                };
                return View("CreatePartialView", result);
            } 
            catch(Exception e)
            {
                return View("Error");
            }
            
        }

        [HttpPost]
        public ActionResult Create(CatalogViewModel catalog)
        {
            try
            {
                if (catalog.NewCatalog.Name == null)
            {
                return View("Error");
            }
            _catalogRepository.AddCatalog(catalog.NewCatalog);
            return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            try
            {
                var selectedCatalog = _catalogRepository.GetCatalogById(Id);
                var result = new CatalogViewModel
                {
                    SelectedCatalog = selectedCatalog
                };
                return View("EditPartialView", result);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
        
        [HttpPost]
        public ActionResult Edit(CatalogViewModel catalog)
        {
            try
            {
                _catalogRepository.UpdateCatalog(catalog.SelectedCatalog);
            return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                var selectedCatalog = _catalogRepository.GetCatalogById(Id);
                var result = new CatalogViewModel
                {
                    SelectedCatalog = selectedCatalog
                };
                return View("DeletePartialView", result);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(CatalogViewModel catalog)
        {
            try
            {
                _catalogRepository.DeleteCatalog(catalog.SelectedCatalog.Id);
            return RedirectToAction (nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}
