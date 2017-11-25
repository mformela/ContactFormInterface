using AuthenticationCarUser.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationCarUser.BusinessLogic
{
    public class CarBusinessLogic : ICarBusinessLogic
    {
        public string CheckIfUserIsAuthAndReturnName() // tutaj napisaliśmy metodę, która ma sprawdzić czy ktoś jest zalogowany czy też nie
        {
            string name = "Niezalogowany";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                name = HttpContext.Current.User.Identity.Name;
            return name;
        }
    }
}