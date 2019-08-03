using CometX.Attributes.RelationalDBAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CometX.ConsoleApp.Models.Authentication
{
    public class Token
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [PropertyNotMapped]
        public virtual string CreatedOnString { get; set; }

        public void SetDateStrings()
        {
            CreatedOnString = CreatedOn.ToString("MM/dd/yyyy");
        }
        [DBColumn("Key")]
        public virtual string Key { get; set; }
        public virtual DateTime IssuedOn { get; set; }
        public virtual DateTime ExpiresOn { get; set; }
        public virtual int AuthorizedOriginId { get; set; }
        //[PropertyNotMapped]
        //public virtual AuthorizedOrigin AuthorizedOrigin { get; set; }
    }
}
