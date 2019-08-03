using System;
using System.Data;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace CometX.NETCore.Repository
{
    public interface ICometXRepository
    {
        bool CheckTable<T>(Expression<Func<T, bool>> expression);
        void Delete<T>(T entity) where T : new();
        void Delete<T>(Expression<Func<T, bool>> expression = null, bool deleteAll = false);
        void ExecuteSQL(CommandType commandType, string statement, Dictionary<string, string> parameters = null);
        bool ExecuteSQLCheck(CommandType commandType, string statement, Dictionary<string, string> parameters = null);
        void Insert<T>(T entity) where T : new();
        T GetById<T>(int id) where T : new();
        T FirstOrDefault<T>(Expression<Func<T, bool>> expression = null) where T : new();
        List<T> SortedTable<T>(string sortDirection, string sortValue, int? recordsToSkip = null, int? recordsToTake = null, Expression<Func<T, bool>> expression = null) where T : new();
        List<T> Table<T>(string query = "") where T : new();
        List<T> Table<T>(Expression<Func<T, bool>> expression) where T : new();
        void Update<T>(T entity, Expression<Func<T, bool>> expression = null) where T : new();
    }
}
