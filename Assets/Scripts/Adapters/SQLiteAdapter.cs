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

    public void Insert (string[] values, string table)
    {
        string insertQuery = "INSERT INTO " + table + " VALUES (" + string.Join(", ", values) + ")";
    }

    public void Insert(string[] fields, string[] values, string table)
    {
        string insertQuery = "INSERT INTO " + table + "(" + string.Join(", ", fields) + ")" + " VALUES (" + string.Join(", ", values) + ")";
    }

    public void Delete(string table)
    {
        string deleteQuery = "DELETE FROM " + table;
    }

    public void Delete(string condition, string table)
    {
        string delteQuery = "DELETE FROM " + table + " WHERE " + condition;
    }

    public void Update(string fieldQuery, string table)
    {
        string updateQuery = "UPDATE " + table + " SET " + fieldQuery;
    }

    public void Update(string condition, string fieldQuery, string table)
    {
        string updateQuery = "UPDATE " + table + " SET " + fieldQuery + " WHERE " + condition;
    }

    public void Execute (string table)
    {
        string queryString = "SELECT " + this.selectQuery + " FROM  " + table;
        if (!this.whereQuery.Equals(""))
        {
            queryString = " WHERE " + this.whereQuery;
        }

        this.selectQuery = "";
        this.whereQuery = "";
    }

    public void Query(string queryString)
    {
        
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