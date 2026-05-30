using Vyracare.Api.Proceedings.Common.Time;

namespace Vyracare.Api.Proceedings.Infrastructure.Time;

public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
