using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.API.Exceptions
{
    public class VehicleManagementDomainException:Exception
    {
        public VehicleManagementDomainException()
        { }

        public VehicleManagementDomainException(string message)
            : base(message)
        { }

        public VehicleManagementDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
