using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.DAL
{
    public class Work
    {
        public string WorkId { get; set; }
        public string Position { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public string Benefit { get; set; }

        //one-to-many
        public ICollection<User> User { get; set; }
    }
}
