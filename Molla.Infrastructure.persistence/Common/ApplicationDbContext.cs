 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Molla.Domain.Entities;
using Molla.Domain.Entities.AdminDashBoard;
using Molla.Domain.Entities.category;
using Molla.Domain.Entities.product;

namespace Molla.Infrastructure.persistence.Common
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            :base(option) 
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Baner> Baners { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }

        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<StockByColorSize> StockByColorSizes { get; set; }

        public DbSet<OFFModel> OffTickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses  { get; set; }

    }
}
