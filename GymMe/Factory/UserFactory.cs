using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class UserFactory
    {
        public static Response<MsUser> createUser(string username, string email,string gender, DateTime DOB, string password, string role)
        {
            MsUser user = new MsUser()
            {
                UserName = username,
                UserEmail = email,
                UserDOB = DOB,
                UserGender = gender,
                UserPassword = password,
                UserRole = role,
            };

            UserRepository.insertUser(user);

            return new Response<MsUser>()
            {
                Success = true,
                Message = "User successfully registered!",
                Data = user
            };
        }
    }
}