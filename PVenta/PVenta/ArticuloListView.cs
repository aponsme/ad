using System;
using System.Data;
using Gtk;
namespace Serpis.Ad
{
	public class ArticuloListView : EntityListView
	{
		public ArticuloListView ()
		{
			TreeViewHelper t=new TreeViewHelper(treeView,"Select * from articulo");
			Gtk.Action addAction = new Gtk.Action("addAction", null, null, Stock.Add);
			//tengo acceso al actionGroup de IEntityListView
			actionGroup.Add(addAction);
			
			addAction.Activated += delegate 
			{
				new WindowAdd();
			};
			
			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null, null, Stock.Refresh);
			//tengo acceso al actionGroup de IEntityListView
			actionGroup.Add(refreshAction);
			refreshAction.Activated += delegate {t.Refresh ();};
			Gtk.Action removeAction = new Gtk.Action("removeAction", null, null, Stock.Remove);
			actionGroup.Add(removeAction);
			
			removeAction.Activated += delegate 
			{
				new WindowRemove();
//				Window ventana=new Window("Borrar");
//				ventana.SetDefaultSize(500,500);
//				VBox h=new VBox(true,30);
//				ventana.Add (h);
//				Label enunciado=new Label("Introduce lo que quieras borrar:");
//				h.Add (enunciado);
//				Entry caja=new Entry();
//				h.Add (caja);
//				Button b=new Button("Borrar");
//				h.Add (b);
//				b.Clicked+=delegate
//				{
//					IDbCommand dbCommand=App.Instance.DbConnection.CreateCommand();		
//					dbCommand.CommandText = 
//					string.Format ("delete from articulo where id={0}", caja.Text);
//					dbCommand.ExecuteNonQuery ();
//				};
//
//				ventana.ShowAll();

			};
			
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
					string.Format ("update articulo set nombre='{1}' where id={0}", t.Id,caja.Text);
					dbCommand.ExecuteNonQuery ();
				};
				
				ventana.ShowAll();
				
			};
			
			
		}
		
	}
}

