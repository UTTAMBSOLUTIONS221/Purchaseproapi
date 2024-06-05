using System.Net.Mail;

namespace DBL.Helpers
{
    public class EmailSenderHelper
    {
        public bool UttambsolutionssendemailAsync(string to, string name, string subject, string body)
        {

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            m.From = new MailAddress("support@socialpesa.com");
            m.To.Add(to);
            m.Subject = subject;
            m.Body = body;
            m.IsBodyHtml = true;
            sc.Host = "Mail.socialpesa.com";
            string str1 = "gmail.com";
            string str2 = "support@socialpesa.com";
            if (str2.Contains(str1))
            {
                try
                {
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("support@socialpesa.com", "K@ribun1");
                    sc.EnableSsl = true;
                    sc.Send(m);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    sc.Port = 25;
                    sc.Credentials = new System.Net.NetworkCredential("support@socialpesa.com", "K@ribun1");
                    sc.EnableSsl = false;
                    sc.Send(m);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
