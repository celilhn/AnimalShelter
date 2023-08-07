using Application.Models;

namespace Application.Interfaces
{
    public interface IEmailService
    {
        public bool SendEmail(EmailModel emailModel);
    }
}
