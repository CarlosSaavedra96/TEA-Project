using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Adapters;
using System.Data;

namespace Entities.Models
{
    public abstract class ModelBase
    {
        internal SQLiteAdapter connection;
        internal string name;

        public ModelBase()
        {
            connection = SQLiteAdapter.NewInstance();
        }

        public List<string[]> GetAll ()
        {
            return connection.Execute(name);
        }

        public List<string[]> GetBy (string[] fields)
        {
            connection.Select(fields);
            return connection.Execute(name);
        }

        public List<string[]> GetBy(string fields)
        {
            connection.Select(fields);
            return connection.Execute(name);
        }

        public List<string[]> GetBy(string condition, string[] fields)
        {
            connection.Select(fields);
            connection.Where(condition);
            return connection.Execute(name);
        }

        public List<string[]> GetBy(string condition, string fields)
        {
            connection.Select(fields);
            connection.Where(condition);
            return connection.Execute(name);
        }

        public int Insert(string[] values)
        {
            return connection.Insert(values, name);
        }

        public int Insert(string[] fields, string[] values)
        {
            return connection.Insert(fields, values, name);
        }

        public int Update(string fieldQuery)
        {
            return connection.Update(fieldQuery, name);
        }

        public int Update(string condition, string fieldQuery)
        {
            return connection.Update(condition, fieldQuery, name);
        }

        public int Delete()
        {
            return connection.Delete(name);
        }

        public int Delete(string condition)
        {
            return connection.Delete(condition, name);
        }
    }
}
