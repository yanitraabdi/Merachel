using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{

    public class AccountModel : GeneralModel
    {
        public AccountModel()
        {
            User = new UserModel();
            Exception = new ExceptionModel();
            UserRoles = new List<RoleInfoModel>();
        }

        public UserModel User { get; set; }
        public List<RoleInfoModel> UserRoles { get; set; }
        public bool IsFailed { get; set; }
    }

    public class RoleInfoModel : GeneralModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public int Sequence { get; set; }
    }
}
