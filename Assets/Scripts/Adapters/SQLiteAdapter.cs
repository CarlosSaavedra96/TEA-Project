using UnityEngine;
using UnityEditor;
using System.Data;
using Mono.Data.Sqlite;

public class SQLiteAdapter
{
    private static SQLiteAdapter instance = null;
    private readonly string databasePath = Application.dataPath + "/Database/TeaProjectDB.db";
    private IDbConnection connection;
    private string selectQuery = "*";
    private string whereQuery = "";
    public delegate void actionQuery();
    
    private SQLiteAdapter ()
    {
        connection = (IDbConnection)new SqliteConnection("URI=file:" + this.databasePath);
    }

    public static SQLiteAdapter NewInstance ()
    {
        if (instance == null)
        {
            instance = new SQLiteAdapter();
        }
        return instance;
    }
    
    public void Select (string selectQuery)
    {
        CheckValueSegment(
            this.selectQuery.Equals("*"), 
            () => {
                this.selectQuery = selectQuery;
            }, () => {
                this.selectQuery = ", " + selectQuery;
            });
    }

    public void Select (string[] selectQuery)
    {
        CheckValueSegment(
            this.selectQuery.Equals("*"),
            () => {
                this.selectQuery = string.Join(", ", selectQuery);
            },
            () => {
                this.selectQuery = ", " + string.Join(", ", selectQuery);
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
                this.whereQuery = " AND " + whereQuery;
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
                this.whereQuery = " OR " + whereQuery;
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
                this.whereQuery = " AND " + field + " " + op + " " + value;
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
                this.whereQuery = " OR " + field + " " + op + " " + value;
            });
    }

    public int Insert (string[] values, string table)
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

    public IDataReader Execute (string table)
    {
        string queryString = "SELECT " + selectQuery + " FROM  " + table;
        if (!whereQuery.Equals(""))
        {
            queryString = " WHERE " + whereQuery;
        }

        selectQuery = "";
        whereQuery = "";
        return Query(queryString);
    }

    public IDataReader Query(string queryString)
    {
        IDbCommand queryCommand;
        connection.Open();
        queryCommand = this.connection.CreateCommand();
        queryCommand.CommandText = queryString;
        connection.Close();
        return queryCommand.ExecuteReader();
    }

    private int QueryNonQuery(string queryString)
    {
        IDbCommand queryCommand;
        connection.Open();
        queryCommand = connection.CreateCommand();
        queryCommand.CommandText = queryString;
        connection.Close();
        return queryCommand.ExecuteNonQuery();
    }

    private void CheckValueSegment (bool condition, actionQuery actionCorrect, actionQuery actionInvalid)
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
}