using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	//private ListStore listStore;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		CellRenderer cellRenderer = new CellRendererText();
		//¿Porque no detecta la variable comboBox?
		comboBox1.PackStart(cellRenderer, false);
	//	comboBox.PackStart(cellRenderer, false); //expand=false
		comboBox1.AddAttribute (cellRenderer, "text", 1);
		
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		comboBox1.Model = listStore;
		
		listStore.AppendValues("1", "Uno");
		listStore.AppendValues("2", "Dos");

		comboBox1.Changed += delegate { showActiveItem (listStore); };

	}
	
	private void showActiveItem(ListStore listStore)
	{
		TreeIter treeIter;
		if ( comboBox1.GetActiveIter (out treeIter) ) { //item seleccionado
			object value = listStore.GetValue (treeIter, 0);
			Console.WriteLine ("comboBox.Changed delegate value={0}", value);
		}
	}
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
