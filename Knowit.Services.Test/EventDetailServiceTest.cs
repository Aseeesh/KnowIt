using Knowit.Domain.DTO;
using Knowit.Domain.Entities;
using Knowit.Services.Services.EventDetailServices;
using Knowit.Services.Test.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Knowit.Services.Test
{
  


   public class EventDetailServiceTest : EventDetailFake
    {
        private IEventDetailService _service;
        private Mock<IEventDetailService> _serviceMock;

        [Fact]
        public async Task Should_be_possible_to_create_new_eventDetail()
        {
            _serviceMock = new Mock<IEventDetailService>();
            _serviceMock.Setup(m => m.PostAsync(eventDetailDto)).ReturnsAsync(eventDetailDto);
            _service = _serviceMock.Object;

            var result = await _service.PostAsync(eventDetailDto);

            Assert.NotNull(result);
            Assert.Equal(eventDetailDto.Description, result.Description);
            Assert.Equal(eventDetailDto.Title, result.Title);
        }

        [Fact]
        public async Task Should_be_return_list_of_events()
        {
            _serviceMock = new Mock<IEventDetailService>();
            _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(eventDetailList);
            _service = _serviceMock.Object;

            var eventDetailsList = await _service.GetAllAsync();

            Assert.NotNull(eventDetailsList);
            Assert.NotEmpty(eventDetailsList);
        }
         
    }
}
