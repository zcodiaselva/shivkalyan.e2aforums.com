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
using newsletter;

public partial class User_Ajax_dev_index : System.Web.UI.Page
{
    clsNewsLetter obj_NewsLetter = new clsNewsLetter();
    clsNewsLetterPrp obj_NewsLetterPrp= new clsNewsLetterPrp();

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


            case "NEWSLETTERMEMBERASSIGN":
                {
                    try
                    {
                        //Member Assign For NewsLetter 
                        NewsLetterMemberAssign();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;


            case "NEWSLETTERMEMBERASSIGNCHK":
                {
                    try
                    {
                        //Member Assign Check Right For NewsLetter  
                        NewsLetterMemberAssignCheck();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            //NewsLetterMemberAssignSearch
            case "NEWSLETTERMEMASSSRC":
                {
                    try
                    {
                        NewsLetterMemberAssignSearch();
                      

                    }
                    catch
                    {

                    }

                }
                break;

            case "NEWSLETTERAPVSRC":
                {
                    try
                    {
                        NewsLetterApproveSearch();

                    }
                    catch
                    {

                    }

                }
                break;

            case "NEWSLETTERGETALL":
                {
                    try
                    {
                        NewsLetterGetAll();

                    }
                    catch (Exception ex)
                    {

                    }

                }
                break;

            case "NEWSLETTERSEND":
                {
                    try
                    {
                        NewsLetterSend();

                    }
                    catch
                    {

                    }

                }
                break;
                

            case "NEWSLETTERUPD":
                {
                    try
                    {
                        NewsLetterUpd();

                    }
                    catch
                    {

                    }

                }
                break;
                

                  case "NEWSLETTERAPPACT":
                {
                    try
                    {
                        NewsLetterApproveAction();

                    }
                    catch
                    {

                    }

                }
                break;

                


            case "NEWSLETTERGETMY":
                {
                    try
                    {
                        NewsLetterGetMy();

                    }
                    catch
                    {

                    }

                }
                break;

            case "NEWSLETTERDELETE":
                {
                    try
                    {
                        NewsLetterDelete();

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

    #region NewsLetterDelete
 
    private void NewsLetterDelete()
    {
        Int32 flag = -1;
        string strnn_id="";
        if (Request.Form["nn_id"] != null)
        {
            strnn_id = Convert.ToString(Request.Form["nn_id"]);
        }
        else
        {
            strnn_id = null;
        }
        try
        {
            obj_NewsLetterPrp.nn_id = Convert.ToInt32( strnn_id);
            flag = obj_NewsLetter.NewsLetterDelete(obj_NewsLetterPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion NewsLetterDelete


    #region NewsLetterMemberAssign

    private void NewsLetterMemberAssign()
    {
        Int32 flag = -1;
        string strnn_user_id;
        if (Request.Form["nn_user_id"] != null)
        {
            strnn_user_id = Convert.ToString(Request.Form["nn_user_id"]);
        }
        else
        {
            strnn_user_id = null;
        }
        try
        {
            obj_NewsLetterPrp.nn_user_id = Convert.ToInt32(strnn_user_id);
            flag = obj_NewsLetter.NewsLetterMemberAssign(obj_NewsLetterPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion NewsLetterMemberAssign


    #region NewsLetterMemberAssignCheck

    private void NewsLetterMemberAssignCheck()
    {
        Int32 flag = -1;
        string strnn_user_id;
        if (Request.Form["nn_user_id"] != null)
        {
            strnn_user_id = Convert.ToString(Request.Form["nn_user_id"]);
        }
        else
        {
            strnn_user_id = null;
        }
        try
        {
            obj_NewsLetterPrp.nn_user_id = Convert.ToInt32(strnn_user_id);
            flag = obj_NewsLetter.NewsLetterMemberAssignCheck(obj_NewsLetterPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion NewsLetterMemberAssignCheck


    #region NewsLetterMemberAssignSearch

    private void NewsLetterMemberAssignSearch()
   {
        string strFullName = "";
        if (Request.Form["Full_Name"] != null || Request.Form["Full_Name"] != "")
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

            DataSet ds = obj_NewsLetter.NewsLetterMemberAssign_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
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
                            builder.Append("<div  class=\"slctMmb\"><label class=\"switch\"> <input  onclick='newsLetterMemberAssign(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\"  class=\"switch\" value=\"1\" checked/> <span></span> </label></div>");
                            
                        }
                        else
                        {
                            builder.Append("<div   class=\"slctMmb\"><label class=\"switch\"> <input  onclick='newsLetterMemberAssign(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\" class=\"switch\" value=\"1\" /> <span></span> </label></div>");
                        }
                        builder.Append("</a> ");

                   
                }
            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion NewsLetterMemberAssignSearch


    #region NewsLetterGetAll

    private void NewsLetterGetAll()
    {
        string strFullName = "";
      
            
      
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_NewsLetter.NewsLetterApprove_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "APPROVE")
                    {
                    builder.Append("<div class='col-md-3'><div class='panel panel-default'><div class='panel-body profile'><div class='profile-image'>");
                    builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \"></div> <div class='profile-data'>");
                    builder.Append("<div class='profile-data-name'> " + ds.Tables[0].Rows[i]["nn_heading"] + "</div></div>");
                    builder.Append("<div class='profile-controls'> <a onclick='return ShowProfileModal(" + ds.Tables[0].Rows[i]["nn_by_user_id"] + ")' data-toggle='modal' class='profile-control-left'  href='#modal-regular-Profile'>");
                    builder.Append("<span   class='fa fa-info'></span></a> <a class='profile-control-right' target='_blank' href=" + ds.Tables[0].Rows[i]["nn_file_url"] + ">");
                    builder.Append("<i class='fa fa-download'></i></span></a> </div> </div> <div class='panel-body'><div class='newsletter-info'> ");
                    builder.Append("<div class='col-md-6'><div class='row'> <p><small><i class='fa fa-calendar'></i>Date Posted</small><br>" + ds.Tables[0].Rows[i]["nn_rdatetime"] + "</p></div></div>");
                    builder.Append("<div class='col-md-6'><div class='row'><p><small><i class='fa fa-user'></i>Submitted By</small><br>" + ds.Tables[0].Rows[i]["Full_Name"].ToString() + "</p>");
                    builder.Append("</div> </div> </div> </div> </div></div>");
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

    #endregion NewsLetterGetAll



    #region NewsLetterApproveSearch

    private void NewsLetterApproveSearch()
    {
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

            DataSet ds = obj_NewsLetter.NewsLetterApprove_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<a  title='View File'  class='list-group-item' target='_blank' href=" + ds.Tables[0].Rows[i]["nn_file_url"] + "> ");
                    builder.Append("<img  class='pull-left' onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");
                    builder.Append("<p><strong>" + ds.Tables[0].Rows[i]["nn_heading"] + "</strong></p>");
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"])))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["UserType"])))
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) == "Experts")
                            {
                                builder.Append("<span>" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "<small> , " + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) + " ( " + Convert.ToString(ds.Tables[0].Rows[i]["Occupation"]) + " )" + "</small></span>");

                            }
                            else
                            {
                                builder.Append("<span>" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "<small> , " + Convert.ToString(ds.Tables[0].Rows[i]["UserType"]) +"</small></span>");
                            }
                        }
                        else
                        {

                            builder.Append("<span>" + Convert.ToString(ds.Tables[0].Rows[i]["Full_Name"]) + "</span>");
                        }

                    }
                    else
                    {
                        builder.Append("<span class=\"contacts-title\"> - </span>");
                    }

                    if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "REQUEST")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' onclick=\"newsLetterApproveAction( '" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' , 'APPROVE')\" type='radio'><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' onclick=\"newsLetterApproveAction( '" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' , 'REJECT')\" type='radio'><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                    else if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "APPROVE")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' onclick=\"newsLetterApproveAction( '" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' , 'APPROVE')\" type='radio' checked><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' onclick=\"newsLetterApproveAction( '" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' , 'REJECT')\" type='radio' ><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                    else if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "REJECT")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' onclick=\"newsLetterApproveAction( '" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' , 'APPROVE')\" ><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' onclick=\"newsLetterApproveAction( '" + ds.Tables[0].Rows[i]["nn_id"].ToString() + "' , 'REJECT')\" type='radio' checked><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                       
                    }
                    builder.Append("</a> ");


                }
            


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion NewsLetterApproveSearch

    #region NewsLetterUpd

    private void NewsLetterUpd()
    {
        Int32 flag = -1;
        string strnn_heading, strnn_file_url,strnn_id;
        if (Request.Form["nn_heading"] != null)
        {
            strnn_heading = Convert.ToString(Request.Form["nn_heading"]);
        }
        else
        {
            strnn_heading = null;
        }
        if (Request.Form["nn_file_url"] != null)
        {
            strnn_file_url = Convert.ToString(Request.Form["nn_file_url"]);
        }
        else
        {
            strnn_file_url = null;
        }
        if (Request.Form["nn_id"] != null)
        {
            strnn_id = Convert.ToString(Request.Form["nn_id"]);
        }
        else
        {
            strnn_id = null;
        }

        try
        {
            obj_NewsLetterPrp.nn_id = Convert.ToInt32(strnn_id);
            obj_NewsLetterPrp.nn_heading = strnn_heading;
            obj_NewsLetterPrp.nn_by_user_id = Convert.ToInt32(mdblUserID);
            obj_NewsLetterPrp.nn_file_url = strnn_file_url;
            flag = obj_NewsLetter.NewsLetterUpd(obj_NewsLetterPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion NewsLetterUpd


    #region NewsLetterSend
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void NewsLetterSend()
    {
        Int32 flag = -1;
        string strnn_heading, strnn_file_url;
        if (Request.Form["nn_heading"] != null)
        {
            strnn_heading = Convert.ToString(Request.Form["nn_heading"]);
        }
        else
        {
            strnn_heading = null;
        }
        if (Request.Form["nn_file_url"] != null)
        {
            strnn_file_url = Convert.ToString(Request.Form["nn_file_url"]);
        }
        else
        {
            strnn_file_url = null;
        }

        try
        {

            obj_NewsLetterPrp.nn_heading = strnn_heading;
            obj_NewsLetterPrp.nn_by_user_id = Convert.ToInt32(mdblUserID);
            obj_NewsLetterPrp.nn_file_url = strnn_file_url;
            flag = obj_NewsLetter.NewsLetterSend(obj_NewsLetterPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion NewsLetterSend


    #region NewsLetterApproveAction
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void NewsLetterApproveAction()
    {
        Int32 flag = -1;
        string strnn_id, strnn_status;
        if (Request.Form["nn_id"] != null)
        {
            strnn_id = Convert.ToString(Request.Form["nn_id"]);
        }
        else
        {
            strnn_id = null;
        }
        if (Request.Form["nn_status"] != null)
        {
            strnn_status = Convert.ToString(Request.Form["nn_status"]);
        }
        else
        {
            strnn_status = null;
        }

        try
        {


            obj_NewsLetterPrp.nn_id = Convert.ToInt32(strnn_id);
            obj_NewsLetterPrp.nn_status = strnn_status;
            flag = obj_NewsLetter.NewsLetterApprove_Action(obj_NewsLetterPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion NewsLetterApproveAction



    #region NewsLetterGetMy

    private void NewsLetterGetMy()
    {
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_NewsLetterPrp.nn_by_user_id = Convert.ToInt32(mdblUserID);
            DataSet ds = obj_NewsLetter.getMyNewsLetter(obj_NewsLetterPrp);
            if (ds != null)
            {
                
                builder.Append("<table class='table table-bordered table-striped table-actions'>");
                builder.Append("<thead><tr><th width='50'>Sr No.</th><th>News Letter Heading</th><th width='100'>Status</th><th width='100'>Date</th><th width='100'>Res. Date</th><th width='120'>Actions</th></tr></thead><tbody>");
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                 

                    builder.Append("</tr><td class='text-center'>" + ds.Tables[0].Rows[i]["SN"] + "</td>");
                    builder.Append(" <td><strong>" + ds.Tables[0].Rows[i]["nn_heading"] + "</strong></td>");
                    if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "REQUEST")
                    {
                        builder.Append(" <td><span class='label label-warning'>Request</span></td>");
                    }
                    else if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "APPROVE")
                    {
                        builder.Append(" <td><span class='label label-success'>Approve</span></td>");
                    }
                    else if (ds.Tables[0].Rows[i]["nn_status"].ToString() == "REJECT")
                    {
                        builder.Append(" <td><span class='label label-danger'>Reject</span></td>");
                    }
                      
                    if (ds.Tables[0].Rows[i]["nn_datetime"].ToString() != ds.Tables[0].Rows[i]["nn_rdatetime"].ToString())
                    {
                        builder.Append("<td>" + ds.Tables[0].Rows[i]["nn_datetime"] + "</td><td>" + ds.Tables[0].Rows[i]["nn_datetime"] + "</td><td>");
                    }
                    else
                    {
                        builder.Append("<td>" + ds.Tables[0].Rows[i]["nn_datetime"] + "</td><td>-</td><td>");
               
                    }

                    builder.Append("<button  onclick=\"newsLetter_get_edit('" + ds.Tables[0].Rows[i]["nn_id"] + "','" + ds.Tables[0].Rows[i]["nn_heading"] + "','" + ds.Tables[0].Rows[i]["nn_file_url"] + "') \" class='btn btn-default btn-rounded btn-condensed btn-sm' data-toggle='modal' data-target='#editTipTech'><span class='fa fa-pencil'></span></button>");
                  builder.Append("<button onclick='newsLetterDelete(" + ds.Tables[0].Rows[i]["nn_id"] + ");' data-toggle='tooltip' data-placement='top' title='Delete' class='btn btn-danger btn-rounded btn-condensed btn-sm'><span class='fa fa-times'></span></button>");
                  builder.Append("<a class='profile-control-right' target='_blank' href=" + ds.Tables[0].Rows[i]["nn_file_url"] + "><button data-toggle='tooltip'  data-placement='top' title='Download PDF' class='btn btn-success btn-rounded btn-condensed btn-sm'><i class='fa fa-download'></i></button></a>");
                  builder.Append("</td></tr>");
                }
                builder.Append(" </tbody></table>");
            }


        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = builder.ToString();
    }

    #endregion NewsLetterMemberAssign

    #endregion Functions


}

 