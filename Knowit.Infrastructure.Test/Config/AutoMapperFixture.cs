using AutoMapper;
using Knowit.Domain.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Infrastructure.Test.Config
{
    public class AutoMapperFixture : IDisposable
    {
        public IMapper Mapper { get; set; }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DtoToModelProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
        }
    }

}
