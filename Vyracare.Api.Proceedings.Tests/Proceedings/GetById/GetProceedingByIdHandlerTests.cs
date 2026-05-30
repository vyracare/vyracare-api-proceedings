using Vyracare.Api.Proceedings.Common.Results;
using Vyracare.Api.Proceedings.Features.Proceedings.GetById;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;

namespace Vyracare.Api.Proceedings.Tests.Proceedings.GetById;

public sealed class GetProceedingByIdHandlerTests
{
    [Fact]
    public async Task Deve_retornar_not_found_quando_procedimento_nao_existir()
    {
        var handler = new GetProceedingByIdHandler(new FakeProceedingRepository());

        var result = await handler.HandleAsync("nao-existe");

        Assert.False(result.IsSuccess);
        Assert.Equal(UseCaseErrorType.NotFound, result.ErrorType);
    }

    [Fact]
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

        public Task<Proceeding> AddAsync(Proceeding proceeding)
        {
            proceeding.Id ??= Guid.NewGuid().ToString("N");
            _items.Add(proceeding);
            return Task.FromResult(proceeding);
        }

        public Task<Proceeding?> GetByIdAsync(string id) => Task.FromResult(_items.FirstOrDefault(item => item.Id == id));

        public Task<IReadOnlyCollection<Proceeding>> ListAsync() => Task.FromResult<IReadOnlyCollection<Proceeding>>(_items);
    }
}
