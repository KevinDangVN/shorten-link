﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }
    }
}
