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
using payment_cc;

public partial class User_Ajax_AjaxCustomers : System.Web.UI.Page
{
    #region Module Level Objects

    DataAccess mobjDataAccess = new DataAccess();
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    CCustomers mobjCCustomer = new CCustomers(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    CCommon mobjCCommon = new CCommon(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string mstrDomainName = WebConfigurationManager.AppSettings["DomainName"].ToString();
    string mstrResponseData = "";


    cls_payment_req_response_prp pay_obj_prp = new cls_payment_req_response_prp();
    cls_payment_req_response pay_obj = new cls_payment_req_response();

    #endregion


    #region Module Level Variables
    string lstrReqID = "";
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
    public string valEmail { get; set; }
    public string ReqID { get; set; }

    string PlanID = "";
    #endregion

    #region Page_Load

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

                if (Request.Form["ValEmail"] != null)
                {
                    valEmail = Request.Form["valEmail"].ToString();
                }
                if (Request.Form["PReqID"] != null)
                {
                    lstrReqID = Request.Form["PReqID"].ToString();
                }

                if (Request.Form["PlanID"] != null)
                {

                    PlanID = Request.Form["PlanID"].ToString();
                }

            }


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



    #endregion Page_Load

    #region GenerateData

    private void GenerateData(string lstrMod)
    {
        switch (lstrMod.ToUpper())
        {
           
            case "PLANGETINFO":
                {
                    try
                    {

                        PlanGetInfo();
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

    #region  PlanGetInfo

    private void PlanGetInfo()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            DataSet lobjds = pay_obj.PlanGetInfo(PlanID);
            if (lobjds != null)
            {
                                  
                if (lobjds.Tables[0].Rows[0]["PlanID"].ToString() == "1111")
                {
                builder.Append("<div class='plan-panel basic-plan'>");
                }
                else{
                builder.Append(" <div class='plan-panel pro-plan'>");      
                }            
                builder.Append("<div class='plan-header'>");
                builder.Append("<h3> " + lobjds.Tables[0].Rows[0]["PlanName"].ToString() + "</h3>");
                builder.Append("<span>$" +Math.Round(Convert.ToDecimal(lobjds.Tables[0].Rows[0]["Amount"]),2).ToString() + "<small>/mo</small></span></div>");

                builder.Append("<ul class='plan-features'>");
                for (int i = 0; i < lobjds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<li>" + lobjds.Tables[0].Rows[i]["PlanDes"].ToString() + "</li>");
                }

                builder.Append("</ul>");
                builder.Append(" <div class='plan-cta'>");

                if (lobjds.Tables[0].Rows[0]["PlanID"].ToString() == "1111")
                {
                    builder.Append(" <a id='silver-signup-link' href='pay/BasicPlan.html' data-featurette='analytics-click-event' data-event-label='Source: Plans Page' data-event-category='button' data-event-action='M: Clicked Basic' class='button button-primary full'>Click To Pay Now</a>");
                }
                else if (lobjds.Tables[0].Rows[0]["PlanID"].ToString() == "2222")
                {
                    builder.Append("  <a id='gold-signup-link' href='pay/ProPlan.html' data-featurette='analytics-click-event' data-event-label='Source: Plans Page' data-event-category='button' data-event-action='M: Clicked Pro' class='button button-primary full'>Click To Pay Now</a>");
                }
                builder.Append("</div>");
                builder.Append("</div>");

            }
        }
        catch (Exception)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion PlanGetInfo


    #endregion Function



}