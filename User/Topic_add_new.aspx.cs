using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using payment_cc;
public partial class User_pro : System.Web.UI.Page
{
    string bac_url = "";
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    double mdblUserID = -1;
    public Int32 UseIDCurent { get; set; }
    public Int32 ReferenceID { get; set; }
    public int UserTypeID = -1;
    public string NotificationType { get; set; }
    public Int32 NotificationID { get; set; }
    public bool IsAdmin { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
           if(Request.QueryString["abc"].ToString()!=null)
           {
               bac_url = Request.QueryString["abc"].ToString();
           }

           

            bind_catagery();
        }
        else
        {
            bac_url = Request.QueryString["abc"].ToString();
        }
        if (Session["UserID"] != null)
        {
            mdblUserID = Convert.ToDouble(Session["UserID"]);
            UseIDCurent =Convert.ToInt32( Session["UserID"].ToString());
        }
        if (Session["IsAdmin"] != null)
        {
            IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
        }
        else
            IsAdmin = false;
        if (Request.Form["Type"] != null)
            NotificationType = Convert.ToString(Request.Form["Type"]);

        if (Request.Form["ID"] != null)
        {
            ReferenceID = Convert.ToInt32(Request.Form["ID"]);
        }
        if (Request.Form["NotificationID"] != null)
        {
            NotificationID = Convert.ToInt32(Request.Form["NotificationID"]);
        }

        if (Session["UserTypeID"] != null)
        {
            UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        }

    }
   
   
    protected void saveClick(object sender, EventArgs e)
    {
        string lstr = mobjCUser.AddNewTopic(txtTitle.Text, txtDesc.Text, Convert.ToInt32(cmb_Categories1.SelectedValue), Convert.ToInt32(-1), true, Convert.ToInt32(Session["UserID"]));

        if (lstr.ToUpper() == "ALREADY EXISTS")
        {
            lbl_message.Text = "Error: Topic with same information already exists !";
            lbl_message.ForeColor=System.Drawing.Color.Red;
        }
        else if (lstr.ToUpper() == "-1")
        {
            lbl_message.Text = "Free users cannot add topics. Upgrade to paid plan , <a href='../Pricing.aspx' target='_blank'> Click Here</a></div>";
            lbl_message.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            
            txtDesc.Text = string.Empty;
            txtTitle.Text = string.Empty;
            cmb_Categories1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('The Topic  under  category ( " + cmb_Categories1.SelectedItem.Text.ToString() + " ) has been save successfully!  ,Redirecting  to " + bac_url + " page in 3 Second .'); setInterval(function(){location.href='" + bac_url + "';},3000);", true);

           
        }


    }
    protected void cancelClick(object sender, EventArgs e)
    {
        Response.Redirect(bac_url);
    }

    private void bind_catagery()
    {
        DataSet lobjDS = new DataSet();

        try
        {

            lobjDS = mobjCUser.FillCategoryCombo();

            cmb_Categories1.DataSource = lobjDS;
            cmb_Categories1.DataTextField = "Title";
            cmb_Categories1.DataValueField = "CategoryID";
            cmb_Categories1.DataBind();
        }
        catch
        {


        }
    }

}