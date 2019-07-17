using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CometX.Entities.TableEntity
{
    public class Table
    {
        public List<Column> Columns { get; set; }
        public List<ColumnValue> ValuesList { get; set; }

        public Table()
        {
            Columns = new List<Column>();
            ValuesList = new List<ColumnValue>();
        }
    }
}
