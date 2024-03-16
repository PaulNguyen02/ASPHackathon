using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebEnvironment_Hackathon_GaMo.Configurations;
using WebEnvironment_Hackathon_GaMo.Extensions;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Context
{
    public class WebEnviDbContext: IdentityDbContext<User, UserRole, Guid>
    {
        public WebEnviDbContext(DbContextOptions options) : base(options)
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new Employee_MissionConfiguration());
            modelBuilder.ApplyConfiguration(new ForumConfiguration());
            modelBuilder.ApplyConfiguration(new NewConfiguration());
            modelBuilder.ApplyConfiguration(new Product_RecycleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Employee_Mission> Employee_Mission { get; set; }
        public DbSet<Product_Recycle> Product_Recycles { get; set; }

    }
}
