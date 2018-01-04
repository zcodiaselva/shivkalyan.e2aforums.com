using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web;


namespace E2aForums
{
    public class DataAccess
    {
        #region Variables

        //#A GD:100610 - Variable for ConnectionString.
        private string _ConnectionString;


        #endregion

        #region Properties

        #region ConnectionString
        /// <summary>
        /// This property is to represent the connection string to establish the database connection
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        #endregion

        #endregion

        #region Constructor

        public DataAccess()
        {

        }

        #endregion

        #region CreateSqlParameters

        /// <summary>
        /// Creates SqlParameters for the SqlCommand object passed
        /// </summary>
        /// <param name="pobjCommand">SqlCommand Object</param>
        /// <param name="pobjHashtable">Hashtable Ojbect</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        private void CreateSqlParameters(ref SqlCommand pobjCommand, Hashtable pobjHashtable)
        {
            //#A NT:100610 - Getting the Hashtable's key and value pairs in IDictionaryEnumerator object.
            IDictionaryEnumerator lobjIDEnum = pobjHashtable.GetEnumerator();

            //#A NT:100610 - Creating the SqlParameters from the key and value pairs of IDictionaryEnumerator object
            while (lobjIDEnum.MoveNext())
            {
                pobjCommand.Parameters.Add(new SqlParameter(lobjIDEnum.Key.ToString(), lobjIDEnum.Value.ToString()));
            }

        }

        #endregion

        #region SQLExecuteScalar

        /// <summary>
        /// Executes the SQL query, and returns the first column of the first row as an Object in the result set returned by the query.
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>
        /// <param name="pobjHashtable">Hashtable Object</param>
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        /// <returns>object</returns>
        public object SQLExecuteScalar(string pstrSQLQuery, Hashtable pobjHashtable, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Decalaring an object
            object lobjReturnValue = null;

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            try
            {
                //#A NT:100610 - Creating Sql Parmaters
                CreateSqlParameters(ref Command, pobjHashtable);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while creating Sql Parameters. " + ex.Message);
            }


            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.CommandText = pstrSQLQuery;
            Command.Connection = Connection;


            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }

            try
            {
                //#A NT:100610 - Calling the Sql ExecuteScalar function to execute the Sql query
                //  if (Command.ExecuteScalar() != DBNull.Value || Command.ExecuteScalar() != null)
                lobjReturnValue = Command.ExecuteScalar();

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);
            }
            finally
            {

                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

                //#A NT:100610 - Disposing and closing the objects
                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Dispose();
                Connection.Close();
            }

            //#A NT:100610 - returning the object
            return lobjReturnValue;

        }


        /// <summary>
        /// Executes the SQL query, and returns the first column of the first row as an Object in the result set returned by the query.
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>   
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        /// <returns>object</returns>
        public object SQLExecuteScalar(string pstrSQLQuery, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Decalaring an object
            object lobjReturnValue = null;

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.CommandText = pstrSQLQuery;
            Command.Connection = Connection;


            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }

            try
            {
                //#A NT:100610 - Calling the Sql ExecuteScalar function to execute the Sql query
                // if (Command.ExecuteScalar() != DBNull.Value || Command.ExecuteScalar() != null)
                lobjReturnValue = Command.ExecuteScalar();

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);
            }
            finally
            {

                //#A NT:100610 - Disposing and closing the objects
                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Dispose();
                Connection.Close();
            }

            //#A NT:100610 - returning the object
            return lobjReturnValue;

        }

        #endregion

        #region SQLExecuteNonQuery

        /// <summary>
        /// Executes the Transact-SQL statement against the Connection, and returns the number of rows affected.
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>
        /// <param name="pobjHashtable">Hashtable Object</param>
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        /// <returns>Integer</returns>
        public Int32 SQLExecuteNonQuery(string pstrSQLQuery, Hashtable pobjHashtable, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Declaring the integer variable.
            Int32 lintRowsAffected = 0;

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            try
            {
                //#A NT:100610 - Creating Sql Parmaters
                CreateSqlParameters(ref Command, pobjHashtable);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while creating Sql Parameters. " + ex.Message);
            }


            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.CommandText = pstrSQLQuery;
            Command.Connection = Connection;

            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }


            try
            {
                //#A NT:100610 - Calling the Sql ExecuteNonQuery function to execute the Sql query and gettng
                // the count of rows affected.
                lintRowsAffected = Command.ExecuteNonQuery();

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);

            }
            finally
            {
                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

                //#A NT:100610 - Disposing and closing the objects
                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Close();
                Connection.Dispose();
            }

            //#A NT:100610 - Returning the count of rows affected
            return lintRowsAffected;

        }

        /// <summary>
        /// Executes the Transact-SQL statement against the Connection, and returns the number of rows affected.
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Sarabjit Sohal
        /// Created On : 021708
        /// </remarks>
        /// <returns>Integer</returns>
        public Int32 SQLExecuteNonQuery(string pstrSQLQuery, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Declaring the integer variable.
            Int32 lintRowsAffected = 0;

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.CommandText = pstrSQLQuery;
            Command.Connection = Connection;

            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }


            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }


            try
            {
                //#A NT:100610 - Calling the Sql ExecuteNonQuery function to execute the Sql query and gettng
                // the count of rows affected.
                lintRowsAffected = Command.ExecuteNonQuery();

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();
            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);

            }
            finally
            {
                //#A NT:100610 - Disposing and closing the objects
                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Close();
                Connection.Dispose();
            }

            //#A NT:100610 - Returning the count of rows affected
            return lintRowsAffected;

        }

        #endregion

        #region SQLExecuteReader

        /// <summary>
        /// Executes the SQL query, and returns the result as SqlReader object
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>
        /// <param name="pobjHashtable">Hashtable Object</param>
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        /// <returns>SqlDataReader Object</returns>
        public SqlDataReader SQLExecuteReader(string pstrSQLQuery, Hashtable pobjHashtable, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Decalaring SqlDataReader object
            SqlDataReader lobjSqlDataReader = null;

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            try
            {
                //#A NT:100610 - Creating Sql Parmaters
                CreateSqlParameters(ref Command, pobjHashtable);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while creating Sql Parameters. " + ex.Message);
            }


            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.CommandText = pstrSQLQuery;
            Command.Connection = Connection;


            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }

            try
            {
                //#A NT:100610 - Calling the Sql ExecuteReader function to execute the Sql query
                lobjSqlDataReader = Command.ExecuteReader();

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);
            }
            finally
            {
                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

                //#A NT:100610 - Disposing and closing the objects
                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Dispose();
                Connection.Close();
            }

            //#A NT:100610 - returning the SqlDataReader object
            return lobjSqlDataReader;

        }

        /// <summary>
        /// Executes the SQL query, and returns the result as SqlReader object
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>    
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        /// <returns>SqlDataReader Object</returns>
        public SqlDataReader SQLExecuteReader(string pstrSQLQuery, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Decalaring SqlDataReader object
            SqlDataReader lobjSqlDataReader = null;

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.CommandText = pstrSQLQuery;
            Command.Connection = Connection;


            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }

            try
            {
                //#A NT:100610 - Calling the Sql ExecuteReader function to execute the Sql query
                lobjSqlDataReader = Command.ExecuteReader();

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);
            }
            finally
            {

                //#A NT:100610 - Disposing and closing the objects
                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Dispose();
                Connection.Close();
            }

            //#A NT:100610 - returning the SqlDataReader object
            return lobjSqlDataReader;

        }

        #endregion

        #region GetDataSet

        /// <summary>
        /// Executes the SQL query, and returns the result as DataSet object.
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>
        /// <param name="pobjHashtable">Hashtable Object</param>
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : Naveen Thakur
        /// Created On : 062910
        /// </remarks>
        /// <returns>DataSet Object</returns>
        public DataSet GetDataSet(string pstrSQLQuery, Hashtable pobjHashtable, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Creating DataSet and DataAdapter objects
            DataSet lobjDataSet = new DataSet();
            SqlDataAdapter lobjDataAdapter = new SqlDataAdapter();

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            try
            {
                //#A NT:100610 - Creating Sql Parmaters
                CreateSqlParameters(ref Command, pobjHashtable);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while creating Sql Parameters. " + ex.Message);
            }


            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.Connection = Connection;
            lobjDataAdapter.SelectCommand = Command;
            lobjDataAdapter.SelectCommand.CommandText = pstrSQLQuery;



            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }

            try
            {
                //#A NT:100610 - The DataAdapter object for filling the dataset.				
                lobjDataAdapter.Fill(lobjDataSet);

                if (lobjDataSet.Tables[0].Rows.Count == 0)
                    lobjDataSet = null;

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);
            }
            finally
            {
                //#A NT:100610 - Clearing the command parameters
                Command.Parameters.Clear();

                //#A NT:100610 - Disposing and closing the objects
                lobjDataAdapter.Dispose();

                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Dispose();
                Connection.Close();
            }

            //#A NT:100610 - returning the DataSet object
            return lobjDataSet;

        }

        /// <summary>
        /// Executes the SQL query, and returns the result as DataSet object.
        /// </summary>
        /// <param name="pstrSQLQuery">SQL Query String</param>    
        /// <param name="pblnIsTransactionRequired">Is Transaction Required</param>
        /// <remarks>
        /// Created By : ManishSharma 
        /// Created On : 062910
        /// </remarks>
        /// <returns>DataSet Object</returns>
        public DataSet GetDataSet(string pstrSQLQuery, bool pblnIsTransactionRequired)
        {
            //#A NT:100610 - Creating DataSet and DataAdapter objects
            DataSet lobjDataSet = new DataSet();
            SqlDataAdapter lobjDataAdapter = new SqlDataAdapter();

            //#A NT:100610 - Creating an object of SqlConnection
            SqlConnection Connection = new SqlConnection(_ConnectionString);

            //#A NT:100610 - Creating an object of SqlCommand
            SqlCommand Command = new SqlCommand();

            //#A NT:100610 - Creating an object of SqlTransaction
            SqlTransaction Transaction = null;

            //#A NT:100610 - Setting the CommandText and Connection properties of Command object.
            Command.Connection = Connection;
            lobjDataAdapter.SelectCommand = Command;
            lobjDataAdapter.SelectCommand.CommandText = pstrSQLQuery;

            try
            {
                //#A NT:100610 - Opening the Connection
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while establishing connection with database. " + ex.Message);
            }

            if (pblnIsTransactionRequired)
            {
                //#A NT:100610 - Begin the SqlTransaction and Setting the Transaction property of Command object.
                Transaction = Connection.BeginTransaction();
                Command.Transaction = Transaction;
            }

            try
            {
                //#A NT:100610 - The DataAdapter object for filling the dataset.				
                lobjDataAdapter.Fill(lobjDataSet);

                if (lobjDataSet.Tables[0].Rows.Count == 0)
                    lobjDataSet = null;

                //#A NT:100610 - Committing the SQL Transaction.
                if (pblnIsTransactionRequired)
                    Transaction.Commit();

            }
            catch (Exception ex)
            {
                //#A NT:100610 - RollBack the SQL Transaction if error occurs.
                if (pblnIsTransactionRequired)
                    Transaction.Rollback();

                throw new Exception("An error occured while executing Sql query. " + ex.Message);
            }
            finally
            {

                //#A NT:100610 - Disposing and closing the objects
                lobjDataAdapter.Dispose();

                if (pblnIsTransactionRequired)
                    Transaction.Dispose();

                Command.Dispose();
                Connection.Dispose();
                Connection.Close();
            }

            //#A NT:100610 - returning the DataSet object
            return lobjDataSet;

        }

        #endregion
    }
}