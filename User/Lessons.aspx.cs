using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_pro : System.Web.UI.Page
{
    public int ChapterID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["i"] != null)
            {
                ChapterID = Convert.ToInt32(Request.QueryString["i"].ToString());


            }
        }
        catch (Exception)
        {

            throw;
        }
    }

}