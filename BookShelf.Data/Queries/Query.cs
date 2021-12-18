using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Data.Queries
{
    public class Query
    {
        public int Limit { get; set; } = 20;
        public int Offset { get; set; }
        public string OrderBy { get; set; }
        public string SortDirection { get; set; }
    }
}
