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
public partial class User_Ajax_dev_index : System.Web.UI.Page
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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

            case "GETINDEXCOUNT":
                {
                    try
                    {
                        //#A:Sahil:072514 - Calling function to get user details
                        GetIndexCount();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETTOPBARCOUNT":
                {
                    try
                    {
                        //#A:Sahil:072514 - Calling function to get user details
                        GetTopBarCount();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;
            /// devsortc



            default:
                mstrResponseData = "Invalid mode";
                break;


        }
    }


    #endregion GenerateData

    #region Functions
    #region GetIndexCount
   
    /// Function used to get Index Page details
   
    public void GetIndexCount()
    {
        DataSet ds = null;
        StringBuilder builder = new StringBuilder("<Response><AdminData>");
        try
        {
            ds = mobjCUser.GetIndexCount(mdblUserID);

            if (ds != null)
            {
                builder.Append("<TotalThread><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["TotalThread"]));
                builder.Append("]]></TotalThread>");

                builder.Append("<TotalMessage><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[1].Rows[0]["TotalMessage"]));
                builder.Append("]]></TotalMessage>");


                builder.Append("<TotalEvent><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[2].Rows[0]["TotalEvent"]));
                builder.Append("]]></TotalEvent>");


                builder.Append("<TotalCust><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[3].Rows[0]["TotalCust"]));
                builder.Append("]]></TotalCust>");

                builder.Append("<TotalCustOpen><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[4].Rows[0]["TotalCustOpen"]));
                builder.Append("]]></TotalCustOpen>");

                builder.Append("<TotalCustPre><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[5].Rows[0]["TotalCustPre"]));
                builder.Append("]]></TotalCustPre>");

                builder.Append("<TotalCustQualified><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[6].Rows[0]["TotalCustQualified"]));
                builder.Append("]]></TotalCustQualified>");

                builder.Append("<TotalCustDisqualified><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[7].Rows[0]["TotalCustDisqualified"]));
                builder.Append("]]></TotalCustDisqualified>");

                builder.Append("<TotalCustClosed><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[8].Rows[0]["TotalCustClosed"]));
                builder.Append("]]></TotalCustClosed>");

                builder.Append("<TotalNot><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[9].Rows[0]["TotalNot"]));
                builder.Append("]]></TotalNot>");

                builder.Append("<count_event><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[10].Rows[0]["count_event"]));
                builder.Append("]]></count_event>");
                
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
    #endregion GetIndexCount


    #region GetTopBarCount

    /// Function used to get Index Page details

    public void GetTopBarCount()
    {
        DataSet ds = null;
        StringBuilder builder = new StringBuilder("<Response><AdminData>");
        try
        {
            ds = mobjCUser.GetTopBarCount(mdblUserID);

            if (ds != null)
            {
                

                builder.Append("<TotalMessage><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["TotalMessage"]));
                builder.Append("]]></TotalMessage>");

                builder.Append("<TotalNot><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[1].Rows[0]["TotalNot"]));
                builder.Append("]]></TotalNot>");

                builder.Append("<count_event><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[2].Rows[0]["count_event"]));
                builder.Append("]]></count_event>");
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
    #endregion GetTopBarCount

    #endregion
}