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

public partial class User_User_ : System.Web.UI.Page
{
    #region Module Level Objects
    DataAccess mobjDataAccess = new DataAccess();
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    CCommon mobjCCommon = new CCommon(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string mstrDomainNanme = WebConfigurationManager.AppSettings["DomainName"].ToString();
    string mstrResponseData = "";
    #endregion

    #region Module Level Variables
    double mdblUserID = -1;
    string mstrEmailID = "";
    double mdblCityID = -1;
    public string mstrIsAdmin { get; set; }
    public string mstrCity { get; set; }
    public string Mode { get; set; }
    // double mdblZoneID = -1;
    public double mdblUserTypeID { get; set; }
    public double mdblOccupationID { get; set; }

    public bool IsAdmin { get; set; }
    public int UserTypeID = -1;
    #endregion

    #region Page Load
    /// Function used to fire page load event.
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string lstrMod = "";
            if (Request.RequestType.ToUpper() == "POST")
            {
                // Getting mode from posted form
                if (Request.Form["Mode"] != null)
                {
                    lstrMod = Request.Form["Mode"].ToString();
                }
                else
                {
                    lstrMod = Request.Form["Mode"].ToString();
                }
            }
            lstrMod = Request.Form["Mode"].ToString();
            // Getting mode from posted form
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

            //Calling function to Generate data.
            GenerateData(lstrMod);

        }//End try
        catch 
        {
            
        }//End catch

        //Passing the response data to the calling ajax page.
        Response.Write(mstrResponseData);
        Response.Flush();
        Response.End();

    }
    #endregion Page Load

    #region GenerateData
    /// Generating data based on the mode passed
    private void GenerateData(string pstrMod)
    {
        switch (pstrMod.ToUpper())
        {

            case "GETUSERDET":
                {
                    try
                    {
                        //#A:Sahil:072514 - Calling function to get user details
                        GetUserDet();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETUSERDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:081414 - Calling function to get logged in user details.
                        GetUserDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "FILLSTATEOFSELECTEDCITY":
                {
                    try
                    {
                        //#A:Jasmeet kaur:020915 - Calling function to fill status combo.
                        FillStateOfSelectedCity();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "FILLOCCUPATIONCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:081414 - Calling function to fill occupation combo.
                        FillOccupationCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLSTATECOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:092614 - Calling function to fill state combo.
                        FillStateCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "FILLCITIESOFSELECTEDSTATE":
                {
                    try
                    {
                        //#A:Jasmeet:092614 - Calling function to fill city combo.
                        FillCitiesOfselectedState();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "FILLCITYCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:092214 - Calling function tofill city combo.
                        FillCityCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETUSERDETAILSFOREDITING":
                {
                    try
                    {
                        //#A:Jasmeet:081414 - Calling function to get logged in user details.
                        GetUserDetailsForEditing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "UPDATEUSERDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:081414 - Calling function to update user details.
                        UpdateUserDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "UPDATEUSERPROPIC":
                {
                    try
                    {
                        //#A:Jasmeet:081414 - Calling function to update user details.
                        UpdateUserProPic();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            /// devsortc



            //default:
            //    mstrResponseData = "Invalid mode";
            //    break;


        }
    }


    #endregion GenerateData

    #region Functions
    #region GetUserDet
    /// <summary>
    /// Function used to get users details
    /// Author -  Sahil Sharma
    /// Date- 072514
    /// </summary>
    public void GetUserDet()
    {
        DataSet ds = null;
        StringBuilder builder = new StringBuilder("<Response><AdminData>");
        try
        {
            ds = mobjCUser.GetLoggedinUserDetails(mdblUserID);

            if (ds != null)
            {
                builder.Append("<Full_Name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                builder.Append("]]></Full_Name>");

                builder.Append("<Picture><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Picture"]));
                builder.Append("]]></Picture>");


                builder.Append("<EMail><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["EMail"]));
                builder.Append("]]></EMail>");

                builder.Append("<Occupation><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Occupation"]));
                builder.Append("]]></Occupation>");
                
                if (Session["UserTypeId"] != null)
                {
                    builder.Append("<UserTypeId><![CDATA[");
                    builder.Append(Convert.ToString(Session["UserTypeId"]));
                    builder.Append("]]></UserTypeId>");
                }

                builder.Append("<designation><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["designation"]));
                builder.Append("]]></designation>");

            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        builder.Append("</AdminData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }
    #endregion
    #region GetUserDetails
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:08142014
    /// function used to get details of logged in user.
    /// </summary>
    private void GetUserDetails()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            DataSet lobjds = mobjCUser.GetLoggedinUserDetails(mdblUserID);
            builder.Append("<div class=\"table-responsive\">");
            builder.Append("<div class=\"block-title\">");
            builder.Append("<div class=\"block-options pull-right\">");
            builder.Append("<a href='#divProfileForm' class=\"btn btn-sm btn-alt btn-default\" data-toggle=\"tooltip\" title=\"Edit Profile\" onClick=\"return showEditProfileDiv();\"><i class=\"fa fa-pencil\"></i></a>");
            builder.Append("</div>");
            builder.Append("<h3><strong><span class=\"fa fa-info-circle\"></span> About</strong>" + "  " + Convert.ToString(lobjds.Tables[0].Rows[0]["Full_Name"]) + "</h3></div>");
            builder.Append("<div class=\"block-content-full\">");
            builder.Append("<table class=\"table table-borderless table-striped\" id=\"tbl_profile\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");
            builder.Append("<td style=\"width: 20%;\">");
            builder.Append("<strong> Name </strong>");
            builder.Append("</td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Full_Name"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["Full_Name"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>Organization</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Organization"])))
            {
                builder.Append("<td><a href=\"javascript:void(0)\">" + Convert.ToString(lobjds.Tables[0].Rows[0]["Organization"]) + "</a></td>");
            }
            else
            {
                builder.Append("<td><a href=\"javascript:void(0)\">-</a></td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>Email</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["EMail"])))
            {
                builder.Append("<td><a href=\"javascript:void(0)\">" + Convert.ToString(lobjds.Tables[0].Rows[0]["EMail"]) + "</a></td>");
            }
            else
            {
                builder.Append("<td><a href=\"javascript:void(0)\">-</a></td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>Address</strong></td>");

            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line1"])))
            {
                builder.Append("<td>");
                builder.Append(Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line1"]));
                if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line2"])))
                    builder.Append(", " + Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line2"]));
                if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line3"])))
                    builder.Append(", " + Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line3"]));
                builder.Append("</td>");
            }
            else
            {
                builder.Append("<td>-</td>");

            }

            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>City</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Title"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["Title"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>Phone Number</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Mobile_Phone"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["Mobile_Phone"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            if (Convert.ToString(lobjds.Tables[0].Rows[0]["OccupationID"]) == "7")
            {
                builder.Append("<td><strong>Occupation</strong></td>");
                if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["OtherOccupation"])))
                {
                    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["OtherOccupation"]) + "</td>");
                }
                else
                {
                    builder.Append("<td>-</td>");
                }
            }
            else
            {
                builder.Append("<td><strong>Occupation</strong></td>");
                if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Occupation"])))
                {
                    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["Occupation"]) + "</td>");
                }
                else
                {
                    builder.Append("<td>-</td>");
                }
            }
            builder.Append("</tr>");

            builder.Append("<tr>");
            builder.Append("<td><strong>Designation</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["designation"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["designation"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");

            builder.Append("<tr>");
            builder.Append("<td><strong>Dealer Name</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["DealerName"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["DealerName"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>MGA</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Mga"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["Mga"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>Governing Body</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Governingbody"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["Governingbody"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>In Business Since</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["InBusinessSince"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["InBusinessSince"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");

            builder.Append("<tr>");
            builder.Append("<td><strong>About Me</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["AboutMe"])))
            {
                builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[0]["AboutMe"]) + "</td>");
            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td><strong>Profile Video</strong></td>");
            if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["ProfileYoutubeURL"])))
            {

                string VideoID = Convert.ToString(lobjds.Tables[0].Rows[0]["ProfileYoutubeURL"]);
                string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                if (!string.IsNullOrEmpty(lastItemOfSplit))
                {
                    builder.Append("<td><div id=\"divYoutubeVideo\">");
                    builder.Append("<iframe title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                    builder.Append("</div></td>");
                }

            }
            else
            {
                builder.Append("<td>-</td>");
            }
            builder.Append("</tr>");


            builder.Append("</tbody>");
            builder.Append("</table>");

            builder.Append("</div>");
            builder.Append("</div>");

        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetUserDetails

    #region FillStateOfSelectedCity
    private void FillStateOfSelectedCity()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";
        Int32 lintCityID = -1;
        try
        {
            if (Request.Form["CityID"] != null)
                lintCityID = Convert.ToInt32(Request.Form["CityID"]);

            lobjDS = mobjCUser.FillStateOfSelectedCity(lintCityID);

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<StateID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["StateID"].ToString() + "]]>");
                    lobjBuilder.Append("</StateID>");

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

    #endregion FillStateOfSelectedCity


    #region FillOccupationCombo
    private void FillOccupationCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.GetOccupations();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<OccupationID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["OccupationID"].ToString() + "]]>");
                    lobjBuilder.Append("</OccupationID>");

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

    #endregion FillOccupationCombo


    #region FillStateCombo
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:092614
    /// Function used to fill state combo
    /// </summary>

    private void FillStateCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.FillStateCombo();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<StateID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["StateID"].ToString() + "]]>");
                    lobjBuilder.Append("</StateID>");

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

    #endregion FillStateCombo


    #region FillCitiesOfselectedCombo
    /// <summary>
    /// Author:jasmeet Kaur
    /// Date:092614
    /// Function used to fill the city combo corresponding to its state value.
    /// </summary>
    private void FillCitiesOfselectedState()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";
        Int32 lintStateID = -1;
        try
        {
            if (Request.Form["StateID"] != null)
                lintStateID = Convert.ToInt32(Request.Form["StateID"]);

            lobjDS = mobjCUser.FillCitiesOfselectedState(lintStateID);

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<CityID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["CityID"].ToString() + "]]>");
                    lobjBuilder.Append("</CityID>");

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

    #endregion FillCitiesOfselectedCombo

    #region FillCityCombo
    private void FillCityCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.FillCityCombo();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<CityID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["CityID"].ToString() + "]]>");
                    lobjBuilder.Append("</CityID>");

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


    #endregion FillCityCombo

    #region GetUserDetailsForEditing
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:081414
    /// Function used to get user details for editing
    /// </summary>
    private void GetUserDetailsForEditing()
    {

        DataSet ds = new DataSet();
        StringBuilder builder = new StringBuilder("<Response><UserData>");
        try
        {

            ds = mobjCUser.GetLoggedinUserDetails(mdblUserID); ;

            if (ds != null)
            {


                builder.Append("<Full_Name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                builder.Append("]]></Full_Name>");

                builder.Append("<OccupationID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OccupationID"]));
                builder.Append("]]></OccupationID>");

                if (Convert.ToString(ds.Tables[0].Rows[0]["OccupationID"]) == "7")
                {
                    builder.Append("<OtherOccupation><![CDATA[");
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OtherOccupation"]));
                    builder.Append("]]></OtherOccupation>");
                }


                builder.Append("<Organization><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Organization"]));
                builder.Append("]]></Organization>");

                builder.Append("<ProfileYoutubeURL><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ProfileYoutubeURL"]));
                builder.Append("]]></ProfileYoutubeURL>");

                builder.Append("<Address_line1><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"]));
                builder.Append("]]></Address_line1>");

                builder.Append("<Address_Line2><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line2"]));
                builder.Append("]]></Address_Line2>");

                builder.Append("<Address_Line3><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line3"]));
                builder.Append("]]></Address_Line3>");

                //builder.Append("<City><![CDATA[");
                //builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["City"]));
                //builder.Append("]]></City>");

                builder.Append("<StateID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["StateID"]));
                builder.Append("]]></StateID>");

                builder.Append("<CityID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["CityID"]));
                builder.Append("]]></CityID>");

                builder.Append("<DealerName><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["DealerName"]));
                builder.Append("]]></DealerName>");

                builder.Append("<Mga><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Mga"]));
                builder.Append("]]></Mga>");

                builder.Append("<GoverningBody><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["GoverningBody"]));
                builder.Append("]]></GoverningBody>");

                builder.Append("<InBusinessSince><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["InBusinessSince"]));
                builder.Append("]]></InBusinessSince>");

                builder.Append("<Mobile_Phone><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"]));
                builder.Append("]]></Mobile_Phone>");

                builder.Append("<Picture><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Picture"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Picture"]));
                }
                else
                {
                    builder.Append("../img/AnonymousGuyPic.jpg");
                    //               builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");

                }
                builder.Append("]]></Picture>");

                builder.Append("<CommunicateConsent><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["CommunicateConsent"]));
                builder.Append("]]></CommunicateConsent>");


                builder.Append("<AboutMe><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["AboutMe"]));
                builder.Append("]]></AboutMe>");


                builder.Append("<designation><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["designation"]));
                builder.Append("]]></designation>");

            }

        }
        catch (Exception)
        {

            throw;
        }

        builder.Append("</UserData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetUserDetailsForEditing
    #region UpdateUserDetails
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:081414
    /// Function used to update user details
    /// </summary>
    private void UpdateUserDetails()
    {
        string lstrName = "";
        Int32 lintOccupationID = -1;
        string lstrOtherOccupation = "";
        string lstrOrganization = "";
        string lstrAddress1 = "";
        string lstrAddress2 = "";
        string lstrAddress3 = "";
        string lstrDealerName = "";
        string lstrMgs = "";
        string lstrGoverningBody = "";
        string lstrInBusinessSince = "";
        string lstrPhone = "";
        string lstrImages = "";
        Int32 lintConsent = -1;
        Int32 lintStateID = -1;
        Int32 lintCityID = -1;
        string lstrVideoURL = "";
        string lstrAboutMe = "";
        string Designation = "";
        try
        {

            if (Request.Form["Full_Name"] != null)
                lstrName = Convert.ToString(Request.Form["Full_Name"]);

            if (Request.Form["OccupationID"] != null)
                lintOccupationID = Convert.ToInt32(Request.Form["OccupationID"]);

            if (Request.Form["Designation"] != null)
                Designation = Convert.ToString(Request.Form["Designation"]);

            if (Request.Form["OtherOccupation"] != null)
                lstrOtherOccupation = Convert.ToString(Request.Form["OtherOccupation"]);

            if (Request.Form["Organization"] != null)
                lstrOrganization = Convert.ToString(Request.Form["Organization"]);

            if (Request.Form["Address_line1"] != null)
                lstrAddress1 = Convert.ToString(Request.Form["Address_line1"]);

            if (Request.Form["Address_Line2"] != null)
                lstrAddress2 = Convert.ToString(Request.Form["Address_Line2"]);

            if (Request.Form["Address_Line3"] != null)
                lstrAddress3 = Convert.ToString(Request.Form["Address_Line3"]);

            if (Request.Form["DealerName"] != null)
                lstrDealerName = Convert.ToString(Request.Form["DealerName"]);

            if (Request.Form["Mga"] != null)
                lstrMgs = Convert.ToString(Request.Form["Mga"]);

            if (Request.Form["GoverningBody"] != null)
                lstrGoverningBody = Convert.ToString(Request.Form["GoverningBody"]);

            if (Request.Form["InBusinessSince"] != null)
                lstrInBusinessSince = Convert.ToString(Request.Form["InBusinessSince"]);

            if (Request.Form["Mobile_Phone"] != null)
                lstrPhone = Convert.ToString(Request.Form["Mobile_Phone"]);

            if (Request.Form["Images"] != null)
                lstrImages = Convert.ToString(Request.Form["Images"]);

            if (Request.Form["CommunicateConsent"] != null)
                lintConsent = Convert.ToInt32(Request.Form["CommunicateConsent"]);

            if (!String.IsNullOrEmpty(Request.Form["StateID"].ToString()))
                lintStateID = Convert.ToInt32(Request.Form["StateID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["CityID"].ToString()))
                lintCityID = Convert.ToInt32(Request.Form["CityID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["ProfileYoutubeURL"].ToString()))
                lstrVideoURL = Convert.ToString(Request.Form["ProfileYoutubeURL"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["AboutMe"].ToString()))
                lstrAboutMe = Convert.ToString(Request.Form["AboutMe"]);


            mobjCUser.UpdateUserDetails(lstrName, lintOccupationID, lstrOtherOccupation, lstrOrganization, lstrAddress1, lstrAddress2, lstrAddress3, lstrDealerName, lstrMgs, lstrGoverningBody, lstrInBusinessSince, lstrPhone, lstrImages, lintConsent, mdblUserID, lintStateID, lintCityID, lstrVideoURL, lstrAboutMe, Designation);
      
                Session["OccupationID"] = mobjCUser.OccupationID;
            mdblOccupationID = mobjCUser.OccupationID;
            if (Session["UserTypeID"] != null)
                Session["UserTypeID"] = mobjCUser.UserTypeID;
            mstrResponseData = "SUCCESS";
            
            // set Session_val null to refresh the User Sesstion from UserContros/SideBarMenuControl.ascx
            Session["session_val"] = null;
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion UpdateUserDetails
    /// devsortf
    #region UpdateUserProPic
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:081414
    /// Function used to update user details
    /// </summary>
    private void UpdateUserProPic()
    {
 
        string lstrImages = "";
       
        try
        {
            if (Request.Form["Images"] != null)
                lstrImages = Convert.ToString(Request.Form["Images"]);
            mobjCUser.UpdateUserProPic(lstrImages, mdblUserID);
            mstrResponseData = "SUCCESS";

            // set Session_val null to refresh the User Sesstion from UserContros/SideBarMenuControl.ascx
            Session["session_val"] = null;
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion UpdateUserProPic
    #endregion
}