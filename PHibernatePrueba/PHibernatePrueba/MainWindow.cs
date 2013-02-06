using System;
using Gtk;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		//http://darioquintana.com.ar/articles/tutorial-de-nhibernate-primeros-pasos
		
		//Clase configuration de NHibernate
		Configuration configuration = new configuration();
		configuration.Configure();
		configuration.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, "none");
		
		configuration.AddAssembly(typeof(Categoria).Assembly);
		
		/*new SchemaExport(configuration).execute(true,false,false);*/
		
		//Se encarga crear sesiones en nuestra aplicacion.
		ISessionFactory sessionFactory = configuration.BuildSessionFactory ();
			
		updateCategoria(sessionFactory);
		
		sessionFactory.Close ();
	}
	
	
	//metodo para modificar una categoria
	protected void updateCategoria(ISessionFactory sessionFactory){
		
		//Abrimos la sesion
		ISession session = sessionFactory.OpenSession();
		try{
		Categoria categoria = (Categoria)session.Load(typeof(Categoria), 2L);
		Console.WriteLine("Categoria Id={0} Nombre={1}", categoria.Id, categoria.Nombre);
		categoria.Nombre = DateTime.Now.ToString ();
		session.SaveOrUpdate (categoria);
		
		session.FLUSH();//CONFIRMAR LOS CAMBIOS
		}finally{
		session.Close ();
		}
	}
	
	//metodo para insertar una categoria
	private void insertCategoria(ISessionFactory sessionFactory){
		//Abreviatura del try-finally-close del metodo anterior
		using(ISession session = sessionFactory.OpenSession()){
		Categoria categoria = new Categoria();
		categoria.Nombre= "Nueva "+DateTime.Now.ToString();
		
		session.SaveOrUpdate (categoria);
		
		session.FLUSH();//CONFIRMAR LOS CAMBIOS
		
		}
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
