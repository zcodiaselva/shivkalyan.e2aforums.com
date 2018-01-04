using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class User_pro : System.Web.UI.Page
{
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
 
    double mdblUserID = -1;
    public bool IsAdmin { get; set; }
    public int UserTypeID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Session["IsAdmin"] != null)
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        else
            IsAdmin = false;
        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }



        int outputUserPAss= mobjCUsers.UserSocialUpdatePassCheck(Convert.ToInt32(mdblUserID));
        if (outputUserPAss == 1)
        {
            Panel_passupd.Visible = true;
        
        }
        else
        {
            Panel_passupd.Visible = false;
        
        }

        
    }

    [System.Web.Services.WebMethod]

    public static string GetSetSessionValue(string EmpName)
    {

        //As this is a static method, we can access session using HttpContext.Current.Session

        if (EmpName.Length > 0)
        {

            HttpContext.Current.Session["EmpName"] = EmpName;

        }

        if (HttpContext.Current.Session["EmpName"] != null)
        {

            EmpName = Convert.ToString(HttpContext.Current.Session["EmpName"]);

        }

        return EmpName; // Return the session value

    }





    protected void btn_changePswd_Click(object sender, EventArgs e)
    {
         Int32 outpassd= mobjCUsers.UserSocialUpdatePass(Convert.ToInt32(mdblUserID),txt_confirmpswd.Text);
         if (outpassd == 1)
         {
             lbl_msg_success.ForeColor = System.Drawing.Color.Green;
             lbl_msg_success.Text = "Password has been updated successfully.";
            Panel_passupd.Visible = false;
        }
    }
}