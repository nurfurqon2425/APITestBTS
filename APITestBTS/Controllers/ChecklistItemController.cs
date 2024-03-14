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
    [ApiController]
    [Route("checklist")]
    public class ChecklistItemController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly JwtService _jwtService;

        public ChecklistItemController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _jwtService = new JwtService(_configuration["Jwt:Key"]);
        }

        [HttpGet("{checklistid}/item")]
        public async Task<ActionResult<ChecklistItem>> GetCheclistItem(string checklistid)
        {
            var checklistitem = await _db.ChecklistItem.FindAsync(checklistid);

            if (checklistitem == null)
            {
                return NotFound();
            }

            return Ok(checklistitem);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ChecklistItem>> Create(ChecklistItem checklistitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.ChecklistItem.Add(checklistitem);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = checklistitem.ChecklistItemId }, checklistitem);
        }

    }
}
