using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class LinkCreatingDTO
    {
        public string FullLink { get; set; }

        public string ShortLink { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Count { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
