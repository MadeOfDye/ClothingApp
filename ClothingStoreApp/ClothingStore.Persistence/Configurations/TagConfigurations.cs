using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class TagConfigurations: IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(tag => tag.TagId)
                .HasName("PK_Tags");
        }
    }
}
