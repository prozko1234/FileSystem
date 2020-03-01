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

        public void AddCatalog(CatalogBranchDTO catalog) {
            _applicationContext.Add(catalog);
            _applicationContext.SaveChanges();
        }

        public void DeleteCatalog(int id) {
            var entity = _applicationContext.Catalogs.SingleOrDefault(x => id == x.Id);
            _applicationContext.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public CatalogBranchDTO GetCatalogById(int id)
        {
            var entity = _applicationContext.Catalogs.SingleOrDefault(x => x.Id == id);
            return new CatalogBranchDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedDate = entity.CreatedData,
                ParentId = entity.ParentCatalog.Id
            };
        }

        public List<CatalogBranchDTO> GetAllCatalogs()
        {
            var entity = _applicationContext.Catalogs.Select(x => new CatalogBranchDTO
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedData,
                ParentId = x.ParentCatalog.Id
            }).ToList();

            return entity;
        }

        public List<CatalogBranchDTO> GetRootCatalogs() {
            var entity = _applicationContext.Catalogs.Where(x => x.ParentCatalog == null).ToList();
            var result = entity.Select(x => new CatalogBranchDTO
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedData,
                ParentId = x.ParentCatalog.Id
            }).ToList();

            return result;
        }

        public List<CatalogBranchDTO> GetBranches()
        {
            List<CatalogBranchDTO> branches = GetAllCatalogs().Select(x => new CatalogBranchDTO
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                CreatedDate = x.CreatedDate,
                BranchChildren = null
            }).ToList();

            foreach (var item in branches) {
                item.BranchChildren = GetBrancheChildren(branches, item);
            }

            return branches.Where(x => x.ParentId == null).ToList();
        }

        public List<CatalogBranchDTO> GetBrancheChildren(List<CatalogBranchDTO> branches, CatalogBranchDTO branchItem) {
            
            if (branches.All(x => x.ParentId != branchItem.Id)) return null;

            branchItem.BranchChildren = branches
                .Where(x => x.ParentId == branchItem.Id)
                .ToList();

            foreach (var item in branchItem.BranchChildren)
            {
                item.BranchChildren = GetBrancheChildren(branches, item);
            }

            return branchItem.BranchChildren;
        }
    }
}
