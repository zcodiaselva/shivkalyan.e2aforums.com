using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace E2aForums
{
    public class CCustomers
    {
        #region Class Object Declaration

        DataAccess mobjDataAccess = new DataAccess();

        #endregion Class Object Declaration

        #region Constructor

        //#A Jasmeet: 020915 - Setting the connection string of DataAccess class in constructor
        public CCustomers(string ConnectionString)
        {
            mobjDataAccess.ConnectionString = ConnectionString;
            //IsNewsLetterSubscribed = false;
        }
        #endregion Constructor

        #region Properties
        public double CustomerID { get; set; }

        #endregion Properties

        #region functions

        #region SaveCustomerDetails
        /// <summary>
        /// Author:Jasmeet Kaur
        /// Date:020915
        /// Function used to add new customer by user.
        /// </summary>
        /// <param name="lstrName"></param>
        /// <param name="lstrEmail"></param>
        /// <param name="lstrAddress1"></param>
        /// <param name="lstrAddress2"></param>
        /// <param name="lstrPhone"></param>
        /// <param name="lstrImages"></param>
        /// <param name="lintStatusID"></param>
        /// <param name="lintStateID"></param>
        /// <param name="lintCityID"></param>
        /// <param name="mdblUserID"></param>
        //public string SaveCustomerDetails(string lstrName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, double mdblUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID)
        //{
        //public string SaveCustomerDetails(string lstrName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, double mdblUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID, string lstrDOBDatePart, string lstrAniversaryDatePart)
        //{
        //public string SaveCustomerDetails(string lstrName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, double mdblUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID, string lstrDOBDatePart, string lstrAniversaryDatePart, string lstrOfficeEmailID, string lstrOfficeAddress1, string lstrOfficeAddress2, string lstrMobile, string lstrHomeFax, string lstrOfficeFax, string lstrExtensionField, string lstrPostalCode)
        //{
        //public string SaveCustomerDetails(string lstrName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, double mdblUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID, string lstrDOBDatePart, string lstrAniversaryDatePart, string lstrOfficeEmailID, string lstrOfficeAddress1, string lstrOfficeAddress2, string lstrMobile, string lstrHomeFax, string lstrOfficeFax, string lstrExtensionField, string lstrPostalCode, int lintOfcCityID, int lintOfcStateID, string lstrOfcTelephone, string lstrWork)
        //{
        public string SaveCustomerDetails(string lstrTitle, string lstrFirstName, string lstrLastName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, double mdblUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID, string lstrDOBDatePart, string lstrAniversaryDatePart, string lstrOfficeEmailID, string lstrOfficeAddress1, string lstrOfficeAddress2, string lstrMobile, string lstrHomeFax, string lstrOfficeFax, string lstrExtensionField, string lstrPostalCode, int lintOfcCityID, int lintOfcStateID, string lstrOfcTelephone, string lstrWork, int lintMaritalStatus, int lintDependents, int lintBestCallTime, string lstrReferredBy, int lintColdLead, string lstrFirstContact, string lstrNextContact, string lstrDiscussed)
        {
           string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();
            string lstrQuery = "EXEC sp_SaveCustomerDetails @Title,@FirstName,@LastName, @Email,@Address1,@Address2,@Phone,@Image,@StatusID,@StateID,@CityID,@UserID,@DateOfBirth,@Anniversary,@CustomerID,@DOBDatePart,@AnniDatePart,@OfficeEmailID,@OfficeAddress1,@OfficeAddress2,@Mobile,@HomeFax,@OfficeFax,@ExtensionField,@PostalCode,@OfcCityID,@OfcStateID,@Telephone,@Work,@Maritalstatus,@Dependents,@BestCallTime,@ReferredBy,@ColdLead,@FirstContact,@NextContact,@Discussed";
            lobjHash.Add("@Title", lstrTitle);
            lobjHash.Add("@FirstName", lstrFirstName);
            lobjHash.Add("@LastName", lstrLastName);
            lobjHash.Add("@Email", lstrEmail);
            lobjHash.Add("@Address1", lstrAddress1);
            lobjHash.Add("@Address2", lstrAddress2);
            lobjHash.Add("@Phone", lstrPhone);
            lobjHash.Add("@Image", lstrImages);
            lobjHash.Add("@StatusID", lintStatusID);
            lobjHash.Add("@StateID", lintStateID);
            lobjHash.Add("@CityID", lintCityID);
            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@DateOfBirth", Convert.ToDateTime(lstrDOB));
            lobjHash.Add("@Anniversary", lstrAnniversary);
            lobjHash.Add("@CustomerID", lintCustomerID);
            lobjHash.Add("@DOBDatePart", lstrDOBDatePart);
            lobjHash.Add("@AnniDatePart", lstrAniversaryDatePart);
            lobjHash.Add("@OfficeEmailID", lstrOfficeEmailID);
            lobjHash.Add("@OfficeAddress1", lstrOfficeAddress1);
            lobjHash.Add("@OfficeAddress2", lstrOfficeAddress2);
            lobjHash.Add("@Mobile", lstrMobile);
            lobjHash.Add("@HomeFax", lstrHomeFax);
            lobjHash.Add("@OfficeFax", lstrOfficeFax);
            lobjHash.Add("@ExtensionField", lstrExtensionField);
            lobjHash.Add("@PostalCode", lstrPostalCode);
            lobjHash.Add("@OfcCityID", lintOfcCityID);
            lobjHash.Add("@OfcStateID", lintOfcStateID);
            lobjHash.Add("@Telephone", lstrOfcTelephone);
            lobjHash.Add("@Work", lstrWork);
            lobjHash.Add("@Maritalstatus", lintMaritalStatus);
            lobjHash.Add("@Dependents", lintDependents);
            lobjHash.Add("@BestCallTime", lintBestCallTime);
            lobjHash.Add("@ReferredBy", lstrReferredBy);
            lobjHash.Add("@ColdLead", lintColdLead);

            if (lstrFirstContact == "")
            {
                lobjHash.Add("@FirstContact", DateTime.Now);
            }
            else
            {
                lobjHash.Add("@FirstContact", lstrFirstContact);
            }

             
            lobjHash.Add("@NextContact", lstrNextContact);
            lobjHash.Add("@Discussed", lstrDiscussed);
           
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

        #endregion SaveCustomerDetails

        #region GetCustomerListing
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021015
        /// Function used to get customer listing.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
        public DataSet GetCustomerListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, double mdblUserID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetCustomersListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString, @UserID";
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

        #endregion GetCustomerListing

        #region DeleteCustomer
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021115
        /// Function used to delete customer.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        public void DeleteCustomer(int lintCustomerID)
        {
            string lstrQuery = "EXEC sp_DeleteCustomer @CustomerID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@CustomerID", lintCustomerID);

            try
            {
                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion DeleteCustomer

        #region GetCustomerDetails
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021115
        /// Function used to get customer details.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        /// <returns></returns>
        public DataSet GetCustomerDetails(int lintCustomerID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetCustomerDetails @CustomerID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@CustomerID", lintCustomerID);
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

        #endregion GetCustomerDetails

        #region FillCustomerCombo

        public DataSet FillCustomerCombo(double mdblUserID, int lintCustomerID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "Exec sp_FillCustomerCombo @UserID,@CustomerID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@CustomerID", lintCustomerID);
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

        #endregion FillCustomerCombo

        #region SaveCustomerAsFollowUp
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021215
        /// Function used to save customer for follow up.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        /// <param name="lstrFollowUpText"></param>
        /// <param name="lstrFollowUpDate"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
        //public string SaveCustomerAsFollowUp(int lintCustomerID, string lstrFollowUpText, string lstrFollowUpDate, double mdblUserID)
        //{
        public string SaveCustomerAsFollowUp(int lintCustomerID, string lstrFollowUpText, string lstrFollowUpDesc, string lstrFollowUpDate, double mdblUserID, string lstrStartTime, string lstrEndTime, int lintStateID, int lintCityID, string lstrVenue)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_SaveCustomerAsFollowUp @CustomerID, @FollowUpText,@Description,@FollowUpDateAndTime,@StartTime,@EndTime,@UserID, @StateID, @CityID, @Venue";

            lobjHash.Add("@CustomerID", lintCustomerID);
            lobjHash.Add("@FollowUpText", lstrFollowUpText);
            lobjHash.Add("@Description", lstrFollowUpDesc);
            lobjHash.Add("@FollowUpDateAndTime", lstrFollowUpDate);
            lobjHash.Add("@StartTime", lstrStartTime);
            lobjHash.Add("@EndTime", lstrEndTime);
            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@StateID", lintStateID);
            lobjHash.Add("@CityID", lintCityID);
            lobjHash.Add("@Venue", lstrVenue);

            try
            {
                
                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstrResult;
        }

        #endregion SaveCustomerAsFollowUp

        #region SaveUserDocuments
        /// <summary>
        /// Author:Jasmeet kaur
        /// DAte:021315
        /// Function used to save user's documents.
        /// </summary>
        /// <param name="lstrDescription"></param>
        /// <param name="lstrDocument"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
        public string SaveUserDocuments(string lstrDescription, string lstrDocument, double mdblUserID, int lintDocID)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_SaveUserDocuments @Description,@Document,@UserID,@DocID";

            lobjHash.Add("@Description", lstrDescription);
            lobjHash.Add("@Document", lstrDocument);
            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@DocID", lintDocID);
            try
            {

                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstrResult;
        }

        #endregion SaveUserDocuments
        
        #region GetUserDocListing
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021315
        /// Function used to get user's document list.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <param name="lintUserID"></param>
        /// <returns></returns>
        public DataSet GetUserDocListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, int lintUserID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetUserDocListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString, @UserID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@sidx", ldblStartIndex);
            lobjHash.Add("@eidx", ldblEndIndex);
            lobjHash.Add("@SortByColName", lstrSortParameter);
            lobjHash.Add("@SortOrder", lstrSortOrder);
            lobjHash.Add("@SearchColumn", lstrSearchColumn);
            lobjHash.Add("@SearchString", lstrSearchString);
            lobjHash.Add("@UserID", lintUserID);

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

        #endregion GetUserDocListing

        #region DeleteDocument
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021315
        /// Function used to delete document.
        /// </summary>
        /// <param name="lintDocID"></param>
        public void DeleteDocument(int lintDocID)
        {
            string lstrQuery = "EXEC sp_DeleteDocument @DocID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@DocID", lintDocID);

            try
            {
                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion DeleteDocument

        #region GetDocumentDetails
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021315
        /// Function used to get document details.
        /// </summary>
        /// <param name="lintDocID"></param>
        /// <returns></returns>
        public DataSet GetDocumentDetails(int lintDocID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetDocumentDetails @DocID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@DocID", lintDocID);
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

        #endregion GetDocumentDetails

        #region AddNewProducts
        /// <summary>
        /// Author:Jasmeet kaur
        /// dtae:021815
        /// Function used ro add new product.
        /// </summary>
        /// <param name="lstrTitle"></param>
        /// <param name="lstrDescription"></param>
        /// <param name="lstrStartDate"></param>
        /// <param name="lstrLastDate"></param>
        /// <param name="lintProductID"></param>
        /// <param name="mdblUserID"></param>
        /// <returns></returns>
        public string AddNewProducts(string lstrTitle, string lstrDescription, string lstrStartDate, string lstrLastDate, int lintProductID, double mdblUserID)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_AddNewProducts @Title, @Desc,@StartDate,@LastDate,@ProductID,@UserID";

            lobjHash.Add("@Title", lstrTitle);
            lobjHash.Add("@Desc", lstrDescription);
            lobjHash.Add("@StartDate", lstrStartDate);
            lobjHash.Add("@LastDate", lstrLastDate);
            lobjHash.Add("@ProductID", lintProductID);
            lobjHash.Add("@UserID", mdblUserID);
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

        #endregion AddNewProducts

        #region GetProductListing
        /// <summary>
        /// Author:Jasmeet kaur
        /// Dtae:021815
        /// Function used to get product listing.
        /// </summary>
        /// <param name="ldblStartIndex"></param>
        /// <param name="ldblEndIndex"></param>
        /// <param name="lstrSortParameter"></param>
        /// <param name="lstrSortOrder"></param>
        /// <param name="lstrSearchColumn"></param>
        /// <param name="lstrSearchString"></param>
        /// <param name="lintUserID"></param>
        /// <returns></returns>
        public DataSet GetProductListing(double ldblStartIndex, double ldblEndIndex, string lstrSortParameter, string lstrSortOrder, string lstrSearchColumn, string lstrSearchString, int lintUserID)
        {
            DataSet ds = null;

            string lstrQuery = "EXEC sp_GetProductListing @sidx, @eidx, @SortByColName, @SortOrder, @SearchColumn, @SearchString, @UserID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@sidx", ldblStartIndex);
            lobjHash.Add("@eidx", ldblEndIndex);
            lobjHash.Add("@SortByColName", lstrSortParameter);
            lobjHash.Add("@SortOrder", lstrSortOrder);
            lobjHash.Add("@SearchColumn", lstrSearchColumn);
            lobjHash.Add("@SearchString", lstrSearchString);
            lobjHash.Add("@UserID", lintUserID);

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

        #endregion GetProductListing

        #region DeleteProduct
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021815
        /// Function used to delete product.
        /// </summary>
        /// <param name="lintProductID"></param>
        public void DeleteProduct(int lintProductID)
        {
            string lstrQuery = "EXEC sp_DeleteProduct @ProductID";
            Hashtable lobjHash = new Hashtable();
            lobjHash.Add("@ProductID", lintProductID);

            try
            {
                mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion DeleteProduct

        #region GetProductDetails
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021815
        /// Function used to get product details.
        /// </summary>
        /// <param name="lintProductID"></param>
        /// <returns></returns>
        public DataSet GetProductDetails(int lintProductID)
        {

            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetProductDetails @ProductID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@ProductID", lintProductID);
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

        #endregion GetProductDetails

        #region SaveCustomerDocuments
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021815
        /// Function used to add customer documents.
        /// </summary>
        /// <param name="lstrDocument"></param>
        /// <param name="mdblUserID"></param>
        /// <param name="lintCustomerID"></param>
        /// <returns></returns>
        public string SaveCustomerDocuments(string lstrTitle, string lstrDocument, double mdblUserID, int lintCustomerID)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_SaveCustomerDocuments @Title,@Document,@UserID,@CustomerID";

            lobjHash.Add("@Title", lstrTitle);
            lobjHash.Add("@Document", lstrDocument);
            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@CustomerID", lintCustomerID);
            try
            {

                lobjres = mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstrResult;
        }

        #endregion SaveCustomerDocuments

        #region GetCustomerName
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021915
        /// Function used to get Customer Name.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        /// <returns></returns>
        public DataSet GetCustomerName(int lintCustomerID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetCustomerName @CustomerID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@CustomerID", lintCustomerID);
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

        #endregion GetCustomerName

        #region GetCustomerFiles
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021915
        /// Function used to get Customer files.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        /// <returns></returns>
        public DataSet GetCustomerFiles(int lintCustomerID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetCustomerFiles @CustomerID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@CustomerID", lintCustomerID);
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

        #endregion GetCustomerFiles

        #region SaveNewCustomerRecords
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:022015
        /// Function used to save customer details from excel.
        /// </summary>
        /// <param name="lstrName"></param>
        /// <param name="lstrEmail"></param>
        /// <param name="lstrAddress1"></param>
        /// <param name="lstrAddress2"></param>
        /// <param name="lstrPhone"></param>
        /// <param name="lstrImages"></param>
        /// <param name="lintStatusID"></param>
        /// <param name="lintStateID"></param>
        /// <param name="lintCityID"></param>
        /// <param name="lintUserID"></param>
        /// <param name="lstrDOB"></param>
        /// <param name="lstrAnniversary"></param>
        /// <param name="lintCustomerID"></param>
        /// <param name="lstrFollowUpText"></param>
        /// <param name="lstrDesc"></param>
        /// <param name="lstrVenue"></param>
        /// <param name="lintFollowUpProvinceID"></param>
        /// <param name="lintFollowUpCityID"></param>
        /// <param name="lstrFollowUpDate"></param>
        /// <param name="lstrStartTime"></param>
        /// <param name="lstrEndTime"></param>
        /// <returns></returns>
       
        //public string SaveNewCustomerRecords(string lstrName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, int lintUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID, string lstrFollowUpText, string lstrDesc, string lstrVenue, int lintFollowUpProvinceID, int lintFollowUpCityID, string lstrFollowUpDate, string lstrStartTime, string lstrEndTime, string lstrDOBDatePart, string lstrAniversaryDatePart, string lstrOfficialEmail, string lstrOfficeAddress1, string lstrOfficeAddress2, string lstrMobile, string lstrHomeFax, string lstrOfficeFaxNo, string lstrExtensionField, string lstrPostalCode)
        //{
        public string SaveNewCustomerRecords(string lstrTitle, string lstrFirstName, string lstrLastName, string lstrEmail, string lstrAddress1, string lstrAddress2, string lstrPhone, string lstrOfcTelephone, string lstrImages, int lintStatusID, int lintStateID, int lintCityID, int lintUserID, string lstrDOB, string lstrAnniversary, int lintCustomerID, string lstrFollowUpText, string lstrDesc, string lstrVenue, int lintFollowUpProvinceID, int lintFollowUpCityID, string lstrFollowUpDate, string lstrStartTime, string lstrEndTime, string lstrDOBDatePart, string lstrAniversaryDatePart, string lstrOfficialEmail, string lstrOfficeAddress1, string lstrOfficeAddress2, string lstrMobile, string lstrHomeFax, string lstrOfficeFaxNo, string lstrExtensionField, string lstrPostalCode, int lintMaritalStatus, int lintDependents, int lintBestCallTime, string lstrReferredBy, int lintColdLead, string lstrFirstContact, string lstrNextContact, string lstrDiscussed, int lintOfcCityID, int lintOfcStateID,string lstrWork)
        {
            string lstrResult = "";
            object lobjres = new object();
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_SaveNewCustomerRecords @Title,@FirstName,@LastName, @Email,@Address1,@Address2,@Phone,@Image,@StatusID,@StateID,@CityID,@UserID,@DateOfBirth,@Anniversary,@CustomerID,@FollowUpText,@Description,@Venue,@FollowUpProvinceID,@FollowUpCityID,@FollowUpDate,@StartTime,@EndTime,@DOBDatePart,@AnniDatePart,@OfficeEmailID,@OfficeAddress1,@OfficeAddress2,@Mobile,@HomeFax,@OfficeFax,@ExtensionField,@PostalCode,@OfcCityID,@OfcStateID,@Telephone,@Work,@Maritalstatus,@Dependents,@BestCallTime,@ReferredBy,@ColdLead,@FirstContact,@NextContact,@Discussed";

            lobjHash.Add("@Title", lstrTitle);
            lobjHash.Add("@FirstName", lstrFirstName);
            lobjHash.Add("@LastName", lstrLastName);
            lobjHash.Add("@Email", lstrEmail);
            lobjHash.Add("@Address1", lstrAddress1);
            lobjHash.Add("@Address2", lstrAddress2);
            lobjHash.Add("@Phone", lstrPhone);
            lobjHash.Add("@Image", lstrImages);
            lobjHash.Add("@StatusID", lintStatusID);
            lobjHash.Add("@StateID", lintStateID);
            lobjHash.Add("@CityID", lintCityID);
            lobjHash.Add("@UserID", lintUserID);
            lobjHash.Add("@DateOfBirth", lstrDOB);
            lobjHash.Add("@Anniversary", lstrAnniversary);
            lobjHash.Add("@CustomerID", lintCustomerID);
            lobjHash.Add("@FollowUpText", lstrFollowUpText);
            lobjHash.Add("@Description", lstrDesc);
            lobjHash.Add("@Venue", lstrVenue);
            lobjHash.Add("@FollowUpProvinceID", lintFollowUpProvinceID);
            lobjHash.Add("@FollowUpCityID", lintFollowUpCityID);
            lobjHash.Add("@FollowUpDate", lstrFollowUpDate);
            lobjHash.Add("@StartTime", lstrStartTime);
            lobjHash.Add("@EndTime", lstrEndTime);
            lobjHash.Add("@DOBDatePart", lstrDOBDatePart);
            lobjHash.Add("@AnniDatePart", lstrAniversaryDatePart);
            //@OfficeEmailID,@OfficeAddress1,@OfficeAddress2,@Mobile,@HomeFax,@OfficeFax,@ExtensionField,@PostalCode
            lobjHash.Add("@OfficeEmailID", lstrOfficialEmail);
            lobjHash.Add("@OfficeAddress1", lstrOfficeAddress1);
            lobjHash.Add("@OfficeAddress2", lstrOfficeAddress2);
            lobjHash.Add("@Mobile", lstrMobile);
            lobjHash.Add("@HomeFax", lstrHomeFax);
            lobjHash.Add("@OfficeFax", lstrOfficeFaxNo);
            lobjHash.Add("@ExtensionField", lstrExtensionField);
            lobjHash.Add("@PostalCode", lstrPostalCode);
            lobjHash.Add("@OfcCityID", lintOfcCityID);
            lobjHash.Add("@OfcStateID", lintOfcStateID);
            lobjHash.Add("@Telephone", lstrOfcTelephone);
            lobjHash.Add("@Work", lstrWork);
            lobjHash.Add("@Maritalstatus", lintMaritalStatus);
            lobjHash.Add("@Dependents", lintDependents);
            lobjHash.Add("@BestCallTime", lintBestCallTime);
            lobjHash.Add("@ReferredBy", lstrReferredBy);
            lobjHash.Add("@ColdLead", lintColdLead);
            lobjHash.Add("@FirstContact", lstrFirstContact);
            lobjHash.Add("@NextContact", lstrNextContact);
            lobjHash.Add("@Discussed", lstrDiscussed);
            
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

        #endregion SaveNewCustomerRecords

        #region FillExpertsCombo

        public DataSet FillExpertsCombo(double mdblUserID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "Exec sp_FillExpertsCombo @UserID";
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

        #endregion FillExpertsCombo

        #region SendMailToClient
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:021915
        /// Function used to get Customer Name.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        /// <returns></returns>
        public DataSet SendMailToClient(int lintCustomerID, double mdblUserID, int lintExpertID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_SendMailToClient @CustomerID,@UserID,@ExpertID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@CustomerID", lintCustomerID);
            lobjHash.Add("@UserID", mdblUserID);
            lobjHash.Add("@ExpertID", lintExpertID);
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

        #endregion SendMailToClient

        #region AuthorizeExpert
        public DataSet AuthorizeExpert(int CustomerID, int UserID, int ExpertID)
        {
            DataSet lobjds = new DataSet();
            try
            {
                string lstrQuery = "";

                Hashtable lobjhash = new Hashtable();

                lstrQuery = "EXEC sp_AuthorizeExpert @CustomerID,@UserID,@ExpertID";

                lobjhash.Add("@UserID", UserID);
                lobjhash.Add("@CustomerID", CustomerID);
                lobjhash.Add("@ExpertID", ExpertID);

                lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return lobjds;
        }

        #endregion AuthorizeExpert
        
        #region AddCustomerForSelectedExpert
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:031915
        /// Function used to add new customer for selected expert.
        /// </summary>
        /// <param name="lstrEmail"></param>
        /// <param name="lstrName"></param>
        /// <param name="lintStatusID"></param>
        /// <param name="lintProvinceID"></param>
        /// <param name="lintCityID"></param>
        /// <param name="lstrDateOfBirth"></param>
        /// <param name="lstrAnniversary"></param>
        /// <param name="lstrAddressline1"></param>
        /// <param name="lstrAddressline2"></param>
        /// <param name="lstrPhone"></param>
        /// <param name="lstrPicture"></param>
        /// <param name="lstrOfficeAddress1"></param>
        /// <param name="lstrOfficeAddress2"></param>
        /// <param name="lstrMobile"></param>
        /// <param name="lstrHomeFax"></param>
        /// <param name="lstrOfficeFax"></param>
        /// <param name="lstrExtensionField"></param>
        /// <param name="lstrPostalCode"></param>
        /// <param name="ExpertID"></param>
        public void AddCustomerForSelectedExpert(string lstrCustomerEmail, string lstrCustomerName, int lintStatusID, int lintProvinceID, int lintCityID, string lstrDateOfBirth, string lstrAnniversary, string lstrAddressline1, string lstrAddressline2, string lstrPhone, string lstrPicture, string lstrOfficeAddress1, string lstrOfficeAddress2, string lstrMobile, string lstrHomeFax, string lstrOfficeFax, string lstrExtensionField, string lstrPostalCode, int ExpertID, string lstrOfficeEmailID, string lstrDOBDatePart, string lstrAniversaryDatePart, Int32 CustomerID)
        {
           
            Hashtable lobjHash = new Hashtable();

            string lstrQuery = "EXEC sp_AddCustomerForSelectedExpert @Full_Name, @Email,@Address1,@Address2,@Phone,@Image,@StatusID,@StateID,@CityID,@UserID,@DateOfBirth,@Anniversary,@DOBDatePart,@AnniDatePart,@OfficeEmailID,@OfficeAddress1,@OfficeAddress2,@Mobile,@HomeFax,@OfficeFax,@ExtensionField,@PostalCode,@CustomerID";

            lobjHash.Add("@Full_Name", lstrCustomerName);
            lobjHash.Add("@Email", lstrCustomerEmail);
            lobjHash.Add("@Address1", lstrAddressline1);
            lobjHash.Add("@Address2", lstrAddressline2);
            lobjHash.Add("@Phone", lstrPhone);
            lobjHash.Add("@Image", lstrPicture);
            lobjHash.Add("@StatusID", lintStatusID);
            lobjHash.Add("@StateID", lintProvinceID);
            lobjHash.Add("@CityID", lintCityID);
            lobjHash.Add("@UserID", ExpertID);
            lobjHash.Add("@DateOfBirth", lstrDateOfBirth);
            lobjHash.Add("@Anniversary", lstrAnniversary);
            lobjHash.Add("@DOBDatePart", lstrDOBDatePart);
            lobjHash.Add("@AnniDatePart", lstrAniversaryDatePart);
            lobjHash.Add("@OfficeEmailID", lstrOfficeEmailID);
            lobjHash.Add("@OfficeAddress1", lstrOfficeAddress1);
            lobjHash.Add("@OfficeAddress2", lstrOfficeAddress2);
            lobjHash.Add("@Mobile", lstrMobile);
            lobjHash.Add("@HomeFax", lstrHomeFax);
            lobjHash.Add("@OfficeFax", lstrOfficeFax);
            lobjHash.Add("@ExtensionField", lstrExtensionField);
            lobjHash.Add("@PostalCode", lstrPostalCode);
            lobjHash.Add("@CustomerID", CustomerID);


            try
            {
                 mobjDataAccess.SQLExecuteScalar(lstrQuery, lobjHash, true);
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        #endregion AddCustomerForSelectedExpert

        #region GetFollowUpDetails
        /// <summary>
        /// Author:JAsmeet Kaur
        /// Date:052215
        /// Function used to get follow-up details.
        /// </summary>
        /// <param name="mdblCustomerID"></param>
        /// <returns></returns>
        public DataSet GetFollowUpDetails(double lintCustomerID)
        {
            DataSet lobjDS = null;
            string lstrQuery = "EXEC sp_GetFollowUpDetails @CustomerID";
            Hashtable lobjHash = new Hashtable();

            lobjHash.Add("@CustomerID", lintCustomerID);
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

        #endregion GetFollowUpDetails

        #region ViewCustomerProfile
        /// <summary>
        /// Author:Jasmeet kaur
        /// Date:05242015
        /// Function used to view customer profiles.
        /// </summary>
        /// <param name="lintCustomerID"></param>
        /// <returns></returns>
        public DataSet ViewCustomerProfile(int lintCustomerID)
        {
            DataSet lobjds = new DataSet();
            try
            {
                string lstrQuery = "";

                Hashtable lobjhash = new Hashtable();

                lstrQuery = "EXEC sp_ViewCustomerDetails @CustomerID";

                lobjhash.Add("@CustomerID", lintCustomerID);

                lobjds = mobjDataAccess.GetDataSet(lstrQuery, lobjhash, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return lobjds;
        }

        #endregion ViewCustomerProfile
        #endregion functions



    }
}