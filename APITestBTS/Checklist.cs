using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITestBTS
{
    public class Checklist
    {
        [Key]
        public string ChecklistId;
        [Required]
        public string ChecklistName;
    }
}
