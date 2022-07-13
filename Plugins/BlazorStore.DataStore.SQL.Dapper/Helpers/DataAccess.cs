﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BlazorStore.DataStore.SQL.Dapper.Helpers
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using(IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingle<T>(sql, parameters);
            }
        }

        public IEnumerable<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.Query<T>(sql, parameters);
            }
        }

        public void ExecuteCommand<T>(string sql, T parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sql, parameters);
            }
        }
    }
}
