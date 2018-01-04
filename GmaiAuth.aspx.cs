using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using E2aForums;
using System.Web.Configuration;
using System.Text;
using System.Web.Security;
using System.Web.Script.Serialization;


public partial class User_GmaiAuth : System.Web.UI.Page
{
    #region Module Level Objects & Variables
   // OpenIdRelyingParty openid = new OpenIdRelyingParty();
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
   // bool isUserRegistered = false;
   // double mdblUserID = -1;
   // string Mode = "";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Mode = "";
            string Email = "";
            string Gender = "";
            string Name = "";
            Int32 lintEmailExistanceStatus = -1;
            if (Request.Form["Mode"] != null)
                Mode = Convert.ToString(Request.Form["Mode"]);
            if (Request.Form["Email"] != null)
                Email = Convert.ToString(Request.Form["Email"]);
            if (Request.Form["Gender"] != null)
                Gender = Convert.ToString(Request.Form["Gender"]);
            if (Request.Form["Name"] != null)
                Name = Convert.ToString(Request.Form["Name"]);
            if (Mode == "Reg")
            {
                //#Sahil:040814 -- setting properties value
                mobjCUsers.EmailID = Email;
                mobjCUsers.Password = Name;
                mobjCUsers.FullName = Name;
                mobjCUsers.FirstName = Name;
                //#A MN: 041514 - Added Registation Type
                mobjCUsers.RegistrationTypeID = Convert.ToInt32(CConstants.enmRegistrationType.Gmail);

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
                SetAuthCookie(Email, "");
                //if (mobjCUsers.EmailAlreadyExists == 0)
                //    Response.Redirect("User/Forum.aspx", true);
                //else
                //    Response.Redirect("User/Forum.aspx", true);
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
                        //#A Sahil:091013 - change the value to increase the cookies expiration by
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
}