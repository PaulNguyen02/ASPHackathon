using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255);
         //   builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.permission).IsRequired();
        }
    }
}
