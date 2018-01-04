using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.Script.Serialization;

public partial class mapforward : System.Web.UI.Page
{
    string EmailID { get; set; }
    String Password { get; set; }
    String FirstName { get; set; }
    String LastName { get; set; }
    String RegistrationTypeID { get; set; }
    String IsNewsLetterSubscribed { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            EmailID = Request.QueryString["EmailID"];
            Password = Request.QueryString["Password"];
            FirstName = Request.QueryString["FirstName"];
            LastName = Request.QueryString["LastName"];
            GetResult();
             
        }
        catch
        {
            Response.Redirect("index.aspx", false);
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

           
                lblnIsCookiePersistent = true;
        

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

                        
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);


                            Response.Cookies["UserName"].Value = EmailID.Trim();
                            Response.Cookies["Password"].Value = Password.Trim();
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
    public void GetResult()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_MapForwordRegisterUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = EmailID;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            cmd.Parameters.Add("@RegistrationTypeID", SqlDbType.Int).Value = Convert.ToInt32(4);
            cmd.Parameters.Add("@IsNewsLetterSubscribed", SqlDbType.Int).Value = Convert.ToInt32(0);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            cmd.Dispose();
            if (dt.Rows.Count != 0)
            {
                Session["UserID"] = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                Session["EmailID"] = dt.Rows[0]["EMail"].ToString();
                Session["IsAdmin"] = dt.Rows[0]["IsAdmin"].ToString();

                Session["IsApproved"] = dt.Rows[0]["IsApproved"].ToString();
                Session["UserTypeID"] = dt.Rows[0]["UserTypeID"].ToString();
                
                Session["IsCompAdmin"] = Convert.ToBoolean(dt.Rows[0]["IsCompAdmin"].ToString());
                Session["IsComp"] = Convert.ToBoolean(dt.Rows[0]["IsComp"].ToString());
                Session["OfCompID"] = dt.Rows[0]["OfCompID"].ToString();
                Session["session_val"] = null;
            SetAuthCookie(dt.Rows[0]["EMail"].ToString().Trim(), "0", Convert.ToInt32(Session["UserID"]));
             Response.Redirect("User/WebConference.aspx", false);
            }
            else
            {
                //DataTable dt2 = new DataTable();
                //SqlCommand cmd2 = new SqlCommand("sp_ValidateUser", con);
                //cmd2.CommandType = CommandType.StoredProcedure;
                //cmd2.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = EmailID;
                //cmd2.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
                //con.Open();
                //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                //da2.Fill(dt2);
                //con.Close();
                //cmd2.Dispose();
                //if (dt2.Rows.Count != 0)
                //{
                //    Session["UserID"] = Convert.ToInt32(dt2.Rows[0]["UserID"].ToString());
                //    Session["EmailID"] = dt2.Rows[0]["EMail"].ToString();
                //    Session["IsAdmin"] = dt2.Rows[0]["IsAdmin"].ToString();

                //    Session["IsApproved"] = dt2.Rows[0]["IsApproved"].ToString();
                //    Session["UserTypeID"] = dt2.Rows[0]["UserTypeID"].ToString();

                //    Session["IsCompAdmin"] = dt2.Rows[0]["IsCompAdmin"].ToString();
                //    Session["IsComp"] = dt2.Rows[0]["IsComp"].ToString();
                //    Session["OfCompID"] = dt2.Rows[0]["OfCompID"].ToString();
                //    string val = Session["UserID"].ToString();
                //    string val2 = Session["EmailID"].ToString();
                //    SetAuthCookie(dt2.Rows[0]["EMail"].ToString().Trim(), "0",Convert.ToInt32(Session["UserID"]));
                //    Response.Redirect("User/WebConference.aspx",false);
                    
                //}
                Response.Redirect("index.aspx", false);
            }
           
        }
        catch (Exception ex)
        {

            Response.Redirect("index.aspx", false);
        }
    }
}