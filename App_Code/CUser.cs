using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace E2aForums
{
    public class CUser
    {

        #region Class Object Declaration

        DataAccess mobjDataAccess = new DataAccess();

        #endregion Class Object Declaration

        #region Constructor

        //#A Sahil: 040814 - Setting the connection string of DataAccess class in constructor
        public CUser(string ConnectionString)
        {
            mobjDataAccess.ConnectionString = ConnectionString;
            //IsNewsLetterSubscribed = false;
        }
        #endregion Constructor

        #region Properties

        private string mstrEmailID = "";
        public string EmailID
        {
            get { return mstrEmailID; }
            set { mstrEmailID = value; }
        }


       

        private string mstrPassword = "";
        public string Password
        {
            get { return mstrPassword; }
            set { mstrPassword = value; }
        }

        public Int32 RegistrationTypeID { get; set; }
        public bool IsNewsLetterSubscribed { get; set; }

        public Int32 UserTypeID { get; set; }

       


        private string mstrFullName = "";
        public string FullName
        {
            get { return mstrFullName; }
            set { mstrFullName = value; }
        }

        private double mdblUserID = -1;
        public double UserID
        {
            set
            {
                mdblUserID = value;
            }
            get
            {
                return mdblUserID;
            }
        }


        public int Status { get; set; }
        public int EmailAlreadyExists { get; set; }



        public bool IsAdmin { get; set; }
        public string UserTheme { get; set; }



        private Int32 mintCommConsent = -1;
        public Int32 CommConsent
        {
            set
            {
                mintCommConsent = value;
            }
            get
            {
                return mintCommConsent;
            }
        }
        public bool IsUserLoginDisabled { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryID { get; set; }
        public bool IsIsApproved { get; set; }
        public Int32 OccupationID { get; set; }
        public double mdblCityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CompName { get; set; }

        public bool IsComp { get; set; }
        public bool IsCompAdmin { get; set; }
        public Int32 OfCompID { get; set; }
        public string session_val { get; set; }

        public string PlanActive { get; set; }

        #endregion


        #region Functions

        #region GetIndexCount
        public DataSet GetIndexCount(double pintuserID)
        {
            DataSet lobjds = new DataSet();
            try
            {
                string lstrQuery = "";

                Hashtable lobjhash = new Hashtable();

                lstrQuery = "EXEC sp_GetIndexCount @UserID";

                lobjhash.Add("@UserID", pintuserID);

                lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return lobjds;

        }
        #endregion GetIndexCount

        #region GetTopBarCount

        /// Function To Get Index Page Details 


        public DataSet GetTopBarCount(double pintuserID)
        {
            DataSet lobjds = new DataSet();
            try
            {
                string lstrQuery = "";

                Hashtable lobjhash = new Hashtable();

                lstrQuery = "EXEC sp_Get_top_bar_count @UserID";

                lobjhash.Add("@UserID", pintuserID);

                lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return lobjds;

        }
        #endregion GetTopBarCount

        #region RegisterUser
        /// function used to register new users
        public void RegisterUser()
        {
            DataSet lobjDS = null;
            Hashtable lobjHashTable = new Hashtable();
            string lstrSqlQuery = "EXEC sp_RegisterUser @EmailID, @Password, @FirstName, @LastName, @RegistrationTypeID, @IsNewsLetterSubscribed";
            lobjHashTable.Add("@EmailID", mstrEmailID);
            lobjHashTable.Add("@Password", mstrPassword);
            
            if (FirstName == null)
                lobjHashTable.Add("@FirstName", "");
            else
                lobjHashTable.Add("@FirstName", FirstName);
            if (LastName == null)
                lobjHashTable.Add("@LastName", "");
            else
                lobjHashTable.Add("@LastName", LastName);
            lobjHashTable.Add("@RegistrationTypeID", RegistrationTypeID);
            lobjHashTable.Add("@IsNewsLetterSubscribed", IsNewsLetterSubscribed);
        

            try
            {
                lobjDS = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjHashTable, true);
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (lobjDS != null)
            {
                if (lobjDS.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    mdblUserID = Convert.ToDouble(lobjDS.Tables[0].Rows[0]["UserID"]);
                }

                if (lobjDS.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    Status = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["Status"]);
                }

                if (lobjDS.Tables[0].Rows[0]["EmailAlreadyExists"].ToString() != "")
                {
                    EmailAlreadyExists = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["EmailAlreadyExists"]);
                }

                if (lobjDS.Tables[0].Rows[0]["OccupationID"].ToString() != "")
                {
                    OccupationID = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["OccupationID"]);

                }

            }

        }
        #endregion RegisterUser

        

        #region ValidateUser
        /// <summary>
        /// function used to register new users
        /// </summary>
        /// <exclude>
        /// Author - Sahil Sharma
        /// Create Date - 040814
        /// </exclude>                
        public void ValidateUser()
        {
            DataSet lobjDS = new DataSet();
            Hashtable lobjHashTable = new Hashtable();

            string lstrSqlQuery = "EXEC sp_ValidateUser @EmailID, @Password";

            lobjHashTable.Add("@EmailID", mstrEmailID);
            lobjHashTable.Add("@Password", mstrPassword);

            try
            {
                lobjDS = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjHashTable, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (lobjDS != null)
            {
                if (lobjDS.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    mdblUserID = Convert.ToDouble(lobjDS.Tables[0].Rows[0]["UserID"]);

                }
                if (lobjDS.Tables[0].Rows[0]["IsAdmin"].ToString() != "")
                {
                    IsAdmin = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsAdmin"]);

                }
                if (lobjDS.Tables[0].Rows[0]["Theme"].ToString() != "")
                {
                    UserTheme = Convert.ToString(lobjDS.Tables[0].Rows[0]["Theme"]);

                }

                if (lobjDS.Tables[0].Rows[0]["CommunicateConsent"].ToString() != "")
                {
                    mintCommConsent = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["CommunicateConsent"]);

                }
                if (lobjDS.Tables[0].Rows[0]["IsUserLoginDisabled"].ToString() != "")
                {
                    IsUserLoginDisabled = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsUserLoginDisabled"]);

                }
                if (lobjDS.Tables[0].Rows[0]["IsApproved"].ToString() != "")
                {
                    IsApproved = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsApproved"]);

                }
                if (lobjDS.Tables[0].Rows[0]["CityID"].ToString() != "")
                {
                    mdblCityID = Convert.ToDouble(lobjDS.Tables[0].Rows[0]["CityID"]);

                }
                if (lobjDS.Tables[0].Rows[0]["UserTypeID"].ToString() != "")
                {
                    UserTypeID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["UserTypeID"]);

                }
                if (lobjDS.Tables[0].Rows[0]["OccupationID"].ToString() != "")
                {
                    OccupationID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["OccupationID"]);

                }

                if (lobjDS.Tables[0].Rows[0]["IsComp"].ToString() != "")
                {
                    IsComp = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsComp"]);

                }
                if (lobjDS.Tables[0].Rows[0]["IsCompAdmin"].ToString() != "")
                {
                    IsCompAdmin = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsCompAdmin"]);

                }
                if (lobjDS.Tables[0].Rows[0]["OfCompID"].ToString() != "")
                {
                    OfCompID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["OfCompID"]);

                }

                if (lobjDS.Tables[0].Rows[0]["PlanActive"].ToString() != "")
                {
                    PlanActive = lobjDS.Tables[0].Rows[0]["PlanActive"].ToString();
                }


            }

        }
        #endregion RegisterUser

        #region AddLinkedAccountForUser
        /// <summary>
        /// function used to Add Linked Account For User
        /// </summary>
        /// <exclude>
        /// Author - Manish Sharma
        /// Create Date - 042514
        /// </exclude>                
        public bool AddLinkedAccountForUser(string pstrEmail, Int32 pintRegTypID, double pdblUserID)
        {
            bool lblnResp = false;
            object objResp = new object();
            Hashtable lobjHashTable = new Hashtable();

            string lstrSqlQuery = "EXEC sp_AddLinkedAccounts @EmailID, @RegistrationTypeID, @UserID";

            lobjHashTable.Add("@EmailID", pstrEmail);
            lobjHashTable.Add("@RegistrationTypeID", pintRegTypID);
            lobjHashTable.Add("@UserID", pdblUserID);

            try
            {
                objResp = mobjDataAccess.SQLExecuteScalar(lstrSqlQuery, lobjHashTable, true);

                if (objResp != null)
                    lblnResp = Convert.ToBoolean(objResp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return lblnResp;

        }
        #endregion

        #region AddUserDetails
        /// *********************************************************
        /// <summary>
        /// Function used to add user details
        /// </summary>
        /// <exclude>
        /// <Author>Sahil Sharma</Author>
        /// <Date>072314</Date>
        /// </exclude>
        /// *********************************************************
        //public void AddUserDetails(string lstrFirstName, string lstrLastname, string lstrOrg, string lstrAddress1, string lstrAddress2, string lstrCity, string lstrAddress, string lstrMga, string lstrGovBody, string lstrSince, string lstrPhoneNo, double ldblUserID, Int32 lintOccuID, Int32 lintConsent)
        //{

        //    try
        //    {
        //        Hashtable lobjHash = new Hashtable();
        //        string lstrQuery = "";

        //        lstrQuery = "EXEC Sp_AddUserDetails  @FirstName,@Lastname,@Org,@Address1,@Address2,@City,@Address,@Mga,@GovBody,@Since,@PhoneNo,@UserID, @OccuID, @Consent";

        //        lobjHash.Add("@FirstName", lstrFirstName);
        //        lobjHash.Add("@Lastname", lstrLastname);
        //        lobjHash.Add("@Org", lstrOrg);
        //        lobjHash.Add("@Address1", lstrAddress1);
        //        lobjHash.Add("@Address2", lstrAddress2);
        //        lobjHash.Add("@City", lstrCity);
        //        lobjHash.Add("@Address", lstrAddress);
        //        lobjHash.Add("@Mga", lstrMga);
        //        lobjHash.Add("@GovBody", lstrGovBody);
        //        lobjHash.Add("@Since", lstrSince);
        //        lobjHash.Add("@PhoneNo", lstrPhoneNo);
        //        lobjHash.Add("@UserID", ldblUserID);
        //        lobjHash.Add("@OccuID", lintOccuID);
        //        lobjHash.Add("@Consent", lintConsent);


        //        mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Failure: Error while updating details" + ex.Message);
        //    }
        //}
        #endregion AddClinic

        #region GetOccupations
        /// <summary>
        /// Author:Sahil Sharma
        /// Dtae:072314
        /// </summary>
        /// <returns></returns>
        public DataSet GetOccupations()
        {
            DataSet lobjDS = new DataSet();
            try
            {
                Hashtable lobjHash = new Hashtable();
                string lstrQuery = "";

                lstrQuery = "EXEC sp_GetOccupations ";

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception("Failure:Error Getting Specialities.  " + ex.Message);
            }
            return lobjDS;
        }



        #endregion GetClassSection

        #region GetUserDetails
        /// ****************************************************************************************
        /// <summary>
        /// Function To Get User Details from datbase
        /// </summary>
        /// <remarks>
        /// Date - 092612
        /// Author- Sahil Sharma
        /// </remarks>
        /// ****************************************************************************************

        public DataSet GetUserDetails(double pintuserID)
        {
            DataSet lobjds = new DataSet();
            try
            {
                string lstrQuery = "";

                Hashtable lobjhash = new Hashtable();

                lstrQuery = "EXEC Sp_GetUserDetails @UserID";

                lobjhash.Add("@UserID", pintuserID);

                lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return lobjds;

        }
        #endregion GetUserDetails

        #region GetForumCategoryDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072114
        /// Function used to get thr category details of forum
        /// </summary>
        /// <returns></returns>
        public DataSet GetForumCategoryDetails(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetForumCategoryDetails @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString ";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@sidx", ldblStartIndex);
            lobjHash.Add("@eidx", ldblEndIndex);
            lobjHash.Add("@SortByColName", lstrSortParameter);
            lobjHash.Add("@SortOrder", lstrSortOrder);
            lobjHash.Add("@SearchColumn", lstrSearchColumn);
            lobjHash.Add("@SearchString", lstrSearchString);


            try
            {
                ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception)
            {
                throw;
            }

            return ds;
        }
        #endregion GetForumCategoryDetails
        

        #region GetForumTopicDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072114
        /// function used to get topic details of forum.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <param name="lintCategoryID"></param>
        /// <returns></returns>
        public DataSet GetForumTopicDetails(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, int lintCategoryID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetForumTopicDetails @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString , @CategoryID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@sidx", ldblStartIndex);
            lobjHash.Add("@eidx", ldblEndIndex);
            lobjHash.Add("@SortByColName", lstrSortParameter);
            lobjHash.Add("@SortOrder", lstrSortOrder);
            lobjHash.Add("@SearchColumn", lstrSearchColumn);
            lobjHash.Add("@SearchString", lstrSearchString);
            lobjHash.Add("@CategoryID", lintCategoryID);

            try
            {
                ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception)
            {
                throw;
            }

            return ds;
        }

        #endregion GetForumTopicDetails

        #region GetMyForumTopicDetails
        /// GetForumTopicDetails
  
        public DataSet GetMyForumTopicDetails(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, int UserID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetForumMyTopicDetails @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString , @UserID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@sidx", ldblStartIndex);
            lobjHash.Add("@eidx", ldblEndIndex);
            lobjHash.Add("@SortByColName", lstrSortParameter);
            lobjHash.Add("@SortOrder", lstrSortOrder);
            lobjHash.Add("@SearchColumn", lstrSearchColumn);
            lobjHash.Add("@SearchString", lstrSearchString);
            lobjHash.Add("@UserID", UserID);

            try
            {
                ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw;
            }

            return ds;
        }

        #endregion GetMyForumTopicDetails


        #region GetMyForumTopic
        /// GetForumTopic

        public  DataSet GetMyForumTopic(int UUserID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetForumMyTopic  @UserID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@UserID", UUserID);

            try
            {
                ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw;
            }

            return ds;
        }

        #endregion GetMyForumTopic


        #region FillCategoryCombo
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:072114
        /// Function used to fill category combo
        /// </summary>
        /// <returns></returns>
        public DataSet FillCategoryCombo()
        {
            DataSet lobjDS = null;
            string lstrQuery = "Exec sp_FillCategoryCombo";
            try
            {
                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }

        #endregion FillCategoryCombo

        #region GetForumPosts
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:072214
        /// function used to get posts detail of forum
        /// </summary>
        /// <param name="lintTopicID"></param>
        /// <returns></returns>       
        public DataSet GetForumPosts(int lintTopicID, double mdblUserID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetForumPosts @TopicID,@UserID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@TopicID", lintTopicID);
            lobjHash.Add("@UserID", mdblUserID);
            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;

        }

        #endregion GetForumPosts

        #region FillTopicCombo
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:072214
        /// Function used to fill topic combo
        /// </summary>
        /// <param name="lintTopicID"></param>
        /// <returns></returns>
        public DataSet FillTopicCombo(int lintTopicID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "Exec sp_FillTopicCombo @TopicID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@TopicID", lintTopicID);
            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }

        #endregion FillTopicCombo

        #region DeleteCategory
        /// <summary>
        /// Author:jasmeet kaur
        /// Date:072314
        /// Function used to delete category
        /// </summary>
        /// <param name="lintCategoryID"></param>
        public void DeleteCategory(int lintCategoryID)
        {
            string lstrQuery = "EXEC sp_DeleteCategory @CategoryID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@CategoryID", lintCategoryID);

            try
            {
                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion DeleteCategory

        #region AddCategory
        /// <summary>
        /// Author:jasmeet kaur
        /// Date:072314
        /// Function used to add category
        /// </summary>
        /// <param name="lintCatgoryID"></param>
        /// <param name="lstrTitle"></param>
        /// <param name="lstrDescription"></param>
        /// <returns></returns>
        public string AddCategory(int lintCatgoryID, string lstrTitle, string lstrDescription, double mdblUserID)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_AddEditCategory @CategoryID,@Title,@Description,@UserID";

                lobjHash.Add("@CategoryID", lintCatgoryID);
                lobjHash.Add("@Title", lstrTitle);
                lobjHash.Add("@Description", lstrDescription);
                lobjHash.Add("@UserID", mdblUserID);

                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                if (lobjres != null)
                    lstrResult = lobjres.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstrResult;
        }

        #endregion AddCategory

        #region GetMemberTopicCount
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072514
        /// Function used to get Category details.
        /// </summary>
        /// <param name="lintCategoryID"></param>
        /// <returns></returns>
        public DataSet GetMemberTopicCount()
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetMemberCount";
            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }

        #endregion GetMemberTopicCount


        #region GetCategoryDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072514
        /// Function used to get Category details.
        /// </summary>
        /// <param name="lintCategoryID"></param>
        /// <returns></returns>
        public DataSet GetCategoryDetails(int lintCategoryID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetCategoryDetails @CategoryID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@CategoryID", lintCategoryID);
            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }

        #endregion GetCategoryDetais

        #region GetTopicListing
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072514
        /// Function used to get topic listing
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <returns></returns>

        public DataSet GetTopicListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, int lintCategoryID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetTopicListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString,@CategoryID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@sidx", ldblStartIndex);
            lobjHash.Add("@eidx", ldblEndIndex);
            lobjHash.Add("@SortByColName", lstrSortParameter);
            lobjHash.Add("@SortOrder", lstrSortOrder);
            lobjHash.Add("@SearchColumn", lstrSearchColumn);
            lobjHash.Add("@SearchString", lstrSearchString);
            lobjHash.Add("@CategoryID", lintCategoryID);
            try
            {
                ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception)
            {
                throw;
            }

            return ds;
        }

        #endregion GetTopicListing

        #region DeleteTopic
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072814
        /// Function used to delete Topic and its posts.
        /// </summary>
        /// <param name="lintTopicID"></param>
        public void DeleteTopic(int lintTopicID)
        {
            string lstrQuery = "EXEC sp_DeleteTopics @TopicID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@TopicID", lintTopicID);

            try
            {
                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion DeleteTopic

        #region GetTopicDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:072814
        /// Function used to get topic details
        /// </summary>
        /// <param name="lintTopicID"></param>
        /// <returns></returns>
        public DataSet GetTopicDetails(int lintTopicID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetTopicDetails @TopicID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@TopicID", lintTopicID);
            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }

        #endregion GetTopicDetails

        #region AddNewTopic
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:072814
        /// Function used to add new topics.
        /// </summary>
        /// <param name="lstrTitle"></param>
        /// <param name="lstrDescription"></param>
        /// <param name="lintCategoryID"></param>
        /// <param name="lintTopicID"></param>
        /// <returns></returns>
        //public string AddNewTopic(string lstrTitle, string lstrDescription, int lintCategoryID, int lintTopicID)
        //{
        //    string lstrResult = "";
        //    object lobjres = new object();
        //    Hashtable lobjHash = new Hashtable();

        //    try
        //    {
        //        string lstrQuery = "EXEC sp_AddNewTopic @Title,@Description,@CategoryID,@TopicID";
        //        lobjHash.Add("@Title", lstrTitle);
        //        lobjHash.Add("@Description", lstrDescription);
        //        lobjHash.Add("@CategoryID", lintCategoryID);
        //        lobjHash.Add("@TopicID", lintTopicID);

        //        lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

        //        if (lobjres != null)
        //            lstrResult = lobjres.ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return lstrResult;
        //}

        #endregion AddNewTopic

        #region LikePosts
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Dtae:072814
        /// Function Used to like posts.
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <param name="lintTopicID"></param>
        /// <returns></returns>
        public void LikePosts(double mdblUserID, int lintTopicID, int lintPostID)
        {
           
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_LikePosts @UserID,@TopicID,@PostID";
            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@TopicID", lintTopicID);
            lobjHash.Add("@PostID", lintPostID);
            try
            {
                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        #endregion LikePosts

        #region AddnewTopic
       /// <summary>
       /// Author:Jasmeet Kaur
       /// Date:072814
       /// Function used to add new topic
       /// </summary>
       /// <param name="lstrTitle"></param>
       /// <param name="lstrDescription"></param>
       /// <param name="lintCategoryID"></param>
       /// <param name="lintTopicID"></param>
       /// <param name="lblnIsFlagged"></param>
       /// <param name="mdblUserID"></param>
       /// <returns></returns>
       public string AddNewTopic(string lstrTitle, string lstrDescription, int lintCategoryID, int lintTopicID, bool lblnIsFlagged, double mdblUserID)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_AddNewTopic @Title,@Description,@CategoryID,@TopicID,@IsFlagged,@UserID";
                lobjHash.Add("@Title", lstrTitle);
                lobjHash.Add("@Description", lstrDescription);
                lobjHash.Add("@CategoryID", lintCategoryID);
                lobjHash.Add("@TopicID", lintTopicID);
                lobjHash.Add("@IsFlagged", lblnIsFlagged);
                lobjHash.Add("@UserID", mdblUserID);

                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                if (lobjres != null)
                    lstrResult = lobjres.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstrResult;
        }

        #endregion AddNewTopic

       

       #region PostTopicComments
       /// <summary>
        /// Author:Jasmeet kaur:
        /// Date:072914
        /// function used to get the comments of topic.
        /// </summary>
        /// <param name="lstrComments"></param>
        /// <param name="lintTopicID"></param>
        /// <param name="lintCategoryID"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
       public int PostTopicComments(string lstrComments, int lintTopicID, int lintCategoryID, double mdblUserID, bool lblIsUrl)
       {
            Int32 ID = -1;
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_PostTopicComments @Content,@TopicID,@CategoryID,@UserID,@IsUrl";
                lobjHash.Add("@Content", lstrComments);
                lobjHash.Add("@TopicID", lintTopicID);
                lobjHash.Add("@CategoryID", lintCategoryID);
                lobjHash.Add("@UserID", mdblUserID);
                lobjHash.Add("@IsUrl", lblIsUrl);

                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                if (lobjres != null)
                    ID = Convert.ToInt32(lobjres);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ID;
        }

        #endregion PostTopicComments

        #region AddPostComments
        /// <summary>
        /// Author:jasmeet kaur
        /// Date:072914
        /// Function used to post comments
        /// </summary>
        /// <param name="lstrComments"></param>
        /// <param name="lintPostID"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
        public string AddPostComments(string lstrComments, int lintPostID, double mdblUserID)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_AddPostComments @Content,@PostID,@UserID";
                lobjHash.Add("@Content", lstrComments);
                lobjHash.Add("@PostID", lintPostID);
                lobjHash.Add("@UserID", mdblUserID);


                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                if (lobjres != null)
                    lstrResult = lobjres.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstrResult;
        }
        #endregion AddPostComments

        #region GetTopicViewCount
        public void GetTopicViewCount(int lintTopicID)
        {
            string lstrQuery = "EXEC sp_GetTopicViewCount @TopicID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@TopicID", lintTopicID);

            try
            {
                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion GetTopicViewCount

        #region SendMessage
        /// <summary>
        /// Author:Sahil
        /// Date:081014
        /// Function used to add message to database
        /// </summary>
        /// <returns></returns>
        public void SendMessage(Int32 lintSenderID, Int32 lintRecevierID, string lstrMessage)
        {
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_SendMessage @SenderID,@RecevierID,@Message";

                lobjHash.Add("@SenderID", lintSenderID);
                lobjHash.Add("@RecevierID", lintRecevierID);
                lobjHash.Add("@Message", lstrMessage);

                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion AddCategory

        #region GetSenderNameList
        /// <summary>
        /// Author:jasmeet kaur
        /// Date:081114
        /// Function used to get sender's name list.
        /// </summary>
        /// <param name="lintUserID"></param>
        /// <returns></returns>
        public DataSet GetSenderNameList(double mdblUserID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetSenderNameList @UserID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@UserID", mdblUserID);

            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }

        #endregion GetSenderNameList

        #region GetMessageList
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:081114
        /// Function used to get message list.
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <param name="lintSenderID"></param>
        /// <returns></returns>
        public DataSet GetMessageList(double mdblUserID, int lintSenderID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetMessages @UserID,@SenderID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@SenderID", lintSenderID);

            try
            {

                lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lobjDS;
        }
        #endregion GetMessageList

        #region PostMessageToUser
        public void PostMessageToUser(int lintReceiverrID, double mdblUserID, string lstrMessage)
        {
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_PostMessageToUser @ReceiverID,@UserID,@Message";

                lobjHash.Add("@ReceiverID", lintReceiverrID);
                lobjHash.Add("@UserID", mdblUserID);
                lobjHash.Add("@Message", lstrMessage);

                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion PostMessageToUser

        #region AddPostImages
         public string AddPostImages(string str, int PostID)
        {
        //public string AddPostImages(string[] imagesArr, int PostID)
        //{
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            try
            {
                string lstrQuery = "EXEC sp_AddPostImages @PostID,@ImageName";
                lobjHash.Add("@PostID", PostID);
                lobjHash.Add("@ImageName", str);
               
                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                if (lobjres != null)
                    lstrResult = lobjres.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstrResult;
        }

        #endregion AddPostImages

        #region GetLoggedinUserDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:081414
        /// Function used to get loggedin user details.
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
         public DataSet GetLoggedinUserDetails(double mdblUserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC sp_GetLoggedinUserDetails @UserID";

                 lobjhash.Add("@UserID", mdblUserID);

                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
         }

         #endregion GetLoggedinUserDetails

        #region UpdateUserDetails
         public void UpdateUserDetails(string lstrName, int lintOccupationID, string lstrOtherOccupation, string lstrOrganization, string lstrAddress1, string lstrAddress2, string lstrAddress3, string lstrDealerName, string lstrMgs, string lstrGoverningBody, string lstrInBusinessSince, string lstrPhone, string lstrImages, int lintConsent, double mdblUserID, int lintStateID, int lintCityID, string lstrVideoURL,string lstrAboutMe,string lstrdesignation)
         {
                 DataSet lobjDS = new DataSet();
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "EXEC sp_UpdateUserDetails @Full_Name, @OccupationID,@OtherOccupation,@Organization,@Address_line1,@Address_Line2,@Address_Line3,@DealerName,@Mga,@GoverningBody,@InBusinessSince,@Mobile_Phone,@Picture,@CommunicateConsent,@UserID,@StateID,@CityID,@ProfileYoutubeURL,@AboutMe,@designation";
                 lobjHash.Add("@Full_Name", lstrName);
                 lobjHash.Add("@OccupationID", lintOccupationID);
                 lobjHash.Add("@OtherOccupation", lstrOtherOccupation);
                 lobjHash.Add("@Organization", lstrOrganization);
                 lobjHash.Add("@Address_line1", lstrAddress1);
                 lobjHash.Add("@Address_Line2", lstrAddress2);
                 lobjHash.Add("@Address_Line3", lstrAddress3);
                 lobjHash.Add("@DealerName", lstrDealerName);
                 lobjHash.Add("@Mga", lstrMgs);
                 lobjHash.Add("@GoverningBody", lstrGoverningBody);
                 lobjHash.Add("@InBusinessSince", lstrInBusinessSince);
                 lobjHash.Add("@Mobile_Phone", lstrPhone);
                 lobjHash.Add("@Picture", lstrImages);
                 lobjHash.Add("@CommunicateConsent", lintConsent);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@StateID", lintStateID);
                 lobjHash.Add("@CityID", lintCityID);
                 lobjHash.Add("@ProfileYoutubeURL", lstrVideoURL);
                 lobjHash.Add("@AboutMe", lstrAboutMe);
                 lobjHash.Add("@designation", lstrdesignation);
                
             try
                 {
                     lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
                     //mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
                 }
                 catch (Exception ex)
                 {
                     throw new Exception(ex.Message);
                 }
                 if (lobjDS != null)
                 {
                     if (lobjDS.Tables[0].Rows[0]["OccupationID"].ToString() != "")
                     {
                         OccupationID = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["OccupationID"]);

                     }
                 }

         }
         #endregion UpdateUserDetails

         #region UpdateUserProPic
         public void UpdateUserProPic( string lstrImages ,Double user_havID)
         {
             DataSet lobjDS = new DataSet();
             Hashtable lobjHash = new Hashtable();
             string lstrQuery = "EXEC sp_UpdateUserProPic @Picture,@UserID";
   
             lobjHash.Add("@Picture", lstrImages);
             lobjHash.Add("@UserID", user_havID);
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
                 //mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
            

         }
         #endregion UpdateUserProPic

         #region UnlikePosts
         /// <summary>
        /// Author:Jasmeet kaur
        /// Datew:081814
        /// Function used to unlike the post.
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <param name="lintTopicID"></param>
        /// <param name="lintPostID"></param>
         public void UnlikePosts(double mdblUserID, int lintTopicID, int lintPostID)
         {
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             string lstrQuery = "EXEC sp_UnLikePosts @UserID,@TopicID,@PostID";
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@TopicID", lintTopicID);
             lobjHash.Add("@PostID", lintPostID);
             try
             {
                 lobjres=mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }
         #endregion UnlikePosts

        #region GetPostsList
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:081914
        /// Function used to get details of selected post id.
        /// </summary>
        /// <param name="lintPostID"></param>
        /// <returns></returns>
         public DataSet GetPostsList(int lintPostID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetPostDetails @PostID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@PostID", lintPostID);
             
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }
         #endregion GetPostsList

        #region GetUsersListing
         public DataSet GetUsersListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetUsersListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }

         #endregion GetUsersListing

        #region ViewUserProfile
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:082714
        /// Function Used to view user profile
        /// </summary>
        /// <param name="lintUserID"></param>
        /// <returns></returns>
         public DataSet ViewUserProfile(int lintUserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";
                 Hashtable lobjhash = new Hashtable();
                 lstrQuery = "EXEC sp_GetLoggedinUserDetails @UserID";
                 lobjhash.Add("@UserID", lintUserID);
                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
         }
         #endregion ViewUserProfile

        #region MarkUserDisable
        
         public void MarkUserDisable(double ldblUserID)
         {
             try
             {
                 string lstrQuery = string.Empty;
                 Hashtable lobjHash = new Hashtable();
                 lstrQuery = "EXEC sp_MarkUserDisable @UserID";
                 lobjHash.Add("@UserID", ldblUserID);

                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         #endregion MarkUserDisable

        #region GetAllNotifications
      
       
         public DataSet GetAllNotifications(double mdblUserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC sp_GetAllNotifications @UserID";
                 lobjhash.Add("@UserID", mdblUserID);                
                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
         }

         #endregion GetAllNotifications


         #region GetEventAlert
        
         public DataSet GetEventAlert(double mdblUserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC sp_GetCalendarEventsAlert @UserID";
                 lobjhash.Add("@UserID", mdblUserID);
                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
         }

         #endregion GetEventAlert


         #region GetAllAlert

         public DataSet GetAllAlert(double mdblUserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC sp_GetAllAlert @UserID";
                 lobjhash.Add("@UserID", mdblUserID);
                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
         }

         #endregion GetAllAlert


         #region ViewNotifications
         /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:082914
        /// Function used to view notifications
        /// </summary>
        /// <param name="lintReferenceID"></param>
        /// <param name="lstrNotificationType"></param>
        /// <returns></returns>
         public DataSet ViewNotifications(int lintReferenceID, string lstrNotificationType, double mdblUserID, int lintNotificationID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_ViewNotifications @ReferenceID,@NotificationType,@UserID,@NotificationID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@ReferenceID", lintReferenceID);
             lobjHash.Add("@NotificationType", lstrNotificationType);
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@NotificationID", lintNotificationID);

             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

        #endregion ViewNotifications

        #region AddUserDetails
         public void AddUserDetails(string lstrFirstName, string lstrLastname, string lstrOrg, string lstrAddress1, string lstrAddress2, string lstrAddress, string lstrMga, string lstrGovBody, string lstrSince, string lstrPhoneNo, double mdblUserID, int lintOccuID, string lstrOtherOccupation, int lintConsent, int lintStateID, int lintCityID, string lstrVideoURL, double mdblUserTypeID)
         {
             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 lstrQuery = "EXEC Sp_AddUserDetails  @FirstName,@Lastname,@Org,@Address1,@Address2,@Address,@Mga,@GovBody,@Since,@PhoneNo,@UserID, @OccuID, @OtherOccupation, @Consent, @StateID, @CityID, @ProfileYoutubeURL,@UserTypeID";

                 lobjHash.Add("@FirstName", lstrFirstName);
                 lobjHash.Add("@Lastname", lstrLastname);
                 lobjHash.Add("@Org", lstrOrg);
                 lobjHash.Add("@Address1", lstrAddress1);
                 lobjHash.Add("@Address2", lstrAddress2);
                 lobjHash.Add("@Address", lstrAddress);
                 lobjHash.Add("@Mga", lstrMga);
                 lobjHash.Add("@GovBody", lstrGovBody);
                 lobjHash.Add("@Since", lstrSince);
                 lobjHash.Add("@PhoneNo", lstrPhoneNo);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@OccuID", lintOccuID);
                 lobjHash.Add("@OtherOccupation", lstrOtherOccupation);
                 lobjHash.Add("@Consent", lintConsent);
                 lobjHash.Add("@StateID", lintStateID);
                 lobjHash.Add("@CityID", lintCityID);
                 lobjHash.Add("@ProfileYoutubeURL", lstrVideoURL);
                 lobjHash.Add("@UserTypeID", mdblUserTypeID);

                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception("Failure: Error while updating details" + ex.Message);
             }
         }
         #endregion AddUserDetails

        #region ApproveUser
         /// <summary>
         /// function used to approve users
         /// </summary>
         /// <exclude>
         /// Author - Jasmeet Kaur
         /// Create Date - 090514
         /// </exclude>                
         public DataSet ApproveUser(Int32 lintUserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC sp_UserApprovedByAdmin @UserID";

                 lobjhash.Add("@UserID", lintUserID);

                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
                         
         }


         #endregion ApproveUser

        #region UnApproveUser
         /// <summary>
         /// function used to Unapprove users
         /// </summary>
         /// <exclude>
         /// Author - Jasmeet Kaur
         /// Create Date - 090514
         /// </exclude> 
         public DataSet UnApproveUser(int UserID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC sp_UserUnApprovedByAdmin @UserID";

                 lobjhash.Add("@UserID", UserID);

                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
            
         }

         #endregion UnApproveUser

        #region PostTopicUrl
        /// <summary>
        /// Author:jasmeet kaur
        /// Date:090914
        /// Function used to post url.
        /// </summary>
        /// <param name="lstrComments"></param>
        /// <param name="lintTopicID"></param>
        /// <param name="lintCategoryID"></param>
        /// <param name="mdblUserID"></param>
        /// <param name="lblIsUrl"></param>
        /// <returns></returns>
         public string PostTopicUrl(string lstrComments, int lintTopicID, int lintCategoryID, double mdblUserID, bool lblIsUrl)
         {
             string lstrResult = "";
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             try
             {
                 string lstrQuery = "EXEC sp_PostTopicComments @Content,@TopicID,@CategoryID,@UserID,@IsUrl";
                 lobjHash.Add("@Content", lstrComments);
                 lobjHash.Add("@TopicID", lintTopicID);
                 lobjHash.Add("@CategoryID", lintCategoryID);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@IsUrl", lblIsUrl);


                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lstrResult;
         }
         #endregion PostTopicUrl

        #region FillCityCombo
         public DataSet FillCityCombo()
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_FillCityCombo";
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion FillCityCombo

        #region FillImgSizeCombo

         public DataSet FillImgSizeCombo()
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_FillImgSizeCombo";
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion FillImgSizeCombo

        #region AddNewAdvertisement
         //public void AddNewAdvertisement(string lstrTitle, string lstrImages, string lstrClickUrl, string lstrFromDate, string lstrToDate, string lstrFromTime, string lstrToTime, int lintImageSizeID, int lintStateID, int lintCityID, double mdblUserID, int lintAdvertisementId)
         //{
         public void AddNewAdvertisement(string lstrTitle, string lstrImages, string lstrClickUrl, string lstrFromDate, string lstrToDate, string lstrFromTime, string lstrToTime, int lintImageSizeID, int lintZoneID, double mdblUserID, int lintAdvertisementId)
         {
            
             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 lstrQuery = "EXEC sp_AddNewAdvertisement @Title,@ImageName,@ClickUrl,@FromDateTime,@ToDateTime,@FromTime,@ToTime,@ImageSizeID,@ZoneID,@UserID,@AdvertisementID";

                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@ImageName", lstrImages);
                 lobjHash.Add("@ClickUrl", lstrClickUrl);
                 lobjHash.Add("@FromDateTime", lstrFromDate);
                 lobjHash.Add("@ToDateTime", lstrToDate);
                 lobjHash.Add("@FromTime", lstrFromTime);
                 lobjHash.Add("@ToTime", lstrToTime);
                 lobjHash.Add("@ImageSizeID", lintImageSizeID);
                 //lobjHash.Add("@StateID", lintStateID);
                 //lobjHash.Add("@CityID", lintCityID);
                 lobjHash.Add("@ZoneID", lintZoneID);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@AdvertisementID", lintAdvertisementId);
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception("Failure: Error while updating details" + ex.Message);
             }
         }

         #endregion AddNewAdvertisement

        #region GetAdvertisementListing
         /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:092314
        /// Function used to get Advertisementlisting.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <returns></returns>
         public DataSet GetAdvertisementListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetAdvertisementListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);
           
             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }

         #endregion GetAdvertisementListing

        #region DeleteAdvertisement
        /// <summary>
        /// Author:jasmeet kaur
        /// Date:092314
        /// Function used to delete advertisement.
        /// </summary>
        /// <param name="lintAdvertisementID"></param>
         public void DeleteAdvertisement(int lintAdvertisementID)
         {
             string lstrQuery = "EXEC sp_DeleteAdvertisement @AdvertisementID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@AdvertisementID", lintAdvertisementID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion DeleteAdvertisement

        #region GetAdvertisementDetails
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:092314
        /// Function used to get advertisement details for editing.
        /// </summary>
        /// <param name="lintAdvertisementID"></param>
        /// <returns></returns>
         public DataSet GetAdvertisementDetails(int lintAdvertisementID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetAdvertisementDetails @AdvertisementID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@AdvertisementID", lintAdvertisementID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetAdvertisementDetails

        #region FillStateCombo
        /// <summary>
        /// Author:Jasmeet kaur
        /// date:092614
        /// Function used to fill state combo.
        /// </summary>
        /// <returns></returns>
         public DataSet FillStateCombo()
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_FillStateCombo";
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion FillStateCombo

        #region FillCitiesOfselectedCombo
         public DataSet FillCitiesOfselectedState(int lintStateID)
         {

             DataSet lobjDS = new DataSet();
             string lstrQuery = "Exec sp_FillCitiesOfselectedState @StateID";
             Hashtable objHash = new Hashtable();
             objHash.Add("@StateID", lintStateID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, objHash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
            
         }
         #endregion FillCitiesOfselectedCombo

         #region ShowAdvertisements
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:093014
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <param name="mdblCityID"></param>
        /// <returns></returns>
         public DataSet ShowAdvertisements(double mdblCityID)
         {
             DataSet lobjds = new DataSet();
             try
             {
                 string lstrQuery = "";

                 Hashtable lobjhash = new Hashtable();

                 lstrQuery = "EXEC Sp_ShowAdvertisements @CityID";

                lobjhash.Add("@CityID", mdblCityID);

                 lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }
             return lobjds;
         }

         #endregion ShowAdvertisements
       
         #region UpdateAdvertisementCount
         public string UpdateAdvertisementCount(double mdblUserID, int AdvertisementID)
         {
             string lstrres = "";
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             string lstrQuery = "EXEC sp_UpdateAdvertisementCount @UserID,@AdvertisementID";
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@AdvertisementID", AdvertisementID);

             try
             {
                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
                 if (lobjres != null)
                     lstrres = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lstrres;
         }

         #endregion UpdateAdvertisementCount

         #region AddRssfeed
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:100814
        /// Function used to add rss feed.
        /// </summary>
        /// <param name="lstrTitle"></param>
        /// <param name="lstrURL"></param>
        /// <param name="lintRssFeedID"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
         public string AddRssfeed(string lstrTitle, string lstrURL, int lintRssFeedID, double mdblUserID, bool lbnIsPublic)
         {
             string lstrResult = "";
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             try
             {
                 string lstrQuery = "EXEC sp_AddRssfeed @Title,@URL,@RssFeedID,@UserID,@IsPublic";
                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@URL", lstrURL);
                 lobjHash.Add("@RssFeedID", lintRssFeedID);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@IsPublic", lbnIsPublic);

                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lstrResult;
         }

         #endregion AddRssfeed

         #region GetRssFeedTitleList
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:100814
        /// Function Used to get list of Rss Feed title
        /// </summary>
        /// <returns></returns>
         public DataSet GetRssFeedTitleList(double mdblUserID, string mstrIsAdmin)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetRssFeedTitleList @UserID,@IsAdmin";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@IsAdmin", mstrIsAdmin);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetRssFeedTitleList

         #region GetRssFeedList
        
         
         public DataSet GetRssFeedList(double mdblUserID, string mstrIsAdmin)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetRssFeedTitleList @UserID,@IsAdmin";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@IsAdmin", mstrIsAdmin);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetRssFeedList


         #region DeleteRssFeed
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:100814
        /// Function used to delete rss Feed
        /// </summary>
        /// <param name="lintRssFeedID"></param>
         public void DeleteRssFeed(int lintRssFeedID)
         {
             string lstrQuery = "EXEC sp_DeleteRssFeed @RssFeedID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@RssFeedID", lintRssFeedID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }
         #endregion DeleteRssFeed

         #region GetRssFeedDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:101014
        /// Function used to get Rss Feed Details for editing.
        /// </summary>
        /// <param name="lintRssFeedID"></param>
        /// <returns></returns>
         public DataSet GetRssFeedDetails(int lintRssFeedID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetRssFeedDetails @RssFeedID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@RssFeedID", lintRssFeedID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetRssFeedDetails

         #region GetUsersRssFeedDetails
         public DataSet GetUsersRssFeedDetails(int lintRssUserID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetUsersRssFeedDetails @RssUserID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@RssUserID", lintRssUserID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }
         #endregion GetUsersRssFeedDetails

         #region LikeTopic
        /// <summary>
        /// Author:Jasmeet kaur
        /// date:101314
        /// Function used to like topic.
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <param name="lintTopicID"></param>
         public string LikeTopic(double mdblUserID, int lintTopicID)
         {
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();
             string lstrResult = "";
             string lstrQuery = "EXEC sp_LikeTopic @UserID,@TopicID";
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@TopicID", lintTopicID);

             try
             {
                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             return lstrResult;
         }

         #endregion LikeTopic

         #region UnlikeTopic
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:101414
        /// Function used to unlike topic.
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <param name="lintTopicID"></param>
         public void UnlikeTopic(double mdblUserID, int lintTopicID)
         {
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             string lstrQuery = "EXEC sp_UnlikeTopic @UserID,@TopicID";
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@TopicID", lintTopicID);
           
             try
             {
                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         #endregion UnlikeTopic

         #region AddTopicNotification
         public void AddTopicNotification(int lintNotificationID, double mdblUserID)
         {
             string lstrQuery = "EXEC sp_AddTopicNotification @NotificationID,@UserID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@NotificationID", lintNotificationID);
             lobjHash.Add("@UserID", mdblUserID);
             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion AddTopicNotification

         #region ForgotPassword
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:110314
        /// Function used for forgot password.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lstrRandomCode"></param>
        /// <returns></returns>
         public DataSet ForgotPassword(string pstrEmail, string lstrRandomCode)
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_ForgotPassword @Email,@RandomNumber";
             Hashtable objHash = new Hashtable();
             objHash.Add("@Email", pstrEmail);
             objHash.Add("@RandomNumber", lstrRandomCode);
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, objHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion ForgotPassword

         #region ValidateRandomCode

         public int ValidateRandomCode(string RandomCode, int RequestUserID)
         {
             Int32 lintUserID = -1;
             object obj = new object();
             string lstrQuery = "Exec sp_ValidateRandomCode @RandomCode,@RequestUserID";
             Hashtable objHash = new Hashtable();
             objHash.Add("@RandomCode", RandomCode);
             objHash.Add("@RequestUserID", RequestUserID);
             try
             {
                 obj = mobjDataAccess.SQLExecuteScalar(lstrQuery, objHash, false);

                 if (obj != null)
                     lintUserID = Convert.ToInt32(obj);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lintUserID;
         }
         #endregion ValidateRandomCode

         #region ResetPassword
         public bool ResetPassword(string lstrNewPass, int lintUserID)
         {
             bool lblnResp = false;
             object objResp = new object();
             Hashtable lobjHashTable = new Hashtable();

             string lstrSqlQuery = "EXEC sp_ResetPassword @NewPass, @UserID";

             lobjHashTable.Add("@NewPass", lstrNewPass);

             lobjHashTable.Add("@UserID", lintUserID);

             try
             {
                 objResp = mobjDataAccess.SQLExecuteScalar(lstrSqlQuery, lobjHashTable, true);

                 if (objResp != null)
                     lblnResp = Convert.ToBoolean(objResp);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }


             return lblnResp;
         }
         #endregion ResetPassword

         #region ShareTopic
         public string ShareTopic(double mdblUserID, int lintTopicID)
         {
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();
             string lstrResult = "";
             string lstrQuery = "EXEC sp_ShareTopic @UserID,@TopicID";
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@TopicID", lintTopicID);

             try
             {
                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             return lstrResult;
         }

         #endregion ShareTopic

         #region PostVideo

         public string PostVideo(string lstrComments, int lintTopicID, int lintCategoryID, double mdblUserID, bool lblIsUrl, string lstrYouTubeUrl)
         {
             string lstrResult = "";
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             try
             {
                 string lstrQuery = "EXEC sp_PostVideo @Content,@TopicID,@CategoryID,@UserID,@IsUrl,@YoutubeUrl";
                 lobjHash.Add("@Content", lstrComments);
                 lobjHash.Add("@TopicID", lintTopicID);
                 lobjHash.Add("@CategoryID", lintCategoryID);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@IsUrl", lblIsUrl);
                 lobjHash.Add("@YoutubeUrl", lstrYouTubeUrl);


                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lstrResult;
         }

         #endregion PostVideo

         #region AddNewAdvertisementZone
         /// <summary>
         /// #Param bajwa- function to add advertisement zone.
         /// </summary>
         /// <param name="pstrTitle"></param>
         /// <param name="pstrDescription"></param>
         /// <param name="lintAdvertisementId"></param>
         public Int32 AddNewAdvertisementZone(string lstrTitle, string lstrDescription, bool lbnIsOpen)
         {
           
             Int32 lintAdvertisementZoneID = -1;

             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 object lobj = new object();

                 lstrQuery = "EXEC sp_AddNewAdvertisementZone @Title,@Description,@IsOpen";

                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@Description", lstrDescription);
                 lobjHash.Add("@IsOpen", lbnIsOpen);

                 lobj = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, false);

                 if (lobj != null)
                     lintAdvertisementZoneID = Convert.ToInt32(lobj);

                 // mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception("Failure: Error while updating details" + ex.Message);
             }

             return lintAdvertisementZoneID;
         }

         #endregion AddNewAdvertisement

         #region AddZoneCities
         /// <summary>
         /// #param bajwa- add cities entries correspondiong to advertisment zone.
         /// </summary>
         /// <param name="pstrTitle"></param>
         /// <param name="pstrDescription"></param>
         /// <param name="pintAdvertisementZoneID"></param>
         public void AddZoneCities(int pintAdvertisementZoneID, int pintCityID)
         {

             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 object lobj = new object();

                 lstrQuery = "EXEC sp_AddZoneCities @CityID,@AdvertisementZoneID";

                 lobjHash.Add("@CityID", pintCityID);
                 lobjHash.Add("@AdvertisementZoneID", pintAdvertisementZoneID);

                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         #endregion AddNewAdvertisement

         #region GetAdvertisementZoneListing
         /// <summary>
         /// Author:Jasmeet Kaur
         /// Date:092314
         /// Function used to get Advertisementlisting.
         /// </summary>
         /// <param name="ldblStartIndex"></param>
         /// <param name="ldblEndIndex"></param>
         /// <param name="lstrSortParameter"></param>
         /// <param name="lstrSortOrder"></param>
         /// <param name="lstrSearchColumn"></param>
         /// <param name="lstrSearchString"></param>
         /// <returns></returns>
         public DataSet GetAdvertisementZoneListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetAdvertisementZoneListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }

         #endregion GetAdvertisementListing

         #region GetAdvertisementZoneCities
         /// <summary>
         /// #param bajwa 120214- function get advertisement zone cities
         /// </summary>
         /// <param name="pintAdvertisementZoneID"></param>
         /// <returns></returns>
         public DataSet GetAdvertisementZoneCities(int pintAdvertisementZoneID)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetAdvertisementZoneCities @AdvertisementZoneID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@AdvertisementZoneID", pintAdvertisementZoneID);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }

         #endregion GetAdvertisementListing

         #region DeleteAdvertisementZone
         /// <summary>
         /// #param bajwa 120214- function to delete advertisement zone
         /// </summary>
         /// <param name="pintAdvertisementZoneID"></param>
         public void DeleteAdvertisementZone(int pintAdvertisementZoneID)
         {
             string lstrQuery = "EXEC sp_DeleteAdvertisementZone @AdvertisementZoneID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@AdvertisementZoneID", pintAdvertisementZoneID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion DeleteAdvertisement

         #region GetAdvertisementZoneDetails
         /// <summary>     
         /// Function used to get advertisement zone details for editing.
         /// </summary>
         /// <param name="lintAdvertisementID"></param>
         /// <returns></returns>
         public DataSet GetAdvertisementZoneDetails(int pintAdvertisementZoneID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetAdvertisementZoneDetails @AdvertisementZoneID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@AdvertisementZoneID", pintAdvertisementZoneID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetAdvertisementDetails

         #region UpdateAdvertisementZone
         /// <summary>
         /// #Param bajwa- function to Update Advertisement Zone.
         /// </summary>
         /// <param name="pstrTitle"></param>
         /// <param name="pstrDescription"></param>
         /// <param name="lintAdvertisementId"></param>
         public void UpdateAdvertisementZone(string lstrTitle, string lstrDescription, int lintAdvertisementZoneID, bool lbnIsOpen)
         {
             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 object lobj = new object();

                 lstrQuery = "EXEC sp_UpdateAdvertisementZone @Title,@Description,@AdvertisementZoneID,@IsOpen";

                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@Description", lstrDescription);
                 lobjHash.Add("@AdvertisementZoneID", lintAdvertisementZoneID);
                 lobjHash.Add("@IsOpen", lbnIsOpen);
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception("Failure: Error while updating details" + ex.Message);
             }

         }

         #endregion AddNewAdvertisement

         #region FillZoneCombo
        /// <summary>
        /// Author:Jasmeet kaur
        /// date:120314
        /// function used to fill zone combo.
        /// </summary>
        /// <returns></returns>
         public DataSet FillZoneCombo()
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_FillZoneCombo";
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion FillZoneCombo

         #region GetExpertsListing
         /// <summary>
        /// Author:jasmeet Kaur
        /// Date:120514
        /// Function used to get experts listing
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <returns></returns>
         public DataSet GetExpertsListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetExpertsListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }

         #endregion GetExpertsListing

         #region AddEditChapter
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:121914
        /// Function used to add/edit chapters.
        /// </summary>
        /// <param name="lintChapterID"></param>
        /// <param name="lstrTitle"></param>
        /// <param name="lstrDescription"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
         public string AddEditChapter(int lintChapterID, string lstrTitle, string lstrDescription, double mdblUserID)
         {
             string lstrResult = "";
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();

             try
             {
                 string lstrQuery = "EXEC sp_AddEditChapter @ChapterID,@Title,@Description,@UserID";

                 lobjHash.Add("@ChapterID", lintChapterID);
                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@Description", lstrDescription);
                 lobjHash.Add("@UserID", mdblUserID);

                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lstrResult;
         }
         #endregion AddEditChapter

         #region GetChaptersListing
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:121914
        /// function used to get chapter listing.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <returns></returns>
         public DataSet GetChaptersListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, double mdblUserID)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetChaptersListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString, @UserID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);
             lobjHash.Add("@UserID", mdblUserID);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }
         #endregion GetChaptersListing

         #region DeleteChapters
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:121914
        /// Function used to delete chapters.
        /// </summary>
        /// <param name="lintChapterID"></param>
         public void DeleteChapters(int lintChapterID)
         {
             string lstrQuery = "EXEC sp_DeleteChapter @ChapterID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@ChapterID", lintChapterID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion DeleteChapters

         #region GetChapterDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:121914
        /// Function used to get chapter details.
        /// </summary>
        /// <param name="lintChapterID"></param>
        /// <returns></returns>
         public DataSet GetChapterDetails(int lintChapterID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetChapterDetails @ChapterID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@ChapterID", lintChapterID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }
         #endregion GetChapterDetails

         #region AddEditSubTitles

         public string AddEditSubTitles(string lstrTitle, string lstrDescription, string lstrDocument, string lstrYoutubeUrl, string lstrUrlLink, int lintChapterID, int lintSubTitleID, double mdblUserID, bool lbnIsPaid)
         {
             string lstrResult = "";
             object lobjres = new object();
             Hashtable lobjHash = new Hashtable();
             string lstrQuery = "";
             try
             {
                

                 lstrQuery = "EXEC sp_AddEditSubTitles @Title,@Description,@Document,@YoutubeURL,@URL,@CategoryID,@SubTitleID,@UserID,@IsPaid";

                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@Description", lstrDescription);
                 lobjHash.Add("@Document", lstrDocument);
                 lobjHash.Add("@YoutubeURL", lstrYoutubeUrl);
                 lobjHash.Add("@URL", lstrUrlLink);
                 lobjHash.Add("@CategoryID", lintChapterID);
                 lobjHash.Add("@SubTitleID", lintSubTitleID);
                 lobjHash.Add("@UserID", mdblUserID);
                 lobjHash.Add("@IsPaid", lbnIsPaid);
                 lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

                 if (lobjres != null)
                     lstrResult = lobjres.ToString();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lstrResult;
         }
         #endregion AddEditSubTitles

         #region GetCourseName
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:122214
        /// Function used to get course name for heading in sub title listing.
        /// </summary>
        /// <param name="lintChapterID"></param>
        /// <returns></returns>
         public DataSet GetCourseName(int lintChapterID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetCourseName @ChapterID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@ChapterID", lintChapterID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetCourseName
                                                                                                                                                                                                                                                                                               
         #region GetCourseSubTitlesListing
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:122214
        /// Function used to get listing of sub-titles of selected courses.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <param name="mdblUserID"></param>
        /// <param name="lintChapterID"></param>
        /// <returns></returns>
         public DataSet GetCourseSubTitlesListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, double mdblUserID, int lintChapterID)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_GetCourseSubTitleListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString, @UserID, @ChapterID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);
             lobjHash.Add("@UserID", mdblUserID);
             lobjHash.Add("@ChapterID", lintChapterID);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception)
             {
                 throw;
             }

             return ds;
         }

         #endregion GetCourseSubTitlesListing

         #region GetSubTitleDetails

         public DataSet GetSubTitleDetails(int lintSubTitleID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetSubTitleDetails @SubTitleID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@SubTitleID", lintSubTitleID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetSubTitleDetails

         #region DeleteSubTitle
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:122314
        /// Function used to delete sub-titles.
        /// </summary>
        /// <param name="lintSubTitleID"></param>
         public void DeleteSubTitle(int lintSubTitleID)
         {
             string lstrQuery = "EXEC sp_DeleteSubTitle @SubTitleID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@SubTitleID", lintSubTitleID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion DeleteSubTitle

         #region GetAllCourses
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:010115
        /// function used to get all courses.
        /// </summary>
        /// <returns></returns>
         public DataSet GetAllCourses()
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_GetAllCourses";
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetAllCourses

         #region GetAllLessons
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:010514
        /// Function used to get all lessons.
        /// </summary>
        /// <param name="lintChapterID"></param>
        /// <returns></returns>
         public DataSet GetAllLessons(int lintChapterID)
         {
             DataSet lobjDS = null;
             string lstrQuery = "EXEC sp_GetAllLessons @ChapterID";
             Hashtable lobjHash = new Hashtable();

             lobjHash.Add("@ChapterID", lintChapterID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion GetAllLessons

         #region FillStatusCombo
         /// <summary>
         /// Author:Jasmeet Kaur
         /// Date:020915
         /// Function used to fill status combo.
         /// </summary>
         /// <returns></returns>
         public DataSet FillStatusCombo()
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_FillStatusCombo";
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion FillStatusCombo

         #region FillStateOfSelectedCity

         public DataSet FillStateOfSelectedCity(int lintCityID)
         {

             DataSet lobjDS = new DataSet();
             string lstrQuery = "Exec sp_FillStateOfSelectedCity @CityID";
             Hashtable objHash = new Hashtable();
             objHash.Add("@CityID", lintCityID);
             try
             {

                 lobjDS = mobjDataAccess.GetDataSet(lstrQuery, objHash, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

             return lobjDS;
         }

         #endregion FillStateOfSelectedCity

         #region DeleteSelectedPost
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:041415
        /// Function used to delete selected posts.
        /// </summary>
        /// <param name="lintUserID"></param>
        /// <param name="lintPostID"></param>
         public void DeleteSelectedPost(int lintUserID, int lintPostID)
         {
             string lstrQuery = "EXEC sp_DeleteSelectedPost @UserID,@PostID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@UserID", lintUserID);
             lobjHash.Add("@PostID", lintPostID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion DeleteSelectedPost

         #region DeletePostComments
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:041415
        /// Function used to delete post comments.
        /// </summary>
        /// <param name="lintUserID"></param>
        /// <param name="lintPostCommentID"></param>
         public void DeletePostComments(int lintUserID, int lintPostCommentID)
         {
             string lstrQuery = "EXEC sp_DeleteSelectedPostComment @UserID,@PostCommentID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@UserID", lintUserID);
             lobjHash.Add("@PostCommentID", lintPostCommentID);

             try
             {
                 mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
             }
             catch (Exception)
             {
                 throw;
             }
         }

         #endregion DeletePostComments

         /// Corporate Related Task
         #region RegisterCorporate
         public void RegisterCorporate()
         {
             DataSet lobjDS = null;
             Hashtable lobjHashTable = new Hashtable();
             string lstrSqlQuery = "EXEC sp_CompanyCreate @EmailID, @Password, @FirstName, @LastName, @CompName, @IsNewsLetterSubscribed";
             lobjHashTable.Add("@EmailID", mstrEmailID);
             lobjHashTable.Add("@Password", mstrPassword);
             if (FirstName == null)
                 lobjHashTable.Add("@FirstName", "");
             else
                 lobjHashTable.Add("@FirstName", FirstName);
             if (LastName == null)
                 lobjHashTable.Add("@LastName", "");
             else
                 lobjHashTable.Add("@LastName", LastName);
             if (CompName == null)
                 lobjHashTable.Add("@CompName", "Company Name");
             else
                 lobjHashTable.Add("@CompName", CompName);

             lobjHashTable.Add("@IsNewsLetterSubscribed", IsNewsLetterSubscribed);
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjHashTable, true);

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             if (lobjDS != null)
             {
                 if (lobjDS.Tables[0].Rows[0]["UserID"].ToString() != "")
                 {
                     mdblUserID = Convert.ToDouble(lobjDS.Tables[0].Rows[0]["UserID"]);
                 }

                 if (lobjDS.Tables[0].Rows[0]["Status"].ToString() != "")
                 {
                     Status = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["Status"]);
                 }

                 if (lobjDS.Tables[0].Rows[0]["EmailAlreadyExists"].ToString() != "")
                 {
                     EmailAlreadyExists = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["EmailAlreadyExists"]);
                 }

                 if (lobjDS.Tables[0].Rows[0]["OccupationID"].ToString() != "")
                 {
                     OccupationID = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["OccupationID"]);

                 }

                 if (lobjDS.Tables[0].Rows[0]["IsComp"].ToString() != "")
                 {
                     IsComp = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsComp"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["IsCompAdmin"].ToString() != "")
                 {
                     IsCompAdmin = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsCompAdmin"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["OfCompID"].ToString() != "")
                 {
                     OfCompID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["OfCompID"]);

                 }


                 //if (lobjDS.Tables[0].Rows[0]["PlanActive"].ToString() != "")
                 //{
                 //    PlanActive = lobjDS.Tables[0].Rows[0]["PlanActive"].ToString();
                 //}


             }

         }
         #endregion RegisterCorporate

         #region CompanyUserAdd
         public void CompanyUserAdd()
         {
             DataSet lobjDS = null;
             Hashtable lobjHashTable = new Hashtable();
             string lstrSqlQuery = "EXEC sp_CompanyUserAdd @EmailID, @Password, @FirstName, @LastName, @OfCompID, @IsNewsLetterSubscribed";
             lobjHashTable.Add("@EmailID", mstrEmailID);
             lobjHashTable.Add("@Password", mstrPassword);
             if (FirstName == null)
                 lobjHashTable.Add("@FirstName", "");
             else
                 lobjHashTable.Add("@FirstName", FirstName);
             if (LastName == null)
                 lobjHashTable.Add("@LastName", "");
             else
                 lobjHashTable.Add("@LastName", LastName);
             if (OfCompID == null)
                 lobjHashTable.Add("@OfCompID", "0");
             else
                 lobjHashTable.Add("@OfCompID", OfCompID);

             lobjHashTable.Add("@IsNewsLetterSubscribed", IsNewsLetterSubscribed);
             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjHashTable, true);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             if (lobjDS != null)
             {

                 if (lobjDS.Tables[0].Rows[0]["EmailAlreadyExists"].ToString() != "")
                 {
                     EmailAlreadyExists = Convert.ToInt16(lobjDS.Tables[0].Rows[0]["EmailAlreadyExists"]);
                 }
             }

         }
         #endregion CompanyUserAdd

         #region CompanyGetUsersListing
         public DataSet CompanyGetUsersListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString,string lstrOfCompID)
         {
             DataSet ds = null;

             string lstrQuery = "EXEC sp_CompanyGetUsersListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString,@OfCompID";
             Hashtable lobjHash = new Hashtable();
             lobjHash.Add("@sidx", ldblStartIndex);
             lobjHash.Add("@eidx", ldblEndIndex);
             lobjHash.Add("@SortByColName", lstrSortParameter);
             lobjHash.Add("@SortOrder", lstrSortOrder);
             lobjHash.Add("@SearchColumn", lstrSearchColumn);
             lobjHash.Add("@SearchString", lstrSearchString);
             lobjHash.Add("@OfCompID", lstrOfCompID);

             try
             {
                 ds = mobjDataAccess.GetDataSet(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 throw;
             }

             return ds;
         }

         #endregion CompanyGetUsersListing


         #region get_Session
         /// <summary>
         /// function used to register new usersession
      
                     
         public void get_Session()
         {
             DataSet lobjDS = new DataSet();
             Hashtable lobjHashTable = new Hashtable();

             string lstrSqlQuery = "EXEC sp_get_Session @UserID";

             lobjHashTable.Add("@UserID", mdblUserID);
           

             try
             {
                 lobjDS = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjHashTable, false);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             if (lobjDS != null)
             {
                 if (lobjDS.Tables[0].Rows[0]["UserID"].ToString() != "")
                 {
                     mdblUserID = Convert.ToDouble(lobjDS.Tables[0].Rows[0]["UserID"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["IsAdmin"].ToString() != "")
                 {
                     IsAdmin = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsAdmin"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["Theme"].ToString() != "")
                 {
                     UserTheme = Convert.ToString(lobjDS.Tables[0].Rows[0]["Theme"]);

                 }

                 if (lobjDS.Tables[0].Rows[0]["CommunicateConsent"].ToString() != "")
                 {
                     mintCommConsent = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["CommunicateConsent"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["IsUserLoginDisabled"].ToString() != "")
                 {
                     IsUserLoginDisabled = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsUserLoginDisabled"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["IsApproved"].ToString() != "")
                 {
                     IsApproved = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsApproved"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["CityID"].ToString() != "")
                 {
                     mdblCityID = Convert.ToDouble(lobjDS.Tables[0].Rows[0]["CityID"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["UserTypeID"].ToString() != "")
                 {
                     UserTypeID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["UserTypeID"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["OccupationID"].ToString() != "")
                 {
                     OccupationID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["OccupationID"]);

                 }

                 if (lobjDS.Tables[0].Rows[0]["IsComp"].ToString() != "")
                 {
                     IsComp = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsComp"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["IsCompAdmin"].ToString() != "")
                 {
                     IsCompAdmin = Convert.ToBoolean(lobjDS.Tables[0].Rows[0]["IsCompAdmin"]);

                 }
                 if (lobjDS.Tables[0].Rows[0]["OfCompID"].ToString() != "")
                 {
                     OfCompID = Convert.ToInt32(lobjDS.Tables[0].Rows[0]["OfCompID"]);

                 }

                 if (lobjDS.Tables[0].Rows[0]["PlanActive"].ToString() != "")
                 {
                     PlanActive = lobjDS.Tables[0].Rows[0]["PlanActive"].ToString();
                 }


                 session_val = "NEW";
             }

         }
         #endregion get_Session



         #region UserSocialUpdatePassCheck
         public Int32 UserSocialUpdatePassCheck(Int32 user_id)
         {
             Int32 lintAdvertisementZoneID = -1;

             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 object lobj = new object();

                 lstrQuery = "EXEC sp_UserSocialUpdatePassCheck @user_id";

                 lobjHash.Add("@user_id", user_id);
                 

                 lobj = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, false);

                 if (lobj != null)
                     lintAdvertisementZoneID = Convert.ToInt32(lobj);

                 // mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {
                 
             }

             return lintAdvertisementZoneID;

         }


         #endregion UserSocialUpdatePassCheck

         #region UserSocialUpdatePass
         public Int32 UserSocialUpdatePass(Int32 user_id,string upass)
         {
             Int32 lintAdvertisementZoneID = -1;

             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 object lobj = new object();

                 lstrQuery = "EXEC sp_UserSocialUpdatePass @user_id,@upass";

                 lobjHash.Add("@user_id", user_id);
                 lobjHash.Add("@upass", upass);

                 lobj = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, false);

                 if (lobj != null)
                     lintAdvertisementZoneID = Convert.ToInt32(lobj);

                 // mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {

             }

             return lintAdvertisementZoneID;

         }


         #endregion UserSocialUpdatePass


        //Page PageAuthentication

        #region PageAuthenticationCheck

         public Int32 PageAuthenticationCheck(String PageUrl, int UserID)
         {
             Int32 lintAdvertisementZoneID = -1;

             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 object lobj = new object();

                 lstrQuery = "EXEC sp_PageAuthenticationCheck @PageUrl,@UserID";

                 lobjHash.Add("@PageUrl", PageUrl);
                 lobjHash.Add("@UserID", UserID);

                 lobj = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, false);

                 if (lobj != null)
                     lintAdvertisementZoneID = Convert.ToInt32(lobj);

                 // mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, false);
             }
             catch (Exception ex)
             {

             }

             return lintAdvertisementZoneID;
         }
        #endregion PageAuthenticationCheck

        #endregion

    }
}