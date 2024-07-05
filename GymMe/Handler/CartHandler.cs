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
    public class CartHandler
    {
        public static Response<int> checkQuantity(string quantity)
        {
            Response<int> Quantity = CartController.validateQuantity(quantity);
            return Quantity;
        }
        public static Response<MsCart> AddToCart(int userID, string supplementID, int quantity)
        {
            return CartFactory.CreateCart(supplementID, quantity, userID);
        }

        public static List<MsCart> GetUserCart(int userID)
        {
            return CartRepository.GetCartByUserID(userID);
        }

        public static void deleteUserCart(int userID)
        {
            CartRepository.DeleteCart(userID);
        }
    }
}