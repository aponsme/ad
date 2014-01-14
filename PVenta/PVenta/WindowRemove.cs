using System;
using Gtk;
using System.Data;
namespace Serpis.Ad
{
	public partial class WindowRemove : Gtk.Window
	{
		public WindowRemove () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			button.Clicked+=delegate
				{
					IDbCommand dbCommand=App.Instance.DbConnection.CreateCommand();		
					dbCommand.CommandText = 
					string.Format ("delete from articulo where id={0}", entry.Text);
					dbCommand.ExecuteNonQuery ();
				};
		}
	}
}

