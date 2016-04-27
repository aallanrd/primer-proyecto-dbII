using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using WebApp.ServiceReference1;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AppController : Controller
    {

        // CLiente del Servicio Web 
        Service1Client client = new Service1Client();

        /*
          1.   /includeDB (https://github.com/aallanrd/primer-proyecto-dbII#includedb)
               @Http Call from View to Call Service API Function : client.includeDB(JSON)
               @Params (string db_type, string username, string pass, string server, 
               string protocol, int port, string alias)
               @Return JSON 
        */

        [HttpPost]
        public JsonResult HttpIncludeDB(string db_type, string username, string pass, string server, string protocol, int port, string alias)
        {

            IncludeDbVm dbV = new IncludeDbVm(db_type, username, pass, server, protocol, port, alias);
            var jsonIDB = JsonConvert.SerializeObject(dbV);
            string x = client.includeDB(jsonIDB);

            return new JsonResult { Data = x };


        }

        /*
    2.   /createDatabase (https://github.com/aallanrd/primer-proyecto-dbII#createdb)
         @Http Call from View to Call Service API Function : client.createDatabase(JSON)
         @Params (int cID, string db_name)
         @Return JSON 
       */

        [HttpPost]
        public JsonResult HttpCreateDB(int cID, string db_name)
        {

            DatabaseVM dbV = new DatabaseVM(cID, db_name);
            var jsonCDB = JsonConvert.SerializeObject(dbV);
            string x = client.createDatabase(jsonCDB);
            return new JsonResult { Data = x };


        }
        /*
    3.   /createTable (https://github.com/aallanrd/primer-proyecto-dbII#createTable)
        @Http Call from View to Call Service API Function : client.createTable(JSON)
        @Params (int cID, string name, string columns)
        @Return JSON 
        */

        [HttpPost]
        public JsonResult HttpCreateTable(int cID, string name, string columns)
        {

            CreateTableVM t = new CreateTableVM(cID, name, columns);
            var jsonCT = JsonConvert.SerializeObject(t);
            string x = client.createTable(jsonCT);
            client.Close();
            return new JsonResult { Data = x };

        }

        /*
       4.   /deleteTable (https://github.com/aallanrd/primer-proyecto-dbII#deleteTable)
           @Http Call from View to Call Service API Function : client.deleteTable(JSON)
           @Params (int cID, string table_name)
           @Return JSON 
           */
        [HttpPost]
        public JsonResult HttpDeleteTable(int cID, string table_name)
        {

            DeleteTableVM t = new DeleteTableVM(cID, table_name);
            var jsonDT = JsonConvert.SerializeObject(t);
            string x = client.deleteTable(jsonDT);
            return new JsonResult { Data = x };

        }
        /*
     5.   /insertValuesTable (https://github.com/aallanrd/primer-proyecto-dbII#deleteTable)
         @Http Call from View to Call Service API Function : client.deleteTable(JSON)
         @Params (int cID, string table_name)
         @Return JSON 
         */
        [HttpPost]
        public JsonResult HttpInsertValueTable(int cID, string table_name, string values)
        {
            InsertTableVM t = new InsertTableVM(cID, table_name, values);
            var jsonIVT = JsonConvert.SerializeObject(t);
            //db_type, db_name
            string x = client.insertValuesTable(jsonIVT);
            return new JsonResult { Data = x };

        }

        /*
        6.   /updateValuesTable (https://github.com/aallanrd/primer-proyecto-dbII#deleteTable)
                 @Http Call from View to Call Service API Function : client.deleteTable(JSON)
                 @Params (int cID, string table_name)
                 @Return JSON 
                 */
        [HttpPost]
        public JsonResult HttpUpdateTable(int cID, string table_name, string values)
        {
            UpdateTableVM t = new UpdateTableVM(cID, table_name, values);
            var jsonAVT = JsonConvert.SerializeObject(t);
            //db_type, db_name
            string x = client.updateValuesTable(jsonAVT);
            return new JsonResult { Data = x };

        }

        /*
     7.   /deleteValuesTable (https://github.com/aallanrd/primer-proyecto-dbII#deleteTable)
         @Http Call from View to Call Service API Function : client.deleteTable(JSON)
         @Params (int cID, string table_name)
         @Return JSON 
         */
        [HttpPost]
        public JsonResult HttpDeleteValueTable(int cID, string table_name, string values)
        {
            DeleteFromTable dFT = new DeleteFromTable(cID, table_name, values);
            var jsonDVT = JsonConvert.SerializeObject(dFT);
            string x = client.deleteValuesTable(jsonDVT);
            return new JsonResult { Data = x };

        }
        /* 7.   /deleteValuesTable(https://github.com/aallanrd/primer-proyecto-dbII#deleteTable)
         @Http Call from View to Call Service API Function : client.deleteTable(JSON)
         @Params(int cID, string table_name)
         @Return JSON 
         */
        [HttpPost]
        public JsonResult HttpQuery
            (int cID, string order_by, string join_on, string querys)
        {
            QueryVM qq = new QueryVM(cID, order_by, join_on, querys);
            var jsonQ = JsonConvert.SerializeObject(qq);
            string x = client.multipleQuery(jsonQ);
            return new JsonResult { Data = x };

        }

        /*
 8.   /getConnections (https://github.com/aallanrd/primer-proyecto-dbII#getConnections)
     @Http Call from View to Call Service API Function : client.deleteTable(JSON)
     @Params (int cID, string table_name)
     @Return JSON 
     */
        [HttpPost]
        public JsonResult HttpGetConnections()
        {

            string x = client.getConnections();
            return new JsonResult { Data = x };

        }



        public ActionResult CrearTabla()        { return View(); }
     
        public ActionResult InsertarTabla( )    { return View(); }
        
        public ActionResult ActualizarTabla()   { return View(); }
      
        public ActionResult BorrarTabla()       { return View(); }
        
        public ActionResult Index()             { return View(); }

        public ActionResult BorrarDeTabla()     { return View(); }

        public ActionResult CrearDB()           { return View(); }

        public ActionResult IncluirDB()         { return View(); }

        public ActionResult Querys()        { return View(); }

        public ActionResult VerConexiones()
        {
            string x = client.getConnections();

            ViewBag.connections = x;


            return View();
        }

        // App/CheckConnection?a=1
        // Chequea una conexion especifica por ID 
        public string CheckConnection(int a)
        {
            return client.checkConnection(a);

        }


    }
}
