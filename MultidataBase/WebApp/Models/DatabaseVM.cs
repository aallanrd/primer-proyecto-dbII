using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class DatabaseVM
    {
        public int idC { get; set; }

        public string db_name { get; set; }

        public DatabaseVM() { }

        public DatabaseVM(int idC, string db_name)
        {
            this.db_name = db_name;
            this.idC = idC;
        }
    }
}