using CLC.Models;
using CLC.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CLC.Services.Business
{
    public class SecurityService
    {
        public Boolean login(LoginModel user)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CLC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();

            SecurityDAO dao = new SecurityDAO(connection);

            bool result = dao.login(user);

            connection.Close();

            return result;
        }

        public Boolean register(UserModel user)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CLC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();

            SecurityDAO dao = new SecurityDAO(connection);

            bool result = dao.register(user);

            connection.Close();

            return result;
        }
    }
}