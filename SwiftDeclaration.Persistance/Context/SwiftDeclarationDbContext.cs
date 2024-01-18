using Microsoft.EntityFrameworkCore;
using SwiftDeclaration.Domain.Entities.Declarations;

namespace SwiftDeclaration.Persistance.Context;

public class SwiftDeclarationDbContext : DbContext
{
    public const string SectionName = "SwiftDeclarationDbContext";
    public DbSet<Declaration> Declarations { get; set; }

    public SwiftDeclarationDbContext(DbContextOptions<SwiftDeclarationDbContext> options) : base(options)
    {
    }
}
