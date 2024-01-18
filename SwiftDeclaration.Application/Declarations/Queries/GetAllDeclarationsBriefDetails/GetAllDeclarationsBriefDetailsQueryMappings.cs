using Mapster;
using SwiftDeclaration.Domain.Entities.Declarations;

namespace SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;

public class GetAllDeclarationsBriefDetailsQueryMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Declaration, GetAllDeclarationsBriefDetailsQueryResponse>()
            .Map(dest => dest.ImageBase64, src => src.Image.ConvertImageDataAsBase64());
    }
}
