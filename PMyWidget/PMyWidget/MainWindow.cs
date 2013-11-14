using System;
using Gtk;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		ArticuloListView articuloListView=new ArticuloListView();
		CategoriaListView categoriaListView=new CategoriaListView();
		
		//Creo notebook con dos paginas
		notebook.AppendPage (new ArticuloListView(), new Label("Articulos"));
		//notebook.AppendPage (categoriaListView.MyWidget, new Label("Categorias"));Cuando compongo
		notebook.AppendPage (new CategoriaListView(), new Label("Categorias"));
		
		newAction2.Activated+=delegate{
			IEntityListView entityListView=(IEntityListView)notebook.CurrentPageWidget;	
			Console.WriteLine("entityListView.GetType={0}",entityListView.GetType());
			entityListView.New();		
		};//Hace esto cuando crea en vez del boton un toolbar con un New que se llama newAction
		
		//mainButton.Sensitive=false;
		/*
			notebook.SwitchPage+=delegate{//Señala cuando cambia la página
		IEntityListView entityListView=(IEntityListView)notebook.CurrentPageWidget;
		//CurrentPageWidget obtiene el widget actual de la pagina actual o sea el objeto de la pagina en
		//la que estoy
		mainButton.Sensitive=entityListView.HasSelected;
			};
		articuloListView.SelectedChanged+=delegate{//Define como son llamados los metodos 
		//en respuesta a un evento
		mainButton.Sensitive=articuloListView.HasSelected;	
			};
		categoriaListView.SelectedChanged+=delegate{
		mainButton.Sensitive=categoriaListView.HasSelected;	
			};
		mainButton.Clicked+= delegate {
		IEntityListView entityListView=(IEntityListView)notebook.CurrentPageWidget;
		entityListView.New();	
		};*/
	}//Lo que consigue con todo esto es que cambie la sensibilidad del boton no solo cuando
	//cambio de pestaña, sino tambien cuando cambio entre elementos.
	
		
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
