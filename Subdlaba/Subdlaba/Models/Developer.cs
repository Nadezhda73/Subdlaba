using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subdlaba.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Working_Role { get; set; }

        [ForeignKey("DeveloperId")]
        public virtual List<DeveloperTracker> DeveloperTrackers { get; set; }
    }
}
