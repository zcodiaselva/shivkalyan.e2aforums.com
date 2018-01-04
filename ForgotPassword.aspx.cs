using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Net;
public partial class ForgotPassword : System.Web.UI.Page
{

    public string pageTitle { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString["pageTitle"].ToString() != null || Request.QueryString["pageTitle"].ToString() != string.Empty)
                {
                    pageTitle = Request.QueryString["pageTitle"].ToString();

                }
                else
                {
                    pageTitle = "-1";
                }
            }
        }
        catch
        {
            pageTitle = "-1";
        }

    }

    #region BtnSubmit click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        lblMessage.Text = "";
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[20];
        var random = new Random();
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var lstrRandomCode = new String(stringChars);
 
        try
        {
            CUser lobjUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

            DataSet ds = lobjUsers.ForgotPassword(txtRegEmail.Text.Trim(), lstrRandomCode);

            if (ds != null)
            {
                string lstrName = "";
                // string lstrPass = "";
                Int32 lintRequestUserId = -1;

                if (ds.Tables[0].Rows[0]["RequestUserID"] != null)
                {
                    lintRequestUserId = Convert.ToInt32(ds.Tables[0].Rows[0]["RequestUserID"]);
                }
                if (lintRequestUserId != -1)
                {
                    if (ds.Tables[0].Rows[0]["Full_Name"] != null)
                    {
                        lstrName = Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]);

                        if (string.IsNullOrEmpty(lstrName))
                            lstrName = "User";
                    }
                    else
                        lstrName = "User";

                    //if (ds.Tables[0].Rows[0]["Password"] != null)
                    //{
                    //    lstrPass = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    //}

                    //if (!string.IsNullOrEmpty(lstrPass))
                    //{
                    CMail lobjMail = new CMail();
                    Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
                    string lstrResetURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "ResetPassword.aspx?tok=" + lstrRandomCode.ToString() + "&ID=" + lintRequestUserId;
                    string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("ForgotPassMailContent.txt"), Encoding.UTF8);
                    lstrMessage = lstrMessage.Replace("<Name>", lstrName);
                    lstrMessage = lstrMessage.Replace("<Email>", txtRegEmail.Text);
                    //lstrMessage = lstrMessage.Replace("<Password>", lstrPass);
                    lstrMessage = lstrMessage.Replace("<ResetLink>", lstrResetURL);
                    lobjMail.EmailTo = txtRegEmail.Text.Trim();
                    lobjMail.Subject = "e2aForums: Reset Password";
                    lobjMail.MessageBody = lstrMessage;
                    lobjMail.SendEMail();


                    //SmtpClient   SMTPClientObj = new SmtpClient();
                    //SMTPClientObj.UseDefaultCredentials = false;
                    //SMTPClientObj.Credentials = new System.Net.NetworkCredential("contact.e2aforums@gmail.com", "Oakville##1@e");
                    //SMTPClientObj.Host = "smtp.gmail.com";
                    //SMTPClientObj.Port = 587;
                    //SMTPClientObj.EnableSsl = true;
                    //SMTPClientObj.Send("contact.e2aforums@gmail.com", "davinderantil@gmail.com", "test", "testbody");
                    txtRegEmail.Text = string.Empty;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.BackColor = System.Drawing.Color.White;
                        lblMessage.Text = "A mail has been sent to your email address containing your credentials";
                   // }
                }
                else if (lintRequestUserId == -1)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Sorry, we are not able find your details. Please register to continue";
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Sorry, we are not able find to your details. Please register to continue";
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region Cancel button click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx", true);     
    }
    #endregion
}