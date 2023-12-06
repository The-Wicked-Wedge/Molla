using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Molla.Domain.Entities;

namespace Molla.Infrastructure.persistence.Common
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : IdentityDbContext(option)
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Baner> Baners { get; set; }
    }
}
