using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Models
{
    public class Table:BaseEntitiy
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
    }
}
