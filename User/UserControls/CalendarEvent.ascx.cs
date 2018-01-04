using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_CalendarEvent : System.Web.UI.UserControl
{
    double mdblUserID = -1;
    public bool IsAdmin { get; set; }
   

    public double UserID
    {
        get { return mdblUserID; }
        set { mdblUserID = value; }
    }
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
    
    }
}