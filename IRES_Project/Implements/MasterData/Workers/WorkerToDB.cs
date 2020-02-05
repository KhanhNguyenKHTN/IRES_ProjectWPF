using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Modules;

namespace Implements.MasterData.Workers
{
    class WorkerToDB
    {
        public WorkerToDB()
        {

        }
        public DataTable getRecordsCommand(string query)
        {

            SQLExecute sqlExecute = new SQLExecute();

            DataTable dt = sqlExecute.GetExcuteQuery(query);


            return dt;
        }

        public Boolean updateCommand(string query)
        {

            SQLExecute sqlExecute = new SQLExecute();

            return sqlExecute.UpdateExcuteQuery(query);
        }
    }
}
