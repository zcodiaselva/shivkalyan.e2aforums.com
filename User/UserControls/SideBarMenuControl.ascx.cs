using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class User_UserControls_SideBarControl : System.Web.UI.UserControl
{
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());

    public bool IsAdmin { get; set; }
    
    public bool IsComp { get; set; }
    public bool IsCompAdmin { get; set; }
    public int OfCompID { get; set; }
    public int UserTypeID = -1;
    public int pOccupationID = 0;
    public string PlanActive { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["session_val"] == null)
            {
                get_session_now();
            }
            else if (Session["session_val"].ToString() == "NEW")
            {

            }
            else
            {
                get_session_now();
            }
            
         }
        catch {

            get_session_now();
        }
        if (Session["OccupationID"] != null)
        {
            pOccupationID = Convert.ToInt32(Session["OccupationID"].ToString());
        }
        if (Session["IsAdmin"] != null)
        {
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        }

        if (Session["IsComp"] != null)
        {
            IsComp = Convert.ToBoolean(Session["IsComp"]);
        }

        if (Session["IsCompAdmin"] != null)
        {
            IsCompAdmin = Convert.ToBoolean(Session["IsCompAdmin"]);
        }

        if (Session["OfCompID"] != null)
        {
            OfCompID =Convert.ToInt32( Session["OfCompID"].ToString());
        }

        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }

        if (Session["PlanActive"] != null)
        {
            PlanActive = Session["PlanActive"].ToString();
        }
    }

    private void get_session_now()
    {
        mobjCUsers.UserID = Convert.ToInt32(Session["UserID"]);
        mobjCUsers.get_Session();
        Session["OccupationID"] = mobjCUsers.OccupationID;
        Session["IsCompAdmin"] = mobjCUsers.IsCompAdmin;
        Session["IsComp"] = mobjCUsers.IsComp;
        Session["OfCompID"] = mobjCUsers.OfCompID;
        Session["UserTypeID"] = mobjCUsers.UserTypeID;
        Session["UserID"] = mobjCUsers.UserID;
      //Session["EmailID"] = mobjCUsers.EmailID;
        Session["IsAdmin"] = mobjCUsers.IsAdmin;
        Session["IsApproved"] = mobjCUsers.IsApproved;
        Session["session_val"] = mobjCUsers.session_val;
        Session["PlanActive"] = mobjCUsers.PlanActive;
     
    }
}