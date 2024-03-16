using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class Employee_MissionConfiguration : IEntityTypeConfiguration<Employee_Mission>
    {
        public void Configure(EntityTypeBuilder<Employee_Mission> builder)
        {
            builder.ToTable("Employee_Mission");
            builder.HasKey(x => x.ID_MISSION);
            builder.Property(x => x.ID_MISSION).UseIdentityColumn();
            builder.Property(x => x.District).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Ward).HasMaxLength(200).IsRequired();
            builder.Property(x => x.City).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Notation).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Date).HasMaxLength(200).IsRequired();
            builder.Property(x => x.is_Collect).HasMaxLength(200).IsRequired();

        }
    }
}
