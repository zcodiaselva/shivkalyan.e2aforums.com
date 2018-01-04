using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using payment_cc;
using E2aForums;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class User_pro : System.Web.UI.Page
{
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    double mdblUserID = -1;
    public Int32 ReferenceID { get; set; }
    public int UserTypeID = -1;
    public string NotificationType { get; set; }
    public Int32 NotificationID { get; set; }
    public bool IsAdmin { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
       

        try
        {
            int PageIsAuth = 0;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string CurentUrl = path.Substring(Convert.ToInt32(path.LastIndexOf("/")) + 1, Convert.ToInt32(path.Length) - Convert.ToInt32(path.LastIndexOf("/")) - 1);
            if (Session["UserID"] != null)
            {
                //int UserCurId = Convert.ToInt32(Session["UserID"]);
                //PageIsAuth = mobjCUser.PageAuthenticationCheck(CurentUrl, UserCurId);
                //if (PageIsAuth != 1)
                //{
                //    Response.Redirect("../AccessDenied.html");
                //}
            }
            else
            {
                Response.Redirect("logout.aspx", false);
            }
        }
        catch
        {

        }
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