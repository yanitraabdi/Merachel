using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


using Dapper;

using EnumStringValues;

using Merachel.Models;
using Merachel.Libraries;

namespace Merachel.BusinessProcess
{
    public class LoginServices : GeneralServices
    {
        public AccountModel GetSignInUser(string userName, string password)
        {
            AccountModel oResult = new AccountModel();

            try
            {
                UserInformationModel oUserInfo = GetValidateUser(userName);
            }
            catch (Exception ex)
            {
                oResult.Exception = oException.Set(ex);
            }
            return oResult;
        }

        private UserInformationModel GetValidateUser(string userName)
        {
            UserInformationModel oResponse = new UserInformationModel();
            UserModel rdUser = new UserModel();

            db = new SQLContext();
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_login_users",
                    new
                    {
                        userName = userName
                    },
                    commandType: CommandType.StoredProcedure))
                {
                    //get user header and details
                    rdUser = reader.Read<UserModel>().FirstOrDefault();
                }
            }

            if (rdUser != null)
            {
                oResponse.User = rdUser;

                oResponse.Exception = new ExceptionModel()
                {
                    ErrorCode = Convert.ToInt16(LoginMessage.SUCCESS),
                    ErrorDesc = LoginMessage.SUCCESS.GetStringValue()
                };
            }
            else
            {
                oResponse.Exception = new ExceptionModel()
                {
                    ErrorCode = Convert.ToInt16(LoginMessage.USER_NOT_EXISTS),
                    ErrorDesc = LoginMessage.USER_NOT_EXISTS.GetStringValue()
                };
            }

            return oResponse;
        }

        private bool CheckPassword(UserInformationModel oUser, string inputPassword)
        {
            //string hashedPass = GetHashPassword(oUser.User.NomorInduk, inputPassword, oUser.User.Salt);

            if (oUser.User.UserPassword.Equals(inputPassword))
                return true;
            else
                return false;
        }

        //private string GetHashPassword(string nomorInduk, string password, string salt)
        //{
        //    string tobeHash = string.Concat(nomorInduk.ToLower(), password, salt);
        //    SHA512Managed hashTool = new SHA512Managed();
        //    byte[] passAsByte = Encoding.UTF8.GetBytes(tobeHash);
        //    byte[] hashed = hashTool.ComputeHash(passAsByte);
        //    hashTool.Clear();

        //    string hashedPass = Convert.ToBase64String(hashed);
        //    return hashedPass;
        //}

        //private void GetEncryptedPassword(string nomorInduk, string password, out string encryptedPassword)
        //{
        //    encryptedPassword = string.Empty;

        //    using (var item = new CryptographyConfiguration())
        //    {
        //        encryptedPassword = item.EncryptText(nomorInduk + "!@#" + password);
        //    }
        //}

        //private ExceptionModel GetPasswordRequirement(string newPassword, int userId)
        //{
        //    PasswordPolicyModel oPassPolicy = new PasswordPolicyModel();
        //    ExceptionModel oResult = new ExceptionModel();

        //    try
        //    {
        //        using (var svc = new LookupServices())
        //        {
        //            //IEnumerable<LookupSetting> lookupData = svc.GetLookupSetting("PASSWORD_POLICY");
        //            //if (lookupData != null && lookupData.Count() > 0)
        //            //{
        //            //    oPassPolicy.LengthPolicy = Convert.ToInt16(lookupData.Where(x => x.Code.Equals("LENGTH_POLICY")).FirstOrDefault().Value);
        //            //    oPassPolicy.ChangePolicy = Convert.ToInt16(lookupData.Where(x => x.Code.Equals("CHANGE_POLICY")).FirstOrDefault().Value);
        //            //}

        //            oPassPolicy.MaxAttempt = 9999;
        //            oPassPolicy.LockedTime = 9999;
        //        }

        //        if (newPassword.Trim().Length < oPassPolicy.LengthPolicy)
        //        {
        //            oResult.ErrorCode = Convert.ToInt16(LoginMessage.PASSWORD_MIN_LENGTH);
        //            oResult.ErrorDesc = LoginMessage.PASSWORD_MIN_LENGTH.GetStringValue() + oPassPolicy.LengthPolicy + " character(s)";
        //            return oResult;
        //        }

        //        IEnumerable<PasswordHistoryModel> rdHistory = null;

        //        db = new SQLContext();
        //        using (var conn = db.Database.Connection)
        //        {
        //            using (var reader = conn.QueryMultiple("dbo.s_get_password_history",
        //            new
        //            {
        //                userid = userId,
        //                count = oPassPolicy.ChangePolicy
        //            },
        //            commandType: CommandType.StoredProcedure))
        //            {
        //                rdHistory = reader.Read<PasswordHistoryModel>();
        //            }
        //        }
        //        if (rdHistory != null)
        //        {
        //            foreach (var item in rdHistory)
        //            {
        //                string pass = string.Empty;
        //                using (var crypto = new CryptographyConfiguration())
        //                {
        //                    pass = crypto.DecryptText(item.PasswordEncrypted.Trim());
        //                }
        //                string[] str = pass.Split(new[] { "!@#" }, StringSplitOptions.RemoveEmptyEntries);
        //                if (newPassword.Equals(str[1], StringComparison.OrdinalIgnoreCase))
        //                {
        //                    oResult.ErrorCode = Convert.ToInt16(LoginMessage.PASSWORD_CHANGE_SAME);
        //                    oResult.ErrorDesc = LoginMessage.PASSWORD_CHANGE_SAME.GetStringValue() + oPassPolicy.ChangePolicy + " password(s) before.";
        //                    return oResult;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oResult = oException.Set(ex);
        //    }

        //    return oResult;
        //}

        //private ExceptionModel PostUserStatus(UserModel oParam)
        //{
        //    ExceptionModel oResult = new ExceptionModel();

        //    try
        //    {
        //        db = new SQLContext();
        //        using (var conn = db.Database.Connection)
        //        {
        //            var reader = Convert.ToString(conn.ExecuteScalar("dbo.s_post_user_status",
        //                 new
        //                 {
        //                     userid = oParam.UserId,
        //                     email = oParam.Email,
        //                     password = oParam.UserPassword,
        //                     salt = oParam.Salt,
        //                     status = oParam.Status,
        //                     encryptedPassword = oParam.UserPasswordEncryted
        //                 },
        //                commandType: CommandType.StoredProcedure));

        //            if (reader == "1")
        //            {
        //                oResult.ErrorCode = Convert.ToInt16(LoginMessage.SUCCESS);
        //            }
        //            else
        //            {
        //                if (reader.Length > 3) //temp by estu to prevent registration
        //                {
        //                    oResult.ErrorCode = Convert.ToInt16(LoginMessage.CUSTOM_REGISTRATION);
        //                    oResult.ErrorDesc = reader;
        //                }
        //                else
        //                {
        //                    oResult.ErrorCode = Convert.ToInt16(LoginMessage.CUSTOM);
        //                    oResult.ErrorDesc = "Error while execute scalar";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oResult = oException.Set(ex);
        //    }

        //    return oResult;
        //}

        //private ExceptionModel PostLoginAttempt(UserModel oParam, bool isFailed)
        //{
        //    ExceptionModel oResult = new ExceptionModel();

        //    try
        //    {
        //        DateTime? lastFailedDate = DateTime.UtcNow;
        //        DateTime? lastSuccessDate = DateTime.UtcNow;
        //        int? failed = 0;
        //        if (isFailed)
        //        {
        //            lastSuccessDate = null;
        //            failed = oParam.TotalFailedAttempt + 1;
        //        }
        //        else
        //        {
        //            lastFailedDate = null;
        //            failed = 0;
        //        }

        //        db = new SQLContext();
        //        using (var conn = db.Database.Connection)
        //        {
        //            int reader = Convert.ToInt16(conn.ExecuteScalar("dbo.s_post_login_attempt",
        //                 new
        //                 {
        //                     userid = oParam.UserId,
        //                     failed = failed,
        //                     lastfailed = lastFailedDate,
        //                     lastsuccess = lastSuccessDate
        //                 },
        //                commandType: CommandType.StoredProcedure));

        //            if (reader != 1)
        //            {
        //                oResult.ErrorCode = Convert.ToInt16(LoginMessage.CUSTOM);
        //                oResult.ErrorDesc = "Error while execute scalar";
        //            }
        //            else
        //                oResult.ErrorCode = Convert.ToInt16(LoginMessage.SUCCESS);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oResult = oException.Set(ex);
        //    }

        //    return oResult;
        //}

        //public ExceptionModel PostChangePassword(int userId, string newPassword, string confirmPassword)
        //{
        //    ExceptionModel oResult = new ExceptionModel();
        //    try
        //    {
        //        if (newPassword.Equals(confirmPassword, StringComparison.OrdinalIgnoreCase))
        //        {
        //            oResult = GetPasswordRequirement(confirmPassword, userId);
        //            if (oResult.ErrorCode != 0)
        //                return oResult;

        //            CryptographyConfiguration oCrypto = new CryptographyConfiguration();
        //            AccountModel oSession = GetSessionInfo();
        //            string salt = oCrypto.GenerateSalt(32);
        //            string passwordHashing = GetHashPassword(oSession.User.NomorInduk, confirmPassword, salt);
        //            string encryptedPassword = string.Empty;
        //            GetEncryptedPassword(oSession.User.NomorInduk, confirmPassword, out encryptedPassword);

        //            db = new SQLContext();
        //            using (var conn = db.Database.Connection)
        //            {
        //                var reader = Convert.ToString(conn.ExecuteScalar("dbo.s_post_user_change_password",
        //                     new
        //                     {
        //                         userid = userId,
        //                         password = passwordHashing,
        //                         encryptedPassword = encryptedPassword,
        //                         salt = salt,

        //                     },
        //                    commandType: CommandType.StoredProcedure));

        //                if (reader == "1")
        //                {
        //                    oResult.ErrorCode = Convert.ToInt16(LoginMessage.SUCCESS);
        //                }
        //                else
        //                {
        //                    if (reader.Length > 3) //temp by estu to prevent registration
        //                    {
        //                        oResult.ErrorCode = Convert.ToInt16(LoginMessage.CUSTOM_REGISTRATION);
        //                        oResult.ErrorDesc = reader;
        //                    }
        //                    else
        //                    {
        //                        oResult.ErrorCode = Convert.ToInt16(LoginMessage.CUSTOM);
        //                        oResult.ErrorDesc = "Error while execute scalar";
        //                    }
        //                }
        //            }

        //            if (oResult.ErrorCode != 0)
        //                return oResult;
        //        }
        //        else
        //        {
        //            oResult.ErrorCode = Convert.ToInt16(LoginMessage.PASSWORD_DOES_NOT_MATCH);
        //            oResult.ErrorDesc = LoginMessage.PASSWORD_DOES_NOT_MATCH.GetStringValue();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oResult = oException.Set(ex);
        //    }
        //    return oResult;
        //}

    }
}
