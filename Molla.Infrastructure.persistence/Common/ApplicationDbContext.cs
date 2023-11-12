using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;

namespace Molla.Infrastructure.persistence.Common
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            :base(option) 
        {
            
        }
        public DbSet<Slider> Sliders { get; set; }



    }
}
