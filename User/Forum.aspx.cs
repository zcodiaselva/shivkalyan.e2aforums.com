using E2aForums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_pro : System.Web.UI.Page
{
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string mstrResponseData = "";
    double mdblUserID = -1;
    public bool IsAdmin { get; set; }
    public string Mode { get; set; }
    public int TopicID { get; set; }
    public int UserTypeID = -1;
    public string Topic { get; set; }
    public int OccupationID { get; set; }
    public int CategoryID { get; set; }
    public int ID { get; set; }
    public int PostID { get; set; }
    public bool lbnIsPostID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Response.Redirect("index.aspx");
        mobjCUser.ValidateUser();
        if (Session["UserID"] != null)
            mdblUserID = Convert.ToDouble(Session["UserID"]);

        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }
        if (Session["OccupationID"] != null)
        {
            OccupationID = Convert.ToInt32(Session["OccupationID"]);
            //Session["OccupationID"] = mobjCUser.OccupationID;
            //OccupationID = mobjCUser.OccupationID; 
        }

        if (Session["IsAdmin"] != null)
        {
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        }
        else
            IsAdmin = false;

        lbnIsPostID = false;

        if (Request.QueryString["post_id"] != null)
        {
            lbnIsPostID = true;
            Int32 lintTopicID = -1;
            try
            {
                if (Request.QueryString["TopicID"] != null)
                    lintTopicID = Convert.ToInt32(Request.QueryString["TopicID"]);

                mobjCUser.ShareTopic(mdblUserID, lintTopicID);
                return;
                // mstrResponseData = "SUCCESS";
            }
            catch (Exception)
            {
                throw;
            }
        }


        if (Request.Form["Mode"] != null)
            Mode = Convert.ToString(Request.Form["Mode"]);
        if (Mode == "ShowTopic" || Mode == "LikeTopic")
        {
            if (Request.Form["TopicID"] != null)
                TopicID = Convert.ToInt32(Request.Form["TopicID"]);

            if (Request.Form["Topic"] != null)
            {
                Topic = Convert.ToString(Request.Form["Topic"]);
            }
            if (Request.Form["CategoryID"] != null)
            {
                CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            }
            if (Request.Form["ID"] != null)
            {
                ID = Convert.ToInt32(Request.Form["ID"]);
            }


        }

    }

}