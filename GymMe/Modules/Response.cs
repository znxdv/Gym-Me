using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Modules
{
    public class Response<T>
    {
        public Boolean Success;
        public string Message;
        public T Data;
    }
}