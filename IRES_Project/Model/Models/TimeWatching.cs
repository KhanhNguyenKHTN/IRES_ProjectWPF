using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class TimeWatching
    {
        private string modeTime;
        private string timeSearch;

        public string ModeTime { get => modeTime; set => modeTime = value; }
        public string TimeSearch { get => timeSearch; set => timeSearch = value; }
    }
}
