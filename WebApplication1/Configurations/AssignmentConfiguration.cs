using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>

    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignment");
            builder.HasKey(x => x.Order_num);
            builder.Property(x => x.Order_num).UseIdentityColumn();
            builder.HasOne(x => x.User).WithMany(x => x.Assignments).HasForeignKey(x => x.UserId);

        }
    }
}
