using IdeoTask.Services.DTO;
using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace IdeoTask.Services.CatalogService
{
    public interface ICatalogRepository
    {
        void AddCatalog(CatalogBranchDTO catalog);
        void DeleteCatalog(int id);
        List<CatalogBranchDTO> GetAllCatalogs();
        CatalogBranchDTO GetCatalogById(int id);
        List<CatalogBranchDTO> GetRootCatalogs();
        List<CatalogBranchDTO> GetBranches();
        List<CatalogBranchDTO> GetBrancheChildren(List<CatalogBranchDTO> branches, CatalogBranchDTO branchItem);
    }
}
