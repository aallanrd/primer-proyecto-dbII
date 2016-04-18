using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
   

    public class Column
    {
        public string name { get; set; }
        public string type { get; set; }

        public int length { get; set; }

        public Column()
        {

        }

        public Column(string name, string type, int length)
        {
            this.name = name;
            this.type = type;
            this.length = length;
        }
    }
}