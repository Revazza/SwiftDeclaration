using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftDeclaration.Domain.ValueObjects.Images;

namespace SwiftDeclaration.Persistance.Configurations;

public class ImageConfigurations : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(x => x.FileName)
            .IsRequired()
            .HasMaxLength(ImageOptions.MaxFileNameLength);
        builder.Property(x => x.Data)
            .IsRequired();

    }
}
