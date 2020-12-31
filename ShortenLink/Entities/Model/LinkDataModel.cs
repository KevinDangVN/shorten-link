using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Model
{
    public class LinkDataModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FullLink { get; set; }

        [Required]
        public string ShortLink { get; set; }

        public DateTime CreatedAt { get; set; }

        // Add One-To-Many Relation
        [ForeignKey("EmployeeId")]
        public EmployeeModel Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
