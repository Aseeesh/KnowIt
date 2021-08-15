using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Domain.DTO
{
    public class EventDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public int CreatedBy { get; set; }
        public string EventDate { get; set; }
        public string CreatedAt { get; set; }
    }
}
