using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.BLL
{
    public class UserTaskBll
    {
        public long UserId { get; set; }
        public UserBll User { get; set; }

        public long TaskId { get; set; }
        public Task Task { get; set; }
    }
}
