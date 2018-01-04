using E2aForums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class User_pro : System.Web.UI.Page
{
   
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
    public double hmdblUserID { get; set; }
    public string PlanActivel { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {



        CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
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

        if (Session["PlanActive"] != null)
        {
            PlanActivel = Session["PlanActive"].ToString();
        }
        else
        {
            PlanActivel = "-1";
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
    [WebMethod]
    public static string InsertData(string lstrTitle, string lintCategoryID, string lintTopicID ,string emp_id)
    {
        CUser mobjCUser2 = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        string msg = string.Empty;


        string lstrDescription = "";
      
        bool lblnIsFlagged = false;


        string lstr = mobjCUser2.AddNewTopic(lstrTitle, lstrDescription, Convert.ToInt32(lintCategoryID), Convert.ToInt32(lintTopicID), lblnIsFlagged, Convert.ToDouble(emp_id));

        if (lstr.ToUpper() == "ALREADY EXISTS")
        {
            msg = "ALREADY EXISTS";

        }
        else
        {

            msg = "SUCCESS";
           

        }

        return msg;
    }
    protected void btnAddTopic_Click(object sender, EventArgs e)
    {
        Response.Redirect("topic_add_new.aspx?abc=" + "Forum_new.aspx");
    }
}