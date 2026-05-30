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

public static class ServiceCollectionExtensions
{
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
