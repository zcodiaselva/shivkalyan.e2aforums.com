using E2aForums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text;
using NewsLetter;
using System.Web.Services;
public partial class _Default : System.Web.UI.Page
{

    #region Module Level objects


    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public string ReturnURL { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append("Name: " + txtName.Text + "<br />Contact No: " + txtPhone.Text + "<br />Email: " + txtEmail.Text + "<br />Company Name: " + txtCompanyName.Text + "<br /><br /><br /> Subject : " + txtSubject.Text + "<br /><br /> Message : " + txtmessage.Text);
        lblMessage.Text = "Email Sent SucessFully.";
        if (!IsValid)
            return;
        lblMessage.Text = "";
        try
        {
            CUser lobjUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);



            CMail lobjMail = new CMail();
            Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();

            lobjMail.EmailTo = "support@e2aforums.com";
            lobjMail.Subject = "e2aForums: Support";
            lobjMail.MessageBody = strBuilder.ToString();
            lobjMail.SendEMail();

            lblMessage.ForeColor = System.Drawing.Color.Green;


            lblMessage.Text = "<div class='alert alert-success center'><strong>Thank You! We will get back to you soon.</strong></div>";

            txtSubject.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtName.Text = string.Empty;
            txtmessage.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompanyName.Text = string.Empty;





        }
        catch (Exception)
        {
            throw;
        }




    }
}