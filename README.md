# multidatabase
A Multidatabase Project for ITCR Course Bases Datos II

 API Description

# ![multidatabase](media/promo.jpg)

Sistema Multidatabase para conexiones y consultas a multiples servidores de BD.


## Instalacion

```
Descargue el proyecto y ábralo en Visual Studio 2015
Podrá encontrar el ejecutable de la solucion VS, 

Multidatabase/Proyecto Multidatabase.sln

```

## Requerimientos

```Instalaciones *(Por NuggetPM)


###Mongo :       (PM> Install-Package mongocsharpdriver)	https://www.nuget.org/packages/mongocsharpdriver
###MariaDB :  a. (PM> Install-Package MySql.Data)		https://www.nuget.org/packages/MySql.Data/  
	    b. metadatadb, check configParams on (WebApp/Controllers/aMariaDBController)	

```

## API

### Multidatabase([API])

#### API

##### rutas

El proyeco del servicio expone las siguientes funciones, cada una de ellas recibe su lista de parámetros
por medio de JSON

##### /includeDB (JSON) : Incluye una nueva conexion en servidor local, para estar realizando consultas o 
			  procedimientos sobre ella.
	JSON Paráms: 
		string db_type: Tipo de servidor al que queremos conectarnos. Ej.(MariaDB,SQLDB,MongoDB)  
		string username : Usuario Autorizado de la Base de Datos . Ej. (root)
		string pass   : Contraseña del Usuario de la Base de Datos ---
		string server : Servidor donde se encuentra alojada. Ej. (localhost) 
		string protocol : Protocolo de comunicacion que utiliza el servidor. Ej( TCp/IP , MySQL/TCP )
		int port: Puerto principal donde esta corriendo el servidor . Ej. (27017,1440,3306) 
		string alias : Nombre adjunto a esta conexión.
	
	Ej.JSON  : { "db_type" : "SQLDB" , "username": "root" , ... }

##### /createDB (JSON): Crea una nueva base datos en la conexión seleccionada

	JSON Paráms :
		int idC : Id de la conexion a la que queremos enlazarnos
		string db_name : Nombre de la nueva base de datos
	Ej.JSON : { "idC" : 1 , "db_name": "xyzDB" } 

##### /createTable

##### /deleteTable

##### /multipleQuery

##### /insertValuesTable


##### /updateValuesTable

##### /multipleQuery

##### /getConecctions



## Team

[![Allan RD]()](https://aallanrd.com) | [![Carlos Arguello]()](https://github.com/carg62) | [![Gerardo Villalobos]()](https://github.com/Gerardo)
---|---|---
[Allan RD](https://aallanrd.com) | [Carlos Arguello](https://github.com/carg62) | [Gerardo Villalobos](https://github.com/gera)


## License

GPL © [General Public License](https://github.com/aallanrd/multidatabase/License)
