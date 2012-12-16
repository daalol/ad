using Gtk;
using System;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		
		public string Nombre { 
			get {return entryNombre.Text;}
			set {entryNombre.Text = value;} 
		}
		
		public decimal Precio {
			get {return Convert.ToDecimal (spinButtonPrecio.Value);}
			set {spinButtonPrecio.Value = Convert.ToDouble(value);}
		}
		
		public long Categoria {
			set {
				//TODO implementar...
			}
		}
		
		public static void AddParameter(IDbCommand dbCommand, string name, object value)
		{
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add (dbDataParameter);
		}

		
		public Gtk.Action SaveAction {
			get {return saveAction;}
		}
	}
}

