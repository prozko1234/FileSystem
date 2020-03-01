using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IdeoTask.Services.DTO
{
    public class CatalogBranchDTO
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<CatalogBranchDTO> BranchChildren { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
