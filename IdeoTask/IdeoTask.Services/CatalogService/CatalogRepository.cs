using IdeoTask;
using IdeoTask.EntityFramework;
using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeoTask.Services.CatalogService
{
    public class CatalogRepository : ICatalogRepository
    {

        private readonly ApplicationContext _applicationContext;

        public CatalogRepository(ApplicationContext applicationContext) {
            _applicationContext = applicationContext;
        }

        public void AddCatalog(Catalog catalog) {
            _applicationContext.Add(catalog);
            _applicationContext.SaveChanges();
        }

        public void DeleteCatalog(int id) {
            var entity = _applicationContext.Catalogs.SingleOrDefault(x => id == x.Id);
            _applicationContext.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public List<Catalog> GetAllCatalogs() {
            var entity = _applicationContext.Catalogs.ToList();
            return entity;
        }
    }
}
