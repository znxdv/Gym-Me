using Final_Project.Factory;
using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Repository
{
    public class TransactionHeaderRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.getInstance();
        public static void AddTransactionHeader(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();

            return;
        }

        public static void deleteTransactionHeader(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Remove(transactionHeader);
            db.SaveChanges();

            return;
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return (from x in db.TransactionHeaders select x).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionByID(int userID)
        {
            return (from x in db.TransactionHeaders where x.UserID == userID select x).ToList();
        }

        public static TransactionHeader GetTransactionByID(int transactionID)
        {
            return db.TransactionHeaders
                 .Include("MsUser")
                 .FirstOrDefault(x => x.TransactionID == transactionID);
        }

        public static void Handle(int tID)
        {
            TransactionHeader th = (from x in db.TransactionHeaders where x.TransactionID == tID select x).FirstOrDefault();
            th.Status = "HANDLED";
            db.SaveChanges();
        }
    }
}