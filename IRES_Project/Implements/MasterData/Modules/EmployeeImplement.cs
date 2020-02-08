﻿using System;
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
            string query = $"select employee_code,user_display_name,role_name,employee.role_id,employee_description,user_phone, employee.active" +
                $" from ires.employee,ires.user_info, ires.role where ires.employee.user_id = ires.user_info.user_id and ires.employee.role_id = ires.role.role_id and ires.employee.active = 'true' ";

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
                    PhoneNb = dt.Rows[i]["user_phone"].ToString(),
                    Active = Convert.ToBoolean(dt.Rows[i]["active"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<Employee> getListDeletedEmployee()
        {
            string query = $"select employee_code,user_display_name,role_name,employee.role_id,employee_description,user_phone , employee.active from ires.employee,ires.user_info, ires.role where ires.employee.user_id = ires.user_info.user_id and ires.employee.role_id = ires.role.role_id and ires.employee.active = 'false' ";

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
                    RoleId = Convert.ToInt32(dt.Rows[i]["role_id"]),
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
            string query = $"select employee_code,user_display_name,role_name,employee.role_id,employee_description,user_phone , employee.active from ires.employee,ires.user_info, ires.role " +
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
                    PhoneNb = dt.Rows[i]["user_phone"].ToString(),
                    Active = Convert.ToBoolean(dt.Rows[i]["active"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<Employee> searchListDeletedEmployee(string search_text)
        {
            string query = $"select employee_code,user_display_name,role_name,employee.role_id,employee_description,user_phone, employee.active from ires.employee,ires.user_info, ires.role " +
                $" where (ires.employee.user_id = ires.user_info.user_id and ires.employee.role_id = ires.role.role_id and ires.employee.active = 'false') and" +
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
        public static bool CheckEmpUserName(string UserName)
        {

            //string query = $"SELECT * FROM ires.employee" +
            //               $" WHERE user_name = '' ||@Value|| '' ";
            string query = $"select * from ires.employee where employee.user_name ='' || @Value ||''";

            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.CheckUserNameQuery(query, UserName);
        }
        public static bool InsertUserToDb(Employee Emp, ref int UserId)
        {
            string query = $"insert into ires.user_info(user_display_name,user_dob, user_email,user_phone,role_id, user_address,user_status, created_by,created_datetime,updated_by, updated_datetime,active,version)" +
                                             $" values('' || @UserName ||'', current_date, '' || @Email ||'', '' || @Phone ||'',  @RoleId, '' || @Address ||'', 'ACTIVE', 'Admin', CURRENT_TIMESTAMP(0), 'Admin', CURRENT_TIMESTAMP(0), true, '0') returning user_id";

            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.InsertUserQuery(query, Emp, ref UserId);
        }
        public static bool InsertEmpToDb(Employee Emp)
        {
            string query = $"insert into ires.employee(employee_code, restaurant_id,user_id,employee_status,user_name,password,employee_description,created_by,created_datetime, updated_by,updated_datetime,active,version,role_id)" +
                $"                               values('' || @EmpCode ||'', @ResId,  @UserId, 'ACTIVE', '' || @UserName ||'','' || @PassWord ||'', '' || @EmpDes ||'', 'Admin', CURRENT_TIMESTAMP(0), 'Admin', CURRENT_TIMESTAMP(0), true, 0, @RoleId)";

            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.InsertEmpQuery(query, Emp);
        }





    }
}
