using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioWEB.Controladores;
using ServicioWEB.Modelo;
using MongoDB.Driver;

namespace ServicioWEB.Controladores
{
    public class aMongoController
    {
        MongoConnect conexion;

        public aMongoController()
        {
           
            
        } 
        public string includeDB(DBModel m)
        {
            conexion = new MongoConnect(m.port,m.server);
            if (conexion.OpenConnection().Equals("Connected"))
            {
                return "Connected";
            }
            else
            {        
                conexion.CloseConnection();
                return "No hay conexion con la base de datos : metadata";
            }
           
        }


        public  string createDB(DBModel m, string database_name)
        {
            conexion = new MongoConnect(m.port,m.server);
            if (conexion.OpenConnection().Equals("Connected"))
            {
                try
                {
                    return conexion.createDB(database_name);
                }
                catch (Exception e)
                {
                    return "Error creando base de datos" + e;
                }
            }
            else
            {
                return "Error conectando a la BD";
            }

        }

        public string check(DBModel model)
        {
            try
            {
               return consultDB(model);
   
               
            }
            catch(Exception e){
                return "Cant Connect";
            }
        }

        public string consultDB(DBModel m)
        {
            conexion = new MongoConnect(m.port, m.server);
            try
            {
               string x =  conexion.OpenConnection();
                if (x.Equals("Connected"))
                {
                    
                    conexion.CloseConnection();
                }
                return x;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        internal string createTable(DBModel m, string table_name, List<Column> cll)
        {
            conexion = new MongoConnect(m.port, m.server);
            try
            {
                string x = conexion.OpenConnection();
                if (x.Equals("Connected"))
                {
                   
                    conexion.CloseConnection();
                }
                return x;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        internal string deleteTable(DBModel m, string table_name)
        {
            conexion = new MongoConnect(m.port, m.server);
            try
            {
                string x = conexion.OpenConnection();
                if (x.Equals("Connected"))
                {
                    conexion.deleteTable(m.alias, table_name);
                    conexion.CloseConnection();
                }
                return x;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        internal string multipleQuery(DBModel model, object cll)
        {
            throw new NotImplementedException();
        }

        internal string insertValuesTable(DBModel m, string table_name, List<Value> cll)
        {
             
            conexion = new MongoConnect(m.port, m.server);
            try
            {
                string x = conexion.OpenConnection();
                if (x.Equals("Connected"))
                {
                    conexion.insertValues( m.alias,table_name, cll);
                    conexion.CloseConnection();
                }
                return x;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        internal string updateValuesTable(DBModel model, string table_name, List<Value> cll)
        {
            throw new NotImplementedException();
        }

        internal string deleteValuesTable(DBModel model, string table_name, List<Value> cll)
        {
            throw new NotImplementedException();
        }
    }



}