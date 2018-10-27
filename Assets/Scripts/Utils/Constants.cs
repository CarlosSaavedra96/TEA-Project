using UnityEngine;
using System;

namespace Entities.Utils
{
    public struct Constants
    {
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