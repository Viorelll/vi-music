using ViMusic.Application.Common.Interfaces;

namespace ViMusic.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
