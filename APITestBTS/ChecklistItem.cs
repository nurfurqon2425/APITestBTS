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
        public string ChecklistItemId;
        [Required]
        public string CheckListId;
        [Required]
        public string ChecklistItemName;
    }
}
