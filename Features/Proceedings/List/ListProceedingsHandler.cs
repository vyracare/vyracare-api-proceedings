using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.List;

public sealed class ListProceedingsHandler
{
    private readonly IProceedingRepository _repository;

    public ListProceedingsHandler(IProceedingRepository repository)
    {
        _repository = repository;
    }

    public async Task<UseCaseResult<IReadOnlyCollection<Proceeding>>> HandleAsync()
    {
        var items = await _repository.ListAsync();
        return UseCaseResult<IReadOnlyCollection<Proceeding>>.Success(items);
    }
}
