using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Data;
using System.Web.Configuration;
using E2aForums;
using System.Collections;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Linq;


public partial class User_Ajax_AjaxCustomers : System.Web.UI.Page
{
    #region Module Level Objects
    DataAccess mobjDataAccess = new DataAccess();
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    CCustomers mobjCCustomer = new CCustomers(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    CCommon mobjCCommon = new CCommon(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string mstrDomainName = WebConfigurationManager.AppSettings["DomainName"].ToString();
    string mstrResponseData = "";
    #endregion

    #region Module Level Variables
    double mdblUserID = -1;
    double mdblCustomerID { get; set; }
    string mstrEmailID = "";
    double mdblCityID = -1;
    public string mstrIsAdmin { get; set; }
    public string mstrCity { get; set; }
    public string Mode { get; set; }
    double mdblZoneID = -1;
    public double mdblUserTypeID { get; set; }
    public double mdblOccupationID { get; set; }

    #endregion

    #region Page_Load
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:020905
    /// Function used to fire page load event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string lstrMod = "";
            if (Request.RequestType.ToUpper() == "POST")
            {
                //#A Sahil:072314 - Getting mode from posted form
                if (Request.Form["Mode"] != null)
                {
                    lstrMod = Request.Form["Mode"].ToString();
                }
            }

            //#A Sahil:160113 - Getting mode from posted form
            if (Request.QueryString["Mode"] != null)
            {
                lstrMod = Request.QueryString["Mode"].ToString();
            }

            if (Session["UserID"] != null)
                mdblUserID = Convert.ToDouble(Session["UserID"]);

            if (Session["EmailID"] != null)
                mstrEmailID = Convert.ToString(Session["EmailID"]);

            if (Session["CityID"] != null)
                mdblCityID = Convert.ToDouble(Session["CityID"]);

            if (Session["IsAdmin"] != null)
                mstrIsAdmin = Convert.ToString(Session["IsAdmin"]);

            if (Session["UserTypeID"] != null)
                mdblUserTypeID = Convert.ToDouble(Session["UserTypeID"]);

            if (Session["OccupationID"] != null)
                mdblOccupationID = Convert.ToDouble(Session["OccupationID"]);

            //#A Sahil:072314 - Calling function to Generate data.
            GenerateData(lstrMod);

        }//End try
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }//End catch

        //#A Sahil:072314 - Passing the response data to the calling ajax page.
        Response.Write(mstrResponseData);
        Response.Flush();
        Response.End();
    }



    #endregion Page_Load

    #region GenerateData
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:020915
    /// Generating data based on the mode passed
    /// </summary>
    /// <param name="lstrMod"></param>
    private void GenerateData(string lstrMod)
    {
        switch (lstrMod.ToUpper())
        {
            case "SAVECUSTOMERDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:020915 - Calling function to add customer by user.
                        SaveCustomerDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCUSTOMERSLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:021015 - Calling function to get customer listing.
                        GetCustomerListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETUSERNAME":
                {
                    try
                    {
                        //#A:Jasmeet:021115 - Calling function to get customer name.
                        GetUserName();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETECUSTOMER":
                {
                    try
                    {
                        //#A:Jasmeet:021115 - Calling function to delete customer .
                        DeleteCustomer();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCUSTOMERDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:021115 - Calling function to get customer details .
                        GetCustomerDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLCUSTOMERCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:021115 - Calling function to get customer details .
                        FillCustomerCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "SAVEFOLLOWUP":
                {
                    try
                    {
                        //#A:Jasmeet:021215 - Calling function to save customer for follow up .
                        SaveFollowUp();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "SAVEUSERDOCUMENTS":
                {
                    try
                    {
                        //#A:Jasmeet:021315 - Calling function to save user documents  .
                        SaveUserDocuments();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETUSERDOCLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:021315 - Calling function to save user documents  .
                        GetUserDocListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETEDOCUMENT":
                {
                    try
                    {
                        //#A:Jasmeet:021315 - Calling function to delete documents  .
                        DeleteDocument();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETDOCUMENTDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:021315 - Calling function to get documents details .
                        GetDocumentDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDNEWPRODUCTS":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to add new product .
                        AddNewProducts();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETPRODUCTSLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to get product listing .
                        GetProductListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETEPRODUCT":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to delete product .
                        DeleteProduct();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETPRODUCTDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to get product details.
                        GetProductDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "SAVECUSTOMERDOCUMENTS":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to save customer documents.
                        SaveCustomerDocuments();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCUSTOMERNAME":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to get customer name.
                        GetCustomerName();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCUSTOMERFILES":
                {
                    try
                    {
                        //#A:Jasmeet:021815 - Calling function to get customer files.
                        GetCustomerFiles();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLEXPERTSCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:031715 - Calling function to fill experts combo.
                        FillExpertsCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "SENDMAILTOCLIENT":
                {
                    try
                    {
                        //#A:Jasmeet:031815 - Calling function to send mail to client.
                        SendMailToClient();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETFOLLOWUPDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:052215 - Calling function to get followup details.
                        GetFollowUpDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "VIEWCUSTOMERPROFILE":
                {
                    try
                    {
                        //#A:Jasmeet:052215 - Calling function to view customer profile details.
                        ViewCustomerProfile();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            default:
                mstrResponseData = "Invalid mode";
                break;
        }
    }


    #endregion GenerateData

    #region Function

    #region SaveCustomerDetails
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:020915
    /// Function used to add new customer by user.
    /// </summary>
    private void SaveCustomerDetails()
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
        Int32 lintCustomerID = -1;
        string currentYear = DateTime.Now.Year.ToString();
        string lstrDOBDatePart = "";
        string lstrAniversaryDatePart = "";
        string lstrOfficeEmailID = "";
        string lstrOfficeAddress1 = "";
        string lstrOfficeAddress2 = "";
        string lstrMobile = "";
        string lstrHomeFax = "";
        string lstrOfficeFax = "";
        string lstrExtensionField = "";
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

            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["FirstName"] != null)
                lstrFirstName = Convert.ToString(Request.Form["FirstName"]);

            if (Request.Form["LastName"] != null)
                lstrLastName = Convert.ToString(Request.Form["LastName"]);

            if (Request.Form["Email"] != null)
                lstrEmail = Convert.ToString(Request.Form["Email"]);

            if (Request.Form["OfficialEmailID"] != null)
                lstrOfficeEmailID = Convert.ToString(Request.Form["OfficialEmailID"]);

            if (Request.Form["Address_line1"] != null)
                lstrAddress1 = Convert.ToString(Request.Form["Address_line1"]);

            if (Request.Form["Address_Line2"] != null)
                lstrAddress2 = Convert.ToString(Request.Form["Address_Line2"]);

            if (Request.Form["OfficeAddress1"] != null)
                lstrOfficeAddress1 = Convert.ToString(Request.Form["OfficeAddress1"]);

            if (Request.Form["OfficeAddress2"] != null)
                lstrOfficeAddress2 = Convert.ToString(Request.Form["OfficeAddress2"]);

            if (!string.IsNullOrEmpty(Request.Form["DateOfBirth"]))
            {
                lstrDOB = Convert.ToString(Request.Form["DateOfBirth"]);

            }
            if (!string.IsNullOrEmpty(Request.Form["ReminderDOB"]))
            {
                lstrDOBDatePart = Convert.ToString(Request.Form["ReminderDOB"]);
                
            }
            if (!string.IsNullOrEmpty(Request.Form["Anniversary"])) //// != null || Request.Form["Anniversary"] != "")
            {
                lstrAnniversary = Convert.ToString(Request.Form["Anniversary"]);
                //lstrAniversaryDatePart = Convert.ToDateTime(Request.Form["Anniversary"]).ToString("dd/MM" + "/" + currentYear, null);

            }
            if (!string.IsNullOrEmpty(Request.Form["ReminderAnniversary"]))
            {
                lstrAniversaryDatePart = Convert.ToString(Request.Form["ReminderAnniversary"]);
            }
            if (Request.Form["Mobile_Phone"] != null)
                lstrPhone = Convert.ToString(Request.Form["Mobile_Phone"]);

            if (Request.Form["Picture"] != null)
                lstrImages = Convert.ToString(Request.Form["Picture"]);

            if (Request.Form["Mobile"] != null)
                lstrMobile = Convert.ToString(Request.Form["Mobile"]);

            if (Request.Form["HomeFax"] != null)
                lstrHomeFax = Convert.ToString(Request.Form["HomeFax"]);

            if (Request.Form["Officefax"] != null)
                lstrOfficeFax = Convert.ToString(Request.Form["Officefax"]);

            if (Request.Form["ExtensionField"] != null)
                lstrExtensionField = Convert.ToString(Request.Form["ExtensionField"]);

            if (Request.Form["PostalCode"] != null)
                lstrPostalCode = Convert.ToString(Request.Form["PostalCode"]);

            if (!String.IsNullOrEmpty(Request.Form["StatusID"].ToString()))
                lintStatusID = Convert.ToInt32(Request.Form["StatusID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["ProvinceID"].ToString()))
                lintStateID = Convert.ToInt32(Request.Form["ProvinceID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["CityID"].ToString()))
                lintCityID = Convert.ToInt32(Request.Form["CityID"].Trim());

            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);

            if (!String.IsNullOrEmpty(Request.Form["OfficeCityID"].ToString()))
                lintOfcCityID = Convert.ToInt32(Request.Form["OfficeCityID"]);

            if (!String.IsNullOrEmpty(Request.Form["OfficeStateID"].ToString()))
                lintOfcStateID = Convert.ToInt32(Request.Form["OfficeStateID"]);

            if (Request.Form["Telephone"] != null)
                lstrOfcTelephone = Convert.ToString(Request.Form["Telephone"]);

            if (Request.Form["Work"] != null)
                lstrWork = Convert.ToString(Request.Form["Work"]);

            if (Request.Form["MaritalStatus"] != null)
                lintMaritalStatus = Convert.ToInt32(Request.Form["MaritalStatus"]);

            if (Request.Form["Dependents"] != null)
                lintDependents = Convert.ToInt32(Request.Form["Dependents"]);

            if (Request.Form["CallTime"] != null)
                lintBestCallTime = Convert.ToInt32(Request.Form["CallTime"]);

            if (Request.Form["ReferredBy"] != null)
                lstrReferredBy = Convert.ToString(Request.Form["ReferredBy"]);

            if (Request.Form["ColdLead"] != null)
                lintColdLead = Convert.ToInt32(Request.Form["ColdLead"]);

            if (Request.Form["FirstContact"] != null)
                lstrFirstContact = Convert.ToString(Request.Form["FirstContact"]);

            if (Request.Form["NextContact"] != null)
                lstrNextContact = Convert.ToString(Request.Form["NextContact"]);

            if (Request.Form["Discussed"] != null)
                lstrDiscussed = Convert.ToString(Request.Form["Discussed"]);

            string lstr = mobjCCustomer.SaveCustomerDetails(lstrTitle, lstrFirstName, lstrLastName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, mdblUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrDOBDatePart, lstrAniversaryDatePart, lstrOfficeEmailID, lstrOfficeAddress1, lstrOfficeAddress2, lstrMobile, lstrHomeFax, lstrOfficeFax, lstrExtensionField, lstrPostalCode, lintOfcCityID, lintOfcStateID, lstrOfcTelephone, lstrWork, lintMaritalStatus, lintDependents, lintBestCallTime, lstrReferredBy, lintColdLead, lstrFirstContact, lstrNextContact, lstrDiscussed);


            // string lstr = mobjCCustomer.SaveCustomerDetails(lstrName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, mdblUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrDOBDatePart, lstrAniversaryDatePart, lstrOfficeEmailID, lstrOfficeAddress1, lstrOfficeAddress2, lstrMobile, lstrHomeFax, lstrOfficeFax, lstrExtensionField, lstrPostalCode, lintOfcCityID, lintOfcStateID, lstrOfcTelephone, lstrWork);

            //  string lstr = mobjCCustomer.SaveCustomerDetails(lstrName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, mdblUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrDOBDatePart, lstrAniversaryDatePart, lstrOfficeEmailID, lstrOfficeAddress1,lstrOfficeAddress2,lstrMobile,lstrHomeFax,lstrOfficeFax,lstrExtensionField,lstrPostalCode);

            // string lstr = mobjCCustomer.SaveCustomerDetails(lstrName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, mdblUserID, lstrDOB, lstrAnniversary, lintCustomerID, lstrDOBDatePart, lstrAniversaryDatePart);
            // mobjCCustomer.SaveCustomerDetails(lstrName, lstrEmail, lstrAddress1, lstrAddress2, lstrPhone, lstrImages, lintStatusID, lintStateID, lintCityID, mdblUserID, lstrDOB, lstrAnniversary, lintCustomerID);


            if (lstr.ToUpper() == "ALREADY EXISTS")
            {
                mstrResponseData = "ALREADY EXISTS";
            }
            else
            {

                mstrResponseData = "SUCCESS";

            }
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }

    }
    #endregion SaveCustomerDetails

    #region GetCustomerListing
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:02112015
    /// Function used to get the customer's list og loggedin user.
    /// </summary>

    private void GetCustomerListing()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<rows>");
            Int32 lintUserID = -1;
            string lstrReturnResult = "";
            DataSet lobjDS = null;

            string lstrSortParameter = "";
            string lstrSortOrder = "";
            double ldblStartIndex = 0;
            double ldblEndIndex = 0;
            double ldblRowsPerPage = 0;
            double ldblTotalRowsCount = 1;
            double ldblPageNo = 1;
            string lstrSearchString = "";
            string lstrSearchColumn = "";
            string lstrAction = "";
            string lstrRows = "";


            try
            {
                if (Request.Form["action"] != null)
                {
                    lstrAction = Request.Form["action"].ToString();
                }
                if (Request.Form["rows"] != null)
                {
                    lstrRows = Request.Form["rows"].ToString();
                }

                if (Request.Form["page"] != null)
                {
                    ldblPageNo = Convert.ToDouble(Request.Form["page"].ToString());
                }

                if (Request.Form["rp"] != null)
                {
                    ldblRowsPerPage = Convert.ToDouble(Request.Form["rp"].ToString());
                }

                if (Request.Form["sortname"] != null)
                {
                    lstrSortParameter = Request.Form["sortname"].ToString();
                }

                if (Request.Form["sortorder"] != null)
                {
                    lstrSortOrder = Request.Form["sortorder"].ToString();
                }

                if (Request.Form["query"] != null)
                {
                    lstrSearchString = Request.Form["query"].ToString();
                }

                if (Request.Form["qtype"] != null)
                {
                    lstrSearchColumn = Request.Form["qtype"].ToString();
                }

                if (Session["UserID"] != null)
                {
                    lintUserID = Convert.ToInt32(Session["UserID"]);
                    mobjCCommon.UserID = lintUserID;
                }
                mobjCCommon.SetGridVariables(CConstants.enumTables.TblCustomers.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");

                // Function to get customers listing.               
                lobjDS = mobjCCustomer.GetCustomerListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, lintUserID);

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";
                        string trColor = "";

                        if (Convert.ToString(lobjDS.Tables[0].Rows[i]["Status"]) == "Prospects")
                        {
                            trColor = "pink";
                        }
                        if (Convert.ToString(lobjDS.Tables[0].Rows[i]["Status"]) == "Clients")
                        {
                            trColor = "red";
                        }

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + "' style=\"background-color:" + trColor + ";\">");//
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../User" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"]) + "\"></td>]]></cell>");

                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"" + "../img/AnonymousGuyPic.jpg" + "\"></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\" onclick=\"return ShowCustomerProfileModal(" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            //onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\"
                            stringBuilder.Append("<cell><![CDATA[<td><a data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  >" + "-" + "</a></td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["DateOfBirth"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToDateTime(lobjDS.Tables[0].Rows[i]["DateOfBirth"]).ToString("MM/dd/yyyy") + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Address_line1"])) || !string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Address_Line2"])) || !string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Province"])) || !string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["City"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\" title=\"View Location\" onclick=\" return codeAddress('" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Address_line1"]) + " " + Convert.ToString(lobjDS.Tables[0].Rows[i]["Address_Line2"]) + " " + Convert.ToString(lobjDS.Tables[0].Rows[i]["City"]) + " " + Convert.ToString(lobjDS.Tables[0].Rows[i]["Province"]) + "');\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Address_line1"]) + " <br/> " + Convert.ToString(lobjDS.Tables[0].Rows[i]["Address_Line2"]) + " <br/> City: " + Convert.ToString(lobjDS.Tables[0].Rows[i]["City"]) + " <br/>Province: " + Convert.ToString(lobjDS.Tables[0].Rows[i]["Province"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Mobile_Phone"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Mobile_Phone"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Status"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Status"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        stringBuilder.Append("<a href='#' title=\"Edit Customer\" data-toggle=\"modal\" onclick=\"return GetMode('Edit'," + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        // stringBuilder.Append("<a href='#' title=\"Edit Customer\" data-toggle=\"modal\" onclick=\"return showEditCustomerModel(" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        stringBuilder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Customer\" data-toggle=\"tooltip\" onclick=\"return DeleteCustomer(" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        stringBuilder.Append("<a href='#modal-Add-Category' title=\"View Documents\" data-toggle=\"modal\" onclick=\"return AddDocument(" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/Document.png\"></a>");
                        stringBuilder.Append("<a href='#div_SeekPermission' title=\"Client Permission\" onclick=\"return ShowSeekPermissionBlock(" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\">" + "<image style=\"width:20px;margin:10px;\" src=\"../user/img/permissions.png\"></a>");
                        stringBuilder.Append("<a href='#div_followUpDetails' title=\"View Follow-Up Details\" onclick=\"return GetFollowUpDetails(" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + ")\">" + "<image style=\"width:20px;margin:10px;\" src=\"../user/img/FollowUpnote.png\"></a>");

                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>]]></cell>");

                        stringBuilder.Append(" </row>");
                    }

                }


                stringBuilder.Append("</rows>");

            }
            catch (Exception ex)
            {
                stringBuilder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += stringBuilder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetCustomerListing

    #region GetUserName
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:021115
    /// Function used to get logged in user name.
    /// </summary>
    private void GetUserName()
    {
        StringBuilder builder = new StringBuilder();
        try
        {
            DataSet ds = mobjCUser.GetUserDetails(mdblUserID);
            if (ds != null)
            {
                builder.Append(ds.Tables[0].Rows[0]["Full_Name"].ToString());

            }
        }
        catch (Exception)
        {

            throw;
        }
        mstrResponseData = builder.ToString();
    }

    #endregion GetUserName

    #region DeleteCustomer
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:02112015
    /// Function used to delete customer.
    /// </summary>
    private void DeleteCustomer()
    {
        Int32 lintCustomerID = -1;

        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);
            //#A Jasmeet: 021115 - delete Customer
            mobjCCustomer.DeleteCustomer(lintCustomerID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteCustomer

    #region GetCustomerDetails
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:021115
    /// Function used to get customer details.
    /// </summary>
    private void GetCustomerDetails()
    {
        Int32 lintCustomerID = -1;

        StringBuilder builder = new StringBuilder("<Response><CustomerData>");
        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);
            //#A Jasmeet: 021115 - GetCustomerDetails

            DataSet ds = mobjCCustomer.GetCustomerDetails(lintCustomerID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<Full_Name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                builder.Append("]]></Full_Name>");

                builder.Append("<DateOfBirth><![CDATA[");
                builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"]).ToString("yyyy/MM/dd"));
                builder.Append("]]></DateOfBirth>");

                if (ds.Tables[0].Rows[0]["Anniversary"].ToString() == "" || ds.Tables[0].Rows[0]["Anniversary"]==null)
                {
                    builder.Append("<Anniversary><![CDATA[");
                    builder.Append("");
                    builder.Append("]]></Anniversary>");
               
                }
                else{
                    builder.Append("<Anniversary><![CDATA[");
                    builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["Anniversary"]).ToString("yyyy/MM/dd"));
                    builder.Append("]]></Anniversary>");
                }
                builder.Append("<StatusID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["StatusID"]));
                builder.Append("]]></StatusID>");

                builder.Append("<Address_line1><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"]));
                builder.Append("]]></Address_line1>");

                builder.Append("<Address_Line2><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line2"]));
                builder.Append("]]></Address_Line2>");

                builder.Append("<CityID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["CityID"]));
                builder.Append("]]></CityID>");

                builder.Append("<ProvinceID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ProvinceID"]));
                builder.Append("]]></ProvinceID>");

                builder.Append("<PostalCode><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"]));
                builder.Append("]]></PostalCode>");

                builder.Append("<Mobile_Phone><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"]));
                builder.Append("]]></Mobile_Phone>");

                builder.Append("<Mobile><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]));
                builder.Append("]]></Mobile>");

                builder.Append("<Telephone><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Telephone"]));
                builder.Append("]]></Telephone>");

                builder.Append("<OfficeAddress1><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress1"]));
                builder.Append("]]></OfficeAddress1>");

                builder.Append("<OfficeAddress2><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress2"]));
                builder.Append("]]></OfficeAddress2>");

                builder.Append("<OfficeCityID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeCityID"]));
                builder.Append("]]></OfficeCityID>");

                builder.Append("<OfficeStateID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeStateID"]));
                builder.Append("]]></OfficeStateID>");

                builder.Append("<Work><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Work"]));
                builder.Append("]]></Work>");

                builder.Append("<ExtensionField><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ExtensionField"]));
                builder.Append("]]></ExtensionField>");

                builder.Append("<Email><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                builder.Append("]]></Email>");

                builder.Append("<OfficialEmailID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficialEmailID"]));
                builder.Append("]]></OfficialEmailID>");

                builder.Append("<HomeFax><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"]));
                builder.Append("]]></HomeFax>");

                builder.Append("<OfficeFax><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeFax"]));
                builder.Append("]]></OfficeFax>");

                builder.Append("<Picture><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Picture"]));
                builder.Append("]]></Picture>");

                builder.Append("<MaritalStatus><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["MaritalStatus"]));
                builder.Append("]]></MaritalStatus>");

                builder.Append("<Dependents><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Dependents"]));
                builder.Append("]]></Dependents>");

                builder.Append("<CallTime><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["CallTime"]));
                builder.Append("]]></CallTime>");

                builder.Append("<ReferredBy><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ReferredBy"]));
                builder.Append("]]></ReferredBy>");

                builder.Append("<ColdLead><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ColdLead"]));
                builder.Append("]]></ColdLead>");
              
                    builder.Append("<FirstContact><![CDATA[");
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["FirstContact"]));
                    builder.Append("]]></FirstContact>");
             
                builder.Append("<NextContact><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["NextContact"]));
                builder.Append("]]></NextContact>");

                builder.Append("<Discussed><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Discussed"]));
                builder.Append("]]></Discussed>");

            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</CustomerData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetCustomerDetails

    #region FillCustomerCombo
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021115
    /// Function used to fill customer combo.
    /// </summary>
    private void FillCustomerCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";
        Int32 lintCustomerID = -1;
        try
        {

            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);

            lobjDS = mobjCCustomer.FillCustomerCombo(mdblUserID, lintCustomerID);

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Full_Name>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "]]>");
                    lobjBuilder.Append("</Full_Name>");

                    lobjBuilder.Append("<CustomerID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["CustomerID"].ToString() + "]]>");
                    lobjBuilder.Append("</CustomerID>");

                    lobjBuilder.Append("</Contents>");

                }
            }

            lobjBuilder.Append("</Response>");

        }

        catch (Exception ex)
        {
            throw new Exception("Failure: " + ex.Message);
        }

        lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += lobjBuilder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion FillCustomerCombo

    #region SaveFollowUp
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021215
    /// Function used to save customer as followup.
    /// </summary>
    private void SaveFollowUp()
    {
        Int32 lintCustomerID = -1;
        string lstrFollowUpText = "";
        string lstrFollowUpDesc = "";
        string lstrFollowUpDate = "";
        string lstrStartTime = "";
        string lstrEndTime = "";
        Int32 lintStateID = -1;
        Int32 lintCityID = -1;
        string lstrVenue = "";

        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);

            if (Request.Form["FollowUpText"] != null)
                lstrFollowUpText = Convert.ToString(Request.Form["FollowUpText"]);

            if (Request.Form["Description"] != null)
                lstrFollowUpDesc = Convert.ToString(Request.Form["Description"]);

            if (Request.Form["FollowUpDateAndTime"] != null)
                lstrFollowUpDate = Convert.ToString(Request.Form["FollowUpDateAndTime"]);

            if (Request.Form["StartTime"] != null)
                lstrStartTime = Convert.ToString(Request.Form["StartTime"]);

            if (Request.Form["EndTime"] != null)
                lstrEndTime = Convert.ToString(Request.Form["EndTime"]);

            if (Request.Form["StateID"] != null)
                lintStateID = Convert.ToInt32(Request.Form["StateID"]);

            if (Request.Form["CityID"] != null)
                lintCityID = Convert.ToInt32(Request.Form["CityID"]);

            if (Request.Form["Venue"] != null)
                lstrVenue = Convert.ToString(Request.Form["Venue"]);

            string lstr = mobjCCustomer.SaveCustomerAsFollowUp(lintCustomerID, lstrFollowUpText, lstrFollowUpDesc, lstrFollowUpDate, mdblUserID, lstrStartTime, lstrEndTime, lintStateID, lintCityID, lstrVenue);

            mstrResponseData = "SUCCESS";


        }

        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion SaveFollowUp

    #region SaveUserDocuments
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021315
    /// Function used to sace user documents.
    /// </summary>
    private void SaveUserDocuments()
    {
        string lstrDescription = "";
        string lstrDocument = "";
        Int32 lintDocID = -1;
        try
        {

            if (Request.Form["Description"] != null)
                lstrDescription = Convert.ToString(Request.Form["Description"]);

            if (Request.Form["PdfDocument"] != null)
                lstrDocument = Convert.ToString(Request.Form["PdfDocument"]);

            if (Request.Form["DocID"] != null)
                lintDocID = Convert.ToInt32(Request.Form["DocID"]);

            string lstr = mobjCCustomer.SaveUserDocuments(lstrDescription, lstrDocument, mdblUserID, lintDocID);
            if (lstr.ToUpper() == "ALREADY EXISTS")
            {
                mstrResponseData = "ALREADY EXISTS";

            }
            else
            {

                mstrResponseData = "SUCCESS";

            }
        }

        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion SaveUserDocuments

    #region GetUserDocListing
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021315
    /// Functiom used to get Users document list.
    /// </summary>
    private void GetUserDocListing()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<rows>");
            Int32 lintUserID = -1;
            string lstrReturnResult = "";
            DataSet lobjDS = null;

            string lstrSortParameter = "";
            string lstrSortOrder = "";
            double ldblStartIndex = 0;
            double ldblEndIndex = 0;
            double ldblRowsPerPage = 0;
            double ldblTotalRowsCount = 1;
            double ldblPageNo = 1;
            string lstrSearchString = "";
            string lstrSearchColumn = "";
            string lstrAction = "";
            string lstrRows = "";


            try
            {
                if (Request.Form["action"] != null)
                {
                    lstrAction = Request.Form["action"].ToString();
                }
                if (Request.Form["rows"] != null)
                {
                    lstrRows = Request.Form["rows"].ToString();
                }

                if (Request.Form["page"] != null)
                {
                    ldblPageNo = Convert.ToDouble(Request.Form["page"].ToString());
                }

                if (Request.Form["rp"] != null)
                {
                    ldblRowsPerPage = Convert.ToDouble(Request.Form["rp"].ToString());
                }

                if (Request.Form["sortname"] != null)
                {
                    lstrSortParameter = Request.Form["sortname"].ToString();
                }

                if (Request.Form["sortorder"] != null)
                {
                    lstrSortOrder = Request.Form["sortorder"].ToString();
                }

                if (Request.Form["query"] != null)
                {
                    lstrSearchString = Request.Form["query"].ToString();
                }

                if (Request.Form["qtype"] != null)
                {
                    lstrSearchColumn = Request.Form["qtype"].ToString();
                }

                if (Session["UserID"] != null)
                {
                    lintUserID = Convert.ToInt32(Session["UserID"]);
                    mobjCCommon.UserID = lintUserID;
                }
                mobjCCommon.SetGridVariables(CConstants.enumTables.TblDocs.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");

                // Function to get customers listing.               
                lobjDS = mobjCCustomer.GetUserDocListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, lintUserID);

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["DocID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");

                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["UploadDocFile"])))
                        {
                            // stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["UploadDocFile"]) + "</td>]]></cell>");
                            string path = Convert.ToString(lobjDS.Tables[0].Rows[i]["UploadDocFile"]);
                            string fileName = path.Split(new char[] { '\\', '/' }).Last();
                            stringBuilder.Append("<cell><![CDATA[<td><a href=\"" + mstrDomainName + Convert.ToString(lobjDS.Tables[0].Rows[i]["UploadDocFile"]) + "\" target='_blank'>" + fileName + "</a></td>]]></cell>");

                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        stringBuilder.Append("<a href='#modal-Add-Document' title=\"Edit Document\" data-toggle=\"modal\" onclick=\"return showEditDocumentModel(" + lobjDS.Tables[0].Rows[i]["DocID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        stringBuilder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Customer\" data-toggle=\"tooltip\" onclick=\"return DeleteDocument(" + lobjDS.Tables[0].Rows[i]["DocID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>]]></cell>");

                        stringBuilder.Append(" </row>");
                    }

                }


                stringBuilder.Append("</rows>");

            }
            catch (Exception ex)
            {
                stringBuilder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += stringBuilder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetUserDocListing

    #region DeleteDocument
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021315
    /// Function used to delete document.
    /// </summary>
    private void DeleteDocument()
    {
        Int32 lintDocID = -1;

        try
        {
            if (Request.Form["DocID"] != null)
                lintDocID = Convert.ToInt32(Request.Form["DocID"]);
            //#A Jasmeet: 021115 - delete Customer
            mobjCCustomer.DeleteDocument(lintDocID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteDocument

    #region GetDocumentDetails
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021315
    /// Function used to get Document details.
    /// </summary>
    private void GetDocumentDetails()
    {
        Int32 lintDocID = -1;

        StringBuilder builder = new StringBuilder("<Response><DocData>");
        try
        {
            if (Request.Form["DocID"] != null)
                lintDocID = Convert.ToInt32(Request.Form["DocID"]);
            //#A Jasmeet: 021115 - GetCustomerDetails

            DataSet ds = mobjCCustomer.GetDocumentDetails(lintDocID);
            if (ds != null)
            {
                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

                builder.Append("<UploadDocFile><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["UploadDocFile"]));
                builder.Append("]]></UploadDocFile>");



            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</DocData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetDocumentDetails

    #region AddNewProducts
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021815
    /// Function used to add new product.
    /// </summary>
    private void AddNewProducts()
    {
        string lstrTitle = "";
        string lstrDescription = "";
        string lstrStartDate = "";
        string lstrLastDate = "";
        Int32 lintProductID = -1;
        try
        {

            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["Description"] != null)
                lstrDescription = Convert.ToString(Request.Form["Description"]);

            if (Request.Form["StartDate"] != null)
                lstrStartDate = Convert.ToString(Request.Form["StartDate"]);

            if (Request.Form["LastDate"] != null)
                lstrLastDate = Convert.ToString(Request.Form["LastDate"]);

            if (Request.Form["ProductID"] != null)
                lintProductID = Convert.ToInt32(Request.Form["ProductID"]);

            string lstr = mobjCCustomer.AddNewProducts(lstrTitle, lstrDescription, lstrStartDate, lstrLastDate, lintProductID, mdblUserID);

            if (lstr.ToUpper() == "ALREADY EXISTS")
            {
                mstrResponseData = "ALREADY EXISTS";
            }
            else
            {

                mstrResponseData = "SUCCESS";

            }
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }

    }

    #endregion AddNewProducts

    #region GetProductListing
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021815
    /// Function used to get product listing.
    /// </summary>

    private void GetProductListing()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<rows>");
            Int32 lintUserID = -1;
            string lstrReturnResult = "";
            DataSet lobjDS = null;

            string lstrSortParameter = "";
            string lstrSortOrder = "";
            double ldblStartIndex = 0;
            double ldblEndIndex = 0;
            double ldblRowsPerPage = 0;
            double ldblTotalRowsCount = 1;
            double ldblPageNo = 1;
            string lstrSearchString = "";
            string lstrSearchColumn = "";
            string lstrAction = "";
            string lstrRows = "";


            try
            {
                if (Request.Form["action"] != null)
                {
                    lstrAction = Request.Form["action"].ToString();
                }
                if (Request.Form["rows"] != null)
                {
                    lstrRows = Request.Form["rows"].ToString();
                }

                if (Request.Form["page"] != null)
                {
                    ldblPageNo = Convert.ToDouble(Request.Form["page"].ToString());
                }

                if (Request.Form["rp"] != null)
                {
                    ldblRowsPerPage = Convert.ToDouble(Request.Form["rp"].ToString());
                }

                if (Request.Form["sortname"] != null)
                {
                    lstrSortParameter = Request.Form["sortname"].ToString();
                }

                if (Request.Form["sortorder"] != null)
                {
                    lstrSortOrder = Request.Form["sortorder"].ToString();
                }

                if (Request.Form["query"] != null)
                {
                    lstrSearchString = Request.Form["query"].ToString();
                }

                if (Request.Form["qtype"] != null)
                {
                    lstrSearchColumn = Request.Form["qtype"].ToString();
                }

                if (Session["UserID"] != null)
                {
                    lintUserID = Convert.ToInt32(Session["UserID"]);
                    mobjCCommon.UserID = lintUserID;
                }
                mobjCCommon.SetGridVariables(CConstants.enumTables.TblProducts.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");

                // Function to get products listing.               
                lobjDS = mobjCCustomer.GetProductListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, lintUserID);

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["ProductID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");

                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Title"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Title"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["StartDate"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToDateTime(lobjDS.Tables[0].Rows[0]["StartDate"]).ToString("MM/dd/yyyy") + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["LastDate"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToDateTime(lobjDS.Tables[0].Rows[0]["LastDate"]).ToString("MM/dd/yyyy") + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        stringBuilder.Append("<a href='#modal-Add-Products' title=\"Edit Product\" data-toggle=\"modal\" onclick=\"return showEditProductModel(" + lobjDS.Tables[0].Rows[i]["ProductID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        stringBuilder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Product\" data-toggle=\"tooltip\" onclick=\"return DeleteProduct(" + lobjDS.Tables[0].Rows[i]["ProductID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</td>]]></cell>");

                        stringBuilder.Append(" </row>");
                    }

                }


                stringBuilder.Append("</rows>");

            }
            catch (Exception ex)
            {
                stringBuilder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += stringBuilder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetProductListing

    #region DeleteProduct

    private void DeleteProduct()
    {
        Int32 lintProductID = -1;

        try
        {
            if (Request.Form["ProductID"] != null)
                lintProductID = Convert.ToInt32(Request.Form["ProductID"]);
            //#A Jasmeet: 021815 - delete Product
            mobjCCustomer.DeleteProduct(lintProductID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteProduct

    #region GetProductDetails
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021815
    /// Function used to get product details.
    /// </summary>
    private void GetProductDetails()
    {
        Int32 lintProductID = -1;

        StringBuilder builder = new StringBuilder("<Response><ProductData>");
        try
        {
            if (Request.Form["ProductID"] != null)
                lintProductID = Convert.ToInt32(Request.Form["ProductID"]);
            //#A Jasmeet: 021115 - GetCustomerDetails

            DataSet ds = mobjCCustomer.GetProductDetails(lintProductID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

                builder.Append("<StartDate><![CDATA[");
                builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]).ToString("MM/dd/yyyy"));
                builder.Append("]]></StartDate>");

                builder.Append("<LastDate><![CDATA[");
                builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["LastDate"]).ToString("MM/dd/yyyy"));
                builder.Append("]]></LastDate>");


            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</ProductData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetProductDetails

    #region SaveCustomerDocuments
    /// <summary>
    /// Author:JAsmeet Kaur
    /// Date:021815
    /// Function used to add customer documents.
    /// </summary>
    private void SaveCustomerDocuments()
    {
        string lstrTitle = "";
        string lstrDocument = "";
        Int32 lintCustomerID = -1;
        try
        {
            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["File"] != null)
                lstrDocument = Convert.ToString(Request.Form["File"]);

            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);

            string lstr = mobjCCustomer.SaveCustomerDocuments(lstrTitle, lstrDocument, mdblUserID, lintCustomerID);

            mstrResponseData = "SUCCESS";

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion SaveCustomerDocuments

    #region GetCustomerName
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021915
    /// Function used to get customer Name.
    /// </summary>
    private void GetCustomerName()
    {
        Int32 lintCustomerID = -1;
        StringBuilder builder = new StringBuilder();
        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);
            DataSet ds = mobjCCustomer.GetCustomerName(lintCustomerID);
            if (ds != null)
            {
                builder.Append(ds.Tables[0].Rows[0]["Full_Name"].ToString());

            }
        }
        catch (Exception)
        {

            throw;
        }
        mstrResponseData = builder.ToString();
    }


    #endregion GetCustomerName

    #region GetCustomerFiles
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:021915
    /// Function used to get customer's files.
    /// </summary>
    private void GetCustomerFiles()
    {
        Int32 lintCustomerID = -1;
        StringBuilder lobjBuilder = new StringBuilder("<Response>");

        string lstrReturnResult = "";
        lobjBuilder.Append("<GetFiles>");
        try
        {

            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);

            DataSet ds = mobjCCustomer.GetCustomerFiles(lintCustomerID);

            if (ds != null)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    lobjBuilder.Append("<Contents>");
                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append(Convert.ToString(ds.Tables[0].Rows[i]["Title"]));
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<CustomerDocs>");
                    lobjBuilder.Append(mstrDomainName + Convert.ToString(ds.Tables[0].Rows[i]["CustomerDocs"]));
                    lobjBuilder.Append("</CustomerDocs>");
                    lobjBuilder.Append("</Contents>");
                }
            }
            lobjBuilder.Append("</GetFiles>");
            lobjBuilder.Append("</Response>");

        }
        catch (Exception ex)
        {
            throw new Exception("Failure: " + ex.Message);
        }

        lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += lobjBuilder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetCustomerFiles

    #region FillExpertsCombo

    private void FillExpertsCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCCustomer.FillExpertsCombo(mdblUserID);

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Full_Name>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "]]>");
                    lobjBuilder.Append("</Full_Name>");

                    lobjBuilder.Append("<UserID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + "]]>");
                    lobjBuilder.Append("</UserID>");

                    lobjBuilder.Append("</Contents>");

                }
            }

            lobjBuilder.Append("</Response>");

        }

        catch (Exception ex)
        {
            throw new Exception("Failure: " + ex.Message);
        }

        lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += lobjBuilder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion FillExpertsCombo

    #region SendMailToClient
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:031815
    /// Function used to send mail to client.
    /// </summary>
    private void SendMailToClient()
    {
        Int32 lintCustomerID = -1;
        string lstrCustomerEmail = "";
        string lstrCustomerPassword = "";
        Int32 lintExpertID = -1;
        string lstrCustName = "";

        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);

            if (Request.Form["ExpertID"] != null)
                lintExpertID = Convert.ToInt32(Request.Form["ExpertID"]);

            DataSet ds = mobjCCustomer.SendMailToClient(lintCustomerID, mdblUserID, lintExpertID);
            if (ds != null)
            {
                lstrCustomerEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                lstrCustomerPassword = ds.Tables[0].Rows[0]["Password"].ToString();
                lstrCustName = ds.Tables[0].Rows[0]["Full_Name"].ToString();
                SendMailForAuthorization(lintCustomerID, lstrCustomerEmail.Trim(), lstrCustomerPassword, lstrCustName, lintExpertID);

            }
        }
        catch (Exception)
        {

            // throw;
        }

    }


    #endregion SendMailToClient

    #region SendMailForAuthorization
    private void SendMailForAuthorization(Int32 lintCustomerID, string CustomerEmail, string Password, string CustomerName, Int32 lintExpertID)
    {
        StringBuilder lobjbuilder = new StringBuilder();

        try
        {
            CMail lobjMail = new CMail();
            Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
            string lstrAuthorizationURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "ClientPermission.aspx?tok=" + lintCustomerID.ToString() + "&mode=" + lobjEnc.Encrypt("Authorize", true) + "&UserID=" + mdblUserID + "&ExpertID=" + lintExpertID;

            string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("../../ClientPermissions.txt"), Encoding.UTF8);
            //lstrMessage = lstrMessage.Replace("<Verifylink>", HttpUtility.UrlEncode(lstrURL));
            lstrMessage = lstrMessage.Replace("<AuthorizationlinkOriginal>", lstrAuthorizationURL);
            lstrMessage = lstrMessage.Replace("<Full_Name>", CustomerName);
            lobjMail.EmailFrom = WebConfigurationManager.AppSettings["EmailFrom"].ToString();
            lobjMail.EmailTo = CustomerEmail;
            //lobjMail.Password = Password;
            lobjMail.Subject = "E2A: Client Permission Required";
            lobjMail.MessageBody = lstrMessage;
            lobjMail.SendEMail();

        }
        catch (Exception)
        {
            //  throw;
        }
    }


    #endregion SendMailForAuthorization

    #region GetFollowUpDetails
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:052215
    /// Finction used to get followup details.
    /// </summary>
    private void GetFollowUpDetails()
    {
        Int32 lintCustomerID = -1;
        string MeetingTime = string.Empty;
        StringBuilder builder = new StringBuilder();
        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);
            DataSet ds = mobjCCustomer.GetFollowUpDetails(lintCustomerID);

            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["FollowUpDateAndTime"] != null)
                    {
                        DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["FollowUpDateAndTime"]);
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["FollowUpDateAndTime"]);
                        MeetingTime = "";
                        if (ts.Days > 0)
                        {
                            if (ts.Days > 7)
                            {
                                Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                Int32 leftdays = (ts.Days - (week * 7));

                                MeetingTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                            }
                            else
                                MeetingTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                        }
                        else if (ts.Hours > 0)
                        {
                            MeetingTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                        }
                        else if (ts.Minutes > 0)
                        {
                            MeetingTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                        }
                        else MeetingTime = "few seconds ago";

                    }


                    builder.Append("<div class=\"timeline block-content-full\" style=\"margin-left:1%;\">");
                    builder.Append("<ul class=\"timeline-list timeline-hover\">");
                    builder.Append("<li class=\"active\">");
                    builder.Append("<div class=\"timeline-icon\"><i class=\"fa fa-file-text\"></i></div>");
                    builder.Append("<div class=\"timeline-time\">" + MeetingTime + "</div>");
                    builder.Append("<div class=\"timeline-content\">");
                    builder.Append("<p class=\"push-bit\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong></p>" + Convert.ToString(ds.Tables[0].Rows[i]["FollowUpText"]) + "</div>");
                    builder.Append("<div class=\"timeline-content\"><p class=\"push-bit\"><strong>Timing :  " + Convert.ToString(ds.Tables[0].Rows[i]["StartDateTime"]) + "   " + " to  " + Convert.ToString(ds.Tables[0].Rows[i]["EndDateTime"]) + "</strong></p></div>");

                    builder.Append("<div class=\"timeline-content\"><p ><a href='#' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\" title=\"View Location\" onclick=\" return codeAddress('" + Convert.ToString(ds.Tables[0].Rows[i]["Venue"]) + " " + Convert.ToString(ds.Tables[0].Rows[i]["City"]) + " " + Convert.ToString(ds.Tables[0].Rows[i]["State"]) + "');\"><strong>Venue :" + "  " + Convert.ToString(ds.Tables[0].Rows[i]["Venue"]) + " <br/>  " + "City: " + Convert.ToString(ds.Tables[0].Rows[i]["City"]) + " <br/> " + " Province: " + Convert.ToString(ds.Tables[0].Rows[i]["State"]) + "</strong></a></p></div>");
                    builder.Append("</li>");
                    builder.Append("</ul></div>");


                }
            }
            else
            {
                builder.Append("<div class=\"timeline block-content-full\" style=\"margin-left:1%;\">");
                builder.Append("<div class=\"timeline-content\" style=\"text-align:center;\"><p class=\"push-bit\"><strong>Follow-Up Details not Found</strong></p></div>");
                builder.Append("</div>");
            }
        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetFollowUpDetails

    #region ViewCustomerProfile
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:052415
    /// Function used to view customer profile details.
    /// </summary>
    private void ViewCustomerProfile()
    {
        Int32 lintCustomerID = -1;
        DataSet ds = new DataSet();
        StringBuilder builder = new StringBuilder("<Response><CustomerData>");
        try
        {
            if (Request.Form["CustomerID"] != null)
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);


            ds = mobjCCustomer.ViewCustomerProfile(lintCustomerID);

            if (ds != null)
            {

                builder.Append("<Full_Name><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Full_Name>");


                builder.Append("<Picture><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Picture"])))
                {
                    builder.Append("<image style=\"width:100px;margin-left:20%;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[0]["Picture"]) + "\">");
                }
                else
                {
                    builder.Append("<image style=\"width:100px;margin-left:20%;\" src=\"../img/AnonymousGuyPic.jpg\">");
                }
                builder.Append("]]></Picture>");

                builder.Append("<DateOfBirth><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfBirth"])))
                {
                    builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"]).ToString("MM/dd/yyyy"));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></DateOfBirth>");

                builder.Append("<Status><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Status"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Status"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Status>");

                builder.Append("<Address_line1><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Address_line1>");

                builder.Append("<Address_Line2><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line2"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line2"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Address_Line2>");

                builder.Append("<City><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["City"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["City"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></City>");


                builder.Append("<State><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["State"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["State"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></State>");

                builder.Append("<OfficeAddress1><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress1"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress1"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></OfficeAddress1>");

                builder.Append("<OfficeAddress2><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress2"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeAddress2"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></OfficeAddress2>");

                builder.Append("<OfficeCity><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeCity"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeCity"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></OfficeCity>");

                builder.Append("<OfficeState><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OfficeState"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OfficeState"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></OfficeState>");

                builder.Append("<PostalCode><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></PostalCode>");

                builder.Append("<Mobile_Phone><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Mobile_Phone>");

                builder.Append("<Work><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Work"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Work"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Work>");

                builder.Append("<Email><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Email"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Email>");


                builder.Append("<HomeFax><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></HomeFax>");

            }
        }

        catch (Exception)
        {

            throw;
        }

        builder.Append("</CustomerData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion ViewCustomerProfile

    #endregion Function
}