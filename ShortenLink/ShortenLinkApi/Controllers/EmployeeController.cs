using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortenLinkApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IShortenLinkRepository _shortenLinkRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IShortenLinkRepository shortenLinkRepository, IMapper mapper)
        {
            _shortenLinkRepository = shortenLinkRepository ?? throw new ArgumentNullException(nameof(shortenLinkRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
