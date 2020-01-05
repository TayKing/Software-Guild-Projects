using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GuildCars.Data.ADO
{
    class AccountRepositoryADO : IAccountRepository
    {
        public List<User> GetAllUsers()
        {
            List<User> Users = new List<User>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserSelectAll", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User CurrentRow = new User
                        {
                            UserID = dr["ID"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Email = dr["Email"].ToString(),
                            Role = dr["UserRole"].ToString()
                        };

                        Users.Add(CurrentRow);
                    }
                }
            }
            return Users;
        }

        public User GetUserByID(string UserID)
        {
            List<User> Users = new List<User>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserSelectByID", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User CurrentRow = new User
                        {
                            UserID = dr["ID"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Email = dr["Email"].ToString(),
                            Role = dr["UserRole"].ToString()
                        };

                        Users.Add(CurrentRow);
                    }
                }
            }
            if (Users.Count > 0)
                return Users[0];
            return null;
        }
    }
}
