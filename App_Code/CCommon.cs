using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using E2aForums;

/// <summary>
/// Summary description for CCommon
/// </summary>
public class CCommon
{
    
    DataAccess mobjDataAccess = new DataAccess();
    public CCommon(string ConnectionString)
    {
        mobjDataAccess.ConnectionString = ConnectionString;

    }

    #region Properties

    public int CategoryID { get; set; }
    public int UserID { get; set; }
    public int ChapterID { get; set; }
    public double CustomerID { get; set; }

    #endregion  Properties

    #region SetGridVariables

    /// <summary>
    /// Setting the variables for Grid Paging
    /// </summary>
    /// <exclude>
    /// Author - Naveen Thakur
    /// Date   - 111712
    /// </exclude>
    /// <param name="pstrTableName">Name of the table</param>
    /// <param name="pdblTotalRowsCount">ref to total rows count</param>
    /// <param name="pdblPageNo">ref to the current page no</param>
    /// <param name="pdblStartIndex">ref to the start index</param>
    /// <param name="pdblEndIndex">ref to the end index</param>
    /// <param name="pstrSortParameter">ref to SortBy Column name</param>
    /// <param name="pstrSortOrder">ref to Sort Order</param>
    /// <param name="pstrSearchColumn">ref to Column on which searching is done</param>
    /// <param name="pstrSearchString">ref to string to be searched</param>
    public void SetGridVariables(string pstrTableName, ref double pdblTotalRowsCount, ref double pdblPageNo, ref double pdblStartIndex, ref double pdblEndIndex, ref string pstrSortParameter, ref string pstrSortOrder, ref string pstrSearchColumn, ref string pstrSearchString)
    {
        try
        {
            double ldblRowsPerPage = 0;
            double ldblTotalPages = 0;


            if (HttpContext.Current.Request.Form["page"] != null)
            {
                pdblPageNo = Convert.ToDouble(HttpContext.Current.Request.Form["page"].ToString());
            }

            if (HttpContext.Current.Request.Form["rp"] != null)
            {
                ldblRowsPerPage = Convert.ToDouble(HttpContext.Current.Request.Form["rp"].ToString());
            }

            if (HttpContext.Current.Request.Form["sortname"] != null)
            {
                pstrSortParameter = HttpContext.Current.Request.Form["sortname"].ToString();
            }

            if (HttpContext.Current.Request.Form["sortorder"] != null)
            {
                pstrSortOrder = HttpContext.Current.Request.Form["sortorder"].ToString();
            }

            if (HttpContext.Current.Request.Form["query"] != null)
            {
                pstrSearchString = HttpContext.Current.Request.Form["query"].ToString();
            }

            if (HttpContext.Current.Request.Form["qtype"] != null)
            {
                pstrSearchColumn = HttpContext.Current.Request.Form["qtype"].ToString();
            }


            pdblTotalRowsCount = GetTotalRowsCount(pstrTableName, pstrSearchColumn, pstrSearchString);

            if (pdblTotalRowsCount > 0)
            {
                ldblTotalPages = pdblTotalRowsCount / ldblRowsPerPage;

                ldblTotalPages = Math.Ceiling(ldblTotalPages);
            }
            else
            {
                ldblTotalPages = 1;
            }

            if (pdblPageNo > ldblTotalPages)
            {
                pdblPageNo = ldblTotalPages;
            }

            pdblStartIndex = ((ldblRowsPerPage * pdblPageNo) - ldblRowsPerPage) + 1;

            pdblEndIndex = (pdblStartIndex + ldblRowsPerPage) - 1;


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }


    #endregion SetGridVariables

    #region GetTotalRowsCount

    /// <summary>
    /// Getting the total records in a table
    /// </summary>
    /// <exclude>
    /// Author - Naveen Thakur
    /// Date   - 100412
    /// </exclude>
    /// <param name="pstrTableName">TableName</param>
    /// <param name="pstrSearchColumn">Column on which searching is done</param>
    /// <param name="pstrSearchString">string to be searched</param>
    /// <returns>Rows count</returns>
    private double GetTotalRowsCount(string pstrTableName, string pstrSearchColumn, string pstrSearchString)
    {
        double ldblRowCount = 0;
        object lobjResult = new object();
        Hashtable lobjHashtable = new Hashtable();
        string lstrSqlQuery = "";




        if (CConstants.enumTables.TblCategories.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetForumCategoryCount @SearchColoumn, @SearchString";

        }
        if (CConstants.enumTables.TblTopics.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetForumTopicCount @SearchColoumn, @SearchString, @CategoryID";
            lobjHashtable.Add("@CategoryID", CategoryID);
        }
        if (CConstants.enumTables.TblTopicList.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetTopicListingCount @SearchColoumn, @SearchString,@CategoryID";
            lobjHashtable.Add("@CategoryID", CategoryID);
        }
        if (CConstants.enumTables.TblUsers.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetUsersListCount @SearchColoumn, @SearchString";
            
        }
        
              if ("CompUsers" == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetCompUsersListCount @SearchColoumn, @SearchString";
            
        }
        if (CConstants.enumTables.TblAdvertisements.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetAdvertisementListingCount @SearchColoumn, @SearchString";

        }
        if (CConstants.enumTables.TblAdvertisementZone.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetAdvertisementZoneListingCount @SearchColoumn, @SearchString";

        }
        if (CConstants.enumTables.TblExperts.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetExpertsListCount @SearchColoumn, @SearchString";

        }
        if (CConstants.enumTables.TblChapters.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetChapterListCount @SearchColoumn, @SearchString, @UserID";
            lobjHashtable.Add("@UserID", UserID);
        }
        if (CConstants.enumTables.TblSubTitles.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetCourseSubTitleListCount @SearchColoumn, @SearchString, @UserID, @ChapterID";
            lobjHashtable.Add("@UserID", UserID);
            lobjHashtable.Add("@ChapterID", ChapterID);
        }
        if (CConstants.enumTables.TblCustomers.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetCustomersListCount @SearchColoumn, @SearchString, @UserID";
            lobjHashtable.Add("@UserID", UserID);
      
        }
        if (CConstants.enumTables.TblDocs.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetUserDocListCount @SearchColoumn, @SearchString, @UserID";
            lobjHashtable.Add("@UserID", UserID);

        }
        if (CConstants.enumTables.TblProducts.ToString() == pstrTableName)
        {
            lstrSqlQuery = "EXEC sp_GetProductListingCount @SearchColoumn, @SearchString, @UserID";
            lobjHashtable.Add("@UserID", UserID);

        }
        try
        {
            lobjHashtable.Add("@SearchString", pstrSearchString);
            lobjHashtable.Add("@SearchColoumn", pstrSearchColumn);

            lobjResult = mobjDataAccess.SQLExecuteScalar(lstrSqlQuery, lobjHashtable, false);

            if (lobjResult != null)
                ldblRowCount = Convert.ToDouble(lobjResult);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return ldblRowCount;
    }

    #endregion GetTotalRowsCount



}