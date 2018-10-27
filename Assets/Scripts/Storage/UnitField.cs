using UnityEngine;
using System;
using System.Collections;
using Entities.Utils;

namespace Entities.Storage {
    public class UnitField
    {
        private string name;
        private string content;
        private byte type;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public string Type
        {
            get
            {
                return Functions.GetFieldTypeName(type);
            }

            set
            {
                type = byte.Parse(value);
            }

        }

        public UnitField(string name, string content, string type)
        {
            this.name = name;
            this.content = content;
            this.type = Byte.Parse(type);
        }
    }
}
