using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Project_Angular.Models
{
    public class EcommerceContext : IdentityDbContext<ApplicationUser,IdentityRole<int>, int>
    {
       public EcommerceContext() { }
        public EcommerceContext(DbContextOptions<EcommerceContext> options):base(options) { }
        
        public DbSet<Clothes> clothes { get; set; }
        public DbSet <Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<order_details> order_details { get; set; }
        public DbSet<Order> orders { get; set; }
        //Identity Table
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<IdentityRole<int>> identityRoles { get; set; }
        public DbSet<IdentityUserRole<int>> identityUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<order_details>().HasKey(x => new{x.orderID,x.clothesID});
        }

    }
}
