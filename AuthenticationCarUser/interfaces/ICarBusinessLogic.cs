using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationCarUser.interfaces
{
    public interface ICarBusinessLogic
    {
        string CheckIfUserIsAuthAndReturnName();
    }
}