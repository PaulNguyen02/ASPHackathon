using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Extensions
{
    public static class Seedata
    {
       
        public static void Seed(this ModelBuilder modelbuilder)
        {

            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelbuilder.Entity<News>().HasData(
                 new News
                 {
                     Id_New = 1,
                     Title = "Tin tức về rác thải nhựa",
                     Description = "Tin tức về rác thải nhựa",
                     ImageUrl = "/themes/img/post/post_1.png",
                     Created_at = DateTime.Now,
                     Created_by = "Admin",
                     UserId = adminId
                 },
                  new News
                  {
                      Id_New = 2,
                      Title = "Tin tức về rác thải nhựa",
                      Description = "Tin tức về rác thải nhựa",
                      ImageUrl = "/themes/img/post/post_2.png",
                      Created_at = DateTime.Now,
                      Created_by = "Admin",
                      UserId = adminId
                  },
                   new News
                   {
                       Id_New = 3,
                       Title = "Tin tức về rác thải nhựa",
                       Description = "Tin tức về rác thải nhựa",
                       ImageUrl = "/themes/img/post/post_3.png",
                       Created_at = DateTime.Now,
                       Created_by = "Admin",
                       UserId = adminId
                   }
                   ,
                    new News
                    {
                        Id_New = 4,
                        Title = "Tin tức về rác thải nhựa",
                        Description = "Tin tức về rác thải nhựa",
                        ImageUrl = "/themes/img/post/post_4.png",
                        Created_at = DateTime.Now,
                        Created_by = "Admin",
                        UserId = adminId
                    },
                     new News
                     {
                         Id_New = 5,
                         Title = "Tin tức về rác thải nhựa",
                         Description = "Tin tức về rác thải nhựa",
                         ImageUrl = "/themes/img/post/post_5.png",
                         Created_at = DateTime.Now,
                         Created_by = "Admin",
                         UserId = adminId
                     },
                      new News
                      {
                          Id_New = 6,
                          Title = "Tin tức về rác thải nhựa",
                          Description = "Tin tức về rác thải nhựa",
                          ImageUrl = "/themes/img/post/post_6.png",
                          Created_at = DateTime.Now,
                          Created_by = "Admin",
                          UserId = adminId
                      }
                 );
            modelbuilder.Entity<Forum>().HasData(
                new Forum
                {
                    ID_Post=1,
                    Title_Post="Cho tôi hỏi về cách phân loại rác thải?",
                    Description= "Phân loại rác thải là quá trình phân chia các loại rác thành các nhóm khác nhau dựa trên tính chất và cách xử lý sau này. ",
                    ImageUrl="/themes/img/gallery/services1.png",
                    Created_At=DateTime.Now,
                    UserId=adminId
                }

                );
            SeedUser(modelbuilder);
        }
        
        public static void SeedUser(this ModelBuilder modelbuilder)
        {
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleId2=new Guid("1b45cfef-cddb-4ff3-86b1-541d37493649");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var regularId = new Guid("b64cc01d-4317-4a44-88f6-a0cc4e2709ab");
            var adminUser = new User
            {
                Id = adminId,
                Name = "AdminWeb",
                UserName = "admin@example.com",
                Email = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                permission="Admin",
                Password="Admin123",
                Location="HCM"
            };
            adminUser.PasswordHash = new PasswordHasher<User>().HashPassword(adminUser, "Admin123");

            modelbuilder.Entity<User>().HasData(adminUser);

            // Assign Admin user to Admin role
            modelbuilder.Entity<UserRole>().HasData(
                new UserRole() { Id = roleId, Name = "Admin", NormalizedName = "ADMIN" , Description="Admin", },
                new UserRole() { Id = roleId2, Name = "User", NormalizedName = "USER" ,Description="User"}
            );
             modelbuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { RoleId = roleId, UserId = adminId }
            );
            // Seed regular User
            var regularUser = new User
            {
                Id = regularId,
                Name="User",

                permission="User",
                Location="HCM",
                Password="User123",
                UserName = "user@example.com",
                Email = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true
            };
            regularUser.PasswordHash = new PasswordHasher<User>().HashPassword(regularUser, "User123");

            modelbuilder.Entity<User>().HasData(regularUser);
            modelbuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { RoleId = roleId2, UserId =regularId }
            );
            // Assign regular User to User role

        }

    }
}
