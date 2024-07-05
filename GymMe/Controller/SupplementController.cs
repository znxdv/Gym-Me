using Final_Project.Model;
using Final_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Controller
{
    public class SupplementController
    {
        public static Response<MsSupplement> validateSupplementName(string supplementName)
        {
            if (string.IsNullOrEmpty(supplementName))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement name cannot be empty!",
                    Data = null
                };
            }
            if (!supplementName.Contains("Supplement"))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement name must contain 'Supplement'!",
                    Data = null
                };
            }
            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        public static Response<DateTime> validateExpiryDate(string expiryDate)
        {
            if (expiryDate == null)
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Expiry date must not be empty!",
                    Data = DateTime.MinValue
                };
            }

            if (DateTime.TryParse(expiryDate, out DateTime parsedExpiryDate))
            {
                if (parsedExpiryDate <= DateTime.Now)
                {
                    return new Response<DateTime>()
                    {
                        Success = false,
                        Message = "Expiry Date must be greater than today's date.",
                        Data = DateTime.MinValue
                    };
                }

                return new Response<DateTime>()
                {
                    Success = true,
                    Message = "",
                    Data = parsedExpiryDate
                };
            }

            else
            {
                return new Response<DateTime>()
                {
                    Success = false,
                    Message = "Expiry date is invalid!",
                    Data = DateTime.MinValue
                };
            }
        }

        public static Response<MsSupplement> validateSupplementPrice(string price)
        {
            if (string.IsNullOrEmpty(price))
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Price cannot be empty!",
                    Data = null
                };
            }

            if (!int.TryParse(price, out int priceInt))
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Numbers only!",
                    Data = null
                };
            }

            if (priceInt < 3000)
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Price must be at least 3000!",
                    Data = null
                };
            }

            return new Response<MsSupplement>
            {
                Success = true,
                Message = "",
                Data = null
            };
        }

        public static Response<MsSupplement> validateSupplementTypeID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Type ID cannot be empty!",
                    Data = null
                };
            }

            if (!int.TryParse(id, out int typeIDInt))
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Numbers only!",
                    Data = null
                };
            }

            return new Response<MsSupplement>
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
    }
}