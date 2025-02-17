using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace InfoRegSystem
{
    public class Connection
    {
        public static string Database { get; } = (@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");
    }
}

