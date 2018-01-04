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
using System.Data;
using ASPSnippets.LinkedInAPI;

public partial class _Default : System.Web.UI.Page
{ 
    #region Module level Object & Variables
    string email, fname, lname;
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    double mdblUserID = -1;
    string Mode = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        LinkedInConnect.APIKey = "75882506nq95yq";
        LinkedInConnect.APISecret = "mGfusdufdaFbgcxK";
        LinkedInConnect.RedirectUrl = Request.Url.AbsoluteUri.Split('?')[0];
        if (LinkedInConnect.IsAuthorized)
        {
            pnlDetails.Visible = true;

            DataSet ds = LinkedInConnect.Fetch();
           // imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
            lblName.Text = ds.Tables["person"].Rows[0]["first-name"].ToString();
            fname = ds.Tables["person"].Rows[0]["first-name"].ToString();

          //  lblName.Text += " " + ds.Tables["person"].Rows[0]["last-name"].ToString();
            lname = ds.Tables["person"].Rows[0]["last-name"].ToString();

           // lblEmailAddress.Text = ds.Tables["person"].Rows[0]["email-address"].ToString();
            email = ds.Tables["person"].Rows[0]["email-address"].ToString();

         //   lblHeadline.Text = ds.Tables["person"].Rows[0]["headline"].ToString();
         //   lblIndustry.Text = ds.Tables["person"].Rows[0]["industry"].ToString();
          //  lblLinkedInId.Text = ds.Tables["person"].Rows[0]["id"].ToString();
          //  lblLocation.Text = ds.Tables["location"].Rows[0]["name"].ToString();
          //  imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
            doit();
        }
        if (Page.IsPostBack == false)
        {
            if (!LinkedInConnect.IsAuthorized)
            {
                LinkedInConnect.Authorize();
            }
        }
    }

    #region Doit
    private void doit()
    {
        try
        {

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

            Session["UserID"] = mobjCUsers.UserID.ToString();
            Session["EmailID"] = mobjCUsers.EmailID;
            //Sahil:040814 -- calling function to creat auth cookie
            SetAuthCookie(email, "0", mobjCUsers.UserID);



            Session["IsAdmin"] = mobjCUsers.IsAdmin;
            // Session["IsUserLoginDisabled"] = mobjCUsers.IsUserLoginDisabled;
            Session["IsApproved"] = mobjCUsers.IsApproved;
            Session["UserTypeID"] = mobjCUsers.UserTypeID;
            //Sahil:040814 -- calling function to creat auth cookie

            Session["OccupationID"] = mobjCUsers.OccupationID;






            Int32 lintEmailExistanceStatus = mobjCUsers.EmailAlreadyExists;

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
        catch(Exception ex)
        {}


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