using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class NewConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("New");
            builder.HasKey(x => x.Id_New);
            builder.Property(x => x.Id_New).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Created_at).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Created_by).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.News).HasForeignKey(x => x.UserId);
        }
    }
}
