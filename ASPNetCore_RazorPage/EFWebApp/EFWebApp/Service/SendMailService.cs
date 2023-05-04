using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class SendMailService:IEmailSender
{
    MailSettings _MailSettings { get; set; }
    private readonly ILogger<SendMailService> logger;
    public SendMailService(IOptions<MailSettings> mailSettings , ILogger<SendMailService> _logger)
    {
        _MailSettings = mailSettings.Value;
        logger = _logger;
        logger.LogInformation("Create SendMailService");
    }
    public async Task SendEmailAsync(string To,string Subject,string Body)
    {
        var email = new MimeKit.MimeMessage();
        email.Sender = new MimeKit.MailboxAddress("Trung", _MailSettings.Mail);
        email.From.Add(new MimeKit.MailboxAddress("Trung", _MailSettings.Mail));
        
        email.To.Add(new MimeKit.MailboxAddress(To, To));
        email.Subject = Subject;

        var buider = new MimeKit.BodyBuilder();
        buider.HtmlBody = Body;

        email.Body = buider.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            await smtp.ConnectAsync(_MailSettings.Host, _MailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_MailSettings.Mail, _MailSettings.Password);
            await smtp.SendAsync(email);

        }
        catch (Exception ex)
        {
            // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
            System.IO.Directory.CreateDirectory("mailssave");
            var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
            await email.WriteToAsync(emailsavefile);
            logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
            logger.LogError(ex.Message);

        }
        smtp.Disconnect(true);
        logger.LogInformation("send mail to: " + email);
    }
    // Chứa thông tin Email sẽ gửi (Trường hợp này chưa hỗ trợ đính kém file)

    //

}