using IdeoTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeoTask.Services.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<Branch> BranchChildren { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
