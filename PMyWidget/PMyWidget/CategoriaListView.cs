using System;
using Gtk;
namespace Serpis.Ad
{
	public class CategoriaListView : MyWidget
	{
		//private MyWidget myWidget;//Declaro variable myWidget para hacer composicion
		public CategoriaListView ()
		{
			//myWidget=new MyWidget();
//			myWidget.TreeView.AppendColumn("id", new CellRendererText(), "text",0); Cuando hace composicion debe mywidget llama al
			// treeview, ya que es suya la propiedad y ya aplico las columnas
//			myWidget.TreeView.AppendColumn("nombre", new CellRendererText(), "text",1);
//			myWidget.TreeView.Model=new ListStore(typeof(int),typeof(string));
			TreeView.AppendColumn("id", new CellRendererText(), "text",0);
			TreeView.AppendColumn("nombre", new CellRendererText(), "text",1);
			TreeView.Model=new ListStore(typeof(int),typeof(string));
			
		}
//		public MyWidget MyWidget{  Cuando compongo he de publicar la propiedad para poder usarla en MainWindow
//			get{return myWidget;}	
//		}
		#region implemented abstract members of SerpisAd.MyWidget
		public override void New ()
		{
			Console.WriteLine ("Categoria");
		}

		public override void Edit ()
		{
			throw new NotImplementedException ();
		}

		public override void Delete ()
		{
			throw new NotImplementedException ();
		}

		public override void Refresh ()
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

