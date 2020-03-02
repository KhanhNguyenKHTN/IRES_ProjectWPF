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
            cmd.Parameters.Add("@UserDisplayName", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@UserDisplayName"].Value = Emp.EmployeeName;
            cmd.Parameters.AddWithValue(Emp.EmployeeName);

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
        public bool UpdateUserQuery(string query, Employee Emp)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            //add parameter
            cmd.Parameters.Add("@UserDisplayName", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@UserDisplayName"].Value = Emp.EmployeeName;
            cmd.Parameters.AddWithValue(Emp.EmployeeName);

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

            cmd.Parameters.Add("@EmpCode", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@EmpCode"].Value = Emp.EmployeeCode;
            cmd.Parameters.AddWithValue(Emp.EmployeeCode);

            if (cmd.ExecuteNonQuery() == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public bool UpdateEmpQuery(string query, Employee Emp)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            //add parameter
            cmd.Parameters.Add("@ResId", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@ResId"].Value = Emp.RestaurantId;
            cmd.Parameters.AddWithValue(Emp.RestaurantId);

            cmd.Parameters.Add("@UserName", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@UserName"].Value = Emp.UserName;
            cmd.Parameters.AddWithValue(Emp.UserName);

            cmd.Parameters.Add("@PassWord", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@PassWord"].Value = Emp.PassWord;
            cmd.Parameters.AddWithValue(Emp.PassWord);

            cmd.Parameters.Add("@EmpDes", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@EmpDes"].Value = Emp.EmployeeDescription;
            cmd.Parameters.AddWithValue(Emp.EmployeeDescription);

            cmd.Parameters.Add("@EmpCode", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@EmpCode"].Value = Emp.EmployeeCode;
            cmd.Parameters.AddWithValue(Emp.EmployeeCode);

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
        public bool InsertDishQuery(string query, DishModel dish, ref int Id, string hour, string min)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            //add parameter
            cmd.Parameters.Add("@dish_name", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@dish_name"].Value = dish.DishName;
            cmd.Parameters.AddWithValue(dish.DishName);

           // DateTime dishCookTime = new DateTime(2020, 3, 4, Convert.ToInt32(hour), Convert.ToInt32(min), 0);
            TimeSpan cook = new TimeSpan(Convert.ToInt32( hour), Convert.ToInt32(min), 0);
            cmd.Parameters.Add("@cook_time", NpgsqlTypes.NpgsqlDbType.Time);
            cmd.Parameters["@cook_time"].Value = cook;
            cmd.Parameters.AddWithValue(cook);

            //cmd.Parameters.Add("@cook_time_hour", NpgsqlTypes.NpgsqlDbType.Text);
            //cmd.Parameters["@cook_time_hour"].Value = hour;
            //cmd.Parameters.AddWithValue(hour);

            //cmd.Parameters.Add("@cook_time_min", NpgsqlTypes.NpgsqlDbType.Text);
            //cmd.Parameters["@cook_time_min"].Value = min;
            //cmd.Parameters.AddWithValue(min);

            cmd.Parameters.Add("@dish_cost", NpgsqlTypes.NpgsqlDbType.Numeric);
            cmd.Parameters["@dish_cost"].Value = Convert.ToDecimal(dish.DishCost);
            cmd.Parameters.AddWithValue(Convert.ToDecimal(dish.DishCost));

            cmd.Parameters.Add("@dish_type", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@dish_type"].Value = dish.DishType.ToUpper();
            cmd.Parameters.AddWithValue(dish.DishType.ToUpper());

            cmd.Parameters.Add("@dish_cate", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@dish_cate"].Value = dish.DishCategoryId;
            cmd.Parameters.AddWithValue(dish.DishCategoryId);
            
            object a = null;
            a = cmd.ExecuteScalar();
            if (a != null)
            {
                Id = Convert.ToInt32(a);
                return true;
            }
            else
                return false;
        }
        public bool UpdateDishCodeQuery(string query, int dishId)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);
            string dishCodeString="D";
            if( 0<= dishId && dishId <10 )
            {
                dishCodeString = "D-000" + dishId.ToString();
            }
            else if(dishId>=10 && dishId < 100)
            {
                dishCodeString = "D-00" + dishId.ToString();
            }
            else if (dishId >= 100 && dishId < 1000)
            {
                dishCodeString = "D-0" + dishId.ToString();
            }
            else if (dishId >= 1000 && dishId < 10000)
            {
                dishCodeString = "D-" + dishId.ToString();
            }
            //add parameter
            cmd.Parameters.Add("@dish_code", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@dish_code"].Value = dishCodeString;
            cmd.Parameters.AddWithValue(dishCodeString);

            cmd.Parameters.Add("@dish_Id", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@dish_Id"].Value = dishId;
            cmd.Parameters.AddWithValue(dishId);
            if (cmd.ExecuteNonQuery() == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public bool InsertDishItemQuery(string query, DishItem item, ref int itemId, int dishId)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);

            //add parameter
            cmd.Parameters.Add("@dish_id", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@dish_id"].Value = dishId;
            cmd.Parameters.AddWithValue(dishId);

            cmd.Parameters.Add("@item_id", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@item_id"].Value = item.ItemId;
            cmd.Parameters.AddWithValue(item.ItemId);
            
            cmd.Parameters.Add("@item_quantity", NpgsqlTypes.NpgsqlDbType.Numeric);
            cmd.Parameters["@item_quantity"].Value = item.ItemQuantity;
            cmd.Parameters.AddWithValue(item.ItemQuantity);
            
            object a = null;
            a = cmd.ExecuteScalar();
            if (a != null)
            {
                itemId = Convert.ToInt32(a);
                return true;
            }
            else
                return false;
        }
        public bool UpdateItemCodeQuery(string query, int itemId)
        {
            // Read command
            NpgsqlCommand cmd = new NpgsqlCommand(query, SQLConnection.Instance.Connection);
            string dishCodeString = "D";
            if (0 <= itemId && itemId < 10)
            {
                dishCodeString = "D-000" + itemId.ToString() +"-I";
            }
            else if (itemId >= 10 && itemId < 100)
            {
                dishCodeString = "D-00" + itemId.ToString() + "-I";
            }
            else if (itemId >= 100 && itemId < 1000)
            {
                dishCodeString = "D-0" + itemId.ToString() + "-I";
            }
            else if (itemId >= 1000 && itemId < 10000)
            {
                dishCodeString = "D-" + itemId.ToString() + "-I";
            }
            //add parameter
            cmd.Parameters.Add("@dish_item_code", NpgsqlTypes.NpgsqlDbType.Text);
            cmd.Parameters["@dish_item_code"].Value = dishCodeString;
            cmd.Parameters.AddWithValue(dishCodeString);

            cmd.Parameters.Add("@dish_item_id", NpgsqlTypes.NpgsqlDbType.Bigint);
            cmd.Parameters["@dish_item_id"].Value = itemId;
            cmd.Parameters.AddWithValue(itemId);
            if (cmd.ExecuteNonQuery() == 1)
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
