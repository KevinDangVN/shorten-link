﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class AuthResponseModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public Guid RoleId { get; set; }
        public RoleModel Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthResponseModel(EmployeeModel employee, string token)
        {
            UserName = employee.UserName;        
            Role = employee.Role;           
            Email = employee.Email;
            Token = token;
        }
    }
}
