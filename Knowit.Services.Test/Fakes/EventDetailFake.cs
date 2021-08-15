using Knowit.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Services.Test.Fakes
{
    public class EventDetailFake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventCategoryId { get; set; }
        public int CreatedBy { get; set; }
        public string EventDate { get; set; }
        public string CreatedAt { get; set; }
        public List<EventDetailDto> eventDetailList { get; set; } = new List<EventDetailDto>();
        public EventDetailDto eventDetailDto { get; set; } = new EventDetailDto();
        public EventDetailFake()
        {
            InitFakeDataObjects();
        }
        protected void InitFakeDataObjects()
        {
            Id = Faker.RandomNumber.Next(100);
            EventDate = Faker.Identification.DateOfBirth().ToString();
            Description = Faker.Lorem.Words(30).ToString();
            Title = Faker.Lorem.Words(50).ToString();
            Description = Faker.Lorem.Words(50).ToString();
        }
    }
}
