using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class SupplementTypeFactory
    {
        public static Response<MsSupplementType> createSupplementType()
        {
            MsSupplementType supplementType = new MsSupplementType()
            {
                SupplementTypeName = "Suple"
            };

            SupplementTypeRepository.insertSupplementType(supplementType);

            return new Response<MsSupplementType>()
            {
                Success = true, 
                Message = "Supplement type inserted!",
                Data = supplementType
            };
        }

    }
}