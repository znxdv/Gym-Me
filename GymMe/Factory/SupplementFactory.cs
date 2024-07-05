using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class SupplementFactory
    {
        public static Response<MsSupplement> CreateSupplement(string name, DateTime expiryDate, string price, string typeID)
        {
            int priceInt = Convert.ToInt32(price);
            int typeIDInt = Convert.ToInt32(typeID);
            MsSupplement supplement = new MsSupplement()
            {
                SupplementName = name,
                SupplementPrice = priceInt,
                SupplementExpiryDate = expiryDate,
                SupplementTypeID = typeIDInt,
            };

            SupplementRepository.insertSupplement(supplement);

            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Supplement inserted!",
                Data = supplement
            };
        }
    }
}