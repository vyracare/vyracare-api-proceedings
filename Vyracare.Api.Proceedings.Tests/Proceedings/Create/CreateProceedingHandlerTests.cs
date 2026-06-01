using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Common.Time;
using Vyracare.Api.Proceedings.Features.Proceedings.Create;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Tests.Proceedings.Create;

/// <summary>
/// Representa o componente CreateProceedingHandlerTests da aplicação.
/// </summary>
public sealed class CreateProceedingHandlerTests
{
    [Fact]
/// <summary>
/// Executa a responsabilidade do método D ev e_r et or na r_v al id ac ao_q ua nd o_n om e_n ao_f or_i nf or ma do.
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
/// Executa a responsabilidade do método D ev e_c ri ar_p ro ce di me nt o_q ua nd o_p ay lo ad_f or_v al id o.
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
/// Obtém ou define a coleção de itens usada no contexto do teste.
/// </summary>
        public List<Proceeding> Items { get; } = [];

/// <summary>
/// Persiste um novo registro e devolve a entidade resultante da operação.
/// </summary>
        public Task<Proceeding> AddAsync(Proceeding proceeding)
        {
            proceeding.Id ??= Guid.NewGuid().ToString("N");
            Items.Add(proceeding);
            return Task.FromResult(proceeding);
        }

/// <summary>
/// Recupera um registro específico a partir do identificador informado.
/// </summary>
        public Task<Proceeding?> GetByIdAsync(string id) => Task.FromResult(Items.FirstOrDefault(item => item.Id == id));

/// <summary>
/// Recupera a coleção de registros disponíveis para a feature.
/// </summary>
        public Task<IReadOnlyCollection<Proceeding>> ListAsync() => Task.FromResult<IReadOnlyCollection<Proceeding>>(Items);
    }

    private sealed class FixedClock : IClock
    {
        public DateTime UtcNow => new(2026, 5, 30, 12, 0, 0, DateTimeKind.Utc);
    }
}
