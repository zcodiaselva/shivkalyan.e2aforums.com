using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserControls_SideBarControl : System.Web.UI.UserControl
{
    public bool IsAdmin { get; set; }
    public int UserTypeID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] != null)
        {
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        }

        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }
    }
}