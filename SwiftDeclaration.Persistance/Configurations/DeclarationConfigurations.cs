using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftDeclaration.Domain.Constants;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Domain.ValueObjects.Images;

namespace SwiftDeclaration.Persistance.Configurations;

public class DeclarationConfigurations : IEntityTypeConfiguration<Declaration>
{
    public void Configure(EntityTypeBuilder<Declaration> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.HeadLine)
            .IsRequired()
            .HasMaxLength(DeclarationOptions.MaxHeadLineLength)
            .UseCollation(CollationConstants.CaseInsensitivity);

        // Adding an index on HeadLine for optimized searching of declarations by head line
        builder.HasIndex(x => x.HeadLine);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(DeclarationOptions.MaxDescriptionLength);
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(DeclarationOptions.MaxPhoneNumberLength);

        builder.OwnsOne(x => x.Image, img =>
        {
            img.Property(i => i.FileName)
                .HasMaxLength(ImageOptions.MaxFileNameLength)
                .IsRequired();

            img.Property(i => i.Data)
                .IsRequired();
        });

    }
}
