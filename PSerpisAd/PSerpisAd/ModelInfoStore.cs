using System;
using System.Collections.Generic;

namespace Serpis.Ad
{
	public static class ModelInfoStore
	{
		private static Dictionary<Type,ModelInfo> modelInfos=new Dictionary<Type,ModelInfo>();

		public static ModelInfo Get(Type type)
		{
		
			if (!modelInfos.ContainsKey (type))//Si no existe ningun elemento del diccionario de ese tipo
				modelInfos [type] = new ModelInfo (type); //Lo crea
			
			return modelInfos [type];//Si ya existe lo devuelve
		}
	}
}

