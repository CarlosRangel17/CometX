using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CometX.Entities.TableEntity
{
    public class ColumnValue
    {
        public List<Value> Values { get; set; }
        public Dictionary<string, string> Keys { get; set; }
    }
}
