using AuthenticationCarUser.Models;
using AuthenticationCarUser.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationCarUser.Repository
{
    public class CarsRepository : AbstractRepository<CarEntity>, ICarsRepository
    {
    }
}