using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWEB.Modelo
{
    public class Query
    {

        public string _cName { get; set; }
        public string _table { get; set; 
}
        public Query()
        {

        }
        public Query( string _cName , string _table)
        {
            this._cName = _cName;
            this._table = _table;
        }
    }
}