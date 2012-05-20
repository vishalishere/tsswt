using System.Web;
using System.Web.Mvc;

using HP.SW.SWT.Extensions;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace HP.SW.SWT.Data
{
    // Como ver queries on the fly
    // Context.GetCommand(query).CommandText
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