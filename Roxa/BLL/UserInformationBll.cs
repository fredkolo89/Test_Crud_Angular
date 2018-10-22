using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.BLL
{
    public class UserInformationBll
    {
        public long UserInformationId { get; set; }

        public string Adress { get; set; }
        public string PlaceOfBirth { get; set; }

        public UserBll User { get; set; }
    }
}
