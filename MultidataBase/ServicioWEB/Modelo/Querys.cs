using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
    public class Querys
    {
        public int cID { get; set; }

        public string values { get; set; }

        public Querys() { }

        public Querys(int cID, string nombre, string values)
        {
            this.cID = cID;
            this.values = values;
        }
    }
}