using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.GetById;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Tests.Proceedings.GetById;

/// <summary>
/// Representa o componente GetProceedingByIdHandlerTests da aplicação.
/// </summary>
public sealed class GetProceedingByIdHandlerTests
{
    [Fact]
/// <summary>
/// Executa a responsabilidade do método D ev e_r et or na r_n ot_f ou nd_q ua nd o_p ro ce di me nt o_n ao_e xi st ir.
/// </summary>
    public async Task Deve_retornar_not_found_quando_procedimento_nao_existir()
    {
        var handler = new GetProceedingByIdHandler(new FakeProceedingRepository());

        var result = await handler.HandleAsync("nao-existe");

        Assert.False(result.IsSuccess);
        Assert.Equal(UseCaseErrorType.NotFound, result.ErrorType);
    }

    [Fact]
/// <summary>
/// Executa a responsabilidade do método D ev e_r et or na r_p ro ce di me nt o_q ua nd o_e le_e xi st ir.
/// </summary>
    public async Task Deve_retornar_procedimento_quando_ele_existir()
    {
        var repository = new FakeProceedingRepository();
        await repository.AddAsync(new Proceeding { Id = "proc-1", Name = "Botox", Category = "Facial", Code = "COD-1", TargetArea = "Rosto", RecoveryTime = "Nenhuma", Description = "Descricao" });

        var handler = new GetProceedingByIdHandler(repository);
        var result = await handler.HandleAsync("proc-1");

        Assert.True(result.IsSuccess);
        Assert.Equal("proc-1", result.Value!.Id);
    }

    private sealed class FakeProceedingRepository : IProceedingRepository
    {
        private readonly List<Proceeding> _items = [];

/// <summary>
/// Persiste um novo registro e devolve a entidade resultante da operação.
/// </summary>
        public Task<Proceeding> AddAsync(Proceeding proceeding)
        {
            proceeding.Id ??= Guid.NewGuid().ToString("N");
            _items.Add(proceeding);
            return Task.FromResult(proceeding);
        }

/// <summary>
/// Recupera um registro específico a partir do identificador informado.
/// </summary>
        public Task<Proceeding?> GetByIdAsync(string id) => Task.FromResult(_items.FirstOrDefault(item => item.Id == id));

/// <summary>
/// Recupera a coleção de registros disponíveis para a feature.
/// </summary>
        public Task<IReadOnlyCollection<Proceeding>> ListAsync() => Task.FromResult<IReadOnlyCollection<Proceeding>>(_items);
    }
}
