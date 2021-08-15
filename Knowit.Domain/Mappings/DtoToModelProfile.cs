using AutoMapper;
using Knowit.Domain.DTO;
using Knowit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Domain.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<EventDetail, EventDetailDto>().ReverseMap();
            CreateMap<EventDetailDto, EventDetail>().ReverseMap();
            CreateMap<EventDetailDto, EventDetail>().ForMember(x => x.CreatedAt,
  opt => opt.MapFrom(src => Convert.ToDateTime(src.EventDate)));
        }
    }
}
