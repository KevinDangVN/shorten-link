using AutoMapper;
using Entities.DTO;
using Entities.Model;
using Entities.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShortenLinkApi.AuthService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortenLinkApi.Controllers
{
    [ApiController]
    [Route("api/employee")]
    

    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private IConfiguration _config;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, IConfiguration config)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _config = config;
        }

        [Authorize]
        [HttpGet("getrole")]
        public IActionResult GetRoleId()
        {
            var claims = HttpContext.User.Claims;
            var test = claims.Where(c => c.Type == "Role").FirstOrDefault().Value;

            if (test == "Admin")
            {
                var roleFromRepo = _employeeRepository.GetRoleId();
                return Ok(_mapper.Map<IEnumerable<RoleModel>>(roleFromRepo));
            }
            return Unauthorized("You are not authorized!");
        }

        [Authorize]
        [HttpGet("viewall")]
        public IActionResult GetAllEmployee()
        {
            var claims = HttpContext.User.Claims;
            var test = claims.Where(c => c.Type == "Role").FirstOrDefault().Value;            

            if (test == "Admin")
            {
                var empFromRepo = _employeeRepository.GetAllEmployee();
                return Ok(empFromRepo);
            }
            return Unauthorized("You are not authorized!");

        }


        [HttpGet("view/{empId}", Name = "GetEmpById")]
        public IActionResult GetEmpById(Guid empId)
        {
            var empFromRepo = _employeeRepository.GetEmployeeById(empId);
            if (empFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDTO>(empFromRepo));
        }

        [HttpPost]
        public ActionResult<EmployeeDTO> CreateEmployee([FromBody] EmployeeCreatingDTO emp)
        {
            if (emp.Email == null)
            {
                return BadRequest("Email not found");
            }
            var existEmp = _employeeRepository.GetEmployeeByEmail(emp.Email);

            if (existEmp != null)
            {
                return BadRequest("Email exists!");
            }

            var empEntity = _mapper.Map<EmployeeModel>(emp);
            empEntity.Password = new PasswordHasher<object>().HashPassword(null, emp.Password);
            _employeeRepository.AddEmployee(Guid.Empty, empEntity);
            _employeeRepository.Save();

            var empToResponse = _mapper.Map<EmployeeDTO>(empEntity);
            return CreatedAtRoute("GetEmpById", new { empId = empToResponse.Id }, empToResponse);
        }

        [HttpDelete("{empId}")]
        [Authorize]
        public ActionResult DeleteEmpById(Guid empId)
        {
            var empFromRepo = _employeeRepository.GetEmployeeById(empId);
            if (empFromRepo == null)
                return NotFound();

            var claims = HttpContext.User.Claims;
            var test = claims.Where(c => c.Type == "EmpId").FirstOrDefault().Value;
            var testAdmin = claims.Where(c => c.Type == "Role").FirstOrDefault().Value;

            if (empId == Guid.Parse(test))
            {
                return BadRequest("You can't delete yourself");
            }

            if (testAdmin != "Admin")
            {
                return Unauthorized("You are not authorized!");
            }

            _employeeRepository.DeleteEmployee(empFromRepo);
            _employeeRepository.Save();

            return NoContent();
        }

        [HttpPatch("{empId}")]
        public ActionResult EditEmployee(Guid empId, [FromBody] EmployeeForUpdate emp)
        {
            var empFromRepo = _employeeRepository.GetEmployeeById(empId);
            if (empFromRepo == null)
                return NotFound();

            var claims = HttpContext.User.Claims;
            var test = claims.Where(c => c.Type == "Role").FirstOrDefault().Value;

            if (test != "Admin")
            {
                return Unauthorized("You are not authorized!");
            }

            _mapper.Map(emp, empFromRepo);
            _employeeRepository.UpdateEmployee(empFromRepo);
            _employeeRepository.Save();

            return NoContent();
        }
        

        [HttpPost("auth")]
        public ActionResult Login([FromBody] AuthRequestModel auth)
        {
            if (auth.Username == null || auth.Password == null)
            {
                return BadRequest();
            }

            var empFromRepo = _employeeRepository.GetEmployeeByUserName(auth.Username);
            if (empFromRepo != null)
            {
                if (_employeeRepository.ComparePassword(empFromRepo.Password, auth.Password))
                {
                    var jwt = new JWTService(_config);
                    var roleName = _employeeRepository.GetRoleNameByRoleId(empFromRepo.RoleId);
                    var token = jwt.GenerateSecurityToken(empFromRepo.Email, empFromRepo.UserName, roleName, empFromRepo.Id);
                    var response = new AuthResponseModel(empFromRepo, token, roleName);
                    return Ok(response);
                }
            }
            return Unauthorized();
        }
    }
}
