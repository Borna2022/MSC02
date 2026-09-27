using Microsoft.EntityFrameworkCore;
using MSC02.Models;

namespace MSC02.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Heat>  Heats { get; set; } // به عنوان مجموعه تعریف می شود
        public DbSet<EAFHeat> HeatEAFs { get; set; } // به عنوان مجموعه تعریف می شود
    }
}
