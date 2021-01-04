using AutoMapper;
using Entities.DTO;
using Entities.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortenLinkApi.Controllers
{
    [ApiController]
    [Route("api/linkdata")]

    public class LinkDataController : ControllerBase
    {
        private readonly IShortenLinkRepository _shortenLinkRepository;
        private readonly IMapper _mapper;

        public LinkDataController(IShortenLinkRepository shortenLinkRepository, IMapper mapper)
        {
            _shortenLinkRepository = shortenLinkRepository ?? throw new ArgumentNullException(nameof(shortenLinkRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("alllinks")]
        public ActionResult<IEnumerable<LinkDataDTO>> GetAllLink()
        {
            var linkFromRepo = _shortenLinkRepository.GetAllLink();
            var linkResult = new List<LinkDataDTO>();
            //foreach (var link in linkFromRepo)
            //{
            //    linkResult.Add(new LinkDataDTO()
            //    {
            //        FullLink = link.FullLink,
            //        Id = link.Id,
            //        ShortLink = link.ShortLink
            //    });
            //}

            return Ok(_mapper.Map<IEnumerable<LinkDataDTO>>(linkFromRepo));
        }

        [HttpGet("link/short/{link}")]
        public ActionResult<LinkDataDTO> GetLinkByShortLink(string link)
        {
            var linkFromRepo = _shortenLinkRepository.GetLinkByShortLink(link);
            if (linkFromRepo == null)
                return NotFound();
            var linkResult = new LinkDataDTO()
            {
                Id = linkFromRepo.Id,
                ShortLink = linkFromRepo.ShortLink,
                FullLink = linkFromRepo.FullLink
            };
            return Ok(linkResult);
        }

        [HttpGet("link/emp/{empId}")]
        public ActionResult<IEnumerable<LinkDataDTO>> GetLinkByEmpId(Guid empId)
        {
            if (!_shortenLinkRepository.EmpExists(empId))
                return NotFound();

            var linkFromRepo = _shortenLinkRepository.GetAllLinkByEmployeeId(empId);
            return Ok(_mapper.Map<IEnumerable<LinkDataDTO>>(linkFromRepo));
        }
    }
}
