using Final_Project.Factory;
using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Repository
{
    public class SupplementRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.getInstance();

        public static List<MsSupplement> getAllSupplements()
        {
            return (from x in db.MsSupplements select x).ToList();
        }

        public static MsSupplement getSupplementID(string id)
        {
            int supplementId = Convert.ToInt32(id);
            return (from x in db.MsSupplements where x.SupplementID == supplementId select x).FirstOrDefault();
        }

        public static void insertSupplement(MsSupplement supplement)
        {
            db.MsSupplements.Add(supplement);
            db.SaveChanges();
        }

        public static void deleteSupplementByID(string id)
        {
            MsSupplement supplement = getSupplementID(id);
            db.MsSupplements.Remove(supplement);
            db.SaveChanges();

        }

        public static void updateSupplement(string id, string name, DateTime expiryDate, string price, string typeId)
        {
            int priceInt = Convert.ToInt32(price);
            int typeIdInt = Convert.ToInt32(typeId);

            MsSupplement supplement = getSupplementID(id);

            supplement.SupplementPrice = priceInt;
            supplement.SupplementExpiryDate = expiryDate;
            supplement.SupplementName = name;
            supplement.SupplementTypeID = typeIdInt;

            db.SaveChanges();
        }
    }
}