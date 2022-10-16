using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.DatabaseLayer
{
    public class DB
    {
        #region Enumeration - CRUD Operations
        /// <summary>
        /// Represents database operations: Add, Edit and Delete
        /// </summary>
        public enum DBOperation 
        {
            Add = 0, 
            Edit = 1,
            Delete = 2
        }
        #endregion

        #region Variable declaration

        #region Private 
        ///<summary>Represents the connection string</summary> 
        private string strConn = "";
        #endregion

        #region Protected - To be inherited by subclassess
        ///<summary>Represents a connection to a SQL Server database.</summary>
        protected SqlConnection cnMain;

        ///<summary>Represents data from the database</summary>
        protected DataSet dsMain;

        ///<summary>Represensts set of SQL commands and data connection used to
        /// fill DataSet and update data source </summary>
        protected SqlDataAdapter daMain;
        #endregion

        #endregion

        
    }
}
