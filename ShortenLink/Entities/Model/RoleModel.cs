using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Model
{
    public class RoleModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
