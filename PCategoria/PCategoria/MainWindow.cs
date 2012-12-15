using System;
using System.Data;
using Gtk;
using Npgsql;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	//Modelo de funcionamiento
	//1º Referencias (System data y Npgsql)
	//2º Diseñador
	//3º picar codigo
	
	private void fillComboBox()
	{
		CellRendererText cellRenderer = new CellRendererText();
		comboBox.PackStart(cellRenderer,false); //expand = false
		comboBox.AddAttribute(cellRenderer,"text", 1);
		
		ListStore liststore = new ListStore(typeof(string), typeof(string));
		
		comboBox.Model=liststore;
		
		//Atacamos a la base de datos para conectarnos
		string connectionString="Server=localhost; Database=dbprueba; User Id=dbprueba; password=1234";
		IDbConnection dbConnection = new NpgsqlConnection(connectionString);
		dbConnection.Open();
		
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText="select id, nombre from categoria";
		
		IDataReader dataReader = dbCommand.ExecuteReader();
		
		while(dataReader.Read()){
			
			liststore.AppendValues(dataReader("id").ToString(), dataReader("nombre").ToString());
		}
		
		dataReader.Close ();
		dbConnection.Close();
	}
	

	
	/*private void GetItemsButton_Click(object sender, EventArgs e){

    StringBuilder sb = new StringBuilder();

    foreach (string name in Combo1.Items){

        sb.Append(name);
        sb.Append(" ");
    }
    MessageBox.Show(sb.ToString());
}*/
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
