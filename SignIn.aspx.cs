using E2aForums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    #region Module Level objects
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public string ReturnURL { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtRegEmail.Text = Request.Cookies["UserName"].Value;
                    txtRegPwd.Attributes["value"] = Request.Cookies["Password"].Value;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }

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

    #region forget password
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx", true);
        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='ForgotPassword.aspx';", true);
    }
    #endregion

    #region signin
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        Session["OccupationID"] = mobjCUsers.OccupationID;
        Session["IsUserLoginDisabled"] = mobjCUsers.IsUserLoginDisabled;
        if (Request.QueryString["ReturnUrl"] != null)
        {
            ReturnURL = Convert.ToString(Request.QueryString["ReturnUrl"]);
            if (ReturnURL.IndexOf(".aspx") == -1)
                ReturnURL = string.Empty;
        }

        if (ldblUserId != -1)
        {
            //if (!mobjCUsers.IsUserLoginDisabled && mobjCUsers.IsApproved)
            //{
            //Sahil:040814 -- setting value to session
            Session["UserID"] = ldblUserId.ToString();

            Session["EmailID"] = txtRegEmail.Text.Trim();
            Session["IsAdmin"] = mobjCUsers.IsAdmin;
            // Session["IsUserLoginDisabled"] = mobjCUsers.IsUserLoginDisabled;
            Session["IsApproved"] = mobjCUsers.IsApproved;
            Session["UserTypeID"] = mobjCUsers.UserTypeID;
            //Sahil:040814 -- calling function to creat auth cookie
            SetAuthCookie(txtRegEmail.Text.Trim(), "0", ldblUserId);

            //if (mobjCUsers.IsAdmin)
            //{
            if (!mobjCUsers.IsUserLoginDisabled)
            {
                Response.Redirect("User/Forum.aspx", true);

            }
            else
            {
                lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold'>You account has been disabled, please register yourself again.</span></center>";
                lblMessageSignIn.Visible = true;
            }

            // }
            //else
            //{

            //    Response.Redirect("User/Experts.aspx", true);
            //}


        }

        else
        {
            lblMessageSignIn.Text = "Incorrect Email / Password<br/>(At least 6 characters with 1 letter and 1 number) <br />";
            lblMessageSignIn.Visible = true;
        }

        btnSignIn.Enabled = true;

    }
    #endregion
}