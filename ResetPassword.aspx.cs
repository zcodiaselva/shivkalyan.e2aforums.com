using E2aForums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : System.Web.UI.Page
{
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string mstrResponseData = "";
    public string RandomCode { get; set; }
    public Int32 RequestUserID { get; set; }
    public Int32 UserID { get; set; }
  
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                if (Request.QueryString["tok"] != null)
                    RandomCode = Convert.ToString(Request.QueryString["tok"]);

                if (Request.QueryString["ID"] != null)
                    RequestUserID = Convert.ToInt32(Request.QueryString["ID"]);


                UserID = mobjCUser.ValidateRandomCode(RandomCode, RequestUserID);
                if (UserID != -1)
                {
                    hiddID.Value = UserID.ToString();

                }
                else
                {
                    lblNewPassword.Visible = false;
                    NewPassword.Visible = false;
                    lblConfirmPswd.Visible = false;
                    ConfirmPassword.Visible = false;
                    lblMessage.Text = "Sorry, we are not able find your details. Please register to continue";
                    //err msg
                }

            }//End try
            catch (Exception ex)
            {
               // throw new Exception(ex.Message.ToString());
            }//End catch
        }
    }
    protected void ResetPassword_Click(object sender, EventArgs e)
    {
        string lstrNewPass = "";
        Int32 lintUserID = -1;
        try
        {
            if (Request.Form["NewPassword"] != null)
                lstrNewPass = Convert.ToString(Request.Form["NewPassword"]);

            lintUserID = Convert.ToInt32(hiddID.Value);
            bool lbnrResult = mobjCUser.ResetPassword(lstrNewPass, lintUserID);

            if (lbnrResult == true )
            {
                mstrResponseData = "SUCCESS";
                string message = "Password has been reset successfully.";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("<script type='text/javascript'>");

                sb.Append("window.onload=function(){");

                sb.Append("alert('");

                sb.Append(message);

                sb.Append("');");

                sb.Append("window.location='Login.aspx';};");

                sb.Append("</script>");

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

                // lblMessage.Text = "Password has been reset successfully";
                // Response.Redirect("Index.aspx");
            }

            else
                mstrResponseData = "Failure";
        }
        catch (Exception)
        {
            throw;
        }
    }

}