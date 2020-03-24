using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.Workers;
using System.Data;

namespace Implements.Common
{
    public class LoginImplement
    {
        public UserModel getUser(UserModel account)
        {
            string query = $"SELECT * FROM ires.employee WHERE user_name='{account.Username}' and password='{account.Password}'";

            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //account.Role = dt.Rows[i]["role_id"].ToString();
            }

            return account;
        }
    }
}
