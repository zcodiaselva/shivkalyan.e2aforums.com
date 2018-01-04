using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;


public partial class User_linkauth : System.Web.UI.Page
{

    //https://www.linkedin.com/secure/developer
    string mstrAPIKeylinkedin = WebConfigurationManager.AppSettings["APIKeylinkedin"].ToString();//"Uf5WddJN80hwsiUa";
    string mstrApiSecretlinkedin = WebConfigurationManager.AppSettings["ApiSecretlinkedin"].ToString();//"tesP8wzwmWGekQ9w";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Mode = "";
            if (Request.QueryString["Mode"] != null)
                Mode = Convert.ToString(Request.QueryString["Mode"]);

            Response.Redirect("https://www.linkedin.com/uas/oauth2/authorization?response_type=code&client_id=" + mstrAPIKeylinkedin + "&scope=r_basicprofile r_emailaddress &state=sfsdfsfsdghfghfg&redirect_uri=" + WebConfigurationManager.AppSettings["DomainName"].ToString() + "Callback.aspx?Mode=" + Mode, false);
        //Response.Redirect("https://www.linkedin.com/uas/oauth2/authorization?response_type=code&client_id=755xl7z5zxzgde&scope=r_basicprofile&state=abcdefghi&redirect_uri=http://e2aforums.com/Callback.aspx
        
        }
    }
}