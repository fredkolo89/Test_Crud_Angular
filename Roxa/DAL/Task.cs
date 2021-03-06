﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.DAL
{
    public class Task
    {
        public long TaskId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        //many-to-many
        public ICollection<UserTask> UserTask { get; set; }
    }
}
