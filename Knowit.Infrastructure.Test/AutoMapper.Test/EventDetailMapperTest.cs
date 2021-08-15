using Knowit.Domain.DTO;
using Knowit.Domain.Entities;
using Knowit.Infrastructure.Test.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Knowit.Infrastructure.Test.AutoMapper.Test
{ 
      public class EventDetailMapperTest : BaseTestService
    {
        [Fact]
        public void Should_be_possible_to_mapper_eventDetailDTO_to_eventDetail_Entity()
        {
            var eventDetailDto = new EventDetailDto
            {
                Id = Faker.RandomNumber.Next(100),
                Title = Faker.Lorem.Words(50).ToString(),
                Description = Faker.Lorem.Words(30).ToString(),
                EventDate = DateTime.UtcNow.AddDays(Faker.RandomNumber.Next(10)).ToString()
            };

            var dtoToEntity = mapper.Map<EventDetail>(eventDetailDto);

            Assert.Equal(eventDetailDto.Id, dtoToEntity.Id);
            Assert.Equal(eventDetailDto.EventDate, dtoToEntity.EventDate.ToString());
            Assert.Equal(eventDetailDto.Description, dtoToEntity.Description);
            Assert.Equal(eventDetailDto.Title, dtoToEntity.Title);
        }
         
    }

}
