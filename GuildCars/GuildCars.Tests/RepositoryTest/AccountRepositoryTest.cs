using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.TestData
{
    public class AccountRepositoryTest : IAccountRepository
    {
        public List<User> _users { get; set; }



        public List<User> GetAllUsers()
        {
            if (_users == null)
            {
                _users = new List<User>();
            }
            return _users;
        }

        public User GetUserByID(string UserID)
        {
            foreach (User u in GetAllUsers())
            {
                if (u.UserID == UserID)
                    return u;
            }
            return null;
        }
    }
}
