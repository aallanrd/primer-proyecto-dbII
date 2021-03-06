﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections;
using ServicioWEB.Modelo;

namespace ServicioWEB
{
    class MongoConnect
    {
        protected static MongoClient _client;
    
        // public MongoDB.Driver.ConnectionMode connection;

        public MongoConnect(int port, string server)
        { 
            _client = new MongoClient("mongodb://" + server +":" + port);
        }

        //Chequea que el cliente se haya abierto correctamente
        public  string  OpenConnection()
        {
            if ( _client != null)
            {             
               return "Connected"; 
            }
            else
            {
                return "Cant Get Database";
            }


        }
        //Crea una base de datos en el cliente actual
        public string createDB(string x)
        {

            var database = _client.GetDatabase(x);

            if (database != null)
            {
                var collection = database.GetCollection<BsonDocument>("test");

                var document = new BsonDocument
                        {
                            
                            { "DBLOg", "Created" },
                         
                        };


                 collection.InsertOneAsync(document);

                if (collection != null)
                {
                    return "Creada Correctamente";
                }
                else {
                    return "No creada";
                }
            }
            else
            {
                return "No puedo obtener conexión";
            }


        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
              //  connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        internal void createTable(string j, string table_name, List<Column> array)
        {
            var database = _client.GetDatabase(j);
            var collection = database.GetCollection<BsonDocument>(table_name);

            BsonDocument document = new BsonDocument();
            for(int i=0; i<array.Count; i++) { 
             document.Add(new BsonElement(array[i].name, array[i].type));
            }
            // document.AddRange(BsonDocument.Parse(array));

            collection.InsertOneAsync(document);

           
        }

        internal void insertValues(string j, string table_name, List<Value> array)
        {
            var database = _client.GetDatabase(j);
            var collection = database.GetCollection<BsonDocument>(table_name);
            BsonDocument document = new BsonDocument();
            for (int i = 0; i < array.Count; i++)
            {
                document.Add(new BsonElement(array[i].Vcol, array[i].Vval));
            }
            collection.InsertOneAsync(document);
        }

        internal void deleteTable(string alias, string table_name)
        {
            var database = _client.GetDatabase(alias);
            var collection = database.GetCollection<BsonDocument>(table_name);
            var filter = new BsonDocument();
            var result =  collection.DeleteMany(filter);
        }
    }
}
