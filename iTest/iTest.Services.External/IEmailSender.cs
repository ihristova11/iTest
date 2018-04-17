using System.Threading.Tasks;

namespace iTest.Services.External
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
