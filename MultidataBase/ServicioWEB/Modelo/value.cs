using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
    public class Value
    {
        public string Vcol { get; set; }
        public string Vval { get; set; }

       
        public Value()
        {

        }

        public Value(string name, string value)
        {
            this.Vcol = name;
            this.Vval = value;
            
        }
    }
}