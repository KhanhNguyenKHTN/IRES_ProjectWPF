using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRES_Globals.GlobalClass
{
    public class ConnectionInfo
    {
        /// <summary>
        /// CONNECT CLOUD DATABASE
        /// </summary>
        public static string SERVER = "104.199.159.71";
        public static string PORT = "5432";
        public static string USER = "postgres";
        public static string PASSWORD = "123456";
        public static string DATABASE = "irest";

        //////////      CONNECT LOCAL DATABASE, when using localhost for Postgres, please comment above connection info (fo cloud database)
        //public static string SERVER = "localhost";
        //public static string PORT = "5432";
        //public static string USER = "postgres";
        //public static string PASSWORD = "123456";
        //public static string DATABASE = "ires";
    }
}
