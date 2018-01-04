using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_pro : System.Web.UI.Page
{
    double mdblUserID = -1;
    public Int32 ReferenceID { get; set; }
    public int UserTypeID = -1;
    public string NotificationType { get; set; }
    public Int32 NotificationID { get; set; }
    public bool IsAdmin { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Session["IsAdmin"] != null)
        {
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        }
        else
            IsAdmin = false;
        if (Request.Form["Type"] != null)
            NotificationType = Convert.ToString(Request.Form["Type"]);

        if (Request.Form["ID"] != null)
        {
            ReferenceID = Convert.ToInt32(Request.Form["ID"]);
        }
        if (Request.Form["NotificationID"] != null)
        {
            NotificationID = Convert.ToInt32(Request.Form["NotificationID"]);
        }

        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }

    }

}