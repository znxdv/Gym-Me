using Final_Project.Controller;
using Final_Project.Factory;
using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Handler
{
    public class UserHandler
    {
        public static Response<MsUser> checkLogin(String username, String password)
        {
            Response<MsUser> checkUsername = UserController.validateUsername(username);
            Response<MsUser> checkPassword = UserController.validatePassword(password);

            if (!checkUsername.Success)
            {
                return checkUsername;
            }

            if (!checkPassword.Success)
            {
                return checkPassword;
            }

            MsUser user = UserRepository.getUser(username, password);
            if (user == null)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Username or password is wrong!",
                    Data = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Successfully logged in!",
                Data = user
            };
        }

        public static Response<MsUser> checkRegister(string username, string email, string gender, string password, string confirmationPassword, string DOB)
        {
            Response<MsUser> checkUsername = UserController.validateUsername(username);
            Response<MsUser> checkEmail = UserController.validateEmail(email);
            Response<MsUser> checkGender = UserController.validateGender(gender);
            Response<DateTime> checkDOB = UserController.validateDOB(DOB);
            Response<MsUser> checkPassword = UserController.validatePassword(password);
            Response<MsUser> checkConfirmationPassword = UserController.validateConfirmationPassword(password, confirmationPassword);

            if (!checkUsername.Success) { return checkUsername; }
            if (!checkEmail.Success) { return checkEmail; }
            if (!checkGender.Success) { return checkGender; }
            if (!checkPassword.Success) { return checkPassword; }
            if (!checkConfirmationPassword.Success) { return checkConfirmationPassword; }

            if (!checkDOB.Success)
            {
                return new Response<MsUser>()
                {
                    Data = null,
                    Success = false,
                    Message = checkDOB.Message
                };
            }

            Response<MsUser> newUser = UserFactory.createUser(username, email, gender, checkDOB.Data, password, "Customer");

            return newUser;
        }

        public static Response<MsUser> checkUpdateProfile(int id, string username, string email, string gender, string dob)
        {
            Response<MsUser> Username = UserController.validateUsername(username);
            Response<MsUser> Email = UserController.validateEmail(email);
            Response<MsUser> Gender = UserController.validateGender(gender);
            Response<DateTime> DOB = UserController.validateDOB(dob);

            if (!Username.Success)
            {
                return Username;
            }

            if (!Email.Success)
            {
                return Email;
            }

            if (!Gender.Success)
            {
                return Gender;
            }

            if (!DOB.Success)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = DOB.Message,
                    Data = null
                };
            }

            UserRepository.updateUserProfile(id, username, email, DOB.Data, gender);

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Profile Updated!",
                Data = null
            };
        }

        public static Response<MsUser> checkUpdatePassword(int id, string currentPassword, string newPassword, string confirmPassword)
        {

            Response<MsUser> password = UserController.validatePassword(currentPassword);
            Response<MsUser> confirmationPassword = UserController.validateConfirmationPassword(newPassword, confirmPassword);

            if (password.Success == false)
            {
                return password;
            }

            if (confirmationPassword.Success == false)
            {
                return confirmationPassword;
            }

            UserRepository.updateUserPassword(id, newPassword);

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Password Updated!",
                Data = null
            };
        }

        public static MsUser userLogin(string username, string password)
        {
            MsUser user = UserRepository.getUser(username, password);

            return user;
        }

        public static List<MsUser> getAllUser()
        {
            return UserRepository.getAllUsers();
        }

        public static MsUser GetUserByID(string id)
        {
            return UserRepository.getUserByID(id);
        }

        public static void DeleteUserByID(string id)
        {
            UserRepository.deleteUserByID(id);
            return;
        }

        public static bool isAdmin(MsUser user)
        {
            if (user.UserRole == "Admin")
            {
                return true;
            }
            return false;
        }

    }
}