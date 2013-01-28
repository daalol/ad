using System;
using System.Data;

namespace PDataSet
{
	public class PDataSet
	{
		public PDataSet ()
		{
			//**************  ejemplo  *************
			// Create a DataSet.
			DataSet set = new DataSet("office");
		
			// Show original name.
			Console.WriteLine(set.DataSetName);
		
			// Change its name.
			set.DataSetName = "unknown";
			Console.WriteLine(set.DataSetName);
		}
	}
}

