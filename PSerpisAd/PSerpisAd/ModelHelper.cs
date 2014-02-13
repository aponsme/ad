using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Serpis.Ad
{
	public class ModelHelper
	{
//MODIFICAR ModelHelper USANDO EL ModelInfoStore
//
//
//
//
//
//		public static object Load(Type type, string id) 
//		{
//			ModelInfo modelInfo=modelInfoStore.Get(type);//Llamo al metodo del diccionario
//			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
//			selectDbCommand.CommandText = modelInfo.getSelect + id;
//			IDataReader dataReader = selectDbCommand.ExecuteReader();
//			dataReader.Read(); //lee el primero
//
//			object obj = Activator.CreateInstance(type);
//			foreach (PropertyInfo propertyInfo in type.GetProperties ()) 
//			{
//				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
//					propertyInfo.SetValue(obj, id, null); //TODO convert al tipo de destino
//				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
//					propertyInfo.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null); //TODO convert al tipo de destino
//			}
//			dataReader.Close ();
//			return obj;
//		}
//
//		public static void Save(object obj)
//		{
//
//			IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand();
//			Type type = obj.GetType();
//			updateDbCommand.CommandText = GetUpdate(type);
//
//			foreach (PropertyInfo propertyInfo in type.GetProperties())
//			{
//				if(propertyInfo.IsDefined (typeof(KeyAttribute), true)
//					|| propertyInfo.IsDefined (typeof(FieldAttribute), true))
//				{  
//					object value = propertyInfo.GetValue(obj, null);
//					DbCommandUtil.AddParameter(updateDbCommand, propertyInfo.Name.ToLower(), value);
//				}
//				updateDbCommand.ExecuteNonQuery();
//
//			}
//
//		}
//		public static void Insert(object obj)
//		{
//			IDbCommand insertDbCommand = App.Instance.DbConnection.CreateCommand();
//			Type type = obj.GetType();
//			insertDbCommand.CommandText = GetInsert(type);
//
//			foreach (PropertyInfo propertyInfo in type.GetProperties())
//			{
//				if(propertyInfo.IsDefined (typeof(KeyAttribute), true) || propertyInfo.IsDefined (typeof(FieldAttribute), true))
//				{
//					object value = propertyInfo.GetValue(obj, null);
//					DbCommandUtil.AddParameter(insertDbCommand, propertyInfo.Name.ToLower(), value);
//				}
//				insertDbCommand.ExecuteNonQuery();
//			}
//		}
		
		
		public static object Load(Type type, string id) 
		{
			ModelInfo modelInfo=ModelInfoStore.Get (type);
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
			selectDbCommand.CommandText = modelInfo.getSelect + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			
			object obj = Activator.CreateInstance(type);
			modelInfo.KeyPropertyInfo.SetValue(obj,id,null);
			foreach(PropertyInfo propertyInfo in modelInfo.FieldPropertyInfos)
			{
				modelInfo.FieldPropertyInfos.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null);
			}	
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) 
//			{
//				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
//				{	
//					object value=convert(id,propertyInfo.PropertyType);
//					propertyInfo.SetValue(obj, id, null); //TODO convert al tipo de destino
//				}	
//				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
//				{	
//					propertyInfo.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null); //TODO convert al tipo de destino
//					object value=convert(dataReader[propertyInfo.Name.ToLower()],propertyInfo.PropertyType);
//				}
//			}
			dataReader.Close ();
			return obj;
		}
		
		private static object convert(object value, Type type)
		{
			return Convert.ChangeType(value, type);
		}
		
		public static void Save(object obj)
		{
           	IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand();
            Type type = obj.GetType();
            updateDbCommand.CommandText = modelInfo.getUpdate;
           
            foreach (PropertyInfo propertyInfo in type.GetProperties())
			{
                if(propertyInfo.IsDefined (typeof(KeyAttribute), true)
                    || propertyInfo.IsDefined (typeof(FieldAttribute), true))
				{  
                    object value = propertyInfo.GetValue(obj, null);
                    DbCommandUtil.AddParameter(updateDbCommand, propertyInfo.Name.ToLower(), value);
                }
				
                updateDbCommand.ExecuteNonQuery();
               
            }
           
        }
		public static void Insert(object obj)
		{
			IDbCommand insertDbCommand = App.Instance.DbConnection.CreateCommand();
			Type type = obj.GetType();
			insertDbCommand.CommandText = GetInsert(type);

			foreach (PropertyInfo propertyInfo in type.GetProperties())
			{
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true) || propertyInfo.IsDefined (typeof(FieldAttribute), true))
				{
					object value = propertyInfo.GetValue(obj, null);
					DbCommandUtil.AddParameter(insertDbCommand, propertyInfo.Name.ToLower(), value);
				}
				insertDbCommand.ExecuteNonQuery();
			}
		}
	}
}



