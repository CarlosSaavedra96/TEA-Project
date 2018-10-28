using UnityEngine;
using System;

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
            return Application.persistentDataPath + filename;
#elif UNITY_IPHONE
            return Application.persistentDataPath + "/" + filename;
#else
            return Application.dataPath + "/" + filename;
#endif
        }
    }
}