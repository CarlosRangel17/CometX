using System;

namespace CometX.NETCore.Attributes.RelationalDBAttributes
{
    public class DBColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public DBColumnAttribute(string name)
        {
            this.Name = name;
        }
    }
}
