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
        //string strLive = "https://www.sandbox.paypal.com/cgi-bin/webscr";
       string strLive = "https://www.paypal.com/cgi-bin/webscr";
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
                obj_cls_prp.ipn_track_id ="";
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



            if (obj_cls_prp.str_out_Response == "VERIFIED")
            { 


                try
                {
                    if (obj_cls_prp.txn_type == "subscr_payment")
                    {
                        DataSet ds = new DataSet();
                        ds = obj_cls.RecurringPaymentInvoiceByReqID(obj_cls_prp.custom.ToString());


                        string strEmail = "";
                        String StrFullName = "";
                        string strreq_date_time = "";
                        if (ds.Tables[0].Rows[0]["EMail"] != null)
                        {
                            strEmail = ds.Tables[0].Rows[0]["EMail"].ToString();
                        }


                        if (ds.Tables[0].Rows[0]["Full_Name"] != null)
                        {
                            StrFullName = ds.Tables[0].Rows[0]["Full_Name"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["req_date_time"] != null)
                        {
                            strreq_date_time = ds.Tables[0].Rows[0]["req_date_time"].ToString();
                        }

                        string strPlanTillDate = "";
                        if (ds.Tables[0].Rows[0]["PlanTillDate"] != null)
                        {
                            strPlanTillDate = ds.Tables[0].Rows[0]["PlanTillDate"].ToString();
                        }

                        string stritem_name = "";

                        if (ds.Tables[0].Rows[0]["item_name"] != null)
                        {
                            stritem_name = ds.Tables[0].Rows[0]["item_name"].ToString();
                        }
                        string strmc_gross = "0";

                        if (ds.Tables[0].Rows[0]["mc_gross"] != null)
                        {
                            strmc_gross = ds.Tables[0].Rows[0]["mc_gross"].ToString();

                            strmc_gross = string.Format("{0:0.00}", strmc_gross).ToString();

                        }

                        string strPlanAmount = "0";
                        if (ds.Tables[0].Rows[0]["Amount"] != null)
                        {
                            strPlanAmount = ds.Tables[0].Rows[0]["Amount"].ToString();
                        }

                        string strTax = Convert.ToString(Convert.ToDecimal(strmc_gross) - Convert.ToDecimal(strPlanAmount));

                        strTax = string.Format("{0:0.00}", strTax).ToString();

                        string strmc_fee = "";

                        if (ds.Tables[0].Rows[0]["mc_fee"] != null)
                        {
                            strmc_fee = ds.Tables[0].Rows[0]["mc_fee"].ToString();
                            strmc_fee = string.Format("{0:0.00}", strmc_fee).ToString();
                        }
                        string strpayment_status = "";
                        if (ds.Tables[0].Rows[0]["payment_status"] != null)
                        {
                            strpayment_status = ds.Tables[0].Rows[0]["payment_status"].ToString();
                        }

                        CMail lobjMail = new CMail();
                        Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();

                        string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("~/PaymentInvoice.txt"), Encoding.UTF8);
                        lstrMessage = lstrMessage.Replace("<Name>", StrFullName);
                        lstrMessage = lstrMessage.Replace("<Email>", strEmail);
                        lstrMessage = lstrMessage.Replace("<req_date_time>", strreq_date_time);
                        lstrMessage = lstrMessage.Replace("<PlanTillDate>", strPlanTillDate);
                        lstrMessage = lstrMessage.Replace("<item_name>", stritem_name);
                        lstrMessage = lstrMessage.Replace("<mc_gross>", strmc_gross);
                        lstrMessage = lstrMessage.Replace("<PlanAmount>", strPlanAmount);
                        lstrMessage = lstrMessage.Replace("<Tax>", strTax);
                        //lstrMessage = lstrMessage.Replace("<mc_fee>", strmc_fee);
                        lstrMessage = lstrMessage.Replace("<payment_status>", strpayment_status);


                        lobjMail.EmailTo = strEmail;
                        lobjMail.Subject = "e2aForums : Payment Invoice";
                        lobjMail.MessageBody = lstrMessage;
                        lobjMail.SendEMail();
                    }
                }
                catch (Exception ex)
                {


                    CMail lobjMail = new CMail();
                    Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();

                    

                    lobjMail.EmailTo = "davinderantil@gmail.com";
                    lobjMail.Subject = "e2aForums:Payment Error";
                    lobjMail.MessageBody = ex.ToString()  ;
                    lobjMail.SendEMail();
                }

            }


        }
        else if (strResponse == "INVALID")
        {
            


        }
        else
        {
            //log response/ipn data for manual investigation
        }
    }
    public string business { get; set; }
}

///---------------------------------Star old Code 3 18 2016
//ServicePointManager.Expect100Continue = true;

////ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
//ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
//HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

////Header Settings

//req.Method = "POST"; // Post method

//req.ContentType = "text/xml";// content type

//req.KeepAlive = false;

//req.ProtocolVersion = HttpVersion.Version10;

////Certificate with private key

////X509Certificate2 cert = new X509Certificate2("Cert.der","Password");

////req.ClientCertificates.Add(cert);

//req.PreAuthenticate = true;

//String XML = "Test Message";//reader.ReadToEnd();

//byte[] buffer = Encoding.ASCII.GetBytes(XML);

//req.ContentLength = buffer.Length;

//// Wrap the request stream with a text-based writer

//Stream writer = req.GetRequestStream();

//// Write the XML text into the stream

//writer.Write(buffer, 0, buffer.Length);

//writer.Close();

//WebResponse rsp = req.GetResponse();

//StreamReader streamIn = new StreamReader(rsp.GetResponseStream());
//string strResponse = streamIn.ReadToEnd();
//streamIn.Close();


///---------------------------------End Old 3 18 2016

//public void save_rec(string txn_id, decimal mc_gross, string payer_email, string first_name, string last_name, string address_street, string address_city, string address_state, string address_zip, string address_country, string custom, string tf_val, string output)
//    {

//        //Label1.Text = "transaction id" + Request.Form["txn_id"] + " Mc Gross : " + Convert.ToDecimal(Request.Form["mc_gross"], info2) + "Payer Email:  " + Request.Form["payer_email"] + " First Name : " + Request.Form["first_name"] +
//        //    " Last NAme : " + Request.Form["last_name"] + " Address Street : " + Request.Form["address_street"] + "Address City :  " + Request.Form["address_city"] + " State :" +
//        //    Request.Form["address_state"] + " Address Zip " + Request.Form["address_zip"] + " Country : " + Request.Form["address_country"] +
//        //    " Custom : " + Request.Form["custom"] + "bussinus val :" + Request.Form["business"] + " Payer ID Val : " + Request.Form["payer_id"] +
//        //    " Item Number val " + Request.Form["item_number"] + " Item Name  val" + Request.Form["item_name"] + " txt Type val  :" + Request.Form["txn_type"] +
//        //    " Pay Status : " + Request.Form["payment_status"] + " reson Val : " + Request.Form["pending_reason"] + " Pay Type val " +
//        //    Request.Form["payment_type"] + " Mc Fee val : " + Convert.ToDecimal(Request.Form["mc_fee"], info2) + " Cur val : " + Request.Form["mc_currency"] + " Pay Date Val : " + Request.Form["payment_date"] + "da " + Request.Form["verify_sign"];


//        //string s_txn_id = "";
//        //string s_payment_date = "";
//        //string s_payer_email = "";
//        //string s_business = "";
//        //string s_payer_id = "";
//        //string s_item_number = "";
//        //string s_item_name = "";
//        //string s_txn_type = "";
//        //string s_payment_status = "";
//        //string s_pending_reason = "";
//        //string s_payment_type = "";
//        //string s_mc_gross = "";
//        //string s_mc_fee = "";
//        //string s_mc_currency = "";
//        //string s_buy_first_name = "";
//        //string s_buy_last_name = "";
//        //string s_buy_address_street = "";
//        //string s_buy_address_city = "";
//        //string s_buy_address_state = "";
//        //string s_buy_address_zip = "";
//        //string s_buy_address_country = "";
//        //string s_verify_sign = "";


//        obj_cls_prp.txn_id = txn_id;
//        obj_cls_prp.payment_date = DateTime.Now; // DateTime.Parse(Request.Form["payment_date"]).Date;
//        obj_cls_prp.payer_email = payer_email;
//        obj_cls_prp.business = "";
//        obj_cls_prp.payer_id = "";
//        obj_cls_prp.item_number = "";
//        obj_cls_prp.item_name = "";
//        obj_cls_prp.txn_type = "";
//        obj_cls_prp.payment_status = "";
//        obj_cls_prp.pending_reason = "";
//        obj_cls_prp.payment_type = "";
//        obj_cls_prp.mc_gross = mc_gross;//Request.Form["mc_gross"];
//        obj_cls_prp.mc_fee = mc_gross;//Request.Form["mc_fee"];
//        obj_cls_prp.mc_currency = "mc_currency";
//        obj_cls_prp.buy_first_name = first_name;
//        obj_cls_prp.buy_last_name = last_name;
//        obj_cls_prp.buy_address_street = address_street;
//        obj_cls_prp.buy_address_city = address_city;
//        obj_cls_prp.buy_address_state = address_state;
//        obj_cls_prp.buy_address_zip = address_zip;
//        obj_cls_prp.buy_address_country = address_country;
//        obj_cls_prp.verify_sign = "verify_sign";
//        obj_cls.save_payment_req_response(obj_cls_prp);

//    }

//transaction id5H891813V1983151W Mc Gross : 400.00 Payer Email: devbu@gmail.com First Name : Dev Bu Last NAme : Kumar Address Street : Address City : State : Address Zip Country : Custom : 78999633
//transaction id9B699112LN8655724 Mc Gross : 400.00Payer Email: devbu@gmail.com First Name : Dev Bu Last NAme : Kumar Address Street : Address City : State : Address Zip Country : Custom : 78999633bussinus val : Payer ID Val : ZGGYQ47G7S8AC Item Number val 1234 Item Name valItem name txt Type val :web_accept Pay Status : Pending reson Val : unilateral Pay Type val instant Mc Fee val : 0 Cur val USD
//                "INVALID payment's parameters" + "(receiver_email or txn_type)");






//            Label1.Text += Request.Form["txn_id"].ToString() + Request.Form["receiver_email"].ToString();

//  Label1.Text += Request.Form["txn_id"].ToString() + Request.Form["receiver_email"].ToString() +
//       Request.Form["txn_id"] + Request.Form["payer_email"] + Request.Form["first_name"] + Request.Form["last_name"] + Request.Form["address_street"] + Request.Form["address_city"]+ Request.Form["address_state"]+ Request.Form["address_zip"] + Request.Form["address_country"] + Request.Form["item_name"] + Request.Form["item_number"] + Request.Form["payment_id"]  + Request.Form["custom"] +   Request.Form["request_id"] ;




//string requestUriString;
//   CultureInfo provider = new CultureInfo("en-us");


//   string strFormValues = Encoding.ASCII.GetString(
//       this.Request.BinaryRead(this.Request.ContentLength));


//   requestUriString = "https://www.sandbox.paypal.com/cgi-bin/webscr";

//   // Create the request back
//   HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);

//   // Set values for the request back
//   request.Method = "POST";
//   request.ContentType = "application/x-www-form-urlencoded";
//   string obj2 = strFormValues + "&cmd=_notify-validate";
//   request.ContentLength = obj2.Length;




//   //send the request, read the response
//   HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//   Stream responseStream = response.GetResponseStream();
//   Encoding encoding = Encoding.GetEncoding("utf-8");
//   StreamReader reader = new StreamReader(responseStream, encoding);

//   // Reads 256 characters at a time.

//   char[] buffer = new char[0x101];
//   int length = reader.Read(buffer, 0, 0x100);
//   while (length > 0)
//   {
//       // Dumps the 256 characters to a string

//       string requestPrice;
//       string IPNResponse = new string(buffer, 0, length);
//       length = reader.Read(buffer, 0, 0x100);


//       NumberFormatInfo info2 = new NumberFormatInfo();
//       info2.NumberDecimalSeparator = ".";
//       info2.NumberGroupSeparator = ",";
//       info2.NumberGroupSizes = new int[] { 3 };

//       // if the request is verified
//       if (String.Compare(IPNResponse, "VERIFIED", false) == 0)
//       {
//           // check the receiver's e-mail (login is user's
//           // identifier in PayPal)
//           // and the transaction type
//           if ((String.Compare(this.Request["receiver_email"], this.business, false) != 0) || (String.Compare(this.Request["txn_type"], "web_accept", false) != 0))
//           {
//               try
//               {
//                   // parameters are not correct. Write a
//                   // response from PayPal
//                   // and create a record in the Log file.
//                   save_rec(this.Request["txn_id"], Convert.ToDecimal(this.Request["mc_gross"], info2), this.Request["payer_email"], this.Request["first_name"],
//                       this.Request["last_name"],
//                       this.Request["address_street"],
//                       this.Request["address_city"],
//                       this.Request["address_state"],
//                       this.Request["address_zip"],
//                       this.Request["address_country"],
//                      this.Request["custom"], "false",
//                       "INVALID payment's parameters" + "(receiver_email or txn_type)");

//               }
//               catch (Exception exception)
//               {

//               }
//               reader.Close();
//               response.Close();
//               return;
//           }


//           try
//           {
//               // write a response from PayPal
//               save_rec(this.Request["txn_id"],
//                   Convert.ToDecimal(this.Request["mc_gross"], info2),
//                   this.Request["payer_email"],
//                   this.Request["first_name"],
//                   this.Request["last_name"],
//                   this.Request["address_street"],
//                   this.Request["address_city"],
//                   this.Request["address_state"],
//                   this.Request["address_zip"],
//                   this.Request["address_country"],
//                  this.Request["custom"], "true", "");

//               ///////////////////////////////////////////////////
//               // Here we notify the person responsible for
//               // goods delivery that
//               // the payment was performed and providing
//               // him with all needed information about
//               // the payment. Some flags informing that
//               // user paid for a services can be also set here.
//               // For example, if user paid for registration
//               // on the site, then the flag should be set
//               // allowing the user who paid to access the site
//               //////////////////////////////////////////////////
//           }
//           catch (Exception exception)
//           {

//           }
//       }
//       else
//       {

//       }
//   }
//   reader.Close();
//   response.Close();