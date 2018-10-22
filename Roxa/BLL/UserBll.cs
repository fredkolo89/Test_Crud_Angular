using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.BLL
{
    public class UserBll
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public UserInformationBll UserInformation { get; set; }
        //one-to-many
        public WorkBll Work { get; set; }
        ////mant-to-many
        public ICollection<UserTaskBll> UserTask { get; set; }
    }
}
