using Vyracare.Api.Proceedings.Features.Proceedings.List;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Tests.Proceedings.List;

public sealed class ListProceedingsHandlerTests
{
    [Fact]
    public async Task Deve_encaminhar_filtros_de_autocomplete_ao_repositorio()
    {
        var repository = new FakeProceedingRepository();

        var result = await new ListProceedingsHandler(repository).HandleAsync("bot", true, 20);

        Assert.True(result.IsSuccess);
        Assert.Equal("bot", repository.Search);
        Assert.True(repository.ActiveOnly);
        Assert.Equal(20, repository.Limit);
    }

    private sealed class FakeProceedingRepository : IProceedingRepository
    {
        public string? Search { get; private set; }
        public bool ActiveOnly { get; private set; }
        public int? Limit { get; private set; }

        public Task<IReadOnlyCollection<Proceeding>> ListAsync(string? search = null, bool activeOnly = false, int? limit = null)
        {
            Search = search;
            ActiveOnly = activeOnly;
            Limit = limit;
            return Task.FromResult<IReadOnlyCollection<Proceeding>>([]);
        }

        public Task<Proceeding?> GetByIdAsync(string id) => Task.FromResult<Proceeding?>(null);
        public Task<Proceeding> AddAsync(Proceeding proceeding) => Task.FromResult(proceeding);
    }
}
