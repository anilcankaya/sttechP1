using shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Services
{
    public class FakeUserService : IUserService
    {
        private List<User> users;
        public FakeUserService()
        {
            users = new List<User>
            {
                new User{ Name="Bekir", LastName="Dönmez", Role="Admin", Email="user1@test.com", Password="1234" },
                new User{ Name="Türkay", LastName="Ürkmez", Role="Admin", Email="user2@test.com", Password="1234" },
                new User{ Name="Mert", LastName="Pişmişoğlu", Role="Editor", Email="user3@test.com", Password="1234" },
                new User{ Name="Birsen", LastName="Karanlık", Role="User", Email="user4@test.com", Password="1234" },


            };
        }
        public User Validate(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

      
    }
}
