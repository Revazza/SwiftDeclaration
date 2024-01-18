using Microsoft.EntityFrameworkCore;

namespace SwiftDeclaration.Persistance.Context;

public class SwiftDeclarationDbContext : DbContext
{
    public const string SectionName = "SwiftDeclarationDbContext";

    public SwiftDeclarationDbContext(DbContextOptions<SwiftDeclarationDbContext> options) : base(options)
    {
    }
}
