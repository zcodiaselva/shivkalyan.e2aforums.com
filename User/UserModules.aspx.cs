using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserModules : System.Web.UI.Page
{
    public string Section { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Section"] != null)
            Section = Convert.ToString(Request.QueryString["Section"]);
    }

   
}