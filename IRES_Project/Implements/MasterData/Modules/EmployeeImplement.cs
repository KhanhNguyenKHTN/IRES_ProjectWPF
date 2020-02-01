using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implements.MasterData.Workers;
using Model.Models;
using Service.Modules;

namespace Implements.MasterData.Modules
{
   public class EmployeeImplement
    {
        public static ObservableCollection<Employee> getListEmployee()
        {
            string query = $"select employee_code,user_display_name,role_name,employee.role_id,employee_description,employee_phone from ires.employee,ires.user_info, ires.role where ires.employee.user_id = ires.user_info.user_id and ires.employee.role_id = ires.role.role_id and ires.employee.active = 'true' ";

            ObservableCollection<Employee> result = new ObservableCollection<Employee>();

            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if(dt.Rows.Count==0)
            {
                Employee def_item = new Employee();
                def_item = new Employee
                {
                    EmployeeCode = "Rỗng",
                    EmployeeName = "Rỗng",
                    RoleId = -1,
                    Role = "Rỗng",
                    PhoneNb = "Rỗng"
                };
                result.Add(def_item);
                return result;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee item = new Employee();

                item = new Employee
                {
                    EmployeeCode = dt.Rows[i]["employee_code"].ToString(),
                    EmployeeName = dt.Rows[i]["user_display_name"].ToString(),
                    RoleId = Convert.ToInt32(dt.Rows[i]["role_id"]),
                    Role = dt.Rows[i]["role_name"].ToString(),
                    PhoneNb = dt.Rows[i]["employee_phone"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<Employee> searchListEmployee(string search_text)
        {
            string query = $"select employee_code,user_display_name,role_name,employee.role_id,employee_description,employee_phone from ires.employee,ires.user_info, ires.role " +
                $" where (ires.employee.user_id = ires.user_info.user_id and ires.employee.role_id = ires.role.role_id and ires.employee.active = 'true') and" +
                $" (lower(user_display_name) like LOWER('%' || @search_text || '%') or lower(role_name) like lower('%' || @search_text || '%') )";
            
            ObservableCollection<Employee> result = new ObservableCollection<Employee>();
            SQLExecute sqlExecute = new SQLExecute();

            DataTable dt = sqlExecute.GetExcuteQueryOne(query, search_text);

            if (dt.Rows.Count == 0)
            {
                Employee def_item = new Employee();
                def_item = new Employee
                {
                    EmployeeCode = "Rỗng",
                    EmployeeName = "Rỗng",
                    RoleId = -1,
                    Role = "Rỗng",
                    PhoneNb = "Rỗng"
                };
                result.Add(def_item);
                return result;
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee item = new Employee();

                item = new Employee
                {
                    EmployeeCode = dt.Rows[i]["employee_code"].ToString(),
                    EmployeeName = dt.Rows[i]["user_display_name"].ToString(),
                    RoleId = Convert.ToInt32(dt.Rows[i]["role_id"]),
                    Role = dt.Rows[i]["role_name"].ToString(),
                    PhoneNb = dt.Rows[i]["employee_phone"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
        public static bool UpdatePhone(string PhoneNb, string user_name)
        {
  
            string query = $"UPDATE ires.Employee SET employee_phone = @Value1" +
                           $" from ires.User_info" +
                           $" WHERE User_info.user_display_name = '' || @Value2 ||'' and Employee.user_id = User_info.user_id";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.GetExcuteQueryTwo(query, PhoneNb, user_name); ;
        }

    //    using (SqlConnection conn =
    //        new SqlConnection(connectionString))
    //    {
    //        conn.Open();
    //        using (SqlCommand cmd =
    //            new SqlCommand("UPDATE Employees SET firstname=@firstname, lastname=@lastname" +
    //                " WHERE Id=@Id", conn))
    //        {
    //            cmd.Parameters.AddWithValue("@Id",user.UserId );
    //            cmd.Parameters.AddWithValue("@firstname",user.FirstName);
    //            cmd.Parameters.AddWithValue("@lastname",user.LastName);
    //            //add whatever parameters you required to update here
    //            int rows = cmd.ExecuteNonQuery();

    //        }
    //}



    }
}
