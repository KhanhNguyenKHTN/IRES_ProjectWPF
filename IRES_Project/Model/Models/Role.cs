using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Role
    {
        private int _RoleId;
        private string _RoleCode;
        private string _RoleName;
        private string _RoleDesc;
        private string _CreatedBy;
        private DateTime _CreatedDatetime;
        private string _UpdatedBy;
        private DateTime _UpdatedDatetime;
        private bool _Active;
        private int _Version;
        public Role() { }

        public int RoleId { get => _RoleId; set => _RoleId = value; }
        public string RoleCode { get => _RoleCode; set => _RoleCode = value; }
        public string RoleName { get => _RoleName; set => _RoleName = value; }
        public string RoleDesc { get => _RoleDesc; set => _RoleDesc = value; }
        public string CreatedBy { get => _CreatedBy; set => _CreatedBy = value; }
        public DateTime CreatedDatetime { get => _CreatedDatetime; set => _CreatedDatetime = value; }
        public string UpdatedBy { get => _UpdatedBy; set => _UpdatedBy = value; }
        public DateTime UpdatedDatetime { get => _UpdatedDatetime; set => _UpdatedDatetime = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int Version { get => _Version; set => _Version = value; }
    }
}
