using NUnit.Framework;
using System;
using System.Reflection;

namespace Serpis.Ad
{
	[TestFixture ()]
	internal class ModelInfoFoo
	{

		public ModelInfoFoo(int id, string nombre){
			this.Id = id;
			this.Nombre = nombre;
		}

		[Key]
		public int Id {get;set;}

		[Field]
		public string Nombre {get;set;}
	}

	[TestFixture ()]
	internal class ModelInfoBar

	{
		public ModelInfoBar(int id, string nombre, decimal precio){
			this.Id = id;
			this.Nombre = nombre;
			this.Precio = precio;
		}

		[Key]
		public int Id {get;set;}

		[Field]
		public string Nombre {get;set;}

		[Field]
		public decimal Precio {get;set;}
	}

	[TestFixture ()]
	public class ModelInfoTest
	{
		[Test ()]
		public void TableName ()
		{
			ModelInfo modelInfo = ModelInfoStore.Get (typeof(ModelInfoFoo));
			Assert.AreEqual ("modelinfofoo", modelInfo.TableName);
		}

		[Test ()]
		public void KeyPropertyInfo(){
			ModelInfo modelInfo = ModelInfoStore.Get (typeof(ModelInfoFoo));
			Assert.IsNotNull (modelInfo.KeyPropertyInfo);
			Assert.AreEqual ("Id", modelInfo.KeyPropertyInfo.Name);
		}

		[Test()]
		public void KeyName(){
			ModelInfo modelInfo = ModelInfoStore.Get (typeof(ModelInfoFoo));
			Assert.AreEqual ("id", modelInfo.KeyName);
		}

		[Test()]
		public void FieldpropertyInfos(){
			ModelInfo modelInfo = ModelInfoStore.Get (typeof(ModelInfoFoo)); 
			PropertyInfo[] fieldPropertyInfo = modelInfo.FieldPropertyInfos;
			Assert.AreEqual (1, fieldPropertyInfo.Length);

			modelInfo = ModelInfoStore.Get (typeof(ModelInfoBar));
			PropertyInfo[] fieldPropertyInfo2 = modelInfo.FieldPropertyInfos;
			Assert.AreEqual (2, fieldPropertyInfo2.Length);
		}

		[Test()]
		public void FieldNames(){
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo)); 
			string[] fieldName = modelInfo.FieldNames;
			Assert.Contains ("nombre", fieldName);
			Assert.AreEqual (1, fieldName.Length);

		}
		[Test()]
		public void getSelect(){
			string expected;
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo)); 
			string getSelects = modelInfo.getSelect;
			expected = "select nombre from modelinfofoo where id=";
			Assert.AreEqual (expected, getSelects);
		}	
		[Test()]
		public void getUpdate(){
			string expected;
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo)); 
			string getUpdates = modelInfo.getUpdate;
			expected = "update modelinfofoo set nombre=@nombre where id=@id";
			Assert.AreEqual (expected, getUpdates);
		}	
		[Test()]
		public void getInsert(){
			string expected;
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo)); 
			string getInserts = modelInfo.getInsert;
			expected = "insert into modelinfofoo set id=@id, nombre=@nombre";
			Assert.AreEqual (expected, getInserts);
		}	
	}
}

