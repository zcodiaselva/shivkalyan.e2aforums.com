using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

public partial class _sendmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var fromAddress = new MailAddress("e2aforums@gmail.com", "From Name");
        var toAddress = new MailAddress(txtTo.Text.Trim(), "To Name");
        const string fromPassword = "Humbhi42#";
        const string subject = "Subject";
        const string body = "Body";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 25,
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }
}