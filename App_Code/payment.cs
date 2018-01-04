using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Text;

using System.Web.UI;
using System.Web.UI.WebControls;
using E2aForums;
using System.Web.Configuration;


using System.Net.Mail;
using System.Net;
namespace payment_cc
{

    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }

    }

    public interface int_payment_req_response
    {


        Int32 pay_req_response_id { get; set; }
        String txn_id { get; set; }
        DateTime payment_date { get; set; }
        String payer_email { get; set; }
        String business { get; set; }
        String payer_id { get; set; }
        String item_number { get; set; }
        String item_name { get; set; }
        String txn_type { get; set; }
        String payment_status { get; set; }
        String pending_reason { get; set; }
        String payment_type { get; set; }
        Decimal mc_gross { get; set; }
        Decimal mc_fee { get; set; }
        String mc_currency { get; set; }
        String buy_first_name { get; set; }
        String buy_last_name { get; set; }
        String buy_address_street { get; set; }
        String buy_address_city { get; set; }
        String buy_address_state { get; set; }
        String buy_address_zip { get; set; }
        String buy_address_country { get; set; }
        String verify_sign { get; set; }
        String pay_res_date { get; set; }
        String str_out_Response { get; set; }
        String out_flag_val { get; set; }
        Int32 req_id { get; set; }



        //Request Table Value
        Int32 by_user_id { get; set; }
    }

    public class cls_payment_req_response_prp : int_payment_req_response
    {

        Int32 _pay_req_response_id;
        String _txn_id;
        DateTime _payment_date;
        String _payer_email;
        String _business;
        String _payer_id;
        String _item_number;
        String _item_name;
        String _txn_type;
        String _payment_status;
        String _pending_reason;
        String _payment_type;
        Decimal _mc_gross;
        Decimal _mc_fee;
        String _mc_currency;
        String _buy_first_name;
        String _buy_last_name;
        String _buy_address_street;
        String _buy_address_city;
        String _buy_address_state;
        String _buy_address_zip;
        String _buy_address_country;
        String _verify_sign;
        String _pay_res_date;
        String _str_out_Response;
        String _out_flag_val;
        Int32 _req_id;


        //Request Table Value
        Int32 _by_user_id;


        public int by_user_id
        {
            get
            {
                return _by_user_id;
            }
            set
            {
                _by_user_id = value;
            }
        }


        public int pay_req_response_id
        {
            get
            {
                return _pay_req_response_id;
            }
            set
            {
                _pay_req_response_id = value;
            }
        }

        public string txn_id
        {
            get
            {
                return _txn_id;
            }
            set
            {
                _txn_id = value;
            }
        }

        public DateTime payment_date
        {
            get
            {
                return _payment_date;
            }
            set
            {
                _payment_date = value;
            }
        }

        public string payer_email
        {
            get
            {
                return _payer_email;
            }
            set
            {
                _payer_email = value;
            }
        }

        public string business
        {
            get
            {
                return _business;
            }
            set
            {
                _business = value;
            }
        }

        public string payer_id
        {
            get
            {
                return _payer_id;
            }
            set
            {
                _payer_id = value;
            }
        }

        public string item_number
        {
            get
            {
                return _item_number;
            }
            set
            {
                _item_number = value;
            }
        }

        public string item_name
        {
            get
            {
                return _item_name;
            }
            set
            {
                _item_name = value;
            }
        }

        public string txn_type
        {
            get
            {
                return _txn_type;
            }
            set
            {
                _txn_type = value;
            }
        }

        public string payment_status
        {
            get
            {
                return _payment_status;
            }
            set
            {
                _payment_status = value;
            }
        }

        public string pending_reason
        {
            get
            {
                return _pending_reason;
            }
            set
            {
                _pending_reason = value;
            }
        }

        public string payment_type
        {
            get
            {
                return _payment_type;
            }
            set
            {
                _payment_type = value;
            }
        }

        public decimal mc_gross
        {
            get
            {
                return _mc_gross;
            }
            set
            {
                _mc_gross = value;
            }
        }

        public decimal mc_fee
        {
            get
            {
                return _mc_fee;
            }
            set
            {
                _mc_fee = value;
            }
        }

        public string mc_currency
        {
            get
            {
                return _mc_currency;
            }
            set
            {
                _mc_currency = value;
            }
        }

        public string buy_first_name
        {
            get
            {
                return _buy_first_name;
            }
            set
            {
                _buy_first_name = value;
            }
        }

        public string buy_last_name
        {
            get
            {
                return _buy_last_name;
            }
            set
            {
                _buy_last_name = value;
            }
        }

        public string buy_address_street
        {
            get
            {
                return _buy_address_street;
            }
            set
            {
                _buy_address_street = value;
            }
        }

        public string buy_address_city
        {
            get
            {
                return _buy_address_city;
            }
            set
            {
                _buy_address_city = value;
            }
        }

        public string buy_address_state
        {
            get
            {
                return _buy_address_state;
            }
            set
            {
                _buy_address_state = value;
            }
        }

        public string buy_address_zip
        {
            get
            {
                return _buy_address_zip;
            }
            set
            {
                _buy_address_zip = value;
            }
        }

        public string buy_address_country
        {
            get
            {
                return _buy_address_country;
            }
            set
            {
                _buy_address_country = value;
            }
        }

        public string verify_sign
        {
            get
            {
                return _verify_sign;
            }
            set
            {
                _verify_sign = value;
            }
        }

        public string pay_res_date
        {
            get
            {
                return _pay_res_date;
            }
            set
            {
                _pay_res_date = value;
            }
        }
        public string str_out_Response
        {
            get
            {
                return _str_out_Response;
            }
            set
            {
                _str_out_Response = value;
            }
        }
        public string out_flag_val
        {
            get
            {
                return _out_flag_val;
            }
            set
            {
                _out_flag_val = value;
            }
        }


        public int req_id
        {
            get
            {
                return _req_id;
            }
            set
            {
                _req_id = value;
            }
        }

    }

    public class cls_payment_req_response : clscon
    {

        public Int32 save_payment_req_response(cls_payment_req_response_prp p)
        {
            Int32 Flag = 1;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_PaymentReqResponseSave";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@txn_id", SqlDbType.VarChar, (50)).Value = p.txn_id;
            cmd.Parameters.Add("@payment_date", SqlDbType.DateTime).Value = p.payment_date;
            cmd.Parameters.Add("@payer_email", SqlDbType.VarChar, (50)).Value = p.payer_email;
            cmd.Parameters.Add("@business", SqlDbType.VarChar, (50)).Value = p.business;
            cmd.Parameters.Add("@payer_id", SqlDbType.VarChar, (50)).Value = p.payer_id;
            cmd.Parameters.Add("@item_number", SqlDbType.VarChar, (50)).Value = p.item_number;
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar, (50)).Value = p.item_name;
            cmd.Parameters.Add("@txn_type", SqlDbType.VarChar, (50)).Value = p.txn_type;
            cmd.Parameters.Add("@payment_status", SqlDbType.VarChar, (50)).Value = p.payment_status;
            cmd.Parameters.Add("@pending_reason", SqlDbType.VarChar, (50)).Value = p.pending_reason;
            cmd.Parameters.Add("@payment_type", SqlDbType.VarChar, (50)).Value = p.payment_type;
            cmd.Parameters.Add("@mc_gross", SqlDbType.Money).Value = p.mc_gross;
            cmd.Parameters.Add("@mc_fee", SqlDbType.Money).Value = p.mc_fee;
            cmd.Parameters.Add("@mc_currency", SqlDbType.VarChar, (50)).Value = p.mc_currency;
            cmd.Parameters.Add("@buy_first_name", SqlDbType.VarChar, (50)).Value = p.buy_first_name;
            cmd.Parameters.Add("@buy_last_name", SqlDbType.VarChar, (50)).Value = p.buy_last_name;
            cmd.Parameters.Add("@buy_address_street", SqlDbType.VarChar, (50)).Value = p.buy_address_street;
            cmd.Parameters.Add("@buy_address_city", SqlDbType.VarChar, (50)).Value = p.buy_address_city;
            cmd.Parameters.Add("@buy_address_state", SqlDbType.VarChar, (50)).Value = p.buy_address_state;
            cmd.Parameters.Add("@buy_address_zip", SqlDbType.VarChar, (50)).Value = p.buy_address_zip;
            cmd.Parameters.Add("@buy_address_country", SqlDbType.VarChar, (50)).Value = p.buy_address_country;
            cmd.Parameters.Add("@verify_sign", SqlDbType.VarChar, (50)).Value = p.verify_sign;
            cmd.Parameters.Add("@pay_res_date", SqlDbType.VarChar, (50)).Value = p.pay_res_date;
            cmd.Parameters.Add("@str_out_Response", SqlDbType.VarChar, (50)).Value = p.str_out_Response;
            cmd.Parameters.Add("@out_flag_val", SqlDbType.VarChar, (50)).Value = p.out_flag_val;
            cmd.Parameters.Add("@req_id", SqlDbType.Int).Value = p.req_id;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Flag = Convert.ToInt32(sqlparm.Value);




            return Flag;

        }



        public Int32 Save_payment_req(cls_payment_req_response_prp p)
        {
            Int32 Flag = 1;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_PaymentReqSave";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@by_user_id", SqlDbType.VarChar, (50)).Value = p.by_user_id;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Flag = Convert.ToInt32(sqlparm.Value);
            return Flag;

        }


        public DataSet PaymentDetails()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_PaymentDetails", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }



        public DataSet PaymentDetailsMy(int UserID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_PaymentInvoice", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            adp.Fill(ds);
            return ds;

        }

        public DataSet PaymentDetailsReqId(string p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_PaymentDetailsReqId", con);
            adp.SelectCommand.Parameters.Add("@pay_req_response_id", SqlDbType.Int).Value = Convert.ToInt32(p);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }

        public DataSet PaymentInvoiceByReqID(string p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_PaymentInvoiceByReqID", con);
            adp.SelectCommand.Parameters.Add("@req_id", SqlDbType.Int).Value = Convert.ToInt32(p);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }




        public DataSet UserPayValidate(string valEmail)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("Sp_PaymentUserValidate", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@EMail", SqlDbType.VarChar).Value = valEmail;
            adp.Fill(ds);
            return ds;


        }



        public DataSet PlanGetInfo(string planID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_planGetInfo", con);
            adp.SelectCommand.Parameters.Add("@PlanID", SqlDbType.Int).Value = Convert.ToInt32(planID);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }



        public DataSet PlanLogGet()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_PlanLogGet", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }


        ///////////Recurring realed Code Apr 13 2016
        public DataSet RecurringPaymentDetails()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_RecurringPaymentDetails", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }


        public DataSet RecurringPaymentProfile()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_RecurringProfileDetails", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }

        public DataSet RecurringPaymentDetailsReqId(string p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_RecurringPaymentDetailsReqId", con);
            adp.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(p);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }


        public DataSet RecurringPaymentDetailsMy(int UserID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_RecurringPaymentDetailsMy", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            adp.Fill(ds);
            return ds;

        }


        public DataSet RecurringPaymentInvoiceInfoId(string p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_RecurringPaymentInvoiceInfoId", con);
            adp.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(p);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }
    }




    public interface int_RecurringPayment
    {
        Int32 id { get; set; }
        String txn_type { get; set; }
        String subscr_id { get; set; }
        String last_name { get; set; }
        String residence_country { get; set; }
        String mc_currency { get; set; }
        String item_name { get; set; }
        String business { get; set; }
        String recurring { get; set; }
        String verify_sign { get; set; }
        String payer_status { get; set; }
        String test_ipn { get; set; }
        String payer_email { get; set; }
        String first_name { get; set; }
        String receiver_email { get; set; }
        String payer_id { get; set; }
        String reattempt { get; set; }
        String item_number { get; set; }
        String subscr_date { get; set; }
        String subscr_effective { get; set; }
        String custom { get; set; }
        String charset { get; set; }
        String notify_version { get; set; }
        String period3 { get; set; }
        Decimal mc_amount3 { get; set; }
        String ipn_track_id { get; set; }
        Decimal mc_gross { get; set; }
        Decimal settle_amount { get; set; }
        String protection_eligibility { get; set; }
        String payment_date { get; set; }
        Decimal mc_fee { get; set; }
        String exchange_rate { get; set; }
        String settle_currency { get; set; }
        String txn_id { get; set; }
        String payment_type { get; set; }
        String payment_fee { get; set; }
        String receiver_id { get; set; }
        String str_out_Response { get; set; }
        String payment_status { get; set; }
        String pending_reason { get; set; }

    }

    public class Cls_RecurringPayment_prp : int_RecurringPayment
    {
        Int32 idl;
        String txn_typel;
        String subscr_idl;
        String last_namel;
        String residence_countryl;
        String mc_currencyl;
        String item_namel;
        String businessl;
        String recurringl;
        String verify_signl;
        String payer_statusl;
        String test_ipnl;
        String payer_emaill;
        String first_namel;
        String receiver_emaill;
        String payer_idl;
        String reattemptl;
        String item_numberl;
        String subscr_datel;
        String subscr_effectivel;
        String customl;
        String charsetl;
        String notify_versionl;
        String period3l;
        Decimal mc_amount3l;
        String ipn_track_idl;
        Decimal mc_grossl;
        Decimal settle_amountl;
        String protection_eligibilityl;
        String payment_datel;
        Decimal mc_feel;
        String exchange_ratel;
        String settle_currencyl;
        String txn_idl;
        String payment_typel;
        String payment_feel;
        String receiver_idl;
        String str_out_Responsel;
        String payment_statusl;
        String pending_reasonl;



        public int id
        {
            get
            {
                return idl;
            }
            set
            {
                idl = value;
            }
        }

        public string txn_type
        {
            get
            {
                return txn_typel;
            }
            set
            {
                txn_typel = value;
            }
        }

        public string subscr_id
        {
            get
            {
                return subscr_idl;
            }
            set
            {
                subscr_idl = value;
            }
        }

        public string last_name
        {
            get
            {
                return last_namel;
            }
            set
            {
                last_namel = value;
            }
        }

        public string residence_country
        {
            get
            {
                return residence_countryl;
            }
            set
            {
                residence_countryl = value;
            }
        }

        public string mc_currency
        {
            get
            {
                return mc_currencyl;
            }
            set
            {
                mc_currencyl = value;
            }
        }

        public string item_name
        {
            get
            {
                return item_namel;
            }
            set
            {
                item_namel = value;
            }
        }

        public string business
        {
            get
            {
                return businessl;
            }
            set
            {
                businessl = value;
            }
        }

        public string recurring
        {
            get
            {
                return recurringl;
            }
            set
            {
                recurringl = value;
            }
        }

        public string verify_sign
        {
            get
            {
                return verify_signl;
            }
            set
            {
                verify_signl = value;
            }
        }

        public string payer_status
        {
            get
            {
                return payer_statusl;
            }
            set
            {
                payer_statusl = value;
            }
        }

        public string test_ipn
        {
            get
            {
                return test_ipnl;

            }
            set
            {
                test_ipnl = value;
            }
        }

        public string payer_email
        {
            get
            {
                return payer_emaill;
            }
            set
            {
                payer_emaill = value;
            }
        }

        public string first_name
        {
            get
            {
                return first_namel;
            }
            set
            {
                first_namel = value;
            }
        }

        public string receiver_email
        {
            get
            {
                return receiver_emaill;
            }
            set
            {
                receiver_emaill = value;
            }
        }

        public string payer_id
        {
            get
            {
                return payer_idl;
            }
            set
            {
                payer_idl = value;
            }
        }

        public string reattempt
        {
            get
            {
                return reattemptl;
            }
            set
            {
                reattemptl = value;
            }
        }

        public string item_number
        {
            get
            {
                return item_numberl;
            }
            set
            {
                item_numberl = value;
            }
        }

        public string subscr_date
        {
            get
            {
                return subscr_datel;
            }
            set
            {
                subscr_datel = value;
            }
        }

        public string subscr_effective
        {
            get
            {
                return subscr_effectivel;
            }
            set
            {
                subscr_effectivel = value;
            }
        }

        public string custom
        {
            get
            {
                return customl;
            }
            set
            {
                customl = value;
            }
        }

        public string charset
        {
            get
            {
                return charsetl;
            }
            set
            {
                charsetl = value;
            }
        }

        public string notify_version
        {
            get
            {
                return notify_versionl;
            }
            set
            {
                notify_versionl = value;
            }
        }

        public string period3
        {
            get
            {
                return period3l;
            }
            set
            {
                period3l = value;
            }
        }

        public Decimal mc_amount3
        {
            get
            {
                return mc_amount3l;
            }
            set
            {
                mc_amount3l = value;
            }
        }

        public string ipn_track_id
        {
            get
            {
                return ipn_track_idl;
            }
            set
            {
                ipn_track_idl = value;
            }
        }

        public Decimal mc_gross
        {
            get
            {
                return mc_grossl;
            }
            set
            {
                mc_grossl = value;
            }
        }

        public Decimal settle_amount
        {
            get
            {
                return settle_amountl;
            }
            set
            {
                settle_amountl = value;
            }
        }

        public string protection_eligibility
        {
            get
            {
                return protection_eligibilityl;
            }
            set
            {
                protection_eligibilityl = value;
            }
        }

        public string payment_date
        {
            get
            {
                return payment_datel;
            }
            set
            {
                payment_datel = value;
            }
        }

        public Decimal mc_fee
        {
            get
            {
                return mc_feel;
            }
            set
            {
                mc_feel = value;
            }
        }

        public string exchange_rate
        {
            get
            {
                return exchange_ratel;
            }
            set
            {
                exchange_ratel = value;
            }
        }

        public string settle_currency
        {
            get
            {
                return settle_currencyl;
            }
            set
            {
                settle_currencyl = value;
            }
        }

        public string txn_id
        {
            get
            {
                return txn_idl;
            }
            set
            {
                txn_idl = value;
            }
        }

        public string payment_type
        {
            get
            {
                return payment_typel;
            }
            set
            {
                payment_typel = value;
            }
        }

        public string payment_fee
        {
            get
            {
                return payment_feel;
            }
            set
            {
                payment_feel = value;
            }
        }

        public string receiver_id
        {
            get
            {
                return receiver_idl;
            }
            set
            {
                receiver_idl = value;
            }
        }

        public string str_out_Response
        {
            get
            {
                return str_out_Responsel;
            }
            set
            {
                str_out_Responsel = value;
            }
        }

        public string payment_status
        {
            get
            {
                return payment_statusl;
            }
            set
            {
                payment_statusl = value;
            }
        }


        public string pending_reason
        {
            get
            {
                return pending_reasonl;
            }
            set
            {
                pending_reasonl = value;
            }
        }
    }

    public class Cls_RecurringPayment : clscon
    {

        public Int32 save_RecurringPayment_req_response(Cls_RecurringPayment_prp p)
        {

            Int32 Flag = 1;
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = "sp_PaymentRecurringSave";
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = con;
            Cmd.Parameters.Add("@txn_type", SqlDbType.NVarChar, (150)).Value = p.txn_type;
            Cmd.Parameters.Add("@subscr_id", SqlDbType.NVarChar, (150)).Value = p.subscr_id;
            Cmd.Parameters.Add("@last_name", SqlDbType.NVarChar, (150)).Value = p.last_name;
            Cmd.Parameters.Add("@residence_country", SqlDbType.NVarChar, (150)).Value = p.residence_country;
            Cmd.Parameters.Add("@mc_currency", SqlDbType.NVarChar, (150)).Value = p.mc_currency;
            Cmd.Parameters.Add("@item_name", SqlDbType.NVarChar, (150)).Value = p.item_name;
            Cmd.Parameters.Add("@business", SqlDbType.NVarChar, (150)).Value = p.business;
            Cmd.Parameters.Add("@recurring", SqlDbType.NVarChar, (150)).Value = p.recurring;
            Cmd.Parameters.Add("@verify_sign", SqlDbType.NVarChar, (150)).Value = p.verify_sign;
            Cmd.Parameters.Add("@payer_status", SqlDbType.NVarChar, (150)).Value = p.payer_status;
            Cmd.Parameters.Add("@test_ipn", SqlDbType.NVarChar, (150)).Value = p.test_ipn;
            Cmd.Parameters.Add("@payer_email", SqlDbType.NVarChar, (150)).Value = p.payer_email;
            Cmd.Parameters.Add("@first_name", SqlDbType.NVarChar, (150)).Value = p.first_name;
            Cmd.Parameters.Add("@receiver_email", SqlDbType.NVarChar, (150)).Value = p.receiver_email;
            Cmd.Parameters.Add("@payer_id", SqlDbType.NVarChar, (150)).Value = p.payer_id;
            Cmd.Parameters.Add("@reattempt", SqlDbType.NVarChar, (150)).Value = p.reattempt;
            Cmd.Parameters.Add("@item_number", SqlDbType.NVarChar, (150)).Value = p.item_number;
            Cmd.Parameters.Add("@subscr_date", SqlDbType.NVarChar, (150)).Value = p.subscr_date;
            Cmd.Parameters.Add("@subscr_effective", SqlDbType.NVarChar, (150)).Value = p.subscr_effective;
            Cmd.Parameters.Add("@custom", SqlDbType.NVarChar, (150)).Value = p.custom;
            Cmd.Parameters.Add("@charset", SqlDbType.NVarChar, (150)).Value = p.charset;
            Cmd.Parameters.Add("@notify_version", SqlDbType.NVarChar, (150)).Value = p.notify_version;
            Cmd.Parameters.Add("@period3", SqlDbType.NVarChar, (150)).Value = p.period3;
            Cmd.Parameters.Add("@mc_amount3", SqlDbType.Decimal).Value = p.mc_amount3;
            Cmd.Parameters.Add("@ipn_track_id", SqlDbType.NVarChar, (150)).Value = p.ipn_track_id;
            Cmd.Parameters.Add("@mc_gross", SqlDbType.Decimal).Value = p.mc_gross;
            Cmd.Parameters.Add("@settle_amount", SqlDbType.Decimal).Value = p.settle_amount;
            Cmd.Parameters.Add("@protection_eligibility", SqlDbType.NVarChar, (150)).Value = p.protection_eligibility;
        
                Cmd.Parameters.Add("@payment_date", SqlDbType.NVarChar, (150)).Value = DateTime.Now.ToString();
           
                //Cmd.Parameters.Add("@payment_date", SqlDbType.NVarChar, (150)).Value = p.payment_date;
            
            Cmd.Parameters.Add("@mc_fee", SqlDbType.Decimal).Value = p.mc_fee;
            Cmd.Parameters.Add("@exchange_rate", SqlDbType.NVarChar, (150)).Value = p.exchange_rate;
            Cmd.Parameters.Add("@settle_currency", SqlDbType.NVarChar, (150)).Value = p.settle_currency;
            Cmd.Parameters.Add("@txn_id", SqlDbType.NVarChar, (150)).Value = p.txn_id;
            Cmd.Parameters.Add("@payment_type", SqlDbType.NVarChar, (150)).Value = p.payment_type;
            Cmd.Parameters.Add("@payment_fee", SqlDbType.NVarChar, (150)).Value = p.payment_fee;
            Cmd.Parameters.Add("@receiver_id", SqlDbType.NVarChar, (150)).Value = p.receiver_id;
            Cmd.Parameters.Add("@str_out_Response", SqlDbType.NVarChar, (150)).Value = p.str_out_Response;
            Cmd.Parameters.Add("@payment_status", SqlDbType.NVarChar, (150)).Value = p.payment_status;
            Cmd.Parameters.Add("@pending_reason", SqlDbType.NVarChar, (150)).Value = p.pending_reason;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            Cmd.Parameters.Add(sqlparm);
            con.Open();
            Cmd.ExecuteNonQuery();
            con.Close();
            Flag = Convert.ToInt32(sqlparm.Value);




            return Flag;

        }

        public DataSet RecurringPaymentInvoiceByReqID(string p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_RecurringPaymentInvoiceByReqID", con);
            adp.SelectCommand.Parameters.Add("@custom", SqlDbType.Int).Value = Convert.ToInt32(p);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds);
            return ds;

        }


    }
}