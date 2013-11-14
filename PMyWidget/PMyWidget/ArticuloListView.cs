using System;
using Gtk;
namespace Serpis.Ad
{
	public class ArticuloListView : MyWidget//hereda de MyWidget
	{
		public ArticuloListView ()
		{
			TreeView.AppendColumn("id", new CellRendererText(), "text",0);
			TreeView.AppendColumn("nombre", new CellRendererText(), "text",1);
			TreeView.AppendColumn("categoria", new CellRendererText(), "text",2);
			TreeView.AppendColumn("precio", new CellRendererText(), "text",3);
			TreeView.Model=new ListStore(typeof(int),typeof(string),typeof(string),typeof(string));
		}
		
		#region implemented abstract members of SerpisAd.MyWidget
		public override void New ()
		{
			Console.WriteLine ("Articulo");
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

