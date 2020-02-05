using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Service.Modules
{
    public class SQLExecute
    {
        private static SQLExecute _Instance;
        public static SQLExecute Instance
        {
            get
            {
                if (_Instance == null) _Instance = new SQLExecute();
                return _Instance;
            }
        }
        public DataTable GetExcuteQuery(string query)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);
            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            dr.Close();
            return dt;
        }
        public DataTable GetExcuteQueryOne(string query, string searchValue)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);
            
            //Add parameter
            cmd.Parameters.Add("@search_text", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@search_text"].Value = searchValue;
            cmd.Parameters.AddWithValue(searchValue);
            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            dr.Close();
            return dt;
        }
        public bool GetExcuteQueryTwoStrStr(string query, string Value1, string Value2)
        {

            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            // Add parameter
            cmd.Parameters.Add("@Value1", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value1"].Value = Value1;
            cmd.Parameters.AddWithValue(Value1);

            cmd.Parameters.Add("@Value2", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value2"].Value = Value2;
            cmd.Parameters.AddWithValue(Value2);
            //Execute a query
            if (cmd.ExecuteNonQuery() == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public bool GetExcuteQueryTwoIntStr(string query, int Value1, string Value2)
        {

            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            // Add parameter
            cmd.Parameters.Add("@Value1", NpgsqlTypes.NpgsqlDbType.Integer);
            cmd.Parameters["@Value1"].Value = Value1;
            cmd.Parameters.AddWithValue(Value1);

            cmd.Parameters.Add("@Value2", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value2"].Value = Value2;
            cmd.Parameters.AddWithValue(Value2);
            //Execute a query
            if (cmd.ExecuteNonQuery() == 1)
            {
               
                return true;
            }
            else
            {
               
                return false;
            }
        }

        public bool GetExcuteQueryThree(string query, string Value1, string Value2, string Value3)
        {

            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            // Add parameter
            cmd.Parameters.Add("@Value1", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value1"].Value = Value1;
            cmd.Parameters.AddWithValue(Value1);

            cmd.Parameters.Add("@Value2", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value2"].Value = Value2;
            cmd.Parameters.AddWithValue(Value2);

            cmd.Parameters.Add("@Value3", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value3"].Value = Value3;
            cmd.Parameters.AddWithValue(Value3);
            //Execute a query
            if (cmd.ExecuteNonQuery() == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public bool DeleteQuery(string query, string Value)
        {

            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            // Add parameter
            cmd.Parameters.Add("@Value", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value"].Value = Value;
            cmd.Parameters.AddWithValue(Value);
            //Execute a query
            if (cmd.ExecuteNonQuery() == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }


        public Boolean UpdateExcuteQuery(string query)
        {
            try
            {
                // Read command
                NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);
                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                dr.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
