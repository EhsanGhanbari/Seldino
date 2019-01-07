using System.Net.Mail;

namespace Seldino.Infrastructure.Email
{
	public interface ISmtpClient
	{
		void Send(MailMessage mailMessage);
	}
}