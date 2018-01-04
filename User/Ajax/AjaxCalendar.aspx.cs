using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Text;
using System.Data;
using E2aForums;
using LitJson;

public partial class User_Ajax_AjaxCalendar : System.Web.UI.Page
{
    #region Module Level Variables

    string mstrResponseData = "";
    double mdblUserId = -1;
    bool IsAdmin;

    public string ApplicationName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    #endregion Module Level Variables

    #region Module Level Object

    CCalendar mobjCCalendar = new CCalendar(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
//   GoogleCalendar GoogleCalendar = new GoogleCalendar(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    #endregion Module Level Object

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string lstrMode = "";

            if (Request.QueryString["Mode"] != null)
            {
                lstrMode = Convert.ToString(Request.QueryString["Mode"]);
            }
            else if (Request.Form["Mode"] != null)
            {
                lstrMode = Convert.ToString(Request.Form["Mode"]);
            }

            if (Session["UserId"] != null)
            {
                mdblUserId = Convert.ToDouble(Session["UserId"]);
            }
            if (Session["IsAdmin"] != null)
                IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
            GenerateData(lstrMode);
        }
        catch (Exception ex)
        {
            //In case of Exception - Throw Exception
            throw new Exception(ex.Message);
        }

        //Passing the response data to the calling ajax page
        Response.Write(mstrResponseData);
        Response.Flush();
        Response.End();
    }

    #region GenerateData

    /// *******************************************************************************
    /// <summary>
    /// Generating data based on the mode passed
    /// </summary>
    /// <exclude>
    /// Author - Jasmeet Kaur
    /// Create Date - 090914
    /// </exclude>
    /// <param name="pstrMod">Mode description</param>   
    /// ******************************************************************************* 

    private void GenerateData(string pstrMod)
    {
        switch (pstrMod.ToUpper())
        {
           
            case "GETCALENDAREVENTS":
                try
                {
                    //#A Jasmeet Kaur - Calling funciton to get calendar events.
                    GetCalendarEvents();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }//end Of catch block
                break;
            case "ADD":
                try
                {
                    //#A Jasmeet:092214 - Calling funciton to add calendar event.
                    AddNewEvent();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }//end Of catch block
                break;
            case "GETEVENTDETAILS":

                try
                {
                    //#A Jasmeet:092514-- Calling function to get event details for the selected event.
                    GetDetailsForSelectedEvent();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }//End Of catch block
                break;
            case "DELETEEVENTDETAILS":
                try
                {
                    //#A Jasmeet:092514 - Calling function to delete details for selected event. 
                    DeleteSelectedEventDetails();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }//end Of catch block
                break;
          
            case "APPROVEEVENT":
                try
                {
                    //#A Jasmeet:093014  - Calling function to approve event. 
                    ApproveEvent();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }//end Of catch block
                break;
            case "ADDNEWFOLLOWUPMEET":
                try
                {
                    //#A Jasmeet:021715  - Calling function to add new follow up meet. 
                    AddNewFollowUpMeet();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }//end Of catch block
                break;
            default:
                break;

        }
    }
    #endregion GenerateData

    #region Function

    #region GetCalendarEvents
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:091014
    /// Function used to get calendar events.
    /// </summary>
    private void GetCalendarEvents()
    {
        try
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            StringBuilder msbContents = new StringBuilder();
            JsonWriter writer = new JsonWriter(msbContents);
            DataSet lobjDsEvents = new DataSet();

            double ldblUnixTimeStamp_Start = 0;
            double ldblUnixTimeStamp_End = 0;

            double ldblEventId = -1;
            string lstrTitle = "";
            string lstrStartDate = "";
            string lstrEndDate = "";
            Int32 lintCityID = -1;
            double ldblUserId = -1;
            bool lbnEventApprovedbyAdmin = false;
            bool lbnIsPublic = false;
            string currentYear = DateTime.Now.Year.ToString();
        
            if (Request.QueryString["Start"] != null && Convert.ToString(Request.QueryString["Start"]) != "")
            {
                ldblUnixTimeStamp_Start = Convert.ToDouble(Request.QueryString["Start"]);
            }

            if (Request.QueryString["End"] != null && Convert.ToString(Request.QueryString["End"]) != "")
            {
                ldblUnixTimeStamp_End = Convert.ToDouble(Request.QueryString["End"]);
            }
            if (Request.Form["CityID"] != null)
            {
                lintCityID = Convert.ToInt32(Request.Form["CityID"]);
            }
            else if (Request.QueryString["CityID"] != null)
            {
                lintCityID = Convert.ToInt32(Request.QueryString["CityID"]);
            }
          
            DateTime newStartDate = origin.AddSeconds(ldblUnixTimeStamp_Start);
            DateTime newEndDate = origin.AddSeconds(ldblUnixTimeStamp_End);

            lobjDsEvents = mobjCCalendar.GetCalendarEvents(newStartDate.ToString("yyyy-MM-dd HH:mm:ss"), newEndDate.ToString("yyyy-MM-dd HH:mm:ss"), mdblUserId, lintCityID,IsAdmin);

       
            
            writer.WriteArrayStart();

            if (lobjDsEvents != null)
            {
                if (lobjDsEvents.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in lobjDsEvents.Tables[0].Rows)
                    {

                        if (drow["EventId"] != null)
                        {
                            ldblEventId = Convert.ToDouble(drow["EventId"]);
                        }


                        if (drow["Title"] != null)
                        {
                            lstrTitle = Convert.ToString(drow["Title"]);
                        }
                        //if (drow["StartDateTime"] != null)
                        //{
                        //    if (drow["Title"] == "BirthDay" || drow["Title"] == "Anniversary")
                        //    {
                        //        lstrStartDate = Convert.ToDateTime(drow["StartDateTime"]).ToString("MMM dd yyyy HH:mm:ss");
                        //        lstrStartDate = Convert.ToDateTime(drow["StartDateTime"]).ToString("dd/MM" + "/" + currentYear + " HH:mm:ss");
                        //    }
                        //    else
                        //    {
                        //        lstrStartDate = Convert.ToDateTime(drow["StartDateTime"]).ToString("MMM dd yyyy HH:mm:ss");
                        //    }
                        //}
                        //if (drow["EndDateTime"] != null)
                        //{
                        //    if (drow["Title"] == "BirthDay" || drow["Title"] == "Anniversary")
                        //    {
                        //        lstrStartDate = Convert.ToDateTime(drow["EndDateTime"]).ToString("MMM dd yyyy HH:mm:ss");
                        //        lstrStartDate = Convert.ToDateTime(drow["EndDateTime"]).ToString("dd/MM" + "/" + currentYear + " HH:mm:ss");
                        //    }
                        //    else
                        //    {
                        //        lstrStartDate = Convert.ToDateTime(drow["StartDateTime"]).ToString("MMM dd yyyy HH:mm:ss");
                        //    }
                        //}
                        if (drow["StartDateTime"] != null)
                        {

                            lstrStartDate = Convert.ToDateTime(drow["StartDateTime"]).ToString("MMM dd yyyy HH:mm:ss");
                        }
                        if (drow["EndDateTime"] != null)
                        {

                            lstrEndDate = Convert.ToDateTime(drow["EndDateTime"]).ToString("MMM dd yyyy HH:mm:ss");
                        }

                        if (drow["UserId"] != null)
                        {
                            ldblUserId = Convert.ToDouble(drow["UserId"]);
                        }
                        if (drow["EventApprovedbyAdmin"] != null)
                        {
                            lbnEventApprovedbyAdmin = Convert.ToBoolean(drow["EventApprovedbyAdmin"]);
                        }
                        if (drow["IsPublic"] != null)
                        {
                            lbnIsPublic = Convert.ToBoolean(drow["IsPublic"]);
                        }
                        
                       
                        writer.WriteObjectStart();
                        writer.WritePropertyName("id");
                        writer.Write(ldblEventId.ToString());
                        writer.WritePropertyName("title");
                        writer.Write(Convert.ToDateTime(lstrStartDate).ToShortTimeString() + " " + lstrTitle);
                        writer.WritePropertyName("start");
                        writer.Write(lstrStartDate);
                        writer.WritePropertyName("end");
                        writer.Write(lstrEndDate);
                        writer.WritePropertyName("isapproved");
                        writer.Write(lbnEventApprovedbyAdmin);
                        writer.WritePropertyName("IsPublic");
                        writer.Write(lbnIsPublic);
                        writer.WritePropertyName("url");
                        writer.Write("javascript:GetSelectedEventDetails(" + ldblEventId.ToString() + ")");

                        writer.WritePropertyName("className");

                        if (!lbnEventApprovedbyAdmin)
                            writer.Write("redEvent");
                        else if (lstrTitle == "BirthDay" || lstrTitle == "Anniversary")
                            writer.Write("PinkEvent");
                        else if(!lbnIsPublic)
                            writer.Write("OrangeEvent");
                       
                        else
                            writer.Write("blueEvent");

                        writer.WriteObjectEnd();
                    }
                }
            }
            writer.WriteArrayEnd();

            mstrResponseData = Convert.ToString(msbContents);

        
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    #endregion GetCalendarEvents

    #region AddNewEvent
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:091614
    /// Function used to add new event.
    /// </summary>
    private void AddNewEvent()
    {
       
        try
        {
            string lstrTitle = "";
            string lstrDescription = "";
            string lstrStartDate = "";
            string lstrEndDate = "";
            double ldblEventID = -1;
            string lstrVenue = "";
            Int32 lintStateID = -1;
            Int32 lintCityID = -1;
            
            bool lbnIsAdmin = false;

            if (Request.Form["Title"] != null)
            {
                lstrTitle = Request.Form["Title"].ToString();
            }

            if (Request.Form["Description"] != null)
            {
                lstrDescription = Request.Form["Description"].ToString();
            }
       
            if (Request.Form["FromDate"] != null)
            {
                lstrStartDate = Request.Form["FromDate"].ToString();
            }

            if (Request.Form["ToDate"] != null)
            {
                lstrEndDate = Request.Form["ToDate"].ToString();
            }

            if (Request.Form["EventID"] != null)
            {
                ldblEventID = Convert.ToDouble(Request.Form["EventID"]);
            }

            if (Request.Form["Venue"] != null)
            {
                lstrVenue = Convert.ToString(Request.Form["Venue"]);
            }

            if (Request.Form["StateID"] != null)
            {
                lintStateID = Convert.ToInt32(Request.Form["StateID"]);
            }
            if (Request.Form["CityID"] != null)
            {
                lintCityID = Convert.ToInt32(Request.Form["CityID"]);
            }
            if (Session["IsAdmin"] != null)
            {
                lbnIsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
            }
          
         
            string lstr = mobjCCalendar.AddNewEvent(lstrTitle, lstrDescription, lstrStartDate, lstrEndDate, ldblEventID, mdblUserId, lstrVenue, lintStateID, lintCityID, lbnIsAdmin);

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

    #endregion AddNewEvent

    #region GetDetailsForSelectedEvent
    private void GetDetailsForSelectedEvent()
    {
        Int32 lintstarthrs=-1;
        Int32 lintendhrs=-1;
      //  Int32 lintCityID = -1;
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<EventDetails>");

            double ldblEventID = -1;
            DataSet lobjEventDetails = new DataSet();

            string lstrReturnResult = "";

            if (Request.Form["EventID"] != null)
            {
                ldblEventID = Convert.ToDouble(Request.Form["EventID"]);
            }
            //if (Request.Form["CityID"] != null)
            //{
            //    lintCityID = Convert.ToInt32(Request.Form["CityID"]);
            //}
            lobjEventDetails = mobjCCalendar.GetEventDetails(ldblEventID, mdblUserId);

            if (lobjEventDetails != null)
            {
                stringBuilder.Append("<Contents><Title>");
                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["Title"].ToString());
                stringBuilder.Append("</Title><Description>");
                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["Description"].ToString());
                stringBuilder.Append("</Description><StartDate>");
                stringBuilder.Append(Convert.ToDateTime(lobjEventDetails.Tables[0].Rows[0]["StartDateTime"]).ToString("MM/dd/yyyy"));
                stringBuilder.Append("</StartDate><EndDate>");
                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["EndDateTime"].ToString());
                stringBuilder.Append("</EndDate><StartHours>");

                if (Convert.ToInt32(lobjEventDetails.Tables[0].Rows[0]["StartHours"].ToString()) > 12)
                {
                    lintstarthrs = Convert.ToInt32(lobjEventDetails.Tables[0].Rows[0]["StartHours"].ToString())-12;
                    if (Convert.ToString(lintstarthrs).Length == 1)
                        stringBuilder.Append("0" + lintstarthrs);
                    else
                        stringBuilder.Append(lintstarthrs);
                }
                else
                {
                    if (lobjEventDetails.Tables[0].Rows[0]["StartHours"].ToString().Length == 1)
                        stringBuilder.Append("0" + lobjEventDetails.Tables[0].Rows[0]["StartHours"].ToString());
                    else
                        stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["StartHours"].ToString());
                }
                stringBuilder.Append("</StartHours><StartMinutes>");
               
                if (lobjEventDetails.Tables[0].Rows[0]["StartMinutes"].ToString().Length == 1)
                    stringBuilder.Append("0" + lobjEventDetails.Tables[0].Rows[0]["StartMinutes"].ToString());
                else
                    stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["StartMinutes"].ToString());
            
                stringBuilder.Append("</StartMinutes><EndHours>");
                if (Convert.ToInt32(lobjEventDetails.Tables[0].Rows[0]["EndHours"].ToString()) > 12)
                {
                    lintendhrs = Convert.ToInt32(lobjEventDetails.Tables[0].Rows[0]["EndHours"].ToString())-12;
                    if (Convert.ToString(lintendhrs).Length == 1)
                        stringBuilder.Append("0" + lintendhrs);
                    else
                        stringBuilder.Append(lintendhrs);
                }
                else
                {
                    if (lobjEventDetails.Tables[0].Rows[0]["EndHours"].ToString().Length == 1)
                        stringBuilder.Append("0" + lobjEventDetails.Tables[0].Rows[0]["EndHours"].ToString());
                    else
                        stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["EndHours"].ToString());
                }
                
               
                stringBuilder.Append("</EndHours><EndMinutes>");

                if (lobjEventDetails.Tables[0].Rows[0]["EndMinutes"].ToString().Length == 1)
                    stringBuilder.Append("0" + lobjEventDetails.Tables[0].Rows[0]["EndMinutes"].ToString());
                else
                    stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["EndMinutes"].ToString());

                stringBuilder.Append("</EndMinutes><STARTAMPM>");
                if (Convert.ToInt32(lobjEventDetails.Tables[0].Rows[0]["StartHours"].ToString()) > 12)
                {
                    stringBuilder.Append("PM");
                }
                else
                {
                    stringBuilder.Append("AM");
                }
                stringBuilder.Append("</STARTAMPM><ENDAMPM>");

                if (Convert.ToInt32(lobjEventDetails.Tables[0].Rows[0]["EndHours"].ToString()) > 12)
                {
                    stringBuilder.Append("PM");
                }
                else
                {
                    stringBuilder.Append("AM");
                }
                stringBuilder.Append("</ENDAMPM><CreatedBy>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["CreatedBy"].ToString());
                stringBuilder.Append("</CreatedBy><UserID>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["UserID"].ToString());
                stringBuilder.Append("</UserID><IsPublic>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["IsPublic"].ToString());
                stringBuilder.Append("</IsPublic><Customer>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["Customer"].ToString());
                stringBuilder.Append("</Customer><CustomerID>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["CustomerID"].ToString());
                stringBuilder.Append("</CustomerID><EventApprovedbyAdmin>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["EventApprovedbyAdmin"].ToString());
                stringBuilder.Append("</EventApprovedbyAdmin><Venue>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["Venue"].ToString());
                stringBuilder.Append("</Venue><StateID>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["StateID"].ToString());
                stringBuilder.Append("</StateID><CityID>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["CityID"].ToString());
                stringBuilder.Append("</CityID><Status>");

                stringBuilder.Append(lobjEventDetails.Tables[0].Rows[0]["Status"].ToString());
                stringBuilder.Append("</Status></Contents>");
                                           
            }

            stringBuilder.Append("</EventDetails>");
            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += stringBuilder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";

            mstrResponseData = lstrReturnResult;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }

    #endregion GetDetailsForSelectedEvent

    #region DeleteSelectedEventDetails
    private void DeleteSelectedEventDetails()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<ResultDetails>");
            double ldblEventID = -1;

            string lstrReturnResult = "SUCCESS";

            if (Request.Form["EventID"] != null)
            {
                ldblEventID = Convert.ToDouble(Request.Form["EventID"]);
            }

            mobjCCalendar.DeleteSelectedEventDetails(ldblEventID, mdblUserId);

            stringBuilder.Append("<Contents>");
            stringBuilder.Append("<Result>");
            stringBuilder.Append(lstrReturnResult);
            stringBuilder.Append("</Result>");
            stringBuilder.Append("</Contents>");
            stringBuilder.Append("</ResultDetails>");
            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += stringBuilder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";

            mstrResponseData = lstrReturnResult;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }

    #endregion DeleteSelectedEventDetails

    #region ApproveEvent

    private void ApproveEvent()
    {
        Int32 lintEventID = -1;

        try
        {
           
            if (Request.Form["EventID"] != null)
                lintEventID = Convert.ToInt32(Request.Form["EventID"]);
            else if (Request.QueryString["EventID"] != null)
                lintEventID = Convert.ToInt32(Request.QueryString["EventID"]);

            //#A Jasmeet: 053014 - Approve Event
            mobjCCalendar.ApproveEvent(lintEventID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }


    #endregion ApproveEvent

    #region AddNewFollowUpMeet
    /// <summary>
    /// Author:Jasmeet akur
    /// Date:021715
    /// Function used to add follow up note.
    /// </summary>
    private void AddNewFollowUpMeet()
    {
        Int32 lintEventID = -1;
        Int32 lintCustomerID = -1;
        string lstrFollowUPNote = "";
        bool lbnIsProspects = false;
        try
        {

            if (Request.Form["EventID"] != null)
            {
                lintEventID = Convert.ToInt32(Request.Form["EventID"].ToString());
            }

            if (Request.Form["CustomerID"] != null)
            {
                lintCustomerID = Convert.ToInt32(Request.Form["CustomerID"]);
            }
            if (Request.Form["FollowUpNotes"] != null)
            {
                lstrFollowUPNote = Convert.ToString(Request.Form["FollowUpNotes"]);
            }

            if (Request.Form["IsProspects"] != null)
            {
                lbnIsProspects = Convert.ToBoolean(Request.Form["IsProspects"]);
            }
            mobjCCalendar.AddNewFollowUpMeet(lstrFollowUPNote, lintEventID, lintCustomerID, lbnIsProspects, mdblUserId);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }


    #endregion AddNewFollowUpMeet

  

    #endregion Function


}