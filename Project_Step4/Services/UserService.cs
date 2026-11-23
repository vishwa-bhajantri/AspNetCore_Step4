using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_Step4.Models;
using System.Data;
using System.Reflection;

namespace Project_Step4.Services
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Age = 29,
                    Gender = "Female",
                    Email = "emily.johnson@example.com",
                    Phone = "+816862846487",
                    City = "Pheonix",
                    Department = "Engineering",
                    Role = "Admin"
                },

                new User
                {
                    Id = 2,
                    FirstName = "Mitchel",
                    LastName = "Williams",
                    Age = 36,
                    Gender = "Male",
                    Email = "mitchel.williams@example.com",
                    Phone = "+816523479812",
                    City = "Houston",
                    Department = "Support",
                    Role = "User"
                },

                new User
                {
                    Id = 3,
                    FirstName = "Sophia",
                    LastName = "Brown",
                    Age = 27,
                    Gender = "Female",
                    Email = "sophia.brown@example.com",
                    Phone = "+817821325465",
                    City = "New York",
                    Department = "HR",
                    Role = "User"
                }
            };
        }

        public User GetUserById(int userId)
        {
            var users = GetUsers();

            return users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
