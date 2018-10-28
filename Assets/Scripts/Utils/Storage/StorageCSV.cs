using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Entities.Utils;

namespace Entities.Utils.Storage
{
    public static class StorageCSV
    {
        public static void Save (string filename, List<string[]> data)
        {
            StreamWriter CSVFile = File.CreateText(Functions.GetPath("Resources", filename));
            for (int c = 0; c < data.Count; c++)
            {
                if (c == 0)
                {
                    CSVFile.Write(string.Join(",", data[c]));
                } else
                {
                    CSVFile.Write("\n" + string.Join(",", data[c]));
                }
            }
            CSVFile.Close();
            Debug.Log("The file was stored succesfully!!!!");
        }

        public static void SaveNewRow(string filename, string[] row)
        {
            StreamWriter CSVFile = new StreamWriter(Functions.GetPath("Resources", filename), true);
            CSVFile.Write("\n" + string.Join(",", row));
            CSVFile.Close();
            Debug.Log("The file was updated succesfully!!!!");
        }

        public static List<string[]> Load (string filename)
        {
            string[] data;
            List<string[]> dataResult = new List<string[]>();
            TextAsset CSVFile = Resources.Load<TextAsset>(filename);
            data = CSVFile.text.Split(new char[] { '\n' });

            foreach (var row in data)
            {
                string[] fields = row.Split(new char[] { ',' });
                dataResult.Add(fields);
            }
            dataResult.RemoveAt(0);
            return dataResult;
        }

        public static void ResetCSV (string filename, string[] fields)
        {
            StreamWriter CSVFile = File.CreateText(Functions.GetPath("Resources", filename));
            CSVFile.Write(string.Join(",", fields));
            CSVFile.Close();
            Debug.Log("The file was reseted succesfully!!!!");
        }
    }
}