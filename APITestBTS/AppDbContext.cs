using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITestBTS
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Auth> Auth { get; set; }
        public DbSet<Checklist> Checklist { get; set; }
        public DbSet<ChecklistItem> ChecklistItem { get; set; }
    }
}
