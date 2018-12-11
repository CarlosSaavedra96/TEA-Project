using UnityEngine;
using System;
using System.IO;

namespace Entities.Utils
{
    public static class Functions
    {
        public static string GetFieldTypeName (byte type)
        {
            string typeName = "Unsupport";
            switch (type)
            {
                case (byte) Constants.FieldType.Float:
                    typeName = "Float";
                    break;
                case (byte) Constants.FieldType.Integer:
                    typeName = "Integer";
                    break;
                case (byte) Constants.FieldType.JSON:
                    typeName = "JSON";
                    break;
                case (byte) Constants.FieldType.JSONArray:
                    typeName = "JSONArray";
                    break;
                case (byte)Constants.FieldType.String:
                    typeName = "String";
                    break;
            }
            return typeName;
        }

        public static string GetPath(string path, string filename)
        {
#if UNITY_EDITOR
            return Application.dataPath + "/" + path + "/" + filename;
#elif UNITY_ANDROID
             string _filepath = Application.persistentDataPath+"/"+ filename;
            if (!File.Exists(_filepath))
            {
                Debug.Log("Check in");
                WWW loadDB = new WWW("jar:file://" + Application.dataPath +
                                     "!/assets/" + filename);

                while (!loadDB.isDone) { }
                File.WriteAllBytes(_filepath, loadDB.bytes);
            }

            return _filepath;
#elif UNITY_IPHONE
            return Application.persistentDataPath + "/" + filename;
#else
            return Application.dataPath + "/" + filename;
#endif
        }
    }
}