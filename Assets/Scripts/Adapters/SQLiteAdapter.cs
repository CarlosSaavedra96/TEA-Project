using UnityEngine;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using Entities.Utils;

namespace Entities.Adapters
{
    public class SQLiteAdapter
    {
        private static SQLiteAdapter instance = null;
        private IDbConnection connection;
        private string selectQuery = "*";
        private string whereQuery = "";
        public delegate void actionQuery();

        private SQLiteAdapter()
        {
        }

        public void Connect()
        {
            if (connection == null)
            {
                Debug.Log("Connected");
                connection = (IDbConnection)new SqliteConnection("URI=file:" + Functions.GetPath("Database", Constants.dataBaseFileName));
                connection.Open();
                Debug.Log(connection);
            }
        }

        public static SQLiteAdapter NewInstance()
        {
            if (instance == null)
            {
                instance = new SQLiteAdapter();
            }
            return instance;
        }

        public void Select(string selectQuery)
        {
            CheckValueSegment(
                this.selectQuery.Equals("*"),
                () => {
                    this.selectQuery = selectQuery;
                }, () => {
                    this.selectQuery = ", " + selectQuery;
                });
        }

        public void Select(string[] selectQuery)
        {
            CheckValueSegment(
                this.selectQuery.Equals("*"),
                () => {
                    this.selectQuery = string.Join(", ", selectQuery);
                },
                () => {
                    this.selectQuery += ", " + string.Join(", ", selectQuery);
                });
        }

        public void Where(string whereQuery)
        {
            this.whereQuery += whereQuery;
        }

        public void WhereAnd(string whereQuery)
        {
            CheckValueSegment(
                this.selectQuery.Equals(""),
                () => {
                    this.whereQuery = whereQuery;
                },
                () => {
                    this.whereQuery += " AND " + whereQuery;
                });
        }

        public void WhereOr(string whereQuery)
        {
            CheckValueSegment(
                this.selectQuery.Equals(""),
                () => {
                    this.whereQuery = whereQuery;
                },
                () => {
                    this.whereQuery += " OR " + whereQuery;
                });
        }

        public void Where(string field, string value, string op)
        {
            this.whereQuery += field + " " + op + " " + value;
        }

        public void WhereAnd(string field, string value, string op)
        {
            CheckValueSegment(
                this.selectQuery.Equals(""),
                () => {
                    this.whereQuery = field + " " + op + " " + value;
                },
                () => {
                    this.whereQuery += " AND " + field + " " + op + " " + value;
                });
        }

        public void WhereOr(string field, string value, string op)
        {
            CheckValueSegment(
                this.selectQuery.Equals(""),
                () => {
                    this.whereQuery = field + " " + op + " " + value;
                },
                () => {
                    this.whereQuery += " OR " + field + " " + op + " " + value;
                });
        }

        public int Insert(string[] values, string table)
        {
            return QueryNonQuery("INSERT INTO " + table + " VALUES (" + string.Join(", ", values) + ")");
        }

        public int Insert(string[] fields, string[] values, string table)
        {
            return QueryNonQuery("INSERT INTO " + table + "(" + string.Join(", ", fields) + ")" + " VALUES (" + string.Join(", ", values) + ")");
        }

        public int Delete(string table)
        {
            return QueryNonQuery("DELETE FROM " + table);
        }

        public int Delete(string condition, string table)
        {
            return QueryNonQuery("DELETE FROM " + table + " WHERE " + condition);
        }

        public int Update(string fieldQuery, string table)
        {
            return QueryNonQuery("UPDATE " + table + " SET " + fieldQuery);
        }

        public int Update(string condition, string fieldQuery, string table)
        {
            return QueryNonQuery("UPDATE " + table + " SET " + fieldQuery + " WHERE " + condition);
        }

        public List<string[]> Execute(string table)
        {
            string queryString = "SELECT " + selectQuery + " FROM  " + table;
            if (!whereQuery.Equals(""))
            {
                queryString += " WHERE " + whereQuery;
            }
            return Query(queryString);
        }

        private List<string[]> Query(string queryString)
        {
            IDbCommand queryCommand;
            IDataReader result;
            List<string[]> result_list = new List<string[]>();
            Connect();
            using (queryCommand = this.connection.CreateCommand())
            {
                queryCommand.CommandText = queryString;
                result = queryCommand.ExecuteReader();
                while (result.Read())
                {
                    var element = new string[result.FieldCount];
                    for (var c = 0; c < result.FieldCount; c++)
                    {
                        element[c] = result.GetValue(c).ToString();
                    }
                    result_list.Add(element);
                }
            }
            result.Close();
            result = null;
            queryCommand.Dispose();
            queryCommand = null;
            connection.Dispose();
            connection.Close();
            connection = null;
            selectQuery = "*";
            whereQuery = "";
            return result_list;
        }

        private int QueryNonQuery(string queryString)
        {
            IDbCommand queryCommand;
            int result;
            Connect();
            using (queryCommand = connection.CreateCommand())
            {
                queryCommand.CommandText = queryString;
                result = queryCommand.ExecuteNonQuery();
            }
            queryCommand.Dispose();
            queryCommand = null;
            connection.Dispose();
            connection.Close();
            connection = null;
            selectQuery = "*";
            whereQuery = "";
            return result;
        }

        private void CheckValueSegment(bool condition, actionQuery actionCorrect, actionQuery actionInvalid)
        {
            if (condition)
            {
                actionCorrect();
            }
            else
            {
                actionInvalid();
            }
        }

        public IDbConnection GetConnection ()
        {
            return connection;
        }
    }
}