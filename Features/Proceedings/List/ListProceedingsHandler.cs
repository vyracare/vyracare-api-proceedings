using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.List;

/// <summary>
/// Implementa a regra de neg?cio do caso de uso representado por esta pasta.
/// </summary>
public sealed class ListProceedingsHandler
{
    private readonly IProceedingRepository _repository;

/// <summary>
/// Inicializa uma nova inst?ncia de ListProceedingsHandler.
/// </summary>
    public ListProceedingsHandler(IProceedingRepository repository)
    {
        _repository = repository;
    }

/// <summary>
/// Executa o caso de uso e devolve o resultado padronizado da opera??o.
/// </summary>
    public async Task<UseCaseResult<IReadOnlyCollection<Proceeding>>> HandleAsync()
    {
        var items = await _repository.ListAsync();
        return UseCaseResult<IReadOnlyCollection<Proceeding>>.Success(items);
    }
}
