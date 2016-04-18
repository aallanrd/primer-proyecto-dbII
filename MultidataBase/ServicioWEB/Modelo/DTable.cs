using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
    public class deleteTable
    {
        public int cID { get; set; }

        public string table_name { get; set; }


        public deleteTable() { }

        public deleteTable(int cID, string nombre)
        {
            this.cID = cID;
            this.table_name = nombre;

        }
    }
}