using IdeoTask.Services.Model;
using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace IdeoTask.Services.CatalogService
{
    public interface ICatalogRepository
    {
        void AddCatalog(Catalog catalog);
        void DeleteCatalog(int id);
        void UpdateCatalog(Catalog catalog);
        List<Catalog> GetAllCatalogs();
        Catalog GetCatalogById(int id);
        List<Branch> GetRootCatalogs();
        List<Branch> GetBranches();
        List<Branch> GetChildrenBranches(List<Branch> branches, Branch branchItem);
    }
}
