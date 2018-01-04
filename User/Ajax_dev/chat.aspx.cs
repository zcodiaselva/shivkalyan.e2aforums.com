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
using chat;

public partial class User_Ajax_dev_index : System.Web.UI.Page
{
    cls_chat obj_chat = new cls_chat();
    cls_chat_prp obj_chat_prp = new cls_chat_prp();

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
            }

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

        }
        catch 
        {
         
        }

        
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

            case "CHATGETUSERSSEARCH":
                {
                    try
                    {
                        //dev Chat Calling function to get user for chat
                        chatGetUsersSearch();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;


            case "CHATGRPGETUSERSSEARCH":
                {
                    try
                    {
                       
                        chatGrpGetUsersSearch();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "CHATCREATEGROUP":
                {
                    try {
                        chatCreateGroup();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;

            case "CHATGETMESSAGE":
                {
                    try {
                        chatGetMessage();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;

            case "CHATSENDMESSAGE":
                {
                    try {
                        chatSendMessage();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;

            case "CHATGETUSERSSINGLE":
                {
                    try {
                        chatGetUsersSingle();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;


            case "CHATGETUSERSGROUP":
                {
                    try {
                        chatGetUsersGroup();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;

            case "CHATGROUPMEMBERGETALL":
                {
                    try {
                        chatGroupMemberGetAll();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;
            case "CHATGROUPMEMBERGETEDIT":
                {
                    try {
                        chatGroupMemberGetEdit();
                    
                    }
                    catch
                    { 
                    
                    }
                 
                }
                break;


            case "CHATGROUPMEMBERADD":
                {
                    try
                    {
                        chatGroupMemberAdd();

                    }
                    catch
                    {

                    }

                }
                break;


            case "GETCHATGRPINFO":
                {
                    try
                    {
                        getchatgrpinfo();

                    }
                    catch
                    {

                    }

                }
                break;
            case "GETCHATGRPEXTMEM":
                {
                    try
                    {
                        getchatgrpextmem();

                    }
                    catch
                    {

                    }

                }
                break;

            case "EDITCHATGRPEXTMEM":
                {
                    try
                    {
                        editchatgrpextmem();

                    }
                    catch
                    {

                    }

                }
                break;
            case "GETCHATGRPSRCMEM":
                {
                    try
                    {
                        getchatgrpsrcmem();

                    }
                    catch
                    {

                    }

                }
                break;

            case "EDITCHATGRPSRCMEM":
                {
                    try
                    {
                        editchatgrpsrcmem();

                    }
                    catch
                    {

                    }

                }
                break;
            case "GETUNRDMESSCOUNTER":
                {
                    try
                    {
                        getUnRdMessCounter();

                    }
                    catch
                    {

                    }

                }
                break;

            case "CHATUPDGROUP":
                {
                    try
                    {
                        chatUpdGroup();

                    }
                    catch
                    {

                    }

                }
                break;

            default:
                mstrResponseData = "Invalid mode";
                break;


        }
    }


    #endregion GenerateData

    #region Functions

    #region chatUpdGroup
   
    private void chatUpdGroup()
    {
        Int32 flag = -1;
        string strGrp_ID = "";

        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        string strGrpName, strGrpIconUrl;
        if (Request.Form["GrpName"] != null)
        {
            strGrpName = Convert.ToString(Request.Form["GrpName"]);
        }
        else
        {
            strGrpName = null;
        }
        if (Request.Form["GrpIconUrl"] != null)
        {
            strGrpIconUrl = Convert.ToString(Request.Form["GrpIconUrl"]);
        }
        else
        {
            strGrpIconUrl = null;
        }

        try
        {

            obj_chat_prp.grp_name = strGrpName;
            obj_chat_prp.grp_by_user_id = Convert.ToInt32(mdblUserID);
            obj_chat_prp.grp_img_url = strGrpIconUrl;
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            obj_chat_prp.grp_by_user_id = Convert.ToInt32(mdblUserID);
            flag = obj_chat.chat_update_group(obj_chat_prp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion chatUpdGroup

    #region getUnRdMessCounter

    private void getUnRdMessCounter()
    {
        double lintMsgsenderID = mdblUserID;
        Int32 CoutMess = 0;
        try
        {
            obj_chat_prp.destination_id = Convert.ToInt32(lintMsgsenderID);
            CoutMess = obj_chat.chat_all_unread_msg(obj_chat_prp);

           


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = CoutMess.ToString();
    }

    #endregion getUnRdMessCounter

    #region getchatgrpsrcmem

    private void getchatgrpsrcmem()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "";

        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        string strFullName = "";
        if (Request.Form["Full_Name"] != null)
        {
            strFullName = Convert.ToString(Request.Form["Full_Name"]);
        }
        else
        {
            strFullName = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_chat.chat_group_member_search(strGrp_ID, strFullName, mdblUserID);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (mdblUserID != Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]))
                    {
                        builder.Append("<a   class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        if (ds.Tables[0].Rows[i]["user_status"].ToString() == "YES")
                        {
                            builder.Append("<div  class=\"slctMmb\"><label class=\"switch\"> <input  onclick='getchatGroupMemberAdd(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\"  class=\"switch\" value=\"1\" checked/> <span></span> </label></div>");
                            //builder.Append("<span class=\"adminIndi label-success\">Already Added !</span>");
                        }
                        else
                        {
                            builder.Append("<div   class=\"slctMmb\"><label class=\"switch\"> <input  onclick='getchatGroupMemberAdd(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\" class=\"switch\" value=\"1\" /> <span></span> </label></div>");
                        }
                        builder.Append("</a> ");

                    }
                    else
                    {
                        builder.Append("<a  class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        builder.Append("<span class=\"adminIndi label-danger\">Group admin</span>");

                        builder.Append("</a> ");
                    }
                }
            }
          

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion getchatgrpsrcmem

    #region editchatgrpsrcmem

    private void editchatgrpsrcmem()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "";

        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        string strFullName = "";
        if (Request.Form["Full_Name"] != null)
        {
            strFullName = Convert.ToString(Request.Form["Full_Name"]);
        }
        else
        {
            strFullName = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_chat.chat_group_member_search(strGrp_ID, strFullName, mdblUserID);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (mdblUserID != Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]))
                    {
                        builder.Append("<a   class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        if (ds.Tables[0].Rows[i]["user_status"].ToString() == "YES")
                        {
                            builder.Append("<div  class=\"slctMmb\"><label class=\"switch\"> <input  onclick='edit_grp_member_search_status_upd(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\"  class=\"switch\" value=\"1\" checked/> <span></span> </label></div>");
                            //builder.Append("<span class=\"adminIndi label-success\">Already Added !</span>");
                        }
                        else
                        {
                            builder.Append("<div   class=\"slctMmb\"><label class=\"switch\"> <input  onclick='edit_grp_member_search_status_upd(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\" class=\"switch\" value=\"1\" /> <span></span> </label></div>");
                        }
                        builder.Append("</a> ");

                    }
                    else
                    {
                        builder.Append("<a  class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        builder.Append("<span class=\"adminIndi label-danger\">Group admin</span>");

                        builder.Append("</a> ");
                    }
                }
            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion editchatgrpsrcmem



    #region getchatgrpextmem

    private void getchatgrpextmem()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "";

        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            DataSet ds = obj_chat.chat_group_member_get_alll(obj_chat_prp);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["by_UserID"]) != Convert.ToInt32(ds.Tables[0].Rows[i]["to_UserID"]))
                    {
                        builder.Append("<a class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["to_Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        if (ds.Tables[0].Rows[i]["user_status"].ToString() == "YES")
                        {
                            builder.Append("<div title='Active Member' class=\"slctMmb\"><label class=\"switch\"> <input type=\"checkbox\" class=\"switch\"  onclick='getchatGroupMemberAddextUp(" + ds.Tables[0].Rows[i]["to_UserID"].ToString() + ")' value=\"1\" checked/> <span></span> </label></div>");
                        }
                        else
                        {
                            builder.Append("<div title='Not Active Member'  class=\"slctMmb\"><label class=\"switch\"> <input type=\"checkbox\" class=\"switch\"  onclick='getchatGroupMemberAddextUp(" + ds.Tables[0].Rows[i]["to_UserID"].ToString() + ")' value=\"1\" /> <span></span> </label></div>");
                        }
                        builder.Append("</a> ");

                    }
                    else
                    {
                        builder.Append("<a class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["to_Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        builder.Append("<span class=\"adminIndi label-danger\">Group admin</span>");

                        builder.Append("</a> ");
                    }
                }
            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion getchatgrpextmem


    #region editchatgrpextmem

    private void editchatgrpextmem()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "";

        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            DataSet ds = obj_chat.chat_group_member_get_alll(obj_chat_prp);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["by_UserID"]) != Convert.ToInt32(ds.Tables[0].Rows[i]["to_UserID"]))
                    {
                        builder.Append("<a class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["to_Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        if (ds.Tables[0].Rows[i]["user_status"].ToString() == "YES")
                        {
                            builder.Append("<div title='Active Member' class=\"slctMmb\"><label class=\"switch\"> <input type=\"checkbox\" class=\"switch\"  onclick='edit_group_ext_member_status_upd(" + ds.Tables[0].Rows[i]["to_UserID"].ToString() + ")' value=\"1\" checked/> <span></span> </label></div>");
                        }
                        else
                        {
                            builder.Append("<div title='Not Active Member'  class=\"slctMmb\"><label class=\"switch\"> <input type=\"checkbox\" class=\"switch\"  onclick='edit_group_ext_member_status_upd(" + ds.Tables[0].Rows[i]["to_UserID"].ToString() + ")' value=\"1\" /> <span></span> </label></div>");
                        }
                        builder.Append("</a> ");

                    }
                    else
                    {
                        builder.Append("<a class=\"list-group-item\" href=\"#\"> <div class=\"list-group-status status-online\"></div>");
                        builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) == "Experts")
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["to_Occupation"]) + " )" + "</p>");

                                }
                                else
                                {
                                    builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span><p>" + Convert.ToString(ds.Tables[0].Rows[i]["to_UserType"]) + "</p>");

                                }
                            }
                            else
                            {

                                builder.Append("<span class=\"contacts-title\">" + Convert.ToString(ds.Tables[0].Rows[i]["to_Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class=\"contacts-title\"> - </span>");
                        }

                        builder.Append("<span class=\"adminIndi label-danger\">Group admin</span>");

                        builder.Append("</a> ");
                    }
                }
            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion editchatgrpextmem

    #region chatGroupMemberAdd

    private void chatGroupMemberAdd()
    {
        Int32 out_put = 0;
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "",str_grp_user_id="";



        if (Request.Form["Grp_User_ID"] != null)
        {
            str_grp_user_id = Convert.ToString(Request.Form["Grp_User_ID"]);
        }
        else
        {
            str_grp_user_id = null;
        }
        
        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }

        try
        {
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            obj_chat_prp.grp_user_id = Convert.ToInt32(str_grp_user_id);
            out_put = obj_chat.chat_group_member_add(obj_chat_prp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = out_put.ToString();
    }
    #endregion chatGroupMemberAdd


    #region chatGroupMemberGetEdit
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users serach for chat.
    /// </summary>
    private void chatGroupMemberGetEdit()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "";
        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            DataSet ds = obj_chat.chat_group_member_get_alll(obj_chat_prp);
            builder.Append("<div class=\"modal-backdrop fade in\" style=\"height: 100%;\"></div>");
            builder.Append("<div class=\"modal-dialog\"> <div class=\"modal-content\"><div class=\"modal-header\">");
            builder.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>");
            builder.Append("<h4 class=\"modal-title\"><span class=\"fa fa-comments\"></span> Edit Group</h4>  </div>");


               builder.Append("<div class=\"modal-body\"> <div class=\"content-frame\"> <div class=\"row\" id=\"\"><div id=\"editGrpView\"> <div class=\"col-md-4\">");
               builder.Append("<div class=\"panel panel-default text-center\"><div class=\"panel-body\">"); 
          
                builder.Append("<div class=\"profile-image grpIcon\">  <img alt=\"\"  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[0]["grp_img_url"].ToString() + " \"> </div>");
                builder.Append("<div class=\"form-group\"><div class=\"col-md-12\"><h6><strong>" + ds.Tables[0].Rows[0]["grp_name"] + "</strong></h6>");
                 builder.Append("<small>" + ds.Tables[0].Rows.Count + " in your group</small></div></div><button type=\"button\" class=\"btn btn-primary btn-rounded\" id=\"editAddMembBtn\">Add Group Members</button> <button id=\"GroupEditbtn\" type=\"button\" class=\"btn btn-info btn-rounded\">Edit</button> ");
                builder.Append("</div></div></div></div>");
                builder.Append("<div class=\"panel panel-default\" id=\"GroupEdit\"><div class=\"panel-body\"><p>Update Group Info.</p>");
                builder.Append("<div class=\"form-group\"><div class=\"col-md-2\"><div class=\"form-group\"><div class=\"col-md-12\">");
                builder.Append("<input type=\"file\" class=\"\" name=\"filename\" id=\"file1\" title=\"Browse file\"/>");
                builder.Append("<span class=\"help-block\">Group Icon</span> </div> </div> </div>");
                builder.Append("<div class=\"col-md-8\"><div class=\"form-group\"><div class=\"col-md-12\">");
                builder.Append("<div class=\"input-group\"> <span class=\"input-group-addon\"><span class=\"fa fa-pencil\"></span></span>");
                builder.Append("<input type=\"text\" class=\"form-control\"></div><span class=\"help-block\">Enter Group Name</span> </div>");
                builder.Append("</div></div><div class=\"col-md-2\"><button class=\"btn btn-success btn-block\"><span class=\"fa fa-refresh\"></span>Update</button>");
                builder.Append("</div> </div> </div> </div></div>");



              builder.Append("<div class=\"content-frame-right\"><div class=\"list-group list-group-contacts border-bottom push-down-10\"> ");
                  
     if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["by_UserID"]) != Convert.ToInt32(ds.Tables[0].Rows[i]["to_UserID"]))
                    {
           
                    builder.Append("<a class=\"list-group-item\" href=\"#\"><div class=\"list-group-status status-online\"></div>");
                    builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \"> <span class=\"contacts-title\">" + ds.Tables[0].Rows[i]["to_Full_Name"].ToString() + "</span>");

                   

                        builder.Append("<div class=\"slctMmb\"><label class=\"switch\"><input type=\"checkbox\" class=\"switch\" value=\"1\" checked/>");
                    builder.Append("<span></span> </label></div></a>");                
                    
                    }
                    else
                    {
                    builder.Append("<a class=\"list-group-item\" href=\"#\"><div class=\"list-group-status status-online\"></div>");
                    builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \"> <span class=\"contacts-title\">" + ds.Tables[0].Rows[i]["to_Full_Name"].ToString() + "</span>");
                    builder.Append("<p></p>");
                    builder.Append("<span class=\"adminIndi label-danger\">Group admin</span> </a>"); 
                    }

                }
            }
            //Done
     builder.Append("</div></div></div>");
     builder.Append("<div class='addSearch' id='editsearchTraget' style='display:none;'><div class='closeBtn'><i class='fa fa-times' title='Close Seach Panel' data-placement='top' data-toggle='tooltip' id='closeBtnSearchBar'></i></div>");

     builder.Append("<div id='Div3' class='content-frame-top'><div class='form-group'><div class='row'><div class='col-md-8'>");
     builder.Append("<div class='input-group'><div class='input-group-addon'> <span class='fa fa-search'></span> </div>");

     builder.Append("<input type='text' id='edit_grp_chat_user_search' class='form-control' placeholder='Who are you looking for?'>");
     builder.Append("<div class='input-group-btn'><button onclick='chat_group_edit_get_UsersSearch()' class='btn btn-primary'>Search</button></div>");
     builder.Append("</div></div></div></div></div>");


     builder.Append("<div class='content-frame-right' style='height: 288px;'><div id='chat_grp_search_users_list' class='list-group list-group-contacts border-bottom push-down-10'>");



     builder.Append("</div><div class='col-md-12'>");
     builder.Append("</div></div></div>");
            builder.Append("</div>");
     builder.Append("<div class=\"modal-footer\"><button data-dismiss=\"modal\" class=\"btn btn-default\" type=\"button\">Close</button></div>");
          
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGroupMemberGetEdit



    #region chatGroupMemberGetAll
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users serach for chat.
    /// </summary>
    private void chatGroupMemberGetAll()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strGrp_ID = "";

        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            DataSet ds = obj_chat.chat_group_member_get_alll(obj_chat_prp);
            builder.Append("<div class=\"modal-backdrop fade in\" style=\"height: 100%;\"></div>");
        builder.Append("<div class=\"modal-dialog\"> <div class=\"modal-content\"><div class=\"modal-header\">");
       builder.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>");
              builder.Append("<h4 class=\"modal-title\"><span class=\"fa fa-comments\"></span> View  Group</h4>  </div>");
              builder.Append("<div class=\"modal-body\"><div class=\"content-frame\">   <div class=\"col-md-12 profile\"> <div class=\"panel panel-default\">");
          // builder.Append("<div style=\"background: url(\'../E2Forums-New/img/music-4.jpg\') center center no-repeat;\" class=\"panel-body profile\">
     builder.Append("<div class=\"profile-image\"> <img alt=\"Nadia Ali\"  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[0]["grp_img_url"].ToString() + " \"> </div>");
                //<div class="profile-data">
                //  <div class="profile-data-name">Nadia Ali</div>
                //  <div style="color: #FFF;" class="profile-data-title">Singer-Songwriter</div>
                //</div>
                 builder.Append("<div class=\"profile-controls\">  </div>");
            //  </div>
                 builder.Append("<div class=\"panel-body\"> <div class=\"row\">  <div class=\"col-md-12\">");
                 builder.Append(" <div class=\"btn btn-info btn-rounded btn-block\"><span class=\"fa fa-check\"></span> " + ds.Tables[0].Rows[0]["grp_name"] + " </div>");
                  builder.Append("</div>            </div>              </div>");
              builder.Append("<div class=\"panel-body list-group border-bottom\">");
  

                  //builder.Append(" <a class=\"list-group-item\" href=\"#\"><span class=\"fa fa-coffee\"></span> Groups <span class=\"badge badge-default\">18</span></a> ");
                   builder.Append(" <a class=\"list-group-item\" href=\"#\"><span class=\"fa fa-users\"></span> Members <span class=\"badge badge-danger\">"+ds.Tables[0].Rows.Count+"</span></a> </div>");
              builder.Append("<div class=\"panel-body scroll-verticle\"> <h4 class=\"text-title\">Members</h4><div class=\"row\">");
             if (ds != null)
            {
                string MessageTime = string.Empty;
               
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["by_UserID"]) != Convert.ToInt32(ds.Tables[0].Rows[i]["to_UserID"]))
                    {
                        builder.Append("<div class=\"col-md-3 col-xs-3\"> <a class=\"friend\" href=\"#\"> <img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["to_uPicture"].ToString() + " \"> <span>" + ds.Tables[0].Rows[i]["to_Full_Name"].ToString() + "</span> </a> </div>");
                    }
                    else
                    {
                        builder.Append("<div class=\"col-md-3 col-xs-3\"> <a class=\"friend\" href=\"#\"> <img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["by_uPicture"].ToString() + " \"> <span>" + ds.Tables[0].Rows[i]["by_Full_Name"].ToString() + " (GROUP ADMIN)" + "</span> </a> </div>");
                    }

                } 
        }
             builder.Append(" </div>  </div> </div>  </div>    </div>      </div>");
             builder.Append("<div class=\"modal-footer\"> <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>  </div>  </div> </div></div>");


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGroupMemberGetAll


    #region chatGrpGetUsersSearch
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users serach for chat.
    /// </summary>
    private void chatGrpGetUsersSearch()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strFullName = "";

        double lintMsgdestinationID = 0;
        if (Request.Form["Full_Name"] != null)
        {
            strFullName = Convert.ToString(Request.Form["Full_Name"]);
        }
        else
        {
            strFullName = null;
        }
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_chat.chat_get_users_search(strFullName, mdblUserID);

            if (ds != null)
            {
                string MessageTime = string.Empty;
                builder.Append("<span id=\"clsSearchPnl\" class=\"clsSearchPnl\"><i class=\"fa fa-close\"></i> Close </span>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (lintMsgsenderID != Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]))
                    {

                        // Bind Chat Box Design
                        lintMsgdestinationID = Convert.ToDouble(ds.Tables[0].Rows[i]["UserID"]);

                        builder.Append("<a href='#' class='list-group-item'><div class='list-group-status status-online'></div>");
                        builder.Append("<img alt=\"avatar\" onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \" class=\"img-circle avatar avatar-xs\">");




                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("<span class='contacts-title'>" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span> <span class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</span>");
                                }
                                else
                                {
                                    builder.Append("<span class='contacts-title'>" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span> <span class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</span>");
                                }
                            }
                            else
                            {
                                builder.Append("<span class='contacts-title'>" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>");
                            }

                        }
                        else
                        {
                            builder.Append("<span class='contacts-title'> - </span> <span class=\"text-muted\">- </span>");
                        }



                        builder.Append("<div class='slctMmb'><label class='switch'><input id=" + ds.Tables[0].Rows[i]["UserID"].ToString() + " onclick='chatGroupMemberAdd("+ds.Tables[0].Rows[i]["UserID"].ToString()+")'  type='checkbox' value='1' class='switch foreign_checkbox'>");
                        builder.Append("<span></span> </label></div></a>");



                       

                    }
                    else
                    {

                    }

                }



            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No User Found</div>");

            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGrpGetUsersSearch




    #region chatGetUsersSearch
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users serach for chat.
    /// </summary>
    private void chatGetUsersSearch()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
        // serch name for chat
        string strFullName = "";

        double lintMsgdestinationID = 0;
        if (Request.Form["Full_Name"] != null)
        {
            strFullName = Convert.ToString(Request.Form["Full_Name"]);
        }
        else
        {
            strFullName = null;
        }
         StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_chat.chat_get_users_search(strFullName, mdblUserID);

            if (ds != null)
            {
                string MessageTime = string.Empty;
                builder.Append("<span id=\"clsSearchPnl\" class=\"clsSearchPnl\"><i class=\"fa fa-close\"></i> Close </span>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (lintMsgsenderID != Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]))
                    {

                        // Bind Chat Box Design
                        lintMsgdestinationID = Convert.ToDouble(ds.Tables[0].Rows[i]["UserID"]);

                        builder.Append("<a href=\"javascript:void(0)\"   onClick=\"chat_get_message(" + mdblUserID + "," + "'USER'" + " ," + lintMsgdestinationID + ")\">");
                        builder.Append("<div class=\"media-left relative\">");
                        builder.Append("<img alt=\"avatar\" onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \" class=\"img-circle avatar avatar-xs\">");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span> <span class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</span> </div>");
                                }
                                else
                                {
                                    builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span> <span class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</span>  </div>");
                                }
                            }
                            else
                            {
                            builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>  </div>");
                            }

                        }
                        else
                        {
                            builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\"> - </span> <span class=\"text-muted\">- </span> </div>");
                        }

                        builder.Append("</a>");
                      
                    }
                    else
                    {
                       
                    }

                }
                

               
            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No User Found</div>");

            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGetUsersSearch



    #region chatGetUsersGroup
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users GetUsersSingle for chat.
    /// </summary>
    private void chatGetUsersGroup()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;


        double lintMsgdestinationID = 0;

        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.destination_id = Convert.ToInt32(lintMsgsenderID);
            DataSet ds = obj_chat.chat_get_users(obj_chat_prp);

            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                   

                        // Bind Chat Box Design
                        lintMsgdestinationID = Convert.ToDouble(ds.Tables[1].Rows[i]["grp_id"]);
                        builder.Append("<li>");
                        builder.Append("<a href=\"javascript:void(0)\"   onClick=\"chat_get_message(" + mdblUserID + "," + "'GROUP'" + " ," + lintMsgdestinationID + ")\">");
                        builder.Append("<div class=\"media-left relative\">");
                        builder.Append("<span readonly=\"readonly\" class=\"informer informer-danger\">" + ds.Tables[1].Rows[i]["unread_count"] + "</span>");
                      
                        builder.Append("<img alt=\"avatar\" onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[1].Rows[i]["grp_img_url"].ToString() + " \" class=\"img-circle avatar avatar-xs\">");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["grp_name"])))
                        {

                            builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[1].Rows[i]["grp_name"]) + "</span>  </div>");
                           

                        }
                        else
                        {
                            builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\"> - </span> <span class=\"text-muted\">- </span> </div>");
                        }

                        builder.Append("</a>");

                        if (mdblUserID.ToString() == ds.Tables[1].Rows[i]["grp_by_user_id"].ToString())
                        {

                            builder.Append("<div class=\"editgrp\"><span data-target=\"#EditGrpChtModal\" data-toggle=\"modal\"    onclick=\"return chat_group_member_get_edit(" + ds.Tables[1].Rows[i]["grp_id"] + ")\"   href=\"javascript:void();\"><i class=\"fa fa-pencil\"></i></span> <span href=\"javascript:void();\" data-target=\"#GrpChtMbrModal\" onclick=\"return chat_group_member_get_all(" + ds.Tables[1].Rows[i]["grp_id"] + ")\" data-toggle=\"modal\"><i class=\"fa fa-users\"></i></span></div>");
                        }
                        else
                        {
                            builder.Append("<div class=\"editgrp\"> <span href=\"javascript:void();\" data-target=\"#GrpChtMbrModal\" onclick=\"return chat_group_member_get_all(" + ds.Tables[1].Rows[i]["grp_id"] + ")\" data-toggle=\"modal\"><i class=\"fa fa-users\"></i></span></div>");
                        }
                            builder.Append("</li>");
                  

                }



            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No User Found</div>");

            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGetUsersGroup


    #region chatGetUsersSingle
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users GetUsersSingle for chat.
    /// </summary>
    private void chatGetUsersSingle()
    {
        //for message get sender id 
        double lintMsgsenderID = mdblUserID;
    

        double lintMsgdestinationID = 0;
       
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.destination_id = Convert.ToInt32(lintMsgsenderID);
            DataSet ds = obj_chat.chat_get_users(obj_chat_prp);

            if (ds != null)
            {
                string MessageTime = string.Empty;
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (lintMsgsenderID != Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]))
                    {

                        // Bind Chat Box Design
                        lintMsgdestinationID = Convert.ToDouble(ds.Tables[0].Rows[i]["UserID"]);

                        builder.Append("<a href=\"javascript:void(0)\"   onClick=\"chat_get_message(" + mdblUserID + "," + "'USER'" + " ," + lintMsgdestinationID + ")\">");
                        builder.Append("<div class=\"media-left relative\">");
                        builder.Append("<span readonly=\"readonly\" class=\"informer informer-danger\">" + ds.Tables[0].Rows[i]["message_unread"] + "</span>");
                        
                        builder.Append("<img alt=\"avatar\" onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \" class=\"img-circle avatar avatar-xs\">");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                                {
                                    builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span> <span class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</span> </div>");
                                }
                                else
                                {
                                    builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span> <span class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + "</span>  </div>");
                                }
                            }
                            else
                            {
                                builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\">" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>  </div>");
                            }

                        }
                        else
                        {
                            builder.Append("</div> <div class=\"media-body\"> <span class=\"block-tit\"> - </span> <span class=\"text-muted\">- </span> </div>");
                        }

                        builder.Append("</a>");

                    }
                    else
                    {

                    }

                }



            }
            else
            {

                builder.Append("<div class=\"row alert-danger nouserFound\" style='text-align:center'>No User Found</div>");

            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGetUsersSingle


    #region chatCreateGroup
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void chatCreateGroup()
    {
        Int32 flag =-1;
        string strGrpName, strGrpIconUrl;
        if (Request.Form["GrpName"] != null)
        {
            strGrpName = Convert.ToString(Request.Form["GrpName"]);
        }
        else
        {
            strGrpName = null;
        }
        if (Request.Form["GrpIconUrl"] != null)
        {
            strGrpIconUrl = Convert.ToString(Request.Form["GrpIconUrl"]);
        }
        else
        {
            strGrpIconUrl = null;
        }
        
        try
        {

            obj_chat_prp.grp_name = strGrpName;
            obj_chat_prp.grp_by_user_id = Convert.ToInt32(mdblUserID);
            obj_chat_prp.grp_img_url = strGrpIconUrl;
             flag= obj_chat.chat_create_group(obj_chat_prp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString() ;
    }

    #endregion chatCreateGroup



    #region chatGetMessage
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users serach for chat.
    /// </summary>
    private void chatGetMessage()
    {
     
         //sender_id: var_sender_id,
         //destination_type: var_destination_type,
         //destination_id: var_destination_id
    
        string str_sender_id = "", str_destination_type = "", str_destination_id="" ;
       
        if (Request.Form["sender_id"] != null) { str_sender_id = Convert.ToString(Request.Form["sender_id"]);  } else { str_sender_id = null;}
        if (Request.Form["destination_type"] != null)   {      str_destination_type = Convert.ToString(Request.Form["destination_type"]); } else { str_destination_type = null;}
       if (Request.Form["destination_id"] != null)     {  str_destination_id = Convert.ToString(Request.Form["destination_id"]); } else { str_destination_id = null; }
       StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.sender_id =Convert.ToInt32( str_sender_id);
            obj_chat_prp.destination_type = str_destination_type.ToString();
            obj_chat_prp.destination_id = Convert.ToInt32(str_destination_id);
            DataSet ds = obj_chat.get_message(obj_chat_prp);

            if (ds != null)
            {
                string MessageTime = string.Empty;
               

                builder.Append("<div class=\"chat-header\"> <a class=\"chat-back\" href=\"javascript:;\"> <i class=\"fa fa-angle-left\"></i></a>");
                builder.Append("<div class=\"chat-header-title\">" + ds.Tables[1].Rows[0]["Full_Name"] + "</div>");
                builder.Append("<a class=\"chat-right\" href=\"javascript:;\"> <i class=\"fa fa-circle-thin\"></i> </a> </div>");
                builder.Append(" <div id='chatscrl' class=\"chat-conversation-content\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    if (ds.Tables[0].Rows[i]["date_time"] != null)
                    {
                        DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["date_time"]);
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["date_time"]);
                        MessageTime = "";
                        if (ts.Days > 0)
                        {
                            if (ts.Days > 7)
                            {
                                Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                Int32 leftdays = (ts.Days - (week * 7));

                                MessageTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                            }
                            else
                                MessageTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                        }
                        else if (ts.Hours > 0)
                        {
                            MessageTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                        }
                        else if (ts.Minutes > 0)
                        {
                            MessageTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                        }
                        else MessageTime = "few seconds ago";

                    }

                    if (ds.Tables[0].Rows[i]["sender_id"].ToString() == mdblUserID.ToString())
                    {
                    
                        builder.Append("<p class=\"text-center text-muted small text-uppercase bold pb15\">" + MessageTime + " </p>");
                        builder.Append("<div class=\"chat-conversation-user me\">");
                        builder.Append("<div class=\"media-left relative\">");
                        builder.Append("<img alt=\"avatar\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \" class=\"img-circle avatar avatar-xs\"  onerror=\"this.onerror=null;this.src='../e2forums-new/img/default_profile_pic.jpg';\"> </div>");
                        builder.Append("<div class=\"chat-conversation-message\">");
                        builder.Append("<span class=\"personname\">" + ds.Tables[0].Rows[i]["Full_Name"] + "</span>");
                        builder.Append("<p>" + ds.Tables[0].Rows[i]["chat_message"].ToString() + "</p>");
                        builder.Append("</div>");
                        builder.Append("</div>");

                    
                    }
                    else
                    {
                        builder.Append("<p class=\"text-center text-muted small text-uppercase bold pb15\">" + MessageTime + " </p>");
                        builder.Append("<div class=\"chat-conversation-user them\">");
                        builder.Append("<div class=\"media-left relative\">");
                        builder.Append("<img alt=\"avatar\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \" class=\"img-circle avatar avatar-xs\"  onerror=\"this.onerror=null;this.src='../e2forums-new/img/default_profile_pic.jpg';\"> </div>");
                        builder.Append("<div class=\"chat-conversation-message\">");
                        builder.Append("<span class=\"personname\">" + ds.Tables[0].Rows[i]["Full_Name"] + "</span>");
                        builder.Append("<p>" + ds.Tables[0].Rows[i]["chat_message"].ToString() + "</p>");
                        builder.Append("</div>");
                        builder.Append("</div>");
                    }
                       
                        
                       
                         

                }
                        builder.Append("<div class=\"chat-conversation-footer\">");
                        builder.Append("<button class=\"chat-input-tool\"> <i class=\"fa fa-comments-o\"></i> </button>");
                        builder.Append("<textarea id=\"chat_message_dev\" placeholder=\"enter text here...\" class=\"chat-input\"></textarea>");
                        builder.Append("<button onClick=\"chat_send_message(" + str_sender_id + ",'"  +  str_destination_type + "' ," + str_destination_id + ")\" class=\"chat-send\"> <i class=\"fa fa-paper-plane\"></i> </button>");
                        builder.Append("</div>");


                builder.Append("</div>");

            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No User Found</div>");

            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion chatGetMessage




    #region chatSendMessage
    /// <summary>
    /// Author:dev Date:11 /07/2015
    /// Function used to get users serach for chat.
    /// </summary>
    private void chatSendMessage()
    {

        string str_message="", str_sender_id = "", str_destination_type = "", str_destination_id = "";
        if (Request.Form["message"] != null) { str_message = Convert.ToString(Request.Form["message"]); } else { str_sender_id = null; }
        if (Request.Form["sender_id"] != null) { str_sender_id = Convert.ToString(Request.Form["sender_id"]); } else { str_sender_id = null; }
        if (Request.Form["destination_type"] != null) { str_destination_type = Convert.ToString(Request.Form["destination_type"]); } else { str_destination_type = null; }
        if (Request.Form["destination_id"] != null) { str_destination_id = Convert.ToString(Request.Form["destination_id"]); } else { str_destination_id = null; }
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_chat_prp.chat_message = str_message;
            obj_chat_prp.sender_id = Convert.ToInt32(str_sender_id);
            obj_chat_prp.destination_type = str_destination_type.ToString();
            obj_chat_prp.destination_id = Convert.ToInt32(str_destination_id);
           obj_chat.send_message(obj_chat_prp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = "Success";
    }

    #endregion chatSendMessage


    #region getchatgrpinfo
   
    private void getchatgrpinfo()
    {
        DataSet ds = new DataSet();
      
        string strGrp_ID = "";
        if (Request.Form["Grp_ID"] != null)
        {
            strGrp_ID = Convert.ToString(Request.Form["Grp_ID"]);
        }
        else
        {
            strGrp_ID = null;
        }

        try
        {
            obj_chat_prp.grp_id = Convert.ToInt32(strGrp_ID);
            
            ds = obj_chat.chat_group_info_get(obj_chat_prp);
        }
        catch (Exception ex)
        {
            throw;
        }
        StringBuilder builder = new StringBuilder("<Response><UserData>");
        try
        {
            if (ds != null)
            {
                builder.Append("<grp_id><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["grp_id"]));
                builder.Append("]]></grp_id>");

                builder.Append("<grp_name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["grp_name"]));
                builder.Append("]]></grp_name>");

                builder.Append("<grp_by_user_id><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["grp_by_user_id"]));
                builder.Append("]]></grp_by_user_id>");

                builder.Append("<grp_img_url><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["grp_img_url"]));
                builder.Append("]]></grp_img_url>");

                builder.Append("<prp_status><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["prp_status"]));
                builder.Append("]]></prp_status>");

                builder.Append("<date_time><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["date_time"]));
                builder.Append("]]></date_time>");

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

    #endregion getchatgrpinfo

    #endregion Functions


}

 