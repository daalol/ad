using System;

namespace Serpis.Ad
{
	public class Categoria
	{	
			//Abraviaturas de metodos getter!!!!
			public virtual long Id {get; set;}
			public virtual string Nombre {get; set;}
		
			
		//Sobrescritura del metodo tostring
			public override string ToString ()
			{
				return string.Format ("[Categoria: Id={0}, Nombre={1}]", Id, Nombre);
			}
			
	}
}

