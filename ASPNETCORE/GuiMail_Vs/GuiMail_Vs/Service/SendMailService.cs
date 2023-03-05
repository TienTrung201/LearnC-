using Microsoft.Extensions.Options;

public class SendMailService:ISendMailService
{
    MailSettings _MailSettings { get; set; }

    public SendMailService(IOptions<MailSettings> mailSettings)
    {
        _MailSettings = mailSettings.Value;
    }
    public async Task<string> SendMail(MailContent mailcontent)
    {
        var email = new MimeKit.MimeMessage();
        email.Sender = new MimeKit.MailboxAddress("Trung", _MailSettings.Mail);
        email.From.Add(new MimeKit.MailboxAddress("Trung", _MailSettings.Mail));
        
        email.To.Add(new MimeKit.MailboxAddress("Phúc ngáo ngơ", mailcontent.To));
        email.Subject = mailcontent.Subject;

        var buider = new MimeKit.BodyBuilder();
        buider.HtmlBody = mailcontent.Body;

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
            return $"Lỗi {_MailSettings.Mail} { _MailSettings.Password}  " + ex.Message;
        }
        smtp.Disconnect(true);
        return "gửi mail thành công";
    }
    // Chứa thông tin Email sẽ gửi (Trường hợp này chưa hỗ trợ đính kém file)

}