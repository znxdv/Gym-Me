using Final_Project.Factory;
using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Repository
{
    public class TransactionDetailRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.getInstance();
        public static void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();

            return;
        }

        public static TransactionDetail GetTransactionByID(int transactionID)
        {
            return db.TransactionDetails
                 .Include("MsSupplement")
                 .FirstOrDefault(x => x.TransactionID == transactionID);
        }
        public static void deleteTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Remove(transactionDetail);
            db.SaveChanges();

            return;
        }
    }
}