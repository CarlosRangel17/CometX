﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using CometX.NETCore.Entities.TableEntity;
using CometX.NETCore.Entities.GenericEntity;

namespace CometX.NETCore.Service
{
    public interface ICometXService
    {
        bool Any<T>(Expression<Func<T, bool>> expression);
        void Delete<T>(T entity) where T : new();
        void DeleteAll<T>(Expression<Func<T, bool>> expression);
        void DeleteFirst<T>(Expression<Func<T, bool>> expression);
        T FirstOrDefault<T>(Expression<Func<T, bool>> expression = null) where T : new();
        List<T> GetAll<T>(string query = "") where T : new();
        List<T> GetAll<T>(Expression<Func<T, bool>> expression) where T : new();
        T GetById<T>(int id) where T : new();
        T GetByKey<T>(object key) where T : new();
        List<T> GetSortedTable<T>(SortDirection sortDirection, string sortValue = "", Expression<Func<T, bool>> expression = null) where T : new();
        List<T> GetSortedTable<T>(SortDirection sortDirection, string sortValue, int recordsToSkip, int? recordsToTake = null, Expression<Func<T, bool>> expression = null) where T : new();
        void Insert<T>(T entity) where T : new();
        void InsertWithContext<T>(ref T entity) where T : new();
        void MarkActive<T>(int id) where T : new();
        void MarkActiveByKey<T>(object key) where T : new();
        void RunProcedure(string storedProcedure, Lexicon param = null);
        void RunProcedure(string storedProcedure, List<Lexicon> parameters);
        bool RunProcedureCheck(string storedProcedure, Lexicon param = null);
        bool RunProcedureCheck(string storedProcedure, List<Lexicon> parameters);
        void Save<T>(T entity) where T : new();
        void Update<T>(T entity) where T : new();
        void Update<T>(T entity, Expression<Func<T, bool>> expression) where T : new();
    }
}
