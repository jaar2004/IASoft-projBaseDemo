// IAR lun 01JUL2024

using projBaseDemo.Application.Interfaces;

namespace projBaseDemo.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
