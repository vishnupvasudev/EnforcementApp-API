using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using KeyVault.Interfaces;

namespace Enforcement.DAL
{
    #region ConnectionDAL
    /// <summary>
    /// ConnectionDAL
    /// </summary>
    public static class ConnectionDAL
    {
        /// <summary>
        /// Connection string Key
        /// </summary>
        private const string connectionstringKey = "AppSettings:ConnectionStrings";

        #region OpenConnection
        /// <summary>
        /// OpenConnection
        /// </summary>
        /// <param name="iKeyValueProvider"></param>
        /// <returns></returns>
        public static IDbConnection OpenConnection(IKeyValueProvider iKeyValueProvider)
        {
            ConnectionStrings connectionStrings = new ConnectionStrings();
            if (iKeyValueProvider != null)
            {
                connectionStrings = iKeyValueProvider.GetValues<ConnectionStrings>(connectionstringKey);
            }

            IDbConnection connection = new SqlConnection(connectionStrings.DefaultConnection);
            connection.Open();
            return connection;
        }
        #endregion OpenConnection
    }
    #endregion
}
