using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASPData
{
    public class SQLHelper
    {
        ASPData asp = new ASPData();

        public bool CheckPermission(string Username, string ObjectID)
        {
            var dicParams = new Dictionary<string, object>
                {
                    { "@Member_ID", Username },
                    { "@Object_ID", ObjectID },
                };

            var parameters = new DynamicParameters(dicParams);

            DataTable dtCheck = ExecQueryDataAsDataTable("SELECT * FROM L00PERMISSIONASP WHERE Member_ID = @Member_ID AND Object_ID = @Object_ID", dicParams);

            if (dtCheck.Rows.Count == 0)
                return false;

            return true;
        }

        public long Insert<T>(T entityToInsert) where T : class
        {


            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                long re = 0;
                try
                {
                    re = connection.Insert(entityToInsert);
                }
                catch (Exception ex)
                {
                    re = 0;
                    throw (ex);
                }
                return re;
            }
        }

        public bool Update<T>(T entityToUpdate) where T : class
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                var result = false;
                try
                {
                    result = connection.Update(entityToUpdate);
                }
                catch (Exception ex)
                {
                    result = false;
                    throw (ex);
                }
                return result;
            }
        }

        public bool Delete<T>(T entityToDelete) where T : class
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                bool success = false;
                try
                {
                    success = connection.Delete(entityToDelete);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return success;
            }
        }

        //public void BulkInsert<T>(IEnumerable<T> data)
        //{
        //    using (var conn = new SqlConnection("{connection string}"))
        //    {
        //        conn.Open();

        //        using (var bulkCopy = new SqlBulkCopy(conn))
        //        {
        //            bulkCopy.BulkCopyTimeout = 0;
        //            bulkCopy.BatchSize = 500;
        //            bulkCopy.DestinationTableName = "Widgets";
        //            bulkCopy.EnableStreaming = true;

        //            using (var dataReader = data.ToDataReader())
        //            {
        //                bulkCopy.WriteToServer(dataReader);
        //            }
        //        }
        //    }
        //}
        public DataTable ExecProcedureDataAsDataTable(string ProcedureName, object parametter = null)
        {
            string connStr = asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS);
            using (var connection = new SqlConnection(connStr))
            {
                connection.Open();
                DataTable table = new DataTable();
                try
                {
                    var reader = connection.ExecuteReader(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);

                    table.Load(reader);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                return table;
            }
        }

        public async Task<DataTable> ExecProcedureDataAsyncAsDataTable(string ProcedureName, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                var reader = await c.ExecuteReaderAsync(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            });

        }
        public DataTable ExecQueryDataAsDataTable(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                var reader = connection.ExecuteReader(T_SQL, param: parametter, commandType: CommandType.Text);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
        public async Task<DataTable> ExecQueryDataAsyncAsDataTable(string T_SQL, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                var reader = await c.ExecuteReaderAsync(T_SQL, param: parametter, commandType: CommandType.Text);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            });
        }

        #region add dataset
        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }

        public DataSet ExecProcedureDataAsDataSet(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                int a = connection.ConnectionTimeout;
                connection.Open();
                DataSet set = new DataSet();
                try
                {
                    var reader = connection.ExecuteReader(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    set = ConvertDataReaderToDataSet(reader);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                return set;
            }
        }

        public async Task<DataSet> ExecProcedureDataAsyncAsDataSet(string ProcedureName, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                var reader = await c.ExecuteReaderAsync(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);
                DataSet set = new DataSet();
                set = ConvertDataReaderToDataSet(reader);
                return set;
            });

        }

        public DataSet ExecQueryDataAsDataSet(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                var reader = connection.ExecuteReader(T_SQL, param: parametter, commandType: CommandType.Text);
                DataSet set = new DataSet();
                set = ConvertDataReaderToDataSet(reader);
                return set;
            }
        }
        public async Task<DataSet> ExecQueryDataAsyncAsDataSet(string T_SQL, object parametter = null)
        {
            return await WithConnection(async c =>
            {
                var reader = await c.ExecuteReaderAsync(T_SQL, param: parametter, commandType: CommandType.Text);
                DataSet set = new DataSet();
                set = ConvertDataReaderToDataSet(reader);
                return set;
            });
        }
        #endregion

        public IEnumerable<T> ExecProcedureData<T>(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.Query<T>(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);
            }
        }

        public T ExecProcedureDataFistOrDefault<T>(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> ExecProcedureDataAsync<T>(string ProcedureName, object parametter = null)
        {

            return await WithConnection(async c =>
            {
                return await c.QueryAsync<T>(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            });


        }

        public T ExecProcedureDataFirstOrDefaultAsync<T>(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.QueryFirstOrDefaultAsync<T>(ProcedureName, parametter, commandType: CommandType.StoredProcedure).Result;
            }
        }

        public int ExecProcedureNonData(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                //return affectedRows 
                return connection.Execute(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            }
        }

        public int ExecProcedureNonDataAsync(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                //return affectedRows 
                return connection.ExecuteAsync(ProcedureName, parametter, commandType: CommandType.StoredProcedure).Result;
            }
        }

        public IEnumerable<T> ExecQueryData<T>(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.Query<T>(T_SQL, parametter, commandType: CommandType.Text);
            }
        }

        public T ExecQueryDataFistOrDefault<T>(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(T_SQL, parametter, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> ExecQueryDataAsync<T>(string T_SQL, object parametter = null)
        {

            return await WithConnection(async c =>
            {
                return await c.QueryAsync<T>(T_SQL, parametter, commandType: CommandType.Text);
            });


        }

        public T ExecQueryDataFirstOrDefaultAsync<T>(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.QueryFirstOrDefaultAsync<T>(T_SQL, parametter, commandType: CommandType.Text).Result;
            }
        }

        public int ExecQueryNonData(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.Execute(T_SQL, parametter, commandType: CommandType.Text);
            }
        }

        public async Task<int> ExecQueryNonDataAsync(string T_SQL, object parametter = null)
        {

            return await WithConnection(async c =>
            {
                return await c.ExecuteAsync(T_SQL, parametter, commandType: CommandType.Text);
            });



        }

        public async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {

            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
            }

        }

        public object ExecProcedureSacalar(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.ExecuteScalar<object>(ProcedureName, parametter, commandType: CommandType.StoredProcedure);
            }

        }

        public object ExecProcedureSacalarAsync(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.ExecuteScalarAsync<object>(ProcedureName, parametter, commandType: CommandType.StoredProcedure).Result;
            }

        }

        public object ExecQuerySacalar(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.ExecuteScalar<object>(T_SQL, parametter, commandType: CommandType.Text);
            }

        }

        public object ExecQuerySacalarAsync(string T_SQL, object parametter = null)
        {
            using (var connection = new SqlConnection(asp.ASPDecrypt(configDatabase.CONNECTION_STRINGS)))
            {
                connection.Open();
                return connection.ExecuteScalarAsync<object>(T_SQL, parametter, commandType: CommandType.Text).Result;
            }

        }

    }
}
