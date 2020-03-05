using IdeoTask;
using IdeoTask.EntityFramework;
using IdeoTask.Services.Model;
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

        public void UpdateCatalog(Catalog catalog)
        {
            _applicationContext.Update(catalog);
            _applicationContext.SaveChanges();
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

        public Catalog GetCatalogById(int id)
        {
            var entity = _applicationContext.Catalogs.SingleOrDefault(x => x.Id == id);
            return entity;
        }

        public List<Catalog> GetAllCatalogs()
        {
            var entity = _applicationContext.Catalogs.ToList();

            return entity;
        }

        public List<Branch> GetRootCatalogs() {
            var entity = _applicationContext.Catalogs.Where(x => x.ParentCatalog == null).ToList();
            var result = entity.Select(x => new Branch
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                ParentId = x.ParentId,
                IsLeaf = x.IsLeaf
            }).ToList();

            return result;
        }

        public List<Branch> GetBranches(SortType sortType)
        {
            List<Branch> branches = GetAllCatalogs().Select(x => new Branch
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                CreatedDate = x.CreatedDate,
                IsLeaf = x.IsLeaf,
                BranchChildren = null
            }).ToList();

            foreach (var item in branches) {
                item.BranchChildren = GetChildrenBranches(branches, item);
                if (item.BranchChildren != null)
                    item.BranchChildren = SortTree(sortType, item.BranchChildren);
            }

            return branches.Where(x=> x.ParentId == null).ToList();
        }

        public List<Branch> GetChildrenBranches(List<Branch> branches, Branch branchItem) {
            
            if (branches.All(x => x.ParentId != branchItem.Id)) return null;

            branchItem.BranchChildren = branches
                .Where(x => x.ParentId == branchItem.Id)
                .ToList();

            foreach (var item in branchItem.BranchChildren)
            {
                item.BranchChildren = GetChildrenBranches(branches, item);
            }

            return branchItem.BranchChildren;
        }

        public List<Branch> SortTree(SortType sortType, List<Branch> branches)
        {
            if (sortType == SortType.NameAsc)
                return branches.OrderBy(x => x.Name).ToList();
            else if (sortType == SortType.NameDesc)
                return branches.OrderByDescending(x => x.Name).ToList();
            else if (sortType == SortType.DateAsc)
                return branches.OrderBy(x => x.CreatedDate).ToList();
            else if (sortType == SortType.DateDesc)
                return branches.OrderByDescending(x => x.CreatedDate).ToList();
            return branches;
        }
    }
}
