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
            

            case "USERPAYVALIDATE":
                {
                    try
                    {

                        UserPayValidate();
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


    #region USERPAYVALIDATE

    private void UserPayValidate()
    {

        DataSet ds = new DataSet();
        StringBuilder builder = new StringBuilder("<Response><UserData>");
        try
        {
            ds = pay_obj.UserPayValidate(valEmail); ;
            if (ds != null)
            {
                builder.Append("<Full_Name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                builder.Append("]]></Full_Name>");


                builder.Append("<EMail><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["EMail"]));
                builder.Append("]]></EMail>");


                builder.Append("<Picture><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Picture"]));
                builder.Append("]]></Picture>");

                builder.Append("<Flag><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Flag"]));
                builder.Append("]]></Flag>");



                builder.Append("<ReqID><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["ReqID"]));
                builder.Append("]]></ReqID>");
            }

        }
        catch (Exception)
        {

            
        }

        builder.Append("</UserData></Response>");
        string lstrReturnResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n ";
        lstrReturnResult += builder.ToString();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/xml";

        mstrResponseData = lstrReturnResult;
    }



    #endregion USERPAYVALIDATE

 

    #endregion Function


   
}