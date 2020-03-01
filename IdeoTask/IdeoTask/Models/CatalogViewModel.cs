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
        public ICollection<CatalogBranchDTO> CatalogDTOsCollection { get; set; }
        public List<CatalogBranchDTO> CatalogDTOsList { get; set; }
        public List<CatalogBranchDTO> BranchList { get; set; }
    }
}
