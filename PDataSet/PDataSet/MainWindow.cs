using System;
using Gtk;
using System.Data;
using Npgsql;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected void OnExecuteActionActivated(Object sender, System.EventArgs e)
	{
		String connectionString ="Server=localhost;Database=dbprueba;User Id=dbprueba;Password=1234";
		NpgsqlCommand selectCommand = dbConnection.CreateCommand ();
		selectCommand.CommandText = "select * from categoria";
		NpgsqlDataAdapter dbDataAdapter = new NpgsqlDataAdapter();
		new NpgsqlCommandBuilder(dbDataAdapter);
		
			dbDataAdapter.SelectCommand = selectCommand;
		
		DataSet dataset = new Dataset();
		dbDataAdapter.Fill (DataSet);
		//Console.WriteLine("Tables.Count={0}", dataSet.Tables.Count);
		
		foreach(DataTable dataTable in dataset.Tables)
			show (dataTable);
		
		DataRow dataRow = dataset.Tables[0].Rows[0];
		dataRow["Nombre"] = DateTime.Now.ToString();
		
		Console.WriteLine("Cambios");
		show (dataset.Tables[0]);
		
		dbDataAdapter.Update(dataset);
		
	}
	
	private void show (DataTable dataTable){
		
		foreach(DataRow dataRow in dataTable.rows)
			foreach(DataColumn datacolumn in dataTable.Columns)
				Console.Write ("[{0}={1}]", datacolumn.ColumnName, dataRow[dataColumn]);
				Console.WriteLine();
	}
}
