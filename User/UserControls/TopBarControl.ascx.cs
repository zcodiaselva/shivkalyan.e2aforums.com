using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserControls_TopBarControl : System.Web.UI.UserControl
{
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
          

       
    }
}