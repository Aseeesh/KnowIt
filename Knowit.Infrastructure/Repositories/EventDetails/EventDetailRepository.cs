using Knowit.Domain.Entities;
using Knowit.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Infrastructure.Repositories.EventDetails
{
    public class EventDetailRepository : BaseRepository<EventDetail>, IEventDetailRepository
    {
        private readonly DbSet<EventDetail> _dataset;

        public EventDetailRepository(ApplicationDbContext context)
            : base(context)
        {
            _dataset = context.Set<EventDetail>();
        }

    }
}

