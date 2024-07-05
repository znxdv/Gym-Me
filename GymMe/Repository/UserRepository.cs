using Final_Project.Factory;
using Final_Project.Model;
using Final_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Repository
{
    public class UserRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.getInstance();
        public static void insertUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
            return;
        }
        public static List<MsUser> getAllUsers()
        {
            return (from x in db.MsUsers select x).ToList();
        }
        public static MsUser getUser(string username, string password)
        {
            MsUser user = (from x in db.MsUsers where x.UserName == username && x.UserPassword == password select x).FirstOrDefault();
            return user;
        }
        public static MsUser getUserByID(string id)
        {
            int userId = Convert.ToInt32(id);
            MsUser user = (from x in db.MsUsers where x.UserID == userId select x).FirstOrDefault();
            return user;
        }

        public static void deleteUserTransactions(int userId)
        {
            CartRepository.DeleteCart(userId);

            var transactionHeaders = db.TransactionHeaders.Where(th => th.UserID == userId).ToList();

            foreach (var header in transactionHeaders)
            {
                var transactionDetails = db.TransactionDetails.Where(td => td.TransactionID == header.TransactionID).ToList();

                foreach (var detail in transactionDetails)
                {
                    TransactionDetailRepository.deleteTransactionDetail(detail);
                }

                TransactionHeaderRepository.deleteTransactionHeader(header);
            }
        }
        public static void deleteUserByID(string userId)
        {
            int userIDInt = Convert.ToInt32(userId);

            UserRepository.deleteUserTransactions(userIDInt);

            MsUser user = db.MsUsers.FirstOrDefault(x => x.UserID == userIDInt);
            if (user != null)
            {
                db.MsUsers.Remove(user);
                db.SaveChanges();
            }
        }

        public static void updateUserProfile(int id, string username, string email, DateTime dob, string gender)
        {
            MsUser user = (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
            user.UserName = username;
            user.UserGender = gender;
            user.UserEmail = email;
            user.UserDOB = dob;

            db.SaveChanges();
        }
        public static void updateUserPassword(int id, string password)
        {
            MsUser user = (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
            user.UserPassword = password;
            db.SaveChanges();
        }
    }
}