using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace CommonWeb.Security
{
    [Serializable]
    public class smInvalidLoginException : Exception
    {
        public smInvalidLoginException() : base(CommonWeb.Resources.CommonResource.err_LoginNotFound) { }
    }

    [Serializable]
    public class smInvalidPasswordException : Exception
    {
        public smInvalidPasswordException() : base(CommonWeb.Resources.CommonResource.valerr_Password) { }
    }

    [Serializable]
    public class smLoginInactiveException : Exception
    {
        public smLoginInactiveException() : base(CommonWeb.Resources.CommonResource.err_NotActiveUser) { }
    }

}