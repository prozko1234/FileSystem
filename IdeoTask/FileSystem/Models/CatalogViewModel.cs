using IdeoTask.Services.Model;
using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoTask.Models
{
    public class CatalogViewModel
    {
        public List<Branch> BranchList { get; set; }
        public List<Catalog> Catalogs { get; set; }
        public Catalog SelectedCatalog { get; set; }
        public Catalog NewCatalog { get; set; }
        public SortType SortType { get; set; }
    }
}
