using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class EmployeeCreatingDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

    }
}
