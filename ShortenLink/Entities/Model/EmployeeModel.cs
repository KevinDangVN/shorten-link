using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Model
{
    public class EmployeeModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
        public RoleModel Role { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<LinkDataModel> LinkDatas { get; set; } = new List<LinkDataModel>();


    }
}
