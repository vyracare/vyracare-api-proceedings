using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.GetById;

/// <summary>
/// Implementa o caso de uso correspondente a esta feature.
/// </summary>
public sealed class GetProceedingByIdHandler
{
    private readonly IProceedingRepository _repository;

/// <summary>
/// Inicializa uma nova instância de GetProceedingByIdHandler.
/// </summary>
    public GetProceedingByIdHandler(IProceedingRepository repository)
    {
        _repository = repository;
    }

/// <summary>
/// Executa o caso de uso e devolve o resultado padronizado da operação.
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
