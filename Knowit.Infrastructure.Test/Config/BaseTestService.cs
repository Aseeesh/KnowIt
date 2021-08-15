using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Infrastructure.Test.Config
{
    public abstract class BaseTestService
    {
        public IMapper mapper { get; set; }

        public BaseTestService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }
    }
}
