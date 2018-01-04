using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using System.Web.Configuration;
using E2aForums;
using System.Text;
using System.Web.Security;

public partial class User_Callback : System.Web.UI.Page
{
    #region Module level Object & Variables
    string mstrAPIKeylinkedin = WebConfigurationManager.AppSettings["APIKeylinkedin"].ToString();//"7775n9xw7tseir";
    string mstrApiSecretlinkedin = WebConfigurationManager.AppSettings["ApiSecretlinkedin"].ToString();//"tesP8wzwmWGekQ9w";
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    double mdblUserID = -1;
    string Mode = "";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Convert.ToString(Request.QueryString["code"]);
        string state = Convert.ToString(Request.QueryString["state"]);

        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Request.QueryString["Mode"] != null)
            Mode = Convert.ToString(Request.QueryString["Mode"]);

        if (!string.IsNullOrEmpty(code))
        {
            string struri = "https://www.linkedin.com/uas/oauth2/accessToken?grant_type=authorization_code&code=" + code + "&redirect_uri=" + WebConfigurationManager.AppSettings["DomainName"].ToString() + "Callback.aspx?Mode=" + Mode + "&client_id=" + mstrAPIKeylinkedin + "&client_secret=" + mstrApiSecretlinkedin;

            HttpWebRequest webRequest = HttpWebRequest.Create(new Uri(struri)) as HttpWebRequest;
            webRequest.Method = System.Net.WebRequestMethods.Http.Get;
            webRequest.ContentLength = 0;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                HttpWebResponse webresponse;
                webresponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                string result = sr.ReadToEnd().ToString();
                LinkInAccessToken obj = new JavaScriptSerializer().Deserialize<LinkInAccessToken>(result);

                if (obj != null)
                {
                    if (!string.IsNullOrEmpty(obj.access_token))
                    {
                        doit(obj.access_token);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
    #endregion

    #region Doit
    private void doit(string accesstoken)
    {
        //string struri = "https://api.linkedin.com/v1/people/~?oauth2_access_token="+accesstoken;
        string struri = "https://api.linkedin.com/v1/people/~:(id,first-name,last-name,email-address)?oauth2_access_token=" + accesstoken;
        Int32 lintEmailExistanceStatus = -1;

        HttpWebRequest webRequest = HttpWebRequest.Create(new Uri(struri)) as HttpWebRequest;
        webRequest.Method = System.Net.WebRequestMethods.Http.Get;
        webRequest.ContentLength = 0;
        webRequest.ContentType = "application/x-www-form-urlencoded";
        double ldblUserId = -1;

        try
        {
            HttpWebResponse webresponse;
            webresponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webresponse.GetResponseStream());
            string result = sr.ReadToEnd().ToString();

            if (!string.IsNullOrEmpty(result))
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(result)))
                {
                    reader.ReadToFollowing("person");

                    reader.ReadToFollowing("id");
                    string id = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("first-name");
                    string fname = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("last-name");
                    string lname = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("email-address");
                    string email = reader.ReadElementContentAsString();

                    if (Mode != "l")
                    {
                        //Response.Write("id: " + id + "<br/>First Name:" + fname + "<br/>Last Name:" + lname + "<br/>Email:" + email); 

                        //#Sahil:040814 -- setting properties value
                        mobjCUsers.EmailID = email;
                        mobjCUsers.Password = fname;
                        mobjCUsers.FullName = fname + " " + lname;
                        mobjCUsers.FirstName = fname;
                        mobjCUsers.LastName = lname;
                        //#A MN: 041514 - Added Registation Type
                        mobjCUsers.RegistrationTypeID = Convert.ToInt32(CConstants.enmRegistrationType.LinkedIn);

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
                        ldblUserId = mobjCUsers.UserID;
                        Session["UserID"] = ldblUserId.ToString();
                        Session["EmailID"] = mobjCUsers.EmailID;
                        //Sahil:040814 -- calling function to creat auth cookie
                        SetAuthCookie(email, "0", mobjCUsers.UserID);

                        try
                        {
                            //#A MN: 041514 -calling function to send verification email
                            //SendVerificationEmail(ldblUserId, email, Convert.ToInt32(CConstants.enmRegistrationType.LinkedIn));
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
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowMessage('Your email is already registered with us, it has been linked to your account.'," + lintEmailExistanceStatus + "); </script>", false);
                        }
                        else
                        {
                            //string strDomainName = WebConfigurationManager.AppSettings["DomainName"].ToString();
                            //Response.Redirect(strDomainName + "Profile.aspx");
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">redirectToProfile(); </script>", false);
                        }
                    }
                    else
                    {
                        if (mobjCUsers.AddLinkedAccountForUser(email, Convert.ToInt32(CConstants.enmRegistrationType.LinkedIn), mdblUserID))
                        {
                            //#A MN: 041514 -calling function to send verification email
                            //SendVerificationEmail(mdblUserID, email, Convert.ToInt32(CConstants.enmRegistrationType.LinkedIn), "l");

                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowProfileMessage('Linkedin account added successfully.','s')</script>", false);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowProfileMessage('A Linkedin account is already added to you account.','f')</script>", false);
                        }
                    }
                }
            }
            //Response.Write(result);
        }
        catch (Exception)
        {
            throw;
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
            lobjMail.Subject = "E2A: LinkedIn Email Verification";
            lobjMail.MessageBody = lstrMessage;
            lobjMail.SendEMail();
        }
        catch (Exception)
        {

            // throw;
        }
    }
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


public class LinkInAccessToken
{
    public string expires_in { get; set; }
    public string access_token { get; set; }
}