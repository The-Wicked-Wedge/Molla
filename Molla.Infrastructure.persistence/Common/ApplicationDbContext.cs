using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Molla.Domain.Entities;

namespace Molla.Infrastructure.persistence.Common
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            :base(option) 
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Baner> Baners { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }

    }
}
