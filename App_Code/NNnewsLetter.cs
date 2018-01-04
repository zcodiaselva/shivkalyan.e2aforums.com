using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace newsletter
{
    public abstract class clscon 
    {
        protected SqlConnection con=new SqlConnection();
        public clscon()
        {
        con.ConnectionString=ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }
    
    }
    public interface int_newsletter
    { 
    Int32 id	{get;set;}
    Int32  nn_user_id	{get;set;}
    String nn_user_status	{get;set;}
    DateTime nndatetime {get;set;}

		

    Int32    nn_id	{get;set;}
    Int32 nn_by_user_id {get;set;}
    String nn_heading	{get;set;}
    String nn_file_url	{get;set;}
    String nn_status	{get;set;}
    DateTime nn_datetime {get;set;}
    DateTime nn_rdatetime { get; set; }
		
    }

    public class clsNewsLetterPrp : int_newsletter
    {

        Int32 Vid ;
        Int32 Vnn_user_id ;
        String Vnn_user_status ;
        DateTime Vnndatetime ;



        Int32 Vnn_id ;
        Int32 Vnn_by_user_id ;
        String Vnn_heading ;
        String Vnn_file_url ;
        String Vnn_status ;
        DateTime Vnn_datetime ;
        DateTime Vnn_rdatetime;
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

        public int nn_user_id
        {
            get
            {
                return Vnn_user_id;
            }
            set
            {
                Vnn_user_id=value;
            }
        }

        public string nn_user_status
        {
            get
            {
                return Vnn_user_status;
            }
            set
            {
                Vnn_user_status=value;
            }
        }

        public DateTime nndatetime
        {
            get
            {
                return Vnndatetime;
            }
            set
            {
                Vnndatetime=value;
            }
        }

        public int nn_id
        {
            get
            {
                return Vnn_id ;
            }
            set
            {
               Vnn_id =value;
            }
        }

        public int nn_by_user_id
        {
            get
            {
                return Vnn_by_user_id;
            }
            set
            {
              Vnn_by_user_id  =value;
            }
        }

        public string nn_heading
        {
            get
            {
                return Vnn_heading;
            }
            set
            {
               Vnn_heading  =value;
            }
        }

        public string nn_file_url
        {
            get
            {
                return Vnn_file_url ;
            }
            set
            {
                Vnn_file_url =value;
            }
        }

        public string nn_status
        {
            get
            {
                return Vnn_status;
            }
            set
            {
               Vnn_status    =value;
            }
        }

        public DateTime nn_datetime
        {
            get
            {
                return Vnn_datetime;
            }
            set
            {
                Vnn_datetime = value;
            }
        }

        public DateTime nn_rdatetime
        {
            get
            {
                return Vnn_rdatetime;
            }
            set
            {
                Vnn_rdatetime = value;
            }
        }
    }

    public class clsNewsLetter  : clscon
    {

        public Int32 NewsLetterMemberAssign(clsNewsLetterPrp p)
        {
            Int32 Flag;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLetterMemberAssign";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nn_user_id", SqlDbType.Int).Value = p.nn_user_id;
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

      
        public Int32 NewsLetterMemberAssignCheck(clsNewsLetterPrp p)
        {
            Int32 Flag;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLetterMemberAssignCheck";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nn_user_id", SqlDbType.Int).Value = p.nn_user_id;
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


        public Int32 NewsLetterSend(clsNewsLetterPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLetterSend";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nn_by_user_id", SqlDbType.Int).Value = p.nn_by_user_id;
            cmd.Parameters.Add("@nn_heading", SqlDbType.VarChar, (50)).Value = p.nn_heading;
            cmd.Parameters.Add("@nn_file_url", SqlDbType.VarChar).Value = p.nn_file_url;
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
        public Int32 NewsLetterUpd(clsNewsLetterPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLetterUpd";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nn_id", SqlDbType.Int).Value = p.nn_id;
            cmd.Parameters.Add("@nn_by_user_id", SqlDbType.Int).Value = p.nn_by_user_id;
            cmd.Parameters.Add("@nn_heading", SqlDbType.VarChar, (50)).Value = p.nn_heading;
            cmd.Parameters.Add("@nn_file_url", SqlDbType.VarChar).Value = p.nn_file_url;
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

        public Int32 NewsLetterApprove_Action(clsNewsLetterPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLetterApprove_Action";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nn_id", SqlDbType.Int).Value = p.nn_id;
            cmd.Parameters.Add("@nn_status", SqlDbType.VarChar, (50)).Value = p.nn_status;
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

        public Int32 NewsLetterDelete(clsNewsLetterPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLetterDelete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nn_id", SqlDbType.Int).Value = p.nn_id;
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
        

        public DataSet NewsLetterMemberAssign_search( string full_name)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_NewsLetterMemberAssign_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.Fill(ds);
            return ds;
        }


        public DataSet NewsLetterApprove_search(string full_name)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_NewsLetterApprove_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.Fill(ds);
            return ds;
        }

        public DataSet getMyNewsLetter(clsNewsLetterPrp p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_NewsLetterGetMy", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nn_by_user_id", SqlDbType.Int).Value = p.nn_by_user_id;
            adp.Fill(ds);
            return ds;
        }
    
    }

}