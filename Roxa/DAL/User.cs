using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.DAL
{
    public class User : IdentityUser<long>
    {
        //one-to-one
        public virtual UserInformation UserInformation { get; set; }
        //one-to-many
        public Work Work { get; set; }
        ////mant-to-many
        public ICollection<UserTask> UserTask { get; set; }
    }
}
