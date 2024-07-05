using Final_Project.Model;
using Final_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Final_Project.Controller
{
    public class UserController
    {
        public static Response<MsUser> validateUsername(String curName)
        {
            if (String.IsNullOrEmpty(curName))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username cannot be empty!",
                    Data = null
                };
            }

            if (curName.Length < 5 || curName.Length > 15)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Length must be between 5 to 15! (Inclusive)",
                    Data = null
                };
            }

            Regex userRegex = new Regex(@"^[a-zA-Z ]+$");
            if (!userRegex.IsMatch(curName))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username must only consist of alphabet and spaces!",
                    Data = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        public static Response<MsUser> validateEmail(String email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return new Response<MsUser>
                {
                    Success = false,
                    Message = "Email cannot be empty!",
                    Data = null
                };
            }

            if (!email.EndsWith(".com"))
            {
                return new Response<MsUser>
                {
                    Success = false,
                    Message = "Email must be valid (ends with .com)",
                    Data = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        public static Response<MsUser> validateGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Gender cannot be empty!",
                    Data = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        public static Response<MsUser> validatePassword(String password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password cannot be empty!",
                    Data = null
                };
            }

            Regex passRegex = new Regex(@"^[A-Z0-9a-z ]+$"); ;
            if (!passRegex.IsMatch(password))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password must be alphanumeric!",
                    Data = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        public static Response<MsUser> validateConfirmationPassword(String password, String confirmationPassword)
        {
            if (password != confirmationPassword)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Confirmation password must be same as password!",
                    Data = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        public static Response<DateTime> validateDOB(String dob)
        {
            if (String.IsNullOrEmpty(dob))
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Date of Birth cannot be empty!",
                    Data = DateTime.MinValue
                };
            }

            if (DateTime.TryParse(dob, out DateTime userDOB))
            {
                return new Response<DateTime>()
                {
                    Success = true,
                    Message = "",
                    Data = userDOB
                };
            }

            return new Response<DateTime>()
            {
                Success = false,
                Message = "Invalid Date of Birth format!",
                Data = DateTime.MinValue
            };

        }
    }
}