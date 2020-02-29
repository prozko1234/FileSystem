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
        List<Catalog> GetAllCatalogs();
    }
}
