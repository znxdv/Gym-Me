using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Factory
{
    public class SingletonDatabase
    {
        private static DatabaseEntities1 instance;

        public static DatabaseEntities1 getInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseEntities1();
            }
            return instance;
        }
    }
}