using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SendEmail.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    // EXEMPLO 01
    [HttpPost("sendemail1")]
    public IActionResult SendEmail1(string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("bailey.ryan@ethereal.email"));
        email.To.Add(MailboxAddress.Parse("bailey.ryan@ethereal.email"));
        email.Subject = "Test Email Subject";
        email.Body = new TextPart(TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("bailey.ryan@ethereal.email", "VKCnCmt4nPf3nKvURB");
        smtp.Send(email);
        smtp.Disconnect(true);

        return Ok("Email enviado!");
    }
    
    // EXEMPLO 02
    [HttpPost("sendemail2")]
    public IActionResult SendEmail2(EmailDto request)
    {
        _emailService.SendEmail(request);
        return Ok("Email enviado!");
    }
}