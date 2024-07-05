using Final_Project.Controller;
using Final_Project.Factory;
using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Final_Project.Handler
{
    public class SupplementHandler
    {
        public static bool checkSupplementTypeID(string id)
        {
            MsSupplementType supplementType = SupplementTypeRepository.getSupplementTypeID(id);

            if (supplementType == null)
            {
                return false;
            }
            return true;
        }

        public static Response<MsSupplement> validateInsertSupplement(string supplementName, string expiryDate, string price, string typeID)
        {
            Response<MsSupplement> SupplementName = SupplementController.validateSupplementName(supplementName);
            Response<DateTime> ExpiryDate = SupplementController.validateExpiryDate(expiryDate);
            Response<MsSupplement> Price = SupplementController.validateSupplementPrice(price);
            Response<MsSupplement> TypeID = SupplementController.validateSupplementTypeID(typeID);


            if (!SupplementName.Success)
            {
                return SupplementName;
            }

            if (!ExpiryDate.Success)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = ExpiryDate.Message,
                    Data = null
                };
            }

            if (!Price.Success)
            {
                return Price;
            }

            if (!TypeID.Success)
            {
                return TypeID;
            }

            if (!checkSupplementTypeID(typeID))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement type ID does not exist!",
                    Data = null
                };
            }

            Response<MsSupplement> newSupplement = SupplementFactory.CreateSupplement(supplementName, ExpiryDate.Data, price, typeID);

            return newSupplement;
        }

        public static Response<MsSupplement> validateUpdateSupplement(string id, string supplementName, string expiryDate, string price, string typeID)
        {
            Response<MsSupplement> SupplementName = SupplementController.validateSupplementName(supplementName);
            Response<DateTime> ExpiryDate = SupplementController.validateExpiryDate(expiryDate);
            Response<MsSupplement> Price = SupplementController.validateSupplementPrice(price);
            Response<MsSupplement> TypeID = SupplementController.validateSupplementTypeID(typeID);


            if (!SupplementName.Success)
            {
                return SupplementName;
            }

            if (!ExpiryDate.Success)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = ExpiryDate.Message,
                    Data = null
                };
            }

            if (!Price.Success)
            {
                return Price;
            }

            if (!checkSupplementTypeID(typeID))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Supplement type ID does not exist!",
                    Data = null
                };
            }

            if (!TypeID.Success)
            {
                return TypeID;
            }

            SupplementRepository.updateSupplement(id, supplementName, ExpiryDate.Data, price, typeID);

            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Update Success!",
                Data = null
            };
        }

        public static List<MsSupplement> GetAllSupplements()
        {
            return SupplementRepository.getAllSupplements();
        }

        public static MsSupplement GetSupplementByID(string id)
        {
            return SupplementRepository.getSupplementID(id);
        }
        public static List<MsSupplementType> GetAllSupplementType()
        {
            return SupplementTypeRepository.GetAllSupplementType();
        }
        public static MsSupplementType GetSupplementTypeByID(string id)
        {
            return SupplementTypeRepository.getSupplementTypeID(id);
        }

        public static void DeleteSupplementByID(string id)
        {
            SupplementRepository.deleteSupplementByID(id);
            return;
        }

        public static Response<int> CheckQuantity(string quantity)
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

            if (!int.TryParse(quantity, out int parsedQuantity))
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Quantity must be numeric.",
                    Data = 0
                };
            }

            if (parsedQuantity <= 0)
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Quantity must be greater than 0.",
                    Data = 0
                };
            }

            return new Response<int>
            {
                Success = true,
                Message = "Valid quantity.",
                Data = parsedQuantity
            };
        }

    }
}