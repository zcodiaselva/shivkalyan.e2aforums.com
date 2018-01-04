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
    
    public partial class ClientPermission : System.Web.UI.Page, IDisposable
    {
        CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        CCustomers mobjCCustomer = new CCustomers(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        CryptorEngine mobjEncrypt = new CryptorEngine();

        #region Pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string lstrMod = string.Empty;

                if (Request.QueryString["mode"] != null)
                    lstrMod = mobjEncrypt.Decrypt(Convert.ToString(Request.QueryString["mode"]), true);

                
                GenerateData(lstrMod);

            }//End try
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }//End catch
        }

        #endregion Pageload

        #region GenerateData
        private void GenerateData(string lstrMod)
        {
            switch (lstrMod.ToUpper())
            {
                case "AUTHORIZE":
                    {
                        try
                        {
                            AuthorizeExpert();
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

        #region AuthorizeExpert

        private void AuthorizeExpert()
        {
            Int32 CustomerID = -1;
            Int32 UserID = -1;
            Int32 ExpertID = -1;
            string lstrEmail = "";
            DataSet ds = null;
            string lstrName = "";
            string lstrCustomerName = "";
            Int32 lintStatusID = -1;
            Int32 lintProvinceID = -1;
            Int32 lintCityID = -1;
            string lstrDateOfBirth = "";
            string lstrAnniversary = "";
            string lstrAddressline1 = "";
            string lstrAddressline2 = "";
            string lstrPhone = "";
            string lstrPicture = "";
            string lstrOfficeAddress1 = "";
            string lstrOfficeAddress2 = "";
            string lstrMobile = "";
            string lstrHomeFax = "";
            string lstrOfficeFax = "";
            string lstrExtensionField = "";
            string lstrPostalCode = "";
            string lstrOfficeEmailID = "";
            string lstrDOBDatePart = "";
            string currentYear = DateTime.Now.Year.ToString();
            string lstrAniversaryDatePart = "";
            string lstrCustomerEmail = "";
          
         
            try
            {


                if (Request.QueryString["tok"] != null)
                    CustomerID = Convert.ToInt32(Request.QueryString["tok"]);

                if (Request.QueryString["UserID"] != null)
                    UserID = Convert.ToInt32(Request.QueryString["UserID"]);

                if (Request.QueryString["ExpertID"] != null)
                    ExpertID = Convert.ToInt32(Request.QueryString["ExpertID"]);

                if (CustomerID != -1)
                {

                    ds = mobjCCustomer.AuthorizeExpert(CustomerID, UserID, ExpertID);
                    if (ds != null)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["EMail"])))
                        {
                            lstrEmail = Convert.ToString(ds.Tables[1].Rows[0]["EMail"]);
                        }
                        else
                        {
                            lstrEmail = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["Full_Name"])))
                        {
                            lstrName = Convert.ToString(ds.Tables[1].Rows[0]["Full_Name"]);
                        }
                        else
                        {
                            lstrName = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Email"])))
                        {
                            lstrCustomerEmail = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                        }
                        else
                        {
                            lstrCustomerEmail = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"])))
                        {
                            lstrCustomerName = Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]);
                        }
                        else
                        {
                            lstrCustomerName = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["StatusID"])))
                        {
                            lintStatusID = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusID"]);
                        }
                        else
                        {
                            lintStatusID = -1;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ProvinceID"])))
                        {
                            lintProvinceID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProvinceID"]);
                        }
                        else
                        {
                            lintProvinceID = -1;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["CityID"])))
                        {
                            lintCityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
                        }
                        else
                        {
                            lintCityID = -1;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfBirth"])))
                        {
                            lstrDateOfBirth = Convert.ToString(ds.Tables[0].Rows[0]["DateOfBirth"]);
                            lstrDOBDatePart = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"]).ToString("dd/MM" + "/" + currentYear);
                        }
                        else
                        {
                            lstrDateOfBirth = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Anniversary"])))
                        {
                            lstrAnniversary = Convert.ToString(ds.Tables[0].Rows[0]["Anniversary"]);
                            lstrAniversaryDatePart = Convert.ToDateTime(ds.Tables[0].Rows[0]["Anniversary"]).ToString("dd/MM" + "/" + currentYear, null);
                        }
                        else
                        {
                            lstrAnniversary = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"])))
                        {
                            lstrAddressline1 = Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"]);
                        }
                        else
                        {
                            lstrAddressline1 = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line2"])))
                        {
                            lstrAddressline2 = Convert.ToString(ds.Tables[0].Rows[0]["Address_Line2"]);
                        }
                        else
                        {
                            lstrAddressline2 = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"])))
                        {
                            lstrPhone = Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"]);
                        }
                        else
                        {
                            lstrPhone = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Picture"])))
                        {
                            lstrPicture = Convert.ToString(ds.Tables[0].Rows[0]["Picture"]);
                        }
                        else
                        {
                            lstrPicture = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress1"])))
                        {
                            lstrOfficeAddress1 = Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress1"]);
                        }
                        else
                        {
                            lstrOfficeAddress1 = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress2"])))
                        {
                            lstrOfficeAddress2 = Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress2"]);
                        }
                        else
                        {
                            lstrOfficeAddress2 = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Mobile"])))
                        {
                            lstrMobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                        }
                        else
                        {
                            lstrMobile = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"])))
                        {
                            lstrHomeFax = Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"]);
                        }
                        else
                        {
                            lstrHomeFax = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeFax"])))
                        {
                            lstrOfficeFax = Convert.ToString(ds.Tables[1].Rows[0]["OfficeFax"]);
                        }
                        else
                        {
                            lstrOfficeFax = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ExtensionField"])))
                        {
                            lstrExtensionField = Convert.ToString(ds.Tables[0].Rows[0]["ExtensionField"]);
                        }
                        else
                        {
                            lstrExtensionField = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"])))
                        {
                            lstrPostalCode = Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"]);
                        }
                        else
                        {
                            lstrPostalCode = "";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficialEmailID"])))
                        {
                            lstrOfficeEmailID = Convert.ToString(ds.Tables[0].Rows[0]["OfficialEmailID"]);
                        }
                        else
                        {
                            lstrOfficeEmailID = "";
                        }
                        ltrlMessage.Text = "<span style='font-size:25px;font-weight:bold;color:green'>Expert (" + lstrEmail + ") has been authorized.</span>";
                        mobjCCustomer.AddCustomerForSelectedExpert(lstrCustomerEmail, lstrCustomerName, lintStatusID, lintProvinceID, lintCityID, lstrDateOfBirth, lstrAnniversary, lstrAddressline1, lstrAddressline2, lstrPhone, lstrPicture, lstrOfficeAddress1, lstrOfficeAddress2, lstrMobile, lstrHomeFax, lstrOfficeFax, lstrExtensionField, lstrPostalCode, ExpertID, lstrOfficeEmailID, lstrDOBDatePart, lstrAniversaryDatePart, CustomerID);
                        SendSuccessEmailToExpert(lstrEmail, lstrName);
                         }
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         

       
        #endregion AuthorizeExpert

        #region SendSuccessEmailToExpert

        private void SendSuccessEmailToExpert(string lstrEmail, string lstrName)
        {
          
            StringBuilder lobjbuilder = new StringBuilder();
            try
            {
                CMail lobjMail = new CMail();
            
                string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("AuthorizationSuccessful.txt"), Encoding.UTF8);
                lobjMail.EmailTo = lstrEmail;
                lstrMessage = lstrMessage.Replace("<User>", lstrName);
                lobjMail.Subject = "e2aForums:" + lstrName + "Authorised";
                lobjMail.MessageBody = lstrMessage;
                lobjMail.SendEMail();

            }
            catch (Exception)
            {

                // throw;
            }
        }

        #endregion SendSuccessEmailToExpert
    }
}