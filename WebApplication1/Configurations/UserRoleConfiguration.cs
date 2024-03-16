using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
        }
    }

}
