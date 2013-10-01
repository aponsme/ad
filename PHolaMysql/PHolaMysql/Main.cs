using System;
using System.Collections.Generic;//using System.Collections.Generic; List<string> columnNames=new List<string>();
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
	class MainClass
	{
		
		
		
		private static string[] getColumnNames(MySqlDataReader mySqlDataReader)
		{
			string[] cabecera=new string [mySqlDataReader.FieldCount];//Array estático
			for(int i=0;i<mySqlDataReader.FieldCount;i++)
				cabecera[i]=mySqlDataReader.GetName(i);
				//List<string> columnNames=new List<string>();
			return cabecera;
		}
		
		
		
		
		
		public static void Main (string[] args)
		{
			string connectionString = 
				"Server=localhost;" +
				"Database=dbprueba;" +
				"User Id=root;" +
				 "Password=sistemas";
			MySqlConnection mySqlConnection=new MySqlConnection(connectionString);
			mySqlConnection.Open();
			//Quiero seleccionar todas las categorias (select * from categoria)
			MySqlCommand mySqlCommand=mySqlConnection.CreateCommand();// MysqlCommnnd mysqlconnection=mysqlCommand.CreateCommand();
			mySqlCommand.CommandText = "Select * from categoria";
			//le puedo pasar cualquier instrucción
			//de mysql reconoclible por la base de datos.
			MySqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();
			//los objetos mysqlDataReader lo único que hace es leer fila a fila. Siempre empieza por la primera y 
			//así hasta el final y pierde la info de la fila anterior. Y sin leer las filas ya tiene toda la metainformación
			//de las columnas, de qué tipo son...
			Console.WriteLine(mySqlDataReader.FieldCount);
		    int count=mySqlDataReader.FieldCount;
//			
//			for(int i=0;i<count;i++)
//			Console.Write(mySqlDataReader.GetName(i)+" | "); 
//			Console.WriteLine ("");
//			Console.WriteLine ("------------"); Ahora veremos otra forma de hacerlo con array estático usando el método
//			getColumnNames ()
			
			string[] prueba=getColumnNames(mySqlDataReader);
			for(int i=0;i<prueba.Length;i++)
				Console.Write(prueba[i]+"   ");//Console.WriteLine(getColumnNames(mySqlDataReader)[i]);
			Console.WriteLine("   ");
			while(mySqlDataReader.Read ())
			{	
					for(int i=0;i<count;i++)
					{
						Console.Write(mySqlDataReader.GetValue(i)+" | ");
					
					}
			Console.WriteLine ("");
			}
			
			mySqlDataReader.Close();//Hay que cerrar los lectores y hay muchas bases de datos que no dejan tener
			//más de uno abierto*/
			
		
			mySqlConnection.Close ();
			Console.WriteLine ("");
			Console.WriteLine ("ok!");//Console.Write otra forma de escribir una cadena
			
		}
	}
}
