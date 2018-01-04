using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using E2aForums;
using System.Web.Configuration;
using System.Text;
using System.Web.Security;
using System.Web.Script.Serialization;


public partial class User_FBSuccess : System.Web.UI.Page
{
    #region Module Level Objects & Variables
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    bool isUserRegistered = false;
    double mdblUserID = -1;
    string FirstName = "";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        string lstrMode = "";
        Int32 lintEmailExistanceStatus = -1;

        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Request.QueryString["Mode"] != null)
            lstrMode = Convert.ToString(Request.QueryString["Mode"]);

        if (Session["AccessToken"] != null)
        {
            var accessToken = Convert.ToString(Session["AccessToken"]);

            var client = new FacebookClient(accessToken);
            dynamic result = client.Get("me", new { fields = "name,id, email" });
            string name = result.name;
            string id = result.id;
            string email = result.email;
            Session["AccessToken"] = string.Empty;

            if (lstrMode != "l")
            {
                //#Sahil:040814 -- setting properties value
                mobjCUsers.EmailID = email;
                mobjCUsers.Password = name;
               // mobjCUsers.FullName = name;
                mobjCUsers.FirstName = name;
              //  mobjCUsers.LastName = name;
                //#A MN: 041514 - Added Registation Type
                mobjCUsers.RegistrationTypeID = Convert.ToInt32(CConstants.enmRegistrationType.Facebook);

                if (Session["UserTypeID"] != null)
                {
                    mobjCUsers.UserTypeID = Convert.ToInt32((Session["UserTypeID"]));
                }
                else
                { 
                    mobjCUsers.UserTypeID = -1;
                }

                //#Sahil:040814 -- calling function to validate user's credentials
                mobjCUsers.RegisterUser();
                Session["IsAdmin"] = mobjCUsers.IsAdmin;
                // Session["IsUserLoginDisabled"] = mobjCUsers.IsUserLoginDisabled;
                Session["IsApproved"] = mobjCUsers.IsApproved;
                Session["UserTypeID"] = mobjCUsers.UserTypeID;
                //Sahil:040814 -- calling function to creat auth cookie
                Session["UserID"] = mobjCUsers.UserID;
                Session["EmailID"] = mobjCUsers.EmailID;
                Session["OccupationID"] = mobjCUsers.OccupationID;
                SetAuthCookie(email, "0", mobjCUsers.UserID);

                try
                {
                    //#A MN: 041514 -calling function to send verification email
                    //SendVerificationEmail(mobjCUsers.UserID, email, Convert.ToInt32(CConstants.enmRegistrationType.LinkedIn));
                }
                catch (Exception) { }

                try
                {
                    //#A MN: 043014 - Calling function to send verfication email to email as well.
                    //SendVerificationEmail(mobjCUsers.UserID, WebConfigurationManager.AppSettings["VerificationAdminEmail"].ToString(), Convert.ToInt32(CConstants.enmRegistrationType.Facebook), "r", "Admin");
                }
                catch (Exception) { }

                lintEmailExistanceStatus = mobjCUsers.EmailAlreadyExists;


                if (mobjCUsers.Status == 1)
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowMessage('Your email is already registered with us, it has been linked to your account.'," + lintEmailExistanceStatus + "); </script>", false);
                else
                   this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">redirectToProfile();</script>", false);
            }
            else
            {
                if (mobjCUsers.AddLinkedAccountForUser(email, Convert.ToInt32(CConstants.enmRegistrationType.Facebook), mdblUserID))
                {
                    //#A MN: 041514 -calling function to send verification email
                    //SendVerificationEmail(mdblUserID, email, Convert.ToInt32(CConstants.enmRegistrationType.Facebook), "l");

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowProfileMessage('Facebook account added successfully.','s')</script>", false);
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowProfileMessage('A Facebook account is already added to you account.','f')</script>", false);
                }
            }

            isUserRegistered = true;
        }
    }
    #endregion

    #region SendVerificationEmail
    /// <summary>
    /// function used to send verification email
    /// </summary>
    private void SendVerificationEmail(double UserID, string email, Int32 pintRegTypID, string VerficationTypeID = "r", string pstrUser = "User")
    {
        StringBuilder lobjbuilder = new StringBuilder();
        try
        {
            CMail lobjMail = new CMail();
            Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
            string lstrURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "verify.aspx?tok=" + UserID.ToString() + "&r=" + pintRegTypID + "&t=" + VerficationTypeID;// +"&e=" + lobjEnc.Encrypt(email, true);
            string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("../VerificationMailContent.txt"), Encoding.UTF8);
            lstrMessage = lstrMessage.Replace("<Verifylink>", HttpUtility.UrlEncode(lstrURL));
            lstrMessage = lstrMessage.Replace("<VerifylinkOriginal>", lstrURL);
            lstrMessage = lstrMessage.Replace("<User>", pstrUser);
            lobjMail.EmailTo = email;
            lobjMail.Subject = "E2A: Facebook Email Verification";
            lobjMail.MessageBody = lstrMessage;
            lobjMail.SendEMail();

        }
        catch (Exception)
        {

            // throw;
        }
    }
    #endregion

    #region SendVerificationEmail -- commented
    /// <summary>
    /// function used to send verification email
    /// </summary>
    /*private void SendVerificationEmail(double UserID, string email, Int32 pintRegTypID, string VerficationTypeID = "r")
    {
        StringBuilder lobjbuilder = new StringBuilder();
        try
        {
            CMail lobjMail = new CMail();
            Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
            string lstrURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "verify.aspx?tok=" + UserID.ToString() + "&r=" + pintRegTypID + "&t=" + VerficationTypeID;// +"&e=" + lobjEnc.Encrypt(email, true);
            string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("VerificationMailContent.txt"), Encoding.UTF8);
            lstrMessage = lstrMessage.Replace("<Verifylink>", HttpUtility.UrlEncode(lstrURL));
            lstrMessage = lstrMessage.Replace("<VerifylinkOriginal>", lstrURL);
            lobjMail.EmailTo = email;
            lobjMail.Subject = "Instynt: Email Verification";
            lobjMail.MessageBody = lstrMessage;
            lobjMail.SendEMail();

        }
        catch (Exception)
        {

            // throw;
        }
    }*/
    #endregion

    #region SetAuthCookie
    /// <summary>
    /// Function used to set Authentication cookie
    /// </summary>
    /// <exclude>
    /// Author - Sahil Sharma
    /// Create Date - 091013
    /// </exclude>
    /// <param name="pstrUserName"></param>
    /// <param name="pstrRememberMe"></param>
    public void SetAuthCookie(string pstrUserName, string pstrRememberMe, double pdbluserid)
    {
        try
        {

            bool lblnIsCookiePersistent = false;

            //if (chkRememberMe.Checked)
            //{
            //    lblnIsCookiePersistent = true;
            //}

            FormsAuthentication.SetAuthCookie(pdbluserid.ToString(), lblnIsCookiePersistent);
            UserData userdata = new UserData() { UserID = pdbluserid, FirstName = pstrUserName };
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Encryption.CryptorEngine encobj = new Encryption.CryptorEngine();
            string str = encobj.Encrypt(ser.Serialize(userdata), true);

            if (Response.Cookies.Count > 0)
            {
                foreach (string lstrCookieName in Response.Cookies.AllKeys)
                {
                    if (lstrCookieName == FormsAuthentication.FormsCookieName && lblnIsCookiePersistent)
                    {
                        /*
                        /// In order to pickup the settings from config, we create a default cookie and use its values to create a 
                        /// new one.
                        var cookie = FormsAuthentication.GetAuthCookie(pdbluserid.ToString(), lblnIsCookiePersistent);
                        var ticket = FormsAuthentication.Decrypt(cookie.Value);

                        var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration,
                            ticket.IsPersistent, str, ticket.CookiePath);
                        var encTicket = FormsAuthentication.Encrypt(newTicket);

                        /// Use existing cookie. Could create new one but would have to copy settings over...
                        cookie.Value = encTicket;
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);

                        //#A Sahil:091013 - change the value to increase the cookies expiration by
                        // Response.Cookies[lstrCookieName].Expires = DateTime.Now.AddDays(7);
                         */

                        //if (chkRememberMe.Checked)
                        //{
                        //    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        //}

                        //Response.Cookies["UserName"].Value = txtRegEmail.Text.Trim();
                        //Response.Cookies["Password"].Value = txtRegPwd.Text.Trim();
                    }
                    else
                    {
                        //Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        //Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion SetAuthCookie
}