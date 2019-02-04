using CLC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CLC.Services.Data
{
    public class SecurityDAO
    {

        private SqlConnection connection;

        public SecurityDAO(SqlConnection connection)
        {
            this.connection = connection;
        }

        public Boolean login(LoginModel user)
        { 
            SqlCommand command = new SqlCommand("SELECT * FROM [Users] WHERE USERNAME = @user AND PASSWORD = @pass", connection);
            command.Parameters.AddWithValue("@user", user.Username);
            command.Parameters.AddWithValue("@pass", user.Password);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return true;
                }
            }

            return false;
        }

        public Boolean register(UserModel user)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Users] ([ID], [USERNAME], [PASSWORD], [FIRSTNAME], [LASTNAME], [SEX], [AGE], [STATE], [EMAIL], [ROLE]) VALUES (NULL, @user, @pass, @fname, @lname, @sex, @age, @state, @email, 0");
            command.Parameters.AddWithValue("@user", user.Username);
            command.Parameters.AddWithValue("@pass", user.Password);
            command.Parameters.AddWithValue("@fname", user.Firstname);
            command.Parameters.AddWithValue("@lname", user.Lastname);
            command.Parameters.AddWithValue("@sex", user.Sex);
            command.Parameters.AddWithValue("@age", user.Age);
            command.Parameters.AddWithValue("@state", user.State);
            command.Parameters.AddWithValue("@email", user.Email);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if(reader.RecordsAffected != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}