using AutoMapper;
using Entities.DTO;
using Entities.Model;
using Entities.Service;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

            var claims = HttpContext.User.Claims;

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
            var existLink = _shortenLinkRepository.GetLinkByShortLink(link.ShortLink);

            if (existLink != null)
            {
                return BadRequest("Slug exists!");
            }
            var linkEntity = _mapper.Map<LinkDataModel>(link);
            linkEntity.Count = 0;

            _shortenLinkRepository.AddLink(empId, linkEntity);
            _shortenLinkRepository.Save();

            var linkToResponse = _mapper.Map<LinkDataDTO>(linkEntity);
            return CreatedAtRoute("GetLinkByEmpIdLinkId", new { empId, linkId = linkToResponse.Id }, linkToResponse);
        }

        [HttpPatch("link/emp/{empId}/{linkId}")]
        public ActionResult UpdateLinkByEmpIdLinkId(Guid empId, Guid linkId, [FromBody] LinkUpdateDTO link)
        {
            if (!_employeeRepository.EmpExists(empId))
                return NotFound();

            var linkFromRepo = _shortenLinkRepository.GetLinkByEmpIdLinkId(empId, linkId);

            var existLink = _shortenLinkRepository.GetLinkByShortLink(link.ShortLink);

            if (existLink != null)
            {
                return BadRequest("Slug exists!");
            }

            if (linkFromRepo == null)
                return NotFound();

            if (linkFromRepo.EmployeeId != empId)
                return NotFound();

            _mapper.Map(link, linkFromRepo);
            _shortenLinkRepository.UpdateLink(linkFromRepo);
            _shortenLinkRepository.Save();

            return NoContent();
        }

        [HttpPatch("view/{shortLink}")]
        public ActionResult IncreaseView(string shortLink)
        {
            var linkFromRepo = _shortenLinkRepository.GetLinkByShortLink(shortLink);
            if (linkFromRepo == null)
                return NotFound();
            var link = new LinkForViewUpdate()
            {
                Count = linkFromRepo.Count + 1
            };

            _mapper.Map(link, linkFromRepo);
            _shortenLinkRepository.UpdateLink(linkFromRepo);
            _shortenLinkRepository.Save();
            return NoContent();
        }

        [HttpDelete("link/emp/{empId}/{linkId}")]
        public ActionResult DeleteLinkWithEmpIdLinkId(Guid empId, Guid linkId)
        {
            if (!_employeeRepository.EmpExists(empId))
                return NotFound();

            var linkFromRepo = _shortenLinkRepository.GetLinkByEmpIdLinkId(empId, linkId);
            if (linkFromRepo == null)
                return NotFound();

            _shortenLinkRepository.DeleteLink(linkFromRepo);
            _shortenLinkRepository.Save();

            return NoContent();
        }        
    }
}
