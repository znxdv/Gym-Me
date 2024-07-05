using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class CartFactory
    {
        public static Response<MsCart> CreateCart(string supplementID, int quantity, int userID)
        {

            int supplementIDInt = Convert.ToInt32(supplementID);
            MsCart cart = new MsCart()
            {
                UserID = userID,
                SupplementID = supplementIDInt,
                Quantity = quantity,
            };

            CartRepository.InsertCart(cart);

            return new Response<MsCart>()
            {
                Success = true,
                Message = "Cart inserted!",
                Data = cart
            };

        }

    }
}