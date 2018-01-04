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

public partial class _Default : System.Web.UI.Page
{
    cls_newslatter_prp obj_news_prp = new cls_newslatter_prp();
    cls_NEWSLATTER_CLs obj_news = new cls_NEWSLATTER_CLs();


    #region Module Level objects


    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public string ReturnURL { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {


                DataSet ds = mobjCUsers.GetMemberTopicCount();
                lbl_Member_count.Text = ds.Tables[0].Rows[0]["Count_Member"].ToString();
                lbl_Topic_count.Text = ds.Tables[1].Rows[0]["Count_Topic"].ToString();


                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtRegEmail.Text = Request.Cookies["UserName"].Value;
                    txtRegPwd.Attributes["value"] = Request.Cookies["Password"].Value;
                }
                // string TotalOnlineUsers_count = Application["TotalOnlineUsers"].ToString();

                string numbers = Application["TotalOnlineUsers"].ToString();
                int[] intArray = new int[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    intArray[i] = Int32.Parse(numbers[i].ToString());

                    if (i == 0)
                    {
                        lbl_digit1_TotalOnlineUsers.Text = intArray[i].ToString();
                    }
                    if (i == 1)
                    {
                        lbl_digit2_TotalOnlineUsers.Text = intArray[i].ToString();
                    }
                    if (i == 2)
                    {
                        lbl_digit3_TotalOnlineUsers.Text = intArray[i].ToString();
                    }

                    if (i == 3)
                    {
                        lbl_digit4_TotalOnlineUsers.Text = intArray[i].ToString();
                    }
                    if (i == 4)
                    {
                        lbl_digit5_TotalOnlineUsers.Text = intArray[i].ToString();
                    }
                    if (i == 5)
                    {
                        lbl_digit6_TotalOnlineUsers.Text = intArray[i].ToString();
                    }
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

    //wrapper class
    public class ServiceResponse
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    //[WebMethod]
    //public Int32 NewsLatterSave(string Email)
    //{

    //    ServiceResponse serviceResponse = new ServiceResponse();

    //     obj_news_prp.EMAil=Email;
    //    Int32 out_put_parm= obj_news.save_newLatter(obj_news_prp);

    //    if (out_put_parm==1)
    //    {
    //        //rest of the code
    //        serviceResponse.IsSuccess = true;
    //       // serviceResponse.Message = String.Join(",", data.ToArray());
    //    }
    //    else
    //    {
    //        //rest of the code
    //        serviceResponse.IsSuccess = false;
    //    }

    //    return new JavaScriptSerializer().Serialize(serviceResponse);
    //}
    [System.Web.Services.WebMethod]
    public Int32 Save_Data(string Email)
    {
        Int32 out_put_parm = 0;
        try
        {
            obj_news_prp.EMAil = Email;
            out_put_parm = obj_news.save_newLatter(obj_news_prp);
            return out_put_parm;
        }
        catch (Exception Ex)
        {
            return out_put_parm;
        }

    }
    #region SetAuthCookie
    /// <summary>
    /// Function used to set Authentication cookie
    /// </summary>
    /// <exclude>
    /// Author - Sahil Sharma
    /// Create Date - 091013
    /// </exclude>
    /// <param name="pstrUserName"></param>
    /// <param name="pstrRememberMe"></param>
    public void SetAuthCookie(string pstrUserName, string pstrRememberMe, double pdbluserid)
    {
        try
        {

            bool lblnIsCookiePersistent = false;

            if (chkRememberMe.Checked)
            {
                lblnIsCookiePersistent = true;
            }

            FormsAuthentication.SetAuthCookie(pdbluserid.ToString(), lblnIsCookiePersistent);
            UserData userdata = new UserData() { UserID = pdbluserid, FirstName = pstrUserName };
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Encryption.CryptorEngine encobj = new Encryption.CryptorEngine();
            string str = encobj.Encrypt(ser.Serialize(userdata), true);

            if (Response.Cookies.Count > 0)
            {
                foreach (string lstrCookieName in Response.Cookies.AllKeys)
                {
                    if (lstrCookieName == FormsAuthentication.FormsCookieName && lblnIsCookiePersistent)
                    {

                        if (chkRememberMe.Checked)
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        }

                        Response.Cookies["UserName"].Value = txtRegEmail.Text.Trim();
                        Response.Cookies["Password"].Value = txtRegPwd.Text.Trim();
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion SetAuthCookie

    #region forget password
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx", true);
        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='ForgotPassword.aspx';", true);
    }
    #endregion

    #region signin
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSignIn_Click(object sender, EventArgs e)
    {


        if (!IsValid)
            return;

        btnSignIn.Enabled = false;
        lblMessageSignIn.Visible = false;

        //#A: Sahil: 040814 -- local variables 
        double ldblUserId = -1;


        //#Sahil:040814 -- setting properties value
        mobjCUsers.EmailID = txtRegEmail.Text.Trim();
        mobjCUsers.Password = txtRegPwd.Text.Trim();


        //#Sahil:040814 -- calling function to validate user's credentials
        mobjCUsers.ValidateUser();

        //#Sahil:040814 -- getting properties value
        ldblUserId = mobjCUsers.UserID;
        Session["CityID"] = mobjCUsers.mdblCityID;
        Session["UserID"] = ldblUserId.ToString();
        // ldblUserTypeID = mobjCUsers.UserType;
        Session["OccupationID"] = mobjCUsers.OccupationID;
        Session["IsUserLoginDisabled"] = mobjCUsers.IsUserLoginDisabled;

        Session["PlanActive"] = mobjCUsers.PlanActive;
        if (Request.QueryString["ReturnUrl"] != null)
        {
            ReturnURL = Convert.ToString(Request.QueryString["ReturnUrl"]);
            if (ReturnURL.IndexOf(".aspx") == -1)
                ReturnURL = string.Empty;
        }

        if (ldblUserId != -1)
        {

            Session["UserID"] = ldblUserId.ToString();
            Session["EmailID"] = txtRegEmail.Text.Trim();
            Session["IsAdmin"] = mobjCUsers.IsAdmin;

            Session["IsApproved"] = mobjCUsers.IsApproved;
            Session["UserTypeID"] = mobjCUsers.UserTypeID;

            Session["IsCompAdmin"] = mobjCUsers.IsCompAdmin;
            Session["IsComp"] = mobjCUsers.IsComp;
            Session["OfCompID"] = mobjCUsers.OfCompID;


            SetAuthCookie(txtRegEmail.Text.Trim(), "0", ldblUserId);


            if (!mobjCUsers.IsUserLoginDisabled)
            {

                if (ReturnURL != string.Empty && ReturnURL != "" && ReturnURL != null)
                {
                    Response.Redirect(ReturnURL, true);
                }

                else
                {
                    Response.Redirect("User/index.aspx", true);
                }

                


            }
            else
            {
                lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold'>You account has been disabled, please register yourself again.</span></center>";
                lblMessageSignIn.Visible = true;
            }
        }

        else
        {
            lblMessageSignIn.Text = "Incorrect Email / Password<br/>(At least 6 characters with 1 letter and 1 number) <br />";
            lblMessageSignIn.Visible = true;
        }

        btnSignIn.Enabled = true;

    }
    #endregion
}