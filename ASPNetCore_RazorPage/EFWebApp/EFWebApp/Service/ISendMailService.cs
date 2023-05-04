using System.Threading.Tasks;

public interface ISendMailService {
    Task<string> SendMail(MailContent mailContent);
}