using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string lstrCookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[lstrCookieName];
            Session.Abandon();
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                FormsAuthentication.SignOut();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
        Response.Redirect("Home.aspx");
    }
}