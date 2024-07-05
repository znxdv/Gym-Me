using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class TransactionDetailFactory
    {
        public static Response<TransactionDetail> CreateDetail(int supplementID, int quantity, int transactionID)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                SupplementID = supplementID,
                Quantity = quantity,
                TransactionID = transactionID
            };

            TransactionDetailRepository.AddTransactionDetail(transactionDetail);

            return new Response<TransactionDetail>()
            {
                Success = true,
                Message = "TransactionDetail created!",
                Data = transactionDetail,
            };
        }
    }
}