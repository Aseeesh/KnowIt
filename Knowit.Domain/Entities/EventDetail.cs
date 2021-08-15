
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Knowit.Domain.Entities
{
    public class EventDetail : BaseEntity
    {
        public string? Name { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? EventCategoryId { get; set; } 
        public DateTime? EventDate { get; set; }
         
        private EventDetail()
        {
        }

        public EventDetail(DateTime? eventDate, string description, string title)
        {
            Validations(eventDate, description);

            EventDate = eventDate;
            Description = description;
            Title = title;
        }
        private void Validations(DateTime? eventDate, string description)
        {
            //if (eventDate < DateTime.Now)
            //    throw new ArgumentException("Date not valid!");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Description is required!");

            if (description.Length <= 2)
                throw new ArgumentException("The description length must contain more than two characters!");
        }
    }
}
