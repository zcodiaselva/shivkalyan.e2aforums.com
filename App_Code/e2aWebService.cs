using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Script.Services;
using E2aForums;
using System.Web.Configuration;
using System.IO;
using System.Drawing;
/// <summary>
/// Summary description for e2aWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class e2aWebService : System.Web.Services.WebService
{
    SqlConnection con = new SqlConnection();

    public e2aWebService()
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    /// <summary>
    /// This Api Only for mapforword Website for Web Cam
    /// </summary>
    /// <param name="EmailID"></param>
    /// <param name="Password"></param>
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void MapForwordPassUpdate(string EmailID, string Password)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            if (EmailID == "" || EmailID == string.Empty)
            {
                EmailID = null;
            }
            if (Password == "" || Password == string.Empty)
            {
                Password = null;
            }

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_MapFoewordPassUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = EmailID;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;

            con.Open();
            cmd.ExecuteNonQuery();
            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Password Upded!");
            OuterRows.Add("Data", row);

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void RegisterUser(string EmailID, string Password, string FirstName, string LastName, string RegistrationTypeID, string IsNewsLetterSubscribed)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_RegisterUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = EmailID;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            cmd.Parameters.Add("@RegistrationTypeID", SqlDbType.Int).Value = Convert.ToInt32(RegistrationTypeID);
            cmd.Parameters.Add("@IsNewsLetterSubscribed", SqlDbType.Int).Value = Convert.ToInt32(IsNewsLetterSubscribed);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count != 0)
            {


                OuterRows.Add("Status", 200);

                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "PlanTillDate" || col.ColumnName == "DateAndTime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        OuterRows.Add("Data", row);
                    }
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Email already exist!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void LoginUser(string EmailID, string Password)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            if (EmailID == "" || EmailID == string.Empty)
            {
                EmailID = null;
            }
            if (Password == "" || Password == string.Empty)
            {
                Password = null;
            }

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ValidateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = EmailID;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "PlanTillDate" || col.ColumnName == "DateAndTime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        OuterRows.Add("Data", row);
                    }
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Incorrect Email / Password!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ForgetPassword(string EmailID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[20];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var lstrRandomCode = new String(stringChars);

            CUser lobjUsers = new CUser(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);

            DataSet ds = lobjUsers.ForgotPassword(EmailID, lstrRandomCode);

            if (ds != null)
            {
                string lstrName = "";
                // string lstrPass = "";
                Int32 lintRequestUserId = -1;

                if (ds.Tables[0].Rows[0]["RequestUserID"] != null)
                {
                    lintRequestUserId = Convert.ToInt32(ds.Tables[0].Rows[0]["RequestUserID"]);
                }
                if (lintRequestUserId != -1)
                {
                    if (ds.Tables[0].Rows[0]["Full_Name"] != null)
                    {
                        lstrName = Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]);

                        if (string.IsNullOrEmpty(lstrName))
                            lstrName = "User";
                    }
                    else
                        lstrName = "User";


                    CMail lobjMail = new CMail();
                    Encryption.CryptorEngine lobjEnc = new Encryption.CryptorEngine();
                    string lstrResetURL = WebConfigurationManager.AppSettings["DomainName"].ToString() + "ResetPassword.aspx?tok=" + lstrRandomCode.ToString() + "&ID=" + lintRequestUserId;
                    string lstrMessage = System.IO.File.ReadAllText(Server.MapPath("~/ForgotPassMailContent.txt"), Encoding.UTF8);
                    lstrMessage = lstrMessage.Replace("<Name>", lstrName);
                    lstrMessage = lstrMessage.Replace("<Email>", EmailID);
                    //lstrMessage = lstrMessage.Replace("<Password>", lstrPass);
                    lstrMessage = lstrMessage.Replace("<ResetLink>", lstrResetURL);
                    lobjMail.EmailTo = EmailID;
                    lobjMail.Subject = "e2aForums: Reset Password";
                    lobjMail.MessageBody = lstrMessage;
                    lobjMail.SendEMail();

                    OuterRows.Add("Status", 200);
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    row.Add("Message", "A mail has been sent to your email address containing your credentials!");
                    OuterRows.Add("Data", row);


                }
                else if (lintRequestUserId == -1)
                {
                    OuterRows.Add("Status", 404);
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    row.Add("Message", "Sorry, we are not able find to your details. Please register to continue!");
                    OuterRows.Add("Data", row);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Sorry, we are not able find to your details. Please register to continue!");
                OuterRows.Add("Data", row);

            }
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void IdexInfo(string UserID)
    {


        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {


            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("sp_GetIndexCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (ds.Tables.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    Dictionary<string, object> row;
                    row = new Dictionary<string, object>();
                    foreach (DataTable dt in ds.Tables)
                    {


                        foreach (DataRow dr in dt.Rows)
                        {

                            foreach (DataColumn col in dt.Columns)
                            {

                                row.Add(col.ColumnName, dr[col]);

                            }

                        }

                    }
                    OuterRows.Add("Data", row);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void FillSateCombo()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_FillStateCombo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateAndTime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }


    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void FillCitiesOfselectedState(string StateID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_FillCitiesOfselectedState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = Convert.ToInt32(StateID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateAndTime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void LoggedinUserDetails(string UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetLoggedinUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "PlanTillDate" || col.ColumnName == "DateAndTime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        OuterRows.Add("Data", row);
                    }
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void GetOccupations()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetOccupations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateAndTime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }

                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void UpdateUserDetails(string Full_Name, string OccupationID, string OtherOccupation, string Organization, string Address_line1, string Address_Line2, string Address_Line3, string DealerName, string Mga, string GoverningBody, string InBusinessSince, string Mobile_Phone, string Picture, int CommunicateConsent, string UserID, string StateID, string CityID, string ProfileYoutubeURL, string AboutMe, string designation)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_UpdateUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar, 50).Value = Full_Name;
            cmd.Parameters.Add("@OccupationID", SqlDbType.Int).Value = Convert.ToInt32(OccupationID);
            cmd.Parameters.Add("@OtherOccupation", SqlDbType.VarChar, 50).Value = OtherOccupation;
            cmd.Parameters.Add("@Organization", SqlDbType.VarChar, 50).Value = Organization;
            cmd.Parameters.Add("@Address_line1", SqlDbType.VarChar, 50).Value = Address_line1;
            cmd.Parameters.Add("@Address_Line2", SqlDbType.VarChar, 50).Value = Address_Line2;
            cmd.Parameters.Add("@Address_Line3", SqlDbType.VarChar, 50).Value = Address_Line3;
            cmd.Parameters.Add("@DealerName", SqlDbType.VarChar, 50).Value = DealerName;
            cmd.Parameters.Add("@Mga", SqlDbType.VarChar, 50).Value = Mga;
            cmd.Parameters.Add("@GoverningBody", SqlDbType.VarChar, 50).Value = GoverningBody;
            cmd.Parameters.Add("@InBusinessSince", SqlDbType.VarChar, 50).Value = InBusinessSince;
            cmd.Parameters.Add("@Mobile_Phone", SqlDbType.VarChar, 50).Value = Mobile_Phone;
            cmd.Parameters.Add("@Picture", SqlDbType.VarChar, 50).Value = Picture;
            cmd.Parameters.Add("@CommunicateConsent", SqlDbType.Int).Value = CommunicateConsent;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = Convert.ToInt32(StateID);
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = Convert.ToInt32(CityID);
            cmd.Parameters.Add("@ProfileYoutubeURL", SqlDbType.VarChar).Value = ProfileYoutubeURL;
            cmd.Parameters.Add("@AboutMe", SqlDbType.VarChar).Value = AboutMe;
            cmd.Parameters.Add("@designation", SqlDbType.VarChar).Value = designation;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "User profile information has been updated successful!");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void UploadImage(string base64String, string UserID)
    {

        string imgfileName = "";
        imgfileName = DateTime.Now.ToString("yyMMddHHmm");
        string Picture = "~/ProfilePics/" + imgfileName + ".jpg";
        string Picture2 = "../ProfilePics/" + imgfileName + ".jpg";
        string filePath = HttpContext.Current.Server.MapPath(Picture);
        File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_UpdateUserProPic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Picture", SqlDbType.VarChar, 50).Value = Picture;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", Picture2);
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ep)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void TechTipsForUser()
    {

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {



            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_TechTipsApprove_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = "";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "tt_rdatetime" || col.ColumnName == "tt_datetime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void NewsLetterForUser()
    {

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {



            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_NewsLetterApprove_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = "";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "nn_rdatetime" || col.ColumnName == "nn_datetime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void LatestNewsForUser()
    {

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {



            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_LatestNewsApprove_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = "";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "ln_rdatetime" || col.ColumnName == "ln_datetime")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void SaveCustomerDetails(String Title, String FirstName, String LastName, String Email, String Address1, String Address2, String Phone, String Image, String StatusID, String StateID, String CityID, String UserID, String DateOfBirth, String Anniversary, String CustomerID, String DOBDatePart
        , String AnniDatePart, String OfficeEmailID, String OfficeAddress1, String OfficeAddress2, String Mobile, String HomeFax, String OfficeFax, String ExtensionField
        , String PostalCode, String OfcCityID, String OfcStateID, String Telephone, String Work, String Maritalstatus, String Dependents, String BestCallTime
        , String ReferredBy, String ColdLead, String FirstContact, String NextContact, String Discussed)
    {
        string Picture2 = "";
        if (Image != "")
        {

            string imgfileName = "";
            imgfileName = DateTime.Now.ToString("yyMMddHHmm");
            string Picture = "~/ProfilePics/" + imgfileName + ".jpg";
            Picture2 = "../ProfilePics/" + imgfileName + ".jpg";
            string filePath = HttpContext.Current.Server.MapPath(Picture);
            File.WriteAllBytes(filePath, Convert.FromBase64String(Image));
        }
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_SaveCustomerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 200).Value = Title;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 200).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 200).Value = LastName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200).Value = Email;
            cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 250).Value = Address1;
            cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 250).Value = Address2;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = Phone;
            cmd.Parameters.Add("@Image", SqlDbType.VarChar).Value = Picture2;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = Convert.ToInt32(StatusID);
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = Convert.ToInt32(StateID);
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = Convert.ToInt32(CityID);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = Convert.ToDateTime(DateOfBirth);
            cmd.Parameters.Add("@Anniversary", SqlDbType.VarChar, 200).Value = Anniversary;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Convert.ToInt32(CustomerID);
            cmd.Parameters.Add("@DOBDatePart", SqlDbType.DateTime).Value = Convert.ToDateTime(DOBDatePart);
            cmd.Parameters.Add("@AnniDatePart", SqlDbType.VarChar, 200).Value = AnniDatePart;
            cmd.Parameters.Add("@OfficeEmailID", SqlDbType.VarChar, 200).Value = OfficeEmailID;
            cmd.Parameters.Add("@OfficeAddress1", SqlDbType.VarChar, 250).Value = OfficeAddress1;
            cmd.Parameters.Add("@OfficeAddress2", SqlDbType.VarChar, 250).Value = OfficeAddress2;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 200).Value = Mobile;
            cmd.Parameters.Add("@HomeFax", SqlDbType.VarChar, 200).Value = HomeFax;
            cmd.Parameters.Add("@OfficeFax", SqlDbType.VarChar, 200).Value = OfficeFax;
            cmd.Parameters.Add("@ExtensionField", SqlDbType.VarChar, 200).Value = ExtensionField;
            cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 200).Value = PostalCode;
            cmd.Parameters.Add("@OfcCityID", SqlDbType.Int).Value = Convert.ToInt32(OfcCityID);
            cmd.Parameters.Add("@OfcStateID", SqlDbType.Int).Value = Convert.ToInt32(OfcStateID);
            cmd.Parameters.Add("@Telephone", SqlDbType.VarChar, 200).Value = Telephone;
            cmd.Parameters.Add("@Work", SqlDbType.VarChar, 200).Value = Work;
            cmd.Parameters.Add("@Maritalstatus", SqlDbType.Int).Value = Convert.ToInt32(Maritalstatus);
            cmd.Parameters.Add("@Dependents", SqlDbType.Int).Value = Convert.ToInt32(Dependents);
            cmd.Parameters.Add("@BestCallTime", SqlDbType.Int).Value = Convert.ToInt32(BestCallTime);
            cmd.Parameters.Add("@ReferredBy", SqlDbType.VarChar, 200).Value = ReferredBy;
            cmd.Parameters.Add("@ColdLead", SqlDbType.Int).Value = Convert.ToInt32(ColdLead);
            cmd.Parameters.Add("@FirstContact", SqlDbType.DateTime).Value = Convert.ToDateTime(FirstContact);
            cmd.Parameters.Add("@NextContact", SqlDbType.VarChar, 200).Value = NextContact;
            cmd.Parameters.Add("@Discussed", SqlDbType.VarChar, 200).Value = Discussed;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);

                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {


                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {

                            row.Add("Message", dr[col]);

                        }
                        OuterRows.Add("Data", row);
                    }
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Email already exist!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }




    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void GetCustomersListing(string UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetCustomersListingAPI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateAndTime" || col.ColumnName == "DateOfBirth" || col.ColumnName == "Anniversary")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void UploadCustomerDocs(string base64String, string Title, string UserID, string CustomerID)
    {
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();


        try
        {
            string imgfileName = "";
            imgfileName = DateTime.Now.ToString("yyMMddHHmm");
            string Picture = "~/CustomerDocs/" + imgfileName + ".jpg";
            string Picture2 = "../CustomerDocs/" + imgfileName + ".jpg";
            string filePath = HttpContext.Current.Server.MapPath(Picture);
            File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_SaveCustomerDocuments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Document", SqlDbType.VarChar).Value = Picture;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 200).Value = Title;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 200).Value = Convert.ToInt32(CustomerID);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", Picture2);
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ep)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void GetCustomersDocs(string CustomerID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetCustomerFiles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Convert.ToInt32(CustomerID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateAndTime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ViewCustomerDetails(string CustomerID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ViewCustomerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Convert.ToInt32(CustomerID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateOfBirth" || col.ColumnName == "DateAndTime" || col.ColumnName == "FirstContact" || col.ColumnName == "NextContact" || col.ColumnName == "Anniversary")
                            {

                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        OuterRows.Add("Data", row);
                    }
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void DeleteCoustomer(string CustomerID)
    {
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        try
        {


            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 200).Value = Convert.ToInt32(CustomerID);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Customer has benn deleted !");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ep)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void SaveCustomerAsFollowUp(string CustomerID, string FollowUpText, string Description, string FollowUpDateAndTime, string StartTime, string EndTime, string UserID, string StateID, string CityID, string Venue)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_SaveCustomerAsFollowUp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Convert.ToInt32(CustomerID);
            cmd.Parameters.Add("@FollowUpText", SqlDbType.VarChar, 500).Value = FollowUpText;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = Description;
            cmd.Parameters.Add("@FollowUpDateAndTime", SqlDbType.DateTime).Value = Convert.ToDateTime(FollowUpDateAndTime);
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = EndTime;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = Convert.ToInt32(StateID);
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = Convert.ToInt32(CityID);
            cmd.Parameters.Add("@Venue", SqlDbType.VarChar, 500).Value = Venue;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "FollowUp has been save successfuly!");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void GetCustomersFollowUpDetails(string CustomerID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetFollowUpDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Convert.ToInt32(CustomerID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "EndDateTime" || col.ColumnName == "StartDateTime" || col.ColumnName == "FollowUpDateAndTime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }




    //Forums Work  
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void FillTopiCategoryCombo()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_FillCategoryCombo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DateAndTime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }

                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);



                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void AddNewTopic(string Title, string Description, string CategoryID, string TopicID, string IsFlagged, double UserID)
    {
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();


        try
        {


            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_AddNewTopic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(CategoryID);
            cmd.Parameters.Add("@TopicID", SqlDbType.Int, 200).Value = Convert.ToInt32(TopicID);
            cmd.Parameters.Add("@IsFlagged", SqlDbType.Bit).Value = Convert.ToBoolean(IsFlagged);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Topic has been save successfully! ");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ep)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    /// <summary>
    /// ForumTopicDetailsGet pagination
    /// </summary>
    /// <param name="CategoryID">Topic Category</param>
    /// <param name="SearchString">Topic name Like </param>
    /// <param name="RowID">Page No return and -1 for no page More</param>

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ForumTopicDetailsGet(String CategoryID, String SearchString, String RowID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("sp_x_GetForumTopicDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (CategoryID == "" || CategoryID == string.Empty)
            {
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = null;
            }
            else
            {
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToUInt32(CategoryID);
            }
            if (SearchString == "" || SearchString == string.Empty)
            {
                cmd.Parameters.Add("@SearchString", SqlDbType.VarChar, 250).Value = "";
            }
            else
            {
                cmd.Parameters.Add("@SearchString", SqlDbType.VarChar, 250).Value = SearchString;
            }


            cmd.Parameters.Add("@RowID", SqlDbType.Int).Value = Convert.ToUInt32(RowID);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                    Dictionary<string, object> rowPage = new Dictionary<string, object>();
                    rowPage.Add("next_page", -1);
                    OuterRows.Add("pagination", rowPage);
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                            if (col.ColumnName == "LastPostDate")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }

                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);

                    Dictionary<string, object> rowPage = new Dictionary<string, object>();
                    rowPage.Add("next_page", ds.Tables[1].Rows[0]["RowID"]);
                    OuterRows.Add("pagination", rowPage);


                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
                Dictionary<string, object> rowPage = new Dictionary<string, object>();
                rowPage.Add("next_page", -1);
                OuterRows.Add("pagination", rowPage);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Dictionary<string, object> rowPage = new Dictionary<string, object>();
            rowPage.Add("next_page", -1);
            OuterRows.Add("pagination", rowPage);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ForumPostsGet(string TopicID, String UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("sp_GetForumPosts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TopicID", SqlDbType.Int, 200).Value = Convert.ToInt32(TopicID);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                            if (col.ColumnName == "TopicTime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);
                }

                if (ds.Tables[1].Rows.Count == 0)
                {
                    OuterRows.Add("Data2", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows2 = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row2;
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        row2 = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[1].Columns)
                        {
                            if (col.ColumnName == "TopicTime" || col.ColumnName == "PostTime" || col.ColumnName == "CommentTime")
                            {
                                row2.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row2.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows2.Add(row2);
                    }
                    OuterRows.Add("Data2", rows2);
                }

                if (ds.Tables[2].Rows.Count == 0)
                {
                    OuterRows.Add("Data3", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows3 = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row3;
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        row3 = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[2].Columns)
                        {
                            if (col.ColumnName == "EndDateTime" || col.ColumnName == "StartDateTime" || col.ColumnName == "FollowUpDateAndTime")
                            {
                                row3.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row3.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows3.Add(row3);
                    }
                    OuterRows.Add("Data3", rows3);
                }

            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void TopicLike(string UserID, string TopicID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_LikeTopic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@TopicID", SqlDbType.Int).Value = Convert.ToInt32(TopicID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
          
            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);
          

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void TopicUnlike(string UserID, string TopicID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_UnlikeTopic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@TopicID", SqlDbType.Int).Value = Convert.ToInt32(TopicID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void PostsLike(string UserID, string TopicID, string PostID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_LikePosts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@TopicID", SqlDbType.Int).Value = Convert.ToInt32(TopicID);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = Convert.ToInt32(PostID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }
   

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void PostsUnLike(string UserID, string TopicID, string PostID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_UnLikePosts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@TopicID", SqlDbType.Int).Value = Convert.ToInt32(TopicID);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = Convert.ToInt32(PostID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void PostTopicUrlComments(string Content, string TopicID, string CategoryID, string UserID, string IsUrl)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
      
            SqlDataAdapter adp = new SqlDataAdapter("sp_PostTopicComments",con);

            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Content", SqlDbType.NVarChar, (500)).Value = Content;
            adp.SelectCommand.Parameters.Add("@TopicID", SqlDbType.Int).Value = Convert.ToInt32(TopicID);
            adp.SelectCommand.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToUInt32(CategoryID);
            adp.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            adp.SelectCommand.Parameters.Add("@IsUrl", SqlDbType.Bit).Value = Convert.ToBoolean(IsUrl);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            string LocPostID = ds.Tables[0].Rows[0]["PostID"].ToString();
            
            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", LocPostID);
            OuterRows.Add("Data", row);


            
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void PostTopicVideo(string Content, string TopicID, string CategoryID, string UserID, string IsUrl, string YoutubeUrl)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_PostVideo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Content", SqlDbType.NVarChar, (500)).Value = Content;
            cmd.Parameters.Add("@TopicID", SqlDbType.Int).Value = Convert.ToInt32(TopicID);
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToUInt32(CategoryID);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            cmd.Parameters.Add("@IsUrl", SqlDbType.Bit).Value = Convert.ToBoolean(IsUrl);
            cmd.Parameters.Add("@YoutubeUrl", SqlDbType.NVarChar, (250)).Value = YoutubeUrl;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void PostTopicImage(string PostID, string base64String)
    {
         string imgfileName = "";
        imgfileName = DateTime.Now.ToString("yyMMddHHmm");
        string Picture = "~/Attachments/" + imgfileName + ".jpg";
        string Picture2 = "../Attachments/" + imgfileName + ".jpg";
        string filePath = HttpContext.Current.Server.MapPath(Picture);
        File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_AddPostImages", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = Convert.ToInt32(PostID);
            cmd.Parameters.Add("@ImageName", SqlDbType.VarChar, (250)).Value = Picture2;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }

    /// <summary>
    /// Chat Work Star From Here (Search User for chat direct)
    /// </summary>
    /// <param name="UserName">Search Name Like for dev > d ,de , dev</param>
    /// <param name="UserID">USer That are currently login</param>
   
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ChatGetUsersSearch(string UserName, string UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_chat_get_users_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = UserName;
            cmd.Parameters.Add("@destination_id", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                                row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ChatGetUsers( String UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_get_users", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value =Convert.ToInt32( UserID);
            adp.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0 || ds.Tables[1].Rows.Count !=0)
            {
                OuterRows.Add("Status", 200);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                                row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                      //the single chat user with logined user
                    OuterRows.Add("Data", rows);
                }

                if (ds.Tables[1].Rows.Count == 0)
                {
                    OuterRows.Add("Data2", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows2 = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row2;
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        row2 = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[1].Columns)
                        {
                            if (col.ColumnName == "date_time")
                            {
                                row2.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row2.Add(col.ColumnName, dr[col]);
                            }
                        }
                        rows2.Add(row2);
                    }
                    
                   // the group chat user with logined user
                    OuterRows.Add("Data2", rows2);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

           
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
            //   return serializer.Serialize(OuterRows);
        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }

/// <summary>
/// Send all Message Single or in group 
/// </summary>
/// <param name="chat_message"></param>
/// <param name="sender_id">Sender User Id </param>
/// <param name="destination_type"> USER /GROUP</param>
    /// <param name="destination_id">Reciever User Id  if destination_type ='User' / Group ID  if destination_type ='GROUP' </param>
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void ChatSendMessage(string chat_message, string sender_id, string destination_type, string destination_id)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_chat_send_message";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@chat_message", SqlDbType.NVarChar).Value =chat_message;
            cmd.Parameters.Add("@sender_id", SqlDbType.Int).Value =Convert.ToInt32(sender_id);
            cmd.Parameters.Add("@destination_type", SqlDbType.VarChar, (50)).Value =destination_type;
            cmd.Parameters.Add("@destination_id", SqlDbType.Int).Value =Convert.ToInt32(destination_id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "SUCCESS");
            OuterRows.Add("Data", row);
           
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_get_messgaes(string sender_id, string destination_type, string destination_id)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_get_messgaes", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@sender_id", SqlDbType.Int).Value =Convert.ToInt32( sender_id);
            adp.SelectCommand.Parameters.Add("@destination_type", SqlDbType.VarChar, (50)).Value = destination_type;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value = Convert.ToInt32( destination_id);
            adp.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "date_time" )
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                           
                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_create_group(string grp_name, string grp_by_user_id, string base64String)
    {
        string imgfileName = "";
        imgfileName = DateTime.Now.ToString("yyMMddHHmm");
        string Picture = "~/ProfilePics/" + imgfileName + ".jpg";
        string Picture2 = "../ProfilePics/" + imgfileName + ".jpg";
        string filePath = HttpContext.Current.Server.MapPath(Picture);
        File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "chat_create_group";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@grp_name", SqlDbType.VarChar, (50)).Value = grp_name;
            cmd.Parameters.Add("@grp_by_user_id", SqlDbType.Int).Value =Convert.ToInt32( grp_by_user_id);
            cmd.Parameters.Add("@grp_img_url", SqlDbType.NVarChar).Value = Picture2;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            int flag;
            flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", flag);
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_update_group(string grp_id, string grp_name, string grp_by_user_id, string grp_img_url)
    {
        
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_chat_update_group";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@grp_id", SqlDbType.Int).Value = Convert.ToInt32(grp_id);
            cmd.Parameters.Add("@grp_name", SqlDbType.VarChar, (50)).Value = grp_name;
            cmd.Parameters.Add("@grp_by_user_id", SqlDbType.Int).Value = Convert.ToInt32( grp_by_user_id);
            cmd.Parameters.Add("@grp_img_url", SqlDbType.NVarChar).Value = grp_img_url;
            SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
            sqlparm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlparm);
            con.Open();
            cmd.ExecuteNonQuery();
            int flag;
            flag = Convert.ToInt32(sqlparm.Value);
            con.Close();
            cmd.Dispose();
           

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", flag);
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void UploadImageOnly(string base64String)
    {

        string imgfileName = "";
        imgfileName = DateTime.Now.ToString("yyMMddHHmm");
        string Picture = "~/ProfilePics/" + imgfileName + ".jpg";
        string Picture2 = "../ProfilePics/" + imgfileName + ".jpg";
        string filePath = HttpContext.Current.Server.MapPath(Picture);
        File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", Picture2);
            OuterRows.Add("Data", row);
          
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ep)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_group_member_get_all(string group_id)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_group_member_get_all", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@grp_id", SqlDbType.Int).Value =Convert.ToInt32(group_id);
            adp.Fill(dt);
            

            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "grp_datetime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }

                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_group_member_search(string group_id, string full_name, string UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("sp_chat_group_member_search", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@grp_id", SqlDbType.Int).Value = Convert.ToInt32(group_id);
            adp.SelectCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar, (50)).Value = full_name;
            adp.SelectCommand.Parameters.Add("@destination_id", SqlDbType.Int).Value = Convert.ToInt32(UserID);
            adp.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "grp_datetime")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }

                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }

    
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_group_info_get(string group_id)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            DataTable dt = new DataTable();
             SqlDataAdapter adp = new SqlDataAdapter("chat_group_info_get", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@grp_id", SqlDbType.Int).Value =Convert.ToInt32( group_id);
          
            adp.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                OuterRows.Add("Status", 200);
                if (dt.Rows.Count == 0)
                {
                    OuterRows.Add("Data", "");
                }
                else
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "date_time")
                            {
                                row.Add(col.ColumnName, String.Format("{0:G}", dr[col]));
                            }
                            else
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }

                        }
                        rows.Add(row);
                    }
                    OuterRows.Add("Data", rows);
                }
            }
            else
            {
                OuterRows.Add("Status", 404);
                Dictionary<string, object> row = new Dictionary<string, object>();
                row.Add("Message", "Not found!");
                OuterRows.Add("Data", row);
            }

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }

    }
    /// <summary>
    /// flag will Return 1 if satus updated or 2 same curruent status and -1 indicate not update 
    /// </summary>
    /// <param name="id"> id in group member table and </param>
    /// <param name="user_status"></param>
     [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void chat_group_member_status_update(string id, string user_status)
    {
    
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Dictionary<string, object> OuterRows = new Dictionary<string, object>();
        try
        {
            Int32 flag;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "chat_group_member_status_update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value =Convert.ToInt32(id);
            cmd.Parameters.Add("@user_status", SqlDbType.VarChar, (50)).Value = user_status;
            SqlParameter sqlpram = new SqlParameter("@flag", SqlDbType.Int);
            sqlpram.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlpram);
            con.Open();
            cmd.ExecuteNonQuery();

            flag = Convert.ToInt32(sqlpram.Value);
            con.Close();
            cmd.Dispose();
           

            OuterRows.Add("Status", 200);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", flag);
            OuterRows.Add("Data", row);


            cmd.Dispose();
            con.Close();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));

        }
        catch (Exception ex)
        {
            OuterRows.Add("Status", 400);
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Message", "Wrong API key format!");
            OuterRows.Add("Data", row);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializer.Serialize(OuterRows));
        }


    }

    /// <summary>
    /// flag return 1 to added or -1 for not added
    /// </summary>
     /// <param name="group_id">group id in which you want to add </param>
    /// <param name="grp_user_id">User Id that you added in the group</param>
     [WebMethod]
     [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
     public void chat_group_member_add(string group_id, string grp_user_id)
     {

         System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
         Dictionary<string, object> OuterRows = new Dictionary<string, object>();
         try
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "sp_chat_group_member_add";
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Connection = con;
             cmd.Parameters.Add("@grp_id", SqlDbType.Int).Value = Convert.ToInt32(group_id);
             cmd.Parameters.Add("@grp_user_id", SqlDbType.Int).Value = Convert.ToInt32( grp_user_id);
             SqlParameter sqlparm = new SqlParameter("@flag", SqlDbType.Int);
             sqlparm.Direction = ParameterDirection.Output;
             cmd.Parameters.Add(sqlparm);
             con.Open();
             cmd.ExecuteNonQuery();
             int flag;
             flag = Convert.ToInt32(sqlparm.Value);
             con.Close();
             cmd.Dispose();


             OuterRows.Add("Status", 200);
             Dictionary<string, object> row = new Dictionary<string, object>();
             row.Add("Message", flag);
             OuterRows.Add("Data", row);


             cmd.Dispose();
             con.Close();
             Context.Response.Clear();
             Context.Response.ContentType = "application/json";
             Context.Response.Write(serializer.Serialize(OuterRows));

         }
         catch (Exception ex)
         {
             OuterRows.Add("Status", 400);
             Dictionary<string, object> row = new Dictionary<string, object>();
             row.Add("Message", "Wrong API key format!");
             OuterRows.Add("Data", row);
             Context.Response.Clear();
             Context.Response.ContentType = "application/json";
             Context.Response.Write(serializer.Serialize(OuterRows));
         }


     }
 
}
