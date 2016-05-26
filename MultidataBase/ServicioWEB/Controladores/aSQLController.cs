﻿using ServicioWEB.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioWEB.Controladores
{
    public class aSQLController 
    {

        
        SQLConnect conexion;

        public aSQLController()
        {
            conexion = new SQLConnect("root", "Ard2592allan", "DESKTOP-GH4HJ56", 1433, "master");
        }
        public aSQLController(string uid, string pass, string server, int port, string database)
        {
            conexion = new SQLConnect(uid, pass, server, port, database);
        }


        public string consultDB()
        {
            if (conexion.OpenConnection().Equals("Connected"))
            {

                try
                {

                    string Query = "SELECT name, database_id, create_date FROM sys.databases";

                    SqlCommand cmd = new SqlCommand(Query);
                    cmd.ExecuteNonQuery();

                    //conexion.CloseConnection();
                    return "Correcto SQL";
                }
                catch (Exception e)
                {
                    return "Error leyendo" + e;
                }
            }

            else
            {
                return ("No hay conexion con la base de datos");
            }
        }

        public string createDB(DBModel db,string database_name)
        {
            conexion = new SQLConnect(db.username, db.pass, db.server, db.port, db.alias);
            if (conexion.OpenConnection().Equals("Connected"))
            {
                try
                {
                    string Query = "CREATE DATABASE " + database_name + ";";

                    SqlCommand cmd = new SqlCommand(Query,conexion.connection);

                    cmd.ExecuteNonQuery();
                    //conexion.CloseConnection();
                    return "Insertada correctamente";
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
            SQLConnect conexion = new SQLConnect(model.username, model.pass, model.server, model.port, model.alias);
            try
            {
                if (conexion.OpenConnection().Equals("Connected"))
                {
                    return "Connected";
                }
                else
                {
                    return "Cant- connect";
                }
            }
            catch(Exception e)
            {
                return "Cant- connect";
            }
        }

        //Crear una nueva tabla en una instancia de MariaDB
        public string createTable(DBModel db, string table_name, List<Modelo.Column> array)
        {

            SQLConnect newConnection = new SQLConnect(db.username, db.pass, db.server, db.port, db.alias);
            if (newConnection.OpenConnection().Equals("Connected"))
            {
                try
                {
                    string colums = "( ";
                    int c = 0;
                    while (c != array.Count)
                    {
                        var x = array[c];
                        if (x.type.Equals("int")){
                            colums = colums + x.name + " " + x.type ;
                        }
                        else
                        {
                            colums = colums + x.name + " " + x.type + " (" + x.length + ")";
                        }
                        
                        if (c + 1 == array.Count)
                        {
                            break;
                        }
                        else
                        {
                            colums = colums + ",";
                        }
                        c++;
                    }
                    colums = colums + ")";
                    string Query = "create table dbo." + table_name + colums;

                    SqlCommand cmd = new SqlCommand(Query, newConnection.connection);

                    cmd.ExecuteNonQuery();
                    return "{ 'msg':  'Insertada correctamente'}";
                }
                catch (Exception e)
                {
                    return "{ 'msg':  'Error insertando'}";
                }


            }
            else
            {
                return "Error conectando a la BD";
            }

        }

        public string deleteTable(DBModel db, string database_name)
        {
            conexion = new SQLConnect(db.username, db.pass, db.server, db.port, db.alias);
            if (conexion.OpenConnection().Equals("Connected"))
            {
                try
                {
                    string Query = "DROP DATABASE dbo." + database_name + "";

                    SqlCommand cmd = new SqlCommand(Query, conexion.connection);

                    cmd.ExecuteNonQuery();
                    //conexion.CloseConnection();
                    return "Insertada correctamente";
                }
                catch (Exception e)
                {
                    return "Error borrando la base de datos" + e;
                }


            }
            else
            {
                return "Error conectando a la BD";
            }
        }

        internal string multipleQuery(DBModel model, object cll)
        {
            throw new NotImplementedException();
        }

        public string insertValuesTable(DBModel db, string table_name, List<Value> cll)
        {
            SQLConnect newConnection = new SQLConnect(db.username, db.pass, db.server, db.port, db.alias);
            if (newConnection.OpenConnection().Equals("Connected"))
            {
                try
                {
                    string colums = "( ";
                    int c = 0;
                   
                    while (c != cll.Count)
                    {
                        var x = cll[c];
                        string Query = "INSERT dbo." + table_name +"VALUES"+ colums+cll;
                        SqlCommand cmd = new SqlCommand(Query, newConnection.connection);
                        cmd.ExecuteNonQuery();

                        if (c + 1 == cll.Count)
                        {
                            break;
                        }
                        else
                        {
                            colums = colums + ",";
                        }
                        c++;
                    }
                    colums = colums + ")";
                   
                   
                    return "{ 'msg':  'Insertada correctamente'}";
                }
                catch (Exception e)
                {
                    return "{ 'msg':  'Error insertando'}";
                }


            }
            else
            {
                return "Error conectando a la BD";
            }

        }

        //ojo el parametro condicion no es un parametro preestablecido haz una clase para condicion "esto es lo que el usuario escribe para que modifique con una condicion respectiva"
        //falta la interfaz en el html
        public string updateValuesTable(DBModel db, string table_name, List<Value> cll)
        {
            SQLConnect newConnection = new SQLConnect(db.username, db.pass, db.server, db.port, db.alias);
            if (newConnection.OpenConnection().Equals("Connected"))
            {
                //actualiza solo un valor no esta implementado en la interfaz para que lo implemente con uno
                try
                {
                   
                        string Query = "update table dbo." + table_name +"SET" +cll+ "="+ cll  +"WHERE" +cll +"="+cll ;
                        SqlCommand cmd = new SqlCommand(Query, newConnection.connection);
                        cmd.ExecuteNonQuery();

       


                    return "{ 'msg':  'Modificado correctamente'}";
                }
                catch (Exception e)
                {
                    return "{ 'msg':  'Error insertando'}";
                }


            }
            else
            {
                return "Error conectando a la BD";
            }
        }

        public string deleteValuesTable(DBModel db, string table_name, List<Value> cll)
        {
            SQLConnect newConnection = new SQLConnect(db.username, db.pass, db.server, db.port, db.alias);
            if (newConnection.OpenConnection().Equals("Connected"))
            {
                try
                {
                        //elimina solo un registro por valor dentro de una tabla   
                        string Query = "delete from" +"table dbo."+"where"+cll+"="+cll;
                        SqlCommand cmd = new SqlCommand(Query, newConnection.connection);
                        cmd.ExecuteNonQuery();

                  


                    return "{ 'msg':  'Insertada correctamente'}";
                }
                catch (Exception e)
                {
                    return "{ 'msg':  'Error insertando'}";
                }


            }
            else
            {
                return "Error conectando a la BD";
            }
        }
    }
}