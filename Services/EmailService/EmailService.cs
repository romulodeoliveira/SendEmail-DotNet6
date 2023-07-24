using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SendEmail.Helper;

namespace SendEmail.Services.EmailService;

public class EmailService : IEmailService
{
    public void SendEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("bailey.ryan@ethereal.email"));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect(EmailHelper.EmailHost, 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(EmailHelper.EmailUserName, EmailHelper.EmailPassword);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}