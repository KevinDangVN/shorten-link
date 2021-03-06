﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class LinkCreatingDTO
    {
        [Required]
        [MinLength(1)]
        public string FullLink { get; set; }

        [Required]
        [MinLength(1)]
        public string ShortLink { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Count { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
    }
}
