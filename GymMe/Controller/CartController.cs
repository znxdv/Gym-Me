using Final_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Controller
{
    public class CartController
    {
        public static Response<int> validateQuantity(string quantity)
        {
            if (string.IsNullOrEmpty(quantity))
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Quantity cannot be empty!",
                    Data = 0
                };
            }

            if (!int.TryParse(quantity, out int quantityInt))
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Numbers only!",
                    Data = 0
                };
            }

            if (quantityInt <= 0)
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Selected quantity must be more than 0!",
                    Data = 0
                };
            }

            return new Response<int>
            {
                Success = true,
                Message = "Valid quantity.",
                Data = quantityInt
            };
        }

    }
}