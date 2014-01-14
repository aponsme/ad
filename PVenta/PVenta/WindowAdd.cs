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
			ComboBoxHelper comboBoxHelper=new ComboBoxHelper(
			combobox,App.Instance.DbConnection,"id","nombre","categoria",0);

			button.Clicked+=delegate
				{
					IDbCommand dbCommand=App.Instance.DbConnection.CreateCommand();	
					dbCommand.CommandText = 
					string.Format ("insert into articulo (nombre,categoria,precio) values ('{0}',{1},'{2}')", entry.Text,comboBoxHelper.Id,entryPrecio.Text);
					Console.WriteLine (entry.Text);
					dbCommand.ExecuteNonQuery ();
				};
		}
	}
}

