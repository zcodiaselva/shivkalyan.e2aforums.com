using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using E2aForums;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class User_UserControls_TopBarControl : System.Web.UI.UserControl
{
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());

    public int OccupationID = 0;
    double mdblUserID = -1;
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
     
        if (Session["OccupationID"] != null)
        {
            OccupationID = Convert.ToInt32(Session["OccupationID"]);
          
        }
        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        int outputUserPAss = mobjCUsers.UserSocialUpdatePassCheck(Convert.ToInt32(mdblUserID));
        if (outputUserPAss == 1)
        {
            Panel_lockScreen.Visible = false;

        }
        else
        {
            Panel_lockScreen.Visible = true;

        }
    }



   
    
}