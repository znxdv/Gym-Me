using Final_Project.Factory;
using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Repository
{
    public class SupplementTypeRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.getInstance();

        public static void insertSupplementType(MsSupplementType supplementType)
        {
            db.MsSupplementTypes.Add(supplementType);
            db.SaveChanges();

        }

        public static List<MsSupplementType> GetAllSupplementType()
        {
            return (from x in db.MsSupplementTypes select x).ToList();
        }

        public static MsSupplementType getSupplementTypeID(string id)
        {
            int findId = Convert.ToInt32(id);
            return (from x in db.MsSupplementTypes where x.SupplementTypeID == findId select x).FirstOrDefault();
        }
    }
}