using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.List;

/// <summary>
/// Implementa o caso de uso correspondente a esta feature.
/// </summary>
public sealed class ListProceedingsHandler
{
    private readonly IProceedingRepository _repository;

/// <summary>
/// Inicializa uma nova instância de ListProceedingsHandler.
/// </summary>
    public ListProceedingsHandler(IProceedingRepository repository)
    {
        _repository = repository;
    }

/// <summary>
/// Executa o caso de uso e devolve o resultado padronizado da operação.
/// </summary>
    public async Task<UseCaseResult<IReadOnlyCollection<Proceeding>>> HandleAsync()
    {
        var items = await _repository.ListAsync();
        return UseCaseResult<IReadOnlyCollection<Proceeding>>.Success(items);
    }
}
