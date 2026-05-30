using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Common.Time;
using Vyracare.Api.Proceedings.Features.Proceedings.Create;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Tests.Proceedings.Create;

/// <summary>
/// Agrupa os cen?rios de teste unit?rio relacionados a este componente.
/// </summary>
public sealed class CreateProceedingHandlerTests
{
    [Fact]
/// <summary>
/// Executa a responsabilidade associada a d ev e r et or na r v al id ac ao q ua nd o n om e n ao f or i nf or ma do.
/// </summary>
    public async Task Deve_retornar_validacao_quando_nome_nao_for_informado()
    {
        var handler = new CreateProceedingHandler(new FakeProceedingRepository(), new FixedClock());

        var result = await handler.HandleAsync(new CreateProceedingRequest("", "Facial", "COD-1", "Rosto", 30, 100, 1, "Nenhuma", "Descricao", true));

        Assert.False(result.IsSuccess);
        Assert.Equal(UseCaseErrorType.Validation, result.ErrorType);
    }

    [Fact]
/// <summary>
/// Executa a responsabilidade associada a d ev e c ri ar p ro ce di me nt o q ua nd o p ay lo ad f or v al id o.
/// </summary>
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
/// <summary>
/// Obt?m ou define i te ms.
/// </summary>
        public List<Proceeding> Items { get; } = [];

/// <summary>
/// Persiste um novo registro e devolve a entidade resultante da opera??o.
/// </summary>
        public Task<Proceeding> AddAsync(Proceeding proceeding)
        {
            proceeding.Id ??= Guid.NewGuid().ToString("N");
            Items.Add(proceeding);
            return Task.FromResult(proceeding);
        }

/// <summary>
/// Recupera um registro espec?fico a partir do seu identificador.
/// </summary>
        public Task<Proceeding?> GetByIdAsync(string id) => Task.FromResult(Items.FirstOrDefault(item => item.Id == id));

/// <summary>
/// Recupera a cole??o de registros dispon?veis para esta feature.
/// </summary>
        public Task<IReadOnlyCollection<Proceeding>> ListAsync() => Task.FromResult<IReadOnlyCollection<Proceeding>>(Items);
    }

    private sealed class FixedClock : IClock
    {
        public DateTime UtcNow => new(2026, 5, 30, 12, 0, 0, DateTimeKind.Utc);
    }
}
