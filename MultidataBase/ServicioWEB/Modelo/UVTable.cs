using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
    public class UVTable
    {
        public int cID { get; set; }

        public string table_name { get; set; }

        public string values { get; set; }

        public UVTable() { }

        public UVTable(int cID, string nombre, string values)
        {
            this.cID = cID;
            this.table_name = nombre;
            this.values = values;
        }
    }
}