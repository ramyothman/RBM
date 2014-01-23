using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CommonWeb.EmailManagement
{
    [Serializable]
    public class emException : Exception
    {
        public emException() : base("Email") { }
    }

}