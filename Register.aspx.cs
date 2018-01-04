using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Web.Configuration;
using DotNetOpenAuth.OpenId.RelyingParty;
using System.Web.Security;
using System.Web.Script.Serialization;
using CsCompany;
public partial class Register : System.Web.UI.Page
{
    #region Module Level objects

    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public bool IsUserLoggedIn { get; set; }
    public string ReturnURL { get; set; }

    public Int32 UserTypeID { get; set; }

    //https://www.linkedin.com/secure/developer
    string mstrAPIKeylinkedin = WebConfigurationManager.AppSettings["APIKeylinkedin"].ToString();//"7775n9xw7tseir";
    string mstrApiSecretlinkedin = WebConfigurationManager.AppSettings["ApiSecretlinkedin"].ToString();//"tesP8wzwmWGekQ9w";
    OpenIdRelyingParty openid = new OpenIdRelyingParty();

    public string FBAccessKey { get; set; }
    public string LogStatus { get; set; }
    public bool IsPostedback { get; set; }
    #endregion Module Level objects

    #region Page_Init
    /// function called when page init event get fired
    protected void Page_Init(object Sender, EventArgs e)
    {
        //This code prevents this page to go into cache
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }

    #endregion Page_Init

    #region page load
    /// page load
    protected void Page_Load(object sender, EventArgs e)
    {
        clsCompPrp cop_prp = new clsCompPrp();


        if (!IsPostBack)
        {
            txtEmailID.Text = string.Empty;
            txtpwd.Text = string.Empty;
            txtConfPwd.Text = string.Empty;

            if (Request.Form["UserTypeID"] != null && Convert.ToString(Request.Form["UserTypeID"]) != "")
            {
                UserTypeID = Convert.ToInt32(Request.Form["UserTypeID"]);

                Session["UserTypeID"] = UserTypeID;
            }

            try
            {
                var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    var decrypted = FormsAuthentication.Decrypt(cookie.Value);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    Encryption.CryptorEngine encobj = new Encryption.CryptorEngine();

                    if (!string.IsNullOrEmpty(decrypted.UserData))
                    {
                        string s = encobj.Decrypt(decrypted.UserData, true);
                        UserData data = ser.Deserialize<UserData>(s);
                        if (data != null)
                        {
                            Session["UserID"] = data.UserID;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        FBAccessKey = WebConfigurationManager.AppSettings["FbAPPKey"].ToString();

        if (Session["UserID"] != null)
        {
            IsUserLoggedIn = true;

        }
        else
        {
            IsUserLoggedIn = false;
        }

    }
    #endregion

    #region SetAuthCookie
    /// Function used to set Authentication cookie
    public void SetAuthCookie(string pstrUserName, string pstrRememberMe)
    {
        try
        {

            bool lblnIsCookiePersistent = false;

            if (pstrRememberMe.ToUpper() == "ON")
            {
                lblnIsCookiePersistent = true;
            }

            FormsAuthentication.SetAuthCookie(pstrUserName, lblnIsCookiePersistent);

            if (Response.Cookies.Count > 0)
            {
                foreach (string lstrCookieName in Response.Cookies.AllKeys)
                {
                    if (lstrCookieName == FormsAuthentication.FormsCookieName && lblnIsCookiePersistent)
                    {
                        // change the value to increase the cookies expiration by
                        Response.Cookies[lstrCookieName].Expires = DateTime.Now.AddYears(1);
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

    #region register
   
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        if (!check1.Checked)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">alert('Please agree to the TOS and Privacy Policy to continue');</script>", false);
            return;
        }
        try
        {
            btnRegister.Enabled = false;
            double ldblUserId = -1;
            string mstrEmailID = "";
            Int16 lintIsChecked = -1;
            if (check1.Checked == true)
            {
                lintIsChecked = 1;
            }
            mobjCUsers.EmailID = txtEmailID.Text.Trim();
            mobjCUsers.Password = txtpwd.Text.Trim();
            mobjCUsers.FirstName = TxtFirstName.Text.Trim();
            mobjCUsers.LastName = TxtLastName.Text.Trim();
            mobjCUsers.RegistrationTypeID = Convert.ToInt32(CConstants.enmRegistrationType.Default);
            if (chknewsletterBox.Checked)
                mobjCUsers.IsNewsLetterSubscribed = true;
            else
                mobjCUsers.IsNewsLetterSubscribed = false;
            //#Sahil:040814 -- calling function to validate user's credentials
            if (txtEmailID.Text.Trim() != "" && txtpwd.Text.Trim() != "" && lintIsChecked == 1 && TxtFirstName.Text.Trim() != "")
                mobjCUsers.RegisterUser();

            //#Sahil:040814 -- getting properties value
            ldblUserId = mobjCUsers.UserID;
            Session["UserID"] = ldblUserId.ToString();
            Session["EmailID"] = mobjCUsers.EmailID;
            mstrEmailID = mobjCUsers.EmailID;

            Session["IsCompAdmin"] = mobjCUsers.IsComp;
            Session["IsCompAdmin"] = mobjCUsers.IsCompAdmin;
            Session["OfCompID"] = mobjCUsers.OfCompID;

            Int32 lintEmailAdreadyExist = mobjCUsers.EmailAlreadyExists;
            SetAuthCookie(mstrEmailID, "0");
            if (lintEmailAdreadyExist == 0)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/index.aspx';", true);
            }
            else
            {
                lblMessageSignIn.Text = "Email ID is already registerd";
            }
            btnRegister.Enabled = true;
        }
        catch (Exception ex)
        {
            throw new Exception (ex.Message);
        }
        LogStatus = "R";

    }
    #endregion

    #region CheckBoxRequired_ServerValidate
    /// validate check box.
    protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        e.IsValid = check1.Checked;
    }
    #endregion



    protected void btnRegisterCoprate_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        if (!check1.Checked)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">alert('Please agree to the TOS and Privacy Policy to continue');</script>", false);
            return;
        }
        try
        {
            btnRegister.Enabled = false;
            double ldblUserId = -1;
            string mstrEmailID = "";
            Int16 lintIsChecked = -1;
            if (check1.Checked == true)
            {
                lintIsChecked = 1;
            }
            mobjCUsers.EmailID = txtEmailID.Text.Trim();
            mobjCUsers.Password = txtpwd.Text.Trim();
            mobjCUsers.FirstName = TxtFirstName.Text.Trim();
            mobjCUsers.LastName = TxtLastName.Text.Trim();
            mobjCUsers.CompName = txtCompanyName.Text.Trim();
            if (chknewsletterBox.Checked)
                mobjCUsers.IsNewsLetterSubscribed = true;
            else
                mobjCUsers.IsNewsLetterSubscribed = false;
            //#Sahil:040814 -- calling function to validate user's credentials
            if (txtEmailID.Text.Trim() != "" && txtpwd.Text.Trim() != "" && lintIsChecked == 1 && TxtFirstName.Text.Trim() != "")
                mobjCUsers.RegisterCorporate();
            Session["IsCompAdmin"] = mobjCUsers.IsCompAdmin;
            Session["OfCompID"] = mobjCUsers.OfCompID;
            Session["UserTypeID"] = mobjCUsers.UserTypeID;
               


            //#Sahil:040814 -- getting properties value
            ldblUserId = mobjCUsers.UserID;
            Session["UserID"] = ldblUserId.ToString();

            Session["EmailID"] = mobjCUsers.EmailID;
            mstrEmailID = mobjCUsers.EmailID;
            Int32 lintEmailAdreadyExist = mobjCUsers.EmailAlreadyExists;
            SetAuthCookie(mstrEmailID, "0");
            if (lintEmailAdreadyExist == 0)
            { 
               
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/index.aspx';", true);
            }
            else
            {
                lblMessageSignIn.Text = "Email ID is already registerd";
            }
            btnRegister.Enabled = true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        LogStatus = "R";
    }
}