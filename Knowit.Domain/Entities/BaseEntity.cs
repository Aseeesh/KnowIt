using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        private DateTime? _createdAt;

        public DateTime? CreatedAt
        {
            get => _createdAt;
            set => _createdAt = (value == null ? DateTime.UtcNow : value);
        }

        public DateTime? UpdatedAt { get; set; }
    }
}
