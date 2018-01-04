using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;
using System;
using payment_cc;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class response : System.Web.UI.Page
{
    cls_payment_req_response_prp obj_cls_prp = new cls_payment_req_response_prp();
    cls_payment_req_response obj_cls = new cls_payment_req_response();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["ReqID"].ToString() == "" || Request.QueryString["ReqID"].ToString() == null)
            {
                Response.Redirect("../AccessDenied.html");
            }
            else
            {


                DataSet ds = new DataSet();
                ds = obj_cls.RecurringPaymentInvoiceInfoId(Request.QueryString["ReqID"].ToString());

                NumberFormatInfo info2 = new NumberFormatInfo();
                info2.NumberDecimalSeparator = ".";
                info2.NumberGroupSeparator = ",";
                info2.NumberGroupSizes = new int[] { 3 };



                try
                {
                    if (ds.Tables[0].Rows[0]["txn_id"].ToString() == "" || ds.Tables[0].Rows[0]["txn_id"].ToString() == null)
                    {

                        lbl_trans_id.Text = "";
                    }
                    else
                    {

                        lbl_trans_id.Text = ds.Tables[0].Rows[0]["txn_id"].ToString();
                    }
                }
                catch
                {
                    lbl_trans_id.Text = "";
                }



                lblPaymentDate.Text = DateTime.Now.ToString();

                try
                {
                    if (ds.Tables[0].Rows[0]["payer_email"].ToString() == "" || ds.Tables[0].Rows[0]["payer_email"].ToString() == null)
                    {

                        lbl_buyer_Email.Text = "";
                    }
                    else
                    {

                        lbl_buyer_Email.Text = ds.Tables[0].Rows[0]["payer_email"].ToString();
                    }
                }
                catch
                {
                    lbl_buyer_Email.Text = "";


                }



                try
                {
                    if (ds.Tables[0].Rows[0]["payer_id"].ToString() == "" || ds.Tables[0].Rows[0]["payer_id"].ToString() == null)
                    {

                        lblBuyerid.Text = "";
                    }
                    else
                    {

                        lblBuyerid.Text = ds.Tables[0].Rows[0]["payer_id"].ToString();
                    }
                }
                catch
                {
                    lblBuyerid.Text = "";
                }

                try
                {
                    if (ds.Tables[0].Rows[0]["item_number"].ToString() == "" || ds.Tables[0].Rows[0]["item_number"].ToString() == null)
                    {

                        lbl_Item_Id.Text = "";
                    }
                    else
                    {

                        lbl_Item_Id.Text = ds.Tables[0].Rows[0]["item_number"].ToString();
                    }

                }
                catch
                {
                    lbl_Item_Id.Text = "";

                }


                try
                {

                    if (ds.Tables[0].Rows[0]["item_name"].ToString() == "" || ds.Tables[0].Rows[0]["item_name"].ToString() == null)
                    {
                        lbl_Item_name.Text = "";
                    }
                    else
                    {

                        lbl_Item_name.Text = ds.Tables[0].Rows[0]["item_name"].ToString();
                    }
                }
                catch
                {
                    lbl_Item_name.Text = "";
                }












                try
                {
                    if (ds.Tables[0].Rows[0]["mc_gross"].ToString() == "" || ds.Tables[0].Rows[0]["mc_gross"].ToString() == null)
                    {
                        lbl_Total_amount.Text = "";
                    }
                    else
                    {

                        lbl_Total_amount.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["mc_gross"], info2).ToString();
                        lbl_Total_amount1.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["mc_gross"], info2).ToString();

                        lbl_Total_amount.Text = string.Format("{0:#.00}",lbl_Total_amount.Text).ToString();
                    }
                }
                catch
                {
                    lbl_Total_amount.Text = "";
                    lbl_Total_amount1.Text = "";
                }


                blb_buyName.Text = ds.Tables[0].Rows[0]["Full_name"].ToString() ;

            }
        }
        catch
        {
            Response.Redirect("../AccessDenied.html");

        }
    }
}



