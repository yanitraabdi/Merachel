using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class UserModel : GeneralModel
    {
        public UserModel()
        {
            //this.UserDependents = new List<UserDependentModel>();
        }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public bool UserStatus { get; set; }
        public string UserEmail { get; set; }
        public string UserDescription { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public string UserPassword { get; set; }
        public string StatusDescription { get; set; }

    }
}
