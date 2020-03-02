using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoTask.Services.Models
{
    public class Catalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? CreatedData {get; set;}
        public int? ParentId { get; set; }

        [ForeignKey("ParentId ")]
        public Catalog ParentCatalog { get; set; }
        public Catalog() {
            CreatedData = DateTime.UtcNow;
        }
    }
}
