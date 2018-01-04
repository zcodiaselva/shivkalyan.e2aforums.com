using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

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

        #endregion


        #region Functions

        #region RegisterUser
        /// <summary>
        /// function used to register new users
        /// </summary>
        /// <exclude>
        /// Author - Sahil Sharma
        /// Create Date - 040814
        /// </exclude>                
        public void RegisterUser()
        {
            DataSet lobjDS = null;
            Hashtable lobjHashTable = new Hashtable();

            string lstrSqlQuery = "EXEC sp_RegisterUser @EmailID, @Password, @FullName, @RegistrationTypeID, @IsNewsLetterSubscribed";

            lobjHashTable.Add("@EmailID", mstrEmailID);
            lobjHashTable.Add("@Password", mstrPassword);
            lobjHashTable.Add("@FullName", mstrFullName);
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
         /// <summary>
         /// Author:Jasmeet kaur
         /// Date:081414
         /// Function used to update user details.
         /// </summary>
         /// <param name="lstrName"></param>
         /// <param name="lintOccupationID"></param>
         /// <param name="lstrOrganization"></param>
         /// <param name="lstrAddress1"></param>
         /// <param name="lstrAddress2"></param>
         /// <param name="lstrAddress3"></param>
         /// <param name="lstrCity"></param>
         /// <param name="lstrDealerName"></param>
         /// <param name="lstrMgs"></param>
         /// <param name="lstrGoverningBody"></param>
         /// <param name="lstrInBusinessSince"></param>
         /// <param name="lstrPhone"></param>
         /// <param name="lintConsent"></param>
         /// <param name="mdblUserID"></param>
         /// <returns></returns>
         //public void UpdateUserDetails(string lstrName, int lintOccupationID, string lstrOtherOccupation, string lstrOrganization, string lstrAddress1, string lstrAddress2, string lstrAddress3, string lstrCity, string lstrDealerName, string lstrMgs, string lstrGoverningBody, string lstrInBusinessSince, string lstrPhone, string lstrImages, int lintConsent, double mdblUserID)
         //{
         public void UpdateUserDetails(string lstrName, int lintOccupationID, string lstrOtherOccupation, string lstrOrganization, string lstrAddress1, string lstrAddress2, string lstrAddress3, string lstrDealerName, string lstrMgs, string lstrGoverningBody, string lstrInBusinessSince, string lstrPhone, string lstrImages, int lintConsent, double mdblUserID, int lintStateID, int lintCityID)
         {
             DataSet lobjDS = new DataSet();
             Hashtable lobjHash = new Hashtable();

             string lstrQuery = "EXEC sp_UpdateUserDetails @Full_Name, @OccupationID,@OtherOccupation,@Organization,@Address_line1,@Address_Line2,@Address_Line3,@DealerName,@Mga,@GoverningBody,@InBusinessSince,@Mobile_Phone,@Picture,@CommunicateConsent,@UserID,@StateID,@CityID";

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

                 try
                 {
                     mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
                 }
                 catch (Exception ex)
                 {
                     throw new Exception(ex.Message);
                 }

         }

         #endregion UpdateUserDetails

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
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:082714
        /// Function used to get user listing
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Autor:jasmeet kaur
        /// Date:082714
        /// Function used to mark user disable foe login
        /// </summary>
        /// <param name="ldblUserID"></param>
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
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:jasmeet kaur
        /// Function used to get notifications
        /// </summary>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
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
         public void AddUserDetails(string lstrFirstName, string lstrLastname, string lstrOrg, string lstrAddress1, string lstrAddress2, string lstrAddress, string lstrMga, string lstrGovBody, string lstrSince, string lstrPhoneNo, double mdblUserID, int lintOccuID, string lstrOtherOccupation, int lintConsent, int lintStateID, int lintCityID)
         {
             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 lstrQuery = "EXEC Sp_AddUserDetails  @FirstName,@Lastname,@Org,@Address1,@Address2,@Address,@Mga,@GovBody,@Since,@PhoneNo,@UserID, @OccuID, @OtherOccupation, @Consent, @StateID, @CityID";

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

        #region ForgotPassword
         public DataSet ForgotPassword(string pstrEmail)
         {
             DataSet lobjDS = null;
             string lstrQuery = "Exec sp_ForgotPassword @Email";
             Hashtable objHash = new Hashtable();
             objHash.Add("@Email", pstrEmail);
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
         public void AddNewAdvertisement(string lstrTitle, string lstrImages, string lstrClickUrl, string lstrFromDate, string lstrToDate, string lstrFromTime, string lstrToTime, int lintImageSizeID, int lintStateID, int lintCityID, double mdblUserID, int lintAdvertisementId)
         {
             try
             {
                 Hashtable lobjHash = new Hashtable();
                 string lstrQuery = "";

                 lstrQuery = "EXEC sp_AddNewAdvertisement @Title,@ImageName,@ClickUrl,@FromDateTime,@ToDateTime,@FromTime,@ToTime,@ImageSizeID,@StateID,@CityID,@UserID,@AdvertisementID";

                 lobjHash.Add("@Title", lstrTitle);
                 lobjHash.Add("@ImageName", lstrImages);
                 lobjHash.Add("@ClickUrl", lstrClickUrl);
                 lobjHash.Add("@FromDateTime", lstrFromDate);
                 lobjHash.Add("@ToDateTime", lstrToDate);
                 lobjHash.Add("@FromTime", lstrFromTime);
                 lobjHash.Add("@ToTime", lstrToTime);
                 lobjHash.Add("@ImageSizeID", lintImageSizeID);
                 lobjHash.Add("@StateID", lintStateID);
                 lobjHash.Add("@CityID", lintCityID);
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

         //#region GetAdvertisementViewersCount

         //public void GetAdvertisementViewersCount(double mdblUserID, int lintAdvertisementID)
         //{
         //    object lobjres = new object();
         //    Hashtable lobjHash = new Hashtable();

         //    string lstrQuery = "EXEC sp_GetAdvertisementViewersCount @UserID,@AdvertisementID";
         //    lobjHash.Add("@UserID", mdblUserID);
         //    lobjHash.Add("@AdvertisementID", lintAdvertisementID);

         //    try
         //    {
         //        lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
         //    }
         //    catch (Exception ex)
         //    {
         //        throw new Exception(ex.Message);
         //    }

         //}

         //#endregion GetAdvertisementViewersCount

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

        #endregion








       
             
    }
}