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
using NewsLetter;
//using Google.GData.Calendar;

public partial class User_Ajax_AjaxUser : System.Web.UI.Page
{
    cls_newslatter_prp obj_news_prp = new cls_newslatter_prp();
    cls_NEWSLATTER_CLs obj_news = new cls_NEWSLATTER_CLs();

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

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string lstrMod = "";
            if (Request.RequestType.ToUpper() == "POST")
            {

                if (Request.Form["Mode"] != null)
                {
                    lstrMod = Request.Form["Mode"].ToString();
                }
            }


            if (Request.QueryString["Mode"] != null)
            {
                lstrMod = Request.QueryString["Mode"].ToString();
            }


            GenerateData(lstrMod);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        Response.Write(mstrResponseData);
        Response.Flush();
        Response.End();

    }
    #endregion Page Load

    #region GenerateData

    private void GenerateData(string pstrMod)
    {
        switch (pstrMod.ToUpper())
        {
            case "EMAILNEWSLATTER":
                {
                    try
                    {
                        //#A:Sahil:072314 - Calling function to add user detail
                        AddNewsLatter();
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

            case "DELETEPOST":
                {
                    try
                    {
                        //#A:Jasmeet kaur:041415 - Calling function to delete Seclected post..
                        //  DeleteSelectedPost();
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
                        // DeletePostComments();
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

    #region AddNewsLatter

    private void AddNewsLatter()
    {
     
            try
            {
                string EMAILNEWSLATTER = "";
                if (Request.Form["EMAILNEWSLATTER"] != null)
                    EMAILNEWSLATTER = (Request.Form["EMAILNEWSLATTER"]).ToString();
                   obj_news_prp.EMAil = EMAILNEWSLATTER;
                Int32 outpram = obj_news.save_newLatter(obj_news_prp);
                if (outpram == -1)
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

    #endregion AddNewsLatter

    #region ViewUserProfile
    /// <summary>
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
                    builder.Append("<image style=\"width:100px;\" onerror=\"this.onerror=null;this.src='E2Forums-New/img/default_profile_pic.jpg';\" src=\"" + Convert.ToString(ds.Tables[0].Rows[0]["Picture"]) + "\">");
                }
                else
                {
                    builder.Append("<image style=\"width:100px;\" onerror=\"this.onerror=null;this.src='E2Forums-New/img/default_profile_pic.jpg';\" src=\"../img/AnonymousGuyPic.jpg\">");
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


    #endregion

}

  

