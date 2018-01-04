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
            case "GETPAYMENTDETAILS":
                {
                    try
                    {

                        GetPaymentDetails();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETPAYMENTPROFILE":
                {
                    try
                    {

                        GetPaymentProfile();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            case "GETPAYMENTDETAILSMY":
                {
                    try
                    {

                        GetPaymentDetailsMy();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

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



            case "GETPAYMENTDETAILSREQID":
                {
                    try
                    {

                        GetPaymentDetailsReqID();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

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

            case "GETPLANLOG":
                {
                    try
                    {

                        GetPlanLog();
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

    #region GETPAYMENTDETAILS

    private void GetPaymentDetails()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            DataSet lobjds = pay_obj.RecurringPaymentDetails();

            builder.Append("<div class=\"block-content-full\">");
            builder.Append("<table class=\"table table-borderless table-striped\" id=\"tbl_profile\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");

            builder.Append("<td>");
            builder.Append("<strong> Payment For Account </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Plan Code </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Plan Name </strong>");
            builder.Append("</td>");


            builder.Append("<td>");
            builder.Append("<strong> Plan & Payment Information </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Transaction ID </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Transaction Type </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Amount  </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Currency  </strong>");
            //builder.Append("</td>");



            //builder.Append("<td>");
            //builder.Append("<strong>  Payer ID </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payer Full Name </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payer Email </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payment Response Date time </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Response </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Requset ID </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Request Status </strong>");
            builder.Append("</td>");

            builder.Append("</tr>");
            if (lobjds != null)
            {

                for (int i = 0; i < lobjds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<tr>");

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"])))
                    {
                        builder.Append("<td>" + "<a onclick=\"return ShowProfileModal(" + lobjds.Tables[0].
                            Rows[i]["by_user_id"] + ")\" data-toggle=\"modal\" href=\"#modal-regular-Profile\"> " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["item_number"])))
                    //{
                    //    builder.Append("<td> <a  onclick=\"return GetPaymentDetailsReqID(" + lobjds.Tables[0].Rows[i]["id"] + ")\" data-toggle=\"modal\" data-target=\"#PayDetails\">get </a> " + Convert.ToString(lobjds.Tables[0].Rows[i]["item_number"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"])))
                    {

                        if (lobjds.Tables[0].Rows[i]["item_name"].ToString() == "Basic Plan")
                        {
                            builder.Append("<td> <span class=\"basicPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"]) + "</span></td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["item_name"].ToString() == "Pro Plan")
                        {
                            builder.Append("<td> <span class=\"proPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"]) + "</span></td>");
                        }

                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["id"])))
                    {

                        builder.Append("<td>" + " <a onclick=\"return GetPaymentDetailsReqID(" + lobjds.Tables[0].Rows[i]["id"] + ")\"  data-toggle=\"modal\" data-target=\"#PayDetails\"> " + " Get Plan & Payment Details of \" " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + " \" Account. " + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["txn_id"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["txn_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["mc_gross"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["mc_gross"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["mc_currency"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["mc_currency"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}



                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payer_id"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["payer_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"])))
                    //{
                    //    if ((!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["buy_last_name"]))))
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"]) + " " +Convert.ToString(lobjds.Tables[0].Rows[i]["buy_last_name"]) +"</td>");
                    //    else
                    //    {
                    //        builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"]) + " - " + "</td>");
                    //    }
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payer_email"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["payer_email"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["pay_res_date"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["pay_res_date"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"])))
                    {
                        if (lobjds.Tables[0].Rows[i]["str_out_Response"].ToString() == "VERIFIED")
                        {
                            builder.Append("<td>" + "<span class=\"verified\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"]) + "</span> " + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["str_out_Response"].ToString() == "INVALID")
                        {
                            builder.Append("<td>" + "<span class=\"unverified\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"]) + "</span> " + "</td>");
                        }
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["req_id"])))
                    //{

                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["req_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"])))
                    {
                        if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Completed")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"transaction was successfully performed, money is transferred to seller's account. If txn_type=reversal, then the money is returned to buyer's account.\" class=\"label label-done\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span> " + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "DENIED" || lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Denied")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"seller cancelled the payment. The payment is in this state when the seller cancels the payment having the Pending state before.\" class=\"label label-denied\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "REFUNDED" || lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Refunded")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"money is returned to the buyer. The payment is in this state when the seller cancels the payment having the Completed state before.\" class=\"label label-refunded\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Failed")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"payment failed. This state is possible only when the payment was performed from a bank account.\" class=\"label label-failed\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }




                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }








                    builder.Append("</tr>");
                }
            }
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


    #endregion GETPAYMENTDETAILS


    #region GETPAYMENTPROFILE

    private void GetPaymentProfile()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            DataSet lobjds = pay_obj.RecurringPaymentProfile();

            builder.Append("<div class=\"block-content-full\">");
            builder.Append("<table class=\"table table-borderless table-striped\" id=\"tbl_profile\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");

            builder.Append("<td>");
            builder.Append("<strong> Payment For Account </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Plan Code </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Plan Name </strong>");
            builder.Append("</td>");


            builder.Append("<td>");
            builder.Append("<strong> Profile Information </strong>");
            builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Profile Action </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Transaction Type </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Amount  </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Currency  </strong>");
            //builder.Append("</td>");



            //builder.Append("<td>");
            //builder.Append("<strong>  Payer ID </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payer Full Name </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payer Email </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payment Response Date time </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Response </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Requset ID </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Request Status </strong>");
            builder.Append("</td>");

            builder.Append("</tr>");
            if (lobjds != null)
            {

                for (int i = 0; i < lobjds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<tr>");

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"])))
                    {
                        builder.Append("<td>" + "<a onclick=\"return ShowProfileModal(" + lobjds.Tables[0].
                            Rows[i]["by_user_id"] + ")\" data-toggle=\"modal\" href=\"#modal-regular-Profile\"> " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["item_number"])))
                    //{
                    //    builder.Append("<td> <a  onclick=\"return GetPaymentDetailsReqID(" + lobjds.Tables[0].Rows[i]["id"] + ")\" data-toggle=\"modal\" data-target=\"#PayDetails\">get </a> " + Convert.ToString(lobjds.Tables[0].Rows[i]["item_number"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"])))
                    {

                        if (lobjds.Tables[0].Rows[i]["item_name"].ToString() == "Basic Plan")
                        {
                            builder.Append("<td> <span class=\"basicPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"]) + "</span></td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["item_name"].ToString() == "Pro Plan")
                        {
                            builder.Append("<td> <span class=\"proPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"]) + "</span></td>");
                        }

                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["id"])))
                    {

                        builder.Append("<td>" + " <a onclick=\"return GetPaymentProDetailsReqID(" + lobjds.Tables[0].Rows[i]["id"] + ")\"  data-toggle=\"modal\" data-target=\"#payment-recurring\"> " + " Get Recurring Profile Details of \" " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + " \" Account. " + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"])))
                    {

                        if (lobjds.Tables[0].Rows[i]["txn_type"].ToString() == "subscr_signup")
                        {
                            builder.Append("<td>Profile Sign-Up </td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["txn_type"].ToString() == "subscr_cancel")
                        {
                            builder.Append("<td>Profile Cancel </td>");
                        }
                        else
                        {
                            builder.Append("<td>-</td>");
                        }
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["mc_gross"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["mc_gross"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["mc_currency"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["mc_currency"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}



                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payer_id"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["payer_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"])))
                    //{
                    //    if ((!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["buy_last_name"]))))
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"]) + " " +Convert.ToString(lobjds.Tables[0].Rows[i]["buy_last_name"]) +"</td>");
                    //    else
                    //    {
                    //        builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"]) + " - " + "</td>");
                    //    }
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payer_email"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["payer_email"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["pay_res_date"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["pay_res_date"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"])))
                    {
                        if (lobjds.Tables[0].Rows[i]["str_out_Response"].ToString() == "VERIFIED")
                        {
                            builder.Append("<td>" + "<span class=\"verified\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"]) + "</span> " + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["str_out_Response"].ToString() == "INVALID")
                        {
                            builder.Append("<td>" + "<span class=\"unverified\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"]) + "</span> " + "</td>");
                        }
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["req_id"])))
                    //{

                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["req_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"])))
                    {
                        if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Completed")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"transaction was successfully performed, money is transferred to seller's account. If txn_type=reversal, then the money is returned to buyer's account.\" class=\"label label-done\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span> " + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "DENIED" || lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Denied")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"seller cancelled the payment. The payment is in this state when the seller cancels the payment having the Pending state before.\" class=\"label label-denied\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "REFUNDED" || lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Refunded")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"money is returned to the buyer. The payment is in this state when the seller cancels the payment having the Completed state before.\" class=\"label label-refunded\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Failed")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"payment failed. This state is possible only when the payment was performed from a bank account.\" class=\"label label-failed\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }




                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }








                    builder.Append("</tr>");
                }
            }
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


    #endregion GETPAYMENTPROFILE


    #region GETPAYMENTDETAILSMY

    private void GetPaymentDetailsMy()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            DataSet lobjds = pay_obj.RecurringPaymentDetailsMy(Convert.ToInt32(mdblUserID));

            builder.Append("<div class=\"block-content-full\">");
            builder.Append("<table class=\"table table-borderless table-striped\" id=\"tbl_profile\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");

            builder.Append("<td>");
            builder.Append("<strong> Payment For Account </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Plan Code </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Plan Name </strong>");
            builder.Append("</td>");


            builder.Append("<td>");
            builder.Append("<strong> Plan & Payment Information </strong>");
            builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Invoice</strong>");
            builder.Append("</td>");
            //builder.Append("<td>");
            //builder.Append("<strong>  Transaction ID </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Transaction Type </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Amount  </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Currency  </strong>");
            //builder.Append("</td>");



            //builder.Append("<td>");
            //builder.Append("<strong>  Payer ID </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payer Full Name </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payer Email </strong>");
            //builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong>  Payment Response Date time </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Response </strong>");
            builder.Append("</td>");

            //builder.Append("<td>");
            //builder.Append("<strong> Requset ID </strong>");
            //builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Request Status </strong>");
            builder.Append("</td>");

            builder.Append("</tr>");
            if (lobjds != null)
            {

                for (int i = 0; i < lobjds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<tr>");

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"])))
                    {
                        builder.Append("<td>" + "<a onclick=\"return ShowProfileModal(" + lobjds.Tables[0].
                            Rows[i]["by_user_id"] + ")\" data-toggle=\"modal\" href=\"#modal-regular-Profile\"> " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["item_number"])))
                    //{
                    //    builder.Append("<td> <a  onclick=\"return GetPaymentDetailsReqID(" + lobjds.Tables[0].Rows[i]["id"] + ")\" data-toggle=\"modal\" data-target=\"#PayDetails\">get </a> " + Convert.ToString(lobjds.Tables[0].Rows[i]["item_number"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"])))
                    {

                        if (lobjds.Tables[0].Rows[i]["item_name"].ToString() == "Basic Plan")
                        {
                            builder.Append("<td> <span class=\"basicPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"]) + "</span></td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["item_name"].ToString() == "Pro Plan")
                        {
                            builder.Append("<td> <span class=\"proPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["item_name"]) + "</span></td>");
                        }

                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["id"])))
                    {

                        builder.Append("<td>" + " <a onclick=\"return GetPaymentDetailsReqID(" + lobjds.Tables[0].Rows[i]["id"] + ")\"  data-toggle=\"modal\" data-target=\"#PayDetails\"> " + " Get Plan & Payment Details of \" " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + " \" Account. " + "</a></td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["id"])))
                    {

                        builder.Append("<td>" + " <a  target='_blank'  href=\"../Pay/invoice.aspx?ReqID=" + lobjds.Tables[0].Rows[i]["id"] + "\"  > " + " Get Invoice of \" " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + " \" Account. " + "</a></td>");
                    
                    
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }
                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["txn_id"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["txn_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["txn_type"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["mc_gross"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["mc_gross"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["mc_currency"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["mc_currency"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}



                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payer_id"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["payer_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"])))
                    //{
                    //    if ((!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["buy_last_name"]))))
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"]) + " " +Convert.ToString(lobjds.Tables[0].Rows[i]["buy_last_name"]) +"</td>");
                    //    else
                    //    {
                    //        builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["buy_first_name"]) + " - " + "</td>");
                    //    }
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payer_email"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["payer_email"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["pay_res_date"])))
                    //{
                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["pay_res_date"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"])))
                    {
                        if (lobjds.Tables[0].Rows[i]["str_out_Response"].ToString() == "VERIFIED")
                        {
                            builder.Append("<td>" + "<span class=\"verified\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"]) + "</span> " + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["str_out_Response"].ToString() == "INVALID")
                        {
                            builder.Append("<td>" + "<span class=\"unverified\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["str_out_Response"]) + "</span> " + "</td>");
                        }
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }


                    //if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["req_id"])))
                    //{

                    //    builder.Append("<td>" + Convert.ToString(lobjds.Tables[0].Rows[i]["req_id"]) + "</td>");
                    //}
                    //else
                    //{
                    //    builder.Append("<td>-</td>");
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"])))
                    {
                        if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Completed")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"transaction was successfully performed, money is transferred to seller's account. If txn_type=reversal, then the money is returned to buyer's account.\" class=\"label label-done\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span> " + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "DENIED" || lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Denied")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"seller cancelled the payment. The payment is in this state when the seller cancels the payment having the Pending state before.\" class=\"label label-denied\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "REFUNDED" || lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Refunded")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"money is returned to the buyer. The payment is in this state when the seller cancels the payment having the Completed state before.\" class=\"label label-refunded\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["payment_status"].ToString() == "Failed")
                        {
                            builder.Append("<td>" + " <span data-toggle=\"tooltip\" data-placement=\"left\" title=\"payment failed. This state is possible only when the payment was performed from a bank account.\" class=\"label label-failed\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["payment_status"]) + "</span>" + "</td>");
                        }




                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }








                    builder.Append("</tr>");
                }
            }
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


    #endregion GETPAYMENTDETAILSMY



    #region GETPAYMENTDETAILSREQID
    private void GetPaymentDetailsReqID()
    {
        DataSet ds = null;
        StringBuilder builder = new StringBuilder("<Response><AdminData>");
        try
        {
            ds = pay_obj.RecurringPaymentDetailsReqId(lstrReqID);

            if (ds != null)
            {



                builder.Append("<txn_id><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["txn_id"]));
                builder.Append("]]></txn_id>");


                builder.Append("<txn_type><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["txn_type"]));
                builder.Append("]]></txn_type>");

                builder.Append("<payer_id><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["payer_id"]));
                builder.Append("]]></payer_id>");

                builder.Append("<first_name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["first_name"]));
                builder.Append("]]></first_name>");

                builder.Append("<last_name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["last_name"]));
                builder.Append("]]></last_name>");

                builder.Append("<payer_email><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["payer_email"]));
                builder.Append("]]></payer_email>");

                builder.Append("<payment_date><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["payment_date"]));
                builder.Append("]]></payment_date>");

                builder.Append("<str_out_Response><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["str_out_Response"]));
                builder.Append("]]></str_out_Response>");

                builder.Append("<req_id><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["req_id"]));
                builder.Append("]]></req_id>");

                builder.Append("<payment_status><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["payment_status"]));
                builder.Append("]]></payment_status>");

                builder.Append("<item_number><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["item_number"]));
                builder.Append("]]></item_number>");

                builder.Append("<Full_Name><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]));
                builder.Append("]]></Full_Name>");

                builder.Append("<EMail><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["EMail"]));
                builder.Append("]]></EMail>");

                builder.Append("<mc_gross><![CDATA[");
                builder.Append(string.Format("{0:N2}", ds.Tables[0].Rows[0]["mc_gross"]));
                builder.Append("]]></mc_gross>");

                builder.Append("<subscr_date><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["subscr_date"]));
                builder.Append("]]></subscr_date>");
            
                builder.Append("<mc_amount3><![CDATA[");
                builder.Append(string.Format("{0:N2}", ds.Tables[0].Rows[0]["mc_amount3"]));
                builder.Append("]]></mc_amount3>");
                
                builder.Append("<period3><![CDATA[");
                builder.Append(Convert.ToString(ds.Tables[0].Rows[0]["period3"]));
                builder.Append("]]></period3>");
            
           
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
    #endregion GETPAYMENTDETAILSREQID


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


    #region GETPLANLOG

    private void GetPlanLog()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            DataSet lobjds = pay_obj.PlanLogGet();

            builder.Append("<div class=\"block-content-full\">");
            builder.Append("<table class=\"table table-borderless table-striped\" id=\"tbl_profile\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");

            builder.Append("<td>");
            builder.Append("<strong> Payment For Account </strong>");
            builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Plan Name </strong>");
            builder.Append("</td>");


            builder.Append("<td>");
            builder.Append("<strong> Plan Active Date Time </strong>");
            builder.Append("</td>");


            builder.Append("<td>");
            builder.Append("<strong> Plan Till Date Time </strong>");
            builder.Append("</td>");

          
            builder.Append("<td>");
            builder.Append("<strong> Plan Base Price </strong>");
            builder.Append("</td>");

            builder.Append("<td>");
            builder.Append("<strong> Plan Sale Price </strong>");
            builder.Append("</td>");

            builder.Append("</tr>");
            if (lobjds != null)
            {

                for (int i = 0; i < lobjds.Tables[0].Rows.Count; i++)
                {
                   
                    if (lobjds.Tables[0].Rows[i]["CurrentPlan"].ToString() == "True")
                    {
                        builder.Append("<td><i class='fa fa-check'></i>");
                    }
                    else {
                           builder.Append("<td style='margin-left:20px;'>");
                    }

                    

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"])))
                    {
                        builder.Append("" + "<a onclick=\"return ShowProfileModal(" + lobjds.Tables[0].Rows[i]["UserID"] + ")\" data-toggle=\"modal\" href=\"#modal-regular-Profile\"> " + Convert.ToString(lobjds.Tables[0].Rows[i]["Full_Name"]) + "</a></td>");
                    }
                    else
                    {
                        builder.Append("-</td>");
                    }


                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["PlanName"])))
                    {

                        if (lobjds.Tables[0].Rows[i]["PlanName"].ToString() == "Basic Plan")
                        {
                            builder.Append("<td> <span class=\"basicPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["PlanName"]) + "</span></td>");
                        }
                        else if (lobjds.Tables[0].Rows[i]["PlanName"].ToString() == "Pro Plan")
                        {
                            builder.Append("<td> <span class=\"proPlan\">" + Convert.ToString(lobjds.Tables[0].Rows[i]["PlanName"]) + "</span></td>");
                        }
                        else
                        {
                            builder.Append("<td> <span class=\"basicPlan\">Free Plan</span></td>");
                        }

                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["ActiveDateTime"])))
                    {

                        builder.Append("<td>" + String.Format("{0:d MMMM, yyyy h:mm tt}", lobjds.Tables[0].Rows[i]["ActiveDateTime"]) + "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }


                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["TillDateTime"])))
                    {

                        builder.Append("<td>" + String.Format("{0:d MMMM, yyyy h:mm tt}", lobjds.Tables[0].Rows[i]["TillDateTime"]) + "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["PlanBasePrice"])))
                    {

                        builder.Append("<td><span class='fa fa-dollar'></span>  " +String.Format("{0:0.00}", lobjds.Tables[0].Rows[i]["PlanBasePrice"] )+ "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(lobjds.Tables[0].Rows[i]["TaxPrice"])))
                    {

                        builder.Append("<td> <span class='fa fa-dollar'></span>  " + String.Format("{0:0.00}", lobjds.Tables[0].Rows[i]["TaxPrice"]) + "</td>");
                    }
                    else
                    {
                        builder.Append("<td>-</td>");
                    }


                    


                  

                    builder.Append("</tr>");
                }
            }
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


    #endregion GETPLANLOG

    #endregion Function



}