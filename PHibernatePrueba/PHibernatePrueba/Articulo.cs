using System;


namespace Serpis.Ad
{
	public class Articulo
	{
		//Abraviaturas de metodos getter!!!!
			public virtual long Id {get; set;}
			public virtual string Nombre {get; set;}
		    public virtual decimal Precio {get; set;}
		
		
		//TODO propiedad categoria
		public virtual Categoria Categoria{get;set;}
	}
}

