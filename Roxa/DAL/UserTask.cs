using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.DAL
{
    //tabela zlaczeniowa do many-to-many
    public class UserTask
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long TaskId { get; set; }
        public Task Task { get; set; }
    }
}
