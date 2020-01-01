using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using IRES_Globals.GlobalClass;
using System.Windows.Forms;

namespace Service
{
    public class SQLConnection
    {
        public NpgsqlConnection Connection = null;

        private static SQLConnection _Instance;

        public static SQLConnection Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SQLConnection();
                    _Instance.connectDB();
                    _Instance.openfConnection();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        public SQLConnection()
        {
            connectDB();
        }
        public void connectDB()
        {
            Connection = new NpgsqlConnection(
                "Server=" + ConnectionInfo.SERVER + ";" +
                "Port=" + ConnectionInfo.PORT + ";" +
                "User Id=" + ConnectionInfo.USER + ";" +
                "Password=" + ConnectionInfo.PASSWORD + ";" +
                "Database=" + ConnectionInfo.DATABASE + ";"
            );
        }

        public void openfConnection()
        {
            try
            {
                Connection.Open();

            }
            catch (NpgsqlException ex)
            {
                //showError(ex);
                MessageBox.Show("fail roai");
            }
        }

        private void closeConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (NpgsqlException ex)
            {
                //showError(ex);
                MessageBox.Show("fail roai");
            }
        } 
    }
}
