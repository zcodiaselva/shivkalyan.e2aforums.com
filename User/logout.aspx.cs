using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {


                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            //Destroys the session
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../Home.aspx");

        }
        catch
        {
            //Destroys the session
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../Home.aspx");
        
        }
            }
}