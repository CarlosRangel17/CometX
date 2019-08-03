using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using CometX.NETCore.Repository.Utilities;
using CometX.NETCore.Repository.Extensions;

namespace CometX.NETCore.Repository
{
    public class BaseRepository
    {
        #region global variable(s)
        protected static string Key { get; set; }
        protected static string ConnectionString { get; set; }
        protected static SqlUtils SqlUtil;
        protected static readonly IConfigurationBuilder Builder = new ConfigurationBuilder();
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
            var config = BuildConfiguration();
            Key = string.IsNullOrWhiteSpace(key) ? "DefaultConnection" : key;
            ConnectionString = string.IsNullOrWhiteSpace(connectionString) ? config.GetConnectionString(Key) : connectionString;
            if (ConnectionString.Contains("metadata")) ConnectionString = ConnectionString.ExtrapolateMetaDataFromConnectionString();
            SqlUtil = new SqlUtils(ConnectionString);
        }
        #endregion

        #region private methods
        private IConfigurationRoot BuildConfiguration()
        {
            Builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = Builder.Build();
            return configuration;
        }
        #endregion
    }
}
