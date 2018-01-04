using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserControls_UserProfile : System.Web.UI.UserControl
{
    double mdblUserID = -1;
    public bool IsAdmin { get; set; }
    public int UserTypeID = -1;
    public string Email { get; set; }
    public bool IsUserLoggedIn { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

        IsUserLoggedIn = false;
        //#E: GD:0203_2015 changed the key to EmailID from Email.
        if (Session["EmailID"] != null)
        {
            Email = Convert.ToString(Session["EmailID"]);
            IsUserLoggedIn = true;
        }
        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Session["IsAdmin"] != null)
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        else
            IsAdmin = false;

        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }
        

    }

}