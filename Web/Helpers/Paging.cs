using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helpers
{
    public class Paging
    {
        public int Id { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public double TotalPages { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalResults { get; set; }
    }
}