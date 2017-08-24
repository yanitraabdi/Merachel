using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.UserID == 0)
            {
                user.UserStatus = true;
                user.UserJoinDate = DateTime.Now;
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.UserID);
                if (dbEntry != null)
                {
                    dbEntry.UserEmail = user.UserEmail;
                    dbEntry.UserPassword = user.UserPassword;
                    dbEntry.UserFullName = user.UserFullName;
                    dbEntry.UserAddress = user.UserAddress;
                    dbEntry.UserPhone = user.UserPhone;
                    dbEntry.UserRole = user.UserRole;
                    dbEntry.UserStatus = true;
                }
            }
            context.SaveChanges();
        }

        public User DeleteUser(int userid)
        {
            User dbEntry = context.Users.Find(userid);
            if (dbEntry != null)
            {
                dbEntry.UserStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
