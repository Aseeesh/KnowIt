using Knowit.Domain.DTO;
using Knowit.Services.Services.EventDetailServices;
using KnowIt.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KnowIt.Web.Test
{
   
    public class EventDetailControllerTest
    {
        private EventDetailController _controller;
        Random random = new Random();

        [Fact]
        public async Task Should_be_possible_to_post_new_event()
        {
            var serviceMock = new Mock<IEventDetailService>();
            var date = DateTime.UtcNow.AddDays(random.Next(10, 50));
            var description = Faker.Lorem.Words(30).ToString();
            var Title = Faker.Lorem.Words(50).ToString();

            serviceMock.Setup(m => m.PostAsync(It.IsAny<EventDetailDto>())).ReturnsAsync(
               new EventDetailDto
               {
                   Id = Faker.RandomNumber.Next(100),
                   EventDate = date.ToString(),
                   Description = description,
                   Title = Title
               }
            );

            _controller = new EventDetailController(serviceMock.Object);

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var EventDetailDto = new EventDetailDto
            {
                EventDate = date.ToString(),
                Description = description,
                Title = Title
            };

            var result = await _controller.Post(EventDetailDto);

            Assert.True(result is ObjectResult);

            var resultObject = ((ObjectResult)result).Value as EventDetailDto;

            Assert.NotNull(resultObject);
            Assert.Equal(EventDetailDto.EventDate, resultObject.EventDate);
            Assert.Equal(EventDetailDto.Description, resultObject.Description);
            Assert.Equal(EventDetailDto.Title, resultObject.Title);
        }

        [Fact]
        public async Task Should_be_possible_to_update_EventDetail()
        {
            var serviceMock = new Mock<IEventDetailService>();
            var date = DateTime.UtcNow.AddDays(random.Next(10, 50));
            var description = Faker.Lorem.Words(30).ToString();
            var Title = Faker.Lorem.Words(50).ToString();

            serviceMock.Setup(m => m.PutAsync(It.IsAny<EventDetailDto>())).ReturnsAsync(
               new EventDetailDto
               {
                   Id = Faker.RandomNumber.Next(100),
                   EventDate = date.ToString(),
                   Description = description,
                   Title = Title
               }
            );

            _controller = new EventDetailController(serviceMock.Object);

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var EventDetailDto = new EventDetailDto
            {
                Id = Faker.RandomNumber.Next(100),
                EventDate = date.ToString(),
                Description = description,
                Title = Title
            };

            var result = await _controller.Update(EventDetailDto.Id, EventDetailDto);
            Assert.True(result is ObjectResult);
        }

        [Fact]
        public async Task Should_not_possible_to_update_unexistent_EventDetail()
        {
            var serviceMock = new Mock<IEventDetailService>();
            var id = Faker.RandomNumber.Next(100);
            var date = DateTime.UtcNow.AddDays(random.Next(10, 50));
            var description = Faker.Lorem.Words(30).ToString();
            var Title = Faker.Lorem.Words(50).ToString();

            serviceMock.Setup(m => m.PutAsync(It.IsAny<EventDetailDto>())).ReturnsAsync(
               new EventDetailDto
               {
                   Id = id,
                   EventDate = date.ToString(),
                   Description = description,
                   Title = Title
               }
            );

            _controller = new EventDetailController(serviceMock.Object);
            _controller.ModelState.AddModelError("id", "EventDetail with not found");

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var EventDetailDto = new EventDetailDto
            {
                Id = id,
                EventDate = date.ToString(),
                Description = description,
                Title = Title
            };

            ActionResult result = await _controller.Update(Faker.RandomNumber.Next(30000, 50000), EventDetailDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(badRequestResult.Value);
        }

        [Fact]
        public async Task Should_not_possible_to_delete_unexistent_EventDetail()
        {
            var serviceMock = new Mock<IEventDetailService>();
            var id = Faker.RandomNumber.Next(100, 300);
            serviceMock.Setup(m => m.DeleteAsync(id)).ReturnsAsync(true);

            _controller = new EventDetailController(serviceMock.Object);

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var result = await _controller.Delete(id);

            Assert.True(result is ObjectResult);

            var resultValue = ((ObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True(resultValue is string);
            Assert.Equal($"EventDetail with id {id} not found", resultValue.ToString());
        }
         
    }
}
