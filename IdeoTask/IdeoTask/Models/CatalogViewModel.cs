using IdeoTask.Services.DTO;
using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoTask.Models
{
    public class CatalogViewModel
    {
        public List<CatalogBranchDTO> BranchList { get; set; }
        public List<CatalogBranchDTO> Catalogs { get; set; }
        public Catalog SelectedCatalog { get; set; }
        public Catalog NewCatalog { get; set; }
    }
}
