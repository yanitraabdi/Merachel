using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnumStringValues;

namespace Merachel.Libraries
{
    public enum LoginMessage
    {
        [StringValue("Success")]
        SUCCESS = 0,

        [StringValue("Exception management noticed that there is problem when processing your system.")]
        CUSTOM = 20004,

        [StringValue("Invalid User and/or Password")]
        INVALID_USER_OR_PASSWORD = 20001,

        [StringValue("Invalid Email Address")]
        INVALID_EMAIL_ADDRESS = 20005,

        [StringValue("Please input correct id, last name, and PTFI email")]
        USER_NOT_EXISTS = 20000,

        [StringValue("User is inactive")]
        USER_INACTIVE = 20002,

        [StringValue("User is already registered")]
        USER_REGISTERED = 20003,

        [StringValue("Your account have been blocked due to login attempt limitation, please try again in ")]
        USER_BLOCKED = 20011,

        [StringValue("Invalid data validation. Data doesn't match with trivelio system.")]
        DATA_DOES_NOT_MATCH = 20006,

        [StringValue("Data doesn't exists")]
        DATA_NOT_EXISTS = 20009,

        [StringValue("Password doesn't match")]
        PASSWORD_DOES_NOT_MATCH = 20007,

        [StringValue("Password does not meet the minimum requirement length. Minimum length is ")]
        PASSWORD_MIN_LENGTH = 20008,

        [StringValue("You have been reset your password, please input your new password from the link that had been sent to your email")]
        PASSWORD_RESET = 20010,

        [StringValue("System cannot reset your password because user currently is not active")]
        PASSWORD_CANNOT_RESET = 20014,

        [StringValue("New password cannot be as same as the previous one")]
        PASSWORD_CHANGE_SAME = 20013,

        [StringValue("Link is expired. User cannot use this is anymore.")]
        LINK_EXPIRED = 20012,

        [StringValue("Custom message for registration")]
        CUSTOM_REGISTRATION = 20015,
    }
}
