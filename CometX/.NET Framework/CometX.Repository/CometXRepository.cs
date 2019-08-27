using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using CometX.Repository.Utilities;
using CometX.Repository.Queries;
using CometX.Repository.Extensions;
using CometX.Attributes.Extensions.RelationalDBExtensions;

namespace CometX.Repository
{
    public class CometXRepository : BaseRepository, ICometXRepository
    {
        #region global variable(s)
        private static readonly QueryUtils QueryUtil = new QueryUtils();
        #endregion

        #region constructor(s)
        public CometXRepository()
        {
            SetConfiguration();
        }

        public CometXRepository(string key)
        {
            SetConfiguration(key);
        }

        public CometXRepository(string key, string connectionString)
        {
            SetConfiguration(key, connectionString);
        }
        #endregion

        #region public methods
        /// <summary>
        /// Checks the flag status of a flag attribute. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckActive<T>(int id)
        {
            try
            {
                string query = BaseQuery.SELECT_IS_ACTIVE_FROM_WHERE<T>(id);

                return SqlUtil.CheckDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Returns a flag based off query condition provided. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool CheckTable<T>(Expression<Func<T, bool>> expression)
        {
            try
            {
                string query = BaseQuery.SELECT_FROM_WHERE_EXISTS<T>(QueryUtil.Translate(expression));

                return SqlUtil.CheckDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Deletes the specified entity based off Primary Key attribute.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : new()
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("entity");

                string query = BaseQuery.DELETE_WHERE<T>(entity.ToDeleteQuery());
                SqlUtil.ExecuteDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Deletes the specified entity or entities based off provided expression.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete<T>(Expression<Func<T, bool>> expression, bool deleteAll = false)
        {
            try
            {
                string table = typeof(T).Name;

                string condition = expression == null ? "" : QueryUtil.Translate(expression);

                string query = deleteAll
                    ? (string.IsNullOrWhiteSpace(condition) ? BaseQuery.DELETE_ALL<T>(table) : BaseQuery.DELETE_WHERE<T>(new string[] { table, condition }))
                    : BaseQuery.DELETE_FIRST_WHERE<T>(new string[] { table, condition });

                SqlUtil.ExecuteDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Run a stored procedure or sql query 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public void ExecuteSQL(CommandType commandType, string statement, Dictionary<string, string> parameters = null)
        {
            try
            {
                switch (commandType)
                {
                    case CommandType.StoredProcedure:
                        SqlUtil.ExecuteStoredProc(statement, parameters);
                        break;
                    case CommandType.Text:
                        SqlUtil.ExecuteDynamicQuery(statement);
                        break;
                    case CommandType.TableDirect:
                        throw new Exception("Command type 'TableDirect' not implemented yet.");
                    default:
                        throw new Exception("Command type not recognized.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Run a stored procedure or sql query check
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public bool ExecuteSQLCheck(CommandType commandType, string statement, Dictionary<string, string> parameters = null)
        {
            try
            {
                switch (commandType)
                {
                    case CommandType.StoredProcedure:
                        return SqlUtil.CheckStoredProc(statement, parameters);
                    case CommandType.Text:
                        return SqlUtil.CheckDynamicQuery(statement);
                    case CommandType.TableDirect:
                        throw new Exception("Command type 'TableDirect' not implemented yet.");
                    default:
                        throw new Exception("Command type not recognized.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        //TODO: Figure out QueryUtil.Translate()
        /// <summary>
        /// Finds first entity by expression, if any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            try
            {
                string query = expression == null
                    ? BaseQuery.SELECT_FIRST_FROM<T>()
                    : BaseQuery.SELECT_FIRST_FROM<T>(QueryUtil.Translate(expression));

                return SqlUtil.GetInfo<T>(query, null, true);
            }
            catch (Exception ex)
            {
                // TODO: Replace catch-block with ==> throw new Exception(CustomErrorResponse(ex));
                // Default to query all records, then apply predicate -- Need to figure out the try section
                return SqlUtil.GetMultipleInfo<T>(BaseQuery.SELECT_FROM<T>(), null, true).FirstOrDefault(expression.Compile());
            }
        }

        /// <summary>
        /// Finds entity by id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById<T>(int id) where T : new()
        {
            try
            {
                return SqlUtil.GetInfo<T>(BaseQuery.SELECT_FROM_WHERE<T>("Id = " + id), null, true);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Finds entity by key based off column associated with a Primary Key attribute
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetByKey<T>(object key) where T : new()
        {
            try
            {
                return SqlUtil.GetInfo<T>(BaseQuery.SELECT_FROM_WHERE<T>(typeof(T).GetProperties().First(x => x.HasPrimaryKeyAttribute()).Name + " = " + key), null, true);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Insert<T>(T entity) where T : new()
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("entity");

                string query = BaseQuery.INSERT<T>(entity.ToInsertQuery());

                SqlUtil.ExecuteDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Toggles the Flag Attribute active or inactive.
        /// </summary>
        /// <param name="entity"></param>
        public void MarkActive<T>(int id, bool isActive) where T : new()
        {
            try
            {
                if (id == 0) throw new ArgumentNullException("id");

                string query = BaseQuery.MARK_ACTIVE<T>(isActive, id);

                SqlUtil.ExecuteDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        //TODO: Figure out QueryUtil.Translate()
        /// <summary>
        /// Returns a list of sorted entities associated with Class T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortDirection"></param>
        /// <param name="sortValue"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<T> SortedTable<T>(string sortDirection, string sortValue, int? recordsToSkip = null, int? recordsToTake = null, Expression<Func<T, bool>> expression = null) where T : new()
        {
            try
            {
                string query = expression == null
                ? BaseQuery.SELECT_FROM_ORDER_BY<T>(sortDirection, sortValue)
                : BaseQuery.SELECT_FROM_WHERE_ORDER_BY<T>(sortDirection, sortValue, QueryUtil.Translate(expression));

                if (recordsToSkip.HasValue)
                {
                    query = BaseQuery.APPEND_SKIP(query, recordsToSkip.Value);

                    if (recordsToTake.HasValue) query = BaseQuery.APPEND_FETCH(query, recordsToTake.Value);
                }

                return SqlUtil.GetMultipleInfo<T>(query, null, true);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        /// <summary>
        /// Returns a list of all entities associated with class T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<T> Table<T>(string query = "") where T : new()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query)) query = BaseQuery.SELECT_FROM<T>();

                return SqlUtil.GetMultipleInfo<T>(query, null, true);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }

        //TODO: Figure out QueryUtil.Translate()
        /// <summary>
        /// Returns a list of all entities associated with class T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<T> Table<T>(Expression<Func<T, bool>> expression) where T : new()
        {
            try
            {
                var condition = QueryUtil.Translate(expression);
                return SqlUtil.GetMultipleInfo<T>(BaseQuery.SELECT_FROM_WHERE<T>(condition), null, true);
            }
            catch (Exception ex)
            {
                // TODO: Replace catch-block with ==> throw new Exception(CustomErrorResponse(ex));
                // Default to query all records, then apply predicate
                return SqlUtil.GetMultipleInfo<T>(BaseQuery.SELECT_FROM_WHERE<T>(), null, true).Where(expression.Compile()).ToList();
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Update<T>(T entity, Expression<Func<T, bool>> expression = null) where T : new()
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("entity");

                string condition = expression == null ? "" : QueryUtil.Translate(expression);

                string query = BaseQuery.UPDATE_WHERE<T>(entity.ToUpdateQuery(condition));
                SqlUtil.ExecuteDynamicQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(CustomErrorResponse(ex));
            }
        }
        #endregion

        #region private methods
        #endregion
    }

}
