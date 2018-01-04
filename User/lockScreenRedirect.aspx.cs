using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_lockScreenRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string email   = Session["EmailID"].ToString();
        Session.Abandon();

        Response.Redirect("../lock_screen.aspx?email="+email);
    }
    
}