using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using E2aForums;

/// <summary>
/// Summary description for CCalendar
/// </summary>
public class CCalendar
{
    DataAccess mobjDataAccess = new DataAccess();
    public CCalendar(string ConnectionString)
	{
        mobjDataAccess.ConnectionString = ConnectionString;
	}

    //#region GetCalendarEvents
    //public DataSet GetCalendarEvents(string pstrStartDate, string pstrEndDate, double pdblUserId)
    //{
    //    DataSet lobjds = null;
    //    Hashtable lobjParams = new Hashtable();

    //    string lstrSqlQuery = " Exec sp_GetCalendarEvents @StartDate, @EndDate, @UserId";

    //    try
    //    {
    //        lobjParams.Add("@StartDate", pstrStartDate);
    //        lobjParams.Add("@EndDate", pstrEndDate);
    //        lobjParams.Add("@UserId", pdblUserId);

    //        lobjds = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjParams, false);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }

    //    return lobjds;
    //}

    //#endregion GetCalendarEvents

    //#region GetCalendarEvents
    //public DataSet GetCalendarEvents(string pstrStartDate, string pstrEndDate, double mdblUserId, int lintCityID)
    //{

    //    DataSet lobjds = null;
    //    Hashtable lobjParams = new Hashtable();

    //    string lstrSqlQuery = " Exec sp_GetCalendarEvents @StartDate, @EndDate, @UserId, @CityID";

    //    try
    //    {
    //        lobjParams.Add("@StartDate", pstrStartDate);
    //        lobjParams.Add("@EndDate", pstrEndDate);
    //        lobjParams.Add("@UserId", mdblUserId);
    //        lobjParams.Add("@CityID", lintCityID);

    //        lobjds = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjParams, false);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }

    //    return lobjds;
    //}
    //#endregion GetCalendarEvents


    #region CheckEventTitleExistence
    public bool CheckEventTitleExistence(string lstrStartDate, string lstrTitle, double mdblUserId, double ldblEventID)
    {
        bool lblnIsTitleExists = false;
        Hashtable lobjParams = new Hashtable();
        object lobjIsTitleExists = new object();

        string lstrSqlQuery = " EXEC sp_CheckTitleExistence @StartDate, @Title, @UserId, @EventID ";

        try
        {
            lobjParams.Add("@StartDate", lstrStartDate);
            lobjParams.Add("@Title", lstrTitle);
            lobjParams.Add("@UserId", mdblUserId);
            lobjParams.Add("@EventID", ldblEventID);

            lobjIsTitleExists = mobjDataAccess.SQLExecuteScalar(lstrSqlQuery, lobjParams, false);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        if (lobjIsTitleExists != null && lobjIsTitleExists.ToString() != "")
            lblnIsTitleExists = true;

        return lblnIsTitleExists;
    }

    #endregion CheckEventTitleExistence
    
    #region AddNewEvent
    public string AddNewEvent(string lstrTitle, string lstrDescription, string lstrStartDate, string lstrEndDate, double ldblEventID, double mdblUserId, string lstrVenue, int lintStateID, int lintCityID, bool lbnIsAdmin)
    {
        string lstrResult = "";
        object lobjres = new object();
        Hashtable lobjHashTable = new Hashtable();

        try
        {
            string lstrSqlQuery = "EXEC sp_AddNewEvent @Title, @Description, @StartDate, @EndDate, @EventID, @UserId, @Venue, @StateID, @CityID, @IsAdmin";

            lobjHashTable.Add("@Title", lstrTitle);
            lobjHashTable.Add("@Description", lstrDescription);
            lobjHashTable.Add("@StartDate", lstrStartDate);
            lobjHashTable.Add("@EndDate", lstrEndDate);
            lobjHashTable.Add("@EventID", ldblEventID);
            lobjHashTable.Add("@UserId", mdblUserId);
            lobjHashTable.Add("@Venue", lstrVenue);
            lobjHashTable.Add("@StateID", lintStateID);
            lobjHashTable.Add("@CityID", lintCityID);
            lobjHashTable.Add("@IsAdmin", lbnIsAdmin);

            lobjres = mobjDataAccess.SQLExecuteScalar(lstrSqlQuery, lobjHashTable, true);

            if (lobjres != null)
                lstrResult = lobjres.ToString();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return lstrResult;
       
    }

    #endregion AddNewEvent

    #region GetEventDetails

    public DataSet GetEventDetails(double ldblEventID, double mdblUserId)
    {
         DataSet lobjds = null;
        Hashtable lobjParams = new Hashtable();

        string lstrSqlQuery = " EXEC sp_GetEventDetails @EventID, @UserID ";

        try
        {
            lobjParams.Add("@EventID", ldblEventID);
            lobjParams.Add("@UserID", mdblUserId);
          
            lobjds = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjParams, false);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return lobjds;
    }

    #endregion GetEventDetails

    #region DeleteSelectedEventDetails
    public void DeleteSelectedEventDetails(double ldblEventID, double mdblUserId)
    {
        Hashtable lobjHashTable = new Hashtable();

        string lstrSqlQuery = "EXEC sp_DeleteEventDetails @EventID, @UserId ";

        lobjHashTable.Add("@EventID", ldblEventID);
        lobjHashTable.Add("@UserId", mdblUserId);

        try
        {
            int lintCount = mobjDataAccess.SQLExecuteNonQuery(lstrSqlQuery, lobjHashTable, true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    #endregion DeleteSelectedEventDetails

   
    #region ApproveEvent
    public void ApproveEvent(int lintEventID)
    {
        string lstrQuery = " Update TblCalendarEvents Set EventApprovedbyAdmin=1 where EventID=@EventID	and Active=1";// "EXEC sp_ApproveEvents @EventID";
        Hashtable lobjHash = new Hashtable();
        lobjHash.Add("@EventID", lintEventID);

        try
        {
            mobjDataAccess.SQLExecuteNonQuery(lstrQuery, lobjHash, true);
        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion ApproveEvent

    #region GetCalendarEvents
    public DataSet GetCalendarEvents(string pstrStartDate, string pstrEndDate, double mdblUserId, int lintCityID, bool IsAdmin)
    {
        DataSet lobjds = null;
        Hashtable lobjParams = new Hashtable();

        string lstrSqlQuery = " Exec sp_GetCalendarEvents @StartDate, @EndDate, @UserId, @CityID, @IsAdmin";

        try
        {
            lobjParams.Add("@StartDate", pstrStartDate);
            lobjParams.Add("@EndDate", pstrEndDate);
            lobjParams.Add("@UserId", mdblUserId);
            lobjParams.Add("@CityID", lintCityID);
            lobjParams.Add("@IsAdmin", IsAdmin);

            lobjds = mobjDataAccess.GetDataSet(lstrSqlQuery, lobjParams, false);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return lobjds;
    }

    #endregion GetCalendarEvents

    #region AddNewFollowUpMeet
    /// <summary>
    /// Author:Jasmeet kaur
    /// date:021715
    /// Function used to add follow up note.
    /// </summary>
    /// <param name="lintEventID"></param>
    /// <param name="lintCustomerID"></param>
    public void AddNewFollowUpMeet(string lstrFollowUPNote, int lintEventID, int lintCustomerID, bool lbnIsProspects, double mdblUserId)
    {
      
        Hashtable lobjParams = new Hashtable();

        string lstrSqlQuery = " Exec sp_AddNewFollowUpMeet @FollowUPNote, @EventID, @CustomerID, @IsProspects,@UserID";

        try
        {
            lobjParams.Add("@FollowUPNote", lstrFollowUPNote);
            lobjParams.Add("@EventID", lintEventID);
            lobjParams.Add("@CustomerID", lintCustomerID);
            lobjParams.Add("@IsProspects", lbnIsProspects);
            lobjParams.Add("@UserID", mdblUserId);
            mobjDataAccess.SQLExecuteNonQuery(lstrSqlQuery, lobjParams, true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

       
    }

    #endregion AddNewFollowUpMeet




    
       

}