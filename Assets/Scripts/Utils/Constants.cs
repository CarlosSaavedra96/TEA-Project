using UnityEngine;
using System;

namespace Entities.Utils
{
    public static class Constants
    {
        public const string dataBaseFileName = "TeaProjectDB.db";
        public enum FieldType : byte
        {
            Integer = 0,
            String = 1,
            Float = 2,
            JSON = 3,
            JSONArray = 4
        }
    }
}