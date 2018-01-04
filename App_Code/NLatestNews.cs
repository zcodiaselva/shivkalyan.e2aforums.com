using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace latestnews
{
    public abstract class clscon 
    {
        protected SqlConnection con=new SqlConnection();
        public clscon()
        {
        con.ConnectionString=ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }
    
    }
    public interface int_latestnews
    { 
    Int32 id	{get;set;}
    Int32  ln_user_id	{get;set;}
    String ln_user_status	{get;set;}
    DateTime lndatetime {get;set;}

		

    Int32    ln_id	{get;set;}
    Int32 ln_by_user_id {get;set;}
    String ln_heading	{get;set;}
    String ln_file_url	{get;set;}
    String ln_status	{get;set;}
    DateTime ln_datetime {get;set;}
    DateTime ln_rdatetime { get; set; }
		
    }

    public class clslatestnewsPrp : int_latestnews
    {

        Int32 Vid ;
        Int32 Vln_user_id ;
        String Vln_user_status ;
        DateTime Vlndatetime ;



        Int32 Vln_id ;
        Int32 Vln_by_user_id ;
        String Vln_heading ;
        String Vln_file_url ;
        String Vln_status ;
        DateTime Vln_datetime ;
        DateTime Vln_rdatetime;
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

        public int ln_user_id
        {
            get
            {
                return Vln_user_id;
            }
            set
            {
                Vln_user_id=value;
            }
        }

        public string ln_user_status
        {
            get
            {
                return Vln_user_status;
            }
            set
            {
                Vln_user_status=value;
            }
        }

        public DateTime lndatetime
        {
            get
            {
                return Vlndatetime;
            }
            set
            {
                Vlndatetime=value;
            }
        }

        public int ln_id
        {
            get
            {
                return Vln_id ;
            }
            set
            {
               Vln_id =value;
            }
        }

        public int ln_by_user_id
        {
            get
            {
                return Vln_by_user_id;
            }
            set
            {
              Vln_by_user_id  =value;
            }
        }

        public string ln_heading
        {
            get
            {
                return Vln_heading;
            }
            set
            {
               Vln_heading  =value;
            }
        }

        public string ln_file_url
        {
            get
            {
                return Vln_file_url ;
            }
            set
            {
                Vln_file_url =value;
            }
        }

        public string ln_status
        {
            get
            {
                return Vln_status;
            }
            set
            {
               Vln_status    =value;
            }
        }

        public DateTime ln_datetime
        {
            get
            {
                return Vln_datetime;
            }
            set
            {
                Vln_datetime = value;
            }
        }

        public DateTime ln_rdatetime
        {
            get
            {
                return Vln_rdatetime;
            }
            set
            {
                Vln_rdatetime = value;
            }
        }
    }

    public class clslatestnews  : clscon
    {

        public Int32 latestnewsMemberAssign(clslatestnewsPrp p)
        {
            Int32 Flag;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_latestNewsMemberAssign";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ln_user_id", SqlDbType.Int).Value = p.ln_user_id;
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

      
        public Int32 latestNewsMemberAssignCheck(clslatestnewsPrp p)
        {
            Int32 Flag;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_latestNewsMemberAssignCheck";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ln_user_id", SqlDbType.Int).Value = p.ln_user_id;
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


        public Int32 latestNewsSend(clslatestnewsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_latestNewsSend";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ln_by_user_id", SqlDbType.Int).Value = p.ln_by_user_id;
            cmd.Parameters.Add("@ln_heading", SqlDbType.VarChar, (50)).Value = p.ln_heading;
            cmd.Parameters.Add("@ln_file_url", SqlDbType.VarChar).Value = p.ln_file_url;
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
        public Int32 latestNewsUpd(clslatestnewsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_latestNewsUpd";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ln_id", SqlDbType.Int).Value = p.ln_id;
            cmd.Parameters.Add("@ln_by_user_id", SqlDbType.Int).Value = p.ln_by_user_id;
            cmd.Parameters.Add("@ln_heading", SqlDbType.VarChar, (50)).Value = p.ln_heading;
            cmd.Parameters.Add("@ln_file_url", SqlDbType.VarChar).Value = p.ln_file_url;
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

        public Int32 latestNewsApprove_Action(clslatestnewsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_latestNewsApprove_Action";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ln_id", SqlDbType.Int).Value = p.ln_id;
            cmd.Parameters.Add("@ln_status", SqlDbType.VarChar, (50)).Value = p.ln_status;
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

        public Int32 latestNewsDelete(clslatestnewsPrp p)
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_latestNewsDelete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ln_id", SqlDbType.Int).Value = p.ln_id;
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
        

        public DataSet latestNewsMemberAssign_search( string full_name)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_latestNewsMemberAssign_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.Fill(ds);
            return ds;
        }


        public DataSet latestNewsApprove_search(string full_name)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_latestNewsApprove_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.Fill(ds);
            return ds;
        }

        public DataSet getMylatestNews(clslatestnewsPrp p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_latestNewsGetMy", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@ln_by_user_id", SqlDbType.Int).Value = p.ln_by_user_id;
            adp.Fill(ds);
            return ds;
        }
    
    }

}