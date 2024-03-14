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
    public class ChecklistController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly JwtService _jwtService;

        public ChecklistController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _jwtService = new JwtService(_configuration["Jwt:Key"]);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checklist>>> GetChecklist()
        {
            var checklist = await _db.Checklist.ToListAsync();
            return Ok(checklist);
        }

        [HttpPost]
        public async Task<ActionResult<Checklist>> Create(Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Checklist.Add(checklist);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = checklist.ChecklistId }, checklist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string checklistid)
        {
            var checklist = await _db.Checklist.FindAsync(checklistid);
            if (checklist == null)
            {
                return NotFound();
            }

            _db.Checklist.Remove(checklist);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
