using IdeoTask;
using IdeoTask.EntityFramework;
using IdeoTask.Services.DTO;
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

        public List<CatalogDTO> GetAllCatalogs() {
            var entity = _applicationContext.Catalogs.ToList();
            var result = entity.Select(x => new CatalogDTO
            {
                Id = x.Id,
                Name = x.Name,
                CreatedData = x.CreatedData,
                ParentCatalog = x.ParentCatalog
            }).ToList();
            return result;
        }

        public CatalogDTO GetCatalogById(int id)
        {
            var entity = _applicationContext.Catalogs.SingleOrDefault(x => x.Id == id);
            return new CatalogDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedData = entity.CreatedData,
                ParentCatalog = entity.ParentCatalog
            };
        }

        List<CatalogDTO> ICatalogRepository.GetAllCatalogs()
        {
            var entity = _applicationContext.Catalogs.Select(x => new CatalogDTO
            {
                Id = x.Id,
                Name = x.Name,
                CreatedData = x.CreatedData,
                ParentCatalog = x.ParentCatalog
            }).ToList();

            return entity;
        }
    }
}
