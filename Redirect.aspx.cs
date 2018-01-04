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

public partial class RedirectUrl : System.Web.UI.Page
{
    #region Module Level objects
    CUser mobjCUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ToString());
    public Int32 AdvertisementID { get; set; }
    public double mdblUserID { get; set; }

    #endregion Module Level objects


    #region pageload
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
          
            if (Request.QueryString["i"] != null)
            {
                AdvertisementID = Convert.ToInt32(Request.QueryString["i"].ToString());
                if (Session["UserID"] != null)
                    mdblUserID = Convert.ToDouble(Session["UserID"]);
                UpdateAdvertisementCount();
            }           

        }//End try
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
        }//End catch
    }

    #endregion pageload



    #region UpdateAdvertisementCount
    private void UpdateAdvertisementCount()
    {
        string url = "";
       
        try
        {
            url = mobjCUsers.UpdateAdvertisementCount(mdblUserID, AdvertisementID);          
        }
        catch (Exception)
        {
            throw;
        }
       if(!string.IsNullOrEmpty(url))
       {
           Response.Redirect((url.IndexOf("http:") != -1 ? url : "http://"+url),true);
       }          
       
    }

    #endregion GetAdvertisementViewersCount




}