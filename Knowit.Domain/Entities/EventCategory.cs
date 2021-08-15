using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Domain.Entities
{
    public class EventCategory: BaseEntity
    { 
        public string Name { get; set; }
        public int NoOfSeats { get; set; }
        public string Description { get; set; } 
    }
}
