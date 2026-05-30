using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.GetById;

/// <summary>
/// Implementa a regra de neg?cio do caso de uso representado por esta pasta.
/// </summary>
public sealed class GetProceedingByIdHandler
{
    private readonly IProceedingRepository _repository;

/// <summary>
/// Inicializa uma nova inst?ncia de GetProceedingByIdHandler.
/// </summary>
    public GetProceedingByIdHandler(IProceedingRepository repository)
    {
        _repository = repository;
    }

/// <summary>
/// Executa o caso de uso e devolve o resultado padronizado da opera??o.
/// </summary>
    public async Task<UseCaseResult<Proceeding>> HandleAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return UseCaseResult<Proceeding>.Failure(UseCaseErrorType.Validation, "Id is required");
        }

        var proceeding = await _repository.GetByIdAsync(id);
        return proceeding is null
            ? UseCaseResult<Proceeding>.Failure(UseCaseErrorType.NotFound, "Proceeding not found")
            : UseCaseResult<Proceeding>.Success(proceeding);
    }
}
