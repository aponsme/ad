using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using Serpis.Ad;
public partial class MainWindow: Gtk.Window
{
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		IDbConnection dbConnection = new MySqlConnection(
	   "Server=localhost;Database=dbPrueba;User Id=root;Password=sistemas");
		dbConnection.Open ();
		ComboBoxHelper comboBoxHelper=new ComboBoxHelper(comboBox,dbConnection,"id","nombre","categoria",2);
		
		comboBox.Changed+=delegate{
//			TreeIter treeIter;
//			comboBox.GetActiveIter(out treeIter);
//			int id=(int)listStore.GetValue(treeIter,0);Se lo lleva al Id en ComboboxHelper
			Console.WriteLine("comboBox.Changed id = {0}",comboBoxHelper.Id);//lo llama como una propiedad
		};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
//El treeview helper me lo llevo a la carpeta Serpis.Ad y cuando abro mainwindow me dan errores porque no 
//encuentra el helper----->le doy a referencia netAssambly y dentro de bin esta la .dll y lo cojo