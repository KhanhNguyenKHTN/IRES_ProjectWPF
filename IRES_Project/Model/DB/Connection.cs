using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;

namespace Model.DB
{
    public class Connection
    {
        private const String SERVER = "localhost";
        private const String PORT = "5432";
        private const String USER = "postgres";
        private const String PASSWORD = "123456";
        private const String DATABASE = "ires";

        private NpgsqlConnection connection = null;

        public Connection()
        {
        }
        public void connectDB()
        {
            connection = new NpgsqlConnection(
                "Server=" + SERVER + ";" +
                "Port=" + PORT + ";" +
                "User Id=" + USER + ";" +
                "Password=" + PASSWORD + ";" +
                "Database=" + DATABASE + ";"
            );
        }

        public void openfConnection()
        {
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                showError(ex);
            }
        }

        private void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (NpgsqlException ex)
            {
                showError(ex);
            }
        }

        private void showError(NpgsqlException ex)
        {
           // MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
        }

        public Boolean runCommand(string query)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            if (cmd.ExecuteScalar() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
