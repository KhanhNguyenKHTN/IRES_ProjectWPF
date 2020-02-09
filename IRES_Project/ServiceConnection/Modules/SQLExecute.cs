using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Models;
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

        public bool CheckUserNameQuery(string query, string searchValue)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            //add parameter
            cmd.Parameters.Add("@Value", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Value"].Value = searchValue;
            cmd.Parameters.AddWithValue(searchValue);
            // execute a query

            NpgsqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count == 1)
            {
                return false;

            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    return true;
                }
            }
            dr.Close();
            return true;
        }
        public bool InsertUserQuery(string query, Employee Emp, ref int UserId)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            //add parameter
            cmd.Parameters.Add("@UserName", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@UserName"].Value = Emp.UserName;
            cmd.Parameters.AddWithValue(Emp.UserName);

            cmd.Parameters.Add("@Email", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Email"].Value = Emp.UserEmail;
            cmd.Parameters.AddWithValue(Emp.UserEmail);

            cmd.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Phone"].Value = Emp.PhoneNb;
            cmd.Parameters.AddWithValue(Emp.PhoneNb);

            cmd.Parameters.Add("@RoleId", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@RoleId"].Value = Emp.RoleId;
            cmd.Parameters.AddWithValue(Emp.RoleId);

            cmd.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@Address"].Value = Emp.UserAddress;
            cmd.Parameters.AddWithValue(Emp.UserAddress);
            // execute a query


            //NpgsqlDataReader dr = cmd.ExecuteReader();

            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //if (dt.Rows.Count == 1)
            //{
            //    return false;

            //}
            //else
            //{
            //    if (dt.Rows.Count == 0)
            //    {
            //        return true;
            //    }
            //}
            //dr.Close();
            //return true;
            object a = null;
            a = cmd.ExecuteScalar();
            if (a != null)
            {
                UserId = Convert.ToInt32(a);
                return true;
            }
            else
                return false;
          

        }
        public bool InsertEmpQuery(string query, Employee Emp)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);
          
            //add parameter
            cmd.Parameters.Add("@EmpCode", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@EmpCode"].Value = Emp.EmployeeCode;
            cmd.Parameters.AddWithValue(Emp.EmployeeCode);

            cmd.Parameters.Add("@ResId", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@ResId"].Value = Emp.RestaurantId;
            cmd.Parameters.AddWithValue(Emp.RestaurantId);

            cmd.Parameters.Add("@UserId", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@UserId"].Value = Emp.UserId;
            cmd.Parameters.AddWithValue(Emp.UserId);

            cmd.Parameters.Add("@UserName", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@UserName"].Value = Emp.UserName;
            cmd.Parameters.AddWithValue(Emp.UserName);

            cmd.Parameters.Add("@PassWord", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@PassWord"].Value = Emp.PassWord;
            cmd.Parameters.AddWithValue(Emp.PassWord);
                
            cmd.Parameters.Add("@EmpDes", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@EmpDes"].Value = Emp.EmployeeDescription;
            cmd.Parameters.AddWithValue(Emp.EmployeeDescription);

            

            //object a = null;
            //a = cmd.ExecuteScalar();
            //if (a != null)
            //{
            //    int EmpId = Convert.ToInt32(a);
            //    return true;
            //}
            //else
            //    return false;
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
