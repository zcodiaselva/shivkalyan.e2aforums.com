using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Posts : System.Web.UI.Page
{
    public int PostID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["PostID"] != null)
        {
            PostID = Convert.ToInt32(Request.QueryString["PostID"]);

        }
    }
}