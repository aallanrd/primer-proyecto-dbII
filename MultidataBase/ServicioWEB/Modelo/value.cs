using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
    public class Value
    {
        public string name { get; set; }
        public string value { get; set; }

       
        public Value()
        {

        }

        public Value(string name, string value)
        {
            this.name = name;
            this.value = value;
            
        }
    }
}