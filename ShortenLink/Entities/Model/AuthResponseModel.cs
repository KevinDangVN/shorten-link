using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class AuthResponseModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string AcToken { get; set; }
        public string UserId { get; set; }

        public AuthResponseModel(EmployeeModel employee, string token, string role)
        {
            UserName = employee.UserName;
            FullName = employee.FullName;
            Role = role;
            Email = employee.Email;
            AcToken = token;
            UserId = employee.Id.ToString();
        }
    }
}
