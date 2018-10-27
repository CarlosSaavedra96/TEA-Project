using UnityEngine;
using System;

namespace Entities.Utils
{
    public class Functions
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
    }
}