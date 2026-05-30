namespace Vyracare.Api.Proceedings.Common.Time;

public interface IClock
{
    DateTime UtcNow { get; }
}
