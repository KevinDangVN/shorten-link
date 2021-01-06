using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class LinkCreatingDTO
    {
        [Required]
        public string FullLink { get; set; }

        [Required]
        public string ShortLink { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Count { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
    }
}
