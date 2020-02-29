using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IdeoTask.Services.DTO
{
    public class CatalogDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? CreatedData { get; set; }
        [ForeignKey("ParentId")]
        public virtual Catalog ParentCatalog { get; set; }

    }
}
