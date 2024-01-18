using Mapster;
using SwiftDeclaration.Application.Declarations.Dtos;
using SwiftDeclaration.Domain.Entities.Declarations;

namespace SwiftDeclaration.Application.Mappings;

public class DeclarationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Declaration, DeclarationDto>()
            .Map(dest => dest.ImageBase64, src => src.Image.ConvertImageDataAsBase64());
    }
}
