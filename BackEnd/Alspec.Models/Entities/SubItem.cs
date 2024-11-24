using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alspec.Models.Entities
{
    public class SubItem
    {
        //Unique identifier for the sub-item.
        [Key]
        public string ItemId{ get; set; }
        //Title of the sub-item
        public string Title { get; set; }
        //Short description of the subitem.
        public string Description { get; set; }
        // Status of the sub-item (e.g., "Pending", "In Progress", "Completed").
        public string Status { get; set; }
        public string JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }


    }
}
