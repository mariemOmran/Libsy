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
            var hasher = new PasswordHasher<ApplicationUser>();
            base.OnModelCreating(builder);
            builder.Entity<order_details>().HasKey(x => new{x.orderID,x.clothesID});
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { 
            Id = 1,
            Name="Admin",
            NormalizedName="ADMIN"
            },
            new IdentityRole<int> {
                Id = 2,
                Name = "User",
                NormalizedName="USER"
            },
            new IdentityRole<int>
            {
                Id = 3,
                Name = "Merchant",
                NormalizedName="MERCHANT"
            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { 
                Id= 1,
                UserName="Admin",
                NormalizedUserName="ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail="ADMIN@GMAIL.COM",
                PasswordHash= hasher.HashPassword(null,"1"),
                Address = "cario"

            }, new ApplicationUser
            {
                Id = 2,
                UserName = "Merchant",
                NormalizedUserName="MERCHANT",
                NormalizedEmail="MERCHANT@GMAIL.COM",
                Email = "merchant@gmail.com",
                PasswordHash = hasher.HashPassword(null, "1"),
                Address ="cario"

            });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { 
                UserId= 1,
                RoleId= 1,
            }, new IdentityUserRole<int>
            {
                UserId =2,
                RoleId = 3,
            });
        }

    }
}
