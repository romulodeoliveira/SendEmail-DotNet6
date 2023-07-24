namespace SendEmail.Services.EmailService;

public interface IEmailService
{
    void SendEmail(EmailDto request);
}