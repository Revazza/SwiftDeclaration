namespace SwiftDeclaration.Infrastructure.Services.Interfaces;

public interface ICacheableQuery
{
    string SectionName { get; }
    string Salt { get; set; }
}
