using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.Movie.lib.sql
{
    // Provides additional information for the SQL database
    internal class SqlMovie : Movie
    {
        public int Id { get; set; }
    }
}
