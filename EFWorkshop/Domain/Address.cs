using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWorkshop.Domain
{
    public class Address
    {
        public string City { get; set; }

        public string State { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
