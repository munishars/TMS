using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.API.Exceptions
{
    public class UserManagementDomainException : Exception
    {
        public UserManagementDomainException()
        { }

        public UserManagementDomainException(string message)
            : base(message)
        { }

        public UserManagementDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
