using Dapper;
using GardenLog.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GardenLog.Services
{
    public class GetUsersService
    {
        // Summary:
        // Gets all user data from DB.

        public List<User> GetUsers(UserContext userContext)
        {
            using SqlConnection connection = new (userContext.Database.GetConnectionString());
            string queryString = $"SELECT * From dbo.Users";
            connection.Open();

            var users = connection.Query<User>(queryString).ToList();
            return users;
        }
    }
}
