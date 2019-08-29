using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripManagement.API.Exceptions
{
    public class TripManagementDomainException : Exception
    {
        public TripManagementDomainException()
        { }

        public TripManagementDomainException(string message)
            : base(message)
        { }

        public TripManagementDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
