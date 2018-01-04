using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;


/// <summary>
/// Summary description for CMail
/// </summary>
public class CMail
{
    #region Properties
    public string EmailTo { get; set; }
    public string Subject { get; set; }
    public string MessageBody { get; set; }
    #endregion

    #region SendMail
    public void SendEMail()
    {

        using (MailMessage emailMessage = new MailMessage())
        {
            SmtpClient smtp = null;
            try
            {

                emailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["EmailFrom"].ToString(), "FetchFind");

                emailMessage.To.Add(new MailAddress(EmailTo.Trim()));
                emailMessage.Subject = Subject;
                emailMessage.Body = MessageBody;
                emailMessage.IsBodyHtml = true;

                smtp = new SmtpClient(WebConfigurationManager.AppSettings["smtp"].ToString(), Convert.ToInt32(WebConfigurationManager.AppSettings["Port"].ToString()));

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["EmailFrom"].ToString(), WebConfigurationManager.AppSettings["EmailFromPass"].ToString());
                smtp.EnableSsl = true;
                smtp.Send(emailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Send Email Failed." + ex.Message);
            }
            finally
            {
                if (smtp != null)
                    smtp.Dispose();
            }
        }
    }
    #endregion
}