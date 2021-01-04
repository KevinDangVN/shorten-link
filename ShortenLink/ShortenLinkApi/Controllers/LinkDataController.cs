using Entities.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortenLinkApi.Controllers
{
    [ApiController]

    public class LinkDataController : ControllerBase
    {
        private readonly IShortenLinkRepository _shortenLinkRepository;

        public LinkDataController(IShortenLinkRepository shortenLinkRepository)
        {
            _shortenLinkRepository = shortenLinkRepository ?? throw new ArgumentNullException(nameof(shortenLinkRepository));
        }

        [HttpGet("api/alllinks")]
        public IActionResult GetAllLink()
        {
            var linkFromRepo = _shortenLinkRepository.GetAllLink();
            return new JsonResult(linkFromRepo);
        }
    }
}
