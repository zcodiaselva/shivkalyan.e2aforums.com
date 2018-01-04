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
using System.Web.Configuration;
public partial class response : System.Web.UI.Page
{
    Cls_RecurringPayment_prp obj_cls_prp = new Cls_RecurringPayment_prp();
    Cls_RecurringPayment obj_cls = new Cls_RecurringPayment();

    cls_payment_req_response_prp obj_clspayment_prp = new cls_payment_req_response_prp();
    cls_payment_req_response obj_clspayment = new cls_payment_req_response();
    protected void Page_Load(object sender, EventArgs e)
    {

        ServicePointManager.Expect100Continue = true;

        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        //Post back to either sandbox or live
        string strLive = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        // string strLive = "https://www.paypal.com/cgi-bin/webscr";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);

        //Set values for the request back
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
        string strRequest = Encoding.ASCII.GetString(param);
        strRequest += "&cmd=_notify-validate";
        req.ContentLength = strRequest.Length;

        //for proxy
        //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
        //req.Proxy = proxy;

        //Send the request to PayPal and get the response
        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
        streamOut.Write(strRequest);
        streamOut.Close();
        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
        string strResponse = streamIn.ReadToEnd();
        streamIn.Close();

        NumberFormatInfo info2 = new NumberFormatInfo();
        info2.NumberDecimalSeparator = ".";
        info2.NumberGroupSeparator = ",";
        info2.NumberGroupSizes = new int[] { 3 };


        if (strResponse == "VERIFIED")
        {


            try
            {
                if (Request.Form["txn_type"].ToString() == "" || Request.Form["txn_type"].ToString() == null)
                {
                    obj_cls_prp.txn_type = "";
                }
                else
                {
                    obj_cls_prp.txn_type = Request.Form["txn_type"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.txn_type = "";
            }

            try
            {
                if (Request.Form["subscr_id"].ToString() == "" || Request.Form["subscr_id"].ToString() == null)
                {
                    obj_cls_prp.subscr_id = "";
                }
                else
                {
                    obj_cls_prp.subscr_id = Request.Form["subscr_id"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.subscr_id = "";
            }


            try
            {
                if (Request.Form["last_name"].ToString() == "" || Request.Form["last_name"].ToString() == null)
                {
                    obj_cls_prp.last_name = "";
                }
                else
                {
                    obj_cls_prp.last_name = Request.Form["last_name"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.last_name = "";
            }

            try
            {
                if (Request.Form["residence_country"].ToString() == "" || Request.Form["residence_country"].ToString() == null)
                {
                    obj_cls_prp.residence_country = "";
                }
                else
                {
                    obj_cls_prp.residence_country = Request.Form["residence_country"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.residence_country = "";
            }

            try
            {
                if (Request.Form["mc_currency"].ToString() == "" || Request.Form["mc_currency"].ToString() == null)
                {
                    obj_cls_prp.mc_currency = "";
                }
                else
                {
                    obj_cls_prp.mc_currency = Request.Form["mc_currency"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.mc_currency = "";
            }


            try
            {
                if (Request.Form["item_name"].ToString() == "" || Request.Form["item_name"].ToString() == null)
                {
                    obj_cls_prp.item_name = "";
                }
                else
                {
                    obj_cls_prp.item_name = Request.Form["item_name"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.item_name = "";
            }

            try
            {
                if (Request.Form["business"].ToString() == "" || Request.Form["business"].ToString() == null)
                {
                    obj_cls_prp.business = "";
                }
                else
                {
                    obj_cls_prp.business = Request.Form["business"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.business = "";

            }
            try
            {
                if (Request.Form["recurring"].ToString() == "" || Request.Form["recurring"].ToString() == null)
                {
                    obj_cls_prp.recurring = "";
                }
                else
                {
                    obj_cls_prp.recurring = Request.Form["recurring"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.recurring = "";

            }
            try
            {
                if (Request.Form["verify_sign"].ToString() == "" || Request.Form["verify_sign"].ToString() == null)
                {
                    obj_cls_prp.verify_sign = "";
                }
                else
                {
                    obj_cls_prp.verify_sign = Request.Form["verify_sign"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.verify_sign = "";

            }
            try
            {
                if (Request.Form["payer_status"].ToString() == "" || Request.Form["payer_status"].ToString() == null)
                {
                    obj_cls_prp.payer_status = "";
                }
                else
                {
                    obj_cls_prp.payer_status = Request.Form["payer_status"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.payer_status = "";

            }

            try
            {
                if (Request.Form["test_ipn"].ToString() == "" || Request.Form["test_ipn"].ToString() == null)
                {
                    obj_cls_prp.test_ipn = "";
                }
                else
                {
                    obj_cls_prp.test_ipn = Request.Form["test_ipn"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.test_ipn = "";

            }
            try
            {
                if (Request.Form["payer_email"].ToString() == "" || Request.Form["payer_email"].ToString() == null)
                {
                    obj_cls_prp.payer_email = "";
                }
                else
                {
                    obj_cls_prp.payer_email = Request.Form["payer_email"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.payer_email = "";

            }

            try
            {
                if (Request.Form["first_name"].ToString() == "" || Request.Form["first_name"].ToString() == null)
                {
                    obj_cls_prp.first_name = "";
                }
                else
                {
                    obj_cls_prp.first_name = Request.Form["first_name"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.first_name = "";

            }
            try
            {
                if (Request.Form["receiver_email"].ToString() == "" || Request.Form["receiver_email"].ToString() == null)
                {
                    obj_cls_prp.receiver_email = "";
                }
                else
                {
                    obj_cls_prp.receiver_email = Request.Form["receiver_email"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.receiver_email = "";

            }
            try
            {
                if (Request.Form["payer_id"].ToString() == "" || Request.Form["payer_id"].ToString() == null)
                {
                    obj_cls_prp.payer_id = "";
                }
                else
                {
                    obj_cls_prp.payer_id = Request.Form["payer_id"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.payer_id = "";

            }

            try
            {
                if (Request.Form["reattempt"].ToString() == "" || Request.Form["reattempt"].ToString() == null)
                {
                    obj_cls_prp.reattempt = "";
                }
                else
                {
                    obj_cls_prp.reattempt = Request.Form["reattempt"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.reattempt = "";

            }
            try
            {
                if (Request.Form["item_number"].ToString() == "" || Request.Form["item_number"].ToString() == null)
                {
                    obj_cls_prp.item_number = "";
                }
                else
                {
                    obj_cls_prp.item_number = Request.Form["item_number"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.item_number = "";
            }
            try
            {
                if (Request.Form["subscr_date"].ToString() == "" || Request.Form["subscr_date"].ToString() == null)
                {
                    obj_cls_prp.subscr_date = "";
                }
                else
                {
                    obj_cls_prp.subscr_date = Request.Form["subscr_date"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.subscr_date = "";
            }
            try
            {
                if (Request.Form["subscr_effective"].ToString() == "" || Request.Form["subscr_effective"].ToString() == null)
                {
                    obj_cls_prp.subscr_effective = "";
                }
                else
                {
                    obj_cls_prp.subscr_effective = Request.Form["subscr_effective"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.subscr_effective = "";
            }
            try
            {
                if (Request.Form["custom"].ToString() == "" || Request.Form["custom"].ToString() == null)
                {
                    obj_cls_prp.custom = "";
                }
                else
                {
                    obj_cls_prp.custom = Request.Form["custom"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.custom = "";
            }

            try
            {
                if (Request.Form["charset"].ToString() == "" || Request.Form["charset"].ToString() == null)
                {
                    obj_cls_prp.charset = "";
                }
                else
                {
                    obj_cls_prp.charset = Request.Form["charset"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.charset = "";
            }
            try
            {
                if (Request.Form["notify_version"].ToString() == "" || Request.Form["notify_version"].ToString() == null)
                {
                    obj_cls_prp.notify_version = "";
                }
                else
                {
                    obj_cls_prp.notify_version = Request.Form["notify_version"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.notify_version = "";
            }
            try
            {
                if (Request.Form["period3"].ToString() == "" || Request.Form["period3"].ToString() == null)
                {
                    obj_cls_prp.period3 = "";
                }
                else
                {
                    obj_cls_prp.period3 = Request.Form["period3"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.period3 = "";
            }
            try
            {
                if (Request.Form["mc_amount3"].ToString() == "" || Request.Form["mc_amount3"].ToString() == null)
                {
                    obj_cls_prp.mc_amount3 = 0;
                }
                else
                {
                    obj_cls_prp.mc_amount3 = Convert.ToDecimal(Request.Form["mc_amount3"].ToString());
                }

            }
            catch
            {
                obj_cls_prp.mc_amount3 = 0;
            }
            try
            {
                if (Request.Form["ipn_track_id"].ToString() == "" || Request.Form["ipn_track_id"].ToString() == null)
                {
                    obj_cls_prp.ipn_track_id = "";
                }
                else
                {
                    obj_cls_prp.ipn_track_id = Request.Form["ipn_track_id"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.ipn_track_id = "";
            }

            try
            {
                if (Request.Form["mc_gross"].ToString() == "" || Request.Form["mc_gross"].ToString() == null)
                {
                    obj_cls_prp.mc_gross = 0;
                }
                else
                {
                    obj_cls_prp.mc_gross = Convert.ToDecimal(Request.Form["mc_gross"], info2);
                }
            }
            catch
            {
                obj_cls_prp.mc_gross = 0;
            }

            try
            {
                if (Request.Form["settle_amount"].ToString() == "" || Request.Form["settle_amount"].ToString() == null)
                {
                    obj_cls_prp.settle_amount = 0;
                }
                else
                {
                    obj_cls_prp.settle_amount = Convert.ToDecimal(Request.Form["settle_amount"], info2);
                }
            }
            catch
            {
                obj_cls_prp.settle_amount = 0;
            }

            try
            {
                if (Request.Form["protection_eligibility"].ToString() == "" || Request.Form["protection_eligibility"].ToString() == null)
                {
                    obj_cls_prp.protection_eligibility = "";
                }
                else
                {
                    obj_cls_prp.protection_eligibility = Request.Form["protection_eligibility"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.protection_eligibility = "";
            }
            try
            {
                if (Request.Form["payment_date"].ToString() == "" || Request.Form["payment_date"].ToString() == null)
                {
                    obj_cls_prp.payment_date = "";
                }
                else
                {
                    obj_cls_prp.payment_date = Request.Form["payment_date"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.payment_date = "";
            }
            try
            {
                if (Request.Form["mc_fee"].ToString() == "" || Request.Form["mc_fee"].ToString() == null)
                {
                    obj_cls_prp.mc_fee = 0;
                }
                else
                {
                    obj_cls_prp.mc_fee = Convert.ToDecimal(Request.Form["mc_fee"], info2);
                }
            }
            catch
            {
                obj_cls_prp.mc_fee = 0;
            }

            try
            {
                if (Request.Form["exchange_rate"].ToString() == "" || Request.Form["exchange_rate"].ToString() == null)
                {
                    obj_cls_prp.exchange_rate = "";
                }
                else
                {
                    obj_cls_prp.exchange_rate = Request.Form["exchange_rate"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.exchange_rate = "";
            }
            try
            {
                if (Request.Form["settle_currency"].ToString() == "" || Request.Form["settle_currency"].ToString() == null)
                {
                    obj_cls_prp.settle_currency = "";
                }
                else
                {
                    obj_cls_prp.settle_currency = Request.Form["settle_currency"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.settle_currency = "";
            }
            try
            {
                if (Request.Form["txn_id"].ToString() == "" || Request.Form["txn_id"].ToString() == null)
                {
                    obj_cls_prp.txn_id = "";
                }
                else
                {
                    obj_cls_prp.txn_id = Request.Form["txn_id"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.txn_id = "";
            }

            try
            {

                if (Request.Form["payment_type"].ToString() == "" || Request.Form["payment_type"].ToString() == null)
                {
                    obj_cls_prp.payment_type = "";

                }
                else
                {
                    obj_cls_prp.payment_type = Request.Form["payment_type"];

                }
            }
            catch
            {
                obj_cls_prp.payment_type = "";

            }

            try
            {

                if (Request.Form["payment_fee"].ToString() == "" || Request.Form["payment_fee"].ToString() == null)
                {
                    obj_cls_prp.payment_fee = "";

                }
                else
                {
                    obj_cls_prp.payment_fee = Request.Form["payment_fee"];

                }
            }
            catch
            {
                obj_cls_prp.payment_fee = "";

            }
            try
            {

                if (Request.Form["receiver_id"].ToString() == "" || Request.Form["receiver_id"].ToString() == null)
                {
                    obj_cls_prp.receiver_id = "";

                }
                else
                {
                    obj_cls_prp.receiver_id = Request.Form["receiver_id"];

                }
            }
            catch
            {
                obj_cls_prp.receiver_id = "";

            }


            obj_cls_prp.str_out_Response = "VERIFIED";


            try
            {
                if (Request.Form["payment_status"].ToString() == "" || Request.Form["payment_status"].ToString() == null)
                {
                    obj_cls_prp.payment_status = "";
                }
                else
                {
                    obj_cls_prp.payment_status = Request.Form["payment_status"].ToString();
                }

            }
            catch
            {
                obj_cls_prp.payment_status = "";
            }
            try
            {
                if (Request.Form["pending_reason"].ToString() == "" || Request.Form["pending_reason"].ToString() == null)
                {
                    obj_cls_prp.pending_reason = "";
                }
                else
                {
                    obj_cls_prp.pending_reason = Request.Form["pending_reason"].ToString();
                }
            }
            catch
            {
                obj_cls_prp.pending_reason = "";
            }




            // transaction Is good payment is done
            obj_cls.save_RecurringPayment_req_response(obj_cls_prp);



        }
        else if (strResponse == "INVALID")
        {

        }
        else
        {

        }
    }
    
    
}
