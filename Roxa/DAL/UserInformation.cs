using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.DAL
{
    public class UserInformation
    {
        //one-to-one
        [ForeignKey("User")]
        public long UserInformationId { get; set; }

        public string Adress { get; set; }
        public string PlaceOfBirth { get; set; }

        //one-to-one
        public virtual User User { get; set; }
    }
}
