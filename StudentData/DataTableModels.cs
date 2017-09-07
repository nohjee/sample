using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentData
{ 
    public class DatatableRequest
    {
        public DatatableSearch Search { get; set; }
        public string Name { get; set; }
    }

    public class DatatableSearch
    {
        public string Value { get; set; }
    }

    public class DatatableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class SchoolListRequest
    {
        public string Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public List<DatatableRequest> Columns { get; set; }
        public List<DatatableOrder> Order { get; set; }
    }
}