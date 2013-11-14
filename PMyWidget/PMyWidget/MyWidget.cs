using System;
using Gtk;
namespace Serpis.Ad
{
	[System.ComponentModel.ToolboxItem(true)]
	public abstract partial class MyWidget : Gtk.Bin, IEntityListView
	{
		public MyWidget ()
		{
			this.Build ();
			
			Visible=true;//Para que sean visibles todos los componentes en los hijos y lo pone aquí para evitar
			//tenerlo que poner en ArticuloListView y CategoriaListView
			
			//En un principio, generalizó el TreeView para las dos clases hijas, pero luego prefirió personalizarlo
			//en cada una de las clases hijas (ver TreeView personalizado en los respectivos constructores)
			//treeView.AppendColumn("id",new CellRendererText(),"text",0);
			//treeView.AppendColumn("nombre",new CellRendererText(),"text",0);
			//ListStore listStore=new ListStore(typeof(int),typeof(string));
			//listStore.AppendValues(1,"elemento1");
			//listStore.AppendValues(2,"elemento2");
			//treeView.Model=listStore;
		}
		
		public TreeView TreeView//Tiene que publicarlo para que puedan usarlo todas las clases 
		{
			get{return treeView;}//Gracias a implementar esto, puedo usar el TreeView, que en 
			//principio el lo declara como private en archivo SerpisAdMyWidget...
		}
		#region IEntityListView implementation
		public virtual void New ()
		{
			Console.WriteLine("MyWidget.New()");
		}
		
		public abstract void Edit ();
		
		public abstract void Delete ();
		
		public abstract void Refresh ();
		
		
		public bool HasSelected {//Este es el get que aparecia en IEntityListView
			get {
				//TreeIter treeIter;
				//return treeView.Selection.GetSelected(out treeIter);1ºPOSIB
				return treeView.Selection.CountSelectedRows()>0;//2ºPOSIB
			}
		}
		public event EventHandler SelectedChanged;
		#endregion
	}
}

