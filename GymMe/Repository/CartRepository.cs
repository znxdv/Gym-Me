using Final_Project.Factory;
using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Repository
{
    public class CartRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.getInstance();
        public static void InsertCart(MsCart cart)
        {
            db.MsCarts.Add(cart);
            db.SaveChanges();
        }


        public static List<MsCart> GetCartByUserID(int userID)
        {
            return (from x in db.MsCarts where x.UserID == userID select x).ToList();
        }

        public static void DeleteCart(int userID)
        {
            List<MsCart> cart = (from x in db.MsCarts where x.UserID == userID select x).ToList();

            foreach (MsCart deleteCart in cart)
            {
                db.MsCarts.Remove(deleteCart);
            }

            db.SaveChanges();
        }
    }
}