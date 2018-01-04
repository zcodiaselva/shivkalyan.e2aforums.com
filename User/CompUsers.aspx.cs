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
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class User_pro : System.Web.UI.Page
{
    double mdblUserID = -1;
    public bool IsAdmin { get; set; }
    public int UserTypeID = -1;
    #region Module Level objects

    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public bool IsUserLoggedIn { get; set; }
    public string ReturnURL { get; set; }



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
        try
        {
            int PageIsAuth = 0;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string CurentUrl = path.Substring(Convert.ToInt32(path.LastIndexOf("/")) + 1, Convert.ToInt32(path.Length) - Convert.ToInt32(path.LastIndexOf("/")) - 1);
            if (Session["UserID"] != null)
            {
                int UserCurId = Convert.ToInt32(Session["UserID"]);
                PageIsAuth = mobjCUsers.PageAuthenticationCheck(CurentUrl, UserCurId);
                if (PageIsAuth != 1)
                {
                    Response.Redirect("../AccessDenied.html");
                }
            }
            else
            {
                Response.Redirect("logout.aspx", false);
            }
        }
        catch
        {

        }
        clsCompPrp cop_prp = new clsCompPrp();

        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Session["IsAdmin"] != null)
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        else
            IsAdmin = false;
   
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
            mobjCUsers.OfCompID = Convert.ToInt32(Session["OfCompID"]);
            if (chknewsletterBox.Checked)
                mobjCUsers.IsNewsLetterSubscribed = true;
            else
                mobjCUsers.IsNewsLetterSubscribed = false;
            //#Sahil:040814 -- calling function to validate user's credentials
            if (txtEmailID.Text.Trim() != "" && txtpwd.Text.Trim() != "" && lintIsChecked == 1 && TxtFirstName.Text.Trim() != "")
                mobjCUsers.CompanyUserAdd();
            Int32 lintEmailAdreadyExist = mobjCUsers.EmailAlreadyExists;
            SetAuthCookie(mstrEmailID, "0");
            if (lintEmailAdreadyExist == 0)
            {
             
                lblMessageSignIn.Text = TxtFirstName.Text.Trim() +" "+ TxtLastName.Text.Trim() +" has been added successfully!";
                lblMessageSignIn.ForeColor = System.Drawing.Color.Green;
                txtEmailID.Text=String.Empty;
                 txtpwd.Text = String.Empty;
                 TxtFirstName.Text=String.Empty;
                 TxtLastName.Text = String.Empty;
                //GetAllCompUser
            }
            else
            {
                lblMessageSignIn.Text = "Email ID is already registerd";
                lblMessageSignIn.ForeColor = System.Drawing.Color.Red;
                
            }
            btnRegister.Enabled = true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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



  
}