using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnvironment_Hackathon_GaMo.Models;

namespace WebEnvironment_Hackathon_GaMo.Configurations
{
    public class Product_RecycleConfiguration : IEntityTypeConfiguration<Product_Recycle>
    {
        public void Configure(EntityTypeBuilder<Product_Recycle> builder)
        {
            builder.ToTable("Product_recycle");
            builder.HasKey(x => x.ID_Product);
            builder.Property(x => x.ID_Product).UseIdentityColumn();
            builder.Property(x => x.Product_Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Decription).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Organic).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Inorganic).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Recycling).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Place).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.product_Recycles).HasForeignKey(x => x.UserId);
        }
    }
}
