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
using latestnews;

public partial class User_Ajax_dev_index : System.Web.UI.Page
{
    clslatestnews obj_latestNews = new clslatestnews();
    clslatestnewsPrp obj_latestNewsPrp= new clslatestnewsPrp();

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


            case "LATESTNEWSMEMBERASSIGN":
                {
                    try
                    {
                        //Member Assign For latestNews 
                        latestNewsMemberAssign();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;


            case "LATESTNEWSMEMBERASSIGNCHK":
                {
                    try
                    {
                        //Member Assign Check Right For latestNews  
                        latestNewsMemberAssignCheck();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            //latestNewsMemberAssignSearch
            case "LATESTNEWSMEMASSSRC":
                {
                    try
                    {
                        latestNewsMemberAssignSearch();
                      

                    }
                    catch
                    {

                    }

                }
                break;

            case "LATESTNEWSAPVSRC":
                {
                    try
                    {
                        latestNewsApproveSearch();

                    }
                    catch
                    {

                    }

                }
                break;

            case "LATESTNEWSGETALL":
                {
                    try
                    {
                        latestNewsGetAll();

                    }
                    catch (Exception ex)
                    {

                    }

                }
                break;

            case "LATESTNEWSSEND":
                {
                    try
                    {
                        latestNewsSend();

                    }
                    catch
                    {

                    }

                }
                break;
                

            case "LATESTNEWSUPD":
                {
                    try
                    {
                        latestNewsUpd();

                    }
                    catch
                    {

                    }

                }
                break;
                

                  case "LATESTNEWSAPPACT":
                {
                    try
                    {
                        latestNewsApproveAction();

                    }
                    catch
                    {

                    }

                }
                break;

                


            case "LATESTNEWSGETMY":
                {
                    try
                    {
                        latestNewsGetMy();

                    }
                    catch
                    {

                    }

                }
                break;

            case "LATESTNEWSDELETE":
                {
                    try
                    {
                        latestNewsDelete();

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

    #region latestNewsDelete
 
    private void latestNewsDelete()
    {
        Int32 flag = -1;
        string strln_id="";
        if (Request.Form["ln_id"] != null)
        {
            strln_id = Convert.ToString(Request.Form["ln_id"]);
        }
        else
        {
            strln_id = null;
        }
        try
        {
            obj_latestNewsPrp.ln_id = Convert.ToInt32( strln_id);
            flag = obj_latestNews.latestNewsDelete(obj_latestNewsPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion latestNewsDelete


    #region latestNewsMemberAssign

    private void latestNewsMemberAssign()
    {
        Int32 flag = -1;
        string strln_user_id;
        if (Request.Form["ln_user_id"] != null)
        {
            strln_user_id = Convert.ToString(Request.Form["ln_user_id"]);
        }
        else
        {
            strln_user_id = null;
        }
        try
        {
            obj_latestNewsPrp.ln_user_id = Convert.ToInt32(strln_user_id);
            flag = obj_latestNews.latestnewsMemberAssign(obj_latestNewsPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion latestNewsMemberAssign


    #region latestNewsMemberAssignCheck

    private void latestNewsMemberAssignCheck()
    {
        Int32 flag = -1;
        string strln_user_id;
        if (Request.Form["ln_user_id"] != null)
        {
            strln_user_id = Convert.ToString(Request.Form["ln_user_id"]);
        }
        else
        {
            strln_user_id = null;
        }
        try
        {
            obj_latestNewsPrp.ln_user_id = Convert.ToInt32(strln_user_id);
            flag = obj_latestNews.latestNewsMemberAssignCheck(obj_latestNewsPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion latestNewsMemberAssignCheck


    #region latestNewsMemberAssignSearch

    private void latestNewsMemberAssignSearch()
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

            DataSet ds = obj_latestNews.latestNewsMemberAssign_search(strFullName);
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
                            builder.Append("<div  class=\"slctMmb\"><label class=\"switch\"> <input  onclick='latestNewsMemberAssign(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\"  class=\"switch\" value=\"1\" checked/> <span></span> </label></div>");
                            
                        }
                        else
                        {
                            builder.Append("<div   class=\"slctMmb\"><label class=\"switch\"> <input  onclick='latestNewsMemberAssign(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\" class=\"switch\" value=\"1\" /> <span></span> </label></div>");
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

    #endregion latestNewsMemberAssignSearch


    #region latestNewsGetAll

    private void latestNewsGetAll()
    {
        string strFullName = "";
      
            
      
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_latestNews.latestNewsApprove_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "APPROVE")
                    {
                    builder.Append("<div class='col-md-3'><div class='panel panel-default'><div class='panel-body profile'><div class='profile-image'>");
                    builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \"></div> <div class='profile-data'>");
                    builder.Append("<div class='profile-data-name'> " + ds.Tables[0].Rows[i]["ln_heading"] + "</div></div>");
                    builder.Append("<div class='profile-controls'> <a onclick='return ShowProfileModal(" + ds.Tables[0].Rows[i]["ln_by_user_id"] + ")' data-toggle='modal' class='profile-control-left'  href='#modal-regular-Profile'>");
                    builder.Append("<span   class='fa fa-info'></span></a> <a class='profile-control-right' target='_blank' href=" + ds.Tables[0].Rows[i]["ln_file_url"] + ">");
                    builder.Append("<i class='fa fa-download'></i></span></a> </div> </div> <div class='panel-body'><div class='newsletter-info'> ");
                    builder.Append("<div class='col-md-6'><div class='row'> <p><small><i class='fa fa-calendar'></i>Date Posted</small><br>" + ds.Tables[0].Rows[i]["ln_rdatetime"] + "</p></div></div>");
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

    #endregion latestNewsGetAll



    #region latestNewsApproveSearch

    private void latestNewsApproveSearch()
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

            DataSet ds = obj_latestNews.latestNewsApprove_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<a  title='View File'  class='list-group-item' target='_blank' href=" + ds.Tables[0].Rows[i]["ln_file_url"] + "> ");
                    builder.Append("<img  class='pull-left' onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");
                    builder.Append("<p><strong>" + ds.Tables[0].Rows[i]["ln_heading"] + "</strong></p>");
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

                    if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "REQUEST")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' onclick=\"latestNewsApproveAction( '" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' , 'APPROVE')\" type='radio'><span class='outer'><span class='ilner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' onclick=\"latestNewsApproveAction( '" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' , 'REJECT')\" type='radio'><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                    else if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "APPROVE")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' onclick=\"latestNewsApproveAction( '" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' , 'APPROVE')\" type='radio' checked><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' onclick=\"latestNewsApproveAction( '" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' , 'REJECT')\" type='radio' ><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                    else if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "REJECT")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' onclick=\"latestNewsApproveAction( '" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' , 'APPROVE')\" ><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' onclick=\"latestNewsApproveAction( '" + ds.Tables[0].Rows[i]["ln_id"].ToString() + "' , 'REJECT')\" type='radio' checked><span class='outer'><span class='inner reject'></span></span> Reject</label>");
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

    #endregion latestNewsApproveSearch

    #region latestNewsUpd

    private void latestNewsUpd()
    {
        Int32 flag = -1;
        string strln_heading, strln_file_url,strln_id;
        if (Request.Form["ln_heading"] != null)
        {
            strln_heading = Convert.ToString(Request.Form["ln_heading"]);
        }
        else
        {
            strln_heading = null;
        }
        if (Request.Form["ln_file_url"] != null)
        {
            strln_file_url = Convert.ToString(Request.Form["ln_file_url"]);
        }
        else
        {
            strln_file_url = null;
        }
        if (Request.Form["ln_id"] != null)
        {
            strln_id = Convert.ToString(Request.Form["ln_id"]);
        }
        else
        {
            strln_id = null;
        }

        try
        {
            obj_latestNewsPrp.ln_id = Convert.ToInt32(strln_id);
            obj_latestNewsPrp.ln_heading = strln_heading;
            obj_latestNewsPrp.ln_by_user_id = Convert.ToInt32(mdblUserID);
            obj_latestNewsPrp.ln_file_url = strln_file_url;
            flag = obj_latestNews.latestNewsUpd(obj_latestNewsPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion latestNewsUpd


    #region latestNewsSend
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void latestNewsSend()
    {
        Int32 flag = -1;
        string strln_heading, strln_file_url;
        if (Request.Form["ln_heading"] != null)
        {
            strln_heading = Convert.ToString(Request.Form["ln_heading"]);
        }
        else
        {
            strln_heading = null;
        }
        if (Request.Form["ln_file_url"] != null)
        {
            strln_file_url = Convert.ToString(Request.Form["ln_file_url"]);
        }
        else
        {
            strln_file_url = null;
        }

        try
        {

            obj_latestNewsPrp.ln_heading = strln_heading;
            obj_latestNewsPrp.ln_by_user_id = Convert.ToInt32(mdblUserID);
            obj_latestNewsPrp.ln_file_url = strln_file_url;
            flag = obj_latestNews.latestNewsSend(obj_latestNewsPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion latestNewsSend


    #region latestNewsApproveAction
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void latestNewsApproveAction()
    {
        Int32 flag = -1;
        string strln_id, strln_status;
        if (Request.Form["ln_id"] != null)
        {
            strln_id = Convert.ToString(Request.Form["ln_id"]);
        }
        else
        {
            strln_id = null;
        }
        if (Request.Form["ln_status"] != null)
        {
            strln_status = Convert.ToString(Request.Form["ln_status"]);
        }
        else
        {
            strln_status = null;
        }

        try
        {


            obj_latestNewsPrp.ln_id = Convert.ToInt32(strln_id);
            obj_latestNewsPrp.ln_status = strln_status;
            flag = obj_latestNews.latestNewsApprove_Action(obj_latestNewsPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion latestNewsApproveAction



    #region latestNewsGetMy

    private void latestNewsGetMy()
    {
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_latestNewsPrp.ln_by_user_id = Convert.ToInt32(mdblUserID);
            DataSet ds = obj_latestNews.getMylatestNews(obj_latestNewsPrp);
            if (ds != null)
            {
                
                builder.Append("<table class='table table-bordered table-striped table-actions'>");
                builder.Append("<thead><tr><th width='50'>Sr No.</th><th>Latest News Heading</th><th width='100'>Status</th><th width='100'>Date</th><th width='100'>Res. Date</th><th width='120'>Actions</th></tr></thead><tbody>");
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                 

                    builder.Append("</tr><td class='text-center'>" + ds.Tables[0].Rows[i]["SN"] + "</td>");
                    builder.Append(" <td><strong>" + ds.Tables[0].Rows[i]["ln_heading"] + "</strong></td>");
                    if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "REQUEST")
                    {
                        builder.Append(" <td><span class='label label-warning'>Request</span></td>");
                    }
                    else if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "APPROVE")
                    {
                        builder.Append(" <td><span class='label label-success'>Approve</span></td>");
                    }
                    else if (ds.Tables[0].Rows[i]["ln_status"].ToString() == "REJECT")
                    {
                        builder.Append(" <td><span class='label label-danger'>Reject</span></td>");
                    }
                      
                    if (ds.Tables[0].Rows[i]["ln_datetime"].ToString() != ds.Tables[0].Rows[i]["ln_rdatetime"].ToString())
                    {
                        builder.Append("<td>" + ds.Tables[0].Rows[i]["ln_datetime"] + "</td><td>" + ds.Tables[0].Rows[i]["ln_datetime"] + "</td><td>");
                    }
                    else
                    {
                        builder.Append("<td>" + ds.Tables[0].Rows[i]["ln_datetime"] + "</td><td>-</td><td>");
               
                    }

                    builder.Append("<button  onclick=\"latestNews_get_edit('" + ds.Tables[0].Rows[i]["ln_id"] + "','" + ds.Tables[0].Rows[i]["ln_heading"] + "','" + ds.Tables[0].Rows[i]["ln_file_url"] + "') \" class='btn btn-default btn-rounded btn-condensed btn-sm' data-toggle='modal' data-target='#editTipTech'><span class='fa fa-pencil'></span></button>");
                  builder.Append("<button onclick='latestNewsDelete(" + ds.Tables[0].Rows[i]["ln_id"] + ");' data-toggle='tooltip' data-placement='top' title='Delete' class='btn btn-danger btn-rounded btn-condensed btn-sm'><span class='fa fa-times'></span></button>");
                  builder.Append("<a class='profile-control-right' target='_blank' href=" + ds.Tables[0].Rows[i]["ln_file_url"] + "><button data-toggle='tooltip'  data-placement='top' title='Download PDF' class='btn btn-success btn-rounded btn-condensed btn-sm'><i class='fa fa-download'></i></button></a>");
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

    #endregion latestNewsMemberAssign

    #endregion Functions


}

 