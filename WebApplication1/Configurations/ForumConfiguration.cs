using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class ForumConfiguration : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("Forum");
            builder.HasKey(x => x.ID_Post);
            builder.Property(x => x.ID_Post).UseIdentityColumn();
            builder.Property(x => x.Title_Post).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Created_At).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Forums).HasForeignKey(x => x.UserId);

        }
    }
}
