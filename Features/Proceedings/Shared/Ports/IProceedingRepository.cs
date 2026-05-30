using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;

namespace Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

/// <summary>
/// Implementa a integra??o com a persist?ncia ou com uma depend?ncia externa da aplica??o.
/// </summary>
public interface IProceedingRepository
{
    Task<IReadOnlyCollection<Proceeding>> ListAsync();
    Task<Proceeding?> GetByIdAsync(string id);
    Task<Proceeding> AddAsync(Proceeding proceeding);
}
