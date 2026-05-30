using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.GetById;

public sealed class GetProceedingByIdHandler
{
    private readonly IProceedingRepository _repository;

    public GetProceedingByIdHandler(IProceedingRepository repository)
    {
        _repository = repository;
    }

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
