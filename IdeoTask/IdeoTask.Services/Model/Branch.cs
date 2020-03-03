using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IdeoTask.Services.Model
{
    public class Branch
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public bool IsLeaf { get; set; }
        public List<Branch> BranchChildren { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
