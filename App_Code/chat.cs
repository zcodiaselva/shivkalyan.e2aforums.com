using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace chat
{
    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

    }

    public interface int_chat
    {
        /// <summary>
        /// table tbl_chat_message  iterface
        /// </summary>
       Int32 message_id	{get;set;}
       String chat_message { get; set; } 
        DateTime date_time	{get;set;}
        Int32 sender_id	{get;set;}
        String destination_type	{get;set;}
        Int32 destination_id	{get;set;}
        String message_status	{get;set;}


        //table  tbl_chat_group_members interface 
        Int32 id	{get;set;}
        Int32 grp_id	{get;set;}
        Int32 grp_user_id	{get;set;}
        String user_status	{get;set;}

		
        // table  tbl_chat_group interface

        String grp_name	{get;set;}
        Int32 grp_by_user_id	{get;set;}
        String grp_img_url	{get;set;}
        String prp_status  {get;set;}
		
        // table tbl_chat_block interface

      
        Int32 for_user_id {get;set;}
        Int32 block_emp_id	{get;set;}
        String emp_status	{get;set;}
		


    }
    public class cls_chat_prp : int_chat
    {
        /// <summary>
        /// table tbl_chat_message  iterface
        /// </summary>
        Int32  MImessage_id;
        String CMchat_message;
        DateTime DTdate_time;
        Int32 FEIsender_id;
        String DTdestination_type;
        Int32 DIdestination_id;
        String MSmessage_status;


        //table  tbl_chat_group_members interface 
        Int32 GIid;
        Int32 GIgrp_id;
        Int32 GEIgrp_user_id;
        String USuser_status;


        // table  tbl_chat_group interface

      
        String GNgrp_name;
        Int32 GBNgrp_by_user_id;
        String GIUgrp_img_url;
        String PSprp_status;

        // table tbl_chat_block interface

        Int32 IIIid { get; set; }
        Int32 FEIfor_user_id { get; set; }
        Int32 BEIblock_emp_id { get; set; }
        String ESemp_status { get; set; }
     
        /// <summary>
        /// table tbl_chat_message
        /// </summary>

        public int message_id
        {
            get
            {
                return MImessage_id;
            }
            set
            {
                MImessage_id = value;
            }
        }

        public string chat_message
        {
            get
            {
                return CMchat_message;
            }
            set
            {
                CMchat_message = value;
            }
        }
        public DateTime date_time
        {
            get
            {
                return DTdate_time;
            }
            set
            {
                DTdate_time = value;
            }
        }

        public int sender_id
        {
            get
            {
                return FEIsender_id;
            }
            set
            {
                FEIsender_id = value;
            }
        }

        public string destination_type
        {
            get
            {
                return DTdestination_type;
            }
            set
            {
                DTdestination_type = value;
            }
        }

        public int destination_id
        {
            get
            {
                return DIdestination_id;
            }
            set
            {
                DIdestination_id = value;
            }
        }

        public string message_status
        {
            get
            {
                return MSmessage_status;
            }
            set
            {
                MSmessage_status = value;
            }
        }


        /// <summary>
        /// table  tbl_chat_group_members
        /// </summary>

        public int id
        {
            get
            {
                return IIIid;
            }
            set
            {
                IIIid = value;
            }
        }

        public int grp_id
        {
            get
            {
                return GIgrp_id;
            }
            set
            {
                GIgrp_id = value;
            }
        }

        public int grp_user_id
        {
            get
            {
                return GEIgrp_user_id;
            }
            set
            {
                GEIgrp_user_id = value;
            }
        }

        public string user_status
        {
            get
            {
                return USuser_status;
            }
            set
            {
                USuser_status = value;
            }
        }

        /// <summary>
        ///  table tbl_chat_block
        /// </summary>

        public string grp_name
        {
            get
            {
                return GNgrp_name;
            }
            set
            {
                GNgrp_name = value;
            }
        }

        public int grp_by_user_id
        {
            get
            {
                return GBNgrp_by_user_id;
            }
            set
            {
                GBNgrp_by_user_id = value;
            }
        }

        public string grp_img_url
        {
            get
            {
                return GIUgrp_img_url;
            }
            set
            {
                GIUgrp_img_url = value;
            }
        }

        public string prp_status
        {
            get
            {
                return PSprp_status;
            }
            set
            {
                PSprp_status = value;
            }
        }

        /// <summary>
        /// table tbl_chat_block
        /// </summary>
        
        public int for_user_id
        {
            get
            {
                return FEIfor_user_id;
            }
            set
            {
                FEIfor_user_id = value;
            }
        }

        public int block_emp_id
        {
            get
            {
                return BEIblock_emp_id;
            }
            set
            {
                BEIblock_emp_id = value;
            }
        }

        public string emp_status
        {
            get
            {
                return ESemp_status;
            }
            set
            {
                ESemp_status = value;
            }
        }
    }


    public class cls_chat : clscon
    {

        public void send_message(cls_chat_prp p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_chat_send_message";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@chat_message", SqlDbType.NVarChar).Value = p.chat_message;
            cmd.Parameters.Add("@sender_id", SqlDbType.Int).Value = p.sender_id;
            cmd.Parameters.Add("@destination_type", SqlDbType.VarChar, (50)).Value = p.destination_type;
            cmd.Parameters.Add("@destination_id", SqlDbType.Int).Value = p.destination_id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
        public DataSet get_message(cls_chat_prp p)
        {
            DataSet ds=new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_get_messgaes", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@sender_id", SqlDbType.Int).Value = p.sender_id;
            adp.SelectCommand.Parameters.Add("@destination_type", SqlDbType.VarChar, (50)).Value = p.destination_type;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value = p.destination_id;
            adp.Fill(ds);
            return ds;
        }
        public DataSet chat_get_users(cls_chat_prp p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_get_users", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value = p.destination_id;
            adp.Fill(ds);
            return ds;
        }


        public Int32 chat_create_group(cls_chat_prp p)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "chat_create_group";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@grp_name", SqlDbType.VarChar,(50)).Value = p.grp_name;
            cmd.Parameters.Add("@grp_by_user_id", SqlDbType.Int).Value = p.grp_by_user_id;
            cmd.Parameters.Add("@grp_img_url", SqlDbType.NVarChar).Value = p.grp_img_url;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            int flag;
            flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return flag;
        }

        public Int32 chat_update_group(cls_chat_prp p)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_chat_update_group";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@grp_id", SqlDbType.Int).Value = p.grp_id;
            cmd.Parameters.Add("@grp_name", SqlDbType.VarChar, (50)).Value = p.grp_name;
            cmd.Parameters.Add("@grp_by_user_id", SqlDbType.Int).Value = p.grp_by_user_id;
            cmd.Parameters.Add("@grp_img_url", SqlDbType.NVarChar).Value = p.grp_img_url;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            int flag;
            flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return flag;
        }
        public DataSet chat_group_member_get_alll(cls_chat_prp p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_group_member_get_all", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@grp_id", SqlDbType.Int).Value = p.grp_id;
            adp.Fill(ds);
            return ds;
        }

        public DataSet chat_group_member_search(string grp_id, string full_name, double lStrlUserID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_group_member_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@grp_id", SqlDbType.Int).Value =Convert.ToInt32(grp_id);
            adp.SelectCommand.Parameters.Add("@Full_Name",SqlDbType.VarChar,(50)).Value=full_name;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value = Convert.ToInt32(lStrlUserID);
            adp.Fill(ds);
            return ds;
        }

        public DataSet chat_group_info_get(cls_chat_prp p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("chat_group_info_get", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@grp_id", SqlDbType.Int).Value = p.grp_id;
            adp.Fill(ds);
            return ds;
        }
        public Int32 chat_group_member_status_update(cls_chat_prp p)
        {
            Int32 flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "chat_group_member_status_update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = p.id;

            cmd.Parameters.Add("@user_status", SqlDbType.VarChar, (50)).Value = p.user_status;

            SqlParameter sqlpram = new SqlParameter("@flag", SqlDbType.Int);
            sqlpram.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlpram);
            con.Open();
            cmd.ExecuteNonQuery();

            flag = Convert.ToInt32(sqlpram.Value);
            con.Close();
            cmd.Dispose();
            return flag;

        }

        public Int32 chat_group_member_add(cls_chat_prp p)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_chat_group_member_add";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@grp_id", SqlDbType.Int).Value = p.grp_id;
            cmd.Parameters.Add("@grp_user_id", SqlDbType.Int).Value = p.grp_user_id;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            int flag;
            flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return flag;
        }
        public void chat_delete_message(cls_chat_prp p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "chat_delete_message";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@message_id", SqlDbType.Int).Value = p.message_id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

        }
        public Int32 chat_all_unread_msg(cls_chat_prp p)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_chat_all_unread_msg";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@destination_id", SqlDbType.Int).Value = p.destination_id;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            int flag;
            flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
            return flag;
        }

        public DataSet chat_get_users_search(string fullName, double lStrlUserID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_get_users_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar,(50)).Value = fullName;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value = Convert.ToInt32(lStrlUserID);
            adp.Fill(ds);
            return ds;
        }
    }
}