using ServicioWEB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioWEB.Controladores;
using System.Collections;
using Newtonsoft.Json;

namespace ServicioWEB
{
    class Multidatabase : InterfaceDB
    {

        aSQLController controlSQL = new aSQLController();
        aMariaController controlMaria = new aMariaController();
        aMongoController controlMongo = new aMongoController();


        // Inserta (si esta disponible), una nueva conexión dentro 
        // de metadatadb
        public string includeDB(string jsonIDB)
        {
            /*
            *string type, string user, string pass, string server,int port,string database
            *Creamos un nuevo modelo de una base de datos a incluir.
            */

            // Deserializamos el JSOn en un modelo de base de datos
            DBModel model = JsonConvert.DeserializeObject<DBModel>(jsonIDB);

            switch (model.dbType)
            {
                case "MariaDB":
                    string cMa = controlMaria.check(model);
                    if (cMa.Equals("Connected"))
                    {
                        return controlMaria.includeDB(model);
                    }
                    else
                    {
                        return "{ 'msg' : 'No hay conexion con esta instancia de Maria' }";
                    }

                case "MongoDB":
                    string cMo = controlMongo.check(model);
                    if (cMo.Equals("Connected"))
                    {
                        return controlMaria.includeDB(model);
                    }
                    else
                    {
                        return "{ 'msg' : 'No hay conexion con esta instancia de Mongo' }";
                    }


                case "SQLDB":
                    string cS = controlSQL.check(model);
                    if (cS.Equals("Connected"))
                    {
                        return controlMaria.includeDB(model);
                    }
                    else
                    {
                        return "{ 'msg' : 'No hay conexion con esta instancia de SQL' }";
                    }


                default: return "Cant Check";
            }

        }

        //Crear una nueva base de datos en cualquier servidor/instancia registrada
        public string createDB(string jsonCDB)
        {
           // string json = "{ 'cID': '1', 'db_name':'MiDB' }";

            //Deserializa el JSOn
            Database db = JsonConvert.DeserializeObject<Database>(jsonCDB);

            //Obtiene la conexión correspondiente
            DBModel  m  =  controlMaria.getConnection(db.idC);

            //String db_type,String db_name
            switch (m.dbType)
            {
                case "MariaDB": return controlMaria.createDB(m,db.db_name);

                case "MongoDB": return controlMongo.createDB(m,db.db_name);

                case "SQLDB":   return controlSQL.  createDB(m,db.db_name);

                default: return "No existe conexion posible con este tipo de DB";
            }
           

        }

        //Crea una nueva tabla en el servidor de BD seleccionado.
        public string createTable(string jsonCT)
        {
            //int iC, string name, ArrayList columnas
            // string json = "{ 'cID': 'idConexion', 'table_name':'TableName', columnas:	
            //[{ alias:	“alias”, nombre:“nombre”,tipo:  “tipo”, null:	true / false },...]}";

            // Tabla por alias a cada base de datos?

            Table table = JsonConvert.DeserializeObject<Table>(jsonCT);
            int idC = table.cID;
            string columnas = table.columnas;   
            var cll = JsonConvert.DeserializeObject<List<Modelo.Column>>(columnas);

            DBModel model = controlMaria.getConnection(idC);
            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.createTable (model, table.table_name, cll);
                    case "MongoDB": return controlMongo.createTable (model, table.table_name, cll);
                    case "SQLDB": return controlSQL.createTable     (model, table.table_name, cll);
                    default: return "Cant Check";
                }

            }
            else
            {
                return "Not checked";
            }

            
        }

        //Elimina una tabla en el servidor de BD seleccionado.
        public string deleteTable(string jsonDT)
        {
            //int iC, string name, ArrayList columnas
            // string json = "{ 'cID': 'idConexion', 'table_name':'TableName', columnas:	
            //[{ alias:	“alias”, nombre:“nombre”,tipo:  “tipo”, null:	true / false },...]}";
            DTable table = JsonConvert.DeserializeObject<DTable>(jsonDT);
            int idC = table.cID;
 
            DBModel model = controlMaria.getConnection(idC);
            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.deleteTable (model, table.table_name);
                    case "MongoDB": return controlMongo.deleteTable (model, table.table_name);
                    case "SQLDB": return controlSQL.deleteTable     (model, table.table_name);
                    default: return "Cant Check";
                }

            }
            else
            {
                return "Not checked";
            }
        }

        public string getConecctions()
        {

              string b = controlMaria.consultDB();
              return b;
            //return "Connected";
        }

        public string checkConnection(int connectionID) 
        {
            DBModel model =  controlMaria.getConnection(connectionID);
            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.check(model);
                    case "MongoDB": return controlMongo.check(model);
                    case "SQLDB": return controlSQL.check(model);
                    default: return "Cant Check";
                }
               
            }
            else
            {
                return "Not checked";
            }
           
        }


        //Ejecuta todas las querys que vengan por parámetro en el JSON
        public string multipleQuery(string jsonMQ)
        {
            Querys querys = JsonConvert.DeserializeObject<Querys>(jsonMQ);
            int idC = querys.cID;
            var cll = JsonConvert.DeserializeObject<List<Modelo.Query>>(querys.values);
            DBModel model = controlMaria.getConnection(idC);

            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.multipleQuery(model, cll);
                    case "MongoDB": return controlMongo.multipleQuery(model, cll);
                    case "SQLDB": return controlSQL.multipleQuery(model, cll);
                    default: return "Cant Check";
                }

            }
            else
            {
                return "Not checked";
            }
        }

        public string insertValuesTable(string jsonIVT)
        {
            IVTable table = JsonConvert.DeserializeObject<IVTable>(jsonIVT);
            int idC = table.cID;
            string valores = table.values;
            var cll = JsonConvert.DeserializeObject<List<Modelo.Value>>(valores);

            DBModel model = controlMaria.getConnection(idC);
            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.insertValuesTable(model, table.table_name, cll);
                    case "MongoDB": return controlMongo.insertValuesTable(model, table.table_name, cll);
                    case "SQLDB": return controlSQL.insertValuesTable(model, table.table_name, cll);
                    default: return "Cant Check";
                }

            }
            else
            {
                return "Not checked";
            }
        }

        public string updateValuesTable(string jsonUVT)
        {
            IVTable table = JsonConvert.DeserializeObject<IVTable>(jsonUVT);
            int idC = table.cID;
            string valores = table.values;
            var cll = JsonConvert.DeserializeObject<List<Modelo.Value>>(valores);

            DBModel model = controlMaria.getConnection(idC);
            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.updateValuesTable(model, table.table_name, cll);
                    case "MongoDB": return controlMongo.updateValuesTable(model, table.table_name, cll);
                    case "SQLDB": return controlSQL.updateValuesTable(model, table.table_name, cll);
                    default: return "Cant Check";
                }

            }
            else
            {
                return "Not checked";
            }
        }

        public string deleteValuesTable(string jsonDVT)
        {
            IVTable table = JsonConvert.DeserializeObject<IVTable>(jsonDVT);
            int idC = table.cID;
            string valores = table.values;
            var cll = JsonConvert.DeserializeObject<List<Modelo.Value>>(valores);

            DBModel model = controlMaria.getConnection(idC);
            if (model != null)
            {
                switch (model.dbType)
                {
                    case "MariaDB": return controlMaria.deleteValuesTable(model, table.table_name, cll);
                    case "MongoDB": return controlMongo.deleteValuesTable(model, table.table_name, cll);
                    case "SQLDB": return controlSQL.deleteValuesTable(model, table.table_name, cll);
                    default: return "Cant Check";
                }

            }
            else
            {
                return "Not checked";
            }
        }
    }
}
