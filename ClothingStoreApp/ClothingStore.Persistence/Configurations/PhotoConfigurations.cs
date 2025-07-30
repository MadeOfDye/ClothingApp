using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class PhotoConfigurations: IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> photoBuilder)
        {
            photoBuilder.ToTable("Photos");
            photoBuilder.HasKey(photo => photo.PhotoId)
                .HasName("PK_Photos");
            photoBuilder.Property(photo => photo.UploadedAt)
                .HasColumnType("datetimeoffset(0)")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            photoBuilder.HasOne(photo => photo.Variant)
                .WithMany(variant => variant.Gallery)
                .HasForeignKey(photo => photo.VariantId)
                .HasConstraintName("FK_Variants_Photos")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
