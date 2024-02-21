using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrostructer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }

}
