using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationCarUser.Models.Interfaces
{
   public  interface IBasicEntity
    {
        int Id { get; set; }
        DateTime DateCreate { get; set; }
        DateTime DateMod { get; set; }
        bool IsActive { get; set; }
        
    }
}
