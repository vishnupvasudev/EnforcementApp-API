#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using Dapper;
using KeyVault.Interfaces;
#endregion Included Namespaces

namespace Enforcement.DAL.Dapper
{
    #region DapperRepository
    /// <summary>
    /// DapperRepository
    /// </summary>
    public class DapperRepository : IRepository
    {
        /* Variable Declarations */

        /// <summary>
        /// _iKeyValueProvider
        /// </summary>
        private readonly IKeyValueProvider _iKeyValueProvider;

        #region TimeOutLimit
        /// <summary>
        /// TimeOut Limit
        /// </summary>
        private int TimeOutLimit => 50000;
        #endregion TimeOutLimit

        /* Variable Declarations */

        /// <summary>
        /// Repository
        /// </summary>
        /// <param name="iKeyValueProvider"></param>
        public DapperRepository(IKeyValueProvider iKeyValueProvider)
        {
            _iKeyValueProvider = iKeyValueProvider;
        }

        /// <summary>
        /// BuildDynamicParameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DynamicParameters BuildDynamicParameters(DataAccessParameters parameters)
        {
            DynamicParameters param = new DynamicParameters();

            foreach (KeyValuePair<string, object> item in parameters.Items)
            {
                if (item.Value != null && item.Value.GetType() == typeof(DataTable))
                {
                    param.Add(item.Key, (item.Value as DataTable).AsTableValuedParameter());
                }
                else
                {
                    param.Add(item.Key, item.Value);
                }
            }

            return param;
        }

        #region GetAll
        /// <summary>
        /// GetAll
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="spName"></param>
        /// <returns></returns>
        public List<T> GetAll<T>(string spName) where T : class, new()
        {
            List<T> lstResult = null;

            using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
            {
                lstResult = connection.Query<T>(spName, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure).ToList();
            }

            return lstResult;
        }
        #endregion GetAll

        #region FindByID
        /// <summary>
        /// FindByID
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T FindByID<T>(string sp, DataAccessParameters param) where T : class, new()
        {
            T resultObj = null;
            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);
                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    resultObj = connection.Query<T>(sp, dynamicParameters, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }

            return resultObj;
        }
        #endregion FindByID

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        public bool Add(string sp, DataAccessParameters param, bool trasactionType = false)
        {
            bool status = false;

            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);

                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    if (trasactionType)
                    {
                        using (IDbTransaction tran = connection.BeginTransaction())
                        {
                            try
                            {
                                status = connection.Execute(sp, dynamicParameters, tran, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                                tran.Commit();
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                                throw;
                            }
                        }
                    }
                    else
                    {
                        status = connection.Execute(sp, dynamicParameters, commandTimeout: 200, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                    }
                }
            }

            return status;
        }
        #endregion Add

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        public bool Update(string sp, DataAccessParameters param, bool trasactionType = false)
        {
            bool status = false;
            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);
                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    if (trasactionType)
                    {
                        using (IDbTransaction tran = connection.BeginTransaction())
                        {
                            try
                            {
                                status = connection.Execute(sp, dynamicParameters, tran, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                                tran.Commit();
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                                throw;
                            }
                        }
                    }
                    else
                    {
                        status = connection.Execute(sp, dynamicParameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                    }
                }
            }

            return status;
        }
        #endregion Update

        #region Remove
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool Remove(string sp, DataAccessParameters param)
        {
            bool status = false;
            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);
                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    status = connection.Execute(sp, dynamicParameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }

            return status;
        }
        #endregion Remove

        #region SelectQuery
        /// <summary>
        /// SelectQuery
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T> SelectQuery<T>(string sp, DataAccessParameters param) where T : class, new()
        {
            List<T> lstResult = null;

            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);
                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    lstResult = connection.Query<T>(sp, dynamicParameters, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return lstResult;
        }
        #endregion SelectQuery

        #region ExecuteSp
        /// <summary>
        /// Execute stored procedure
        /// </summary>
        /// <param name="storedprocedure"></param>
        /// <param name="param"></param>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public bool ExecuteSp(string storedprocedure, DataAccessParameters param, bool transactionType = false)
        {
            bool status = false;
            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);

                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    if (transactionType)
                    {
                        using (IDbTransaction tran = connection.BeginTransaction())
                        {
                            status = connection.Execute(storedprocedure, dynamicParameters, tran, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                        }
                    }
                    else
                    {
                        status = connection.Execute(storedprocedure, dynamicParameters, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                    }
                }
            }

            return status;
        }
        #endregion ExecuteSp

        #region AddAndReturnPrimaryKey
        /// <summary>
        /// AddAndReturnPrimaryKey
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        public long AddAndReturnPrimaryKey(string sp, DataAccessParameters param, bool trasactionType = false)
        {
            long result = 0;
            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);

                if (trasactionType)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                        {
                            result = connection.Query<long>(sp, dynamicParameters, commandType: CommandType.StoredProcedure).Single();
                        }

                        transactionScope.Complete();
                    }
                }
                else
                {
                    using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                    {
                        result = connection.Query<long>(sp, dynamicParameters, commandType: CommandType.StoredProcedure).Single();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="trasactionType"></param>
        /// <returns></returns>
        public bool Add<T>(string sp, DataAccessParameters param, bool trasactionType = false) where T : class, new()
        {
            throw new NotImplementedException();
        }
        #endregion AddAndReturnPrimaryKey

        #region QueryMultiple
        /// <summary>
        /// Query multiple
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<dynamic> QueryMultiple(string sp, DataAccessParameters param)
        {
            dynamic result = null;
            List<dynamic> dynResult = new List<dynamic>();
            DynamicParameters dynamicParameters;

            if (param != null)
            {
                dynamicParameters = BuildDynamicParameters(param);

                using (IDbConnection connection = ConnectionDAL.OpenConnection(_iKeyValueProvider))
                {
                    using (var multi = connection.QueryMultiple(sp, dynamicParameters, commandTimeout: TimeOutLimit, commandType: CommandType.StoredProcedure))
                    {
                        try
                        {
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                            result = multi.Read<dynamic>().ToList();
                            dynResult.Add(result);
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return dynResult;
        }
        #endregion QueryMultiple
    }
    #endregion DapperRepository
}
