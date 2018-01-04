using Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using E2aForums;

namespace e2aForums
{
    public partial class Verification : System.Web.UI.Page, IDisposable
    {
        CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        CryptorEngine mobjEncrypt = new CryptorEngine();
        protected void Page_Load(object sender, EventArgs e)
        {
            try                
            {
                string lstrMod = string.Empty;

                if (Request.QueryString["m"] != null)
                    lstrMod = mobjEncrypt.Decrypt(Convert.ToString(Request.QueryString["m"]), true);
                
                GenerateData(lstrMod);

            }//End try
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }//End catch
        }

        #region GenerateData

       void GenerateData(string lstrMod)
        {
            switch (lstrMod.ToUpper())
            {
                case "APPROVE":
                    {
                        try
                        {
                            ApproveUser();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    break;
                case "UNAPPROVE":
                    {
                        try
                        {
                            UnApproveUser();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    break;
                 default:

                        ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:red'>Invalid Operation</span>";
                        break;
            }
        }

     
    
        #endregion GenerateData

       #region ApproveUser

       private void ApproveUser()
       {
               Int32 UserID = -1;
               string lstrEmail = "";
               DataSet ds = null;
               try
               {

                 
                   if (Request.QueryString["tok"] != null)
                       UserID = Convert.ToInt32(Request.QueryString["tok"]);

                  
                   if (UserID != -1)
                   {
                       
                     ds = mobjCUser.ApproveUser(UserID);
                     if (ds != null)
                     {
                         lstrEmail = Convert.ToString(ds.Tables[0].Rows[0]["EMail"]);
                         ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:green'>Account(" + lstrEmail + ") has been approved.</span>";
                         SendSuccessEmailForApprove(lstrEmail);
                     }
                   }
                   else
                   {
                       ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:red'>Your account could not be approved at this time. Please try later</span>";
                   }
                  
               }
               catch (Exception ex)
               {   
                   ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:red'>Your account could not be approved at this time. Please try later.</span>";
                   throw new Exception(ex.Message);
               }
           
       }

       #endregion ApproveUser

       #region UnApproveUser
       private void UnApproveUser()
       {
           Int32 UserID = -1;
           string lstrEmail = "";
           DataSet ds = null;
           try
           {


               if (Request.QueryString["tok"] != null)
                   UserID = Convert.ToInt32(Request.QueryString["tok"]);

               
               if (UserID != -1)
               {
                   ds = mobjCUser.UnApproveUser(UserID);

                   if (ds != null)
                   {
                       lstrEmail = Convert.ToString(ds.Tables[0].Rows[0]["EMail"]);
                       ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:green'>Account has been unapproved.</span>";
                       SendSuccessEmailForUnApprove(lstrEmail);
                   }
               }
               else
               {
                   ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:red'>Your account could not be unapproved at this time. Please try later</span>";
               }
              
           }
           catch (Exception)
           {  
               ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:red'>Your account could not be unapproved at this time. Please try later.</span>";
               throw;
           }
       }

       #endregion UnApproveUser

       #region SendSuccessEmailForUnApprove
       /// <summary>
       /// function used to send verification email
       /// </summary>
       private void SendSuccessEmailForUnApprove(string pstrEmail)
       {
           StringBuilder lobjbuilder = new StringBuilder();
           try
           {
               CMail lobjMail = new CMail();
               string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("UnApprovedMailContent.txt"), Encoding.UTF8);
               lobjMail.EmailTo = pstrEmail;
               lobjMail.Subject = "e2aForums: Account Unapproved";
               lobjMail.MessageBody = lstrMessage;
               lobjMail.SendEMail();

           }
           catch (Exception)
           {

               // throw;
           }
       }
       #endregion

       #region SendSuccessEmailForApprove
       /// <summary>
       /// function used to send verification email
       /// </summary>
       private void SendSuccessEmailForApprove(string pstrEmail)
       {
           StringBuilder lobjbuilder = new StringBuilder();
           try
           {
               CMail lobjMail = new CMail();
               string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("ApproveAccountMailContent.txt"), Encoding.UTF8);
               lobjMail.EmailTo = pstrEmail;
               lobjMail.Subject = "e2aForums: Account Approved";
               lobjMail.MessageBody = lstrMessage;
               lobjMail.SendEMail();

           }
           catch (Exception)
           {

               // throw;
           }
       }
       #endregion SendSuccessEmailForApprove
    }
}