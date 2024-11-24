using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alspec.Models.Entities
{
    [Table("Job")]
    public class Job
    {
        
        public string  Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SubItem> SubItems { get; set; } = new List<SubItem>();




    }
}
