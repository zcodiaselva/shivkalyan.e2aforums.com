using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Data;

public partial class User_LogInPanel : System.Web.UI.Page
{
    #region Module Level objects
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public string ReturnURL { get; set; }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                /*
                // Retrieves the cookie that contains your custom FormsAuthenticationTicket.
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null)
                {
                    // Decrypts the FormsAuthenticationTicket that is held in the cookie's .Value property.
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    // The "authTicket" variable now contains your original, custom FormsAuthenticationTicket,
                    // complete with User-specific custom data.  You can then check that the FormsAuthenticationTicket's
                    // .Name property is for the correct user, and perform the relevant functions with the ticket.
                    // Here, we simply write the user-specific data to the Http Response stream.
                    if (!string.IsNullOrEmpty(authTicket.Name))
                    {
                        txtRegEmail.Text = authTicket.Name;
                    }
                }
                */
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtRegEmail.Text = Request.Cookies["UserName"].Value;
                    txtRegPwd.Attributes["value"] = Request.Cookies["Password"].Value;
                }

            }
            catch (Exception)
            {

                // throw;
            }


        }
    }
    #endregion

    #region SignIn
    protected void btnSignIn_Click(object sender, EventArgs e)
    {

        if (!IsValid)
            return;

        btnSignIn.Enabled = false;
        lblMessageSignIn.Visible = false;

        //#A: Sahil: 040814 -- local variables 
        double ldblUserId = -1;
       
       
        //#Sahil:040814 -- setting properties value
        mobjCUsers.EmailID = txtRegEmail.Text.Trim();
        mobjCUsers.Password = txtRegPwd.Text.Trim();
       

        //#Sahil:040814 -- calling function to validate user's credentials
        mobjCUsers.ValidateUser();

        //#Sahil:040814 -- getting properties value
        ldblUserId = mobjCUsers.UserID;
        Session["CityID"] = mobjCUsers.mdblCityID;
        Session["UserID"] = ldblUserId.ToString();
        // ldblUserTypeID = mobjCUsers.UserType;
       
        if (Request.QueryString["ReturnUrl"] != null)
        {
            ReturnURL = Convert.ToString(Request.QueryString["ReturnUrl"]);
            if (ReturnURL.IndexOf(".aspx") == -1)
                ReturnURL = string.Empty;
        }

        if (ldblUserId != -1)
        {
            if (!mobjCUsers.IsUserLoginDisabled && mobjCUsers.IsApproved)
            {
                //Sahil:040814 -- setting value to session
                Session["UserID"] = ldblUserId.ToString();
               
                Session["Email"] = txtRegEmail.Text.Trim();
                Session["IsAdmin"] = mobjCUsers.IsAdmin;
                Session["IsUserLoginDisabled"] = mobjCUsers.IsUserLoginDisabled;
                Session["IsApproved"] = mobjCUsers.IsApproved;
                Session["UserTypeID"] = mobjCUsers.UserTypeID;
                //Sahil:040814 -- calling function to creat auth cookie
                SetAuthCookie(txtRegEmail.Text.Trim(), "0", ldblUserId);

                if (mobjCUsers.IsAdmin)
                {
                    
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/Users.aspx';", true);
                }
                else
                {
                    if (mobjCUsers.UserTypeID == 2)
                    {
                        if (mobjCUsers.CommConsent == -1)
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/UserDetail.aspx';", true);
                        else
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/Forum.aspx';", true);
                        //Response.Redirect("Profile.aspx", true);
                    }
                    else
                    {
                        if (mobjCUsers.CommConsent == -1)
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/UserDetail.aspx';", true);
                        else
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/Experts.aspx';", true);
                        
                    }
                }
            }

            else if (!mobjCUsers.IsApproved && mobjCUsers.UserTypeID==2)
            {
               
                if (mobjCUsers.CommConsent == -1)
                {
                    SetAuthCookie(txtRegEmail.Text.Trim(), "0", ldblUserId);
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/UserDetail.aspx';", true);
                }
                else
                {
                    lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold'>You account is awaiting admin approval, please wait for 48 hours.</span></center>";
                    lblMessageSignIn.Visible = true;
                }

            }
           
            else
            {
                lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold'>You account has been disabled, please contact admin.</span></center>";
                lblMessageSignIn.Visible = true;
            }

        }
        else
        {
            lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold;'>Incorrect Email / Password<br/>(At least 6 characters with 1 letter and 1 number)</span></center>";
            lblMessageSignIn.Visible = true;
        }

        btnSignIn.Enabled = true;
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

            if (chkRememberMe.Checked)
            {
                lblnIsCookiePersistent = true;
            }

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

                        if (chkRememberMe.Checked)
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        }

                        Response.Cookies["UserName"].Value = txtRegEmail.Text.Trim();
                        Response.Cookies["Password"].Value = txtRegPwd.Text.Trim();
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
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

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='ForgotPassword.aspx';", true);
        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "temp", "<script type='text/javascript'>window.parent.hideSocialLinks();</script>", false);         
    }

    //#region btn_Advisor_Click
    //protected void btn_Advisor_Click(object sender, EventArgs e)
    //{
    //     //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='Advisor/index.html';", true);
    //    Response.Redirect("Advisor/index.html");
    //    return;
    //}
    //#endregion btn_Advisor_Click
}