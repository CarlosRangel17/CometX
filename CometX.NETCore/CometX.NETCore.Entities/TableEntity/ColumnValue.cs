using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CometX.NETCore.Entities.TableEntity
{
    public class ColumnValue
    {
        public List<Value> Values { get; set; }
        public Dictionary<string, string> Keys { get; set; }
    }
}
