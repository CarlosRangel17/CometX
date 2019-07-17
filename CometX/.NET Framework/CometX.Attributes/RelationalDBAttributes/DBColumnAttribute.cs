using System;

namespace CometX.Attributes.RelationalDBAttributes
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
