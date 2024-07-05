using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class TransactionHeaderFactory
    {
        public static Response<TransactionHeader> CreateHeader(int userID)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                Status = "UNHANDLED",
                TransactionDate = DateTime.Now,
                UserID = Convert.ToInt32(userID),
            };

            TransactionHeaderRepository.AddTransactionHeader(transactionHeader);

            return new Response<TransactionHeader>()
            {
                Success = true,
                Message = "TransactionDetail created!",
                Data = transactionHeader,
            };
        }
    }
}