using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;

namespace Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

public interface IProceedingRepository
{
    Task<IReadOnlyCollection<Proceeding>> ListAsync();
    Task<Proceeding?> GetByIdAsync(string id);
    Task<Proceeding> AddAsync(Proceeding proceeding);
}
