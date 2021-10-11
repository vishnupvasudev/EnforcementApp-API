#region Included Namespaces
using System;
using System.Collections.Generic;
#endregion Included Namespaces

namespace Enforcement.DAL
{    
    #region IRepository
    /// <summary>
    /// IRepository
    /// </summary>
    public interface IRepository
    {
        #region GetAll
        /// <summary>
        /// Get All
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="spName"></param>
        /// <returns>T</returns>
        List<T> GetAll<T>(string spName) where T : class, new();
        #endregion GetAll

        #region FindByID
        /// <summary>
        /// FindByID
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T FindByID<T>(string sp, DataAccessParameters param) where T : class, new();
        #endregion FindByID

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        bool Add<T>(string sp, DataAccessParameters param, bool trasactionType = false) where T : class, new();
        #endregion Add

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        bool Add(string sp, DataAccessParameters param, bool trasactionType = false);
        #endregion Add

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        bool Update(string sp, DataAccessParameters param, bool trasactionType = false);
        #endregion Update

        #region Remove
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Remove(string sp, DataAccessParameters param);
        #endregion Remove

        #region SelectQuery
        /// <summary>
        /// SelectQuery
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        List<T> SelectQuery<T>(string sp, DataAccessParameters param) where T : class, new();
        #endregion SelectQuery

        #region ExecuteSp
        /// <summary>
        /// Execute stored procedure
        /// </summary>
        /// <param name="storedprocedure"></param>
        /// <param name="param"></param>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        bool ExecuteSp(string storedprocedure, DataAccessParameters param, bool transactionType = false);
        #endregion ExecuteSp

        #region AddAndReturnPrimaryKey
        /// <summary>
                    /// AddAndReturnPrimaryKey
                    /// </summary>
                    /// <param name="sp"></param>
                    /// <param name="param"></param>
                    /// <param name="trasactionType"></param>
                    /// <returns></returns>
        long AddAndReturnPrimaryKey(string sp, DataAccessParameters param, bool trasactionType = false);
        #endregion AddAndReturnPrimaryKey

        #region QueryMultiple
        /// <summary>
        /// QueryMultiple
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        List<dynamic> QueryMultiple(string sp, DataAccessParameters param);
        #endregion
    }
    #endregion IRepository
}
