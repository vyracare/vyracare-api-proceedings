using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Vyracare.Api.Proceedings.Common.Configuration;
using Vyracare.Api.Proceedings.Common.Time;
using Vyracare.Api.Proceedings.Features.Proceedings.Create;
using Vyracare.Api.Proceedings.Features.Proceedings.GetById;
using Vyracare.Api.Proceedings.Features.Proceedings.List;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;
using Vyracare.Api.Proceedings.Infrastructure.Persistence;
using Vyracare.Api.Proceedings.Infrastructure.Time;

namespace Vyracare.Api.Proceedings.Infrastructure.DependencyInjection;

/// <summary>
/// Centraliza extens?es reutiliz?veis usadas pela aplica??o.
/// </summary>
public static class ServiceCollectionExtensions
{
/// <summary>
/// Registra os servi?os necess?rios para conectar a aplica??o ao MongoDB.
/// </summary>
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<MongoOptions>>().Value;
            return new MongoClient(options.ConnectionString);
        });

        services.AddScoped(sp =>
        {
            var options = sp.GetRequiredService<IOptions<MongoOptions>>().Value;
            return sp.GetRequiredService<IMongoClient>().GetDatabase(options.Database);
        });

        return services;
    }

/// <summary>
/// Registra os handlers, portas e servi?os centrais da aplica??o no container de depend?ncias.
/// </summary>
    public static IServiceCollection AddProceedingsCore(this IServiceCollection services)
    {
        services.AddSingleton<IClock, SystemClock>();
        services.AddScoped<IProceedingRepository, MongoProceedingRepository>();
        services.AddScoped<CreateProceedingHandler>();
        services.AddScoped<GetProceedingByIdHandler>();
        services.AddScoped<ListProceedingsHandler>();
        return services;
    }
}
