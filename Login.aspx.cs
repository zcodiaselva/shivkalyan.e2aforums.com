using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Configuration;
using System.Drawing;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


namespace E2aForums
{
    public partial class User_Login : System.Web.UI.Page
    {

        #region Module Level objects
        CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
        public bool IsUserLoggedIn { get; set; }
        public string ReturnURL { get; set; }

        public Int32 UserTypeID { get; set; }      

        //https://www.linkedin.com/secure/developer
        string mstrAPIKeylinkedin = WebConfigurationManager.AppSettings["APIKeylinkedin"].ToString();//"7775n9xw7tseir";
        string mstrApiSecretlinkedin = WebConfigurationManager.AppSettings["ApiSecretlinkedin"].ToString();//"tesP8wzwmWGekQ9w";
        OpenIdRelyingParty openid = new OpenIdRelyingParty();

        public string FBAccessKey { get; set; }
        public string LogStatus { get; set; }
        public bool IsPostedback { get; set; }
        #endregion Module Level objects

        #region Page_Init
        /// <summary>
        /// function called when page init event get fired
        /// </summary>
        /// <author>Sahil Sharma</author>
        /// <date>040814</date>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object Sender, EventArgs e)
        {

            Response.Redirect("SignIn.aspx",false);            
            
            ////Sahil:091013 -- This code prevents this page to go into cache
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        #endregion Page_Init

        #region Page_Load
        /// <summary>
        /// function called when page load event get fired
        /// </summary>
        /// <author>Sahil Sharma</author>
        /// <date>040814</date>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmailID.Text = string.Empty;
                txtpwd.Text = string.Empty;
                txtConfPwd.Text = string.Empty;

                if (Request.Form["UserTypeID"] != null && Convert.ToString(Request.Form["UserTypeID"]) != "")
                {
                    UserTypeID = Convert.ToInt32(Request.Form["UserTypeID"]);

                    Session["UserTypeID"] = UserTypeID;
                }

                try
                {
                    var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (cookie != null)
                    {
                        var decrypted = FormsAuthentication.Decrypt(cookie.Value);
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        Encryption.CryptorEngine encobj = new Encryption.CryptorEngine();

                        if (!string.IsNullOrEmpty(decrypted.UserData))
                        {
                            string s = encobj.Decrypt(decrypted.UserData, true);
                            UserData data = ser.Deserialize<UserData>(s);
                            if (data != null)
                            {
                                Session["UserID"] = data.UserID;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                     throw;
                }

            }

            FBAccessKey = WebConfigurationManager.AppSettings["FbAPPKey"].ToString();

            if (Session["UserID"] != null)
            {
                IsUserLoggedIn = true;
                //ltrlUserView.Text = "<div class=\"customer-worker\">Logged In&nbsp;&nbsp;<span class=\"breaker\"> | </span><a href=\"Profile.aspx\">&nbsp;&nbsp;Profile</a><span class=\"breaker\"> | </span><a href=\"Logout.aspx\">&nbsp;&nbsp;Logout</a> </div>";

            }
            else
            {
                IsUserLoggedIn = false;
                //ltrlUserView.Text = "<div class=\"customer-worker\">Customer view&nbsp;&nbsp;<span class=\"breaker\"> | </span><a href=\"Professional.aspx\">&nbsp;&nbsp;Professional view</a> </div>";
            }



        }

        #endregion Page_Load

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
        public void SetAuthCookie(string pstrUserName, string pstrRememberMe)
        {
            try
            {

                bool lblnIsCookiePersistent = false;

                if (pstrRememberMe.ToUpper() == "ON")
                {
                    lblnIsCookiePersistent = true;
                }

                FormsAuthentication.SetAuthCookie(pstrUserName, lblnIsCookiePersistent);

                if (Response.Cookies.Count > 0)
                {
                    foreach (string lstrCookieName in Response.Cookies.AllKeys)
                    {
                        if (lstrCookieName == FormsAuthentication.FormsCookieName && lblnIsCookiePersistent)
                        {
                            //#A Sahil:091013 - change the value to increase the cookies expiration by
                            Response.Cookies[lstrCookieName].Expires = DateTime.Now.AddYears(1);
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

        #region Register
        /// <summary>
        /// #A:Sahil 040814 Function called when Register is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(txtEmailID.Text))
            {
                RequiredFieldValidator1.Validate();
                return;
            }
            if (string.IsNullOrEmpty(txtpwd.Text))
            {
                RequiredFieldValidator4.Validate();
                return;
            }
            if (string.IsNullOrEmpty(txtConfPwd.Text))
            {
                CompareValidator1.Validate();
                return;
            }
            if (txtpwd.Text != txtConfPwd.Text)
            {
                CompareValidator1.Validate();
                return;
            }*/

            if (!IsValid)
                return;

            if (!check1.Checked)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">alert('Please agree to the TOS and Privacy Policy to continue');</script>", false);
                return;
            }

            try
            {
                btnRegister.Enabled = false;
               
                //#A: Sahil: 040814 -- local variables 
                double ldblUserId = -1;
                string mstrEmailID = "";
                Int16 lintIsChecked = -1;

                if (check1.Checked == true)
                {
                    lintIsChecked = 1;
                }
                //#Sahil:040814 -- setting properties value
                mobjCUsers.EmailID = txtEmailID.Text.Trim();
                mobjCUsers.Password = txtpwd.Text.Trim();

                if(Session["UserTypeID"] != null)
                {
                    mobjCUsers.UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                }
                //#A MN: 041514 - Added Registation Type
                mobjCUsers.RegistrationTypeID = Convert.ToInt32(CConstants.enmRegistrationType.Default);

                if (chknewsletterBox.Checked)
                    mobjCUsers.IsNewsLetterSubscribed = true;
                else
                    mobjCUsers.IsNewsLetterSubscribed = false;

                //#Sahil:040814 -- calling function to validate user's credentials

                if (txtEmailID.Text.Trim() != "" && txtpwd.Text.Trim() != "" && lintIsChecked == 1)
                    mobjCUsers.RegisterUser();
               
                //#Sahil:040814 -- getting properties value
                ldblUserId = mobjCUsers.UserID;
                Session["UserID"] = ldblUserId.ToString();
                Session["OccupationID"] = mobjCUsers.OccupationID;
                Session["EmailID"] = mobjCUsers.EmailID;
                mstrEmailID = mobjCUsers.EmailID; ;
                //if (Request.QueryString["ReturnUrl"] != null)
                //{
                //    ReturnURL = Convert.ToString(Request.QueryString["ReturnUrl"]);
                //    if (ReturnURL.IndexOf(".aspx") == -1)
                //        ReturnURL = string.Empty;
                //}

                if (ldblUserId != -1)
                {
                    SetAuthCookie(mobjCUsers.EmailID, "");
                    //#A MN: 041514 - Calling function to send verification email.
                    //SendVerificationEmail(ldblUserId, txtEmailID.Text.Trim());

                    //Sahil:040814 -- setting value to session
                    //Session["UserID"] = ldblUserId.ToString();
                    //Sahil:040814 -- calling function to creat auth cookie
                   // SetAuthCookie(txtEmailID.Text.Trim(), "0");
                    /* lblMessageReg.Visible = true;
                     lblMessageReg.ForeColor = Color.Green;
                     lblMessageReg.Font.Size = new FontUnit(12);
                     lblMessageReg.Text = "Registration successful. Please login to continue.";*/

                    //#A JASMEET: 090514 - Calling function to send verification email 
                    //SendAdminVerificationEmail(ldblUserId, WebConfigurationManager.AppSettings["EmailFrom"].ToString(), txtEmailID.Text.Trim());
                    //SendSuccessEmail(txtEmailID.Text.Trim());

                    //lblMessageSignIn.Text = "<center><span style='color:green;font-size:12px;font-weight:bold;margin-left: 135px;'>Registration successful. Your account is awaiting administrator's approval. Please wait for the confirmation email.</span></center>";
                    //lblMessageSignIn.Visible = true;
                    //txtEmailID.Text = "";
                    if (mobjCUsers.OccupationID == 0)
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/UserDetail.aspx';", true);
                    }
                    else
                    {
                        if (mobjCUsers.IsApproved)
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='User/Forum.aspx';", true);
                        }
                       
                    }
                  //  Response.Redirect("../UserDetails.aspx");
                }
                else
                {
                    if (lintIsChecked == -1)
                    {
                        //lblMessageReg.Text = "Please agree to TOS & privacy policy";
                        //lblMessageReg.Font.Size = new FontUnit(12);
                        //lblMessageReg.Visible = true;
                        lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold;margin-left: 135px;'>Please agree to TOS & privacy policy</span></center>";
                    }
                    else
                    {
                        lblMessageSignIn.Text = "<center><span style='color:red;font-size:12px;font-weight:bold;margin-left: 135px;'>Email ID is already registerd</span></center>";

                        //lblMessageReg.Text = "Email ID is already registerd";
                        //lblMessageReg.Font.Size = new FontUnit(12);
                        //lblMessageReg.Visible = true;
                    }
                }

                btnRegister.Enabled = true;

            }
            catch (Exception)
            {

                throw;
            }
           LogStatus = "R";

        }

      
      
        #endregion Login

        //#region SendAdminVerificationEmail
        ///// <summary>
        ///// function used to send verification email
        ///// </summary>
        //private void SendAdminVerificationEmail(double ldblUserId,string email,string useremail)
        //{
        //    StringBuilder lobjbuilder = new StringBuilder();
        //    try
        //    {
        //        CMail lobjMail = new CMail();
        //        Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
        //        string lstrApproveURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "Verification.aspx?tok=" + ldblUserId.ToString() + "&m=" + lobjEnc.Encrypt("Approve", true);
        //        string lstrUnApproveURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "Verification.aspx?tok=" + ldblUserId.ToString() + "&m=" + lobjEnc.Encrypt("UnApprove", true);

        //        string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("AdminVerificationMailContent.txt"), Encoding.UTF8);
        //        //lstrMessage = lstrMessage.Replace("<Verifylink>", HttpUtility.UrlEncode(lstrURL));
        //        lstrMessage = lstrMessage.Replace("<ApprovelinkOriginal>", lstrApproveURL);
        //        lstrMessage = lstrMessage.Replace("<UnApprovelinkOriginal>", lstrUnApproveURL);
        //        lstrMessage = lstrMessage.Replace("<EMAIL_ADDRESS>", useremail);
        //        lobjMail.EmailTo = email;
        //        lobjMail.Subject = "E2A: Email Verification";
        //        lobjMail.MessageBody = lstrMessage;
        //        lobjMail.SendEMail();

        //    }
        //    catch (Exception)
        //    {
        //         throw;
        //    }
        //}
        //#endregion

        //#region SendSuccessEmail
        ///// <summary>
        ///// function used to send verification email
        ///// </summary>
        //private void SendSuccessEmail(string pstrEmail)
        //{
        //    StringBuilder lobjbuilder = new StringBuilder();
        //    try
        //    {
        //        CMail lobjMail = new CMail();
        //        string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("UserSuccessMailContent.txt"), Encoding.UTF8);
        //        lobjMail.EmailTo = pstrEmail;
        //        lobjMail.Subject = "e2aForums: Account Creation Mail";
        //        lobjMail.MessageBody = lstrMessage;
        //        lobjMail.SendEMail();

        //    }
        //    catch (Exception)
        //    {
        //         throw;
        //    }
        //}
        //#endregion

        #region CheckBoxRequired_ServerValidate
        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = check1.Checked;
        }
        #endregion

        //#region btn_Advisor_Click
        //protected void btn_Advisor_Click(object sender, EventArgs e)
        //{
        //   // this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='Advisor/index.html';", true);
        //    Response.Redirect("Advisor/index.html");
        //    return;
        //}
        //#endregion btn_Advisor_Click
    }
}