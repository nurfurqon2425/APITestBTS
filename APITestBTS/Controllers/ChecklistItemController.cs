using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITestBTS.Controllers
{
    public class ChecklistItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
