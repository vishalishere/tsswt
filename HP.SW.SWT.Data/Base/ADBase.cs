using System.Web;
using System.Web.Mvc;

using HP.SW.SWT.Extensions;
using MySql.Data.MySqlClient;
using System;

namespace HP.SW.SWT.Data
{
    public abstract class ADBase
    {
        private static string ConnectionString
        {
            get
            {
                return "SERVER=localhost;DATABASE=swt;UID=root;PASSWORD=root;";
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