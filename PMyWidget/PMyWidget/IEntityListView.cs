using System;

namespace Serpis.Ad
{
	public interface IEntityListView
	{
		void New();
		void Edit();
		void Delete();
		void Refresh();	
		bool HasSelected {get;}//Para implementar un miembro de interfaz, el miembro correspondiente de la clase debe ser público,
//		no estático y tener el mismo nombre y la misma firma que el miembro de interfaz. Las propiedades e indizadores de una clase
//		pueden definir descriptores de acceso adicionales para una propiedad o indizador definidos en una interfaz. Por ejemplo,
//		una interfaz puede declarar una propiedad con un descriptor de acceso get, pero la clase que implementa la interfaz puede
//		declarar la misma propiedad con descriptores de acceso get y set. Sin embargo, si la propiedad o el indizador utiliza una
//		implementación explícita, los descriptores de acceso deben coincidir. 
		
		event EventHandler SelectedChanged;//Define como son llamados los metodos en respuesta a un evento.
	}
}

