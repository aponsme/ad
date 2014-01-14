using System;
using Gtk;
using System.Data;
namespace Serpis.Ad
{
	public class CategoriaListView : EntityListView
	{
		public CategoriaListView ()
		{
			TreeViewHelper t=new TreeViewHelper(treeView,"Select * from categoria");
			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null, null, Stock.Refresh);
			//tengo acceso al actionGroup de IEntityListView
			actionGroup.Add(refreshAction);
			refreshAction.Activated += delegate {t.Refresh ();};
			Gtk.Action editAction = new Gtk.Action("editAction", null, null, Stock.Edit);
			actionGroup.Add(editAction);
			editAction.Activated += delegate {
				Window ventana=new Window("Editar");
				ventana.SetDefaultSize(500,500);
				VBox h=new VBox(true,10);
				ventana.Add (h);
				Label enunciado=new Label("Introduce el nuevo valor:");
				h.Add (enunciado);
				Entry caja=new Entry();
				h.Add (caja);
				Button b=new Button("Editar");
				h.Add (b);
				b.Clicked+=delegate
				{
					IDbCommand dbCommand=App.Instance.DbConnection.CreateCommand();		
					dbCommand.CommandText = 
					string.Format ("Update categoria set nombre='{1}' where id={0}", t.Id,caja.Text);
					//Otra opción "update categoria set nombre=?nombre where id=" +id;
					//Otra opción "update categoria set nombre=@nombre where id=" +id;
					//Otra opción es con parametros:
					//"update categoria set nombre=:nombre where id=" +id;
					//IDbCommand updateDbCommand=App.Instance.DbConnection.CreateCommand();
					//updateDbCommand.CommandText="Update categoria set nombre=@nombre where id"+id;
//					IDbDataParameter nombreDbDataParameter=updateDbCommand.CreateParameter();
//					nombreDbDataParameter.ParameterName="nombre";
//					nombreDbDataParameter.Value=entryNombre.Text;
					//updateDbCommand.Parameters.Add(nombreDbDataParameter);
					//updateDbCommand.ExecuteNonQuery();
					//addParameter (updateDbCommand,"nombre",entryNombre.Text);
					dbCommand.ExecuteNonQuery ();
					ventana.Destroy ();
				};
				
				ventana.ShowAll();
				
			};
			
			
		}
//		public static void addParameter(IDbCommand dbCommand, string name, object value)
//		{
//			IDbDataParameter dbDataParameter=IDbCommand.CreateParameter();
//			dbDataParameter.ParameterName=name;
//			dbDataParameter.Value=value;
//			dbCommand.Parameters.Add(dbDataParameter);
//		}
	}
}

