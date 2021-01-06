using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class LinkUpdateDTO
    {
        [Required]
        [MinLength(1)]
        public string FullLink { get; set; }

        [Required]
        [MinLength(1)]
        public string ShortLink { get; set; }
    }
}
