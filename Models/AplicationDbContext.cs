using Microsoft.EntityFrameworkCore;

namespace Backend_ASP.NETcore.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
        public DbSet<Prospecto> Prospectos { get; set; }
 
    }
}
