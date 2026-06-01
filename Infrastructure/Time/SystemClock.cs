using Vyracare.Api.Proceedings.Common.Time;

namespace Vyracare.Api.Proceedings.Infrastructure.Time;

/// <summary>
/// Implementa o relógio padrão da aplicação usando a data e hora do sistema.
/// </summary>
public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
