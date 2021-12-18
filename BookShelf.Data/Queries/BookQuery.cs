using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Data.Queries
{
    public class BookQuery : Query
    {

        public string Title { get; set; }

        public string Author { get; set; }

        /// <summary>
        /// null - все, true - отданные, false - доступные
        /// </summary>
        public bool? IsAbsent { get; set; }
    }
}
