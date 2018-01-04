using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using E2aForums;
using System.Web.Configuration;
public partial class User_pro : System.Web.UI.Page
{
   
    double mdblUserID = -1;
    public String lUserID { get; set; }
    public bool IsAdmin { get; set; }
    public int UserTypeID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserID"] != null)
        {
            mdblUserID = Convert.ToDouble(Session["UserID"]);
            lUserID = Session["UserID"].ToString();
        }
        if (Session["IsAdmin"] != null)
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        else
            IsAdmin = false;
        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }
       
        if (!IsPostBack)
        {
            BindDummyItem();
        }
    }

  public void BindDummyItem()
    {
        
       
           DataTable dtGetData = new DataTable();
           dtGetData.Columns.Add("Topic");
           dtGetData.Columns.Add("TopicView");
           dtGetData.Columns.Add("Replies");
           dtGetData.Columns.Add("LastPostUser");
           dtGetData.Rows.Add();

           grdDemo.DataSource = dtGetData;
           grdDemo.DataBind();
       }

       [WebMethod]
      
        public static DetailsClass[] GetData(string UID) //GetData function
      {
          CUser mobjCUser2 = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
          DataSet ds2 = mobjCUser2.GetMyForumTopic(Convert.ToInt32(UID));
          List<DetailsClass> Detail = new List<DetailsClass>();
           foreach(DataRow dtRow in ds2.Tables[0].Rows)
           {
               DetailsClass DataObj = new DetailsClass();
               DataObj.Topic = dtRow["Topic"].ToString();
               DataObj.Description = dtRow["Description"].ToString();
               if (dtRow["TopicView"].ToString() == "")
               {
                   DataObj.TopicView = "0";
               }
               else
               {
                   DataObj.TopicView = dtRow["TopicView"].ToString();
               }

               if (dtRow["Replies"].ToString() == "")
               {
                   DataObj.Replies = "0";
               }
               else
               {
                   DataObj.Replies = dtRow["Replies"].ToString();
               }
               if (dtRow["LastPostUser"].ToString()=="")
                  {
                  DataObj.LastPostUser = "-";
               }
               else
	            {
                    DataObj.LastPostUser = dtRow["LastPostUser"].ToString();
	            }
               
               Detail.Add(DataObj);
           }

           return Detail.ToArray();
       }
       public class DetailsClass //Class for binding data
       {  
           public string Topic { get; set; }
           public string Description { get; set; }
           public string TopicView { get; set; }
           public string Replies { get; set; }
           public string LastPostUser { get; set; }
           

       }


       [WebMethod]
       public static CountryDetails[] BindDatatoDropdown(String UID, string ISADMIN)
       {
           CUser mobjCUser2 = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
           DataSet ds2 = mobjCUser2.GetRssFeedList(Convert.ToInt32(UID),ISADMIN);
           List<CountryDetails> details = new List<CountryDetails>();
           foreach (DataRow dtrow in ds2.Tables[0].Rows)
                   {

                       //builder.Append("<a class=\"tooltip\" title='" + ds.Tables[0].Rows[i]["Title"].ToString() + "' href='#' onclick=\"return GetRssFeedDetails('" + (Convert.ToString(ds.Tables[0].Rows[i]["URL"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(ds.Tables[0].Rows[i]["URL"]) : Convert.ToString(ds.Tables[0].Rows[i]["URL"])) + "'," + Convert.ToString(ds.Tables[0].Rows[i]["RssFeedID"]) + ")\">");
                       // builder.Append("<i class=\"fa fa-angle-right fa-fw\"></i> <strong>" + Convert.ToString(ds.Tables[0].Rows[i]["Title"]).Substring(0, 9) + "..." + "</strong>");
                       CountryDetails country = new CountryDetails();
                       country.RssId = Convert.ToInt32(dtrow["RssFeedID"].ToString());
                      country.RssName = "<a class=\"tooltip\" title='" + dtrow["Title"].ToString() + "' href='#' onclick=\"return GetRssFeedDetails('" + (Convert.ToString(dtrow["URL"]).IndexOf("http") == -1 ? "http://" + Convert.ToString(dtrow["URL"]) : Convert.ToString(dtrow["URL"])) + "'," + Convert.ToString(dtrow["RssFeedID"]) + ")\">" +dtrow["Title"].ToString() ;
                      // country.RssName = dtrow["Title"].ToString();
                       details.Add(country);
                   }
           
           return details.ToArray();
       }
       public class CountryDetails
       {
           public int RssId { get; set; }
           public string RssName { get; set; }
       }

}