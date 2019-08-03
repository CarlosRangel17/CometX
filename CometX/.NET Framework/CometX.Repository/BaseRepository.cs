using System;
using System.Configuration;
using CometX.Repository.Utilities;
using CometX.Repository.Extensions;

namespace CometX.Repository
{
    public class BaseRepository
    {
        #region global variable(s)
        protected static string Key { get; set; }
        protected static string ConnectionString { get; set; }
        protected static SqlUtils SqlUtil;
        #endregion

        #region public method(s)
        public string CustomErrorResponse(Exception ex)
        {
            string message = ex.Message;

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                message += "\n" + ex.Message;
            }

            return message;
        }

        public void SetConfiguration(string key = "", string connectionString = "")
        {
            Key = string.IsNullOrWhiteSpace(key) ? "DefaultConnection" : key;
            ConnectionString = string.IsNullOrWhiteSpace(connectionString) ? ConfigurationManager.ConnectionStrings[Key].ConnectionString : connectionString;
            if (ConnectionString.Contains("metadata")) ConnectionString = ConnectionString.ExtrapolateMetaDataFromConnectionString();
            SqlUtil = new SqlUtils(ConnectionString);
        }
        #endregion

        #region private methods
        #endregion
    }
}
