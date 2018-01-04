using E2aForums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UploadExcelFile : System.Web.UI.Page
{
    #region Module Level Objects

    // Module level object declaration.
    CCommon mobjCCommon = new CCommon(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    CCustomers mobjCCustomer = new CCustomers(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    #endregion Module Level Objects

    #region Module Level Variables

    private OleDbConnection connection;
    private OleDbDataAdapter daAdapter;
    private string SheetName, Range;

    double ldblTotalRowCount = 0;
    double UserID = -1;
    public string Mode { get; set; }
    #endregion Module Level Variables

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    #region button click
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload_TBSxls.HasFile)
        {
            UploadExcelSheet();
        }

    }
    #endregion button click

    #region UploadExcelSheet
    /// *******************************************************************************
    /// <summary>
    /// This function is used to upload excel sheet in database.
    /// </summary>
    /// <remarks>
    /// <Author>Jasmeet Kaur</Author>
    /// <Date> 011514 </Date>    
    /// </remarks>  
    /// *******************************************************************************   
    public void UploadExcelSheet()
    {
        try
        {
            // DataSet lobjDS = new DataSet();
            Button1.Enabled = false;
            string lstrFileName = Path.GetFileName(FileUpload_TBSxls.FileName);

            string s = @"([<>\?\*\\\""/\|])+";
            //lstrFileName = "<123?.csv";

            Regex rg = new Regex(s);
            //bool b = rg.IsMatch("abc<"); // True;
            //bool a = rg.IsMatch("abc");  // false

            bool b = rg.IsMatch(lstrFileName);
            if (b)
            {
                string replacestr = Regex.Replace(lstrFileName, @"[[<>\?\*\\\""/\|]+", "_");
                lstrFileName = replacestr;
            }

            string ExcelExtension = Path.GetExtension(FileUpload_TBSxls.FileName);

            //if (ExcelExtension.ToUpper() == ".XLS" || ExcelExtension.ToUpper() == ".XLSX")
            if (ExcelExtension.ToUpper() == ".CSV")
            {
                string lstrCurrDateTime = DateTime.Now.ToString("dd-MM-yyyy h-mm-ss-tt");

                string lstrModifiedFileName = lstrCurrDateTime + "_" + lstrFileName;

                FileUpload_TBSxls.SaveAs(Server.MapPath("UploadedCvs" + "/" + lstrModifiedFileName));

                string physicalpath = Server.MapPath("UploadedCvs/");

                string filefullpath = physicalpath + lstrModifiedFileName;



                // lobjDS = GetAllDataSet(filefullpath);
                DataTable datatab = new DataTable();

                datatab = GetDataTableFromCsv(filefullpath, true);

                AddXLSDetails(datatab, lstrModifiedFileName);


                /*if (File.Exists(filefullpath))
                {
                    File.Delete(filefullpath);
                }*/
                FileUpload_TBSxls = null;

                lblUpload.ForeColor = System.Drawing.Color.Green;
                lblUpload.Text = "File has been uploaded sucessfully.";
                //Response.Redirect("Customers.aspx",true);
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='Customers.aspx';", true);
                lblUpload.Visible = true;
                Button1.Enabled = true;
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">return HideModal(); </script>", false);

                //FileUpload_TBSxls.Attributes.Clear();

            }
            else
            {
                lblUpload.ForeColor = System.Drawing.Color.Red;
                lblUpload.Text = "Please select *.cvs file for upload.";
                lblUpload.Visible = true;
                form_UploadExcel.Visible = false;

            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error ocurred while Uploading File " + ex.Message);
        }


    }// end of UploadExcelSheet()


    #endregion UploadExcelSheet()

    #region GetDataTableFromCsv
    private static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
    {
        try
        {

            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }

        }
        catch (Exception)
        {

            throw;
        }

    }
    #endregion GetDataTableFromCsv

    #region AddXLSDetails
    /// <summary>
    /// A public function used to get uploaded file details to their respective tables.
    /// </summary>
    /// <Author> Jasmeet kaur    </Author>
    /// <Date>   011514   </Date>
    /// <returns> Nothing </returns>
    /// *******************************************************************************
    public void AddXLSDetails(DataTable pobjDS, string pstrfilename)
    {

        try
        {

            for (int i = 0; i < pobjDS.Rows.Count; i++)
            {
                InsertDetails(pobjDS.Rows[i], pstrfilename);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error ocurred while executing AddXLSDetails(). " + ex.Message);
        }

    }//end of function AddXMLDetails

    #endregion AddXLSDetails

    #region InsertDetails
    /// <summary>
    /// A public function used to Insert uploaded data to their respective tables.
    /// </summary>
    /// <Author>   Jasmeet kaur   </Author>
    /// <Date>   01152014   </Date>
    /// <returns> Nothing </returns>
    private void InsertDetails(DataRow lobjRW, string lstrfilename)
    {
        string lstrTitle = "";
        string lstrFirstName = "";
        string lstrLastName = "";
        string lstrEmail = "";
        string lstrAddress1 = "";
        string lstrAddress2 = "";
        string lstrDOB = "";
        string lstrAnniversary = "";
        Int32 lintStatusID = -1;
        string lstrPhone = "";
        string lstrImages = "";
        Int32 lintStateID = -1;
        Int32 lintCityID = -1;
        Int32 lintUserID = -1;
        Int32 lintCustomerID = -1;
        string lstrFollowUpText = "";
        string lstrDesc = "";
        string lstrVenue = "";
        Int32 lintFollowUpProvinceID = -1;
        Int32 lintFollowUpCityID = -1;
        string lstrFollowUpDate = "";
        string lstrStartTime = "";
        string lstrEndTime = "";
        string currentYear = DateTime.Now.Year.ToString();
        string lstrDOBDatePart = "";
        string lstrAniversaryDatePart = "";
        string lstrOfficialEmail = "";
        string lstrOfficeAddress1 = "";
        string lstrOfficeAddress2 = "";
        string lstrMobile = "";
        string lstrHomeFax ="";
        string lstrOfficeFaxNo = "";
        string lstrExtensionField ="";
        string lstrPostalCode = "";
        Int32 lintOfcStateID = -1;
        Int32 lintOfcCityID = -1;
        string lstrOfcTelephone = "";
        string lstrWork = "";
        Int32 lintMaritalStatus = -1;
        Int32 lintDependents = -1;
        Int32 lintBestCallTime = -1;
        string lstrReferredBy = "";
        Int32 lintColdLead = -1;
        string lstrFirstContact = "";
        string lstrNextContact = "";
        string lstrDiscussed = "";
        try
        {
            if (lobjRW["Title"].ToString() != "")
            {
                lstrTitle = Convert.ToString(lobjRW["Title"]);
            }
            if (lobjRW["FirstName"].ToString() != "")
            {
                lstrFirstName = Convert.ToString(lobjRW["FirstName"]).Trim();
            }
            if (lobjRW["LastName"].ToString() != "")
            {
                lstrLastName = Convert.ToString(lobjRW["LastName"]).Trim();
            }
           
            
            if (lobjRW["DateOfBirth"].ToString() != "")
            {
                lstrDOB = Convert.ToDateTime(lobjRW["DateOfBirth"]).ToString("dd/MM/yyyy");
                lstrDOBDatePart = Convert.ToDateTime(lobjRW["DateOfBirth"]).ToString("dd/MM" + "/" + currentYear);
            }
            if (lobjRW["StatusID"].ToString() != "")
            {
                lintStatusID = Convert.ToInt32(lobjRW["StatusID"]);
            }
            //if (lobjRW["Anniversary"].ToString() != "")
            //{
            //    lstrAnniversary = Convert.ToDateTime(lobjRW["Anniversary"]).ToString("dd/MM/yyyy");
            //    lstrAniversaryDatePart = Convert.ToDateTime(lobjRW["Anniversary"]).ToString("dd/MM" + "/" + currentYear);
            //}
            if (lobjRW["Address_line1"].ToString() != "")
            {
                lstrAddress1 = Convert.ToString(lobjRW["Address_line1"]).Trim();
            }
            if (lobjRW["Address_Line2"].ToString() != "")
            {
                lstrAddress2 = Convert.ToString(lobjRW["Address_Line2"]).Trim();
            }
            if (lobjRW["CityID"].ToString() != "")
            {
                lintCityID = Convert.ToInt32(lobjRW["CityID"]);
            }
            if (lobjRW["ProvinceID"].ToString() != "")
            {
                lintStateID = Convert.ToInt32(lobjRW["ProvinceID"]);
            }
            if (lobjRW["PostalCode"].ToString() != "")
            {
                lstrPostalCode = Convert.ToString(lobjRW["PostalCode"]).Trim();
            }
            if (lobjRW["PhoneNo"].ToString() != "")
            {
                lstrPhone = Convert.ToString(lobjRW["PhoneNo"]).Trim();
            }
            if (lobjRW["Mobile"].ToString() != "")
            {
                lstrMobile = Convert.ToString(lobjRW["Mobile"]).Trim();
            }
            if (lobjRW["Telephone"].ToString() != "")
            {
                lstrOfcTelephone = Convert.ToString(lobjRW["Telephone"]).Trim();
            }
            if (lobjRW["OfficeAddress_line1"].ToString() != "")
            {
                lstrOfficeAddress1 = Convert.ToString(lobjRW["OfficeAddress_line1"]).Trim();
            }
            if (lobjRW["OfficeAddress_line2"].ToString() != "")
            {
                lstrOfficeAddress2 = Convert.ToString(lobjRW["OfficeAddress_line2"]).Trim();
            }
            if (lobjRW["OfficeCityID"].ToString() != "")
            {
                lintOfcCityID = Convert.ToInt32(lobjRW["OfficeCityID"]);
            }
            if (lobjRW["OfficeProvinceID"].ToString() != "")
            {
                lintOfcStateID = Convert.ToInt32(lobjRW["OfficeProvinceID"]);
            }
            if (lobjRW["Work"].ToString() != "")
            {
                lstrWork = Convert.ToString(lobjRW["Work"]).Trim();
            }
            if (lobjRW["ExtensionField"].ToString() != "")
            {
                lstrExtensionField = Convert.ToString(lobjRW["ExtensionField"]).Trim();
            }
            if (lobjRW["Email"].ToString() != "")
            {
                lstrEmail = Convert.ToString(lobjRW["Email"]).Trim();
            }
            if (lobjRW["Official_EmailID"].ToString() != "")
            {
                lstrOfficialEmail = Convert.ToString(lobjRW["Official_EmailID"]).Trim();
            }
            if (lobjRW["Home_FaxNo"].ToString() != "")
            {
                lstrHomeFax = Convert.ToString(lobjRW["Home_FaxNo"]).Trim();
            }
            if (lobjRW["Office_FaxNo"].ToString() != "")
            {
                lstrOfficeFaxNo = Convert.ToString(lobjRW["Office_FaxNo"]).Trim();
            }
            if (lobjRW["Picture"].ToString() != "")
            {
                lstrImages = Convert.ToString(lobjRW["Picture"]).Trim();
            }
            if (lobjRW["MaritalStatus"].ToString() != "")
            {
                lintMaritalStatus = Convert.ToInt32(lobjRW["MaritalStatus"]);
            }
            if (lobjRW["Dependent"].ToString() != "")
            {
                lintDependents = Convert.ToInt32(lobjRW["Dependent"]);
            }
            if (lobjRW["BestTimeToCall"].ToString() != "")
            {
                lintBestCallTime = Convert.ToInt32(lobjRW["BestTimeToCall"]);
            }
            if (lobjRW["ReferredBy"].ToString() != "")
            {
                lstrReferredBy = Convert.ToString(lobjRW["ReferredBy"]).Trim();
            }
            if (lobjRW["ColdLead"].ToString() != "")
            {
                lintColdLead = Convert.ToInt32(lobjRW["ColdLead"]);
            }
            if (lobjRW["FirstContact"].ToString() != "")
            {
                lstrFirstContact = Convert.ToString(lobjRW["FirstContact"]).Trim();
            }
            if (lobjRW["NextContact"].ToString() != "")
            {
                lstrNextContact = Convert.ToString(lobjRW["NextContact"]).Trim();
            }
            if (lobjRW["Discussed"].ToString() != "")
            {
                lstrDiscussed = Convert.ToString(lobjRW["Discussed"]).Trim();
            }
            if (lobjRW["NextMeetingDate"].ToString() != "")
            {
                lstrFollowUpDate = Convert.ToDateTime(lobjRW["NextMeetingDate"]).ToString("dd/MM/yyyy");
            }
            if (lobjRW["NextMeetingStartTime"].ToString() != "")
            {
                lstrStartTime = Convert.ToDateTime(lobjRW["NextMeetingStartTime"]).ToString("hh:mm:ss"); 
            }
            if (lobjRW["NextMeetingEndTime"].ToString() != "")
            {
                lstrEndTime = Convert.ToDateTime(lobjRW["NextMeetingEndTime"]).ToString("hh:mm:ss");
            }

            if (lobjRW["MeetingTitle"].ToString() != "")
            {
                lstrFollowUpText = Convert.ToString(lobjRW["MeetingTitle"]).Trim();
            }
            if (lobjRW["MeetingDescription"].ToString() != "")
            {
                lstrDesc = Convert.ToString(lobjRW["MeetingDescription"]).Trim();
            }
            if (lobjRW["Venue"].ToString() != "")
            {
                lstrVenue = Convert.ToString(lobjRW["Venue"]).Trim();
            }
            if (lobjRW["MeetingProvinceID"].ToString() != "")
            {
                lintFollowUpProvinceID = Convert.ToInt32(lobjRW["MeetingProvinceID"]);
            }
            if (lobjRW["MeetingCityID"].ToString() != "")
            {
                lintFollowUpCityID = Convert.ToInt32(lobjRW["MeetingCityID"]);
            }
            
            if (Session["UserID"] != null)
            {
                lintUserID = Convert.ToInt32(Session["UserID"]);
                mobjCCommon.UserID = lintUserID;
            }

            if (Session["CustomerID"] != null)
            {
                lintCustomerID = Convert.ToInt32(Session["CustomerID"]);
                mobjCCommon.CustomerID = lintCustomerID;
            }
            string lstr = mobjCCustomer.SaveNewCustomerRecords(lstrTitle,lstrFirstName,lstrLastName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone,lstrOfcTelephone, lstrImages, lintStatusID, lintStateID, lintCityID, lintUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrFollowUpText, lstrDesc, lstrVenue, lintFollowUpProvinceID, lintFollowUpCityID, lstrFollowUpDate, lstrStartTime, lstrEndTime, lstrDOBDatePart, lstrAniversaryDatePart, lstrOfficialEmail, lstrOfficeAddress1, lstrOfficeAddress2, lstrMobile, lstrHomeFax, lstrOfficeFaxNo, lstrExtensionField, lstrPostalCode,lintMaritalStatus,lintDependents,lintBestCallTime,lstrReferredBy,lintColdLead,lstrFirstContact,lstrNextContact,lstrDiscussed,lintOfcCityID,lintOfcStateID,lstrWork);

          //  string lstr = mobjCCustomer.SaveNewCustomerRecords(lstrName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, lintUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrFollowUpText, lstrDesc, lstrVenue, lintFollowUpProvinceID, lintFollowUpCityID, lstrFollowUpDate, lstrStartTime, lstrEndTime, lstrDOBDatePart,lstrAniversaryDatePart);
          //  string lstr = mobjCCustomer.SaveNewCustomerRecords(lstrName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, lintUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrFollowUpText, lstrDesc, lstrVenue, lintFollowUpProvinceID, lintFollowUpCityID, lstrFollowUpDate, lstrStartTime, lstrEndTime, lstrDOBDatePart, lstrAniversaryDatePart,lstrOfficialEmail,lstrOfficeAddress1,lstrOfficeAddress2,lstrMobile,lstrHomeFax,lstrOfficeFaxNo,lstrExtensionField,lstrPostalCode);

            if (lstr.ToUpper() == "ALREADY EXISTS")
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowMessage('Client/Propspects already exist');$('.close').click(); GetCustomersListing(); </script>", false);

            }
            else if (lstr.ToUpper() == "ERROR")
            {

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowMessage('Some records are missing in the excel sheet, so please update the excel before upload.');$('.close').click(); GetCustomersListing(); </script>", false);


            }
            else 
            {

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "<script type=\"text/javascript\">ShowMessage('File Uploaded successfully.');$('.close').click(); GetCustomersListing(); </script>", false);


            }

        }

        catch (Exception ex)
        {
            throw new Exception("An error ocurred while executing InsertDetails(). " + ex.Message);
        }
    }//end InsertDetails()

    #endregion UploadQuestionsExcelSheet()
}