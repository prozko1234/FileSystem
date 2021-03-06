﻿using IdeoTask.Services.Model;
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
        List<Branch> GetRootBranches();
        List<Branch> GetBranches(SortType sortType);
        List<Branch> GetChildrenBranches(List<Branch> branches, Branch branchItem);
        List<Branch> GetSortTree(SortType sortType, List<Branch> branches);
        void ChangeBranchLocation(Catalog catalog, int idLocation);
    }
}
