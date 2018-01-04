using E2aForums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

using NewsLetter;
using System.Web.Services;


public partial class Home : System.Web.UI.Page
{
   
   

    #region Module Level objects
   
    
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public string ReturnURL { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


   
}