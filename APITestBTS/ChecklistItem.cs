using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITestBTS
{
    public class ChecklistItem
    {
        [Key]
        public string ChecklistItemId { get; set; }
        [Required]
        public string CheckListId { get; set; }
        [Required]
        public string ChecklistItemName { get; set; }
    }
}
