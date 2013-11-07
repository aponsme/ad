using System;
using Gtk;
using System.Data;

namespace Serpis.Ad
{
	//otra opcion a la concatenacion en el dbcommand es poner
	//private const String selectFormat="Select{0},{1} from {2}" 
	public class ComboBoxHelper
	{
		TreeIter treeIter;
		ComboBox comboBox; 
		ListStore listStore;
		
		public ComboBoxHelper (
			ComboBox comboBox,
			IDbConnection dbConnection,
			string idFieldName,
			string valueFieldName,
			string tableName,
			int initialId)
		{
			this.comboBox=comboBox;
			
			
			CellRendererText cellRendererText=new CellRendererText();
			comboBox.PackStart(cellRendererText,true);
			comboBox.AddAttribute(cellRendererText,"text",1);
			listStore=new ListStore(typeof(int),typeof(string));
		
			TreeIter initialTreeIter=listStore.AppendValues(0,"<Sin asignar>");
			
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "Select "+idFieldName+","+valueFieldName+ " from "+tableName;
			//Usando selectFormat dbCommand.CommandText = string.Format(selectFormat,idFieldName, valueFieldName,tableName);
			IDataReader dataReader=dbCommand.ExecuteReader();

			while(dataReader.Read())
			{
			int id=(int)dataReader["id"];
			
			String nombre=(String)dataReader["nombre"];
			
			TreeIter treeIter=listStore.AppendValues(id,nombre);
			if(id==initialId)
				initialTreeIter=treeIter;
		}
		
		dataReader.Close();
		comboBox.Model=listStore;
		comboBox.SetActiveIter(initialTreeIter);
		}
			
		public int Id 
		{
			get {
				comboBox.GetActiveIter(out treeIter);
				int initialId=(int)listStore.GetValue(treeIter,0);
				return initialId;}
		}//Para que nos devuelva una propiedad
			
			
			
			
		}
	}


