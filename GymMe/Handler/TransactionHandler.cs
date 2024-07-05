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
    public class TransactionHandler
    {
        public static Response<string> CreateTransaction(int userID, List<MsCart> cart)
        {
            foreach (MsCart cartItem in cart)
            {
                Response<TransactionHeader> transactionHeader = TransactionHeaderFactory.CreateHeader(userID);
                TransactionDetailFactory.CreateDetail(cartItem.SupplementID, cartItem.Quantity, transactionHeader.Data.TransactionID);
            }

            return new Response<string>
            {
                Success = true,
                Message = "Ordered successfully!",
                Data = null,
            };
        }

        public static void changeHandleStatus(string transactionID)
        {
            TransactionHeaderRepository.Handle(Convert.ToInt16(transactionID));
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionHeaderRepository.GetAllTransactions();
        }

        public static List<TransactionHeader> GetAllTransactionHeaderByID(int userID)
        {
            return TransactionHeaderRepository.GetAllTransactionByID(userID);
        }

        public static TransactionHeader GetTransactionHeaderByID(string transactionID)
        {
            return TransactionHeaderRepository.GetTransactionByID(Convert.ToInt16(transactionID));
        }

        public static TransactionDetail GetTransactionDetailByID(string transactionID)
        {
            return TransactionDetailRepository.GetTransactionByID(Convert.ToInt16(transactionID));
        }
    
    }
}