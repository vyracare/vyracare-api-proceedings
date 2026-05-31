using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Common.Time;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Features.Proceedings.Create;

/// <summary>
/// Implementa o caso de uso correspondente a esta feature.
/// </summary>
public sealed class CreateProceedingHandler
{
    private readonly IProceedingRepository _repository;
    private readonly IClock _clock;

/// <summary>
/// Inicializa uma nova instância de CreateProceedingHandler.
/// </summary>
    public CreateProceedingHandler(IProceedingRepository repository, IClock clock)
    {
        _repository = repository;
        _clock = clock;
    }

/// <summary>
/// Executa o caso de uso e devolve o resultado padronizado da operação.
/// </summary>
    public async Task<UseCaseResult<Proceeding>> HandleAsync(CreateProceedingRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return UseCaseResult<Proceeding>.Failure(UseCaseErrorType.Validation, "Name is required");
        }

        if (string.IsNullOrWhiteSpace(request.Category))
        {
            return UseCaseResult<Proceeding>.Failure(UseCaseErrorType.Validation, "Category is required");
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return UseCaseResult<Proceeding>.Failure(UseCaseErrorType.Validation, "Code is required");
        }

        var timestamp = _clock.UtcNow;
        var proceeding = new Proceeding
        {
            Name = request.Name.Trim(),
            Category = request.Category.Trim(),
            Code = request.Code.Trim(),
            TargetArea = request.TargetArea.Trim(),
            DurationMinutes = request.DurationMinutes,
            SessionPrice = request.SessionPrice,
            SessionCount = request.SessionCount,
            RecoveryTime = request.RecoveryTime.Trim(),
            Description = request.Description.Trim(),
            Active = request.Active,
            CreatedAt = timestamp,
            UpdatedAt = timestamp
        };

        var created = await _repository.AddAsync(proceeding);
        return UseCaseResult<Proceeding>.Success(created);
    }
}
