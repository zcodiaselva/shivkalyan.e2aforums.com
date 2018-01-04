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
//using Google.GData.Calendar;

public partial class User_Ajax_AjaxUser : System.Web.UI.Page
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
    double mdblZoneID = -1;
    public double mdblUserTypeID { get; set; }
    public double mdblOccupationID { get; set; }
    public int OfCompID { get; set; }
    public string locPlanActivel { get; set; }

    #endregion

    #region Page Load
    /// *******************************************************************************
    /// <summary>
    /// Function used to fire page load event.
    /// </summary>
    /// <exclude>
    /// Author - Sahil Sharma
    /// Date - 072314
    /// </exclude>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// *******************************************************************************
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

            if (Session["PlanActive"] != null)
            {
                locPlanActivel = Session["PlanActive"].ToString();
            }
            else
            {
                locPlanActivel = "NO";
            }

            if (Session["OfCompID"]!=null)
            OfCompID = Convert.ToInt32(Session["OfCompID"]);

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
        catch 
        {
            Response.Redirect("logout.aspx");
           
        }//End catch

        //#A Sahil:072314 - Passing the response data to the calling ajax page.
        Response.Write(mstrResponseData);
        Response.Flush();
        Response.End();

    }
    #endregion Page Load

    #region GenerateData
    /// *******************************************************************************
    /// <summary>
    /// Generating data based on the mode passed
    /// </summary>
    /// <exclude>
    /// Author - Sahil 
    /// Date - 072314
    /// </exclude>
    /// <param name="pstrMod">Mode description</param>    
    /// *******************************************************************************
    private void GenerateData(string pstrMod)
    {
        switch (pstrMod.ToUpper())
        {
            case "ADDUSERDET":
                {
                    try
                    {
                        //#A:Sahil:072314 - Calling function to add user detail
                        AddUserDet();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;


            case "GETOCCUPATIONS":
                try
                {
                    //#A Sahil:072314 -- Calling function to get occupations from db
                    GetOccupations();

                }//end of try
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }//End Of catch block
                break;

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
            case "GETFORUMCATEGORY":
                {
                    try
                    {
                        //#A:Jasmeet:072114 - Calling function to get category details of forum.
                        GetForumCategory();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETMYFORUMCATEGORY":
                {
                    try
                    {
                        //#A:Jasmeet:072114 - Calling function to get category details of forum.
                        GetMyForumCategory();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETFORUMTOPICS":
                {
                    try
                    {
                        //#A:Jasmeet:072214 - Calling function to get topic details of forum.
                        GetForumTopics();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETMYFORUMTOPICS":
                {
                    try
                    {
                        //#A:Jasmeet:072214 - Calling function to get topic details of forum.
                        GetMyForumTopics();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLCATEGORYCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:072214 - Calling function to fill category combo.
                        FillCategoryCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETFORUMPOSTS":
                {
                    try
                    {
                        //#A:Jasmeet:072214 - Calling function to fill category combo.
                        GetForumPosts();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLTOPICCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:072214 - Calling function to fill topic combo.
                        FillTopicComboFilter();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCATEGORYLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:072414 - Calling function to fill topic combo.
                        GetCategoryListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETECATEGORY":
                {
                    try
                    {
                        //#A:Jasmeet:072514 - Calling function to delete category.
                        DeleteCategory();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "ADDCATEGORY":
                {
                    try
                    {
                        //#A:Jasmeet:072514 - Calling function to add category.
                        AddCategory();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCATEGORYDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:072514 - Calling function to get category detais for editing.
                        GetCategoryDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETTOPICLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:072514 - Calling function to get Topic listing.
                        GetTopicListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETETOPIC":
                {
                    try
                    {
                        //#A:Jasmeet:072814 - Calling function to delete topics and its posts.
                        DeleteTopic();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETTOPICDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:072814 - Calling function to delete topics and its posts.
                        GetTopicDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDNEWTOPIC":
                {
                    try
                    {
                        //#A:Jasmeet:072814 - Calling function to add new topics.
                        AddNewTopic();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "LIKEPOST":
                {
                    try
                    {
                        //#A:Jasmeet:072814 - Calling function to like posts.
                        LikePosts();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "POSTTOPICCOMMENTS":
                {
                    try
                    {
                        //#A:Jasmeet:073014 - Calling function to save topic comments.
                        PostTopicComments();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDPOSTCOMMENTS":
                {
                    try
                    {
                        //#A:Jasmeet:073014 - Calling function to save topic comments.
                        AddPostComments();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETTOPICVIEWCOUNT":
                {
                    try
                    {
                        //#A:Jasmeet:073014 - Calling function to save topic comments.
                        GetTopicViewCount();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "SENDMESSAGE":
                {
                    try
                    {
                        //#A:Sahil:081014 - Calling function to message to the users
                        SendMessage();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETSENDERSNAMELIST":
                {
                    try
                    {
                        //#A:Jasmeet:081114 - Calling function to sender's list.
                        GetSenderNameList();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETMESSAGELIST":
                {
                    try
                    {
                        //#A:Jasmeet:081114 - Calling function to sender's message list.
                        GetMessageList();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "POSTMESSAGETOUSER":
                {
                    try
                    {
                        //#A:Jasmeet:081114 - Calling function to post message to user.
                        PostMessageToUser();
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
            case "UNLIKEPOSTS":
                {
                    try
                    {
                        //#A:Jasmeet:081414 - Calling function to unlike the liked post.
                        UnlikePosts();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETPOSTSLIST":
                {
                    try
                    {
                        //#A:Jasmeet:081914 - Calling function to get posts list.
                        GetPostsList();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETUSERSLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:082714 - Calling function to get users list.
                        GetUsersListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "COMPGETUSERSLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:082714 - Calling function to get users list.
                        CompGetUsersListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "VIEWUSERPROFILE":
                {
                    try
                    {
                        //#A:Jasmeet:082714 - Calling function to view user profile.
                        ViewUserProfile();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "MARKUSERDISABLE":
                {
                    try
                    {
                        //#A:Jasmeet:082714 - Calling function to disable for loggin selected user.
                        MarkUserDisable();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETALLNOTIFICATIONS":
                {
                    try
                    {
                        //#A:Jasmeet:082814 - Calling function to get notifications.
                        GetAllNotifications();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETEVENTALERT":
                {
                    try
                    {
                        //#A:Jasmeet:082814 - Calling function to get notifications.
                        GetEventAlert();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;


            case "GETALLALERT":
                {
                    try
                    {
                        //#Dev - Calling function to get alert.
                        GetAllAlert();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "VIEWNOTIFICATIONS":
                {
                    try
                    {
                        //#A:Jasmeet:082814 - Calling function to view notifications.
                        ViewNotifications();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "POSTTOPICURL":
                {
                    try
                    {
                        //#A:Jasmeet:090914 - Calling function to post url content.
                        PostTopicUrl();
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
            case "FILLIMGSIZECOMBO":
                {
                    try
                    {
                        //#A:Jasmeet:092214 - Calling function to fill image size combo.
                        FillImgSizeCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDNEWADVERTISEMENT":
                {
                    try
                    {
                        //#A:Jasmeet:092314 - Calling function to add new advertisement
                        AddNewAdvertisement();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETADVERTISEMENTLISTING":
                {
                    try
                    {
                        //#A:Jasmeet:092314 - Calling function to get advertisement listing.
                        GetAdvertisementListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETEADVERTISEMENT":
                {
                    try
                    {
                        //#A:Jasmeet:092314 - Calling function to delete advertisement.
                        DeleteAdvertisement();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETADVERTISEMENTDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:092314 - Calling function to get advertisement details.
                        GetAdvertisementDetails();
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
            case "SHOWADVERTISEMENT":
                {
                    try
                    {
                        //#A:Jasmeet:100214 - Calling function to show advertisement.
                        ShowAdvertisement();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDRSSFEED":
                {
                    try
                    {
                        //#A:Jasmeet:100814 - Calling function to add rss feed.
                        AddRssfeed();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETRSSFEEDTITLELIST":
                {
                    try
                    {
                        //#A:Jasmeet:100814 - Calling function to add rss feed.
                        GetRssFeedTitleList();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETRSSFEEDLIST":
                {
                    try
                    {
                        //#A:Jasmeet:100814 - Calling function to add rss feed.
                        GetRssFeedList();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETERSSFEED":
                {
                    try
                    {
                        //#A:Jasmeet:100814 - Calling function to add rss feed.
                        DeleteRssFeed();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETRSSFEEDDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet:101014 - Calling function to get rss feed details.
                        GetRssFeedDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETUSERSRSSFEEDTITLELIST":
                {
                    try
                    {
                        //#A:Jasmeet:101314 - Calling function to get user's rss feed details.
                        GetUsersRssFeedDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "LIKETOPIC":
                {
                    try
                    {
                        //#A:Jasmeet:101314 - Calling function to like topic
                        LikeTopic();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "UNLIKETOPIC":
                {
                    try
                    {
                        //#A:Jasmeet:101414 - Calling function to unlike topic
                        UnlikeTopic();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "REMOVENOTIFICATION":
                {
                    try
                    {
                        //#A:Jasmeet:101614 - Calling function to Remove Notification.
                        RemoveNotification();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "POSTVIDEO":
                {
                    try
                    {
                        //#A:Jasmeet:101614 - Calling function to Remove Notification.
                        PostVideo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "ADDNEWADVERTISEMENTZONE":
                {
                    try
                    {
                        //#A:ParamBajwa:12022014 - Calling function to add new advertisement Group
                        AddNewAdvertisementZone();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETADVERTISEMENTZONELISTING":
                {
                    try
                    {
                        //#A:ParamBajwa:12022014 - Calling function to Get AdvertisemenZone Listing
                        GetAdvertisemenZoneListing();                      
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "DELETEADVERTISEMENTZONE":
                {
                    try
                    {
                        //#A:ParamBajwa:12022014 - Calling function to Get delete advertisement zone
                        DeleteAdvertisementZone();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETADVERTISEMENTZONEDETAILS":
                {
                    try
                    {
                        //#A:ParamBajwa:12022014 - Calling function to Get Advertisement Zone Details
                        GetAdvertisementZoneDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLZONECOMBO":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12032014 - Calling function to Get fill zone
                        FillZoneCombo();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETEXPERTSLISTING":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12052014 - Calling function to Get Experts Listing
                        GetExpertsListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDEDITCHAPTER":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12192014 - Calling function to add/edit chapters.
                        AddEditChapter();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCHAPTERSLISTING":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12192014 - Calling function to get chapters listing.
                        GetChaptersListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETECHAPTERS":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12192014 - Calling function to delete chapters.
                        DeleteChapters();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCHAPTERDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12192014 - Calling function to get chapters detail.
                        GetChapterDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "ADDEDITSUBTITLES":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12192014 - Calling function to add/edit SubTitles.
                        AddEditSubTitles();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCOURSENAME":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12192014 - Calling function to get course name.
                        GetCourseName();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETCOURSESUBTITLESLISTING":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12222014 - Calling function to get sub-titles listing of selected course..
                        GetCourseSubTitlesListing();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETSUBTITLESDETAILS":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12232014 - Calling function to get sub-titles details for editing.
                        GetSubTitleDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETESUBTITLES":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12232014 - Calling function to delete sub-titles.
                        DeleteSubTitle();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETALLCOURSES":
                {
                    try
                    {
                        //#A:Jasmeet kaur:12232014 - Calling function to get all courses.
                        GetAllCourses();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "GETALLLESSONS":
                {
                    try
                    {
                        //#A:Jasmeet kaur:010515 - Calling function to get all Lessons of selected course.
                        GetAllLessons();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "POSTEVENTTOGOOGLECALENDAR":
                {
                    try
                    {
                        //#A:Jasmeet kaur:012915 - Calling function to post event to google calendar.
                        PostEventToGoogleCalendar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "FILLSTATUSCOMBO":
                {
                    try
                    {
                        //#A:Jasmeet kaur:020915 - Calling function to fill status combo.
                        FillStatusCombo();
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
            case "DELETEPOST":
                {
                    try
                    {
                        //#A:Jasmeet kaur:041415 - Calling function to delete Seclected post..
                        DeleteSelectedPost();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            case "DELETEPOSTCOMMENTS":
                {
                    try
                    {
                        //#A:Jasmeet kaur:041415 - Calling function to delete Seclected comment..
                        DeletePostComments();
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

    #region Functions

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
        string lstrDesignation = "";
        try
        {

            if (Request.Form["Full_Name"] != null)
                lstrName = Convert.ToString(Request.Form["Full_Name"]);

            if (Request.Form["OccupationID"] != null)
                lintOccupationID = Convert.ToInt32(Request.Form["OccupationID"]);
               
            if (Request.Form["OtherOccupation"] != null)
                lstrOtherOccupation = Convert.ToString(Request.Form["OtherOccupation"]);
            if (Request.Form["Designation"] != null)
                lstrDesignation = Convert.ToString(Request.Form["Designation"]);

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
            mobjCUser.UpdateUserDetails(lstrName, lintOccupationID, lstrOtherOccupation, lstrOrganization, lstrAddress1, lstrAddress2, lstrAddress3, lstrDealerName, lstrMgs, lstrGoverningBody, lstrInBusinessSince, lstrPhone, lstrImages, lintConsent, mdblUserID, lintStateID, lintCityID, lstrVideoURL, lstrAboutMe, lstrDesignation);

            if (Session["OccupationID"] != null)
                Session["OccupationID"] = mobjCUser.OccupationID;
                mdblOccupationID = mobjCUser.OccupationID;
            if (Session["UserTypeID"] != null)
                Session["UserTypeID"] = mobjCUser.UserTypeID;
            mstrResponseData = "SUCCESS";
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion UpdateUserDetails
     
    #region AddUserDet
    /// ***********************************************************
    /// <summary>
    /// Function used to add clinic Detail
    /// </summary>
    /// <exclude>
    /// <Author>Sahil Sharma</Author>
    /// <Date>072314</Date>
    /// </exclude>
    /// ***********************************************************
    private void AddUserDet()
    {

        string lstrFirstName = "";
        string lstrLastname = "";
        string lstrOrg = "";
        string lstrOtherOccupation = "";
        string lstrAddress1 = "";
        string lstrAddress2 = "";
        string lstrCity = "";
        string lstrAddress = "";
        string lstrMga = "";
        string lstrGovBody = "";
        string lstrSince = "";
        string lstrPhoneNo = "";
        Int32 lintOccuID = -1;
        Int32 lintConsent = -1;
        string lstrOccupation = "";
        Int32 lintStateID = -1;
        Int32 lintCityID = -1;
        string lstrVideoURL = "";

        try
        {
            if (!String.IsNullOrEmpty(Request.Form["FirstName"].ToString()))
                lstrFirstName = Convert.ToString(Request.Form["FirstName"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["Lastname"].ToString()))
                lstrLastname = Convert.ToString(Request.Form["Lastname"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["Organization"].ToString()))
                lstrOrg = Convert.ToString(Request.Form["Organization"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["Address_line1"].ToString()))
                lstrAddress1 = Convert.ToString(Request.Form["Address_line1"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["Address_Line2"].ToString()))
                lstrAddress2 = Convert.ToString(Request.Form["Address_Line2"].Trim());

            //if (!String.IsNullOrEmpty(Request.Form["City"].ToString()))
            //    lstrCity = Convert.ToString(Request.Form["City"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["DealerName"].ToString()))
                lstrAddress = Convert.ToString(Request.Form["DealerName"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["Mga"].ToString()))
                lstrMga = Convert.ToString(Request.Form["Mga"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["GoverningBody"].ToString()))
                lstrGovBody = Convert.ToString(Request.Form["GoverningBody"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["InBusinessSince"].ToString()))
                lstrSince = Convert.ToString(Request.Form["InBusinessSince"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["Mobile_Phone"].ToString()))
                lstrPhoneNo = Convert.ToString(Request.Form["Mobile_Phone"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["OccupationID"].ToString()))
                lintOccuID = Convert.ToInt32(Request.Form["OccupationID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["OtherOccupation"].ToString()))
                lstrOtherOccupation = Convert.ToString(Request.Form["OtherOccupation"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["CommunicateConsent"].ToString()))
                lintConsent = Convert.ToInt32(Request.Form["CommunicateConsent"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["OccupationText"].ToString()))
                lstrOccupation = Convert.ToString(Request.Form["OccupationText"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["StateID"].ToString()))
                lintStateID = Convert.ToInt32(Request.Form["StateID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["CityID"].ToString()))
                lintCityID = Convert.ToInt32(Request.Form["CityID"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["CityText"].ToString()))
                lstrCity = Convert.ToString(Request.Form["CityText"].Trim());

            if (!String.IsNullOrEmpty(Request.Form["ProfileYoutubeURL"].ToString()))
                lstrVideoURL = Convert.ToString(Request.Form["ProfileYoutubeURL"].Trim());

            if (mdblUserID != -1)
            {
                if (mdblUserTypeID != 2)
                {
                    mobjCUser.AddUserDetails(lstrFirstName, lstrLastname, lstrOrg, lstrAddress1, lstrAddress2, lstrAddress, lstrMga, lstrGovBody, lstrSince, lstrPhoneNo, mdblUserID, lintOccuID, lstrOtherOccupation, lintConsent, lintStateID, lintCityID, lstrVideoURL, mdblUserTypeID);
                    SendSuccessEmail(mstrEmailID);
                    mstrResponseData = "SUCCESS";
                }
                else
                {
                    mobjCUser.AddUserDetails(lstrFirstName, lstrLastname, lstrOrg, lstrAddress1, lstrAddress2, lstrAddress, lstrMga, lstrGovBody, lstrSince, lstrPhoneNo, mdblUserID, lintOccuID, lstrOtherOccupation, lintConsent, lintStateID, lintCityID, lstrVideoURL, mdblUserTypeID);
                    SendAdminVerificationEmail(mdblUserID, WebConfigurationManager.AppSettings["EmailFrom"].ToString(), mstrEmailID, lstrFirstName, lstrLastname, lstrOrg, lstrAddress1, lstrAddress2, lstrCity, lstrAddress, lstrMga, lstrGovBody, lstrSince, lstrPhoneNo, lintOccuID, lstrOtherOccupation, lintConsent, lstrOccupation);
                    SendSuccessEmail(mstrEmailID);
                    mstrResponseData = "EXPERT";
                }

               
            }
            
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

    }



    #endregion AddUserDet

    #region SendAdminVerificationEmail
    /// <summary>
    /// function used to send verification email
    /// </summary>
    private void SendAdminVerificationEmail(double ldblUserId, string email, string mstrEmailID, string lstrFirstName, string lstrLastname, string lstrOrg, string lstrAddress1, string lstrAddress2, string lstrCity, string lstrAddress, string lstrMga, string lstrGovBody, string lstrSince, string lstrPhoneNo, int lintOccuID, string lstrOtherOccupation, int lintConsent, string lstrOccupation)
    {
        StringBuilder lobjbuilder = new StringBuilder();
        try
        {
            CMail lobjMail = new CMail();
            Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
            string lstrApproveURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "Verification.aspx?tok=" + ldblUserId.ToString() + "&m=" + lobjEnc.Encrypt("Approve", true);
            string lstrUnApproveURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "Verification.aspx?tok=" + ldblUserId.ToString() + "&m=" + lobjEnc.Encrypt("UnApprove", true);

            string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("../../AdminVerificationMailContent.txt"), Encoding.UTF8);
            //lstrMessage = lstrMessage.Replace("<Verifylink>", HttpUtility.UrlEncode(lstrURL));
            lstrMessage = lstrMessage.Replace("<first_name>", lstrFirstName);
            lstrMessage = lstrMessage.Replace("<last_name>", lstrLastname);
            lstrMessage = lstrMessage.Replace("<Organization>", lstrOrg);
            lstrMessage = lstrMessage.Replace("<Address1>", lstrAddress1);
            lstrMessage = lstrMessage.Replace("<Address2>", lstrAddress2);
            lstrMessage = lstrMessage.Replace("<City>", lstrCity);
            lstrMessage = lstrMessage.Replace("<Mga>", lstrMga);
            lstrMessage = lstrMessage.Replace("<GoverningBody>", lstrGovBody);
            lstrMessage = lstrMessage.Replace("<InBusinessSince>", lstrSince);
            lstrMessage = lstrMessage.Replace("<Phone_number>", lstrPhoneNo);
            if (lintOccuID == 7)
            {
                lstrMessage = lstrMessage.Replace("<Occupation>", lstrOtherOccupation);
            }
            else
            {
                lstrMessage = lstrMessage.Replace("<Occupation>", lstrOccupation);
            }

            lstrMessage = lstrMessage.Replace("<ApprovelinkOriginal>", lstrApproveURL);
            lstrMessage = lstrMessage.Replace("<UnApprovelinkOriginal>", lstrUnApproveURL);
            lstrMessage = lstrMessage.Replace("<EMAIL_ADDRESS>", mstrEmailID);
            lobjMail.EmailTo = email;
            lobjMail.Subject = "E2A: Email Verification";
            lobjMail.MessageBody = lstrMessage;
            lobjMail.SendEMail();

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion SendAdminVerificationEmail

    #region SendSuccessEmail
    /// <summary>
    /// function used to send verification email
    /// </summary>
    private void SendSuccessEmail(string pstrEmail)
    {
        StringBuilder lobjbuilder = new StringBuilder();
        try
        {
            CMail lobjMail = new CMail();
            string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("../../UserSuccessMailContent.txt"), Encoding.UTF8);
            lobjMail.EmailTo = pstrEmail;
            lobjMail.Subject = "e2aForums: Account Creation Mail";
            lobjMail.MessageBody = lstrMessage;
            lobjMail.SendEMail();

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region GetOccupations
    private void GetOccupations()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");

        string lstrReturnResult = "";
        //#A Sahil 072314 Getting occupations from db

        lobjBuilder.Append("<GetTypes>");
        try
        {


            lobjDS = mobjCUser.GetOccupations();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {

                    lobjBuilder.Append("<Contents>");
                    lobjBuilder.Append("<Name>");
                    lobjBuilder.Append(Convert.ToString(lobjDS.Tables[0].Rows[i]["Title"]));
                    lobjBuilder.Append("</Name>");

                    lobjBuilder.Append("<ID>");
                    lobjBuilder.Append(Convert.ToString(lobjDS.Tables[0].Rows[i]["OccupationID"]));
                    lobjBuilder.Append("</ID>");
                    lobjBuilder.Append("</Contents>");
                }
            }
            lobjBuilder.Append("</GetTypes>");
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

    #endregion GetClassSection

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
            ds = mobjCUser.GetUserDetails(mdblUserID);

            if (ds != null)
            {
                builder.Append("<Full_Name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                builder.Append("]]></Full_Name>");

                builder.Append("<Picture><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Picture"]));
                builder.Append("]]></Picture>");

                if (Session["UserTypeId"] != null)
                {
                    builder.Append("<UserTypeId><![CDATA[");
                    builder.Append(Convert.ToString(Session["UserTypeId"]));
                    builder.Append("]]></UserTypeId>");
                }

                //if(!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"])))
                //{
                //    mstrResponseData = Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]);
                //}
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

    #region GetMyForumCategory
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:072114
    /// Function Used to get details of category.
    /// </summary>
    private void GetMyForumCategory()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

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
            string PostTime = "";
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


                mobjCCommon.SetGridVariables(CConstants.enumTables.TblCategories.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetForumCategoryDetails(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostDate"])))
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    PostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    PostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                PostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                PostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else PostTime = "few seconds ago";

                        }

                        else
                        {
                            PostTime = "-";
                        }
                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");


                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Category"])) || !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiv(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Category"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiv(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\"><strong>" + "-" + "</strong></a><br><small>" + "-" + "</small></h4></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Topics"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + Convert.ToString(ds.Tables[0].Rows[i]["Topics"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + "-" + "</td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Posts"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + Convert.ToString(ds.Tables[0].Rows[i]["Posts"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + "-" + "</td>]]></cell>");
                        }
                        if (mdblOccupationID == 7)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a>" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a  href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["LastPostUserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }

                        builder.Append(" </row>");
                    }

                }

                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetMyForumCategory
    #region GetForumCategory
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:072114
    /// Function Used to get details of category.
    /// </summary>
    private void GetForumCategory()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

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
            string PostTime = "";
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


                mobjCCommon.SetGridVariables(CConstants.enumTables.TblCategories.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetForumCategoryDetails(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostDate"])))
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    PostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    PostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                PostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                PostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else PostTime = "few seconds ago";

                        }

                        else
                        {
                            PostTime = "-";
                        }
                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");


                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Category"])) || !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiv(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Category"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiv(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\"><strong>" + "-" + "</strong></a><br><small>" + "-" + "</small></h4></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Topics"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + Convert.ToString(ds.Tables[0].Rows[i]["Topics"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + "-" + "</td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Posts"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + Convert.ToString(ds.Tables[0].Rows[i]["Posts"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\">" + "-" + "</td>]]></cell>");
                        }
                        if (mdblOccupationID == 7)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a>" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a  href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["LastPostUserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }

                        builder.Append(" </row>");
                    }

                }

                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetForumCategory

    #region GetForumTopicsListing
    /// <summary>
    /// Author:Jasmeet Kaur
    /// </summary>
    private void GetForumTopics()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

            Int32 lintCategoryID = -1;
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
            string PostTime = "";
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

                if (Request.QueryString["CategoryID"] != null)
                {
                    lintCategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                    mobjCCommon.CategoryID = lintCategoryID;
                    mobjCUser.CategoryID = lintCategoryID;
                }

                mobjCCommon.SetGridVariables(CConstants.enumTables.TblTopics.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetForumTopicDetails(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, lintCategoryID);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostDate"])))
                        //                   if (ds.Tables[0].Rows[i]["LastPostDate"] != null)
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    PostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    PostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                PostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                PostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else PostTime = "few seconds ago";

                        }
                        else
                        {
                            PostTime = "-";
                        }

                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");

                        if (Convert.ToString(ds.Tables[0].Rows[i]["IsFlagged"]) == "True")
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Topic"])) || !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a class=\"addTabs\" id='" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "' onclick='return AddnewTab(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ",\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]).Replace("'", "") + "\"," + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")'  href='#'><strong>" + "" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a class=\"addTabs\" id='" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "' onclick='return AddnewTab(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ",\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]).Replace("'", "") + "\"," + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")' href='#'><strong>" + "" + "-" + "</strong></a><br><small>" + "-" + "</small></h4></td>]]></cell>");
                            }
                        }
                        else
                        {

                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a class=\"addTabs\" id='" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "' onclick='return AddnewTab(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ",\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]).Replace("'", "") + "\"," + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")' href='#'><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Replies"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + Convert.ToString(ds.Tables[0].Rows[i]["Replies"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + "0" + "</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["TopicView"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + Convert.ToString(ds.Tables[0].Rows[i]["TopicView"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + "0" + "</td>]]></cell>");

                        }
                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                        //{
                        //    builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a>" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");

                        //    //builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\" style=\"text-align:center;\">by " + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "<br><small>" + PostTime + "</small></td>]]></cell>");
                        //}
                        //else
                        //{
                        //    builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");


                        //}

                        if (mdblOccupationID == 7)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a>" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a  href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["LastPostUserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }
                        builder.Append(" </row>");
                    }

                }


                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetForumTopicsListing


    #region GetMyForumTopicsListing
    /// <summary>
    /// Author:Jasmeet Kaur
    /// </summary>
    private void GetMyForumTopics()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

            Int32 lintUserID = -1;
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
            string PostTime = "";
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

                if (Request.QueryString["UserID"] != null)
                {
                    lintUserID = Convert.ToInt32(Request.QueryString["UserID"]);
                    mobjCCommon.UserID = lintUserID;
                    mobjCUser.UserID = lintUserID;
                }

                mobjCCommon.SetGridVariables(CConstants.enumTables.TblTopics.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetMyForumTopicDetails(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, lintUserID);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostDate"])))
                        //                   if (ds.Tables[0].Rows[i]["LastPostDate"] != null)
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    PostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    PostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                PostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                PostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else PostTime = "few seconds ago";

                        }
                        else
                        {
                            PostTime = "-";
                        }

                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");

                        if (Convert.ToString(ds.Tables[0].Rows[i]["IsFlagged"]) == "True")
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Topic"])) || !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a class=\"addTabs\" id='" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "' onclick='return AddnewTab(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ",\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]).Replace("'", "") + "\"," + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")'  href='#'><strong>" + "" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a class=\"addTabs\" id='" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "' onclick='return AddnewTab(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ",\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]).Replace("'", "") + "\"," + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")' href='#'><strong>" + "" + "-" + "</strong></a><br><small>" + "-" + "</small></h4></td>]]></cell>");
                            }
                        }
                        else
                        {

                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a class=\"addTabs\" id='" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "' onclick='return AddnewTab(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ",\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]).Replace("'", "") + "\"," + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")' href='#'><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Replies"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + Convert.ToString(ds.Tables[0].Rows[i]["Replies"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + "0" + "</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["TopicView"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + Convert.ToString(ds.Tables[0].Rows[i]["TopicView"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + "0" + "</td>]]></cell>");

                        }
                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                        //{
                        //    builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a>" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");

                        //    //builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\" style=\"text-align:center;\">by " + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "<br><small>" + PostTime + "</small></td>]]></cell>");
                        //}
                        //else
                        //{
                        //    builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");


                        //}

                        if (mdblOccupationID == 7)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a>" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a  href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["LastPostUserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a>-</a></td>]]></cell>");

                            }
                        }
                        builder.Append(" </row>");
                    }

                }


                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetMyForumTopicsListing

    #region FillCategoryCombo
    //#A Jasmeet: 073014 - function used to fill combo category combo
    private void FillCategoryCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.FillCategoryCombo();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<CategoryID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["CategoryID"].ToString() + "]]>");
                    lobjBuilder.Append("</CategoryID>");

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


    #endregion FillSkillsTypeCombo

    #region GetForumPosts
    /// <summary>
    /// Author:jasmeet kaur
    /// Date:073104
    /// function used to get forum posts.
    /// </summary>
    private void GetForumPosts()
    {

        Int32 lintTopicID = -1;
        string lstrTopicTime = "";
        string lstrPostTime = "";
        string lstrCommentTime = "";
        string lstrImages = "";
        string[] splitImage = new string[20];

        StringBuilder builder = new StringBuilder();
        if (Request.Form["TopicID"] != null)
        {
            lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);
        }

        try
        {

            DataSet ds = mobjCUser.GetForumPosts(lintTopicID, mdblUserID);

            if (ds != null)
            {
                #region Advisors
                if (mdblOccupationID != 7)
              {
                //if (mdblUserTypeID == 2 || mdblUserTypeID == 1)
                //{
                    builder.Append("<div class=\"block\" >");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        builder.Append("<div class=\"block-content-full\">");
                        builder.Append("<ul class=\"media-list media-feed media-feed-hover\">");
                        builder.Append("<li class=\"media\">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Title"])))
                        {

                            builder.Append("<div class=\"media-body\">");

                            if (ds.Tables[0].Rows[0]["TopicTime"] != null)
                            {
                                DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["TopicTime"]);
                                TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0]["TopicTime"]);

                                if (ts.Days > 0)
                                {
                                    if (ts.Days > 7)
                                    {
                                        Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                        Int32 leftdays = (ts.Days - (week * 7));

                                        lstrTopicTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                    }
                                    else
                                        lstrTopicTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                }
                                else if (ts.Hours > 0)
                                {
                                    lstrTopicTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                }
                                else if (ts.Minutes > 0)
                                {
                                    lstrTopicTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                }
                                else lstrTopicTime = "few seconds ago";

                            }

                            builder.Append("<p class=\"push-bit\"><span class=\"text-muted pull-right\">");
                            builder.Append("Added by <a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[0]["UserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "</a><br>");
                            builder.Append("<small class=\"text-muted pull-right\">" + lstrTopicTime + "</small>");
                            builder.Append("<h4><a><strong >" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + "</strong></a></h4>");
                            builder.Append("</p>");
                            builder.Append("<Description>");
                            builder.Append("" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]) + "");

                            if (locPlanActivel == "YES")
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TopicShareUserID"])))
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["LikeAndShareUserID"])))
                                    {
                                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTopicShare"]) == true)
                                        {
                                            //To read more, sign up at www.e2aforums.com today!
                                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["TopicShareUserID"]) == mdblUserID)
                                            {
                                                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + " <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"   onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> |</a> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! ', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a> </span></p>");
                                            }
                                            else
                                            {
                                                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "  <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"   onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> |</a> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today!', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a></span> </p>");

                                            }
                                        }
                                        else
                                        {
                                            builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + " <img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "  <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"   onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> | </a> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! ', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a> </span></p>");

                                        }

                                    }
                                    else
                                    {
                                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTopicShare"]) == true)
                                        {
                                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["TopicShareUserID"]) == mdblUserID)
                                            {
                                                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "  <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"   onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> |</a> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today!', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a></span></p>");
                                            }
                                            else
                                            {
                                                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "   <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"  onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> |</a><a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! ', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a> </span></p>");

                                            }
                                        }
                                        else
                                        {

                                            builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\"  onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "   <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> |</a> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! ', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a> </span></p>");
                                        }
                                    }

                                }
                                else
                                {

                                    builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "   <a  href=\"https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: ' To read more, sign up at www.e2aforums.com today! '&url=http://e2aforums.com&original_referer=http://e2aforums.com\"  class=\"twitter-share-button\" data-url=\"http://e2aforums.com\" data-text=\"Enter Data text asdashere\" data-size=\"large\" data-count=\"none\"onclick=\"window.open('https://twitter.com/intent/tweet?text=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description:  To read more, sign up at www.e2aforums.com today! &url=http://e2aforums.com&original_referer=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/tw.jpg' /> |</a> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.linkedin.com/shareArticle?mini=true&url=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \', 'newwindow', 'width=650, height=382'); return false;\"   > <img src='img/in.jpg' /> |</a>  <a href=\"https://plus.google.com/share?url=http://e2aforums.com\"  onclick=\"window.open('https://plus.google.com/share?url=http://e2aforums.com', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/gplus.jpg' /> |</a> <a href=\"http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today! \"  onclick=\"window.open('http://www.facebook.com/share.php?u=http://e2aforums.com&title=Topic: " + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + " , Description: To read more, sign up at www.e2aforums.com today!', 'newwindow', 'width=650, height=382'); return false;\"   >  <img src='img/fb.jpg' /> |</a></span></p>");

                                }
                            }
                            else
                            {


                                builder.Append("<p>  Your current plan is expired. Kindly purchase a plan fore share,<a href='../Pricing.aspx' target='_blank'> Click Here</a></p>");
                            }
                            
                            

                            builder.Append("</Description>");

                            builder.Append("<div  class=\"block\">");
                            builder.Append("<div  class=\"block-title\"><h2><strong>" + "Post" + "</strong>" + "  " + "something.." + "</h2></div>");
                            builder.Append("<form action=\"page_forms_components.html\" method=\"post\" class=\"block-content-full block-content-mini-padding\" onsubmit=\"return false;\">");
                            builder.Append("<textarea id=\"default-textarea\" name=\"default-textarea\" rows=\"2\" class=\"form-control push-bit\" placeholder=\"What are you thinking?\"></textarea>");
                            builder.Append("<div class=\"clearfix\">");
                            builder.Append("<table style=\"width:100%;\">");
                            builder.Append("<tr>");
                            builder.Append("<td><input id=\"Video\" type=\"radio\" value=\"Video\" name=\"PostType\" style=\"float:left;margin-left:5px;\" onchange=\"return ShowPostVideoSection();\"/><label class=\"col-md-3 control-label\">Video</label><input id=\"Images\" type=\"radio\" value=\"Images\" name=\"PostType\" style=\"float:left;\" onchange=\"return ShowPostVideoSection();\"/><label class=\"col-md-3 control-label\">Images</label>");
                            builder.Append("<td>");
                            builder.Append("<button type=\"submit\" class=\"btn btn-sm btn-primary pull-right\" style=\"margin-left:10px;\" onclick=\"return PostTopicUrl('true');\"><i class=\"fa fa-pencil\"></i>Post As URL</button>");
                            builder.Append("<button type=\"submit\" class=\"btn btn-sm btn-primary pull-right\" onclick=\"return PostTopicComments('false');\"><i class=\"fa fa-pencil\"></i>Post As Text</button>");
                            builder.Append("</td></tr>");
                            builder.Append("<tr clospan='2'>");
                            builder.Append("<td><div id=\"divPostVideo\" style=\"display:none;\"><input id=\"txtVideoURL\" name=\"txtVideoURL\" placeholder=\"Enter Youtube URL...\" class=\"form-control\" style=\"width:50%;\" type=\"text\" /></div></td></tr>");
                            builder.Append("</table>");
                            builder.Append("<div id=\"divImages\" style=\"display:none;\">");
                            builder.Append("<div><input type=\"file\" name=\"filUpload1\" id=\"filUpload1\" onchange=\"showimagepreview(this)\" /></div>");
                            builder.Append("<img id=\"filUpload1Img\" style='display:none' height='50px' alt=\"uploaded image preview\"/>");
                            builder.Append("<a href='#' id='filUpload1-a'  style='display:none;margin-left:7px;' onclick='RemoveImage(\"filUpload1\")'>Remove</a>");
                            builder.Append("<div><input  type=\"file\" name=\"filUpload2\" id=\"filUpload2\" onchange=\"showimagepreview(this)\"/></div>");
                            builder.Append("<img id=\"filUpload2Img\" style='display:none' height='50px' alt=\"uploaded image preview\"/>");
                            builder.Append("<a href='#' id='filUpload2-a'  style='display:none;margin-left:7px;'  onclick='RemoveImage(\"filUpload2\")'>Remove</a>");
                            builder.Append("<div><input type=\"file\" name=\"filUpload3\" id=\"filUpload3\" onchange=\"showimagepreview(this)\"/></div>");
                            builder.Append("<img id=\"filUpload3Img\" style='display:none' height='50px' alt=\"uploaded image preview\"/>");
                            builder.Append("<a href='#' id='filUpload3-a'  style='display:none;margin-left:7px;'  onclick='RemoveImage(\"filUpload3\")'>Remove</a>");
                            builder.Append("</div>");
                            builder.Append("</div>");
                            builder.Append("</form>");
                            builder.Append("</div>");
                        }
                        builder.Append("</li>");
                        builder.Append("</ul>");
                        builder.Append("</div>");
                    }


                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataView dv = new DataView(ds.Tables[1]);
                        DataTable dt = dv.ToTable(true, "PostID");

                        builder.Append("<div class=\"block\">");
                        bool hasHeaderWritten = false;
                        foreach (DataRow dr in dt.Rows)
                        {
                            hasHeaderWritten = false;
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                Int32 lintPostID = Convert.ToInt32(ds.Tables[1].Rows[i]["PostID"]);
                                if (Convert.ToInt32(dr[0]) == Convert.ToInt32(ds.Tables[1].Rows[i]["PostID"]))
                                {

                                    if (!hasHeaderWritten)
                                    {
                                        builder.Append("<div class=\"block-content-full\">");
                                        builder.Append("<ul class=\"media-list media-feed media-feed-hover\"  style=\"min-height:300px;\">");
                                        builder.Append("<li class=\"media\">");

                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Posts"])))
                                        {
                                            if (ds.Tables[1].Rows[i]["PostTime"] != null)
                                            {
                                                DateTime inputDateTime = Convert.ToDateTime(ds.Tables[1].Rows[i]["PostTime"]);
                                                TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[1].Rows[i]["PostTime"]);

                                                if (ts.Days > 0)
                                                {
                                                    if (ts.Days > 7)
                                                    {
                                                        Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                                        Int32 leftdays = (ts.Days - (week * 7));

                                                        lstrPostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                                    }
                                                    else
                                                        lstrPostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                                }
                                                else if (ts.Hours > 0)
                                                {
                                                    lstrPostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                                }
                                                else if (ts.Minutes > 0)
                                                {
                                                    lstrPostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                                }
                                                else lstrPostTime = "few seconds ago";

                                            }
                                            else
                                            {
                                                lstrPostTime = "-";
                                            }
                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Picture"])))
                                            {

                                                builder.Append("<li class=\"media\"><a href='#' class=\"pull-left\"><img style=\"width:50px;\" src=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Picture"]) + "\" class=\"img-circle\"></a>");
                                            }
                                            else
                                            {
                                                builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");


                                            }
                                            builder.Append("<div class=\"media-body\">");
                                            builder.Append("<p class=\"push-bit\">");
                                            builder.Append("<span class=\"text-muted pull-right\"><small>" + lstrPostTime + "</small>");
                                            builder.Append("<span class=\"text-danger\" data-toggle=\"tooltip\" title=\"From Web\"><i class=\"fa fa-globe\"></i></span>");
                                            builder.Append("</span>");
                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"])))
                                            {
                                                builder.Append("<strong><a  href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + ")\">" + Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"]) + "</a>" + " published a new story." + "</strong></p>");
                                                if (Session["UserID"] != null)
                                                {
                                                    string strLoggedInID = Session["UserID"].ToString();
                                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"])))
                                                    {
                                                        if (strLoggedInID != Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"]))
                                                        {
                                                            builder.Append("<a id=\"Message-a\"  title=\"Message user\" href=\"#modal-Send-Msg\" data-toggle=\"modal\" style=\"display:none;\"></a><a href='#'><i class=\"gi gi-envelope sidebar-nav-icon\" onclick=\"return showSendMsgModel(" + Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"]) + ",'" + Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"]) + "')\"></i></a></br>");

                                                        }

                                                    }


                                                }
                                            }
                                            else
                                            {
                                                builder.Append("<strong><a href=\"javascript:void(0)\">-</a>" + " published a new story." + "</strong></p>");

                                            }
                                            if (Convert.ToBoolean(ds.Tables[1].Rows[i]["IsUrl"]) == false)
                                            {
                                                if (Session["UserID"].ToString() == Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"]))
                                                {
                                                    builder.Append("<p id=\"p_posts\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "  " + "<a href='#' title=\"Delete Post\" onclick=\"return DeletePost(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + "," + ds.Tables[1].Rows[i]["PostID"].ToString() + ")\"><image style=\"width:20px;\" src=\"img/DeletePostComment.png\"></a></p>");
                                                }
                                                else
                                                {
                                                    builder.Append("<p id=\"p_posts\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</p>");
                                                }
                                            }
                                            else
                                            {
                                                if (Session["UserID"].ToString() == Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"]))
                                                {
                                                    if (Convert.ToString(ds.Tables[1].Rows[i]["Posts"]).IndexOf("http://") == -1)
                                                    {
                                                        if (Convert.ToString(ds.Tables[1].Rows[i]["Posts"]).IndexOf("https://") == -1)
                                                            builder.Append("<a class=\"pull-left\" target='_blank' href=\"http://" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a>" + "  " + "<a href='#' title=\"Delete Post\" onclick=\"return DeletePost(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + "," + ds.Tables[1].Rows[i]["PostID"].ToString() + ")\"><image style=\"width:20px;\" src=\"img/DeletePostComment.png\"></a></br>");
                                                        else
                                                            builder.Append("<a class=\"pull-left\" target='_blank' href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a>" + "  " + "<a href='#' title=\"Delete Post\" onclick=\"return DeletePost(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + "," + ds.Tables[1].Rows[i]["PostID"].ToString() + ")\"><image style=\"width:20px;\" src=\"img/DeletePostComment.png\"></a></br>");
                                               
                                                    }
                                                    else
                                                        builder.Append("<a class=\"pull-left\" target='_blank' href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a>" + "  " + "<a href='#' title=\"Delete Post\" onclick=\"return DeletePost(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + "," + ds.Tables[1].Rows[i]["PostID"].ToString() + ")\"><image style=\"width:20px;\" src=\"img/DeletePostComment.png\"></a></br>");
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(ds.Tables[1].Rows[i]["Posts"]).IndexOf("http://") == -1)
                                                    {
                                                        if (Convert.ToString(ds.Tables[1].Rows[i]["Posts"]).IndexOf("https://") == -1)
                                                            builder.Append("<a class=\"pull-left\" target='_blank' href=\"http://" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a></br>");
                                                        else
                                                            builder.Append("<a class=\"pull-left\" target='_blank' href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a>" + "  " + "<a href='#' title=\"Delete Post\" onclick=\"return DeletePost(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + "," + ds.Tables[1].Rows[i]["PostID"].ToString() + ")\"><image style=\"width:20px;\" src=\"img/DeletePostComment.png\"></a></br>");
                                               
                                                    }
                                                    else
                                                        builder.Append("<a class=\"pull-left\" target='_blank' href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a></br>");
                                                
                                                }
                                                  }
                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"])))
                                            {
                                                if (Convert.ToBoolean(ds.Tables[1].Rows[i]["IsYouTubeURL"]) == true)
                                                {
                                                    string VideoID = Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"]);
                                                    string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                                                    if (!string.IsNullOrEmpty(lastItemOfSplit))
                                                    {
                                                        builder.Append("<div id=\"divYoutubeVideo\">");
                                                       builder.Append("<iframe title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                                                        
                                                        
                                                        builder.Append("</div>");
                                                    }
                                                }
                                            }
                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["File"])))
                                            {
                                                if (Convert.ToString(ds.Tables[1].Rows[i]["File"]).Contains(","))
                                                {
                                                    splitImage = Convert.ToString(ds.Tables[1].Rows[i]["File"]).Split(',');
                                                    for (int j = 0; j < splitImage.Length; j++)
                                                    {
                                                        lstrImages = splitImage[j].Trim();
                                                        builder.Append("<a href=\" ../" + lstrImages + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + lstrImages + "\"></a>");

                                                    }
                                                }
                                                else
                                                {
                                                    builder.Append("<a href=\" ../" + Convert.ToString(ds.Tables[1].Rows[i]["File"]).Trim() + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + Convert.ToString(ds.Tables[1].Rows[i]["File"]).Trim() + "\"></a>");

                                                }

                                            }
                                            if (Convert.ToBoolean(ds.Tables[1].Rows[i]["PostLikeduserID"]) == true)
                                            {
                                                builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[1].Rows[i]["PostLikeCount"]) + "</span></p>");
                                            }
                                            else
                                            {

                                                builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[1].Rows[i]["PostLikeCount"]) + "</span></p>");
                                            }



                                            hasHeaderWritten = true;
                                        }
                                    }

                                    builder.Append("<ul class=\"media-list push\">");
                                    builder.Append("<li class=\"media\">");

                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["CommentTime"])))
                                    {
                                        DateTime inputDateTime = Convert.ToDateTime(ds.Tables[1].Rows[i]["CommentTime"]);
                                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[1].Rows[i]["CommentTime"]);

                                        if (ts.Days > 0)
                                        {
                                            if (ts.Days > 7)
                                            {
                                                Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                                Int32 leftdays = (ts.Days - (week * 7));

                                                lstrCommentTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                            }
                                            else
                                                lstrCommentTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                        }
                                        else if (ts.Hours > 0)
                                        {
                                            lstrCommentTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                        }
                                        else if (ts.Minutes > 0)
                                        {
                                            lstrCommentTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                        }
                                        else lstrCommentTime = "few seconds ago";

                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["SenderImage"])))
                                        {
                                            builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[1].Rows[i]["SenderImage"]) + "\"></a>");
                                        }
                                        else
                                        {
                                            builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");

                                        }

                                        builder.Append("<div class=\"media-body\">");
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["SenderName"])))
                                        {
                                            builder.Append("<a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[1].Rows[i]["SenderID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                            if (Session["UserID"] != null)
                                            {
                                                string strLoggedInID = Session["UserID"].ToString();
                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["SenderID"])))
                                                {
                                                    if (strLoggedInID != Convert.ToString(ds.Tables[1].Rows[i]["SenderID"]))
                                                    {
                                                        builder.Append("<br /><a id=\"Message-a\"  title=\"Message user\" href=\"#modal-Send-Msg\" data-toggle=\"modal\" onclick=\"return showSendMsgModel(" + Convert.ToString(ds.Tables[1].Rows[i]["SenderID"]) + ",'" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "')\"><i class=\"gi gi-envelope sidebar-nav-icon\"></i></a>");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            builder.Append("<a href=''><strong-</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                        }

                                        if (Session["UserID"].ToString() == Convert.ToString(ds.Tables[1].Rows[i]["SenderID"]))
                                        {
                                            builder.Append("<p>" + Convert.ToString(ds.Tables[1].Rows[i]["Comment"]) + "  " + "<a href='#' title=\"Delete Post\" onclick=\"return DeletePostComments(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + "," + ds.Tables[1].Rows[i]["PostCommentID"].ToString() + ")\"><image style=\"width:20px;\" src=\"img/DeletePostComment.png\"></a></p>");
                                        }
                                        else
                                        {
                                            builder.Append("<p>" + Convert.ToString(ds.Tables[1].Rows[i]["Comment"]) + "</p>");
                                        }
                                        builder.Append("</div>");
                                        builder.Append("</li>");

                                        builder.Append("<li class=\"media\"><a href=\"#\" class=\"pull-left\">");



                                    }
                                }

                            }
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[2].Rows[0]["UserPic"])))
                            {
                                builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[2].Rows[0]["UserPic"]) + "\"></a>");
                            }
                            else
                            {
                                builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                            }
                            builder.Append("<div class=\"media-body\">");
                            builder.Append("<form action=\"page_forms_components.html\" method=\"post\" onsubmit=\"return false;\">");
                            builder.Append("<textarea id=\"profile-newsfeed-comment" + Convert.ToInt32(dr[0]) + "\" name=\"profile-newsfeed-comment" + Convert.ToInt32(dr[0]) + "\" class=\"form-control\"  rows=\"2\" placeholder=\"Your comment..\"></textarea>");
                            builder.Append("<button type=\"submit\" class=\"btn btn-xs btn-primary\" onclick=\"return AddPostComments(" + Convert.ToInt32(dr[0]) + ");\"> <i class=\"fa fa-pencil\"></i>Post Comment</button>");
                            builder.Append("</form>");
                            builder.Append("</div>");
                            builder.Append("</li>");

                            builder.Append("</li>");
                            builder.Append("</ul>");
                            builder.Append("</div>");

                        }



                        builder.Append("</div>");
                    }


              }
                #endregion Advisors

                #region Users
                else
                {
                    builder.Append("<div class=\"block\" >");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        builder.Append("<div class=\"block-content-full\">");
                        builder.Append("<ul class=\"media-list media-feed media-feed-hover\">");
                        builder.Append("<li class=\"media\">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Title"])))
                        {

                            builder.Append("<div class=\"media-body\">");

                            if (ds.Tables[0].Rows[0]["TopicTime"] != null)
                            {
                                DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["TopicTime"]);
                                TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0]["TopicTime"]);

                                if (ts.Days > 0)
                                {
                                    if (ts.Days > 7)
                                    {
                                        Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                        Int32 leftdays = (ts.Days - (week * 7));

                                        lstrTopicTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                    }
                                    else
                                        lstrTopicTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                }
                                else if (ts.Hours > 0)
                                {
                                    lstrTopicTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                }
                                else if (ts.Minutes > 0)
                                {
                                    lstrTopicTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                }
                                else lstrTopicTime = "few seconds ago";

                            }

                            builder.Append("<p class=\"push-bit\"><span class=\"text-muted pull-right\">");
                           // builder.Append("Added by <a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[0]["UserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "</a><br>");
                            builder.Append("Added by <a style=\"text-decoration:none;\">" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "</a><br>");
                          
                            builder.Append("<small class=\"text-muted pull-right\">" + lstrTopicTime + "</small>");
                            builder.Append("<h4><a><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + "</strong></a></h4>");
                            builder.Append("</p>");
                            builder.Append("<Description>");
                            builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]) + "</p>");
                                //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TopicShareUserID"])))
                                //{
                                //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["LikeAndShareUserID"])))
                                //    {
                                //        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTopicShare"]) == true)
                                //        {
                                //            if (Convert.ToInt32(ds.Tables[0].Rows[0]["TopicShareUserID"]) == mdblUserID)
                                //            {
                                //                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" style=\"display:none;\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");
                                //            }
                                //            else
                                //            {
                                //                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");

                                //            }
                                //        }
                                //        else
                                //        {
                                //            builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");

                                //        }

                                //    }
                                //    else
                                //    {
                                //        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTopicShare"]) == true)
                                //        {
                                //            if (Convert.ToInt32(ds.Tables[0].Rows[0]["TopicShareUserID"]) == mdblUserID)
                                //            {
                                //                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" style=\"display:none;\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");
                                //            }
                                //            else
                                //            {
                                //                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");

                                //            }
                                //        }
                                //        else
                                //        {

                                //            builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\"  onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");
                                //        }
                                //    }

                                //}
                                //else
                                //{

                                //    builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='#' id=\"ShareTopic_" + lintTopicID + "\" class=\"btn btn-xs btn-default\" onclick=\"return shareOnFacebook('" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]).Replace("'", "#@#").Replace("\"", "#@#@") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]).Replace("'", "#@#").Replace("\"", "#@#@") + "'," + lintTopicID + ")\"><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");

                                //}

                                builder.Append("</Description>");

                             
                            }
                            builder.Append("</li>");
                            builder.Append("</ul>");
                            builder.Append("</div>");
                        }


                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataView dv = new DataView(ds.Tables[1]);
                            DataTable dt = dv.ToTable(true, "PostID");

                            builder.Append("<div class=\"block\">");
                            bool hasHeaderWritten = false;
                            foreach (DataRow dr in dt.Rows)
                            {
                                hasHeaderWritten = false;
                                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                                {
                                    Int32 lintPostID = Convert.ToInt32(ds.Tables[1].Rows[i]["PostID"]);
                                    if (Convert.ToInt32(dr[0]) == Convert.ToInt32(ds.Tables[1].Rows[i]["PostID"]))
                                    {

                                        if (!hasHeaderWritten)
                                        {
                                            builder.Append("<div class=\"block-content-full\">");
                                            builder.Append("<ul class=\"media-list media-feed media-feed-hover\"  style=\"min-height:300px;\">");
                                            builder.Append("<li class=\"media\">");

                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Posts"])))
                                            {
                                                if (ds.Tables[1].Rows[i]["PostTime"] != null)
                                                {
                                                    DateTime inputDateTime = Convert.ToDateTime(ds.Tables[1].Rows[i]["PostTime"]);
                                                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[1].Rows[i]["PostTime"]);

                                                    if (ts.Days > 0)
                                                    {
                                                        if (ts.Days > 7)
                                                        {
                                                            Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                                            Int32 leftdays = (ts.Days - (week * 7));

                                                            lstrPostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                                        }
                                                        else
                                                            lstrPostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                                    }
                                                    else if (ts.Hours > 0)
                                                    {
                                                        lstrPostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                                    }
                                                    else if (ts.Minutes > 0)
                                                    {
                                                        lstrPostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                                    }
                                                    else lstrPostTime = "few seconds ago";

                                                }
                                                else
                                                {
                                                    lstrPostTime = "-";
                                                }
                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Picture"])))
                                                {

                                                    builder.Append("<li class=\"media\"><a href='#' class=\"pull-left\"><img style=\"width:50px;\" src=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Picture"]) + "\" class=\"img-circle\"></a>");
                                                }
                                                else
                                                {
                                                    builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");


                                                }
                                                builder.Append("<div class=\"media-body\">");
                                                builder.Append("<p class=\"push-bit\">");
                                                builder.Append("<span class=\"text-muted pull-right\"><small>" + lstrPostTime + "</small>");
                                                builder.Append("<span class=\"text-danger\" data-toggle=\"tooltip\" title=\"From Web\"><i class=\"fa fa-globe\"></i></span>");
                                                builder.Append("</span>");
                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"])))
                                                {
                                                  //  builder.Append("<strong><a href='#modal-regular-Profile'  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + ds.Tables[1].Rows[i]["PostCreatorID"].ToString() + ")\">" + Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"]) + "</a>" + " published a new story." + "</strong></p>");
                                                    builder.Append("<strong><a style=\"text-decoration:none;\" >" + Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"]) + "</a>" + " published a new story." + "</strong></p>");
                                                    //if (Session["UserID"] != null)
                                                    //{
                                                    //    string strLoggedInID = Session["UserID"].ToString();
                                                    //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"])))
                                                    //    {
                                                    //        if (strLoggedInID != Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"]))
                                                    //        {
                                                    //            builder.Append("<a id=\"Message-a\"  title=\"Message user\" href=\"#modal-Send-Msg\" data-toggle=\"modal\" onclick=\"return showSendMsgModel(" + Convert.ToString(ds.Tables[1].Rows[i]["PostCreatorID"]) + ",'" + Convert.ToString(ds.Tables[1].Rows[i]["Full_Name"]) + "')\"><i class=\"gi gi-envelope sidebar-nav-icon\"></i></a></br>");

                                                    //        }

                                                    //    }


                                                    //}
                                                }
                                                else
                                                {
                                                    builder.Append("<strong><a href=\"javascript:void(0)\">-</a>" + " published a new story." + "</strong></p>");

                                                }
                                                if (Convert.ToBoolean(ds.Tables[1].Rows[i]["IsUrl"]) == false)
                                                {
                                                    builder.Append("<p id=\"p_posts\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</p></br>");
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(ds.Tables[1].Rows[i]["Posts"]).IndexOf("http://") == -1)
                                                        builder.Append("<a class=\"pull-left\" target='_blank' href=\"http://" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a></br>");
                                                    else
                                                        builder.Append("<a class=\"pull-left\" target='_blank' href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "\">" + Convert.ToString(ds.Tables[1].Rows[i]["Posts"]) + "</a></br>");
                                                }
                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"])))
                                                {
                                                    if (Convert.ToBoolean(ds.Tables[1].Rows[i]["IsYouTubeURL"]) == true)
                                                    {

                                                        string VideoID = Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"]);
                                                        string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                                                        if (!string.IsNullOrEmpty(lastItemOfSplit))
                                                        {
                                                            builder.Append("<div id=\"divYoutubeVideo\">");
                                                            builder.Append("<iframe title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                                                            builder.Append("</div>");
                                                        }



                                                    }
                                                }
                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["File"])))
                                                {
                                                    if (Convert.ToString(ds.Tables[1].Rows[i]["File"]).Contains(","))
                                                    {
                                                        splitImage = Convert.ToString(ds.Tables[1].Rows[i]["File"]).Split(',');
                                                        for (int j = 0; j < splitImage.Length; j++)
                                                        {
                                                            lstrImages = splitImage[j].Trim();
                                                            builder.Append("<a href=\" ../" + lstrImages + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + lstrImages + "\"></a></br>");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        builder.Append("<a href=\" ../" + Convert.ToString(ds.Tables[1].Rows[i]["File"]).Trim() + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + Convert.ToString(ds.Tables[1].Rows[i]["File"]).Trim() + "\"></a></br>");

                                                    }

                                                }
                                                //if (Convert.ToBoolean(ds.Tables[1].Rows[i]["PostLikeduserID"]) == true)
                                                //{
                                                //    builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[1].Rows[i]["PostLikeCount"]) + "</span></p>");
                                                //}
                                                //else
                                                //{

                                                //    builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[1].Rows[i]["PostLikeCount"]) + "</span></p>");
                                                //}



                                                hasHeaderWritten = true;
                                            }
                                        }

                                        builder.Append("<ul class=\"media-list push\">");
                                        builder.Append("<li class=\"media\">");

                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["CommentTime"])))
                                        {
                                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[1].Rows[i]["CommentTime"]);
                                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[1].Rows[i]["CommentTime"]);

                                            if (ts.Days > 0)
                                            {
                                                if (ts.Days > 7)
                                                {
                                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                                    Int32 leftdays = (ts.Days - (week * 7));

                                                    lstrCommentTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                                }
                                                else
                                                    lstrCommentTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                            }
                                            else if (ts.Hours > 0)
                                            {
                                                lstrCommentTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                            }
                                            else if (ts.Minutes > 0)
                                            {
                                                lstrCommentTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                            }
                                            else lstrCommentTime = "few seconds ago";

                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["SenderImage"])))
                                            {
                                                builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[1].Rows[i]["SenderImage"]) + "\"></a>");
                                            }
                                            else
                                            {
                                                builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");

                                            }

                                            builder.Append("<div class=\"media-body\">");
                                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["SenderName"])))
                                            {
                                              //  builder.Append("<a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[1].Rows[i]["SenderID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                                builder.Append("<a style=\"text-decoration:none;\"><strong>" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                                //if (Session["UserID"] != null)
                                                //{
                                                //    string strLoggedInID = Session["UserID"].ToString();
                                                //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["SenderID"])))
                                                //    {
                                                //        if (strLoggedInID != Convert.ToString(ds.Tables[1].Rows[i]["SenderID"]))
                                                //        {
                                                //            builder.Append("<br /><a id=\"Message-a\"  title=\"Message user\" href=\"#modal-Send-Msg\" data-toggle=\"modal\" onclick=\"return showSendMsgModel(" + Convert.ToString(ds.Tables[1].Rows[i]["SenderID"]) + ",'" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "')\"><i class=\"gi gi-envelope sidebar-nav-icon\"></i></a>");
                                                //        }
                                                //    }
                                                //}
                                            }
                                            else
                                            {
                                                builder.Append("<a href=''><strong-</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                            }
                                            builder.Append("<p>" + Convert.ToString(ds.Tables[1].Rows[i]["Comment"]) + "</p>");

                                            builder.Append("</div>");
                                            builder.Append("</li>");

                                            builder.Append("<li class=\"media\"><a href=\"#\" class=\"pull-left\">");



                                        }
                                    }

                                }
                             
                                builder.Append("</li>");

                                builder.Append("</li>");
                                builder.Append("</ul>");
                                builder.Append("</div>");

                            }



                            builder.Append("</div>");
                        }


                }

                #endregion Users

            }
        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }
    #endregion GetForumPostsListing

    #region DeleteSelectedPost
    /// <summary>
    /// Author:jasmeet kaur
    /// Date:041415
    /// Function used to delete selected post.
    /// </summary>
    private void DeleteSelectedPost()
    {
        Int32 lintPostID = -1;
        Int32 lintUserID = -1;

        try
        {
            if (Request.Form["UserID"] != null)
                lintUserID = Convert.ToInt32(Request.Form["UserID"]);
            if (Request.Form["PostID"] != null)
                lintPostID = Convert.ToInt32(Request.Form["PostID"]);
            //#A Jasmeet: 052514 - delete Category
            mobjCUser.DeleteSelectedPost(lintUserID, lintPostID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteSelectedPost

    #region DeletePostComments
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:041415
    /// Function used to delete comment.
    /// </summary>
    private void DeletePostComments()
    {
        Int32 lintPostCommentID = -1;
        Int32 lintUserID = -1;

        try
        {
            if (Request.Form["UserID"] != null)
                lintUserID = Convert.ToInt32(Request.Form["UserID"]);
            if (Request.Form["PostCommentID"] != null)
                lintPostCommentID = Convert.ToInt32(Request.Form["PostCommentID"]);
            //#A Jasmeet: 052514 - delete Category
            mobjCUser.DeletePostComments(lintUserID, lintPostCommentID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeletePostComments


    #region FillTopicComboFilter
    private void FillTopicComboFilter()
    {
        Int32 lintTopicID = -1;
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";
        if (Request.Form["TopicID"] != null)
        {
            lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);
        }

        try
        {

            lobjDS = mobjCUser.FillTopicCombo(lintTopicID);

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<TopicID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["TopicID"].ToString() + "]]>");
                    lobjBuilder.Append("</TopicID>");

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

    #endregion FillTopicComboFilter

    #region GetCategoryListing
    private void GetCategoryListing()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

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
            string PostTime = "";
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


                mobjCCommon.SetGridVariables(CConstants.enumTables.TblCategories.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetForumCategoryDetails(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostDate"])))
                        // if (ds.Tables[0].Rows[i]["LastPostDate"] != null)
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    PostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    PostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                PostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                PostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else PostTime = "few seconds ago";

                        }

                        else
                        {
                            PostTime = "-";
                        }
                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Category"])) || !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiv(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Category"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiv(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\"><strong>" + "-" + "</strong></a><br><small>" + "-" + "</small></h4></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Topics"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\"><a href=\"javascript:void(0)\">" + Convert.ToString(ds.Tables[0].Rows[i]["Topics"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\"><a href=\"javascript:void(0)\">" + "-" + "</a></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Posts"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\"><a href=\"javascript:void(0)\">" + Convert.ToString(ds.Tables[0].Rows[i]["Posts"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\"><a href=\"javascript:void(0)\">" + "-" + "</a></td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\">by <a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["LastPostUserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\"><a href='#modal-regular-Profile'>-</a></td>]]></cell>");

                        }
                        builder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        builder.Append("<div class=\"block-options\">");
                        builder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Category\" data-toggle=\"tooltip\" onclick=\"return DeleteCategory(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        builder.Append("<a href='#modal-Add-Category' title=\"Edit Category\" data-toggle=\"modal\" onclick=\"return showEditCategoryModel(" + ds.Tables[0].Rows[i]["CategoryID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        builder.Append("</div>");
                        builder.Append("</td>]]></cell>");
                        builder.Append(" </row>");
                    }

                }

                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetCategoryListing

    #region DeleteCategory
    private void DeleteCategory()
    {
        Int32 lintCategoryID = -1;

        try
        {
            if (Request.Form["CategoryID"] != null)
                lintCategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            //#A Jasmeet: 052514 - delete Category
            mobjCUser.DeleteCategory(lintCategoryID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteCategory

    #region AddCategory
    private void AddCategory()
    {
        Int32 lintCatgoryID = -1;
        string lstrTitle = "";
        string lstrDescription = "";


        try
        {
            if (Request.Form["CategoryID"] != null)
                lintCatgoryID = Convert.ToInt32(Request.Form["CategoryID"]);

            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["Description"] != null)
                lstrDescription = Convert.ToString(Request.Form["Description"]);

            //#A Jasmeet: 052814 - add category
            string lstr = mobjCUser.AddCategory(lintCatgoryID, lstrTitle, lstrDescription, mdblUserID);
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

    #endregion AddCategory

    #region GetCategoryDeatils
    private void GetCategoryDetails()
    {
        Int32 lintCategoryID = -1;

        StringBuilder builder = new StringBuilder("<Response><CategoryData>");
        try
        {
            if (Request.Form["CategoryID"] != null)
                lintCategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            //#A Jasmeet: 072514 - GetCategoryDetais

            DataSet ds = mobjCUser.GetCategoryDetails(lintCategoryID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</CategoryData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
        // mstrResponseData = builder.ToString();
    }

    #endregion GetCategoryDeatils

    #region GetTopicListing
    private void GetTopicListing()
    {
        try
        {
            Int32 lintCategoryID = -1;
            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;
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
            string PostTime = "";
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

                if (Request.QueryString["CategoryID"] != null)
                {
                    lintCategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                    mobjCCommon.CategoryID = lintCategoryID;
                    mobjCUser.CategoryID = lintCategoryID;
                }
                mobjCCommon.SetGridVariables(CConstants.enumTables.TblTopicList.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetTopicListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, lintCategoryID);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostDate"])))
                        //                   if (ds.Tables[0].Rows[i]["LastPostDate"] != null)
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["LastPostDate"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    PostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    PostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                PostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                PostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else PostTime = "few seconds ago";

                        }
                        else
                        {
                            PostTime = "-";
                        }

                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["TopicID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");


                        if (Convert.ToString(ds.Tables[0].Rows[i]["IsFlagged"]) == "True")
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Topic"])) || !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                            {
                                builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiscussionList(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ")\"><strong>" + "" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");
                            }
                            else
                            {
                                builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiscussionList(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ")\"><strong>" + "" + "-" + "</strong></a><br><small>" + "-" + "</small></h4></td>]]></cell>");
                            }
                        }
                        else
                        {

                            builder.Append("<cell><![CDATA[<td class=\"text-center\"><h4><a href='#' onclick=\"return ShowTopicDiscussionList(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "</strong></a><br><small>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</small></h4></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Replies"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\"><a href=\"javascript:void(0)\">" + Convert.ToString(ds.Tables[0].Rows[i]["Replies"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\"><a href=\"javascript:void(0)\">" + "0" + "</a></td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["TopicView"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\"><a href=\"javascript:void(0)\">" + Convert.ToString(ds.Tables[0].Rows[i]["TopicView"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\"><a href=\"javascript:void(0)\">" + "0" + "</a></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\" style=\"text-align:center;\">by <a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["LastPostUserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[i]["LastPostUser"]) + "</a><br><small>" + PostTime + "</small></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"hidden-xs hidden-sm\" style=\"text-align:center;\"><a href='#modal-regular-Profile'>-</a></td>]]></cell>");
                        }
                        builder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        builder.Append("<div class=\"block-options\">");
                        builder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Topic\" data-toggle=\"tooltip\" onclick=\"return DeleteTopic(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                       // builder.Append("<a href='#modal-Add-Topic' title=\"Edit Topic\" data-toggle=\"modal\" onclick=\"return showEditTopicModel(" + ds.Tables[0].Rows[i]["TopicID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        builder.Append("</div>");
                        builder.Append("</td>]]></cell>");
                        builder.Append(" </row>");
                    }

                }


                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetTopicListing

    #region DeleteTopic

    private void DeleteTopic()
    {
        Int32 lintTopicID = -1;

        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);
            //#A Jasmeet: 072814 - delete topic
            mobjCUser.DeleteTopic(lintTopicID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteTopic

    #region GetTopicDetails
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:072814
    /// Function used to get topic details
    /// </summary>
    private void GetTopicDetails()
    {
        Int32 lintTopicID = -1;

        StringBuilder builder = new StringBuilder("<Response><TopicData>");
        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);
            //#A Jasmeet: 072814 - GetTopicDetais

            DataSet ds = mobjCUser.GetTopicDetails(lintTopicID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

                builder.Append("<CategoryID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["CategoryID"]));
                builder.Append("]]></CategoryID>");

                builder.Append("<IsFlagged><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["IsFlagged"]));
                builder.Append("]]></IsFlagged>");
            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</TopicData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;

    }

    #endregion GetTopicDeatils

    #region AddNewTopic
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:072814
    /// Function used to add new topic.
    /// </summary>
    private void AddNewTopic()
    {
        string lstrTitle = "";
        string lstrDescription = "";
        Int32 lintCategoryID = -1;
        Int32 lintTopicID = -1;
        bool lblnIsFlagged = false;
        try
        {

         
            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["description"] != null)
                lstrDescription = Convert.ToString(Request.Form["description"]);

            if (Request.Form["CategoryID"] != null)
                lintCategoryID = Convert.ToInt32(Request.Form["CategoryID"]);

            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["IsFlagged"] != null)
                lblnIsFlagged = Convert.ToBoolean(Request.Form["IsFlagged"]);



            string lstr = mobjCUser.AddNewTopic(lstrTitle, lstrDescription, lintCategoryID, lintTopicID, lblnIsFlagged, mdblUserID);
            //string lstr = mobjCUser.AddNewTopic(lstrTitle, lstrDescription, lintCategoryID, lintTopicID);
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
            mstrResponseData = "Error: " + ex.Message;
        }
    }

    #endregion AddNewTopic

    #region LikePosts
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:072814
    /// Function used to like topic
    /// </summary>
    private void LikePosts()
    {
        Int32 lintTopicID = -1;
        Int32 lintPostID = -1;
        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["PostID"] != null)
                lintPostID = Convert.ToInt32(Request.Form["PostID"]);

            mobjCUser.LikePosts(mdblUserID, lintTopicID, lintPostID);
            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion LikePosts

    #region PostTopicComments
    private void PostTopicComments()
    {
        string lstrComments = "";
        Int32 lintTopicID = -1;
        Int32 lintCategoryID = -1;
        string lstrImages = "";
        bool lblIsUrl = false;

        try
        {
            if (Request.Form["Content"] != null)
                lstrComments = Convert.ToString(Request.Form["Content"]);

            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["CategoryID"] != null)
                lintCategoryID = Convert.ToInt32(Request.Form["CategoryID"]);

            if (Request.Form["Images"] != null)
                lstrImages = Convert.ToString(Request.Form["Images"]);

            if (Request.Form["IsUrl"] != null)
                lblIsUrl = Convert.ToBoolean(Request.Form["IsUrl"]);



            Int32 PostID = mobjCUser.PostTopicComments(lstrComments, lintTopicID, lintCategoryID, mdblUserID, lblIsUrl);

            if (PostID != -1)
            {
                string[] imagesArr = lstrImages.Split(',');

                if (imagesArr.Length > 0)
                {
                    // for (int i = 0; i < imagesArr.Length; i++)
                    foreach (string str in imagesArr)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            string lstrResult = mobjCUser.AddPostImages(str, PostID);
                        }
                    }
                }

            }


            mstrResponseData = "SUCCESS";

        }
        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }
    }

    #endregion PostTopicComments

    #region AddPostComments
    private void AddPostComments()
    {
        string lstrComments = "";
        Int32 lintPostID = -1;

        try
        {
            if (Request.Form["Comment"] != null)
                lstrComments = Convert.ToString(Request.Form["Comment"]);

            if (Request.Form["PostID"] != null)
                lintPostID = Convert.ToInt32(Request.Form["PostID"]);

            string lstr = mobjCUser.AddPostComments(lstrComments, lintPostID, mdblUserID);

            mstrResponseData = "SUCCESS";

        }
        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }
    }

    #endregion AddPostComments

    #region GetTopicViewCount

    private void GetTopicViewCount()
    {
        Int32 lintTopicID = -1;

        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);
            //#A Jasmeet: 052514 - delete Category
            mobjCUser.GetTopicViewCount(lintTopicID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion GetTopicViewCount

    #region SendMessage
    private void SendMessage()
    {
        Int32 lintRecevierID = -1;
        string lstrMessage = "";
        Int32 lintSenderID = -1;


        try
        {
            if (Request.Form["RecevierID"] != null)
                lintRecevierID = Convert.ToInt32(Request.Form["RecevierID"]);

            if (Request.Form["Message"] != null)
                lstrMessage = Convert.ToString(Request.Form["Message"]);

            if (Session["UserID"] != null)
                lintSenderID = Convert.ToInt32(Session["UserID"]);


            //#A Sahil: 081014 - Sending message to the user
            mobjCUser.SendMessage(lintSenderID, lintRecevierID, lstrMessage);

            mstrResponseData = "SUCCESS";

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion AddCategory

    #region GetSenderNameList
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:081114
    /// Function used to get sender's name.
    /// </summary>
    private void GetSenderNameList()
    {

        Int32 lintMsgsenderID = -1;
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.GetSenderNameList(mdblUserID);

            if (ds != null)
            {
                string MessageTime = string.Empty;
                builder.Append("<ul class=\"nav nav-pills nav-stacked\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (mdblUserID == Convert.ToInt32(ds.Tables[0].Rows[i]["ReceiverID"]))
                    {
                        lintMsgsenderID = Convert.ToInt32(ds.Tables[0].Rows[i]["SenderID"]);
                    }
                    else
                    {
                        lintMsgsenderID = Convert.ToInt32(ds.Tables[0].Rows[i]["ReceiverID"]);
                    }
                    builder.Append("<li id=\"li_" + lintMsgsenderID + "\">");
                    builder.Append("<a href=\"javascript:void(0)\" onclick=\"return GetMessages(" + lintMsgsenderID + ")\">");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UnreadMsg"])))
                    {
                        builder.Append(" <span id=\"From_" + lintMsgsenderID + "\" class=\"badge pull-right\">" + ds.Tables[0].Rows[i]["UnreadMsg"].ToString() + "</span>");
                    }
                    else
                    {
                        builder.Append("<span class=\"badge pull-right\">" + "0" + "</span>");
                    }

                    builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Sender"]) + "</strong>");

                    builder.Append("</a>");
                    builder.Append("</li>");

                }
                builder.Append("</ul>");
            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No sender Found</div>");

            }


        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetSenderNameList

    #region GetMessages
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:081114
    /// Function used to get message list.
    /// </summary>
    private void GetMessageList()
    {
        Int32 lintSenderID = -1;
        StringBuilder builder = new StringBuilder();
        try
        {
            if (mdblUserID == Convert.ToInt32(Request.Form["ReceiverID"]))
            {

                lintSenderID = Convert.ToInt32(Request.Form["SenderID"]);
            }
            else if (Request.Form["ReceiverID"] != null)
            {
                lintSenderID = Convert.ToInt32(Request.Form["ReceiverID"]);
            }

            DataSet ds = mobjCUser.GetMessageList(mdblUserID, lintSenderID);

            if (ds != null)
            {
                string MessageTime = string.Empty;
                string ReceiverSendTime = string.Empty;
                builder.Append("<div class=\"media-list push\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["DateAndTime"] != null)
                    {
                        DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAndTime"]);
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAndTime"]);
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

                    builder.Append("<li class=\"media\">");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["SenderPic"])))
                    {
                        builder.Append("<a href='' class=\"pull-left\"><img style=\"width:50px;\" src=" + Convert.ToString(ds.Tables[0].Rows[i]["SenderPic"]) + "\" class=\"img-circle\"></a>");
                    }
                    else
                    {
                        builder.Append("<a href='' class=\"pull-left\"><image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                    }
                    builder.Append("<div class=\"media-body\">");
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["ReceiverID"]) == mdblUserID)
                    {
                        builder.Append("<a href='#modal-regular-Profile' style=\"color:black;\"  data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["SenderID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Sender"]) + "</strong></a>");
                    }
                    else
                    {
                        builder.Append("<a href='#modal-regular-Profile'  data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["SenderID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Sender"]) + "</strong></a>");

                    }

                   
                    builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[i]["Message"]) + "</p>");
                    builder.Append("<span class=\"text-muted\"><small><em>" + MessageTime + "</em></small></span>");
                    builder.Append("</div>");
                    builder.Append("</li>");

                }
                builder.Append("</ul>");

                if (ds.Tables[1].Rows[0] != null)
                {
               
                    builder.Append("<a href=\"page_ready_user_profile.html\" class=\"pull-left\">");
                    //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["Picture"])))
                    //{
                    //    builder.Append("<a href='' class=\"pull-left\"><img style=\"width:50px;\" src=\"" + Convert.ToString(ds.Tables[1].Rows[0]["Picture"]) + "\" class=\"img-circle\"></a>");
                    //}
                    //else
                    //{
                    //    builder.Append("<a href='' class=\"pull-left\"><image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                    //}
                    builder.Append("</a>");
                    builder.Append("<div class=\"chat-conversation-footer\">");
                    builder.Append("<form action=\"page_ready_user_profile.html\" method=\"post\" onSubmit=\"return false;\">");
                    builder.Append("<textarea id=\"profile-newsfeed-comment1\" name=\"profile-newsfeed-comment1\" class=\"form-control\" rows=\"2\" placeholder=\"Your comment..\"></textarea>");
                    builder.Append("<button type=\"submit\" class=\"chat-send\" onclick=\"return PostMessageToUser();\"><i class=\"fa fa-paper-plane\"></i>" + "" + "</button>");
                    builder.Append("</form>");
                    builder.Append("</div>");
                   
                }
               
            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No message Found</div>");

            }


        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetMessages

    #region PostMessageToUser
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:081214
    /// Function used to send message to user
    /// </summary>
    private void PostMessageToUser()
    {
        string lstrMessage = "";
        Int32 lintReceiverID = -1;


        try
        {

            if (Request.Form["Message"] != null)
                lstrMessage = Convert.ToString(Request.Form["Message"]);

            if (Request.Form["ReceiverID"] != null)
                lintReceiverID = Convert.ToInt32(Request.Form["ReceiverID"]);
            //#A Jasmeet Kaur: 081214 - post message to the user
            mobjCUser.PostMessageToUser(lintReceiverID, mdblUserID, lstrMessage);

            mstrResponseData = "SUCCESS";

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion PostMessageToUser

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
            builder.Append("<div class=\"block-title\">");
            builder.Append("<div class=\"block-options pull-right\">");
            builder.Append("<a href='#divProfileForm' class=\"btn btn-sm btn-alt btn-default\" data-toggle=\"tooltip\" title=\"Edit Profile\" onClick=\"return showEditProfileDiv();\"><i class=\"fa fa-pencil\"></i></a>");
            builder.Append("</div>");
            builder.Append("<h2><strong>About</strong>" + "  " + Convert.ToString(lobjds.Tables[0].Rows[0]["Full_Name"]) + "</h2></div>");
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
                    builder.Append("," + Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line2"]));
                if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line3"])))
                    builder.Append("," + Convert.ToString(lobjds.Tables[0].Rows[0]["Address_line3"]));
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

        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetUserDetails

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

  

    #region UnlikePosts
    /// <summary>
    /// Author:jasmeet kaur
    /// Date:081814
    /// Function used to unlike the liked post
    /// </summary>
    private void UnlikePosts()
    {
        Int32 lintTopicID = -1;
        Int32 lintPostID = -1;
        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["PostID"] != null)
                lintPostID = Convert.ToInt32(Request.Form["PostID"]);

            mobjCUser.UnlikePosts(mdblUserID, lintTopicID, lintPostID);
            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion UnlikePosts

    #region GetPostsList
    /// <summary>
    /// Author:Jasmeet Kaur
    /// date:081914
    /// Function used to get post list of selected post id.
    /// </summary>
    private void GetPostsList()
    {

        Int32 lintPostID = -1;
        string lstrPostTime = "";
        string lstrCommentTime = "";
        string lstrImages = "";
        string[] splitImage = new string[20];
        StringBuilder builder = new StringBuilder();
        if (Request.Form["PostID"] != null)
        {
            lintPostID = Convert.ToInt32(Request.Form["PostID"]);
        }

        try
        {

            DataSet ds = mobjCUser.GetPostsList(lintPostID);

            if (ds != null)
            {
                builder.Append("<div class=\"block\">");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    DataTable dt = dv.ToTable(true, "PostID");
                    // DataSet tempDS = ds.Tables[1].Select()

                    //builder.Append("<div class=\"block\">");
                    bool hasHeaderWritten = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        hasHeaderWritten = false;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            lintPostID = Convert.ToInt32(ds.Tables[0].Rows[i]["PostID"]);
                            if (Convert.ToInt32(dr[0]) == Convert.ToInt32(ds.Tables[0].Rows[i]["PostID"]))
                            {

                                if (!hasHeaderWritten)
                                {
                                    builder.Append("<div class=\"block-content-full\">");
                                    builder.Append("<ul class=\"media-list media-feed media-feed-hover\">");
                                    builder.Append("<li class=\"media\">");

                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Post"])))
                                    {
                                        if (ds.Tables[0].Rows[i]["PostTime"] != null)
                                        {
                                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["PostTime"]);
                                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["PostTime"]);

                                            if (ts.Days > 0)
                                            {
                                                if (ts.Days > 7)
                                                {
                                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                                    Int32 leftdays = (ts.Days - (week * 7));

                                                    lstrPostTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                                }
                                                else
                                                    lstrPostTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                            }
                                            else if (ts.Hours > 0)
                                            {
                                                lstrPostTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                            }
                                            else if (ts.Minutes > 0)
                                            {
                                                lstrPostTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                            }
                                            else lstrPostTime = "few seconds ago";

                                        }
                                        else
                                        {
                                            lstrPostTime = "-";
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["PostSenderPic"])))
                                        {
                                            builder.Append("<li class=\"media\"><a href='#' class=\"pull-left\"><img style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[i]["PostSenderPic"]) + "\" class=\"img-circle\"></a>");
                                        }
                                        else
                                        {
                                            builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");


                                        }
                                        builder.Append("<div class=\"media-body\">");
                                        builder.Append("<p class=\"push-bit\">");
                                        builder.Append("<span class=\"text-muted pull-right\"><small>" + lstrPostTime + "</small>");
                                        builder.Append("<span class=\"text-danger\" data-toggle=\"tooltip\" title=\"From Web\"><i class=\"fa fa-globe\"></i></span>");
                                        builder.Append("</span>");
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["CommentSenderName"])))
                                        {
                                            builder.Append("<strong><a href=\"javascript:void(0)\">" + Convert.ToString(ds.Tables[0].Rows[i]["CommentSenderName"]) + "</a>" + " published a new story." + "</strong></p>");

                                        }
                                        else
                                        {
                                            builder.Append("<strong><a href=\"javascript:void(0)\">-</a>" + " published a new story." + "</strong></p>");

                                        }

                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Post"])))
                                        {
                                            builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[i]["Post"]) + "</p>");
                                        }
                                        else
                                        {
                                            builder.Append("<p>-</p>");
                                        }

                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["File"])))
                                        {
                                            if (Convert.ToString(ds.Tables[0].Rows[i]["File"]).Contains(","))
                                            {
                                                splitImage = Convert.ToString(ds.Tables[0].Rows[i]["File"]).Split(',');
                                                for (int j = 0; j < splitImage.Length; j++)
                                                {
                                                    lstrImages = splitImage[j].Trim();
                                                    builder.Append("<a href=\" ../" + lstrImages + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + lstrImages + "\"></a>");

                                                }
                                            }
                                            else
                                            {
                                                builder.Append("<a href=\" ../" + Convert.ToString(ds.Tables[0].Rows[i]["File"]).Trim() + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + Convert.ToString(ds.Tables[0].Rows[i]["File"]).Trim() + "\"></a>");

                                            }

                                        }

                                        hasHeaderWritten = true;
                                    }
                                }

                                //builder.Append("<Posts>");
                                builder.Append("<ul class=\"media-list push\">");
                                builder.Append("<li class=\"media\">");

                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["CommentTime"])))
                                //if (ds.Tables[0].Rows[i]["CommentTime"] != null)
                                {
                                    DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["CommentTime"]);
                                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["CommentTime"]);

                                    if (ts.Days > 0)
                                    {
                                        if (ts.Days > 7)
                                        {
                                            Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                            Int32 leftdays = (ts.Days - (week * 7));

                                            lstrCommentTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                        }
                                        else
                                            lstrCommentTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                    }
                                    else if (ts.Hours > 0)
                                    {
                                        lstrCommentTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                    }
                                    else if (ts.Minutes > 0)
                                    {
                                        lstrCommentTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                    }
                                    else lstrCommentTime = "few seconds ago";

                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["CommentSenderPic"])))
                                    {
                                        builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[i]["CommentSenderPic"]) + "\"></a>");
                                    }
                                    else
                                    {
                                        builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");

                                    }

                                    builder.Append("<div class=\"media-body\">");
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["CommentSenderName"])))
                                    {
                                        builder.Append("<a href=''><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["CommentSenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                        //  builder.Append("<a href=''><strong>" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>" + " " + "<a href=''><image style=\"width:20px;\" src=\"img/like.png\"></a>");
                                    }
                                    else
                                    {
                                        builder.Append("<a href=''><strong-</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                    }
                                    builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[i]["Comment"]) + "</p>");

                                    builder.Append("</div>");
                                    builder.Append("</li>");
                                    builder.Append("</ul>");
                                    //builder.Append("<li class=\"media\"><a href=\"#\" class=\"pull-left\">");



                                }
                            }

                        }

                        builder.Append("</li>");

                        //builder.Append("</li>");
                        builder.Append("</ul>");
                        //builder.Append("</div>");


                        // builder.Append("</ul>");

                    }



                    builder.Append("</div>");
                }


            }

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetPostsList

    #region GetUsersListing
 
    private void GetUsersListing()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<rows>");

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

                mobjCCommon.SetGridVariables(CConstants.enumTables.TblUsers.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");

                // Function to get users listing.               
                lobjDS = mobjCUser.GetUsersListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"]) + "\"></td>]]></cell>");

                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"" + "../img/AnonymousGuyPic.jpg" + "\"></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            //onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\"
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + "-" + "</a></td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"]) + "</td>]]></cell>");
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
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["UserType"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["UserType"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Occupation"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Occupation"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        if (Convert.ToString(lobjDS.Tables[0].Rows[i]["IsUserLoginDisabled"]) == "False" || string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["IsUserLoginDisabled"])))
                        {
                            stringBuilder.Append("<img src=\"../img/Inactive.png\"  title=\"Click to mark as disbaled.\" style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" onclick=\"return MarkUserDisable(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ",'" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "','false')\" />");
                        }
                        else
                        {
                            stringBuilder.Append("<img src=\"../img/active.png\" title=\"Click to mark as enabled.\" style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" onclick=\"return MarkUserDisable(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ",'" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "','true')\" />");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["RssUserID"])))
                        {
                            stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/Rss.png\" onclick=\"return ViewUsersRssFeed(" + lobjDS.Tables[0].Rows[i]["RssUserID"].ToString() + ")\"></a>");
                        }
                        else
                        {
                            stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\" style=\"display:none;\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/Rss.png\"></a>");

                        }
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

    #endregion GetUsersListing


    #region CompGetUsersListing

    private void CompGetUsersListing()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<rows>");

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

                mobjCCommon.SetGridVariables("CompUsers", ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");

                // Function to get users listing.               
                lobjDS = mobjCUser.CompanyGetUsersListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString,OfCompID.ToString());

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"]) + "\"></td>]]></cell>");

                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"" + "../img/AnonymousGuyPic.jpg" + "\"></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            //onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\"
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + "-" + "</a></td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"]) + "</td>]]></cell>");
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
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["UserType"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["UserType"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Occupation"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Occupation"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        if (Convert.ToString(lobjDS.Tables[0].Rows[i]["IsUserLoginDisabled"]) == "False" || string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["IsUserLoginDisabled"])))
                        {
                            stringBuilder.Append("<img src=\"../img/Inactive.png\"  title=\"Click to mark as disbaled.\" style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" onclick=\"return MarkUserDisable(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ",'" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "','false')\" />");
                        }
                        else
                        {
                            stringBuilder.Append("<img src=\"../img/active.png\" title=\"Click to mark as enabled.\" style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" onclick=\"return MarkUserDisable(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ",'" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "','true')\" />");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["RssUserID"])))
                        {
                            stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/Rss.png\" onclick=\"return ViewUsersRssFeed(" + lobjDS.Tables[0].Rows[i]["RssUserID"].ToString() + ")\"></a>");
                        }
                        else
                        {
                            stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\" style=\"display:none;\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/Rss.png\"></a>");

                        }
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

    #endregion CompGetUsersListing

    #region ViewUserProfile
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:082414
    /// Function used to view user profile
    /// </summary>
    private void ViewUserProfile()
    {
        Int32 lintUserID = -1;
        DataSet ds = new DataSet();
        StringBuilder builder = new StringBuilder("<Response><UserData>");
        try
        {
            if (Request.Form["UserID"] != null)
                lintUserID = Convert.ToInt32(Request.Form["UserID"]);


            ds = mobjCUser.ViewUserProfile(lintUserID);

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
                    builder.Append("<image style=\"width:100px;\" src=\"" + Convert.ToString(ds.Tables[0].Rows[0]["Picture"]) + "\">");
                }
                else
                {
                    builder.Append("<image style=\"width:100px;\" src=\"../img/AnonymousGuyPic.jpg\">");
                }
                builder.Append("]]></Picture>");

                builder.Append("<EMail><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["EMail"]));
                builder.Append("]]></EMail>");

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

                builder.Append("<Address_Line3><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line3"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_Line3"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Address_Line3>");

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

                builder.Append("<Organization><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Organization"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Organization"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Organization>");

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
                builder.Append("<Occupation><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OccupationID"])))
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["OccupationID"]) == 7)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OtherOccupation"])))
                        {
                            builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["OtherOccupation"]));
                        }
                        else
                        {
                            builder.Append("-");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Occupation"])))
                        {
                            builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Occupation"]));
                        }
                        else
                        {
                            builder.Append("-");
                        }
                    }
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Occupation>");

                builder.Append("<DealerName><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DealerName"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["DealerName"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></DealerName>");

                builder.Append("<MGA><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MGA"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["MGA"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></MGA>");

                builder.Append("<GoverningBody><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["GoverningBody"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["GoverningBody"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></GoverningBody>");

               
                builder.Append("<InBusinessSince><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["InBusinessSince"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["InBusinessSince"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></InBusinessSince>");

                builder.Append("<ProfileYoutubeURL><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ProfileYoutubeURL"])))
                {
                    string VideoID = Convert.ToString(ds.Tables[0].Rows[0]["ProfileYoutubeURL"]);
                    string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                    if (!string.IsNullOrEmpty(lastItemOfSplit))
                    {
                        builder.Append("<div id=\"divYoutubeVideo\">");
                        builder.Append("<iframe id=\"iframevideo\" title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                        builder.Append("</div>");
                    }
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></ProfileYoutubeURL>");

                builder.Append("<AboutMe><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AboutMe"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["AboutMe"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></AboutMe>");

                builder.Append("<Designation><![CDATA[");
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["designation"])))
                {
                    builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["designation"]));
                }
                else
                {
                    builder.Append("-");
                }
                builder.Append("]]></Designation>");
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

    #endregion ViewUserProfile

    #region MarkUserDisable
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:082714
    /// Function used to mark user disable for login.
    /// </summary>
    private void MarkUserDisable()
    {
        try
        {
            double ldblUserID = -1;
            if (Request.Form["UserId"] != null)
                ldblUserID = Convert.ToDouble(Request.Form["UserId"]);

            mobjCUser.MarkUserDisable(ldblUserID);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        mstrResponseData = "Success";
    }

    #endregion MarkUserDisable



    #region GetEventAlert
  
    private void GetEventAlert()
    {
       // string NotificationTime = "";
        // bool IsNotificationForm = true;
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.GetEventAlert(mdblUserID);


            if (ds != null)
            {
                String v = ds.Tables[1].Rows[0][0] + "##";
                builder.Append(ds.Tables[1].Rows[0][0] + "##");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                 //builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Post"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "', " + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");
                    builder.Append("<a href=\"CalendarEvents.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "\" class=\"list-group-item\"> <strong> " + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong><br /> <small class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["StartDateTime"]) + "</small> </a>");
                
                }


            }

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetEventAlert



    #region GetAllAlert

    private void GetAllAlert()
    {
        // string NotificationTime = "";
        // bool IsNotificationForm = true;
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.GetAllAlert(mdblUserID);


            if (ds != null)
            {
                String v = ds.Tables[1].Rows[0][0] + "##";
                builder.Append(ds.Tables[1].Rows[0][0] + "##");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[i]["PageRedirection"]) == "../Pricing.aspx")
                    {
                        //builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Post"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "', " + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");
                        builder.Append("<a target=\"_blank\" href=\"" + Convert.ToString(ds.Tables[0].Rows[i]["PageRedirection"]) + "\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "\" class=\"list-group-item\"> <strong> " + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong><br /> <small class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["StartDate"]) + "</small> </a>");
                    }
                    else {
                        builder.Append("<a href=\"" + Convert.ToString(ds.Tables[0].Rows[i]["PageRedirection"]) + "\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "\" class=\"list-group-item\"> <strong> " + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong><br /> <small class=\"text-muted\">" + Convert.ToString(ds.Tables[0].Rows[i]["StartDate"]) + "</small> </a>");
                    }

                }


            }

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetAllAlert


    #region GetAllNotifications
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:082814
    /// Function used to get notifications.
    /// </summary>
    private void GetAllNotifications()
    {
        string NotificationTime = "";
        // bool IsNotificationForm = true;
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.GetAllNotifications(mdblUserID);


            if (ds != null)
            {
                builder.Append(ds.Tables[1].Rows[0][0] + "##");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["DateAndTime"])))
                    {
                        DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAndTime"]);
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAndTime"]);

                        if (ts.Days > 0)
                        {
                            if (ts.Days > 7)
                            {
                                Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                Int32 leftdays = (ts.Days - (week * 7));

                                NotificationTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                            }
                            else
                                NotificationTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                        }
                        else if (ts.Hours > 0)
                        {
                            NotificationTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                        }
                        else if (ts.Minutes > 0)
                        {
                            NotificationTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                        }
                        else NotificationTime = "few seconds ago";

                    }

                    else
                    {
                        NotificationTime = "-";
                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Post")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Post"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "', " + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Video")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["YouTubeURL"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "', " + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Like")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["LikedPost"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "', " + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Comment")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Comment"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "', " + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Message")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "'," + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"gi gi-envelope\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Authorize")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href=\"Notification.aspx\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "\" style=\"text-decoration:none;\" onclick=\"return ViewNotifications(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"]) + "'," + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ")\"><small>" + NotificationTime + "</small><br><i class=\"gi gi-envelope\"></i>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</a></div>");

                    }
                    
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "Topic")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href='#' data-toggle=\"tooltip\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "\" style=\"text-decoration:none;\"  onclick=\"return ShowTopicNotification(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["Topic"]) + "'," + ds.Tables[0].Rows[i]["LikedTopicCategoryID"].ToString() + "," + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ");\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "TopicLike")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href='#' data-toggle=\"tooltip\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["LikedTopic"]) + "\" style=\"text-decoration:none;\"  onclick=\"return ShowTopicNotification(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["LikedTopic"]) + "'," + ds.Tables[0].Rows[i]["LikedTopicCategoryID"].ToString() + "," + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ");\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }
                    if ((Convert.ToString(ds.Tables[0].Rows[i]["NotificationType"])) == "TopicShare")
                    {
                        builder.Append("<div class=\"alert alert-success alert-alt\"><a href='#' data-toggle=\"tooltip\" title=\"" + Convert.ToString(ds.Tables[0].Rows[i]["LikedTopic"]) + "\" style=\"text-decoration:none;\"  onclick=\"return ShowTopicNotification(" + ds.Tables[0].Rows[i]["ReferenceID"].ToString() + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["LikedTopic"]) + "'," + ds.Tables[0].Rows[i]["LikedTopicCategoryID"].ToString() + "," + ds.Tables[0].Rows[i]["NotificationID"].ToString() + ");\"><small>" + NotificationTime + "</small><br><i class=\"fa fa-arrow-up fa-fw\"></i>" + "  " + string.Format(Convert.ToString(ds.Tables[0].Rows[i]["Title"]), Convert.ToString(ds.Tables[0].Rows[i]["LoggedInUser"])) + "</a></div>");

                    }

                }


            }

        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetAllNotifications

    #region ViewNotifications
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:082914
    /// Function used to view notifications
    /// </summary>
    private void ViewNotifications()
    {
        Int32 lintReferenceID = -1;
        Int32 lintNotificationID = -1;
        string lstrNotificationType = "";
        string lstrTitleTime = "";
        string lstrImages = "";
        Int32 lintPostID = -1;
        Int32 lintTopicID = -1;
        string lstrCommentTime = "";
        Int32 lintSendMsgToUserID = -1;
        string lstrTopicTime = "";
        string[] splitImage = new string[20];
        StringBuilder builder = new StringBuilder();
        if (Request.Form["ReferenceID"] != null)
        {
            lintReferenceID = Convert.ToInt32(Request.Form["ReferenceID"]);
        }
        if (Request.Form["NotificationType"] != null)
        {
            lstrNotificationType = Convert.ToString(Request.Form["NotificationType"]);
        }
        if (Request.Form["NotificationID"] != null)
        {
            lintNotificationID = Convert.ToInt32(Request.Form["NotificationID"]);
        }

        try
        {

            DataSet ds = mobjCUser.ViewNotifications(lintReferenceID, lstrNotificationType, mdblUserID, lintNotificationID);

            if (ds != null)
            {
                #region Post,Comment,Like,Video

                if (lstrNotificationType == "Post" || lstrNotificationType == "Comment" || lstrNotificationType == "Like" || lstrNotificationType == "Video")
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    DataTable dt = dv.ToTable(true, "PostID");
                    lintPostID = Convert.ToInt32(ds.Tables[0].Rows[0]["PostID"]);
                    lintTopicID = Convert.ToInt32(ds.Tables[0].Rows[0]["TopicID"]);
                    builder.Append("<div class=\"block\">");

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (ds.Tables[0].Rows[0]["NotificationTime"] != null)
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["NotificationTime"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0]["NotificationTime"]);

                            if (ts.Days > 0)
                            {
                                if (ts.Days > 7)
                                {
                                    Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                    Int32 leftdays = (ts.Days - (week * 7));

                                    lstrTitleTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                }
                                else
                                    lstrTitleTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                            }
                            else if (ts.Hours > 0)
                            {
                                lstrTitleTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                            }
                            else if (ts.Minutes > 0)
                            {
                                lstrTitleTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                            }
                            else lstrTitleTime = "few seconds ago";

                        }

                        builder.Append("<div class=\"block-content-full\">");
                        builder.Append("<ul class=\"media-list media-feed media-feed-hover\">");
                        builder.Append("<li class=\"media\"><a href=\"Profile.aspx\" class=\"pull-left\">");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Picture"])))
                        {
                            builder.Append("<li class=\"media\"><a href='#' class=\"pull-left\"><img style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[0]["Picture"]) + "\" class=\"img-circle\"></a>");
                        }
                        else
                        {
                            builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                        }
                        builder.Append("<div class=\"media-body\">");
                        builder.Append("<p class=\"push-bit\"><span class=\"text-muted pull-right\"><small>" + lstrTitleTime + "</small>");
                        builder.Append("<span class=\"text-info\" data-toggle=\"tooltip\" title=\"From Custom App\"><i class=\"fa fa-wrench\"></i></span></span>");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"])))
                        {
                            builder.Append("<strong><a href='#modal-regular-Profile' data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[0]["PostCreatorID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "</a>" + " published a new story." + "</strong></p>");
                            if (Session["UserID"] != null)
                            {
                                string strLoggedInID = Session["UserID"].ToString();
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PostCreatorID"])))
                                {
                                    if (strLoggedInID != Convert.ToString(ds.Tables[0].Rows[0]["PostCreatorID"]))
                                    {
                                        builder.Append("<a id=\"Message-a\"  title=\"Message user\" href=\"#modal-Send-Msg\" data-toggle=\"modal\" onclick=\"return showSendMsgModel(" + Convert.ToString(ds.Tables[0].Rows[0]["PostCreatorID"]) + ",'" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "')\"><i class=\"gi gi-envelope sidebar-nav-icon\"></i></a>");

                                    }

                                }


                            }
                        }
                        else
                        {
                            builder.Append("<strong><a href=\"javascript:void(0)\">-</a>" + " published a new story." + "</strong></p>");

                        }


                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Posts"])))
                        {
                            builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[0]["Posts"]) + "</p>");
                        }
                        else
                        {
                            builder.Append("<p>-</p>");
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["File"])))
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["File"]).Contains(","))
                            {
                                splitImage = Convert.ToString(ds.Tables[0].Rows[0]["File"]).Split(',');
                                for (int j = 0; j < splitImage.Length; j++)
                                {
                                    lstrImages = splitImage[j].Trim();
                                    builder.Append("<a href=\" ../" + lstrImages + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + lstrImages + "\"></a>");

                                }
                            }
                            else
                            {
                                builder.Append("<a href=\" ../" + Convert.ToString(ds.Tables[0].Rows[0]["File"]).Trim() + "\" target='_blank'><img id=\"filUpload1Img\" height='50px' style=\"width:50px;margin:5px;\" src=\" ../" + Convert.ToString(ds.Tables[0].Rows[0]["File"]).Trim() + "\"></a>");

                            }

                        }
                        if (lstrNotificationType == "Like" && !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["YouTubeURL"])))
                        {
                            string VideoID = Convert.ToString(ds.Tables[0].Rows[0]["YouTubeURL"]);
                            //string lastItemOfSplit = VedioID.Split(new char[] { '\\', '/' })[index.last];
                            string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                            if (!string.IsNullOrEmpty(lastItemOfSplit))
                            {
                                builder.Append("<div id=\"divYoutubeVideo\">");
                                builder.Append("<iframe title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                                builder.Append("</div>");
                            }

                        }
                        if (lstrNotificationType == "Comment" && !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["YouTubeURL"])))
                        {
                            string VideoID = Convert.ToString(ds.Tables[0].Rows[0]["YouTubeURL"]);
                            //string lastItemOfSplit = VedioID.Split(new char[] { '\\', '/' })[index.last];
                            string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                            if (!string.IsNullOrEmpty(lastItemOfSplit))
                            {
                                builder.Append("<div id=\"divYoutubeVideo\">");
                                builder.Append("<iframe title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                                builder.Append("</div>");
                            }

                        }
                        if (lstrNotificationType == "Video")
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["YouTubeURL"])))
                            {
                                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsYouTubeURL"]) == true)
                                {
                                   
                                    string VideoID = Convert.ToString(ds.Tables[0].Rows[0]["YouTubeURL"]);
                                    //string lastItemOfSplit = VedioID.Split(new char[] { '\\', '/' })[index.last];
                                    string lastItemOfSplit = VideoID.Split(new char[] { @"="[0], "="[0] }).Last();
                                    if (!string.IsNullOrEmpty(lastItemOfSplit))
                                    {
                                        builder.Append("<div id=\"divYoutubeVideo\">");
                                        builder.Append("<iframe title=\"YouTube video player\" style=\"margin:0; padding:0;\" src=\"" + WebConfigurationManager.AppSettings["YoutubePath"].ToString() + "/embed/" + lastItemOfSplit + "?rel=0&showsearch=0&autohide=1&autoplay=0&controls=1&fs=1&loop=0&showinfo=0&color=red&theme=light \" frameborder=\"0\" allowfullscreen></iframe>");
                                        builder.Append("</div>");
                                    }



                                }
                            }
                        }
                        //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PostLikeduserID"]) == true)
                        //{
                        //    builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["PostLikeCount"]) + "</span></p>");
                        //}
                        //else
                        //{
                        //    //  builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='' class=\"btn btn-xs btn-default\" ><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");

                        //    builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["PostLikeCount"]) + "</span></p>");
                        //}
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PostsLikeAndShareID"])))
                        {
                            builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["PostLikeCount"]) + "</span></p>");
                        }
                        else
                        {
                            builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["PostLikeCount"]) + "</span></p>");
                        }
                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PostsLikeAndShareID"])))
                        //{
                        //    builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>");
                        //}
                        //else
                        //{
                        //    builder.Append("<p><a id=\"LikePost_" + lintPostID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikePost_" + lintPostID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>");
                        //}
                        //builder.Append("<p><a id=\"UnLikePost-a\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return LikePosts(" + lintTopicID + "," + lintPostID + ")\"><i class=\"fa fa-thumbs-up\"></i>Unlike</a>");

                        // builder.Append("<a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" onclick=\"return ViewPostDetailPage(" + lintPostID + ");\"><i class=\"fa fa-share-square-o\"></i>Share</a>");

                    }

                    builder.Append("<ul class=\"media-list push\">");
                    builder.Append("<li class=\"media\">");
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["CommentTime"])))
                            //if (ds.Tables[0].Rows[i]["CommentTime"] != null)
                            {
                                DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["CommentTime"]);
                                TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["CommentTime"]);

                                if (ts.Days > 0)
                                {
                                    if (ts.Days > 7)
                                    {
                                        Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                        Int32 leftdays = (ts.Days - (week * 7));

                                        lstrCommentTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                    }
                                    else
                                        lstrCommentTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                }
                                else if (ts.Hours > 0)
                                {
                                    lstrCommentTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                }
                                else if (ts.Minutes > 0)
                                {
                                    lstrCommentTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                }
                                else lstrCommentTime = "few seconds ago";

                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["SenderImage"])))
                                {
                                    builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[i]["SenderImage"]) + "\"></a>");
                                }
                                else
                                {
                                    builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");

                                }
                                builder.Append("<div class=\"media-body\">");
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["SenderName"])))
                                {
                                    builder.Append("<a href='#modal-regular-Profile'  data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["SenderID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["SenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                    //  builder.Append("<a href=''><strong>" + Convert.ToString(ds.Tables[1].Rows[i]["SenderName"]) + "</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>" + " " + "<a href=''><image style=\"width:20px;\" src=\"img/like.png\"></a>");
                                    if (Session["UserID"] != null)
                                    {
                                        string strLoggedInID = Session["UserID"].ToString();
                                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["SenderID"])))
                                        {
                                            if (strLoggedInID != Convert.ToString(ds.Tables[0].Rows[i]["SenderID"]))
                                            {
                                                builder.Append("<br /><a id=\"Message-a\"  title=\"Message user\" href=\"#modal-Send-Msg\" data-toggle=\"modal\" onclick=\"return showSendMsgModel(" + Convert.ToString(ds.Tables[0].Rows[i]["SenderID"]) + ",'" + Convert.ToString(ds.Tables[0].Rows[i]["SenderName"]) + "')\"><i class=\"gi gi-envelope sidebar-nav-icon\"></i></a>");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    builder.Append("<a href=''><strong-</strong></a>" + "  " + "<span class=\"text-muted\"><small><em>" + lstrCommentTime + "</em></small></span>");
                                }
                                builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[i]["Comment"]) + "</p>");

                                builder.Append("</div>");
                                builder.Append("</li>");
                            }
                        }

                        builder.Append("<li class=\"media\"><a href=\"page_ready_user_profile.html\" class=\"pull-left\">");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["UserPic"])))
                        {
                            builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[1].Rows[0]["UserPic"]) + "\"></a>");
                        }
                        else
                        {
                            builder.Append("<a class=\"pull-left\">" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                        }
                        builder.Append("<div class=\"media-body\">");
                        builder.Append("<form action=\"page_forms_components.html\" method=\"post\" onsubmit=\"return false;\">");
                        builder.Append("<textarea id=\"profile-newsfeed-comment" + Convert.ToInt32(dr[0]) + "\" name=\"profile-newsfeed-comment" + Convert.ToInt32(dr[0]) + "\" class=\"form-control\"  rows=\"2\" placeholder=\"Your comment..\"></textarea>");
                        builder.Append("<button type=\"submit\" class=\"btn btn-xs btn-primary\" onclick=\"return AddPostComments(" + Convert.ToInt32(dr[0]) + ");\"> <i class=\"fa fa-pencil\"></i>Post Comment</button>");
                        builder.Append("</form>");
                    }
                    builder.Append("</div>");
                    builder.Append("</li>");
                    builder.Append("</ul>");
                    builder.Append("</div>");
                    builder.Append("</li>");
                    builder.Append("</ul>");
                    builder.Append("</div>");
                }

                #endregion Post,Comment,Like,Video

                #region TopicLike
                if (lstrNotificationType == "TopicLike")
                {

                    builder.Append("<div class=\"block\" >");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        builder.Append("<div class=\"block-content-full\">");
                        builder.Append("<ul class=\"media-list media-feed media-feed-hover\">");
                        builder.Append("<li class=\"media\">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Title"])))
                        {

                            builder.Append("<div class=\"media-body\">");

                            if (ds.Tables[0].Rows[0]["TopicTime"] != null)
                            {
                                DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["TopicTime"]);
                                TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0]["TopicTime"]);

                                if (ts.Days > 0)
                                {
                                    if (ts.Days > 7)
                                    {
                                        Int32 week = (Int32)Math.Ceiling(Convert.ToDecimal(ts.Days / 7));
                                        Int32 leftdays = (ts.Days - (week * 7));

                                        lstrTopicTime = week + " Week(s) " + (leftdays > 0 ? " & " + leftdays.ToString() + " day(s) " : "") + " ago";
                                    }
                                    else
                                        lstrTopicTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
                                }
                                else if (ts.Hours > 0)
                                {
                                    lstrTopicTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
                                }
                                else if (ts.Minutes > 0)
                                {
                                    lstrTopicTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
                                }
                                else lstrTopicTime = "few seconds ago";

                            }
                            //builder.Append("<ForumPosts>");
                            builder.Append("<p class=\"push-bit\"><span class=\"text-muted pull-right\">");
                            builder.Append("Added by <a href='#modal-regular-Profile'  data-toggle=\"modal\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[0]["UserID"].ToString() + ")\">" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "</a><br>");
                            builder.Append("<small class=\"text-muted pull-right\">" + lstrTopicTime + "</small>");
                            builder.Append("<h4><a><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["Title"]) + "</strong></a></h4>");
                            builder.Append("</p>");
                            builder.Append("<Description>");
                            builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[0]["Description"]) + "</p>");
                            //  builder.Append("<p><a class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>" + "Like" + "</a>" + "     " + "<a href='' class=\"btn btn-xs btn-default\" ><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a></p>");
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TopicLikeAndShareID"])))
                            {
                                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" style=\"display:none;\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='' class=\"btn btn-xs btn-default\" ><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");
                            }
                            else
                            {
                                builder.Append("<p><a id=\"LikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" class=\"btn btn-xs btn-success\" onclick=\"return LikeTopic(" + lintTopicID + ");\"><i class=\"fa fa-thumbs-up\"></i>Like</a><a id=\"UnLikeTopic_" + lintTopicID + "\" href=\"javascript:void(0)\" style=\"display:none;\" class=\"btn btn-xs btn-success\" onclick=\"return UnlikeTopic(" + lintTopicID + ")\"><i class=\"fa fa-thumbs-down\"></i>Unlike</a>" + "     " + "<a href='' class=\"btn btn-xs btn-default\" ><i class=\"fa fa-share-square-o\"></i>" + "Share" + "</a><img id=\"like\" src=\"images/like1.png\"/><span id=\"LikeCount\">" + Convert.ToInt32(ds.Tables[0].Rows[0]["TopicLikeCount"]) + "</span></p>");
                            }

                            builder.Append("</Description>");


                        }
                        builder.Append("</li>");
                        builder.Append("</ul>");
                        builder.Append("</div>");
                    }
                    builder.Append("</div>");
                }

                #endregion TopicLike

                #region Message

                if (lstrNotificationType == "Message")
                {
                    lintSendMsgToUserID = Convert.ToInt32(ds.Tables[2].Rows[0]["InitiatedByUserID"]);
                    string MessageTime = string.Empty;
                    string ReceiverSendTime = string.Empty;
                    //builder.Append("<div class=\"block\">");
                    //builder.Append("<div class=\"block-content-full\">");
                    //builder.Append("<ul class=\"media-list media-feed media-feed-hover\">");
                    builder.Append("<ul class=\"media-list push\">");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (ds.Tables[0].Rows[i]["DateAndTime"] != null)
                        {
                            DateTime inputDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAndTime"]);
                            TimeSpan ts = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAndTime"]);
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

                        builder.Append("<li class=\"media\">");
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Picture"])))
                        {
                            builder.Append("<a href='' class=\"pull-left\"><img style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[i]["Picture"]) + "\" class=\"img-circle\"></a>");
                        }
                        else
                        {
                            builder.Append("<a href='' class=\"pull-left\"><image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                        }
                        builder.Append("<div class=\"media-body\">");
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["InitiatedByUserID"]) == mdblUserID)
                        {
                            builder.Append("<a href='#modal-regular-Profile'  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["InitiatedByUserID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["SenderName"]) + "</strong></a>");
                        }
                        else
                        {
                            builder.Append("<a href='#modal-regular-Profile'  data-toggle=\"modal\"  style=\"color:black;\" onclick=\"return ShowProfileModal(" + ds.Tables[0].Rows[i]["InitiatedByUserID"].ToString() + ")\"><strong>" + Convert.ToString(ds.Tables[0].Rows[i]["SenderName"]) + "</strong></a>");

                        }

                        builder.Append("<span class=\"text-muted\"><small><em>" + MessageTime + "</em></small></span>");
                        builder.Append("<p>" + Convert.ToString(ds.Tables[0].Rows[i]["Message"]) + "</p>");

                        builder.Append("</div>");
                        builder.Append("</li>");

                    }
                    if (ds.Tables[1].Rows[0] != null)
                    {
                        builder.Append("<li class=\"media\">");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["UserPic"])))
                        {
                            builder.Append("<a href='' class=\"pull-left\"><img style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[1].Rows[0]["UserPic"]) + "\" class=\"img-circle\"></a>");
                        }
                        else
                        {
                            builder.Append("<a href='' class=\"pull-left\"><image class=\"img-circle\" style=\"width:50px;\" src=\"../img/AnonymousGuyPic.jpg\"></a>");
                        }

                        builder.Append("<div class=\"media-body\">");
                        builder.Append("<form action=\"page_ready_user_profile.html\" method=\"post\" onSubmit=\"return false;\">");
                        builder.Append("<textarea id=\"profile-newsfeed-comment1\" name=\"profile-newsfeed-comment1\" class=\"form-control\" rows=\"2\" placeholder=\"Your comment..\"></textarea>");
                        builder.Append("<button type=\"submit\" class=\"btn btn-xs btn-primary\" onclick=\"return PostMessageToUser1(" + lintSendMsgToUserID + ");\"><i class=\"fa fa-pencil\"></i>" + "Post" + "</button>");
                        builder.Append("</form>");
                        builder.Append("</div>");
                        builder.Append("</li>");
                    }
                    builder.Append("</ul>");

                }

                #endregion Message

                #region Authorize
                if (lstrNotificationType == "Authorize")
                {
                    builder.Append("<div class=\"block\">");
                    builder.Append("<div class=\"block-title\">");
                    builder.Append("<div class=\"block-options pull-right\">");
                  //  builder.Append("<a href='#divProfileForm' class=\"btn btn-sm btn-alt btn-default\" data-toggle=\"tooltip\" title=\"Edit Profile\" onClick=\"return showEditProfileDiv();\"><i class=\"fa fa-pencil\"></i></a>");
                    builder.Append("</div>");
                    builder.Append("<h2>A new Client information has been shared with you. The details of<strong style=\"color:#F31455;\">" + "  " + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + " " + "</strong> as shown below:</h2></div>");
                    builder.Append("<div class=\"block-content-full\">");
                    builder.Append("<table class=\"table table-borderless table-striped\" id=\"tbl_profile\">");
                    builder.Append("<tbody>");
                    builder.Append("<tr>");
                    builder.Append("<td style=\"width: 20%;\">");
                    builder.Append("<strong> Image  </strong>");
                    builder.Append("</td>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Picture"])))
                    {
                        builder.Append("<td>" + "<image style=\"width:100px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[0]["Picture"]) + "\"></td>");
                    }
                    else
                    {
                        builder.Append("<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"" + "../img/AnonymousGuyPic.jpg" + "\"></td>");
                    }
                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td>");
                    builder.Append("<strong> Name </strong>");
                    builder.Append("</td>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"])))
                    {
                        builder.Append("<td>" + Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]) + "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }
                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td><strong>Email</strong></td>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Email"])))
                    {
                        builder.Append("<td><a href=\"javascript:void(0)\">" + Convert.ToString(ds.Tables[0].Rows[0]["Email"]) + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td><a href=\"javascript:void(0)\">-</a></td>");
                    }
                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td><strong>Address</strong></td>");

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"])))
                    {
                        builder.Append("<td>");
                        builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Address_line1"]));
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Address_line2"])))
                            builder.Append("," + Convert.ToString(ds.Tables[0].Rows[0]["Address_line2"]));
                      builder.Append("</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");

                    }

                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td><strong>City</strong></td>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["City"])))
                    {
                        builder.Append("<td>" + Convert.ToString(ds.Tables[0].Rows[0]["City"]) + "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }
                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td><strong>Province</strong></td>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Province"])))
                    {
                        builder.Append("<td>" + Convert.ToString(ds.Tables[0].Rows[0]["Province"]) + "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }
                    builder.Append("</tr>");
                    builder.Append("<tr>");
                    builder.Append("<td><strong>Phone Number</strong></td>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"])))
                    {
                        builder.Append("<td>" + Convert.ToString(ds.Tables[0].Rows[0]["Mobile_Phone"]) + "</td>");
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

                #endregion Authorize
            }



        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion ViewNotifications

    #region PostTopicUrl
    /// <summary>
    /// Author:Jasmeet kaur
    /// date:090914
    /// function used to post topic url.
    /// </summary>
    private void PostTopicUrl()
    {
        string lstrComments = "";
        Int32 lintTopicID = -1;
        Int32 lintCategoryID = -1;
        string lstrImages = "";
        bool lblIsUrl = false;

        try
        {
            if (Request.Form["Content"] != null)
                lstrComments = Convert.ToString(Request.Form["Content"]);

            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["CategoryID"] != null)
                lintCategoryID = Convert.ToInt32(Request.Form["CategoryID"]);

            if (Request.Form["Images"] != null)
                lstrImages = Convert.ToString(Request.Form["Images"]);

            if (Request.Form["IsUrl"] != null)
                lblIsUrl = Convert.ToBoolean(Request.Form["IsUrl"]);



            string lstr = mobjCUser.PostTopicUrl(lstrComments, lintTopicID, lintCategoryID, mdblUserID, lblIsUrl);


            mstrResponseData = "SUCCESS";

        }
        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }
    }

    #endregion PostTopicUrl

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

    #region FillImgSizeCombo
    private void FillImgSizeCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.FillImgSizeCombo();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<ImageSize>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["ImageSize"].ToString() + "]]>");
                    lobjBuilder.Append("</ImageSize>");

                    lobjBuilder.Append("<ImageSizeID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["ImageSizeID"].ToString() + "]]>");
                    lobjBuilder.Append("</ImageSizeID>");

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

    #endregion FillImgSizeCombo

    #region AddNewAdvertisement
    /// <summary>
    /// Author:jasmeet kaur
    /// Date:092314
    /// Function used to add new advertisement.
    /// </summary>
    private void AddNewAdvertisement()
    {
        string lstrTitle = "";
        string lstrImages = "";
        string lstrClickUrl = "";
        string lstrFromDate = "";
        string lstrToDate = "";
        string lstrFromTime = "";
        string lstrToTime = "";
        Int32 lintImageSizeID = -1;
        //Int32 lintStateID = -1;
        //Int32 lintCityID = -1;
        Int32 lintAdvertisementId = -1;
        Int32 lintZoneID = -1;
        try
        {

            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["ImageName"] != null)
                lstrImages = Convert.ToString(Request.Form["ImageName"]);

            if (Request.Form["ClickUrl"] != null)
                lstrClickUrl = Convert.ToString(Request.Form["ClickUrl"]);

            if (Request.Form["FromDateTime"] != null)
                lstrFromDate = Convert.ToString(Request.Form["FromDateTime"]);

            if (Request.Form["ToDateTime"] != null)
                lstrToDate = Convert.ToString(Request.Form["ToDateTime"]);

            if (Request.Form["FromTime"] != null)
                lstrFromTime = Convert.ToString(Request.Form["FromTime"]);

            if (Request.Form["ToTime"] != null)
                lstrToTime = Convert.ToString(Request.Form["ToTime"]);

            if (Request.Form["ImageSizeID"] != null)
                lintImageSizeID = Convert.ToInt32(Request.Form["ImageSizeID"]);

            //if (Request.Form["StateID"] != null)
            //    lintStateID = Convert.ToInt32(Request.Form["StateID"]);

            //if (Request.Form["CityID"] != null)
            //    lintCityID = Convert.ToInt32(Request.Form["CityID"]);

            if (Request.Form["AdvertisementZoneID"] != null)
                lintZoneID = Convert.ToInt32(Request.Form["AdvertisementZoneID"]);

            if (Request.Form["AdvertisementID"] != null)
                lintAdvertisementId = Convert.ToInt32(Request.Form["AdvertisementID"]);

           // mobjCUser.AddNewAdvertisement(lstrTitle, lstrImages, lstrClickUrl, lstrFromDate, lstrToDate, lstrFromTime, lstrToTime, lintImageSizeID, lintStateID, lintCityID, mdblUserID, lintAdvertisementId);
            mobjCUser.AddNewAdvertisement(lstrTitle, lstrImages, lstrClickUrl, lstrFromDate, lstrToDate, lstrFromTime, lstrToTime, lintImageSizeID, lintZoneID, mdblUserID, lintAdvertisementId);
            mstrResponseData = "SUCCESS";
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion AddNewAdvertisement

    #region GetAdvertisementListing
    /// <summary>
    /// AUTHOR:JASMEET KAUR
    /// DATE:092314
    /// function used to get advertisement listing.
    /// </summary>
    private void GetAdvertisementListing()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

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


                mobjCCommon.SetGridVariables(CConstants.enumTables.TblAdvertisements.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetAdvertisementListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);

                if (ds != null)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["AdvertisementID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["ImageName"])))
                        {
                            builder.Append("<cell><![CDATA[<td>" + "<image style=\"width:50px;\" src=\"../" + Convert.ToString(ds.Tables[0].Rows[i]["ImageName"]) + "\"></td>]]></cell>");

                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>-</td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Title"])))
                        {
                            builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>" + "-" + "</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["ClickUrl"])))
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[i]["ClickUrl"]).IndexOf("http") == -1)
                                builder.Append("<cell><![CDATA[<td><a class=\"pull-left\" target='_blank' href=\"http://" + Convert.ToString(ds.Tables[0].Rows[i]["ClickUrl"]) + "\">" + Convert.ToString(ds.Tables[0].Rows[i]["ClickUrl"]) + "</a></td>]]></cell>");
                            else
                                builder.Append("<cell><![CDATA[<td><a class=\"pull-left\" target='_blank' href=\"" + Convert.ToString(ds.Tables[0].Rows[i]["ClickUrl"]) + "\">" + Convert.ToString(ds.Tables[0].Rows[i]["ClickUrl"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["City"])))
                        //{
                        //    builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["City"]) + "</td>]]></cell>");
                        //}
                        //else
                        //{
                        //    builder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        //}
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Zone"])))
                        {
                            builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Zone"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["ViewCount"])))
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + Convert.ToString(ds.Tables[0].Rows[i]["ViewCount"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td class=\"text-center hidden-xs hidden-sm\" style=\"text-align:center;\">" + "0" + "</td>]]></cell>");

                        }

                        builder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        builder.Append("<div class=\"block-options\">");
                        builder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Advertisement\" data-toggle=\"tooltip\" onclick=\"return DeleteAdvertisement(" + ds.Tables[0].Rows[i]["AdvertIsementID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        builder.Append("<a href='#modal-Add-Advertisement' title=\"Edit Advertisement\" data-toggle=\"modal\" onclick=\"return showEditAdvertisementModel(" + ds.Tables[0].Rows[i]["AdvertisementID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
                        builder.Append("</div>");
                        builder.Append("</td>]]></cell>");

                        builder.Append(" </row>");
                    }

                }


                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetAdvertisementListing

    #region DeleteAdvertisement
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:092314
    /// Function used to delete advertisement
    /// </summary>
    private void DeleteAdvertisement()
    {
        Int32 lintAdvertisementID = -1;

        try
        {
            if (Request.Form["AdvertisementID"] != null)
                lintAdvertisementID = Convert.ToInt32(Request.Form["AdvertisementID"]);
            //#A Jasmeet: 072814 - delete topic
            mobjCUser.DeleteAdvertisement(lintAdvertisementID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteAdvertisement

    #region GetAdvertisementDetails
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:092314
    /// function used to get advertisement details
    /// </summary>
    private void GetAdvertisementDetails()
    {
        Int32 lintAdvertisementID = -1;
        Int32 lintstarthrs = -1;
        Int32 lintendhrs = -1;
        StringBuilder builder = new StringBuilder("<Response><AdvertisementData>");
        try
        {
            if (Request.Form["AdvertisementID"] != null)
                lintAdvertisementID = Convert.ToInt32(Request.Form["AdvertisementID"]);

            DataSet ds = mobjCUser.GetAdvertisementDetails(lintAdvertisementID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<ImageName><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ImageName"]));
                builder.Append("]]></ImageName>");

                builder.Append("<ClickUrl><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ClickUrl"]));
                builder.Append("]]></ClickUrl>");

                builder.Append("<ImageSizeID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ImageSizeID"]));
                builder.Append("]]></ImageSizeID>");

                //builder.Append("<StateID><![CDATA[");
                //builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["StateID"]));
                //builder.Append("]]></StateID>");

                //builder.Append("<CityID><![CDATA[");
                //builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["CityID"]));
                //builder.Append("]]></CityID>");

                builder.Append("<AdvertisementZoneID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["AdvertisementZoneID"]));
                builder.Append("]]></AdvertisementZoneID>");

                builder.Append("<FromDateTime><![CDATA[");
                builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["FromDateTime"]).ToString("MM/dd/yyyy"));
                builder.Append("]]></FromDateTime>");

                builder.Append("<ToDateTime><![CDATA[");
                builder.Append(Convert.ToDateTime(ds.Tables[0].Rows[0]["ToDateTime"]).ToString("MM/dd/yyyy"));
                builder.Append("]]></ToDateTime>");

                builder.Append("<StartHours><![CDATA[");
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["StartHours"].ToString()) > 12)
                {
                    lintstarthrs = Convert.ToInt32(ds.Tables[0].Rows[0]["StartHours"].ToString()) - 12;
                    if (Convert.ToString(lintstarthrs).Length == 1)
                        builder.Append("0" + lintstarthrs);
                    else
                        builder.Append(lintstarthrs);
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["StartHours"].ToString().Length == 1)
                        builder.Append("0" + ds.Tables[0].Rows[0]["StartHours"].ToString());
                    else
                        builder.Append(ds.Tables[0].Rows[0]["StartHours"].ToString());
                }

                builder.Append("]]></StartHours>");

                builder.Append("<StartMinutes><![CDATA[");
                if (ds.Tables[0].Rows[0]["StartMinutes"].ToString().Length == 1)
                    builder.Append("0" + ds.Tables[0].Rows[0]["StartMinutes"].ToString());
                else
                    builder.Append(ds.Tables[0].Rows[0]["StartMinutes"].ToString());
                builder.Append("]]></StartMinutes>");

                builder.Append("<STARTAMPM><![CDATA[");
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["StartHours"].ToString()) > 12)
                {
                    builder.Append("PM");
                }
                else
                {
                    builder.Append("AM");
                }
                builder.Append("]]></STARTAMPM>");

                builder.Append("<ToHours><![CDATA[");
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["EndHours"].ToString()) > 12)
                {
                    lintendhrs = Convert.ToInt32(ds.Tables[0].Rows[0]["EndHours"].ToString()) - 12;
                    if (Convert.ToString(lintendhrs).Length == 1)
                        builder.Append("0" + lintendhrs);
                    else
                        builder.Append(lintendhrs);
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["EndHours"].ToString().Length == 1)
                        builder.Append("0" + ds.Tables[0].Rows[0]["EndHours"].ToString());
                    else
                        builder.Append(ds.Tables[0].Rows[0]["EndHours"].ToString());
                }

                builder.Append("]]></ToHours>");

                builder.Append("<ToMinutes><![CDATA[");
                if (ds.Tables[0].Rows[0]["EndMinutes"].ToString().Length == 1)
                    builder.Append("0" + ds.Tables[0].Rows[0]["EndMinutes"].ToString());
                else
                    builder.Append(ds.Tables[0].Rows[0]["EndMinutes"].ToString());

                builder.Append("]]></ToMinutes>");

                builder.Append("<TOAMPM><![CDATA[");
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["EndHours"].ToString()) > 12)
                {
                    builder.Append("PM");
                }
                else
                {
                    builder.Append("AM");
                }
                builder.Append("]]></TOAMPM>");
            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</AdvertisementData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetAdvertisementDetails

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

    #region ShowAdvertisement
    private void ShowAdvertisement()
    {

        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.ShowAdvertisements(mdblCityID);

            if (ds != null)
            {

                EnumerableRowCollection<DataRow> LeftSectionQuery = from order in ds.Tables[0].AsEnumerable()
                                                                    where order.Field<decimal>("ImageSizeID") == 1
                                                                    select order;

                foreach (DataRow dr in LeftSectionQuery)
                {
                    builder.Append("<li >");
                    if (!string.IsNullOrEmpty(Convert.ToString(dr["ImageName"])))
                    {
                        builder.Append("<a  href='../Redirect.aspx?i=" + Convert.ToString(dr["AdvertisementID"]) + "' class=\"pull-left\" style=\"margin:0px;padding:3px;\" target='_blank;' ><img style=\"width:194px;height:auto;\" src=\"" + Convert.ToString(dr["ImageName"]) + "\"/></a>");

                    }

                    builder.Append("</li>");
                }

                builder.Append("#");
                EnumerableRowCollection<DataRow> TopSectionQuery = from order in ds.Tables[0].AsEnumerable()
                                                                   where order.Field<decimal>("ImageSizeID") == 2
                                                                   select order;

                foreach (DataRow dr in TopSectionQuery)
                {

                    if (!string.IsNullOrEmpty(Convert.ToString(dr["ImageName"])))
                    {
                        builder.Append("<a  href='../Redirect.aspx?i=" + Convert.ToString(dr["AdvertisementID"]) + "' class=\"pull-left\" style=\"margin:5px;\" target='_blank;' ><img src=\"" + Convert.ToString(dr["ImageName"]) + "\" /></a>");

                        //  builder.Append("<a  href='" + (Convert.ToString(dr["ClickUrl"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(dr["ClickUrl"]) : Convert.ToString(dr["ClickUrl"])) + "' class=\"pull-left\" style=\"margin:5px;\" target='_blank;' ><img src=\"" + Convert.ToString(dr["ImageName"]) + "\" onclick=\"return GetAdvertisementViewersCount(" + Convert.ToString(dr["AdvertisementID"]) + ",'" + (Convert.ToString(dr["ClickUrl"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(dr["ClickUrl"]) : Convert.ToString(dr["ClickUrl"])) + "');\"/></a>");
                        // builder.Append("<a href='#' class=\"pull-left\" style=\"margin:5px;\" target='_blank;'><img src=\"" + Convert.ToString(dr["ImageName"]) + "\" onclick=\"return GetAdvertisementViewersCount(" + Convert.ToString(dr["AdvertisementID"]) + ",'" + (Convert.ToString(dr["ClickUrl"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(dr["ClickUrl"]) : Convert.ToString(dr["ClickUrl"])) + "');\"/></a>");
                    }

                }

            }

        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();

    }
    #endregion ShowAdvertisement

    #region AddRssfeed
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:100814
    /// Function used to add rss Feed.
    /// </summary>
    private void AddRssfeed()
    {
        string lstrTitle = "";
        string lstrURL = "";
        Int32 lintRssFeedID = -1;
        bool lbnIsPublic = false;

        try
        {
            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["URL"] != null)
                lstrURL = Convert.ToString(Request.Form["URL"]);

            if (Request.Form["RssFeedID"] != null)
                lintRssFeedID = Convert.ToInt32(Request.Form["RssFeedID"]);

            if (Request.Form["IsPublic"] != null)
                lbnIsPublic = Convert.ToBoolean(Request.Form["IsPublic"]);

            if (IsValidFeedUrl(lstrURL))
            {

                string lstr = mobjCUser.AddRssfeed(lstrTitle, lstrURL, lintRssFeedID, mdblUserID, lbnIsPublic);
                if (lstr.ToUpper() == "SUCCESS")
                {
                    mstrResponseData = "SUCCESS";

                }
            }
            else
            {
                mstrResponseData = "Invalid Url";
            }
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }
    }

    #endregion AddRssfeed

    #region GetRssFeedTitleList
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:100814
    /// Function used to get list of Rss Feed Title.
    /// </summary>
    private void GetRssFeedTitleList()
    {
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.GetRssFeedTitleList(mdblUserID, mstrIsAdmin);

            if (ds != null)
            {
                string RssFeedTime = string.Empty;
                builder.Append("<ul class=\"nav nav-pills nav-stacked\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    builder.Append("<li id=\"li_" + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + "\" >");

                    builder.Append("<a class=\"tooltip\" title='" + ds.Tables[0].Rows[i]["Title"].ToString() + "' href='#' onclick=\"return GetRssFeedDetails('" + (Convert.ToString(ds.Tables[0].Rows[i]["URL"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(ds.Tables[0].Rows[i]["URL"]) : Convert.ToString(ds.Tables[0].Rows[i]["URL"])) + "'," + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + ")\">");
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["RssUserID"]) == mdblUserID || mstrIsAdmin == "True")
                    {

                        builder.Append("<img src=\"images/pencil.png\" data-toggle=\"modal\" class=\"display_none\" alt=\"Edit Rss Feed\" title=\"Edit Rss Feed\" onclick=\"return ShowEditModalForRssFeed(" + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + ");\" style=\"float:right;margin:5px;\"/>");

                        builder.Append("<img src=\"images/whitecross.png\" alt=\"Delete Rss Feed\" class=\"display_none\"  title=\"Delete Rss Feed\" onclick=\"return DeleteRssFeed(" + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + ");\" style=\"float:right;margin:5px;\"/>");
                        if (Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Length >= 9)
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Substring(0, 9) + "..." + "</strong>");
                        }
                        else
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong>");
                        }
                    }

                    else
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Length >= 9)
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Substring(0, 9) + "..." + "</strong>");
                        }
                        else
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong>");
                        }

                    }
                    builder.Append("</a>");
                    builder.Append("</li>");

                }
                builder.Append("</ul>");
            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No Rss Found</div>");

            }


        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetRssFeedTitleList

    #region GetRssFeedList
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:100814
    /// Function used to get list of Rss Feed Title.
    /// </summary>
    private DataSet GetRssFeedList()
    {
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = mobjCUser.GetRssFeedTitleList(mdblUserID, mstrIsAdmin);



            return ds;
        }
        catch (Exception)
        {
            throw;
        }

       
    }

    #endregion GetRssFeedList

    #region DeleteRssFeed
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:100814
    /// Function used to delete Rss Feed.
    /// </summary>
    private void DeleteRssFeed()
    {
        Int32 lintRssFeedID = -1;

        try
        {
            if (Request.Form["RssFeedID"] != null)
                lintRssFeedID = Convert.ToInt32(Request.Form["RssFeedID"]);
            //#A Jasmeet: 100814 - delete Rss Feed
            mobjCUser.DeleteRssFeed(lintRssFeedID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }


    #endregion DeleteRssFeed

    #region IsValidFeedUrl
    public bool IsValidFeedUrl(string url)
    {
        bool isValid = true;
        try
        {
            XmlReader reader = XmlReader.Create(url);
            Rss20FeedFormatter formatter = new Rss20FeedFormatter();
            formatter.ReadFrom(reader);
            reader.Close();
        }
        catch
        {

            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(url);
            System.ServiceModel.Syndication.SyndicationFeed feed = System.ServiceModel.Syndication.SyndicationFeed.Load(reader);
            if (feed != null)
                isValid = true;
            else
                isValid = false;
        }

        return isValid;
    }

    #endregion IsValidFeedUrl

    #region GetRssFeedDetails

    private void GetRssFeedDetails()
    {
        Int32 lintRssFeedID = -1;

        StringBuilder builder = new StringBuilder("<Response><RssFeedData>");
        try
        {
            if (Request.Form["RssFeedID"] != null)
                lintRssFeedID = Convert.ToInt32(Request.Form["RssFeedID"]);
            //#A Jasmeet: 101014 - GetRssFeedDetails

            DataSet ds = mobjCUser.GetRssFeedDetails(lintRssFeedID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<URL><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["URL"]));
                builder.Append("]]></URL>");

                builder.Append("<IsPublic><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["IsPublic"]));
                builder.Append("]]></IsPublic>");

            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</RssFeedData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetRssFeedDetails

    #region GetUsersRssFeedDetails
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:101314
    /// Function used to view user's rss feed.
    /// </summary>
    private void GetUsersRssFeedDetails()
    {
        Int32 lintRssUserID = -1;
        StringBuilder builder = new StringBuilder();
        try
        {
            if (Request.Form["UserID"] != null)
                lintRssUserID = Convert.ToInt32(Request.Form["UserID"]);
            DataSet ds = mobjCUser.GetUsersRssFeedDetails(lintRssUserID);

            if (ds != null)
            {
                string RssFeedTime = string.Empty;
                builder.Append("<ul class=\"nav nav-pills nav-stacked\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    builder.Append("<li id=\"li_" + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + "\">");
                    if (Convert.ToString(ds.Tables[0].Rows[i]["IsPublic"]) == "True")
                    {
                        builder.Append("<a class=\"tooltip\" title='" + ds.Tables[0].Rows[i]["Title"].ToString() + "' href='#' onclick=\"return GetRssFeedDetails('" + (Convert.ToString(ds.Tables[0].Rows[i]["URL"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(ds.Tables[0].Rows[i]["URL"]) : Convert.ToString(ds.Tables[0].Rows[i]["URL"])) + "'," + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + ")\" style=\"background-color:#0044a5;color:black\">");
                        if (Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Length >= 9)
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Substring(0, 9) + "..." + "</strong>");
                        }
                        else
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong>");
                        }
                        builder.Append("</a>");
                    }
                    else
                    {
                        builder.Append("<a class=\"tooltip\" title='" + ds.Tables[0].Rows[i]["Title"].ToString() + "' href='#' onclick=\"return GetRssFeedDetails('" + (Convert.ToString(ds.Tables[0].Rows[i]["URL"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(ds.Tables[0].Rows[i]["URL"]) : Convert.ToString(ds.Tables[0].Rows[i]["URL"])) + "'," + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + ")\" style=\"background-color:#f31455;color:black\">");
                        if (Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Length >= 9)
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Substring(0, 9) + "..." + "</strong>");
                        }
                        else
                        {
                            builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</strong>");
                        }
                        builder.Append("</a>");
                    }
                    builder.Append("</li>");

                }
                builder.Append("</ul>");
            }
            else
            {

                builder.Append("<div class=\"row\" style='text-align:center'>No Rss Found</div>");

            }


        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetUsersRssFeedDetails

    #region LikeTopic
    private void LikeTopic()
    {
        Int32 lintTopicID = -1;
        string lstrResult = "";

        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            lstrResult = mobjCUser.LikeTopic(mdblUserID, lintTopicID);
            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion LikeTopic

    #region UnlikeTopic
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:101414
    /// Function used to unlike topic.
    /// </summary>
    private void UnlikeTopic()
    {

        Int32 lintTopicID = -1;

        try
        {
            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            mobjCUser.UnlikeTopic(mdblUserID, lintTopicID);
            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion UnlikeTopic

    #region RemoveNotification
    private void RemoveNotification()
    {

        Int32 lintNotificationID = -1;

        try
        {
            if (Request.Form["NotificationID"] != null)
                lintNotificationID = Convert.ToInt32(Request.Form["NotificationID"]);
            //#A Jasmeet: 052514 - delete Category
            mobjCUser.AddTopicNotification(lintNotificationID, mdblUserID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion RemoveNotification

    #region PostVideo
    private void PostVideo()
    {
        string lstrComments = "";
        Int32 lintTopicID = -1;
        Int32 lintCategoryID = -1;
        string lstrImages = "";
        bool lblIsUrl = false;
        string lstrYouTubeUrl = "";
        try
        {
            if (Request.Form["Content"] != null)
                lstrComments = Convert.ToString(Request.Form["Content"]);

            if (Request.Form["TopicID"] != null)
                lintTopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["CategoryID"] != null)
                lintCategoryID = Convert.ToInt32(Request.Form["CategoryID"]);

            if (Request.Form["Images"] != null)
                lstrImages = Convert.ToString(Request.Form["Images"]);

            if (Request.Form["IsUrl"] != null)
                lblIsUrl = Convert.ToBoolean(Request.Form["IsUrl"]);

            if (Request.Form["YouTubeUrl"] != null)
                lstrYouTubeUrl = Convert.ToString(Request.Form["YouTubeUrl"]);

            string lstr = mobjCUser.PostVideo(lstrComments, lintTopicID, lintCategoryID, mdblUserID, lblIsUrl, lstrYouTubeUrl);


            mstrResponseData = "SUCCESS";

        }
        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }
    }

    #endregion PostVideo

    #region AddNewAdvertisementZone
    /// <summary>
    /// Author:Param Bajwa
    /// Date:12022014
    /// Function used to add new advertisement group or region/zone.
    /// </summary>
    private void AddNewAdvertisementZone()
    {
        string lstrTitle = "";
        string lstrDescription = "";          
        Int32 lintStateID = -1;
        Int32 lintCityID = -1;
        Int32 lintAdvertisementZoneID = -1;
        Int32 lintMAdvertisementZoneID = -1;
        string lstrCities = "";
        bool lbnIsOpen = false;
        try
        {

            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["Description"] != null)
                lstrDescription = Convert.ToString(Request.Form["Description"]);

            if (Request.Form["CityID"] != null)
                lstrCities = Convert.ToString(Request.Form["CityID"]);

            if (Request.Form["StateID"] != null)
                lintStateID = Convert.ToInt32(Request.Form["StateID"]);

            if (Request.Form["AdvertisementZoneID"] != null)
                lintAdvertisementZoneID = Convert.ToInt32(Request.Form["AdvertisementZoneID"]);

            if (Request.Form["IsOpen"] != null)
                lbnIsOpen = Convert.ToBoolean(Request.Form["IsOpen"]);

            //add advertise group
            if (lintAdvertisementZoneID == -1)
            {

                lintAdvertisementZoneID = mobjCUser.AddNewAdvertisementZone(lstrTitle, lstrDescription, lbnIsOpen);

                if (lintAdvertisementZoneID != -1)
                {
                    if (!lbnIsOpen)
                    {
                        string[] ArrCities = lstrCities.Split(',');

                        int count = ArrCities.Length;

                        if (count > 0)
                        {

                            for (int i = 0; i < count; i++)
                            {
                                mobjCUser.AddZoneCities(lintAdvertisementZoneID, Convert.ToInt32(ArrCities[i]));
                            }
                        }
                    }

                }
            }
            else
            {
                mobjCUser.UpdateAdvertisementZone(lstrTitle, lstrDescription, lintAdvertisementZoneID, lbnIsOpen);

                if (lintAdvertisementZoneID != -1)
                {
                    if (!lbnIsOpen)
                    {
                        string[] ArrCities = lstrCities.Split(',');

                        int count = ArrCities.Length;

                        if (count > 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                mobjCUser.AddZoneCities(lintAdvertisementZoneID, Convert.ToInt32(ArrCities[i]));
                            }
                        }
                    }
                }

            }


            mstrResponseData = "SUCCESS";
        }
        catch (Exception ex)
        {
            mstrResponseData = "Error:" + ex.Message;
        }
    }

    #endregion AddNewAdvertisement

    #region GetAdvertisemenZoneListing
    /// <summary>
    /// Param bajwa
    /// DATE:12022014
    /// Funtion used to Get Advertisemen Zone Listing.
    /// </summary>
    private void GetAdvertisemenZoneListing()
    {
        try
        {

            StringBuilder builder = new StringBuilder("<rows>");

            string lstrReturnResult = "";
            DataSet ds = null;

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


                mobjCCommon.SetGridVariables(CConstants.enumTables.TblAdvertisementZone.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                builder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                builder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                ds = mobjCUser.GetAdvertisementZoneListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);

                if (ds != null)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        builder.Append("<row unread='" + val + "' id='chk_" + ds.Tables[0].Rows[i]["AdvertisementZoneID"].ToString() + "'>");
                        builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                       
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Title"])))
                        {
                            builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>" + "-" + "</td>]]></cell>");
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Description"])))
                        {
                            builder.Append("<cell><![CDATA[<td>" + Convert.ToString(ds.Tables[0].Rows[i]["Description"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        Int32 lAdverZoneId = Convert.ToInt32(ds.Tables[0].Rows[i]["AdvertisementZoneID"]);

                        DataSet lobjDSCities = mobjCUser.GetAdvertisementZoneCities(lAdverZoneId);

                        if (lobjDSCities != null)
                        {
                            string lstrCities = "";

                            for (int j = 0; j < lobjDSCities.Tables[0].Rows.Count; j++)
                            {
                                lstrCities += Convert.ToString(lobjDSCities.Tables[0].Rows[j]["City"]) + ", ";
                            }

                            builder.Append("<cell><![CDATA[<td>" + lstrCities.Substring(0, lstrCities.Length - 2) + "</td>]]></cell>");

                        }
                        else
                        {
                            builder.Append("<cell><![CDATA[<td>All Cities</td>]]></cell>");
                        }                    

                        builder.Append("<cell><![CDATA[<td>");
                        builder.Append("<div class=\"block-options\">");
                        builder.Append("<a class=\"btn btn-alt btn-sm btn-primary btn-option\" href='#modal-Add-Advertisement' title=\"Edit Advertisement zone\" data-toggle=\"modal\" onclick=\"return showEditAdvertisementModel(" + ds.Tables[0].Rows[i]["AdvertisementZoneID"].ToString() + ")\">" + "<i class=\"fa fa-pencil\"></i></a> &nbsp;");

                        builder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Advertisement zone\" data-toggle=\"tooltip\" onclick=\"return DeleteAdvertisementZone(" + ds.Tables[0].Rows[i]["AdvertisementZoneID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        
                        builder.Append("</div>");
                        builder.Append("</td>]]></cell>");

                        builder.Append(" </row>");
                    }

                }


                builder.Append("</rows>");

            }
            catch (Exception ex)
            {
                builder.Append("Failure : " + ex.Message);
            }

            lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
            lstrReturnResult += builder.ToString();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Write(lstrReturnResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion GetAdvertisemenZoneListing

    #region DeleteAdvertisementZone
    /// <summary>
    /// Author:Param bajwa
    /// Date:12022014
    /// Function used to delete advertisement zone
    /// </summary>
    private void DeleteAdvertisementZone()
    {
        Int32 lintAdvertisementZoneID = -1;

        try
        {
            if (Request.Form["AdvertisementZoneID"] != null)
                lintAdvertisementZoneID = Convert.ToInt32(Request.Form["AdvertisementZoneID"]);

            
            mobjCUser.DeleteAdvertisementZone(lintAdvertisementZoneID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteAdvertisement

    #region GetAdvertisementZoneDetails
    /// <summary>
    /// function to get advertisement details
    /// </summary>
    private void GetAdvertisementZoneDetails()
    {
        Int32 lintAdvertisementZoneID = -1;       
        
        StringBuilder builder = new StringBuilder("<Response><AdvertisementData>");
        try
        {
            if (Request.Form["AdvertisementZoneID"] != null)
                lintAdvertisementZoneID = Convert.ToInt32(Request.Form["AdvertisementZoneID"]);

            DataSet ds = mobjCUser.GetAdvertisementZoneDetails(lintAdvertisementZoneID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

                builder.Append("<CbIsOpen><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["IsOpen"]));
                builder.Append("]]></CbIsOpen>");

           
                Int32 lAdverZoneId = Convert.ToInt32(ds.Tables[0].Rows[0]["AdvertisementZoneID"]);

                DataSet lobjDSCities = mobjCUser.GetAdvertisementZoneCities(lAdverZoneId);
                string lstrCities = "";

                if (lobjDSCities != null)
                {                  

                    for (int j = 0; j < lobjDSCities.Tables[0].Rows.Count; j++)
                    {
                        lstrCities += Convert.ToString(lobjDSCities.Tables[0].Rows[j]["City"]) + "," + Convert.ToString(lobjDSCities.Tables[0].Rows[j]["CityID"]) + "##";
                    }

                   lstrCities = lstrCities.Substring(0, lstrCities.Length - 2);

                }

                builder.Append("<City><![CDATA[");
                builder.Append(lstrCities);
                builder.Append("]]></City>");

               
            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</AdvertisementData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetAdvertisementDetails

    #region FillZoneCombo
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:120314
    /// Function used to fill zone combo in advertisement section.
    /// </summary>
    private void FillZoneCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.FillZoneCombo();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<AdvertisementZoneID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["AdvertisementZoneID"].ToString() + "]]>");
                    lobjBuilder.Append("</AdvertisementZoneID>");

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
    #endregion FillZoneCombo

    #region GetExpertsListing
    /// <summary>
    /// Author:jasmeet kaur
    /// date:120514
    /// Function used to get experts listing.
    /// </summary>
    private void GetExpertsListing()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder("<rows>");

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

                mobjCCommon.SetGridVariables(CConstants.enumTables.TblExperts.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");

                // Function to get users listing.               
                lobjDS = mobjCUser.GetExpertsListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString);
            //   lobjDS = mobjCUser.GetExpertsListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, mdblUserID);
                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"../" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Picture"]) + "\"></td>]]></cell>");

                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + "<image class=\"img-circle\" style=\"width:50px;\" src=\"" + "../img/AnonymousGuyPic.jpg" + "\"></td>]]></cell>");

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            //onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\"
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + "-" + "</a></td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["EMail"]) + "</td>]]></cell>");
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
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Occupation"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Occupation"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        //if (Convert.ToString(lobjDS.Tables[0].Rows[i]["IsUserLoginDisabled"]) == "False" || string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["IsUserLoginDisabled"])))
                        //{
                        //    stringBuilder.Append("<img src=\"../img/Inactive.png\"  title=\"Click to mark as disbaled.\" style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" onclick=\"return MarkUserDisable(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ",'" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "','false')\" />");
                        //}
                        //else
                        //{
                        //    stringBuilder.Append("<img src=\"../img/active.png\" title=\"Click to mark as enabled.\" style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" onclick=\"return MarkUserDisable(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ",'" + lobjDS.Tables[0].Rows[i]["Full_Name"].ToString() + "','true')\" />");

                        //}
                        //if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["RssUserID"])))
                        //{
                        stringBuilder.Append("<a href='#modal-Send-Msg' title=\"Send Message\" data-toggle=\"modal\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/message.png\" onclick=\"return showSendMsgModel(" + Convert.ToString(lobjDS.Tables[0].Rows[i]["UserID"]) + ",'" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Full_Name"]) + "')\"></a>");
                        //}
                        //else
                        //{
                        //    stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\" style=\"display:none;\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/message.png\"></a>");

                        //}
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["RssUserID"])))
                        {
                            stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/Rss.png\" onclick=\"return ViewUsersRssFeed(" + lobjDS.Tables[0].Rows[i]["RssUserID"].ToString() + ")\"></a>");
                        }
                        else
                        {
                            stringBuilder.Append("<a href='#feedContainer' title=\"View Rss\" data-toggle=\"modal\" style=\"display:none;\">" + "<image style=\"margin:10px 0px 0px 10px; padding: 0px; cursor:pointer; height:26px; width: 27px; float: left;\" src=\"../img/Rss.png\"></a>");

                        }
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

    #endregion GetExpertsListing

    #region AddEditChapter
    /// <summary>
    /// Author:Jasmeet kaur
    /// date:121914
    /// Function used to add/edit chapters.
    /// </summary>
    private void AddEditChapter()
    {
        Int32 lintChapterID = -1;
        string lstrTitle = "";
        string lstrDescription = "";


        try
        {
            if (Request.Form["ChapterID"] != null)
                lintChapterID = Convert.ToInt32(Request.Form["ChapterID"]);

            if (Request.Form["Title"] != null)
                lstrTitle = Convert.ToString(Request.Form["Title"]);

            if (Request.Form["Description"] != null)
                lstrDescription = Convert.ToString(Request.Form["Description"]);

            //#A Jasmeet: 052814 - add category
            string lstr = mobjCUser.AddEditChapter(lintChapterID, lstrTitle, lstrDescription, mdblUserID);
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

    #endregion AddEditChapter

    #region GetChaptersListing
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:121914
    /// Function used to get chapters listing.
    /// </summary>
    private void GetChaptersListing()
    {
        try
        {

            StringBuilder stringBuilder = new StringBuilder("<rows>");

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
            Int32 lintUserID = -1;
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

                mobjCCommon.SetGridVariables(CConstants.enumTables.TblChapters.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                lobjDS = mobjCUser.GetChaptersListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString,mdblUserID);

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Title"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowSubtitleBlock(" + lobjDS.Tables[0].Rows[i]["ChapterID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Title"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Author"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Author"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + "-" + "</a></td>]]></cell>");
                        }
                        
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        stringBuilder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete Chapters\" data-toggle=\"tooltip\" onclick=\"return DeleteChapters(" + lobjDS.Tables[0].Rows[i]["ChapterID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        stringBuilder.Append("<a href='#modal-Add-Chapter' title=\"Edit Chapter\" data-toggle=\"modal\" onclick=\"return showEditChapterModel(" + lobjDS.Tables[0].Rows[i]["ChapterID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
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

    #endregion GetChaptersListing

    #region DeleteChapters
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:121914
    /// Function used to delete chapters.
    /// </summary>
    private void DeleteChapters()
    {
        Int32 lintChapterID = -1;

        try
        {
            if (Request.Form["ChapterID"] != null)
                lintChapterID = Convert.ToInt32(Request.Form["ChapterID"]);
            //#A Jasmeet: 122214 - delete course
            mobjCUser.DeleteChapters(lintChapterID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion DeleteChapters

    #region GetChapterDetails
    private void GetChapterDetails()
    {
        Int32 lintChapterID = -1;

        StringBuilder builder = new StringBuilder("<Response><ChapterData>");
        try
        {
            if (Request.Form["ChapterID"] != null)
                lintChapterID = Convert.ToInt32(Request.Form["ChapterID"]);
            //#A Jasmeet: 121914 - GetChapterDetails

            DataSet ds = mobjCUser.GetChapterDetails(lintChapterID);
            if (ds != null)
            {
                builder.Append("<Title><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Title"]));
                builder.Append("]]></Title>");

                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</ChapterData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetChapterDetails

    #region AddEditSubTitles
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:121914
    /// Function used to add/edit sub titles.
    /// </summary>
    private void AddEditSubTitles()
    {
        string lstrTitle = "";
        string lstrDescription = "";
        string lstrYoutubeUrl = "";
        string lstrUrlLink = "";
        string lstrDocument = "";
        bool lbnIsPaid =false;
        Int32 lintChapterID = -1;
        Int32 lintSubTitleID = -1;
        try
        {

            if (Request.Form["SubTitle"] != null)
                lstrTitle = Convert.ToString(Request.Form["SubTitle"]);

            if (Request.Form["Description"] != null)
                lstrDescription = Convert.ToString(Request.Form["Description"]);

            if (Request.Form["PdfDocument"] != null)
                lstrDocument = Convert.ToString(Request.Form["PdfDocument"]);

            if (Request.Form["YoutubeURL"] != null)
                lstrYoutubeUrl = Convert.ToString(Request.Form["YoutubeURL"]);

            if (Request.Form["URL"] != null)
                lstrUrlLink = Convert.ToString(Request.Form["URL"]);

            if (Request.Form["ChapterID"] != null)
                lintChapterID = Convert.ToInt32(Request.Form["ChapterID"]);

            if (Request.Form["SubTitleID"] != null)
                lintSubTitleID = Convert.ToInt32(Request.Form["SubTitleID"]);

            if (Request.Form["IsPaid"] != null)
                lbnIsPaid = Convert.ToBoolean(Request.Form["IsPaid"]);

            string lstr = mobjCUser.AddEditSubTitles(lstrTitle, lstrDescription, lstrDocument, lstrYoutubeUrl, lstrUrlLink, lintChapterID, lintSubTitleID, mdblUserID, lbnIsPaid);
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

    #endregion AddEditSubTitles

    #region GetCourseName
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:122214
    /// Function used to get Course Name.
    /// </summary>
    private void GetCourseName()
    {
        Int32 lintChapterID = -1;

        StringBuilder builder = new StringBuilder();
        try
        {
            if (Request.Form["ChapterID"] != null)
            {
                lintChapterID = Convert.ToInt32(Request.Form["ChapterID"]);
            }
            //#A Jasmeet: 122214 - Get course name

            DataSet ds = mobjCUser.GetCourseName(lintChapterID);
            if (ds != null)
            {
                builder.Append(ds.Tables[0].Rows[0]["Title"].ToString());

            }
        }
        catch (Exception)
        {

            throw;
        }
        mstrResponseData = builder.ToString();
    }

    #endregion GetCourseName

    #region GetCourseSubTitlesListing

    private void GetCourseSubTitlesListing()
    {
        try
        {

            StringBuilder stringBuilder = new StringBuilder("<rows>");

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
            Int32 lintUserID = -1;
            Int32 lintChapterID = -1;
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
                if (Request.QueryString["ChapterID"] != null)
                {
                    lintChapterID = Convert.ToInt32(Request.QueryString["ChapterID"]);
                    mobjCCommon.ChapterID = lintChapterID;
                }

                mobjCCommon.SetGridVariables(CConstants.enumTables.TblSubTitles.ToString(), ref ldblTotalRowsCount, ref ldblPageNo, ref ldblStartIndex, ref ldblEndIndex, ref lstrSortParameter, ref lstrSortOrder, ref lstrSearchColumn, ref lstrSearchString);

                stringBuilder.Append("<page>" + ldblPageNo.ToString() + "</page>");
                stringBuilder.Append("<total>" + ldblTotalRowsCount.ToString() + "</total>");


                lobjDS = mobjCUser.GetCourseSubTitlesListing(ldblStartIndex, ldblEndIndex, lstrSortParameter, lstrSortOrder, lstrSearchColumn, lstrSearchString, mdblUserID, lintChapterID);

                if (lobjDS != null)
                {

                    for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                    {
                        string val = "false";

                        if (i % 2 == 0)
                            val = "true";
                        else
                            val = "false";


                        stringBuilder.Append("<row unread='" + val + "' id='chk_" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + "'>");
                        stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Row"]) + "</td>]]></cell>");
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["SubTitle"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["SubTitle"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                    
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["YoutubeURL"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href=\"" + Convert.ToString(lobjDS.Tables[0].Rows[i]["YoutubeURL"])+ "\" target='_blank'>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["YoutubeURL"]) + "</a></td>]]></cell>");

                       
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["PdfDocument"])))
                        {
                            
                            string path = Convert.ToString(lobjDS.Tables[0].Rows[i]["PdfDocument"]);
                            string fileName = path.Split(new char[] { '\\', '/' }).Last();
                            stringBuilder.Append("<cell><![CDATA[<td><a href=\"" + Convert.ToString(lobjDS.Tables[0].Rows[i]["PdfDocument"]) + "\" target='_blank'>" + fileName + "</a></td>]]></cell>");


                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["URL"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href=\"" + Convert.ToString(lobjDS.Tables[0].Rows[i]["URL"]) + "\" target='_blank'>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["URL"]) + "</a></td>]]></cell>");


                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Author"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Author"]) + "</a></td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td><a href='#modal-regular-Profile' data-toggle=\"modal\" Style=\"color:#f31455\"  data-toggle=\"modal\"  onclick=\"return ShowProfileModal(" + lobjDS.Tables[0].Rows[i]["UserID"].ToString() + ")\">" + "-" + "</a></td>]]></cell>");
                        }
                       
                        if (!string.IsNullOrEmpty(Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"])))
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>" + Convert.ToString(lobjDS.Tables[0].Rows[i]["Description"]) + "</td>]]></cell>");
                        }
                        else
                        {
                            stringBuilder.Append("<cell><![CDATA[<td>-</td>]]></cell>");
                        }

                        stringBuilder.Append("<cell><![CDATA[<td class=\"text-center\">");
                        stringBuilder.Append("<div class=\"block-options\">");
                        stringBuilder.Append("<a class=\"btn btn-alt btn-sm btn-danger btn-option\" title=\"Delete SubTitles\" data-toggle=\"tooltip\" onclick=\"return DeleteSubTitles(" + lobjDS.Tables[0].Rows[i]["SubTitleID"].ToString() + ")\" data-original-title=\"Delete\">" + "<i class=\"fa fa-times\"></i>" + "</a>");
                        stringBuilder.Append("<a href='#modal-Add-SubTitles' title=\"Edit SubTitles\" data-toggle=\"modal\" onclick=\"return ShowEditSubTitlesModel(" + lobjDS.Tables[0].Rows[i]["SubTitleID"].ToString() + ")\">" + "<image style=\"width:30px;margin:10px;\" src=\"../user/img/pencil-icon.png\"></a>");
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

    #endregion GetCourseSubTitlesListing

    #region GetSubTitleDetails
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:122314
    /// Function used to get details of sub titles of selected course for editing.
    /// </summary>
    private void GetSubTitleDetails()
    {
        Int32 lintSubTitleID = -1;

        StringBuilder builder = new StringBuilder("<Response><SubTitleData>");
        try
        {
            if (Request.Form["SubTitleID"] != null)
                lintSubTitleID = Convert.ToInt32(Request.Form["SubTitleID"]);
            //#A Jasmeet: 122314 - GetSubTitleDetails

            DataSet ds = mobjCUser.GetSubTitleDetails(lintSubTitleID);
            if (ds != null)
            {
                builder.Append("<SubTitle><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["SubTitle"]));
                builder.Append("]]></SubTitle>");

                builder.Append("<Description><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Description"]));
                builder.Append("]]></Description>");

                builder.Append("<PdfDocument><![CDATA[");
                string path = Convert.ToString(ds.Tables[0].Rows[0]["PdfDocument"]);
                string extension = Path.GetExtension(path);
                string filename = Path.GetFileName(path);
                builder.Append(filename);
                builder.Append("]]></PdfDocument>");
           
                builder.Append("<YoutubeURL><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["YoutubeURL"]));
                builder.Append("]]></YoutubeURL>");

                builder.Append("<URL><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["URL"]));
                builder.Append("]]></URL>");

                builder.Append("<ISPAID><![CDATA[");
                builder.Append(Convert.ToBoolean(ds.Tables[0].Rows[0]["ISPAID"]));
                builder.Append("]]></ISPAID>");

            }
        }
        catch (Exception)
        {

            throw;
        }
        builder.Append("</SubTitleData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }

    #endregion GetSubTitleDetails

    #region DeleteSubTitle
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:122314
    /// Function used to delete subtitles.
    /// </summary>
    private void DeleteSubTitle()
    {
        Int32 lintSubTitleID = -1;

        try
        {
            if (Request.Form["SubTitleID"] != null)
                lintSubTitleID = Convert.ToInt32(Request.Form["SubTitleID"]);
            //#A Jasmeet: 122314 - delete SubTitle
            mobjCUser.DeleteSubTitle(lintSubTitleID);

            mstrResponseData = "SUCCESS";
        }
        catch (Exception)
        {

            throw;
        }
    }


    #endregion DeleteSubTitle

    #region GetAllCourses

    private void GetAllCourses()
    {
        StringBuilder builder = new StringBuilder();

        try
        {

            DataSet ds = mobjCUser.GetAllCourses();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        builder.Append("<div class=\"col-sm-3\">");

                        builder.Append("<div class=\"widget\">");
                        builder.Append("<div class=\"widget-advanced\">");

                        builder.Append("<div class=\"widget-header text-center themed-background-dark-bgCourse\">");
                        builder.Append("<h3 class=\"widget-content-light\">");
                        builder.Append("<a href='Lessons.aspx?i=" + Convert.ToString(ds.Tables[0].Rows[i]["ChapterID"]) + "' class=\"themed-color-bg\">" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]) + "</a><br>");
                        if (ds.Tables[0].Rows[i]["Description"].ToString() != "")
                        {
                            string lstrDescription = ds.Tables[0].Rows[i]["Description"].ToString();
                            if (lstrDescription.Length < 30)
                            {
                                builder.Append("<small>" + lstrDescription + "</small></h3> </div>");
                            }
                            else
                            {
                                builder.Append("<small>" + lstrDescription.Substring(0, 20) + "</small></h3></div>");
                               }
                        }
                        else
                        {
                            builder.Append("<small></small></h3></div>");
                        }
                        
                        builder.Append("<div class=\"widget-main\">");
                        builder.Append("<a href='#' class=\"widget-image-container animation-fadeIn\">");
                        builder.Append("<span class=\"widget-icon themed-background-bg\"><i class=\"fa fa-globe\"></i></span></a>");
                        builder.Append("<a href='Lessons.aspx?i=" + Convert.ToString(ds.Tables[0].Rows[i]["ChapterID"]) + "' class=\"btn btn-sm btn-default pull-right\">" + Convert.ToString(ds.Tables[0].Rows[i]["TotalLessons"]) + " Lessons</a>");
                        builder.Append("<a href='#' class=\"btn btn-sm\"></a></div></div>");
                        builder.Append("</div></div>");



                    }
                }
            }
        }

        catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetAllCourses

    #region GetAllLessons
    /// <summary>
    /// Author:Jasmeet Kaur
    /// Date:010514
    /// Function used to get all lenssons of selected course.
    /// </summary>
    private void GetAllLessons()
    {
         StringBuilder builder = new StringBuilder();
         Int32 lintChapterID = -1;
         if (Request.Form["ChapterID"] != null)
         {
             lintChapterID = Convert.ToInt32(Request.Form["ChapterID"]);
         }
         try
        {
            DataSet ds = mobjCUser.GetAllLessons(lintChapterID);
            if (ds != null)
            {
                builder.Append("<div id=\"page-content\" style=\"min-height:400%;\">");
                builder.Append("<div class=\"content-header\">");
                builder.Append("<div class=\"header-section\">");
                builder.Append("<h1><i class=\"fa fa-globe\"></i>" + Convert.ToString(ds.Tables[0].Rows[0]["Course"]) + "</h1></div></div>");
                builder.Append("<ul class=\"breadcrumb breadcrumb-top\"><li>Pages</li><li>Education</a></li><li><a href='Courses.aspx'>Courses</a></li><li><a href='#'>" + Convert.ToString(ds.Tables[0].Rows[0]["Course"]) + "</a></li></ul>");
                builder.Append("<div class=\"row\">");
                builder.Append("<div class=\"col-md-12\">");
                builder.Append("<div class=\"widget\">");
                builder.Append("<div class=\"widget-advanced\">");
                builder.Append("<div class=\"widget-header text-center themed-background-dark\">");
                builder.Append("<h3 class=\"widget-content-light\">");
                builder.Append("<a style=\"text-decoration:none;\">" + Convert.ToString(ds.Tables[0].Rows[0]["Course"]) + "</a><br/>");
                if (ds.Tables[0].Rows[0]["CourseDesc"].ToString() != "")
                {
                    string lstrDescription = ds.Tables[0].Rows[0]["CourseDesc"].ToString();
                    if (lstrDescription.Length < 30)
                    {
                        builder.Append("<small>" + lstrDescription + "</small></h3></div>");
                    }
                    else
                    {
                        builder.Append("<small>" + lstrDescription.Substring(0, 20) + "</small></h3></div>");
                    }
                }
                else
                {
                    builder.Append("<small></small></h3></div>");
                }
                        
                
                builder.Append("<div class=\"widget-main\">");
                builder.Append("<a href='#' class=\"widget-image-container animation-fadeIn\">");
                builder.Append("<span class=\"widget-icon themed-background\"><i class=\"fa fa-globe\"></i></span></a>");
                builder.Append("<a href='#' class=\"btn btn-sm btn-default pull-right\">" + Convert.ToString(ds.Tables[0].Rows[0]["TotalLessons"]) + " Lessons</a>");
                builder.Append("<a href='#' class=''></a></div>");
                if (ds.Tables[1].Rows.Count > 0)
                {

                    builder.Append("<table class=\"table table-vcenter\"><thead>");
                    builder.Append("<tr class=\"active\">");
                    builder.Append("<th>" + Convert.ToString(ds.Tables[0].Rows[0]["Course"]) + "</th>");
                    builder.Append("<th class=\"text-right\"></th></tr></thead>");
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["PdfDocument"])) && !string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"])))
                        {
                            builder.Append("<tbody><tr><td><a style=\"text-decoration:none;\">" + (i + 1) + " " + Convert.ToString(ds.Tables[1].Rows[i]["SubTitle"]) + "</a></td>");
                            builder.Append("<td class=\"text-right\"><a href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["PdfDocument"]) + "\" class=\"btn btn-xs btn-primary\" target='_blank' style=\"margin-right:2%;\"><i class=\"fa fa-download\"></i>Download</a><span></span><a href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["YoutubeURL"]) + "\" target='_blank' class=\"btn btn-xs btn-primary\" ><i class=\"fa fa-play\"></i>Start</a></td>");
                            builder.Append("</tr>");
                            builder.Append("</tbody>");
                      
                        }
                        else if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["PdfDocument"])) && string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"])))
                        {
                            builder.Append("<tbody><tr><td><a style=\"text-decoration:none;\">" + (i + 1) + " " + Convert.ToString(ds.Tables[1].Rows[i]["SubTitle"]) + "</a></td>");
                            builder.Append("<td class=\"text-right\"><a href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["PdfDocument"]) + "\" class=\"btn btn-xs btn-primary\" target='_blank' ><i class=\"fa fa-download\"></i>Download</a></td>");
                            builder.Append("</tr>");
                            builder.Append("</tbody>");
                        }
                        else if (string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["PdfDocument"])) && !string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"])))
                        {
                            builder.Append("<tbody><tr><td><a style=\"text-decoration:none;\">" + (i + 1) + " " + Convert.ToString(ds.Tables[1].Rows[i]["SubTitle"]) + "</a></td>");
                            builder.Append("<td class=\"text-right\"><a href=\"" + Convert.ToString(ds.Tables[1].Rows[i]["YouTubeURL"]) + "\" target='_blank' class=\"btn btn-xs btn-primary\" ><i class=\"fa fa-play\"></i>Start</a></td>");
                            builder.Append("</tr>");
                            builder.Append("</tbody>");
                        }
                    }
                    builder.Append("</table>");
                }
                else
                {
                    builder.Append("<div style=\"margin-left:5%;margin-top:2%;width:70%;\"><h5><b>No lessons found under this course.</b></h5></div>");
                }
                builder.Append("</div>");
                builder.Append("</div>");
                builder.Append("</div>");
                builder.Append("</div>");
                builder.Append("</div>");
               
            }
        }
          catch (Exception ex)
        {
            mstrResponseData = "Error: " + ex.Message;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion GetAllLessons

    #region PostEventToGoogleCalendar
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:012915
    /// Function used to post calendar event to google calandar
    /// </summary>
    private void PostEventToGoogleCalendar()
    {
     
    }

    #endregion PostEventToGoogleCalendar

    #region FillStatusCombo
    /// <summary>
    /// Author:Jasmeet kaur
    /// Date:092614
    /// Function used to fill state combo
    /// </summary>

    private void FillStatusCombo()
    {
        DataSet lobjDS = new DataSet();
        StringBuilder lobjBuilder = new StringBuilder("<Response>");
        string lstrReturnResult = "";

        try
        {

            lobjDS = mobjCUser.FillStatusCombo();

            if (lobjDS != null)
            {

                for (int i = 0; i < lobjDS.Tables[0].Rows.Count; i++)
                {
                    lobjBuilder.Append("<Contents>");

                    lobjBuilder.Append("<Title>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["Title"].ToString() + "]]>");
                    lobjBuilder.Append("</Title>");

                    lobjBuilder.Append("<StatusID>");
                    lobjBuilder.Append("<![CDATA[" + lobjDS.Tables[0].Rows[i]["StatusID"].ToString() + "]]>");
                    lobjBuilder.Append("</StatusID>");

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

    #endregion FillStatusCombo

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
}
    #endregion

