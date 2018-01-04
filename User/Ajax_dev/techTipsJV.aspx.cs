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
using techtips;

public partial class User_Ajax_dev_index : System.Web.UI.Page
{
    clsTechTips obj_techTips = new clsTechTips();
    clsTechTipsPrp obj_techTipsPrp= new clsTechTipsPrp();

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


            case "TECHTIPSMEMBERASSIGN":
                {
                    try
                    {
                        //Member Assign For TechTips 
                        TechTipsMemberAssign();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;


            case "TECHTIPSMEMBERASSIGNCHK":
                {
                    try
                    {
                        //Member Assign Check Right For TechTips  
                        TechTipsMemberAssignCheck();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                break;

            //TechTipsMemberAssignSearch
            case "TECHTIPSMEMASSSRC":
                {
                    try
                    {
                        TechTipsMemberAssignSearch();
                      

                    }
                    catch
                    {

                    }

                }
                break;

            case "TECHTIPSAPVSRC":
                {
                    try
                    {
                        TechTipsApproveSearch();

                    }
                    catch
                    {

                    }

                }
                break;

            case "TECHTIPSGETALL":
                {
                    try
                    {
                        TechTipsGetAll();

                    }
                    catch (Exception ex)
                    {

                    }

                }
                break;

            case "TECHTIPSSEND":
                {
                    try
                    {
                        techTipsSend();

                    }
                    catch
                    {

                    }

                }
                break;
                

            case "TECHTIPSUPD":
                {
                    try
                    {
                        techTipsUpd();

                    }
                    catch
                    {

                    }

                }
                break;
                

                  case "TECHTIPSAPPACT":
                {
                    try
                    {
                        TechTipsApproveAction();

                    }
                    catch
                    {

                    }

                }
                break;

                


            case "TECHTIPSGETMY":
                {
                    try
                    {
                        TechTipsGetMy();

                    }
                    catch
                    {

                    }

                }
                break;

            case "TECHTIPSDELETE":
                {
                    try
                    {
                        TechTipsDelete();

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

    #region TechTipsDelete
 
    private void TechTipsDelete()
    {
        Int32 flag = -1;
        string strtt_id="";
        if (Request.Form["tt_id"] != null)
        {
            strtt_id = Convert.ToString(Request.Form["tt_id"]);
        }
        else
        {
            strtt_id = null;
        }
        try
        {
            obj_techTipsPrp.tt_id = Convert.ToInt32( strtt_id);
            flag = obj_techTips.TechTipsDelete(obj_techTipsPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion TechTipsDelete


    #region TechTipsMemberAssign

    private void TechTipsMemberAssign()
    {
        Int32 flag = -1;
        string strtt_user_id;
        if (Request.Form["tt_user_id"] != null)
        {
            strtt_user_id = Convert.ToString(Request.Form["tt_user_id"]);
        }
        else
        {
            strtt_user_id = null;
        }
        try
        {
            obj_techTipsPrp.tt_user_id = Convert.ToInt32(strtt_user_id);
            flag = obj_techTips.TechTipsMemberAssign(obj_techTipsPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion TechTipsMemberAssign


    #region TechTipsMemberAssignCheck

    private void TechTipsMemberAssignCheck()
    {
        Int32 flag = -1;
        string strtt_user_id;
        if (Request.Form["tt_user_id"] != null)
        {
            strtt_user_id = Convert.ToString(Request.Form["tt_user_id"]);
        }
        else
        {
            strtt_user_id = null;
        }
        try
        {
            obj_techTipsPrp.tt_user_id = Convert.ToInt32(strtt_user_id);
            flag = obj_techTips.TechTipsMemberAssignCheck(obj_techTipsPrp);
        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion TechTipsMemberAssignCheck


    #region TechTipsMemberAssignSearch

    private void TechTipsMemberAssignSearch()
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

            DataSet ds = obj_techTips.TechTipsMemberAssign_search(strFullName);
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
                            builder.Append("<div  class=\"slctMmb\"><label class=\"switch\"> <input  onclick='TechTipsMemberAssign(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\"  class=\"switch\" value=\"1\" checked/> <span></span> </label></div>");
                            
                        }
                        else
                        {
                            builder.Append("<div   class=\"slctMmb\"><label class=\"switch\"> <input  onclick='TechTipsMemberAssign(" + ds.Tables[0].Rows[i]["UserID"].ToString() + ")' type=\"checkbox\" class=\"switch\" value=\"1\" /> <span></span> </label></div>");
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

    #endregion TechTipsMemberAssignSearch


    #region TechTipsGetAll

    private void TechTipsGetAll()
    {
        string strFullName = "";
      
            
      
        StringBuilder builder = new StringBuilder();
        try
        {

            DataSet ds = obj_techTips.TechTipsApprove_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "APPROVE")
                    {
                    builder.Append("<div class='col-md-3'><div class='panel panel-default'><div class='panel-body profile'><div class='profile-image'>");
                    builder.Append("<img  onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \"></div> <div class='profile-data'>");
                    builder.Append("<div class='profile-data-name'> " + ds.Tables[0].Rows[i]["tt_heading"] + "</div></div>");
                    builder.Append("<div class='profile-controls'> <a onclick='return ShowProfileModal(" + ds.Tables[0].Rows[i]["tt_by_user_id"] + ")' data-toggle='modal' class='profile-control-left'  href='#modal-regular-Profile'>");
                    builder.Append("<span   class='fa fa-info'></span></a> <a class='profile-control-right' target='_blank' href=" + ds.Tables[0].Rows[i]["tt_file_url"] + ">");
                    builder.Append("<i class='fa fa-download'></i></span></a> </div> </div> <div class='panel-body'><div class='newsletter-info'> ");
                    builder.Append("<div class='col-md-6'><div class='row'> <p><small><i class='fa fa-calendar'></i>Date Posted</small><br>" + ds.Tables[0].Rows[i]["tt_rdatetime"] + "</p></div></div>");
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

    #endregion TechTipsGetAll



    #region TechTipsApproveSearch

    private void TechTipsApproveSearch()
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

            DataSet ds = obj_techTips.TechTipsApprove_search(strFullName);
            if (ds != null)
            {
                string MessageTime = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    builder.Append("<a  title='View File'  class='list-group-item' target='_blank' href=" + ds.Tables[0].Rows[i]["tt_file_url"] + "> ");
                    builder.Append("<img  class='pull-left' onerror=\"this.onerror=null;this.src=\'../E2Forums-New/img/default_profile_pic.jpg';\" src=\" " + ds.Tables[0].Rows[i]["Picture"].ToString() + " \">");
                    builder.Append("<p><strong>" + ds.Tables[0].Rows[i]["tt_heading"] + "</strong></p>");
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

                    if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "REQUEST")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' onclick=\"TechTipsApproveAction( '" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' , 'APPROVE')\" type='radio'><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' onclick=\"TechTipsApproveAction( '" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' , 'REJECT')\" type='radio'><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                    else if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "APPROVE")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' onclick=\"TechTipsApproveAction( '" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' , 'APPROVE')\" type='radio' checked><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' onclick=\"TechTipsApproveAction( '" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' , 'REJECT')\" type='radio' ><span class='outer'><span class='inner reject'></span></span> Reject</label>");
                        builder.Append("</div>");
                        
                    }
                    else if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "REJECT")
                    {
                        builder.Append("<div class='slctMmb form-material'>");
                        builder.Append("<label class='radio-material'><input id='radio1" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' onclick=\"TechTipsApproveAction( '" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' , 'APPROVE')\" ><span class='outer'><span class='inner'></span></span> Approve </label>");
                        builder.Append("<label class='radio-material'><input id='radio2" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' onclick=\"TechTipsApproveAction( '" + ds.Tables[0].Rows[i]["tt_id"].ToString() + "' , 'REJECT')\" type='radio' checked><span class='outer'><span class='inner reject'></span></span> Reject</label>");
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

    #endregion TechTipsApproveSearch

    #region techTipsUpd

    private void techTipsUpd()
    {
        Int32 flag = -1;
        string strtt_heading, strtt_file_url,strtt_id;
        if (Request.Form["tt_heading"] != null)
        {
            strtt_heading = Convert.ToString(Request.Form["tt_heading"]);
        }
        else
        {
            strtt_heading = null;
        }
        if (Request.Form["tt_file_url"] != null)
        {
            strtt_file_url = Convert.ToString(Request.Form["tt_file_url"]);
        }
        else
        {
            strtt_file_url = null;
        }
        if (Request.Form["tt_id"] != null)
        {
            strtt_id = Convert.ToString(Request.Form["tt_id"]);
        }
        else
        {
            strtt_id = null;
        }

        try
        {
            obj_techTipsPrp.tt_id = Convert.ToInt32(strtt_id);
            obj_techTipsPrp.tt_heading = strtt_heading;
            obj_techTipsPrp.tt_by_user_id = Convert.ToInt32(mdblUserID);
            obj_techTipsPrp.tt_file_url = strtt_file_url;
            flag = obj_techTips.TechTipsUpd(obj_techTipsPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion techTipsUpd


    #region techTipsSend
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void techTipsSend()
    {
        Int32 flag = -1;
        string strtt_heading, strtt_file_url;
        if (Request.Form["tt_heading"] != null)
        {
            strtt_heading = Convert.ToString(Request.Form["tt_heading"]);
        }
        else
        {
            strtt_heading = null;
        }
        if (Request.Form["tt_file_url"] != null)
        {
            strtt_file_url = Convert.ToString(Request.Form["tt_file_url"]);
        }
        else
        {
            strtt_file_url = null;
        }

        try
        {

            obj_techTipsPrp.tt_heading = strtt_heading;
            obj_techTipsPrp.tt_by_user_id = Convert.ToInt32(mdblUserID);
            obj_techTipsPrp.tt_file_url = strtt_file_url;
            flag = obj_techTips.TechTipsSend(obj_techTipsPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion techTipsSend


    #region TechTipsApproveAction
    /// <summary>
    /// Author:dev  Date:11 /07/2015
    /// Function used to Grop for chat.
    /// </summary>
    private void TechTipsApproveAction()
    {
        Int32 flag = -1;
        string strtt_id, strtt_status;
        if (Request.Form["tt_id"] != null)
        {
            strtt_id = Convert.ToString(Request.Form["tt_id"]);
        }
        else
        {
            strtt_id = null;
        }
        if (Request.Form["tt_status"] != null)
        {
            strtt_status = Convert.ToString(Request.Form["tt_status"]);
        }
        else
        {
            strtt_status = null;
        }

        try
        {


            obj_techTipsPrp.tt_id = Convert.ToInt32(strtt_id);
            obj_techTipsPrp.tt_status = strtt_status;
            flag = obj_techTips.TechTipsApprove_Action(obj_techTipsPrp);

        }
        catch (Exception ex)
        {
            throw;
        }

        mstrResponseData = flag.ToString();
    }

    #endregion TechTipsApproveAction



    #region TechTipsGetMy

    private void TechTipsGetMy()
    {
        StringBuilder builder = new StringBuilder();
        try
        {
            obj_techTipsPrp.tt_by_user_id = Convert.ToInt32(mdblUserID);
            DataSet ds = obj_techTips.getMyTechTips(obj_techTipsPrp);
            if (ds != null)
            {
                
                builder.Append("<table class='table table-bordered table-striped table-actions'>");
                builder.Append("<thead><tr><th width='50'>Sr No.</th><th>Tech Tip Heading</th><th width='100'>Status</th><th width='100'>Date</th><th width='100'>Res. Date</th><th width='120'>Actions</th></tr></thead><tbody>");
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                 

                    builder.Append("</tr><td class='text-center'>" + ds.Tables[0].Rows[i]["SN"] + "</td>");
                    builder.Append(" <td><strong>" + ds.Tables[0].Rows[i]["tt_heading"] + "</strong></td>");
                    if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "REQUEST")
                    {
                        builder.Append(" <td><span class='label label-warning'>Request</span></td>");
                    }
                    else if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "APPROVE")
                    {
                        builder.Append(" <td><span class='label label-success'>Approve</span></td>");
                    }
                    else if (ds.Tables[0].Rows[i]["tt_status"].ToString() == "REJECT")
                    {
                        builder.Append(" <td><span class='label label-danger'>Reject</span></td>");
                    }
                      
                    if (ds.Tables[0].Rows[i]["tt_datetime"].ToString() != ds.Tables[0].Rows[i]["tt_rdatetime"].ToString())
                    {
                        builder.Append("<td>" + ds.Tables[0].Rows[i]["tt_datetime"] + "</td><td>" + ds.Tables[0].Rows[i]["tt_datetime"] + "</td><td>");
                    }
                    else
                    {
                        builder.Append("<td>" + ds.Tables[0].Rows[i]["tt_datetime"] + "</td><td>-</td><td>");
               
                    }

                    builder.Append("<button  onclick=\"techTips_get_edit('" + ds.Tables[0].Rows[i]["tt_id"] + "','" + ds.Tables[0].Rows[i]["tt_heading"] + "','" + ds.Tables[0].Rows[i]["tt_file_url"] + "') \" class='btn btn-default btn-rounded btn-condensed btn-sm' data-toggle='modal' data-target='#editTipTech'><span class='fa fa-pencil'></span></button>");
                  builder.Append("<button onclick='techTipDelete(" + ds.Tables[0].Rows[i]["tt_id"] + ");' data-toggle='tooltip' data-placement='top' title='Delete' class='btn btn-danger btn-rounded btn-condensed btn-sm'><span class='fa fa-times'></span></button>");
                  builder.Append("<a class='profile-control-right' target='_blank' href=" + ds.Tables[0].Rows[i]["tt_file_url"] + "><button data-toggle='tooltip'  data-placement='top' title='Download PDF' class='btn btn-success btn-rounded btn-condensed btn-sm'><i class='fa fa-download'></i></button></a>");
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

    #endregion TechTipsMemberAssign

    #endregion Functions


}

 