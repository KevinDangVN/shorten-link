using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class LinkDataDTO
    {
        public Guid Id { get; set; }
        public string FullLink { get; set; }
        public string ShortLink { get; set; }
        public int Count { get; set; }
    }
}
