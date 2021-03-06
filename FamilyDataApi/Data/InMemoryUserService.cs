using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdultDataAPI.Models;

namespace AdultDataAPI.Data{
    public class InMemoryUserService :IUserService{
        private List<User> users;

        public InMemoryUserService(){
            users = new[]{
                new User{
                    UserName = "admin",
                    Password = "admin",
                    Role = "admin"
                },
                new User{
                    UserName = "user",
                    Password = "user",
                    Role = "user"
                }
            }.ToList();
        }


        public async Task<User> ValidateUser(string userName, string password){
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null){
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)){
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
    
    
}