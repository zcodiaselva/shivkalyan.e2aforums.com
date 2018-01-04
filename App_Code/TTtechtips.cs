using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace techtips
{
    public abstract class clscon 
    {
        protected SqlConnection con=new SqlConnection();
        public clscon()
        {
        con.ConnectionString=ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }
    
    }
    public interface int_techtips
    { 
    Int32 id	{get;set;}
    Int32  tt_user_id	{get;set;}
    String tt_user_status	{get;set;}
    DateTime ttdatetime {get;set;}

		

    Int32    tt_id	{get;set;}
    Int32 tt_by_user_id {get;set;}
    String tt_heading	{get;set;}
    String tt_file_url	{get;set;}
    String tt_status	{get;set;}
    DateTime tt_datetime {get;set;}
    DateTime tt_rdatetime { get; set; }
		
    }

    public class clsTechTipsPrp : int_techtips
    {

        Int32 Vid ;
        Int32 Vtt_user_id ;
        String Vtt_user_status ;
        DateTime Vttdatetime ;



        Int32 Vtt_id ;
        Int32 Vtt_by_user_id ;
        String Vtt_heading ;
        String Vtt_file_url ;
        String Vtt_status ;
        DateTime Vtt_datetime ;
        DateTime Vtt_rdatetime;
        public int id
        {
            get
            {
                 return Vid;
            }
            set
            {
                Vid=value;
            }
        }

        public int tt_user_id
        {
            get
            {
                return Vtt_user_id;
            }
            set
            {
                Vtt_user_id=value;
            }
        }

        public string tt_user_status
        {
            get
            {
                return Vtt_user_status;
            }
            set
            {
                Vtt_user_status=value;
            }
        }

        public DateTime ttdatetime
        {
            get
            {
                return Vttdatetime;
            }
            set
            {
                Vttdatetime=value;
            }
        }

        public int tt_id
        {
            get
            {
                return Vtt_id ;
            }
            set
            {
               Vtt_id =value;
            }
        }

        public int tt_by_user_id
        {
            get
            {
                return Vtt_by_user_id;
            }
            set
            {
              Vtt_by_user_id  =value;
            }
        }

        public string tt_heading
        {
            get
            {
                return Vtt_heading;
            }
            set
            {
               Vtt_heading  =value;
            }
        }

        public string tt_file_url
        {
            get
            {
                return Vtt_file_url ;
            }
            set
            {
                Vtt_file_url =value;
            }
        }

        public string tt_status
        {
            get
            {
                return Vtt_status;
            }
            set
            {
               Vtt_status    =value;
            }
        }

        public DateTime tt_datetime
        {
            get
            {
                return Vtt_datetime;
            }
            set
            {
                Vtt_datetime = value;
            }
        }

        public DateTime tt_rdatetime
        {
            get
            {
                return Vtt_rdatetime;
            }
            set
            {
                Vtt_rdatetime = value;
            }
        }
    }

    public class clsTechTips : clscon
    {

        public Int32 TechTipsMemberAssign(clsTechTipsPrp p)
        {
            Int32 Flag;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_TechTipsMemberAssign";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt_user_id", SqlDbType.Int).Value = p.tt_user_id;
            SqlParameter sqlparm = new SqlParameter("@Flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return Flag;
        
        }

      
        public Int32 TechTipsMemberAssignCheck(clsTechTipsPrp p)
        {
            Int32 Flag;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_TechTipsMemberAssignCheck";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt_user_id", SqlDbType.Int).Value = p.tt_user_id;
            SqlParameter sqlparm = new SqlParameter("@Flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return Flag;

        }


        public Int32 TechTipsSend(clsTechTipsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_TechTipsSend";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt_by_user_id", SqlDbType.Int).Value = p.tt_by_user_id;
            cmd.Parameters.Add("@tt_heading", SqlDbType.VarChar, (50)).Value = p.tt_heading;
            cmd.Parameters.Add("@tt_file_url", SqlDbType.VarChar).Value = p.tt_file_url;
            SqlParameter sqlparm = new SqlParameter("@Flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return Flag;

        }
        public Int32 TechTipsUpd(clsTechTipsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_TechTipsUpd";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt_id", SqlDbType.Int).Value = p.tt_id;
            cmd.Parameters.Add("@tt_by_user_id", SqlDbType.Int).Value = p.tt_by_user_id;
            cmd.Parameters.Add("@tt_heading", SqlDbType.VarChar, (50)).Value = p.tt_heading;
            cmd.Parameters.Add("@tt_file_url", SqlDbType.VarChar).Value = p.tt_file_url;
            SqlParameter sqlparm = new SqlParameter("@Flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return Flag;

        }

        public Int32 TechTipsApprove_Action(clsTechTipsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_TechTipsApprove_Action";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt_id", SqlDbType.Int).Value = p.tt_id;
            cmd.Parameters.Add("@tt_status", SqlDbType.VarChar, (50)).Value = p.tt_status;
            SqlParameter sqlparm = new SqlParameter("@Flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return Flag;

        }

        public Int32 TechTipsDelete(clsTechTipsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_TechTipsDelete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt_id", SqlDbType.Int).Value = p.tt_id;
            SqlParameter sqlparm = new SqlParameter("@Flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return Flag;

        }
        

        public DataSet TechTipsMemberAssign_search( string full_name)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_TechTipsMemberAssign_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.Fill(ds);
            return ds;
        }


        public DataSet TechTipsApprove_search(string full_name)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_TechTipsApprove_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.Fill(ds);
            return ds;
        }  

        public DataSet getMyTechTips( clsTechTipsPrp p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_TechTipsGetMy", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@tt_by_user_id", SqlDbType.Int).Value = p.tt_by_user_id;
            adp.Fill(ds);
            return ds;
        }
    
    }

}