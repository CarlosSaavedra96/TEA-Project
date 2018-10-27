using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

namespace Entities.Controllers
{
    public class Storage : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            string conn = "URI=file:" + Application.dataPath + "/Database/TeaProjectDB.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT UserId, FirstName, LastName " + "FROM User";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int userid = reader.GetInt32(0);
                string firstname = reader.GetString(1);
                string lastname = reader.GetString(2);

                Debug.Log("Id= " + userid + "  FirstName =" + firstname + "  LastName =" + lastname);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
