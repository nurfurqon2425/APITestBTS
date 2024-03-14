using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITestBTS.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
