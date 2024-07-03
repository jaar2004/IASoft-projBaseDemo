// IAR lun 01JUL2024

using projBaseDemo.Application.DTOs.Email;

namespace projBaseDemo.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
