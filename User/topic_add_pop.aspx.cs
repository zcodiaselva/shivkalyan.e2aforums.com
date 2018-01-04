using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class User_topic_add_pop : System.Web.UI.Page
{
    CUser mobjCUser = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            bind_catagery();
        }
        
    }
    protected void saveClick(object sender, EventArgs e)
    {
        string lstr = mobjCUser.AddNewTopic(txtTitle.Text, txtDesc.Text,Convert.ToInt32(cmb_Categories1.SelectedValue),Convert.ToInt32(-1), true,Convert.ToInt32(Session["UserID"]));
       
        if (lstr.ToUpper() == "ALREADY EXISTS")
        {
            lbl_message.Text = "Error: Topic with same information already exists !";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Topic has been save successfully !')", true); 
            lbl_message.Text = "Topic has been save successfully !";
            txtDesc.Text = string.Empty;
            txtTitle.Text = string.Empty;
            cmb_Categories1.DataBind();

        }


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