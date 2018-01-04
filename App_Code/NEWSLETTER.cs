using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace NewsLetter
{
    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();

        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }
    }
    #region Interface
    public interface  cls_int
    {
        Int32 ID { get; set; }
        String EMAil { get; set; }
        DateTime RecDateTime { get; set; }
        String UserStatus { get; set; }

    }
    #endregion interface
    #region Property Class
    public class cls_newslatter_prp : cls_int
    {
        Int32 dID;
        String dEMAil;
        DateTime dRecDateTime;
        String dUserStatus;
        public int ID
        {
            get
            {
                return dID;
            }
            set
            {
                dID = value;
            }
        }

        public string EMAil
        {
            get
            {
                return dEMAil;
            }
            set
            {
                dEMAil = value;
            }
        }

        public DateTime RecDateTime
        {
            get
            {
                return dRecDateTime;
            }
            set
            {
                dRecDateTime = value;
            }
        }

        public string UserStatus
        {
            get
            {
                return dUserStatus;
            }
            set
            {
                dUserStatus = value;
            }
        }
    }
    #endregion Property Class

    #region  Class
    public class cls_NEWSLATTER_CLs : clscon
    {
        public Int32  save_newLatter(cls_newslatter_prp p )
        {
            Int32 Flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_NewsLatterSave";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EMail", SqlDbType.VarChar).Value = p.EMAil;
            SqlParameter sqlp = new SqlParameter("@flag", SqlDbType.Int);
            sqlp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlp);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Flag = Convert.ToInt32(sqlp.Value);
            cmd.Dispose();
            return Flag;
            
        }
    }
#endregion  Class
}

