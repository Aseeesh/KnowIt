﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Domain.DTO
{
    public class EventCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfSeats { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
