using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implements.MasterData;
using Implements.Workers;
using Model.Models;
using Service.Modules;

namespace Implements.MasterData.Modules
{
   public class EmployeeImplement
    {
        public static ObservableCollection<Employee> getListEmployee()
        {
            string query = $"select employee_code,user_display_name,role_name,employee_description,user_phone, employee.active" +
                $" from ires.employee,ires.user_info, ires.role where ires.employee.user_id = ires.user_info.user_id and ires.employee.active = 'true' ";

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
                    //RoleId = Convert.ToInt32(dt.Rows[i]["role_id"]),
                    Role = dt.Rows[i]["role_name"].ToString(),
                    PhoneNb = dt.Rows[i]["user_phone"].ToString(),
                    Active = Convert.ToBoolean(dt.Rows[i]["active"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<Employee> getListDeletedEmployee()
        {
            string query = $"select employee_code,user_display_name,role_name,employee_description,user_phone , employee.active from ires.employee,ires.user_info, ires.role where ires.employee.user_id = ires.user_info.user_id and ires.employee.active = 'false' ";

            ObservableCollection<Employee> result = new ObservableCollection<Employee>();

            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
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
                    Role = dt.Rows[i]["role_name"].ToString(),
                    PhoneNb = dt.Rows[i]["user_phone"].ToString(),
                    Active = Convert.ToBoolean(dt.Rows[i]["active"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<Employee> searchListEmployee(string search_text)
        {
            string query = $"select employee_code,user_display_name,role_name,employee_description,user_phone , employee.active from ires.employee,ires.user_info, ires.role " +
                $" where (ires.employee.user_id = ires.user_info.user_id and ires.employee.active = 'true') and" +
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
                    Role = dt.Rows[i]["role_name"].ToString(),
                    PhoneNb = dt.Rows[i]["user_phone"].ToString(),
                    Active = Convert.ToBoolean(dt.Rows[i]["active"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<Employee> searchListDeletedEmployee(string search_text)
        {
            string query = $"select employee_code,user_display_name,role_name,employee_description,user_phone, employee.active from ires.employee,ires.user_info, ires.role " +
                $" where (ires.employee.user_id = ires.user_info.user_id and ires.employee.active = 'false') and" +
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
                    Role = dt.Rows[i]["role_name"].ToString(),
                    PhoneNb = dt.Rows[i]["user_phone"].ToString(),
                    Active = Convert.ToBoolean(dt.Rows[i]["active"])
                };
                result.Add(item);
            }

            return result;
        }
        public static bool UpdatePhone(string PhoneNb, string EmpCode)
        {
  
            string query = $"UPDATE ires.User_info SET user_phone = @Value1" +
                           $" from ires.Employee" +
                           $" WHERE employee_code = '' || @Value2 ||''" +
                           $" and Employee.user_id = User_info.user_id";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.GetExcuteQueryTwoStrStr(query, PhoneNb, EmpCode); ;
        }
        public static bool UpdateRole(int RoleId, string EmpCode)
        {

            string query = $"UPDATE ires.Employee SET role_id = @Value1" +
                           $" WHERE employee_code = '' || @Value2 ||''";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.GetExcuteQueryTwoIntStr(query, RoleId, EmpCode); ;
        }
        public static bool DeleteEmp(string EmpCode)
        {

            string query = $"UPDATE ires.Employee SET active = false" +
                           $" WHERE employee_code = '' || @Value ||''";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.DeleteQuery(query, EmpCode); 
        }
        public static bool ActiveEmp(string EmpCode)
        {

            string query = $"UPDATE ires.Employee SET active = true" +
                           $" WHERE employee_code = '' || @Value ||''";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.DeleteQuery(query, EmpCode);
        }

    }
}
