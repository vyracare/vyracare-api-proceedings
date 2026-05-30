using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Common.Time;
using Vyracare.Api.Proceedings.Features.Proceedings.Create;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Tests.Proceedings.Create;

public sealed class CreateProceedingHandlerTests
{
    [Fact]
    public async Task Deve_retornar_validacao_quando_nome_nao_for_informado()
    {
        var handler = new CreateProceedingHandler(new FakeProceedingRepository(), new FixedClock());

        var result = await handler.HandleAsync(new CreateProceedingRequest("", "Facial", "COD-1", "Rosto", 30, 100, 1, "Nenhuma", "Descricao", true));

        Assert.False(result.IsSuccess);
        Assert.Equal(UseCaseErrorType.Validation, result.ErrorType);
    }

    [Fact]
    public async Task Deve_criar_procedimento_quando_payload_for_valido()
    {
        var repository = new FakeProceedingRepository();
        var handler = new CreateProceedingHandler(repository, new FixedClock());

        var result = await handler.HandleAsync(new CreateProceedingRequest("Botox", "Facial", "COD-1", "Rosto", 30, 100, 1, "Nenhuma", "Descricao", true));

        Assert.True(result.IsSuccess);
        Assert.Single(repository.Items);
    }

    private sealed class FakeProceedingRepository : IProceedingRepository
    {
        public List<Proceeding> Items { get; } = [];

        public Task<Proceeding> AddAsync(Proceeding proceeding)
        {
            proceeding.Id ??= Guid.NewGuid().ToString("N");
            Items.Add(proceeding);
            return Task.FromResult(proceeding);
        }

        public Task<Proceeding?> GetByIdAsync(string id) => Task.FromResult(Items.FirstOrDefault(item => item.Id == id));

        public Task<IReadOnlyCollection<Proceeding>> ListAsync() => Task.FromResult<IReadOnlyCollection<Proceeding>>(Items);
    }

    private sealed class FixedClock : IClock
    {
        public DateTime UtcNow => new(2026, 5, 30, 12, 0, 0, DateTimeKind.Utc);
    }
}
