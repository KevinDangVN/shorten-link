using AutoMapper;
using Entities.DTO;
using Entities.Model;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public LinkDataController(IShortenLinkRepository shortenLinkRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _shortenLinkRepository = shortenLinkRepository ?? throw new ArgumentNullException(nameof(shortenLinkRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
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

        [HttpGet("link/emp/{empId}", Name = "GetAllLinkByEmpId")]
        public ActionResult<IEnumerable<LinkDataDTO>> GetAllLinkByEmpId(Guid empId)
        {
            if (!_shortenLinkRepository.EmpWithLinkExists(empId))
                return NotFound();

            var linkFromRepo = _shortenLinkRepository.GetAllLinkByEmployeeId(empId);

            return Ok(_mapper.Map<IEnumerable<LinkDataDTO>>(linkFromRepo));
        }

        [HttpGet("link/emp/{empId}/{linkId}", Name = "GetLinkByEmpIdLinkId")]
        public IActionResult GetLinkByEmpIdLinkId(Guid empId, Guid linkId)
        {
            if (!_employeeRepository.EmpExists(empId))
                return NotFound();
            if (!_shortenLinkRepository.LinkExists(linkId))
            {
                return NotFound();
            }

            var linkFromRepo = _shortenLinkRepository.GetLinkByEmpIdLinkId(empId, linkId);

            return Ok(_mapper.Map<LinkDataDTO>(linkFromRepo));
        }

        [HttpPost("link/emp/{empId}")]
        public ActionResult<LinkDataDTO> CreateLinkWithEmp(Guid empId, [FromBody] LinkCreatingDTO link)
        {
            if (!_employeeRepository.EmpExists(empId))
                return NotFound();
            var linkEntity = _mapper.Map<LinkDataModel>(link);
            linkEntity.Count = 0;

            _shortenLinkRepository.AddLink(empId, linkEntity);
            _shortenLinkRepository.Save();

            var linkToResponse = _mapper.Map<LinkDataDTO>(linkEntity);
            return CreatedAtRoute("GetLinkByEmpIdLinkId", new { empId, linkId = linkToResponse.Id }, linkToResponse);
        }

    }
}
