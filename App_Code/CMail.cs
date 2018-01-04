using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;



public class CMail
{
    #region Properties
    public string EmailTo { get; set; }
    public string Subject { get; set; }
    public string MessageBody { get; set; }
    public string EmailFrom { get; set; }
    public string Password { get; set; }
    #endregion

    #region SendMail
    public void SendEMail()
    {
      
        try
        {
            MailMessage msg = new MailMessage();

            msg.To.Add(EmailTo.Trim());

            MailAddress address = new MailAddress(WebConfigurationManager.AppSettings["EmailFrom"].ToString());
            msg.From = address;
            msg.Subject = Subject;
            msg.Body = MessageBody;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            
            client.Host = WebConfigurationManager.AppSettings["smtp"].ToString();// "relay-hosting.secureserver.net";
            client.Port = Convert.ToInt32(WebConfigurationManager.AppSettings["Port"].ToString());// 25;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            NetworkCredential credentials = new NetworkCredential(WebConfigurationManager.AppSettings["EmailFrom"].ToString(), WebConfigurationManager.AppSettings["EmailFromPass"].ToString());
            //NetworkCredential credentials = new NetworkCredential("e2aforums@gmail.com", "Humbhi42#");
            client.Credentials = credentials;

            client.Send(msg);
          

        }
        catch (Exception)
        {
            throw;
        }
        
    }//end function

    #endregion SendMail


    #region SendMail
    public void SendEMail1()
    {

        using (MailMessage emailMessage = new MailMessage())
        {
            SmtpClient smtp = null;
            try
            {

                 emailMessage.From = new MailAddress(EmailTo.Trim());

                 emailMessage.To.Add(new MailAddress(WebConfigurationManager.AppSettings["EmailFrom"].ToString()));
                emailMessage.Subject = Subject;
                emailMessage.Body = MessageBody;
                emailMessage.IsBodyHtml = true;

                smtp = new SmtpClient(WebConfigurationManager.AppSettings["smtp"].ToString(), Convert.ToInt32(WebConfigurationManager.AppSettings["Port"].ToString()));

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("humbhijasmeet2@gmail.com", "humbhi42");
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