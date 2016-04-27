using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class QueryVM
    {
        public int cID { get; set; }

        public string order_by { get; set; }

        public string querys { get; set; }

        public string join_on { get; set; }

        public QueryVM() { }

        public QueryVM(int cID, string order_by ,string join_on, string querys)
        {
            this.cID = cID;
            this.order_by = order_by;
            this.join_on = join_on;
            this.querys = querys;
        }
    }
}