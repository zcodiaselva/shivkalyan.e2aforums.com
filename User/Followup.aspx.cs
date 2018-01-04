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
public partial class User_pro : System.Web.UI.Page
{
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    public Int32 CustomerID = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["CustomerID"] != null)
            {
                CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"].ToString());


            }
        }
        catch (Exception)
        {

            throw;
        }

        try
        {
            int PageIsAuth = 0;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string CurentUrl = path.Substring(Convert.ToInt32(path.LastIndexOf("/")) + 1, Convert.ToInt32(path.Length) - Convert.ToInt32(path.LastIndexOf("/")) - 1);
            if (Session["UserID"] != null)
            {
                int UserCurId = Convert.ToInt32(Session["UserID"]);
                PageIsAuth = mobjCUser.PageAuthenticationCheck(CurentUrl, UserCurId);
                if (PageIsAuth != 1)
                {
                    Response.Redirect("../AccessDenied.html");
                }
            }
            else
            {
                Response.Redirect("logout.aspx", false);
            }
        }
        catch
        {

        }
    }

}