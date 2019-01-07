using System.Net.Mail;

namespace Seldino.Infrastructure.Email
{
	public class SmtpClientProxy : ISmtpClient
	{
		private readonly SmtpClient _smtpClient;

		public SmtpClientProxy()
		{
			_smtpClient = new SmtpClient();
		}

		public SmtpClientProxy(SmtpClient smtpClient)
		{
			_smtpClient = smtpClient;
		}

		#region ISmtpClient Members

		public void Send(MailMessage mailMessage)
		{
			_smtpClient.Send(mailMessage);
		}

		#endregion
	}
}