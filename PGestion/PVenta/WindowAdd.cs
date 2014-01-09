using System;
using Gtk;
using System.Data;
namespace Serpis.Ad
{
	public partial class WindowAdd : Gtk.Window
	{
		public WindowAdd () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			button.Clicked+=delegate
				{
					IDbCommand dbCommand=App.Instance.DbConnection.CreateCommand();	
					dbCommand.CommandText = 
					string.Format ("insert into articulo (nombre) values ('{0}')", entry.Text);
					Console.WriteLine (entry.Text);
					dbCommand.ExecuteNonQuery ();
				};
		}
	}
}

