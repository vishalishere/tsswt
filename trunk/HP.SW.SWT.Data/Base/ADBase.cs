using System;
using System.Configuration;

namespace HP.SW.SWT.Data
{
    // Como ver queries on the fly
    // Context.GetCommand(query).CommandText
    public abstract class ADBase
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SWT"].ConnectionString;
            }
        }

        internal static SwT Context
        {
            get
            {
                SwT swt = new SwT(ConnectionString);
                swt.Log = Console.Out;
                return swt;
            }
        }
    }
}