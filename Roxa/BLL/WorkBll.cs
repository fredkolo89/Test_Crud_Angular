using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.BLL
{
    public class WorkBll
    {
        public long WorkId { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Benefit { get; set; }

        //one-to-many
        public ICollection<UserBll> User { get; set; }
    }
}
